Imports System.Text
Imports System.Threading.Tasks
Imports System.Text.RegularExpressions

Public Class MicroFileSystem

    Private _helper As MicroSerialHelper

    Public Sub New(helper As MicroSerialHelper)
        _helper = helper
    End Sub

    Public Class FileItem
        Public Property Name As String
        Public Property IsFolder As Boolean
        Public Property Size As Long
    End Class

    ' --- SAFETY PROTOCOL ---
    ''' <summary>
    ''' CRITICAL: Clears the line and stops any running code before we start a file operation.
    ''' This fixes the "Soft Reboot" and "Syntax Error" issues after using the Command Center.
    ''' </summary>
' --- SAFETY PROTOCOL (ROBUST) ---
    Private Async Function PrepareConnectionAsync() As Task
        ' 1. THE INTERRUPT
        ' Send Ctrl+C (ASCII 3) twice. 
        ' This kills any running 'main.py' or infinite loop from the Command Center.
        Await _helper.SendRawBytesAsync({3, 3})
        Await Task.Delay(250) ' Wait for the "Traceback" text to flush

        ' 2. THE MODE SWITCH (FORCE RAW REPL)
        ' Send Ctrl+A (ASCII 1) to enter Raw Mode.
        ' We do this explicitly so the subsequent file commands (which use Ctrl+D) 
        ' don't accidentally trigger a Soft Reboot.
        Await _helper.SendRawBytesAsync({1})
        Await Task.Delay(100)

        ' 3. THE FLUSH (Optional but recommended)
        ' Send a dummy comment to clear any garbage from the input buffer
        ' before the real command arrives.
        Dim clearBuffer As Byte() = System.Text.Encoding.UTF8.GetBytes("#" & vbCr)
        Await _helper.SendRawBytesAsync(clearBuffer)
        Await Task.Delay(50)
    End Function

    ' --- LIST FILES ---
    Public Async Function ListFilesAsync(folderPath As String) As Task(Of List(Of FileItem))
        Await PrepareConnectionAsync() ' <--- SAFETY FIRST

        Dim result As New List(Of FileItem)
        Dim py As New StringBuilder()
        py.Append("try:import os" & vbLf & "except:import uos as os" & vbLf)
        py.Append("try:" & vbLf)
        py.Append(String.Format(" for f in os.ilistdir('{0}'):" & vbLf, folderPath))
        py.Append("  sz=f[3] if len(f)>3 else 0" & vbLf)
        py.Append("  print('{0}|{1}|{2}'.format(f[0],f[1],sz))" & vbLf)
        py.Append("except Exception as e:print('ERR:'+str(e))" & vbLf)

        Dim rawOutput As String = Await _helper.ExecuteCommandAsync(py.ToString())

        Dim lines As String() = rawOutput.Split({vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        For Each line In lines
            Dim clean = line.Trim()
            If clean = "" OrElse clean = ">" OrElse clean = "OK" Then Continue For
            If clean.StartsWith("OK") AndAlso clean.Contains("|") Then clean = clean.Substring(2)

            Dim parts = clean.Split("|"c)
            If parts.Length >= 3 Then
                Dim typeCode As Integer
                Dim sizeVal As Long
                If Integer.TryParse(parts(1), typeCode) AndAlso Long.TryParse(parts(2), sizeVal) Then
                    Dim itm As New FileItem()
                    itm.Name = parts(0)
                    itm.IsFolder = (typeCode = 16384)
                    itm.Size = sizeVal
                    result.Add(itm)
                End If
            End If
        Next
        Return result
    End Function

    ' --- UPLOAD ---
    Public Async Function UploadFileAsync(localPath As String, remotePath As String, progress As IProgress(Of Integer)) As Task(Of Boolean)
        Dim hasError As Boolean = False
        Dim errorMsg As String = ""

        Try
            Await PrepareConnectionAsync() ' <--- SAFETY FIRST

            If Not IO.File.Exists(localPath) Then Throw New IO.FileNotFoundException("Local file not found.")

            Dim fileBytes As Byte() = IO.File.ReadAllBytes(localPath)
            Dim totalBytes As Integer = fileBytes.Length
            Dim chunkSize As Integer = 512

            ' 1. Open File
            Dim setupCmd As New StringBuilder()
            setupCmd.AppendLine("import ubinascii")
            setupCmd.AppendLine(String.Format("f = open('{0}', 'wb')", remotePath))
            Await _helper.ExecuteCommandAsync(setupCmd.ToString())

            ' 2. Write Chunks
            Dim bytesSent As Integer = 0
            For i As Integer = 0 To totalBytes - 1 Step chunkSize
                Dim length As Integer = Math.Min(chunkSize, totalBytes - i)
                Dim hexChunk As String = BitConverter.ToString(fileBytes, i, length).Replace("-", "")

                Dim cmd As String = String.Format("f.write(ubinascii.unhexlify('{0}'))", hexChunk)
                Dim resp As String = Await _helper.ExecuteCommandAsync(cmd)

                If resp.Contains("Error") OrElse resp.Contains("Traceback") Then Throw New Exception("Write Error: " & resp)

                bytesSent += length
                Dim pct As Integer = CInt((bytesSent / totalBytes) * 100)
                If progress IsNot Nothing Then progress.Report(pct)
            Next

        Catch ex As Exception
            hasError = True
            errorMsg = ex.Message
        End Try

        If hasError Then
            Await _helper.ExecuteCommandAsync("try: f.close()" & vbLf & "except: pass")
            MessageBox.Show("Upload Failed: " & errorMsg)
            Return False
        Else
            Await _helper.ExecuteCommandAsync("f.close()")
            Return True
        End If
    End Function

    ' --- DOWNLOAD ---
    Public Async Function DownloadFileAsync(remotePath As String, localPath As String, progress As IProgress(Of Integer)) As Task(Of Boolean)
        Try
            Await PrepareConnectionAsync() ' <--- SAFETY FIRST

            ' 1. Get Size
            Dim sizeCmd As String = String.Format("import os; print(os.stat('{0}')[6])", remotePath)
            Dim sizeResp As String = Await _helper.ExecuteCommandAsync(sizeCmd)

            Dim sizeMatch = Regex.Match(sizeResp, "\d+")
            Dim totalBytes As Long = 0
            If sizeMatch.Success Then Long.TryParse(sizeMatch.Value, totalBytes)
            If totalBytes = 0 Then totalBytes = 1

            ' 2. Read
            Await _helper.ExecuteCommandAsync("import ubinascii")
            Await _helper.ExecuteCommandAsync(String.Format("f = open('{0}', 'rb')", remotePath))

            Dim receivedBytes As Long = 0
            Dim chunkSize As Integer = 512

            Using fs As New IO.FileStream(localPath, IO.FileMode.Create)
                While receivedBytes < totalBytes
                    Dim cmd As String = String.Format("print(ubinascii.hexlify(f.read({0})).decode())", chunkSize)
                    Dim resp As String = Await _helper.ExecuteCommandAsync(cmd)

                    Dim hexData As String = ExtractLongestHexString(resp)
                    If String.IsNullOrEmpty(hexData) Then
                        If receivedBytes >= totalBytes Then Exit While
                        Throw New Exception("Empty data received.")
                    End If

                    Dim bytes As Byte() = HexStringToBytes(hexData)
                    fs.Write(bytes, 0, bytes.Length)
                    receivedBytes += bytes.Length

                    Dim pct As Integer = CInt((receivedBytes / totalBytes) * 100)
                    If progress IsNot Nothing Then progress.Report(pct)
                End While
            End Using

            Await _helper.ExecuteCommandAsync("f.close()")
            Return True
        Catch ex As Exception
            MessageBox.Show("Download Error: " & ex.Message)
            Return False
        End Try
    End Function

    ' --- QUICK VIEW (READ STRING) ---
    Public Async Function ReadFileContentAsync(remotePath As String) As Task(Of String)
        Try
            Await PrepareConnectionAsync() ' <--- SAFETY FIRST

            Dim sizeCmd As String = String.Format("import os; print(os.stat('{0}')[6])", remotePath)
            Dim sizeResp As String = Await _helper.ExecuteCommandAsync(sizeCmd)

            Dim sizeMatch = Regex.Match(sizeResp, "\d+")
            Dim totalBytes As Long = 0
            If sizeMatch.Success Then Long.TryParse(sizeMatch.Value, totalBytes)

            If totalBytes > 100000 Then
                Throw New Exception("File is too large for Quick View. Please Download it.")
            End If

            Await _helper.ExecuteCommandAsync("import ubinascii")
            Await _helper.ExecuteCommandAsync(String.Format("f = open('{0}', 'rb')", remotePath))

            Dim cmd As String = "print(ubinascii.hexlify(f.read()).decode())"
            Dim resp As String = Await _helper.ExecuteCommandAsync(cmd)

            Await _helper.ExecuteCommandAsync("f.close()")

            Dim hexData As String = ExtractLongestHexString(resp)
            If String.IsNullOrEmpty(hexData) Then
                If totalBytes = 0 Then Return String.Empty
                Throw New Exception("Could not read file data.")
            End If

            Dim bytes As Byte() = HexStringToBytes(hexData)
            Return Encoding.UTF8.GetString(bytes)

        Catch ex As Exception
            Return "Error reading file: " & ex.Message
        End Try
    End Function

    ' --- HELPERS ---
    Private Function ExtractLongestHexString(raw As String) As String
        Dim matches = Regex.Matches(raw, "[A-Fa-f0-9]+")
        Dim longest As String = ""
        For Each m As Match In matches
            If m.Value.Length > longest.Length Then longest = m.Value
        Next
        Return longest
    End Function

    Private Function HexStringToBytes(hex As String) As Byte()
        Dim numberChars As Integer = hex.Length
        Dim bytes As Byte() = New Byte(numberChars / 2 - 1) {}
        For i As Integer = 0 To numberChars - 1 Step 2
            bytes(i / 2) = Convert.ToByte(hex.Substring(i, 2), 16)
        Next
        Return bytes
    End Function

    Public Async Function DeleteFileAsync(remotePath As String) As Task(Of Boolean)
        Try
            Await PrepareConnectionAsync() ' <--- SAFETY FIRST

            Dim cmd As String = String.Format("import os; os.remove('{0}')", remotePath)
            Dim resp As String = Await _helper.ExecuteCommandAsync(cmd)
            If resp.Contains("Error") Then
                cmd = String.Format("os.rmdir('{0}')", remotePath)
                resp = Await _helper.ExecuteCommandAsync(cmd)
            End If
            If resp.Contains("Error") Then Throw New Exception(resp)
            Return True
        Catch ex As Exception
            MessageBox.Show("Delete Error: " & ex.Message)
            Return False
        End Try
    End Function

End Class
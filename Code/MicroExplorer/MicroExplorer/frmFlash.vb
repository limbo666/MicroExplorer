Imports System.IO
Imports System.Diagnostics
Imports System.Text.RegularExpressions

Public Class frmFlash

    ' Path to the external tool
    Private _toolPath As String = Path.Combine(Application.StartupPath, "esptool.exe")
    Private _downloadUrl As String = "https://github.com/espressif/esptool/releases"

    ' Property to accept COM port from Main Form
    Public Property TargetPort As String = ""

    Private Sub frmFlash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Check for Tool
        If File.Exists(_toolPath) Then
            lblToolStatus.Text = "esptool.exe found."
            lblToolStatus.ForeColor = Color.DarkGreen
            lnkDownload.Visible = False
            grpSettings.Enabled = True
            grpFirmware.Enabled = True
            btnFlash.Enabled = True
        Else
            lblToolStatus.Text = "esptool.exe NOT found!"
            lblToolStatus.ForeColor = Color.Red
            lnkDownload.Visible = True
            grpSettings.Enabled = False
            grpFirmware.Enabled = False
            btnFlash.Enabled = False
            rtbLog.AppendText("CRITICAL ERROR: esptool.exe is missing." & vbCrLf)
            rtbLog.AppendText("Please download the standalone executable and place it in:" & vbCrLf)
            rtbLog.AppendText(Application.StartupPath & vbCrLf)
        End If

        ' 2. Populate Ports
        cmbPort.Items.AddRange(IO.Ports.SerialPort.GetPortNames())
        If Not String.IsNullOrEmpty(TargetPort) AndAlso cmbPort.Items.Contains(TargetPort) Then
            cmbPort.SelectedItem = TargetPort
        ElseIf cmbPort.Items.Count > 0 Then
            cmbPort.SelectedIndex = 0
        End If

        ' 3. Populate Chips
        cmbChip.Items.AddRange({"esp32", "esp32c3", "esp32s3", "esp32s2", "esp8266"})
        cmbChip.SelectedItem = "esp32" ' Default
    End Sub

    ' --- HELPER: HANDLE TOOL DOWNLOAD ---
    Private Sub lnkDownload_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkDownload.LinkClicked
        Process.Start(New ProcessStartInfo(_downloadUrl) With {.UseShellExecute = True})
    End Sub

    ' --- LOGIC: CHIP OFFSET ---
    Private Sub cmbChip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbChip.SelectedIndexChanged
        ' Logic: Original ESP32 needs offset 0x1000. Newer chips (C3, S3) usually start at 0x0.
        Dim chip = cmbChip.SelectedItem.ToString()
        If chip = "esp32" Then
            lblOffset.Text = "Offset: 0x1000"
            lblOffset.Tag = "0x1000"
        Else
            lblOffset.Text = "Offset: 0x0"
            lblOffset.Tag = "0x0"
        End If
    End Sub

    ' --- ACTION: BROWSE ---
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using ofd As New OpenFileDialog()
            ofd.Filter = "Bin Files|*.bin|All Files|*.*"
            If ofd.ShowDialog() = DialogResult.OK Then
                txtBinPath.Text = ofd.FileName
            End If
        End Using
    End Sub

    ' --- ACTION: DETECT CHIP ---
    Private Async Sub btnDetect_Click(sender As Object, e As EventArgs) Handles btnDetect.Click
        If String.IsNullOrEmpty(cmbPort.Text) Then Return

        btnDetect.Enabled = False
        rtbLog.Clear()
        Log(">>> Detecting Chip Details...")

        ' Command: esptool.exe --port COMx chip_id
        Dim args As String = $"--port {cmbPort.Text} chip_id"
        Dim output As String = Await RunEsptoolAsync(args)

        ' Parse Output
        If output.Contains("ESP32-C3") Then
            SelectChip("esp32c3")
        ElseIf output.Contains("ESP32-S3") Then
            SelectChip("esp32s3")
        ElseIf output.Contains("ESP32-S2") Then
            SelectChip("esp32s2")
        ElseIf output.Contains("ESP8266") Then
            SelectChip("esp8266")
        ElseIf output.Contains("ESP32") Then
            SelectChip("esp32")
        Else
            Log(">>> Could not auto-identify chip flavor. Please select manually.")
        End If

        btnDetect.Enabled = True
    End Sub

    Private Sub SelectChip(chip As String)
        If cmbChip.Items.Contains(chip) Then
            cmbChip.SelectedItem = chip
            Log($">>> Detected: {chip.ToUpper()}")
        End If
    End Sub

    ' --- ACTION: FLASH ---
    Private Async Sub btnFlash_Click(sender As Object, e As EventArgs) Handles btnFlash.Click
        If String.IsNullOrEmpty(txtBinPath.Text) OrElse Not File.Exists(txtBinPath.Text) Then
            MessageBox.Show("Please select a valid .bin file.")
            Return
        End If

        If MessageBox.Show("Ready to flash firmware. This involves risk." & vbCrLf &
                           "Ensure you selected the correct Chip Type." & vbCrLf & vbCrLf &
                           "Proceed?", "Confirm Flash", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return

        btnFlash.Enabled = False
        btnDetect.Enabled = False

        Dim port = cmbPort.Text
        Dim chip = cmbChip.Text
        Dim offset = lblOffset.Tag.ToString()
        Dim binPath = txtBinPath.Text

        rtbLog.Clear()

        Try
            ' 1. ERASE (Optional)
            If chkErase.Checked Then
                Log(">>> Starting ERASE operation...")
                Await RunEsptoolAsync($"--port {port} --chip {chip} erase_flash")
                Log(">>> Erase Complete.")
                Await Task.Delay(1000) ' Cool down
            End If

            ' 2. WRITE
            Log($">>> Starting WRITE operation (Offset {offset})...")
            ' Using 460800 baud for speed. If it fails, drop to 115200.
            Dim args As String = $"--chip {chip} --port {port} --baud 460800 write_flash -z {offset} ""{binPath}"""

            Await RunEsptoolAsync(args)

            Log("------------------------------------------------")
            Log(">>> FLASHING COMPLETE! Please Reset the Board.")
            Log("------------------------------------------------")
            MessageBox.Show("Firmware update successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            Log("ERR: " & ex.Message)
            MessageBox.Show("Error during flash process. Check log.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnFlash.Enabled = True
            btnDetect.Enabled = True
        End Try
    End Sub

    ' --- ENGINE: RUN PROCESS ---
    Private Function RunEsptoolAsync(arguments As String) As Task(Of String)
        Dim tcs As New TaskCompletionSource(Of String)
        Dim fullOutput As New System.Text.StringBuilder()

        Dim p As New Process()
        p.StartInfo.FileName = _toolPath
        p.StartInfo.Arguments = arguments
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardError = True
        p.StartInfo.CreateNoWindow = True

        ' Real-time log handlers
        AddHandler p.OutputDataReceived, Sub(s, args)
                                             If args.Data IsNot Nothing Then
                                                 fullOutput.AppendLine(args.Data)
                                                 Me.BeginInvoke(Sub() Log(args.Data))
                                             End If
                                         End Sub
        AddHandler p.ErrorDataReceived, Sub(s, args)
                                            If args.Data IsNot Nothing Then
                                                fullOutput.AppendLine(args.Data)
                                                Me.BeginInvoke(Sub() Log("STDERR: " & args.Data))
                                            End If
                                        End Sub

        p.EnableRaisingEvents = True
        AddHandler p.Exited, Sub(s, args)
                                 tcs.SetResult(fullOutput.ToString())
                             End Sub

        p.Start()
        p.BeginOutputReadLine()
        p.BeginErrorReadLine()

        Return tcs.Task
    End Function

    Private Sub Log(text As String)
        If rtbLog.IsDisposed Then Return
        rtbLog.AppendText(text & vbCrLf)
        rtbLog.ScrollToCaret()
    End Sub

End Class
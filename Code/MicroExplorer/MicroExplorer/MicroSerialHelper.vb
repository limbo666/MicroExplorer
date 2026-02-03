Imports System.IO.Ports
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

Public Class MicroSerialHelper
    Private _serial As SerialPort
    Private _cancellationTokenSource As CancellationTokenSource

    Public Event DataReceived(text As String)
    Public Event ConnectionStatusChanged(isConnected As Boolean, message As String)

    ' Thread-safe state
    Public ReadOnly Property IsConnected As Boolean
        Get
            Return _serial IsNot Nothing AndAlso _serial.IsOpen
        End Get
    End Property

    Public ReadOnly Property CurrentPort As String
        Get
            If _serial IsNot Nothing Then Return _serial.PortName
            Return String.Empty
        End Get
    End Property

    Public Async Function ConnectAsync(portName As String) As Task(Of Boolean)
        Disconnect()

        Try
            _serial = New SerialPort(portName, 115200, Parity.None, 8, StopBits.One)
            _serial.DtrEnable = True
            _serial.RtsEnable = True
            _serial.ReadTimeout = 500
            _serial.WriteTimeout = 1000

            _serial.Open()

            RaiseEvent ConnectionStatusChanged(False, "Port Open. Waiting for device...")
            Await Task.Delay(1500)

            _serial.DiscardInBuffer()

            ' 1. Interrupt active scripts (Manual Write)
            Dim interrupt As Byte() = {3}
            Await _serial.BaseStream.WriteAsync(interrupt, 0, 1)
            Await Task.Delay(100)
            Await _serial.BaseStream.WriteAsync(interrupt, 0, 1)

            ' 2. Enter Raw REPL (Manual Write)
            Dim rawMode As Byte() = {1}
            Await _serial.BaseStream.WriteAsync(rawMode, 0, 1)

            ' 3. Verify Handshake (Manual Read for safety during setup)
            ' We do a temporary read loop here just for the handshake
            Dim response As String = Await ReadOneShotAsync("raw REPL; CTRL-B to exit", 2500)
            If String.IsNullOrEmpty(response) Then Throw New Exception("Device did not enter Raw REPL mode.")

            ' Clear prompt
            Await ReadOneShotAsync(">", 1000)

            ' 4. START THE PERMANENT LISTENER
            ' This is the missing piece! It keeps reading forever.
            _cancellationTokenSource = New CancellationTokenSource()
            StartListeningLoop(_cancellationTokenSource.Token)

            RaiseEvent ConnectionStatusChanged(True, "Connected")
            Return True

        Catch ex As Exception
            Disconnect()
            RaiseEvent ConnectionStatusChanged(False, "Error: " & ex.Message)
            Return False
        End Try
    End Function

    Public Sub Disconnect()
        Try
            ' Stop the background loop
            If _cancellationTokenSource IsNot Nothing Then
                _cancellationTokenSource.Cancel()
            End If

            If _serial IsNot Nothing Then
                If _serial.IsOpen Then
                    Try
                        Dim b() As Byte = {2} ' Exit Raw REPL
                        _serial.Write(b, 0, 1)
                        _serial.Close()
                    Catch
                    End Try
                End If
                _serial.Dispose()
            End If
        Catch ex As Exception
        Finally
            _serial = Nothing
            RaiseEvent ConnectionStatusChanged(False, "Disconnected")
        End Try
    End Sub

    ''' <summary>
    ''' The Heart: Constantly reads serial data and pushes it to events.
    ''' </summary>
    Private Async Sub StartListeningLoop(token As CancellationToken)
        Dim buffer(1024) As Byte

        Try
            While Not token.IsCancellationRequested AndAlso IsConnected
                If _serial.BytesToRead > 0 Then
                    Dim count As Integer = Await _serial.BaseStream.ReadAsync(buffer, 0, buffer.Length, token)
                    If count > 0 Then
                        Dim chunk As String = Encoding.UTF8.GetString(buffer, 0, count)
                        RaiseEvent DataReceived(chunk)
                    End If
                Else
                    ' Short delay to prevent CPU hogging
                    Await Task.Delay(20, token)
                End If
            End While
        Catch ex As TaskCanceledException
            ' Normal shutdown
        Catch ex As Exception
            ' If the loop crashes (e.g. unplugged), ensure we disconnect
            Disconnect()
        End Try
    End Sub

    ''' <summary>
    ''' Helper: Reads strictly for initialization (before the loop starts).
    ''' </summary>
    Private Async Function ReadOneShotAsync(target As String, timeoutMs As Integer) As Task(Of String)
        Dim sb As New StringBuilder()
        Dim buffer(1024) As Byte
        Dim startTime = DateTime.Now

        While (DateTime.Now - startTime).TotalMilliseconds < timeoutMs
            If _serial.BytesToRead > 0 Then
                Dim count As Integer = Await _serial.BaseStream.ReadAsync(buffer, 0, buffer.Length)
                Dim chunk As String = Encoding.UTF8.GetString(buffer, 0, count)
                sb.Append(chunk)
                ' We also raise the event so the user sees the boot logs
                RaiseEvent DataReceived(chunk)
                If sb.ToString().Contains(target) Then Return sb.ToString()
            Else
                Await Task.Delay(20)
            End If
        End While
        Return String.Empty
    End Function

    ''' <summary>
    ''' Executes a command relying on the background loop to deliver the response.
    ''' </summary>
    Public Async Function ExecuteCommandAsync(pythonCode As String) As Task(Of String)
        If Not IsConnected Then Return String.Empty

        Dim responseBuffer As New StringBuilder()
        Dim tcs As New TaskCompletionSource(Of Boolean)

        ' Hook into the stream
        Dim handler As MicroSerialHelper.DataReceivedEventHandler =
            Sub(text As String)
                responseBuffer.Append(text)
                If responseBuffer.ToString().Contains(">") Then
                    tcs.TrySetResult(True)
                End If
            End Sub

        AddHandler Me.DataReceived, handler

        Try
            ' 1. Clear previous garbage (optional but good)
            ' We can't easily clear the StringBuilder from the event, so we rely on the prompt check

            ' 2. Send Code
            Dim data As Byte() = Encoding.UTF8.GetBytes(pythonCode)
            Await _serial.BaseStream.WriteAsync(data, 0, data.Length)

            ' 3. Send Execute Signal (Ctrl+D)
            Dim eof As Byte() = {4}
            Await _serial.BaseStream.WriteAsync(eof, 0, eof.Length)

            ' 4. Wait for the ">" prompt from the background loop
            Dim finishedTask = Await Task.WhenAny(tcs.Task, Task.Delay(8000))

            If finishedTask Is tcs.Task Then
                Return responseBuffer.ToString()
            Else
                Return "Error: Timeout - No response received."
            End If

        Catch ex As Exception
            Return "Error: " & ex.Message
        Finally
            RemoveHandler Me.DataReceived, handler
        End Try
    End Function
    ''' <summary>
    ''' Sends raw bytes directly. Used for Reset commands where we expect the connection to drop.
    ''' </summary>
    Public Async Function SendRawBytesAsync(data As Byte()) As Task
        If _serial IsNot Nothing AndAlso _serial.IsOpen Then
            Await _serial.BaseStream.WriteAsync(data, 0, data.Length)
            Await _serial.BaseStream.FlushAsync()
        End If
    End Function
    Public Shared Function GetPorts() As String()
        Return SerialPort.GetPortNames()
    End Function
End Class
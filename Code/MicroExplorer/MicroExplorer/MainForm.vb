Imports System.Collections.ObjectModel
Imports System.IO

Public Class MainForm

    ' --- CORE COMPONENTS ---
    Private _fs As MicroFileSystem
    Private WithEvents _micro As New MicroSerialHelper()
    Private WithEvents tmrWatchdog As New Timer()

    ' --- CONTEXT MENUS ---
    Private WithEvents cmsLocal As New ContextMenuStrip()
    Private WithEvents cmsRemote As New ContextMenuStrip()

    ' --- STATE ---
    Private _targetPort As String = String.Empty
    Private _waitingForDevice As Boolean = False
    Private _isSyncing As Boolean = False
    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Handle Cold Start Arguments
        If My.Application.CommandLineArgs.Count > 0 Then
            ProcessCommandLineArgs(My.Application.CommandLineArgs)
        End If
    End Sub

    ''' <summary>
    ''' Central Hub for processing external arguments (Reset, Run, Upload).
    ''' Works for both Cold Start and Hot Start.
    ''' </summary>
    Public Async Sub ProcessCommandLineArgs(args As System.Collections.ObjectModel.ReadOnlyCollection(Of String))
        If args.Count = 0 Then Return

        Dim switch As String = args(0).ToLower()
        Dim param As String = If(args.Count > 1, args(1), "")

        LogTerminal(vbCrLf & ">>> External Command Received: " & switch & vbCrLf, Color.Cyan)

        ' 1. AUTO-CONNECT (If needed)
        If Not _micro.IsConnected Then
            Dim lastPort As String = My.Settings.LastComPort
            If String.IsNullOrEmpty(lastPort) OrElse Not cmbPorts.Items.Contains(lastPort) Then
                LogTerminal(">>> Error: Cannot execute '" & switch & "'. Device not connected and no last port found." & vbCrLf, Color.Red)
                Return
            End If

            LogTerminal(">>> Auto-Connecting to " & lastPort & "..." & vbCrLf, Color.Orange)
            Dim connected As Boolean = Await PerformConnection(lastPort)
            If Not connected Then
                LogTerminal(">>> Auto-Connect Failed. Aborting command." & vbCrLf, Color.Red)
                Return
            End If
        End If

        ' 2. EXECUTE COMMAND
        Try
            Select Case switch
                Case "-reset"
                    ' Trigger Soft Reset Button Logic
                    btnSoftReset.PerformClick()

                Case "-runmain"
                    ' Trigger Run Main Button Logic
                    btnRunMain.PerformClick()

                Case "-upload"
                    ' Upload Only
                    If Not String.IsNullOrEmpty(param) Then HandleExternalUpload(param, False)

                Case "-uploadrun"
                    ' Upload AND Execute
                    If Not String.IsNullOrEmpty(param) Then HandleExternalUpload(param, True)
            End Select
        Catch ex As Exception
            LogTerminal(">>> Command Execution Error: " & ex.Message & vbCrLf, Color.Red)
        End Try
    End Sub

    ''' <summary>
    ''' Helper to Upload and optionally Run a file.
    ''' </summary>
    Private Async Sub HandleExternalUpload(localPath As String, runAfter As Boolean)
        If Not IO.File.Exists(localPath) Then
            LogTerminal(">>> Error: File not found: " & localPath & vbCrLf, Color.Red)
            Return
        End If

        Dim filename = IO.Path.GetFileName(localPath)
        Dim remoteDir = txtDevicePath.Text
        Dim remotePath = If(remoteDir.EndsWith("/"), remoteDir & filename, remoteDir & "/" & filename)

        ' 1. Upload
        LogTerminal(">>> Uploading: " & filename & "..." & vbCrLf, Color.Cyan)
        SetTransferState(True)
        Dim progress As New Progress(Of Integer)(Sub(pct) pbTransfer.Value = pct)
        Dim success As Boolean = Await _fs.UploadFileAsync(localPath, remotePath, progress)
        SetTransferState(False)

        ' 2. Run (If requested)
        If success Then
            LogTerminal(">>> Upload Complete." & vbCrLf, Color.Lime)
            If runAfter Then
                LogTerminal(">>> Executing " & filename & "..." & vbCrLf, Color.Cyan)
                ' Send the MicroPython execute command safely
                ExecuteExternalCommand("exec(open('" & remotePath & "').read())")
            End If
            ' Refresh UI
            Await RefreshFileList()
        End If
    End Sub


    ' --- INITIALIZATION ---
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Restore Settings
        Try
            If My.Settings.FormSize.Width > 0 Then
                Me.Size = My.Settings.FormSize
                Me.Location = My.Settings.FormLoc
            End If
            If My.Settings.FormState = FormWindowState.Maximized Then Me.WindowState = FormWindowState.Maximized
        Catch
        End Try

        Me.Text = "MicroExplorer - " & Application.ProductVersion
        ' 2. Initialize Helpers
        _fs = New MicroFileSystem(_micro)

        ' 3. Initialize Context Menus
        InitContextMenus()
        SetupTerminal()
        ' 4. UI Init
        UpdateUI_Safe(My.Computer.Ports.SerialPortNames)

        Dim lastPort As String = My.Settings.LastComPort
        If cmbPorts.Items.Contains(lastPort) Then cmbPorts.SelectedItem = lastPort

        ' 5. Load Last Local Path
        Dim lastPath As String = My.Settings.LastLocalPath
        If String.IsNullOrWhiteSpace(lastPath) OrElse Not IO.Directory.Exists(lastPath) Then
            lastPath = "C:\"
        End If
        LoadLocalFiles(lastPath)

        UpdateConnectionStateUI(False)




        SetupButtonIcons()


        ' 6. Start Watchdog
        tmrWatchdog.Interval = 1000
        tmrWatchdog.Start()
    End Sub









    Private Sub SetupButtonIcons()
        btnDelete.ImageList = ImageList2
        btnDelete.ImageIndex = 0 ' Index of your 'Connect' icon
        btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText
        btnDelete.TextAlign = ContentAlignment.MiddleRight
        btnDelete.ImageAlign = ContentAlignment.MiddleLeft


        btnUpload.ImageList = ImageList2
        btnUpload.ImageIndex = 2 ' Upload Icon
        btnUpload.TextImageRelation = TextImageRelation.ImageBeforeText

        btnDownload.ImageList = ImageList2
        btnDownload.ImageIndex = 1 ' Download Icon
        btnDownload.TextImageRelation = TextImageRelation.ImageBeforeText


        btnConnect.ImageList = ImageList2
        btnConnect.ImageIndex = 9 '  Icon
        btnConnect.TextImageRelation = TextImageRelation.ImageBeforeText

        btnMkDir.ImageList = ImageList2
        btnMkDir.ImageIndex = 5 '  Icon
        btnMkDir.TextImageRelation = TextImageRelation.ImageBeforeText

        btnSoftReset.ImageList = ImageList2
        btnSoftReset.ImageIndex = 7 '  Icon
        btnSoftReset.TextImageRelation = TextImageRelation.ImageBeforeText

        btnRunMain.ImageList = ImageList2
        btnRunMain.ImageIndex = 8 '  Icon
        btnRunMain.TextImageRelation = TextImageRelation.ImageBeforeText

        btnDiskSpace.ImageList = ImageList2
        btnDiskSpace.ImageIndex = 4 '  Icon
        btnDiskSpace.TextImageRelation = TextImageRelation.ImageBeforeText

        btnTimeSync.ImageList = ImageList2
        btnTimeSync.ImageIndex = 13 '  Icon
        btnTimeSync.TextImageRelation = TextImageRelation.ImageBeforeText


        btnWiFi.ImageList = ImageList2
        btnWiFi.ImageIndex = 12 '  Icon
        btnWiFi.TextImageRelation = TextImageRelation.ImageBeforeText

        btnRam.ImageList = ImageList2
        btnRam.ImageIndex = 6 '  Icon
        btnRam.TextImageRelation = TextImageRelation.ImageBeforeText


        btnQuickView.ImageList = ImageList2
        btnQuickView.ImageIndex = 11 '  Icon
        btnQuickView.TextImageRelation = TextImageRelation.ImageBeforeText




        btnCmdCenter.ImageList = ImageList2
        btnCmdCenter.ImageIndex = 3 '  Icon
        btnCmdCenter.TextImageRelation = TextImageRelation.ImageBeforeText



        btnLocalUp.ImageList = ImageList2
        btnLocalUp.ImageIndex = 10 '  Icon
        btnLocalUp.TextImageRelation = TextImageRelation.ImageBeforeText

        btnDeviceUp.ImageList = ImageList2
        btnDeviceUp.ImageIndex = 10 '  Icon
        btnDeviceUp.TextImageRelation = TextImageRelation.ImageBeforeText



        btnFlash.ImageList = ImageList2
        btnFlash.ImageIndex = 16 '  Icon
        btnFlash.TextImageRelation = TextImageRelation.ImageAboveText

    End Sub














    Private Sub InitContextMenus()
        ' --- LOCAL MENU ---
        ' FIX: Added the 'With' keyword before the curly braces
        Dim itemOpen As New ToolStripMenuItem("Open", Nothing, AddressOf LocalOpen_Click) With {.Font = New Font(Me.Font, FontStyle.Bold)}

        Dim itemOpenWith As New ToolStripMenuItem("Open with...", Nothing, AddressOf LocalOpenWith_Click)
        Dim itemRename As New ToolStripMenuItem("Rename", Nothing, AddressOf LocalRename_Click)
        Dim itemDelete As New ToolStripMenuItem("Delete (Recycle)", Nothing, AddressOf LocalDelete_Click)

        cmsLocal.Items.AddRange({itemOpen, itemOpenWith, New ToolStripSeparator(), itemRename, New ToolStripSeparator(), itemDelete})

        ' --- REMOTE MENU ---
        Dim itemDownload As New ToolStripMenuItem("Download", Nothing, AddressOf btnDownload_Click)
        Dim itemRemDelete As New ToolStripMenuItem("Delete", Nothing, AddressOf btnDelete_Click)

        cmsRemote.Items.AddRange({itemDownload, New ToolStripSeparator(), itemRemDelete})
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        tmrWatchdog.Stop()
        _micro.Disconnect()

        My.Settings.FormState = Me.WindowState
        If Me.WindowState = FormWindowState.Normal Then
            My.Settings.FormSize = Me.Size
            My.Settings.FormLoc = Me.Location
        Else
            My.Settings.FormSize = Me.RestoreBounds.Size
            My.Settings.FormLoc = Me.RestoreBounds.Location
        End If
        My.Settings.Save()
    End Sub

    ' --- LOCAL FILE LOGIC (NEW FEATURES) ---

    Private Sub lvLocal_MouseClick(sender As Object, e As MouseEventArgs) Handles lvLocal.MouseClick
        If e.Button = MouseButtons.Right AndAlso lvLocal.SelectedItems.Count > 0 Then
            ' Enable "Open" options only for files, not folders
            Dim isFile As Boolean = (lvLocal.SelectedItems(0).Tag.ToString() = "FILE")
            cmsLocal.Items(0).Enabled = isFile ' Open
            cmsLocal.Items(1).Enabled = isFile ' Open With
            cmsLocal.Show(Cursor.Position)
        End If
    End Sub

    Private Sub lvLocal_DoubleClick(sender As Object, e As EventArgs) Handles lvLocal.DoubleClick
        If lvLocal.SelectedItems.Count = 0 Then Return
        Dim item = lvLocal.SelectedItems(0)

        If item.Tag.ToString() = "DIR" Then
            ' Navigate
            LoadLocalFiles(IO.Path.Combine(txtLocalPath.Text, item.Text))
        Else
            ' Open File
            LocalOpen_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub LocalOpen_Click(sender As Object, e As EventArgs)
        Try
            Dim path As String = IO.Path.Combine(txtLocalPath.Text, lvLocal.SelectedItems(0).Text)
            Process.Start(New ProcessStartInfo(path) With {.UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show("Could not open file: " & ex.Message)
        End Try
    End Sub

    Private Sub LocalOpenWith_Click(sender As Object, e As EventArgs)
        Try
            Dim path As String = IO.Path.Combine(txtLocalPath.Text, lvLocal.SelectedItems(0).Text)
            ' Windows trick to show "Open With" dialog
            Process.Start("rundll32.exe", "shell32.dll,OpenAs_RunDLL " & path)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LocalRename_Click(sender As Object, e As EventArgs)
        Dim item = lvLocal.SelectedItems(0)
        Dim oldName = item.Text
        Dim newName = InputBox("Enter new name:", "Rename", oldName)

        If String.IsNullOrWhiteSpace(newName) OrElse newName = oldName Then Return

        Try
            Dim oldPath = IO.Path.Combine(txtLocalPath.Text, oldName)
            Dim newPath = IO.Path.Combine(txtLocalPath.Text, newName)

            If item.Tag.ToString() = "DIR" Then
                IO.Directory.Move(oldPath, newPath)
            Else
                IO.File.Move(oldPath, newPath)
            End If
            LoadLocalFiles(txtLocalPath.Text)
        Catch ex As Exception
            MessageBox.Show("Rename Failed: " & ex.Message)
        End Try
    End Sub

    Private Sub LocalDelete_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Move " & lvLocal.SelectedItems.Count & " items to Recycle Bin?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.No Then Return

        Try
            For Each item As ListViewItem In lvLocal.SelectedItems
                Dim path = IO.Path.Combine(txtLocalPath.Text, item.Text)
                If item.Tag.ToString() = "DIR" Then
                    My.Computer.FileSystem.DeleteDirectory(path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                Else
                    My.Computer.FileSystem.DeleteFile(path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                End If
            Next
            LoadLocalFiles(txtLocalPath.Text)
        Catch ex As Exception
            MessageBox.Show("Delete Failed: " & ex.Message)
        End Try
    End Sub

    ' --- REMOTE FILE LOGIC (CONTEXT MENU) ---

    Private Sub lvDevice_MouseClick(sender As Object, e As MouseEventArgs) Handles lvDevice.MouseClick
        If e.Button = MouseButtons.Right AndAlso lvDevice.SelectedItems.Count > 0 Then
            cmsRemote.Show(Cursor.Position)
        End If
    End Sub

    Private Sub lvDevice_DoubleClick(sender As Object, e As EventArgs) Handles lvDevice.DoubleClick
        If lvDevice.SelectedItems.Count = 0 Then Return
        Dim item = lvDevice.SelectedItems(0)
        If item.Tag.ToString() = "DIR" Then
            Dim current = txtDevicePath.Text
            Dim newPath As String = If(current = "/", "/" & item.Text, current & "/" & item.Text)
            LoadDeviceFiles(newPath)
        End If
    End Sub

    ' --- MULTI-FILE OPERATIONS ---

    ' 1. UPLOAD (PC -> Device) - Supports Multiple Files
    Private Async Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If Not _micro.IsConnected Then Return
        If lvLocal.SelectedItems.Count = 0 Then Return

        Dim count As Integer = lvLocal.SelectedItems.Count
        Dim filesUploaded As Integer = 0

        SetTransferState(True)

        For Each item As ListViewItem In lvLocal.SelectedItems
            If item.Tag.ToString() = "DIR" Then Continue For ' Skip folders for now

            Dim filename = item.Text
            Dim localPath = IO.Path.Combine(txtLocalPath.Text, filename)
            Dim remoteDir = txtDevicePath.Text
            Dim remotePath = If(remoteDir.EndsWith("/"), remoteDir & filename, remoteDir & "/" & filename)

            rtbTerminal.AppendText(vbCrLf & ">>> Uploading (" & (filesUploaded + 1) & "/" & count & "): " & filename & "..." & vbCrLf)

            Dim progress As New Progress(Of Integer)(Sub(pct) pbTransfer.Value = pct)
            Dim success As Boolean = Await _fs.UploadFileAsync(localPath, remotePath, progress)

            If success Then filesUploaded += 1
        Next

        SetTransferState(False)

        If filesUploaded > 0 Then
            rtbTerminal.AppendText(">>> Batch Upload Complete." & vbCrLf)
            Await RefreshFileList()
        End If
    End Sub

    ' 2. DOWNLOAD (Device -> PC) - Supports Multiple Files
    Private Async Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If Not _micro.IsConnected Then Return
        If lvDevice.SelectedItems.Count = 0 Then Return

        Dim count As Integer = lvDevice.SelectedItems.Count
        Dim filesDownloaded As Integer = 0
        Dim localDir = txtLocalPath.Text

        SetTransferState(True)

        For Each item As ListViewItem In lvDevice.SelectedItems
            If item.Tag.ToString() = "DIR" Then Continue For ' Skip folders

            Dim filename = item.Text
            Dim localPath = IO.Path.Combine(localDir, filename)
            Dim remoteDir = txtDevicePath.Text
            Dim remotePath = If(remoteDir.EndsWith("/"), remoteDir & filename, remoteDir & "/" & filename)

            ' Confirmation if exists (Once per file, or you could implement "Yes to All" logic later)
            If IO.File.Exists(localPath) Then
                If MessageBox.Show("Overwrite '" & filename & "'?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.No Then Continue For
            End If

            rtbTerminal.AppendText(vbCrLf & ">>> Downloading (" & (filesDownloaded + 1) & "/" & count & "): " & filename & "..." & vbCrLf)

            Dim progress As New Progress(Of Integer)(Sub(pct) pbTransfer.Value = pct)
            Dim success As Boolean = Await _fs.DownloadFileAsync(remotePath, localPath, progress)

            If success Then filesDownloaded += 1
        Next

        SetTransferState(False)

        If filesDownloaded > 0 Then
            rtbTerminal.AppendText(">>> Batch Download Complete." & vbCrLf)
            LoadLocalFiles(localDir)
        End If
    End Sub

    ' 3. DELETE REMOTE - Supports Multiple Files
    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not _micro.IsConnected OrElse lvDevice.SelectedItems.Count = 0 Then Return

        Dim count As Integer = lvDevice.SelectedItems.Count
        If MessageBox.Show("Permanently delete " & count & " items from Device?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then Return

        rtbTerminal.AppendText(vbCrLf & ">>> Batch Deleting..." & vbCrLf)

        Dim currentDir = txtDevicePath.Text

        For Each item As ListViewItem In lvDevice.SelectedItems
            Dim filename = item.Text
            Dim remotePath = If(currentDir.EndsWith("/"), currentDir & filename, currentDir & "/" & filename)

            Await _fs.DeleteFileAsync(remotePath)
        Next

        rtbTerminal.AppendText(">>> Done." & vbCrLf)
        Await RefreshFileList()
    End Sub

    ' --- STANDARD INFRASTRUCTURE ---

    ' Change 'Sub' to 'Function' and add 'As Task(Of Boolean)'
    Private Async Function PerformConnection(portName As String) As Task(Of Boolean)
        btnConnect.Enabled = False
        btnConnect.Text = "Processing..."
        lblStatus.Text = "Connecting..."
        lblStatus.ForeColor = Color.Orange

        Dim success As Boolean = Await _micro.ConnectAsync(portName)

        If success Then
            My.Settings.LastComPort = portName
            My.Settings.Save()
            _waitingForDevice = False

            ' Re-enable so we can disconnect later
            btnConnect.Enabled = True

            rtbTerminal.AppendText(">>> Connection Established. Listing files..." & vbCrLf)
            Await LoadDeviceFiles("/")
        Else
            btnConnect.Enabled = True
            btnConnect.Text = "Connect"
        End If

        Return success ' <--- Return the result
    End Function
    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If btnConnect.Text.Contains("...") Then Return

        If _waitingForDevice AndAlso btnConnect.Text = "Cancel" Then
            _waitingForDevice = False
            _targetPort = ""
            lblStatus.Text = "Ready"
            lblStatus.ForeColor = Color.Black
            pnlLed.BackColor = Color.Gray
            btnConnect.Text = "Connect"
            Return
        End If

        If _micro.IsConnected Then
            _waitingForDevice = False
            _targetPort = ""
            _micro.Disconnect()
            Return
        End If

        If cmbPorts.SelectedItem Is Nothing OrElse cmbPorts.Text = "No Ports Found" Then Return
        _waitingForDevice = False
        PerformConnection(cmbPorts.SelectedItem.ToString())
    End Sub
    Private Async Function RefreshFileList() As Task
        If Not _micro.IsConnected Then Return
        If _isSyncing Then Return

        _isSyncing = True
        lblStatus.Text = "Syncing..."

        Try
            ' 1. Wait for Flash memory to settle
            Await Task.Delay(500)

            Dim path As String = txtDevicePath.Text
            If String.IsNullOrEmpty(path) Then path = "/"

            ' 2. Fetch Data
            Dim files = Await _fs.ListFilesAsync(path)

            ' 3. Update UI
            lvDevice.BeginUpdate()
            lvDevice.Items.Clear()

            For Each f In files
                Dim item As New ListViewItem(f.Name)

                If f.IsFolder Then
                    ' FOLDERS (Keep existing style)
                    item.SubItems.Add("")
                    item.ImageIndex = 0
                    item.Tag = "DIR"
                    item.ForeColor = Color.DarkBlue
                    item.Font = New Font(lvDevice.Font, FontStyle.Bold)
                Else
                    ' FILES
                    item.SubItems.Add(FormatSize(f.Size))
                    item.Tag = "FILE"

                    ' Apply Magic Styling
                    ApplyFileStyle(item, f.Name)
                End If

                lvDevice.Items.Add(item)
            Next

            lvDevice.EndUpdate()
            lblStatus.Text = "Connected"
            lblStatus.ForeColor = Color.Green

        Catch ex As Exception
            lvDevice.EndUpdate()
            rtbTerminal.AppendText("[Sync Error] " & ex.Message & vbCrLf)
            lblStatus.Text = "Sync Failed"
            lblStatus.ForeColor = Color.Red
        Finally
            _isSyncing = False
            If _micro.IsConnected Then UpdateConnectionStateUI(True)
        End Try
    End Function


    Private Async Function LoadDeviceFiles(path As String) As Task
        txtDevicePath.Text = path
        Await RefreshFileList()
    End Function

    Private Sub OnDataReceived(text As String) Handles _micro.DataReceived
        If Me.IsDisposed Then Return
        ' Clean output
        Dim cleanText = text.Replace("<<<BEGIN>>>", "").Replace("<<<END>>>", "").Replace("OK", "").Replace(Chr(4), "")
        If String.IsNullOrWhiteSpace(cleanText) Then Return
        Try
            Me.BeginInvoke(Sub()
                               rtbTerminal.AppendText(cleanText)
                               rtbTerminal.ScrollToCaret()
                           End Sub)
        Catch
        End Try
    End Sub

    Private Sub OnConnectionStatus(isConnected As Boolean, message As String) Handles _micro.ConnectionStatusChanged
        If Me.IsDisposed Then Return
        Try
            Me.BeginInvoke(Sub()
                               lblStatus.Text = message
                               If isConnected Then
                                   lblStatus.ForeColor = Color.Green
                                   pnlLed.BackColor = Color.LimeGreen
                                   btnConnect.Text = "Disconnect"
                                   ' Force enabled here too, just in case
                                   btnConnect.Enabled = True

                                   UpdateConnectionStateUI(True)
                               Else
                                   UpdateConnectionStateUI(False)
                                   If _waitingForDevice Then
                                       lblStatus.Text = "Waiting..."
                                       lblStatus.ForeColor = Color.Orange
                                       pnlLed.BackColor = Color.Orange
                                       btnConnect.Text = "Cancel"
                                   ElseIf message.Contains("Error") Then
                                       lblStatus.ForeColor = Color.Red
                                       pnlLed.BackColor = Color.Red
                                       btnConnect.Text = "Connect"
                                   Else
                                       lblStatus.ForeColor = Color.Black
                                       pnlLed.BackColor = Color.Gray
                                       btnConnect.Text = "Connect"
                                   End If
                               End If
                           End Sub)
        Catch
        End Try
    End Sub
    Private Sub UpdateConnectionStateUI(connected As Boolean)
        ' Left Panel always active
        splitMain.Enabled = True

        ' Right Panel & Actions
        lvDevice.Enabled = connected
        txtDevicePath.Enabled = connected
        btnDeviceUp.Enabled = connected

        ' Connection Buttons
        cmbPorts.Enabled = Not connected
        btnRefresh.Enabled = Not connected

        ' Core Features
        If btnSoftReset IsNot Nothing Then btnSoftReset.Enabled = connected
        If btnRunMain IsNot Nothing Then btnRunMain.Enabled = connected
        If btnMkDir IsNot Nothing Then btnMkDir.Enabled = connected
        If btnDelete IsNot Nothing Then btnDelete.Enabled = connected
        If btnUpload IsNot Nothing Then btnUpload.Enabled = connected
        If btnDownload IsNot Nothing Then btnDownload.Enabled = connected
        If btnFilesRefresh IsNot Nothing Then btnFilesRefresh.Enabled = connected

        ' --- NEW BUTTONS ---
        If btnDiskSpace IsNot Nothing Then btnDiskSpace.Enabled = connected
        If btnTimeSync IsNot Nothing Then btnTimeSync.Enabled = connected
        If btnWiFi IsNot Nothing Then btnWiFi.Enabled = connected
        If btnRam IsNot Nothing Then btnRam.Enabled = connected
        If btnQuickView IsNot Nothing Then btnQuickView.Enabled = connected
    End Sub

    ' --- LOCAL FILE NAV ---
    Private Sub LoadLocalFiles(path As String)
        Try
            ' 1. Validate Path
            If Not IO.Directory.Exists(path) Then Return

            ' 2. Prepare UI
            lvLocal.BeginUpdate()
            lvLocal.Items.Clear()

            ' 3. Persist Path
            txtLocalPath.Text = path
            My.Settings.LastLocalPath = path
            My.Settings.Save()

            Dim dirInfo As New IO.DirectoryInfo(path)

            ' 4. FOLDERS (Index 0, Dark Blue, Bold)
            For Each d In dirInfo.GetDirectories()
                Dim item As New ListViewItem(d.Name)
                item.SubItems.Add("")
                item.SubItems.Add("Folder")

                ' Image Index 0 based on your screenshot
                item.ImageIndex = 0
                item.Tag = "DIR"

                ' Visual Style
                item.ForeColor = Color.DarkBlue
                item.Font = New Font(lvLocal.Font, FontStyle.Bold)

                lvLocal.Items.Add(item)
            Next

            ' 5. FILES
            For Each f In dirInfo.GetFiles()
                Dim item As New ListViewItem(f.Name)
                item.SubItems.Add((f.Length / 1024).ToString("F1") & " KB")
                item.SubItems.Add(f.Extension)

                item.Tag = "FILE"

                ' Apply Magic Styling
                ApplyFileStyle(item, f.Name)

                lvLocal.Items.Add(item)
            Next

            lvLocal.EndUpdate()

        Catch ex As Exception
            lvLocal.EndUpdate()
            MessageBox.Show("Local File Error: " & ex.Message)
        End Try
    End Sub
    Private Sub btnLocalUp_Click(sender As Object, e As EventArgs) Handles btnLocalUp.Click
        Try
            Dim p = IO.Directory.GetParent(txtLocalPath.Text)
            If p IsNot Nothing Then LoadLocalFiles(p.FullName)
        Catch
        End Try
    End Sub

    Private Sub txtLocalPath_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLocalPath.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadLocalFiles(txtLocalPath.Text)
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using fbd As New FolderBrowserDialog()
            fbd.SelectedPath = txtLocalPath.Text
            If fbd.ShowDialog() = DialogResult.OK Then LoadLocalFiles(fbd.SelectedPath)
        End Using
    End Sub

    Private Sub btnDeviceUp_Click(sender As Object, e As EventArgs) Handles btnDeviceUp.Click
        Dim current = txtDevicePath.Text
        If current = "/" OrElse String.IsNullOrEmpty(current) Then Return
        Dim lastSlash = current.LastIndexOf("/")
        If lastSlash <= 0 Then
            LoadDeviceFiles("/")
        Else
            LoadDeviceFiles(current.Substring(0, lastSlash))
        End If
    End Sub

    ' --- MKDIR & RESET ---
    Private Async Sub btnMkDir_Click(sender As Object, e As EventArgs) Handles btnMkDir.Click
        If Not _micro.IsConnected Then Return
        Dim newName = InputBox("Folder Name:", "New Folder", "NewFolder")
        If String.IsNullOrWhiteSpace(newName) Then Return

        Dim currentDir = txtDevicePath.Text
        Dim newPath = If(currentDir.EndsWith("/"), currentDir & newName, currentDir & "/" & newName)

        Dim cmd = String.Format("import os; os.mkdir('{0}')", newPath)
        Await _micro.ExecuteCommandAsync(cmd)
        Await RefreshFileList()
    End Sub

    Private Async Sub btnSoftReset_Click(sender As Object, e As EventArgs) Handles btnSoftReset.Click
        If Not _micro.IsConnected Then Return
        tmrWatchdog.Stop()
        rtbTerminal.AppendText(vbCrLf & ">>> Rebooting..." & vbCrLf)
        Await _micro.SendRawBytesAsync(System.Text.Encoding.UTF8.GetBytes("import machine; machine.soft_reset()" & vbCr))
        _micro.Disconnect()
        Await Task.Delay(2500)
        Dim port = cmbPorts.Text
        If Not String.IsNullOrEmpty(port) Then PerformConnection(port) Else tmrWatchdog.Start()
    End Sub

    Private Async Sub btnRunMain_Click(sender As Object, e As EventArgs) Handles btnRunMain.Click
        If Not _micro.IsConnected Then Return
        rtbTerminal.AppendText(vbCrLf & ">>> Running main.py..." & vbCrLf)
        Await _micro.SendRawBytesAsync(System.Text.Encoding.UTF8.GetBytes("exec(open('main.py').read())"))
        Await _micro.SendRawBytesAsync({4})
    End Sub

    ' Manual Refresh Button
    Private Async Sub btnFilesRefresh_Click(sender As Object, e As EventArgs) Handles btnFilesRefresh.Click
        Await RefreshFileList()
    End Sub

    ' --- HELPERS ---
    Private Sub SetTransferState(busy As Boolean)
        pbTransfer.Visible = busy
        pbTransfer.Value = 0
        btnUpload.Enabled = Not busy
        btnDelete.Enabled = Not busy
        splitMain.Enabled = Not busy
        If btnFilesRefresh IsNot Nothing Then btnFilesRefresh.Enabled = Not busy
    End Sub

    Private Function FormatSize(bytes As Long) As String
        If bytes >= 1024 * 1024 Then Return (bytes / 1024 / 1024).ToString("F2") & " MB"
        If bytes >= 1024 Then Return (bytes / 1024).ToString("F1") & " KB"
        Return bytes.ToString() & " B"
    End Function

    Private Sub UpdateUI_Safe(currentPorts As ReadOnlyCollection(Of String))
        Dim sysList As New List(Of String)(currentPorts)
        Dim hasChanged As Boolean = False
        If cmbPorts.Items.Count <> sysList.Count Then hasChanged = True
        If Not hasChanged Then
            For Each p In sysList
                If Not cmbPorts.Items.Contains(p) Then hasChanged = True
            Next
        End If
        If hasChanged Then
            Dim oldSel = cmbPorts.Text
            cmbPorts.BeginUpdate()
            cmbPorts.Items.Clear()
            For Each p In sysList : cmbPorts.Items.Add(p) : Next
            If sysList.Contains(oldSel) Then cmbPorts.SelectedItem = oldSel Else If cmbPorts.Items.Count > 0 Then cmbPorts.SelectedIndex = 0
            cmbPorts.EndUpdate()
        End If
    End Sub

    Private Sub tmrWatchdog_Tick(sender As Object, e As EventArgs) Handles tmrWatchdog.Tick
        UpdateUI_Safe(My.Computer.Ports.SerialPortNames)
    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick_1(sender As Object, e As EventArgs)
        MsgBox("Nikos Georgousis 2026")
    End Sub



    ' 1. DISK SPACE
    Private Sub btnDiskSpace_Click(sender As Object, e As EventArgs) Handles btnDiskSpace.Click
        Dim py As String = "import os; fs=os.statvfs('/'); print('Free: {:,} KB'.format((fs[0]*fs[3])/1024))"
        ExecuteExternalCommand(py)
    End Sub

    ' 2. RAM INFO (The one that caused the reboot)
    Private Sub btnRam_Click(sender As Object, e As EventArgs) Handles btnRam.Click
        Dim py As String = "import gc; gc.collect(); print('Free RAM: {:,} bytes'.format(gc.mem_free()))"
        ExecuteExternalCommand(py)
    End Sub

    ' 3. WI-FI STATUS
    Private Sub btnWiFi_Click(sender As Object, e As EventArgs) Handles btnWiFi.Click
        Dim py As String = "import network; print(network.WLAN(network.STA_IF).ifconfig())"
        ExecuteExternalCommand(py)
    End Sub

    ' 4. TIME SYNC (Keep using ExecuteCommandAsync for this one if it returns complex data, 
    ' but for simple setting, External is fine too. Let's keep your original strictly if it works, 
    ' or switch to this safe version:)
    Private Sub btnTimeSync_Click(sender As Object, e As EventArgs) Handles btnTimeSync.Click
        Dim n = DateTime.Now
        Dim cmd = String.Format("import machine; machine.RTC().datetime(({0}, {1}, {2}, {3}, {4}, {5}, {6}, 0))",
                                          n.Year, n.Month, n.Day, 0, n.Hour, n.Minute, n.Second)
        ExecuteExternalCommand(cmd)
        ExecuteExternalCommand("print('Time Set:', machine.RTC().datetime())")
    End Sub



    ' 5. QUICK VIEW (Cat)
    ' Currently prints to Terminal. Ready to be redirected to a new form later.
    Private Async Sub btnQuickView_Click(sender As Object, e As EventArgs) Handles btnQuickView.Click
        If Not _micro.IsConnected Then Return

        ' 1. Validation
        If lvDevice.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a file to view.")
            Return
        End If

        Dim item = lvDevice.SelectedItems(0)
        If item.Tag.ToString() = "DIR" Then
            MessageBox.Show("Cannot view a folder.")
            Return
        End If

        Dim filename As String = item.Text
        Dim currentDir As String = txtDevicePath.Text
        Dim remotePath As String = If(currentDir.EndsWith("/"), currentDir & filename, currentDir & "/" & filename)

        ' 2. UI Feedback
        rtbTerminal.AppendText(vbCrLf & ">>> Fetching content of " & filename & "..." & vbCrLf)

        ' 3. Fetch Content
        Dim content As String = Await _fs.ReadFileContentAsync(remotePath)

        If content.StartsWith("Error reading file:") Then
            MessageBox.Show(content, "Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 4. Open Viewer
        Dim viewer As New frmCodeViewer()
        viewer.LoadCode(filename, content)
        viewer.Show() ' Use .Show() for non-blocking, or .ShowDialog() for blocking
    End Sub

    Private Sub SetupTerminal()
        ' 1. The Font (Monospaced is essential for code alignment)
        rtbTerminal.Font = New Font("Consolas", 10, FontStyle.Regular)

        ' 2. The Hacker/Terminal Look
        rtbTerminal.BackColor = Color.FromArgb(30, 30, 30) ' Dark Gray/Black
        rtbTerminal.ForeColor = Color.LightGreen           ' Retro Terminal Green

        ' 3. UX Settings
        rtbTerminal.ReadOnly = True       ' User shouldn't type directly into the log
        rtbTerminal.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbTerminal.DetectUrls = False    ' Disable blue links to keep the style clean
    End Sub

    ''' <summary>
    ''' Allows external forms (like Command Center) to execute Python.
    ''' </summary>
    Public Async Sub ExecuteExternalCommand(cmd As String)
        If Not _micro.IsConnected Then
            MessageBox.Show("Device not connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Log outgoing command (Cyan)
        LogTerminal(vbCrLf & ">>> " & cmd & vbCrLf, Color.Cyan)

        ' --- THE FIX IS HERE ---
        ' 1. Send Ctrl+B (ASCII 2) to force "Friendly REPL" mode. 
        '    This kicks it out of "Raw Mode" if it was stuck there.
        Await _micro.SendRawBytesAsync({2})

        ' 2. Wait a split second for the mode switch
        Await Task.Delay(50)

        ' 3. Send the Command + Carriage Return
        Dim data = System.Text.Encoding.UTF8.GetBytes(cmd & vbCr)
        Await _micro.SendRawBytesAsync(data)
    End Sub

    Private _frmCmd As frmCommands

    Private Sub btnCmdCenter_Click(sender As Object, e As EventArgs) Handles btnCmdCenter.Click
        If _frmCmd Is Nothing OrElse _frmCmd.IsDisposed Then
            _frmCmd = New frmCommands(Me)
        End If
        _frmCmd.Show()
        _frmCmd.BringToFront()
    End Sub

    ''' <summary>
    ''' Helper to write colored text to the terminal safely from any thread.
    ''' </summary>
    Private Sub LogTerminal(text As String, color As Color)
        If Me.IsDisposed OrElse rtbTerminal.IsDisposed Then Return

        ' Ensure we are on the UI thread
        If rtbTerminal.InvokeRequired Then
            Me.BeginInvoke(Sub() LogTerminal(text, color))
        Else
            rtbTerminal.SelectionStart = rtbTerminal.TextLength
            rtbTerminal.SelectionLength = 0

            rtbTerminal.SelectionColor = color
            rtbTerminal.AppendText(text)
            rtbTerminal.ScrollToCaret()
        End If
    End Sub


    ''' <summary>
    ''' Applies colors and icons based on file extension.
    ''' </summary>
    Private Sub ApplyFileStyle(item As ListViewItem, fileName As String)
        Dim ext As String = IO.Path.GetExtension(fileName).ToLower()

        ' Default Style (Index 1 = Generic File)
        item.ImageIndex = 1
        item.ForeColor = Color.Black

        Select Case ext
            Case ".py", ".pyw"
                item.ImageIndex = 2       ' Python Icon
                item.ForeColor = Color.Green ' 

            Case ".html", ".htm", ".js", ".css", ".json", ".xml"
                item.ImageIndex = 3       ' Web Icon
                item.ForeColor = Color.Teal      ' 

            Case ".png", ".jpg", ".jpeg", ".bmp", ".gif", ".ico"
                item.ImageIndex = 4       ' Image Icon
                item.ForeColor = Color.Purple    ' 

            Case ".txt", ".ini", ".conf", ".bat", ".ps1", ".log"
                item.ImageIndex = 5       ' System Icon
                item.ForeColor = Color.OrangeRed   ' 
        End Select
    End Sub

    Private Sub btnFlash_Click(sender As Object, e As EventArgs) Handles btnFlash.Click

        ' Safety: If we are currently connected, we MUST disconnect first
        ' so esptool can grab the COM port.
        If _micro.IsConnected Then
            If MessageBox.Show("We must disconnect from the device to open the Flasher. Proceed?",
                               "Disconnect Required", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                btnConnect.PerformClick() ' Trigger disconnect logic
            Else
                Return
            End If
        End If

        Dim frm As New frmFlash()
        ' Pass the currently selected COM port to save the user time
        frm.TargetPort = cmbPorts.Text
        frm.ShowDialog()
    End Sub

    ''' <summary>
    ''' Called automatically when an external app (Notepad++) sends a file.
    ''' </summary>
    Public Async Sub HandleExternalUpload(localPath As String)
        ' 1. Safety Checks
        If Not _micro.IsConnected Then
            LogTerminal(">>> External Upload Ignored: Device not connected." & vbCrLf, Color.Orange)
            Return
        End If

        If Not IO.File.Exists(localPath) Then
            LogTerminal(">>> External Upload Error: File not found." & vbCrLf, Color.Red)
            Return
        End If

        ' 2. Determine Paths
        Dim filename = IO.Path.GetFileName(localPath)
        Dim remoteDir = txtDevicePath.Text
        Dim remotePath = If(remoteDir.EndsWith("/"), remoteDir & filename, remoteDir & "/" & filename)

        ' 3. Visual Feedback
        LogTerminal(vbCrLf & ">>> External Upload Triggered: " & filename & "..." & vbCrLf, Color.Cyan)

        ' 4. Upload (Reuse your existing logic)
        SetTransferState(True)
        Dim progress As New Progress(Of Integer)(Sub(pct) pbTransfer.Value = pct)

        Dim success As Boolean = Await _fs.UploadFileAsync(localPath, remotePath, progress)

        SetTransferState(False)

        If success Then
            LogTerminal(">>> Upload Complete." & vbCrLf, Color.Lime)
            ' Optional: Refresh list to show the new file size/date
            Await RefreshFileList()
        End If
    End Sub

    Private Sub lnkInfo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkInfo.LinkClicked
        frmInfo.Show()

    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        MsgBox("Created by Nikos Georgousis. 2026")
    End Sub
End Class
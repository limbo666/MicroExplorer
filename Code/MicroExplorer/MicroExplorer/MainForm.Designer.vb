<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.cmbPorts = New System.Windows.Forms.ComboBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.splitTop = New System.Windows.Forms.SplitContainer()
        Me.grConnection = New System.Windows.Forms.GroupBox()
        Me.LlblComPort = New System.Windows.Forms.Label()
        Me.pnlLed = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.grOperations = New System.Windows.Forms.GroupBox()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.btnMkDir = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnFilesRefresh = New System.Windows.Forms.Button()
        Me.btnSoftReset = New System.Windows.Forms.Button()
        Me.btnRunMain = New System.Windows.Forms.Button()
        Me.splitMain = New System.Windows.Forms.SplitContainer()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lvLocal = New System.Windows.Forms.ListView()
        Me.colLocalName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLocalSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colLocalType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnLocalUp = New System.Windows.Forms.Button()
        Me.txtLocalPath = New System.Windows.Forms.TextBox()
        Me.lvDevice = New System.Windows.Forms.ListView()
        Me.colDeviceName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDeviceSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnDeviceUp = New System.Windows.Forms.Button()
        Me.txtDevicePath = New System.Windows.Forms.TextBox()
        Me.btnDiskSpace = New System.Windows.Forms.Button()
        Me.btnRam = New System.Windows.Forms.Button()
        Me.btnTimeSync = New System.Windows.Forms.Button()
        Me.btnWiFi = New System.Windows.Forms.Button()
        Me.btnQuickView = New System.Windows.Forms.Button()
        Me.btnCmdCenter = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnFlash = New System.Windows.Forms.Button()
        Me.splitBack = New System.Windows.Forms.SplitContainer()
        Me.rtbTerminal = New System.Windows.Forms.RichTextBox()
        Me.grCommands = New System.Windows.Forms.GroupBox()
        Me.lnkInfo = New System.Windows.Forms.LinkLabel()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.pbTransfer = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel1.SuspendLayout()
        CType(Me.splitTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitTop.Panel1.SuspendLayout()
        Me.splitTop.Panel2.SuspendLayout()
        Me.splitTop.SuspendLayout()
        Me.grConnection.SuspendLayout()
        Me.grOperations.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        CType(Me.splitBack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitBack.Panel1.SuspendLayout()
        Me.splitBack.Panel2.SuspendLayout()
        Me.splitBack.SuspendLayout()
        Me.grCommands.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbPorts
        '
        Me.cmbPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPorts.FormattingEnabled = True
        Me.cmbPorts.Location = New System.Drawing.Point(43, 18)
        Me.cmbPorts.Name = "cmbPorts"
        Me.cmbPorts.Size = New System.Drawing.Size(90, 21)
        Me.cmbPorts.TabIndex = 0
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(139, 12)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(124, 31)
        Me.btnConnect.TabIndex = 1
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.Controls.Add(Me.splitTop)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(957, 100)
        Me.Panel1.TabIndex = 2
        '
        'splitTop
        '
        Me.splitTop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitTop.Location = New System.Drawing.Point(3, 0)
        Me.splitTop.Name = "splitTop"
        '
        'splitTop.Panel1
        '
        Me.splitTop.Panel1.Controls.Add(Me.grConnection)
        '
        'splitTop.Panel2
        '
        Me.splitTop.Panel2.Controls.Add(Me.grOperations)
        Me.splitTop.Size = New System.Drawing.Size(815, 100)
        Me.splitTop.SplitterDistance = 432
        Me.splitTop.TabIndex = 13
        '
        'grConnection
        '
        Me.grConnection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grConnection.Controls.Add(Me.LlblComPort)
        Me.grConnection.Controls.Add(Me.btnConnect)
        Me.grConnection.Controls.Add(Me.cmbPorts)
        Me.grConnection.Controls.Add(Me.pnlLed)
        Me.grConnection.Controls.Add(Me.btnRefresh)
        Me.grConnection.Controls.Add(Me.lblStatus)
        Me.grConnection.Location = New System.Drawing.Point(3, 3)
        Me.grConnection.Name = "grConnection"
        Me.grConnection.Size = New System.Drawing.Size(426, 92)
        Me.grConnection.TabIndex = 11
        Me.grConnection.TabStop = False
        Me.grConnection.Text = "Connection"
        '
        'LlblComPort
        '
        Me.LlblComPort.AutoSize = True
        Me.LlblComPort.Location = New System.Drawing.Point(11, 22)
        Me.LlblComPort.Name = "LlblComPort"
        Me.LlblComPort.Size = New System.Drawing.Size(26, 13)
        Me.LlblComPort.TabIndex = 10
        Me.LlblComPort.Text = "Port"
        '
        'pnlLed
        '
        Me.pnlLed.Location = New System.Drawing.Point(271, 19)
        Me.pnlLed.Name = "pnlLed"
        Me.pnlLed.Size = New System.Drawing.Size(15, 16)
        Me.pnlLed.TabIndex = 4
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(43, 41)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 31)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Refresh list"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(139, 50)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(16, 13)
        Me.lblStatus.TabIndex = 3
        Me.lblStatus.Text = "..."
        '
        'grOperations
        '
        Me.grOperations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grOperations.Controls.Add(Me.btnDownload)
        Me.grOperations.Controls.Add(Me.btnDelete)
        Me.grOperations.Controls.Add(Me.btnUpload)
        Me.grOperations.Controls.Add(Me.btnMkDir)
        Me.grOperations.Location = New System.Drawing.Point(5, 3)
        Me.grOperations.Name = "grOperations"
        Me.grOperations.Size = New System.Drawing.Size(371, 92)
        Me.grOperations.TabIndex = 12
        Me.grOperations.TabStop = False
        Me.grOperations.Text = "Operations"
        '
        'btnDownload
        '
        Me.btnDownload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDownload.Location = New System.Drawing.Point(23, 49)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(124, 35)
        Me.btnDownload.TabIndex = 5
        Me.btnDownload.Text = "Download"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(225, 49)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(124, 35)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "Delete File/Folder"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpload.Location = New System.Drawing.Point(23, 12)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(124, 35)
        Me.btnUpload.TabIndex = 9
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'btnMkDir
        '
        Me.btnMkDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMkDir.Location = New System.Drawing.Point(225, 12)
        Me.btnMkDir.Name = "btnMkDir"
        Me.btnMkDir.Size = New System.Drawing.Size(124, 35)
        Me.btnMkDir.TabIndex = 7
        Me.btnMkDir.Text = "Create Folder"
        Me.btnMkDir.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.MicroExplorer.My.Resources.Resources.Program_Icon
        Me.PictureBox1.Location = New System.Drawing.Point(840, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(83, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'btnFilesRefresh
        '
        Me.btnFilesRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilesRefresh.Location = New System.Drawing.Point(302, 9)
        Me.btnFilesRefresh.Name = "btnFilesRefresh"
        Me.btnFilesRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnFilesRefresh.TabIndex = 5
        Me.btnFilesRefresh.Text = "Refresh Files"
        Me.btnFilesRefresh.UseVisualStyleBackColor = True
        '
        'btnSoftReset
        '
        Me.btnSoftReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSoftReset.Location = New System.Drawing.Point(5, 28)
        Me.btnSoftReset.Name = "btnSoftReset"
        Me.btnSoftReset.Size = New System.Drawing.Size(114, 31)
        Me.btnSoftReset.TabIndex = 5
        Me.btnSoftReset.Text = "Reset"
        Me.btnSoftReset.UseVisualStyleBackColor = True
        '
        'btnRunMain
        '
        Me.btnRunMain.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRunMain.Location = New System.Drawing.Point(5, 65)
        Me.btnRunMain.Name = "btnRunMain"
        Me.btnRunMain.Size = New System.Drawing.Size(114, 31)
        Me.btnRunMain.TabIndex = 6
        Me.btnRunMain.Text = "Run main.py"
        Me.btnRunMain.UseVisualStyleBackColor = True
        '
        'splitMain
        '
        Me.splitMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitMain.Location = New System.Drawing.Point(3, 3)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.Controls.Add(Me.btnBrowse)
        Me.splitMain.Panel1.Controls.Add(Me.lvLocal)
        Me.splitMain.Panel1.Controls.Add(Me.btnLocalUp)
        Me.splitMain.Panel1.Controls.Add(Me.txtLocalPath)
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.Controls.Add(Me.btnFilesRefresh)
        Me.splitMain.Panel2.Controls.Add(Me.lvDevice)
        Me.splitMain.Panel2.Controls.Add(Me.btnDeviceUp)
        Me.splitMain.Panel2.Controls.Add(Me.txtDevicePath)
        Me.splitMain.Size = New System.Drawing.Size(831, 656)
        Me.splitMain.SplitterDistance = 428
        Me.splitMain.TabIndex = 10
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(350, 10)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.Text = "Select Folder "
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lvLocal
        '
        Me.lvLocal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvLocal.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLocalName, Me.colLocalSize, Me.colLocalType})
        Me.lvLocal.FullRowSelect = True
        Me.lvLocal.HideSelection = False
        Me.lvLocal.Location = New System.Drawing.Point(0, 37)
        Me.lvLocal.Name = "lvLocal"
        Me.lvLocal.Size = New System.Drawing.Size(425, 311)
        Me.lvLocal.SmallImageList = Me.ImageList1
        Me.lvLocal.TabIndex = 2
        Me.lvLocal.UseCompatibleStateImageBehavior = False
        Me.lvLocal.View = System.Windows.Forms.View.Details
        '
        'colLocalName
        '
        Me.colLocalName.Text = "Name"
        Me.colLocalName.Width = 198
        '
        'colLocalSize
        '
        Me.colLocalSize.Text = "Size"
        Me.colLocalSize.Width = 61
        '
        'colLocalType
        '
        Me.colLocalType.Text = "Type"
        Me.colLocalType.Width = 275
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "blue-open-folder-11560.png")
        Me.ImageList1.Images.SetKeyName(1, "green-word-document-doc-24085.png")
        Me.ImageList1.Images.SetKeyName(2, "python.png")
        Me.ImageList1.Images.SetKeyName(3, "web.png")
        Me.ImageList1.Images.SetKeyName(4, "Image.png")
        Me.ImageList1.Images.SetKeyName(5, "txt.png")
        '
        'btnLocalUp
        '
        Me.btnLocalUp.Location = New System.Drawing.Point(2, 9)
        Me.btnLocalUp.Name = "btnLocalUp"
        Me.btnLocalUp.Size = New System.Drawing.Size(75, 23)
        Me.btnLocalUp.TabIndex = 1
        Me.btnLocalUp.Text = "Up"
        Me.btnLocalUp.UseVisualStyleBackColor = True
        '
        'txtLocalPath
        '
        Me.txtLocalPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocalPath.Location = New System.Drawing.Point(83, 12)
        Me.txtLocalPath.Name = "txtLocalPath"
        Me.txtLocalPath.Size = New System.Drawing.Size(261, 20)
        Me.txtLocalPath.TabIndex = 0
        '
        'lvDevice
        '
        Me.lvDevice.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDevice.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colDeviceName, Me.colDeviceSize})
        Me.lvDevice.FullRowSelect = True
        Me.lvDevice.HideSelection = False
        Me.lvDevice.Location = New System.Drawing.Point(3, 37)
        Me.lvDevice.Name = "lvDevice"
        Me.lvDevice.Size = New System.Drawing.Size(375, 311)
        Me.lvDevice.SmallImageList = Me.ImageList1
        Me.lvDevice.TabIndex = 3
        Me.lvDevice.UseCompatibleStateImageBehavior = False
        Me.lvDevice.View = System.Windows.Forms.View.Details
        '
        'colDeviceName
        '
        Me.colDeviceName.Text = "Name"
        Me.colDeviceName.Width = 206
        '
        'colDeviceSize
        '
        Me.colDeviceSize.Text = "Size"
        Me.colDeviceSize.Width = 120
        '
        'btnDeviceUp
        '
        Me.btnDeviceUp.Location = New System.Drawing.Point(3, 9)
        Me.btnDeviceUp.Name = "btnDeviceUp"
        Me.btnDeviceUp.Size = New System.Drawing.Size(75, 23)
        Me.btnDeviceUp.TabIndex = 3
        Me.btnDeviceUp.Text = "Up"
        Me.btnDeviceUp.UseVisualStyleBackColor = True
        '
        'txtDevicePath
        '
        Me.txtDevicePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDevicePath.Location = New System.Drawing.Point(84, 11)
        Me.txtDevicePath.Name = "txtDevicePath"
        Me.txtDevicePath.Size = New System.Drawing.Size(211, 20)
        Me.txtDevicePath.TabIndex = 3
        '
        'btnDiskSpace
        '
        Me.btnDiskSpace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDiskSpace.Location = New System.Drawing.Point(5, 102)
        Me.btnDiskSpace.Name = "btnDiskSpace"
        Me.btnDiskSpace.Size = New System.Drawing.Size(114, 31)
        Me.btnDiskSpace.TabIndex = 13
        Me.btnDiskSpace.Text = "Disk Space"
        Me.btnDiskSpace.UseVisualStyleBackColor = True
        '
        'btnRam
        '
        Me.btnRam.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRam.Location = New System.Drawing.Point(5, 213)
        Me.btnRam.Name = "btnRam"
        Me.btnRam.Size = New System.Drawing.Size(114, 31)
        Me.btnRam.TabIndex = 16
        Me.btnRam.Text = "RAM Info"
        Me.btnRam.UseVisualStyleBackColor = True
        '
        'btnTimeSync
        '
        Me.btnTimeSync.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTimeSync.Location = New System.Drawing.Point(5, 139)
        Me.btnTimeSync.Name = "btnTimeSync"
        Me.btnTimeSync.Size = New System.Drawing.Size(114, 31)
        Me.btnTimeSync.TabIndex = 14
        Me.btnTimeSync.Text = "Time Sync"
        Me.btnTimeSync.UseVisualStyleBackColor = True
        '
        'btnWiFi
        '
        Me.btnWiFi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWiFi.Location = New System.Drawing.Point(5, 176)
        Me.btnWiFi.Name = "btnWiFi"
        Me.btnWiFi.Size = New System.Drawing.Size(114, 31)
        Me.btnWiFi.TabIndex = 15
        Me.btnWiFi.Text = "WiFi IP"
        Me.btnWiFi.UseVisualStyleBackColor = True
        '
        'btnQuickView
        '
        Me.btnQuickView.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuickView.Location = New System.Drawing.Point(5, 250)
        Me.btnQuickView.Name = "btnQuickView"
        Me.btnQuickView.Size = New System.Drawing.Size(114, 31)
        Me.btnQuickView.TabIndex = 17
        Me.btnQuickView.Text = "Quick File View..."
        Me.btnQuickView.UseVisualStyleBackColor = True
        '
        'btnCmdCenter
        '
        Me.btnCmdCenter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCmdCenter.Location = New System.Drawing.Point(823, 461)
        Me.btnCmdCenter.Name = "btnCmdCenter"
        Me.btnCmdCenter.Size = New System.Drawing.Size(123, 50)
        Me.btnCmdCenter.TabIndex = 18
        Me.btnCmdCenter.Text = "Command Center..."
        Me.btnCmdCenter.UseVisualStyleBackColor = True
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "delete.png")
        Me.ImageList2.Images.SetKeyName(1, "download.png")
        Me.ImageList2.Images.SetKeyName(2, "upload.png")
        Me.ImageList2.Images.SetKeyName(3, "command.png")
        Me.ImageList2.Images.SetKeyName(4, "hdd.png")
        Me.ImageList2.Images.SetKeyName(5, "newfolder.png")
        Me.ImageList2.Images.SetKeyName(6, "ram.png")
        Me.ImageList2.Images.SetKeyName(7, "reset.png")
        Me.ImageList2.Images.SetKeyName(8, "run.png")
        Me.ImageList2.Images.SetKeyName(9, "serial.png")
        Me.ImageList2.Images.SetKeyName(10, "up.png")
        Me.ImageList2.Images.SetKeyName(11, "view.png")
        Me.ImageList2.Images.SetKeyName(12, "wifi.png")
        Me.ImageList2.Images.SetKeyName(13, "time.png")
        Me.ImageList2.Images.SetKeyName(14, "flash_firmware1.png")
        Me.ImageList2.Images.SetKeyName(15, "flash_firmware2.png")
        Me.ImageList2.Images.SetKeyName(16, "flash_firmware3.png")
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New System.Drawing.Point(847, 82)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(74, 13)
        Me.lblTitle.TabIndex = 19
        Me.lblTitle.Text = "Micro Explorer"
        '
        'btnFlash
        '
        Me.btnFlash.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFlash.BackColor = System.Drawing.Color.Transparent
        Me.btnFlash.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnFlash.FlatAppearance.BorderSize = 2
        Me.btnFlash.ForeColor = System.Drawing.Color.DarkRed
        Me.btnFlash.ImageList = Me.ImageList2
        Me.btnFlash.Location = New System.Drawing.Point(823, 562)
        Me.btnFlash.Name = "btnFlash"
        Me.btnFlash.Size = New System.Drawing.Size(124, 50)
        Me.btnFlash.TabIndex = 11
        Me.btnFlash.Text = "Firmware flasher..."
        Me.btnFlash.UseVisualStyleBackColor = False
        '
        'splitBack
        '
        Me.splitBack.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitBack.Location = New System.Drawing.Point(4, 103)
        Me.splitBack.Name = "splitBack"
        Me.splitBack.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitBack.Panel1
        '
        Me.splitBack.Panel1.Controls.Add(Me.splitMain)
        '
        'splitBack.Panel2
        '
        Me.splitBack.Panel2.Controls.Add(Me.rtbTerminal)
        Me.splitBack.Size = New System.Drawing.Size(816, 506)
        Me.splitBack.SplitterDistance = 354
        Me.splitBack.TabIndex = 20
        '
        'rtbTerminal
        '
        Me.rtbTerminal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbTerminal.Location = New System.Drawing.Point(0, 0)
        Me.rtbTerminal.Name = "rtbTerminal"
        Me.rtbTerminal.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.rtbTerminal.Size = New System.Drawing.Size(816, 148)
        Me.rtbTerminal.TabIndex = 12
        Me.rtbTerminal.Text = ""
        '
        'grCommands
        '
        Me.grCommands.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grCommands.Controls.Add(Me.btnQuickView)
        Me.grCommands.Controls.Add(Me.btnRam)
        Me.grCommands.Controls.Add(Me.btnTimeSync)
        Me.grCommands.Controls.Add(Me.btnWiFi)
        Me.grCommands.Controls.Add(Me.btnDiskSpace)
        Me.grCommands.Controls.Add(Me.btnSoftReset)
        Me.grCommands.Controls.Add(Me.btnRunMain)
        Me.grCommands.Location = New System.Drawing.Point(823, 139)
        Me.grCommands.Name = "grCommands"
        Me.grCommands.Size = New System.Drawing.Size(123, 293)
        Me.grCommands.TabIndex = 21
        Me.grCommands.TabStop = False
        Me.grCommands.Text = "Commands"
        '
        'lnkInfo
        '
        Me.lnkInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkInfo.AutoSize = True
        Me.lnkInfo.Location = New System.Drawing.Point(907, 619)
        Me.lnkInfo.Name = "lnkInfo"
        Me.lnkInfo.Size = New System.Drawing.Size(25, 13)
        Me.lnkInfo.TabIndex = 22
        Me.lnkInfo.TabStop = True
        Me.lnkInfo.Text = "Info"
        '
        'btnAbout
        '
        Me.btnAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbout.Location = New System.Drawing.Point(833, 614)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(68, 23)
        Me.btnAbout.TabIndex = 23
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'pbTransfer
        '
        Me.pbTransfer.Name = "pbTransfer"
        Me.pbTransfer.Size = New System.Drawing.Size(300, 16)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pbTransfer})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 615)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(957, 22)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 637)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.lnkInfo)
        Me.Controls.Add(Me.grCommands)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCmdCenter)
        Me.Controls.Add(Me.splitBack)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnFlash)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(810, 570)
        Me.Name = "MainForm"
        Me.Text = "MicroExplorer"
        Me.Panel1.ResumeLayout(False)
        Me.splitTop.Panel1.ResumeLayout(False)
        Me.splitTop.Panel2.ResumeLayout(False)
        CType(Me.splitTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitTop.ResumeLayout(False)
        Me.grConnection.ResumeLayout(False)
        Me.grConnection.PerformLayout()
        Me.grOperations.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel1.PerformLayout()
        Me.splitMain.Panel2.ResumeLayout(False)
        Me.splitMain.Panel2.PerformLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        Me.splitBack.Panel1.ResumeLayout(False)
        Me.splitBack.Panel2.ResumeLayout(False)
        CType(Me.splitBack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitBack.ResumeLayout(False)
        Me.grCommands.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbPorts As ComboBox
    Friend WithEvents btnConnect As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlLed As Panel
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnSoftReset As Button
    Friend WithEvents btnRunMain As Button
    Friend WithEvents btnMkDir As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpload As Button
    Friend WithEvents splitMain As SplitContainer
    Friend WithEvents lvLocal As ListView
    Friend WithEvents btnLocalUp As Button
    Friend WithEvents txtLocalPath As TextBox
    Friend WithEvents colLocalName As ColumnHeader
    Friend WithEvents colLocalSize As ColumnHeader
    Friend WithEvents colLocalType As ColumnHeader
    Friend WithEvents btnDeviceUp As Button
    Friend WithEvents txtDevicePath As TextBox
    Friend WithEvents lvDevice As ListView
    Friend WithEvents colDeviceName As ColumnHeader
    Friend WithEvents colDeviceSize As ColumnHeader
    Friend WithEvents btnFilesRefresh As Button
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnDownload As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnDiskSpace As Button
    Friend WithEvents btnRam As Button
    Friend WithEvents btnTimeSync As Button
    Friend WithEvents btnWiFi As Button
    Friend WithEvents btnQuickView As Button
    Friend WithEvents btnCmdCenter As Button
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents LlblComPort As Label
    Friend WithEvents btnFlash As Button
    Friend WithEvents splitBack As SplitContainer
    Friend WithEvents rtbTerminal As RichTextBox
    Friend WithEvents grOperations As GroupBox
    Friend WithEvents grConnection As GroupBox
    Friend WithEvents splitTop As SplitContainer
    Friend WithEvents grCommands As GroupBox
    Friend WithEvents lnkInfo As LinkLabel
    Friend WithEvents btnAbout As Button
    Friend WithEvents pbTransfer As ToolStripProgressBar
    Friend WithEvents StatusStrip1 As StatusStrip
End Class

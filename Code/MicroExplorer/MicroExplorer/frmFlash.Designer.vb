<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFlash))
        Me.lblToolStatus = New System.Windows.Forms.Label()
        Me.grpSettings = New System.Windows.Forms.GroupBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.lblOffset = New System.Windows.Forms.Label()
        Me.cmbChip = New System.Windows.Forms.ComboBox()
        Me.btnDetect = New System.Windows.Forms.Button()
        Me.cmbPort = New System.Windows.Forms.ComboBox()
        Me.lnkDownload = New System.Windows.Forms.LinkLabel()
        Me.grpFirmware = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.btnFlash = New System.Windows.Forms.Button()
        Me.chkErase = New System.Windows.Forms.CheckBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtBinPath = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblFlasher = New System.Windows.Forms.Label()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.lblInstrcutionsHeader = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.grpSettings.SuspendLayout()
        Me.grpFirmware.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblToolStatus
        '
        Me.lblToolStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblToolStatus.AutoSize = True
        Me.lblToolStatus.Location = New System.Drawing.Point(9, 277)
        Me.lblToolStatus.Name = "lblToolStatus"
        Me.lblToolStatus.Size = New System.Drawing.Size(61, 13)
        Me.lblToolStatus.TabIndex = 0
        Me.lblToolStatus.Text = "Checking..."
        '
        'grpSettings
        '
        Me.grpSettings.Controls.Add(Me.lblPort)
        Me.grpSettings.Controls.Add(Me.lblOffset)
        Me.grpSettings.Controls.Add(Me.cmbChip)
        Me.grpSettings.Controls.Add(Me.btnDetect)
        Me.grpSettings.Controls.Add(Me.cmbPort)
        Me.grpSettings.Location = New System.Drawing.Point(12, 12)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(279, 121)
        Me.grpSettings.TabIndex = 2
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "Connection && Chip"
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(6, 30)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(29, 13)
        Me.lblPort.TabIndex = 7
        Me.lblPort.Text = "Port:"
        '
        'lblOffset
        '
        Me.lblOffset.AutoSize = True
        Me.lblOffset.Location = New System.Drawing.Point(156, 90)
        Me.lblOffset.Name = "lblOffset"
        Me.lblOffset.Size = New System.Drawing.Size(73, 13)
        Me.lblOffset.TabIndex = 6
        Me.lblOffset.Text = "Memory offset"
        '
        'cmbChip
        '
        Me.cmbChip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChip.FormattingEnabled = True
        Me.cmbChip.Location = New System.Drawing.Point(159, 61)
        Me.cmbChip.Name = "cmbChip"
        Me.cmbChip.Size = New System.Drawing.Size(104, 21)
        Me.cmbChip.TabIndex = 5
        '
        'btnDetect
        '
        Me.btnDetect.Location = New System.Drawing.Point(39, 55)
        Me.btnDetect.Name = "btnDetect"
        Me.btnDetect.Size = New System.Drawing.Size(106, 33)
        Me.btnDetect.TabIndex = 4
        Me.btnDetect.Text = "Detect Chip"
        Me.btnDetect.UseVisualStyleBackColor = True
        '
        'cmbPort
        '
        Me.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPort.FormattingEnabled = True
        Me.cmbPort.Location = New System.Drawing.Point(41, 27)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(104, 21)
        Me.cmbPort.TabIndex = 0
        '
        'lnkDownload
        '
        Me.lnkDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lnkDownload.AutoSize = True
        Me.lnkDownload.Location = New System.Drawing.Point(9, 259)
        Me.lnkDownload.Name = "lnkDownload"
        Me.lnkDownload.Size = New System.Drawing.Size(92, 13)
        Me.lnkDownload.TabIndex = 3
        Me.lnkDownload.TabStop = True
        Me.lnkDownload.Text = "Download esptool"
        '
        'grpFirmware
        '
        Me.grpFirmware.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFirmware.Controls.Add(Me.Label1)
        Me.grpFirmware.Controls.Add(Me.rtbLog)
        Me.grpFirmware.Controls.Add(Me.btnFlash)
        Me.grpFirmware.Controls.Add(Me.chkErase)
        Me.grpFirmware.Controls.Add(Me.btnBrowse)
        Me.grpFirmware.Controls.Add(Me.txtBinPath)
        Me.grpFirmware.Location = New System.Drawing.Point(297, 12)
        Me.grpFirmware.Name = "grpFirmware"
        Me.grpFirmware.Size = New System.Drawing.Size(410, 260)
        Me.grpFirmware.TabIndex = 4
        Me.grpFirmware.TabStop = False
        Me.grpFirmware.Text = "Firmware File"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Firmware path:"
        '
        'rtbLog
        '
        Me.rtbLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbLog.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.rtbLog.Location = New System.Drawing.Point(6, 99)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.Size = New System.Drawing.Size(398, 157)
        Me.rtbLog.TabIndex = 4
        Me.rtbLog.Text = ""
        '
        'btnFlash
        '
        Me.btnFlash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFlash.Location = New System.Drawing.Point(289, 55)
        Me.btnFlash.Name = "btnFlash"
        Me.btnFlash.Size = New System.Drawing.Size(106, 33)
        Me.btnFlash.TabIndex = 3
        Me.btnFlash.Text = "Flash"
        Me.btnFlash.UseVisualStyleBackColor = True
        '
        'chkErase
        '
        Me.chkErase.AutoSize = True
        Me.chkErase.Checked = True
        Me.chkErase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkErase.Location = New System.Drawing.Point(6, 63)
        Me.chkErase.Name = "chkErase"
        Me.chkErase.Size = New System.Drawing.Size(103, 17)
        Me.chkErase.TabIndex = 2
        Me.chkErase.Text = "Erase Flash First"
        Me.chkErase.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(314, 25)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(81, 23)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtBinPath
        '
        Me.txtBinPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBinPath.Location = New System.Drawing.Point(82, 26)
        Me.txtBinPath.Name = "txtBinPath"
        Me.txtBinPath.Size = New System.Drawing.Size(226, 20)
        Me.txtBinPath.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MicroExplorer.My.Resources.Resources.flash_firmware31
        Me.PictureBox1.Location = New System.Drawing.Point(34, 131)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(46, 66)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'lblFlasher
        '
        Me.lblFlasher.AutoSize = True
        Me.lblFlasher.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblFlasher.Location = New System.Drawing.Point(18, 190)
        Me.lblFlasher.Name = "lblFlasher"
        Me.lblFlasher.Size = New System.Drawing.Size(83, 13)
        Me.lblFlasher.TabIndex = 12
        Me.lblFlasher.Text = "Firmware flasher"
        '
        'lblInstructions
        '
        Me.lblInstructions.Location = New System.Drawing.Point(102, 151)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(186, 60)
        Me.lblInstructions.TabIndex = 13
        Me.lblInstructions.Text = "1. Connect the device" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. Detect Chip" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3. Select firmware file (*.bin)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4. Flash"
        '
        'lblInstrcutionsHeader
        '
        Me.lblInstrcutionsHeader.AutoSize = True
        Me.lblInstrcutionsHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblInstrcutionsHeader.Location = New System.Drawing.Point(103, 136)
        Me.lblInstrcutionsHeader.Name = "lblInstrcutionsHeader"
        Me.lblInstrcutionsHeader.Size = New System.Drawing.Size(73, 13)
        Me.lblInstrcutionsHeader.TabIndex = 14
        Me.lblInstrcutionsHeader.Text = "Instructions"
        '
        'lblInfo
        '
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(8, 211)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(280, 48)
        Me.lblInfo.TabIndex = 15
        Me.lblInfo.Text = "This tool uses esptool.exe from Espessif." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This executable should be in the same " &
    "folder with MicroExplorer.exe"
        '
        'frmFlash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 301)
        Me.Controls.Add(Me.lblInstrcutionsHeader)
        Me.Controls.Add(Me.lblInstructions)
        Me.Controls.Add(Me.lblFlasher)
        Me.Controls.Add(Me.grpFirmware)
        Me.Controls.Add(Me.lnkDownload)
        Me.Controls.Add(Me.grpSettings)
        Me.Controls.Add(Me.lblToolStatus)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(730, 340)
        Me.Name = "frmFlash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Firmware Flasher"
        Me.grpSettings.ResumeLayout(False)
        Me.grpSettings.PerformLayout()
        Me.grpFirmware.ResumeLayout(False)
        Me.grpFirmware.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblToolStatus As Label
    Friend WithEvents grpSettings As GroupBox
    Friend WithEvents lblOffset As Label
    Friend WithEvents cmbChip As ComboBox
    Friend WithEvents btnDetect As Button
    Friend WithEvents cmbPort As ComboBox
    Friend WithEvents lnkDownload As LinkLabel
    Friend WithEvents grpFirmware As GroupBox
    Friend WithEvents rtbLog As RichTextBox
    Friend WithEvents btnFlash As Button
    Friend WithEvents chkErase As CheckBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtBinPath As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblFlasher As Label
    Friend WithEvents lblInstructions As Label
    Friend WithEvents lblInstrcutionsHeader As Label
    Friend WithEvents lblInfo As Label
    Friend WithEvents lblPort As Label
    Friend WithEvents Label1 As Label
End Class

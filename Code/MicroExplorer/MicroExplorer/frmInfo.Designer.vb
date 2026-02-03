<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCopied = New System.Windows.Forms.Label()
        Me.tmrHide = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(382, 133)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File manager"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(382, 97)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Firmware flasher"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(22, 254)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(382, 169)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Notepad++ Integration"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(366, 86)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(362, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Existing files will be overwritten"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(362, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Folder cannot be deleted if files contained"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(366, 76)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Flashes *.bin files to board." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This function relies on the presence of esptool." &
    "exe to the same folder with MicroExplorer." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The esptool.exe can be downloaded fo" &
    "r free from github repo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(10, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(366, 57)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "The program can be integrated with Notepad++ in order to easily upload the edited" &
    " file to the board using commands from Notepad++ " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The command used for notepa" &
    "d++ is:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label6.Location = New System.Drawing.Point(10, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(350, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = """ProgramPath\MicroExplorer.exe"" -upload ""$(FULL_CURRENT_PATH)"""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(230, 137)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(142, 26)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Copy adaptive command"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(11, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(362, 18)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "The line should be used on ""Run"" command of Notepad++"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(11, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(362, 18)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Use the button below to copy the valid command with active program path. "
        '
        'lblCopied
        '
        Me.lblCopied.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCopied.AutoSize = True
        Me.lblCopied.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblCopied.Location = New System.Drawing.Point(19, 426)
        Me.lblCopied.Name = "lblCopied"
        Me.lblCopied.Size = New System.Drawing.Size(89, 13)
        Me.lblCopied.TabIndex = 3
        Me.lblCopied.Text = "Command copied"
        Me.lblCopied.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCopied.Visible = False
        '
        'tmrHide
        '
        Me.tmrHide.Interval = 3000
        '
        'frmInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 442)
        Me.Controls.Add(Me.lblCopied)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInfo"
        Me.Text = "Info"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblCopied As Label
    Friend WithEvents tmrHide As Timer
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommands
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCommands))
        Me.cmbCommands = New System.Windows.Forms.ComboBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.btnQuick1 = New System.Windows.Forms.Button()
        Me.btnQuick2 = New System.Windows.Forms.Button()
        Me.btnQuick4 = New System.Windows.Forms.Button()
        Me.btnQuick3 = New System.Windows.Forms.Button()
        Me.btnQuick5 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbCommands
        '
        Me.cmbCommands.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCommands.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmbCommands.FormattingEnabled = True
        Me.cmbCommands.Location = New System.Drawing.Point(12, 12)
        Me.cmbCommands.Name = "cmbCommands"
        Me.cmbCommands.Size = New System.Drawing.Size(452, 23)
        Me.cmbCommands.TabIndex = 0
        '
        'btnRun
        '
        Me.btnRun.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRun.Location = New System.Drawing.Point(470, 4)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(75, 33)
        Me.btnRun.TabIndex = 1
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'btnQuick1
        '
        Me.btnQuick1.Location = New System.Drawing.Point(12, 45)
        Me.btnQuick1.Name = "btnQuick1"
        Me.btnQuick1.Size = New System.Drawing.Size(75, 33)
        Me.btnQuick1.TabIndex = 2
        Me.btnQuick1.Text = "Button1"
        Me.btnQuick1.UseVisualStyleBackColor = True
        '
        'btnQuick2
        '
        Me.btnQuick2.Location = New System.Drawing.Point(106, 45)
        Me.btnQuick2.Name = "btnQuick2"
        Me.btnQuick2.Size = New System.Drawing.Size(75, 33)
        Me.btnQuick2.TabIndex = 3
        Me.btnQuick2.Text = "Button1"
        Me.btnQuick2.UseVisualStyleBackColor = True
        '
        'btnQuick4
        '
        Me.btnQuick4.Location = New System.Drawing.Point(294, 45)
        Me.btnQuick4.Name = "btnQuick4"
        Me.btnQuick4.Size = New System.Drawing.Size(75, 33)
        Me.btnQuick4.TabIndex = 5
        Me.btnQuick4.Text = "Button1"
        Me.btnQuick4.UseVisualStyleBackColor = True
        '
        'btnQuick3
        '
        Me.btnQuick3.Location = New System.Drawing.Point(200, 45)
        Me.btnQuick3.Name = "btnQuick3"
        Me.btnQuick3.Size = New System.Drawing.Size(75, 33)
        Me.btnQuick3.TabIndex = 4
        Me.btnQuick3.Text = "Button1"
        Me.btnQuick3.UseVisualStyleBackColor = True
        '
        'btnQuick5
        '
        Me.btnQuick5.Location = New System.Drawing.Point(388, 45)
        Me.btnQuick5.Name = "btnQuick5"
        Me.btnQuick5.Size = New System.Drawing.Size(75, 33)
        Me.btnQuick5.TabIndex = 6
        Me.btnQuick5.Text = "Button1"
        Me.btnQuick5.UseVisualStyleBackColor = True
        '
        'frmCommands
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 84)
        Me.Controls.Add(Me.btnQuick5)
        Me.Controls.Add(Me.btnQuick4)
        Me.Controls.Add(Me.btnQuick3)
        Me.Controls.Add(Me.btnQuick2)
        Me.Controls.Add(Me.btnQuick1)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.cmbCommands)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCommands"
        Me.Text = "Command Center"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbCommands As ComboBox
    Friend WithEvents btnRun As Button
    Friend WithEvents btnQuick1 As Button
    Friend WithEvents btnQuick2 As Button
    Friend WithEvents btnQuick4 As Button
    Friend WithEvents btnQuick3 As Button
    Friend WithEvents btnQuick5 As Button
End Class

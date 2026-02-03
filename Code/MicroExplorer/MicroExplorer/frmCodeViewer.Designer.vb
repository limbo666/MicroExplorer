<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodeViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCodeViewer))
        Me.rtbCodeView = New System.Windows.Forms.RichTextBox()
        Me.btnSaveAs = New System.Windows.Forms.Button()
        Me.btnCopyToClipboard = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rtbCodeView
        '
        Me.rtbCodeView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbCodeView.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.rtbCodeView.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.rtbCodeView.ForeColor = System.Drawing.Color.GhostWhite
        Me.rtbCodeView.Location = New System.Drawing.Point(12, 12)
        Me.rtbCodeView.Name = "rtbCodeView"
        Me.rtbCodeView.Size = New System.Drawing.Size(521, 339)
        Me.rtbCodeView.TabIndex = 0
        Me.rtbCodeView.Text = ""
        '
        'btnSaveAs
        '
        Me.btnSaveAs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAs.Location = New System.Drawing.Point(12, 357)
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.Size = New System.Drawing.Size(109, 30)
        Me.btnSaveAs.TabIndex = 1
        Me.btnSaveAs.Text = "Save as..."
        Me.btnSaveAs.UseVisualStyleBackColor = True
        '
        'btnCopyToClipboard
        '
        Me.btnCopyToClipboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCopyToClipboard.Location = New System.Drawing.Point(127, 357)
        Me.btnCopyToClipboard.Name = "btnCopyToClipboard"
        Me.btnCopyToClipboard.Size = New System.Drawing.Size(109, 30)
        Me.btnCopyToClipboard.TabIndex = 2
        Me.btnCopyToClipboard.Text = "Copy to Clipboard"
        Me.btnCopyToClipboard.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(424, 357)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(109, 30)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmCodeViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 390)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCopyToClipboard)
        Me.Controls.Add(Me.btnSaveAs)
        Me.Controls.Add(Me.rtbCodeView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCodeViewer"
        Me.Text = "Quick Viewer"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rtbCodeView As RichTextBox
    Friend WithEvents btnSaveAs As Button
    Friend WithEvents btnCopyToClipboard As Button
    Friend WithEvents btnClose As Button
End Class

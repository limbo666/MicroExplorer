Public Class frmInfo
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Clipboard.SetText("""" & Application.ExecutablePath & """" & " -upload ""$(FULL_CURRENT_PATH)""")
            lblCopied.Text = "Command copied to clipboard"

            lblCopied.Visible = True

            tmrHide.Enabled = True
        Catch ex As Exception
            lblCopied.Text = "Error: " & ex.Message

            lblCopied.Visible = False
        End Try

        tmrHide.Enabled = False
    End Sub

    Private Sub frmInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = MainForm.Left + MainForm.Width + 10
        Me.Top = MainForm.Top
    End Sub

    Private Sub tmrHide_Tick(sender As Object, e As EventArgs) Handles tmrHide.Tick
        tmrHide.Enabled = False
        lblCopied.Visible = False

    End Sub
End Class
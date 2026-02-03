Imports System.IO

Public Class frmCodeViewer

    ' Property to easily set content from MainForm
    Public Sub LoadCode(filename As String, content As String)
        Me.Text = "Quick View - " & filename
        rtbCodeView.Text = content
        ' Reset cursor to top
        rtbCodeView.SelectionStart = 0
        rtbCodeView.ScrollToCaret()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCopyToClipboard_Click(sender As Object, e As EventArgs) Handles btnCopyToClipboard.Click
        If Not String.IsNullOrEmpty(rtbCodeView.Text) Then
            Clipboard.SetText(rtbCodeView.Text)
            MessageBox.Show("Copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnSaveAs_Click(sender As Object, e As EventArgs) Handles btnSaveAs.Click
        Using sfd As New SaveFileDialog()
            sfd.Filter = "Python Files|*.py|Text Files|*.txt|All Files|*.*"
            sfd.FileName = Me.Text.Replace("Quick View - ", "") ' Suggest original name

            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    File.WriteAllText(sfd.FileName, rtbCodeView.Text)
                    MessageBox.Show("File saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error saving file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub frmCodeViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppSettings.Load()
        Dim s = AppSettings.Current.ViewerWindow
        If s.Width > 0 Then
            Me.Location = New Point(s.X, s.Y)
            Me.Size = New Size(s.Width, s.Height)
        End If
    End Sub

    Private Sub frmCodeViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        With AppSettings.Current.ViewerWindow
            .X = Me.Location.X
            .Y = Me.Location.Y
            .Width = Me.Width
            .Height = Me.Height
        End With
        AppSettings.Save()
    End Sub
End Class
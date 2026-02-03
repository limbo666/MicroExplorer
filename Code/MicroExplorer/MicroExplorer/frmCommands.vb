Public Class frmCommands

    ' Reference to main form for execution
    Private _main As MainForm
    Private _snapDist As Integer = 20

    Public Sub New(main As MainForm)
        InitializeComponent()
        _main = main
    End Sub

    Private Sub frmCommands_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Load Settings
        AppSettings.Load()

        ' 2. Restore History
        cmbCommands.Items.Clear()
        For Each cmd In AppSettings.Current.CommandHistory
            cmbCommands.Items.Add(cmd)
        Next

        ' 3. Restore Buttons
        UpdateQuickButtons()

        ' 4. Restore Position & Size
        Dim s = AppSettings.Current.CmdWindow

        If s.Width > 0 Then
            ' User has a saved custom position, use it
            Me.Location = New Point(s.X, s.Y)
            Me.Size = New Size(s.Width, s.Height)
        Else
            ' No saved state (First Run) -> Snap to Bottom of Main
            Me.Width = _main.Width
            Me.Height = 120 ' Default Height
            Me.Location = New Point(_main.Left, _main.Bottom)
        End If
    End Sub
    Private Sub UpdateQuickButtons()
        Dim btns = {btnQuick1, btnQuick2, btnQuick3, btnQuick4, btnQuick5}
        Dim data = AppSettings.Current.QuickCommands

        For i As Integer = 0 To 4
            If i < data.Count Then
                btns(i).Text = data(i).Label
                btns(i).Tag = data(i).Command
                ' Add Context Menu to Edit
                AddEditContextMenu(btns(i), i)
            End If
        Next
    End Sub

    Private Sub AddEditContextMenu(btn As Button, index As Integer)
        Dim cms As New ContextMenuStrip()
        Dim itemEdit As New ToolStripMenuItem("Edit Command...", Nothing, Sub() EditCommand(index))
        cms.Items.Add(itemEdit)
        btn.ContextMenuStrip = cms
    End Sub

    Private Sub EditCommand(index As Integer)
        Dim data = AppSettings.Current.QuickCommands(index)
        Dim newLbl = InputBox("Button Label:", "Edit Quick Command", data.Label)
        Dim newCmd = InputBox("Python Command:", "Edit Quick Command", data.Command)

        If Not String.IsNullOrEmpty(newLbl) Then
            data.Label = newLbl
            data.Command = newCmd
            UpdateQuickButtons()
            AppSettings.Save()
        End If
    End Sub

    ' --- EXECUTION ---

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        Execute(cmbCommands.Text)
    End Sub

    Private Sub btnQuick_Click(sender As Object, e As EventArgs) Handles btnQuick1.Click, btnQuick2.Click, btnQuick3.Click, btnQuick4.Click, btnQuick5.Click
        Dim cmd As String = sender.Tag.ToString()
        Execute(cmd)
    End Sub

    Private Sub Execute(cmd As String)
        If String.IsNullOrWhiteSpace(cmd) Then Return

        ' Send to Main Form logic
        _main.ExecuteExternalCommand(cmd)

        ' Update History (FIFO 20)
        If cmbCommands.Items.Contains(cmd) Then cmbCommands.Items.Remove(cmd)
        cmbCommands.Items.Insert(0, cmd)
        If cmbCommands.Items.Count > 20 Then cmbCommands.Items.RemoveAt(20)
        cmbCommands.Text = cmd

        ' Sync to Settings
        AppSettings.Current.CommandHistory.Clear()
        For Each item As String In cmbCommands.Items
            AppSettings.Current.CommandHistory.Add(item)
        Next
        AppSettings.Save()
    End Sub

    ' --- SNAPPING & PERSISTENCE ---

    Private Sub frmCommands_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Save State
        With AppSettings.Current.CmdWindow
            .X = Me.Location.X
            .Y = Me.Location.Y
            .Width = Me.Width
            .Height = Me.Height
        End With
        AppSettings.Save()
    End Sub

    Private Sub frmCommands_Move(sender As Object, e As EventArgs) Handles Me.Move
        If _main Is Nothing Then Return

        ' Snap to Bottom of Main
        If Math.Abs(Me.Top - _main.Bottom) < _snapDist Then
            Me.Top = _main.Bottom
            ' Optional: Snap Left edges too
            If Math.Abs(Me.Left - _main.Left) < _snapDist Then Me.Left = _main.Left
        End If
    End Sub
End Class
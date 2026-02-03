Imports System.IO
Imports System.Web.Script.Serialization ' Requires Reference: System.Web.Extensions

Public Class AppSettings
    Public Class WindowState
        Public X As Integer
        Public Y As Integer
        Public Width As Integer
        Public Height As Integer
        Public Visible As Boolean
    End Class

    Public Class QuickCmd
        Public Label As String
        Public Command As String
    End Class

    Public Class SettingsData
        Public CommandHistory As New List(Of String)
        Public QuickCommands As New List(Of QuickCmd)
        Public CmdWindow As New WindowState
        Public ViewerWindow As New WindowState
    End Class

    Private Shared _filePath As String = Path.Combine(Application.StartupPath, "settings.json")
    Public Shared Current As New SettingsData()

    Public Shared Sub Load()
        If Not File.Exists(_filePath) Then
            Defaults()
            Return
        End If
        Try
            Dim json = File.ReadAllText(_filePath)
            Dim serializer As New JavaScriptSerializer()
            Current = serializer.Deserialize(Of SettingsData)(json)

            ' Safety checks
            If Current.QuickCommands Is Nothing Then Current.QuickCommands = New List(Of QuickCmd)
            If Current.CommandHistory Is Nothing Then Current.CommandHistory = New List(Of String)
            If Current.CmdWindow Is Nothing Then Current.CmdWindow = New WindowState()
            If Current.ViewerWindow Is Nothing Then Current.ViewerWindow = New WindowState()
        Catch
            Defaults()
        End Try
    End Sub

    Public Shared Sub Save()
        Try
            Dim serializer As New JavaScriptSerializer()
            Dim json = serializer.Serialize(Current)
            File.WriteAllText(_filePath, json)
        Catch
        End Try
    End Sub

    Private Shared Sub Defaults()
        Current.QuickCommands.Clear()
        ' Add 5 default slots
        For i As Integer = 1 To 5
            Current.QuickCommands.Add(New QuickCmd With {.Label = "Cmd " & i, .Command = "print('Hello " & i & "')"})
        Next

        ' Set Width to 0 to signal "Auto-Snap" logic in the form loader
        Current.CmdWindow = New WindowState With {.X = 0, .Y = 0, .Width = 0, .Height = 120}
    End Sub
End Class
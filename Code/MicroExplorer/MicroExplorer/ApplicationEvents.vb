Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        ' This event fires when a second instance tries to start (e.g. from Notepad++)
        Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            ' Capture arguments
            Dim args = e.CommandLine

            If args.Count > 0 AndAlso My.Application.MainForm IsNot Nothing Then
                Dim main As MainForm = CType(My.Application.MainForm, MainForm)
                ' Pass args to the new centralized handler on the UI thread
                main.BeginInvoke(Sub() main.ProcessCommandLineArgs(args))
            End If
        End Sub

    End Class
End Namespace

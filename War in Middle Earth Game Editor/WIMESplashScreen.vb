Imports WIMEEditor.EditorSettings
Public NotInheritable Class WIMESplashScreen
    Private Sub SplashScreen2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        'Copyright.Text = My.Application.Info.Copyright
        ApplicationTitle.Text = progName
        Version.Text = "Version " & progVersion & " " & progDate & " - Special Version for Donors"
        Copyright.Text = "Copyright (C) 2017 Aaron R. Willis"
        Copyright2.Text = "War in Middle Earth -- Copyright (C) 1988 Melbourne House"
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        pgr1.Increment(10)
        If pgr1.Value = 300 Then
            frmWIMEEditorMain.Show()
            Me.Hide()
        End If
    End Sub
End Class

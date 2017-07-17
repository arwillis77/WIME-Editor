
Imports WIMEEditor.EditorSettings
Imports System.Xml
Public Class frmProgramSettings
    Public tempSettings As New EditorSettings
    Private Sub frmProgramSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tempSettings = loadConfig(settingsFullFilename)
        txtWIMEFolder.Text = tempSettings.wimeDIRECTORY
        txtApplicationDirectory.Text = tempSettings.dataDirectory
        txtBackgroundImage.Text = tempSettings.backgroundImage
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnBackgroundDir_Click(sender As Object, e As EventArgs) Handles btnBackgroundDir.Click
        ' Changes the application's background image.
        loadedSettings = loadConfig(settingsFullFilename)
        Dim tempImage As String
        Dim tempSettingsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & Application.ProductName & "\" & settingsFilename
        Dim tempFD As New OpenFileDialog
        tempFD.InitialDirectory = tempSettings.backgroundImageDirectory
        tempFD.Title = "Select the image to display as the background to the WIME Editor."
        tempFD.Filter = "PNG|*.png|All Files|*.*"
        tempFD.RestoreDirectory = False
        tempFD.FileName = ""
        tempFD.ShowDialog()
        tempImage = tempFD.SafeFileName
        Dim XmlDoc As XmlDocument = New XmlDocument
        XmlDoc.Load(tempSettingsFile)
        XmlDoc.DocumentElement(tempSettings.stringBackground).InnerText = tempImage
        XmlDoc.Save(tempSettingsFile)
        txtBackgroundImage.Text = tempImage
        frmWIMEEditorMain.BackgroundImage = Image.FromFile(loadedSettings.backgroundImageDirectory & "\" & tempImage)
    End Sub
    Private Sub btnWIMEDirectory_Click(sender As Object, e As EventArgs) Handles btnWIMEDirectory.Click
        ' Changes the directory for the location of WIME.
        Dim tempSettingsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & Application.ProductName & "\" & settingsFilename
        Dim tempDir As String
        tempDir = selectWIMEDirectory()
        Dim XmlDoc As XmlDocument = New XmlDocument
        XmlDoc.Load(tempSettingsFile)
        XmlDoc.DocumentElement(tempSettings.stringWIMEDirectory).InnerText = tempDir
        XmlDoc.Save(tempSettingsFile)
        txtWIMEFolder.Text = tempDir
    End Sub
End Class
Imports WIMEEditor.EditorSettings
Imports System.Xml
Public Class frmProgramSettings
    Public tempSettings As New EditorSettings
    Private Sub frmProgramSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tempSettings = LoadConfig(settingsFullFilename)
        txtWIMEFolder.Text = tempSettings.wimeDIRECTORY
        txtApplicationDirectory.Text = tempSettings.dataDirectory
        txtBackgroundImage.Text = tempSettings.backgroundImage
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub btnWIMEDirectory_Click(sender As Object, e As EventArgs) Handles btnWIMEDirectory.Click
        ' Changes the directory for the location of WIME.
        Dim tempSettingsFile As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & Application.ProductName & "\" & settingsFilename
        Dim tempDir As String
        tempDir = SelectWIMEDirectory()
        Dim XmlDoc As XmlDocument = New XmlDocument
        XmlDoc.Load(tempSettingsFile)
        XmlDoc.DocumentElement(tempSettings.stringWIMEDirectory).InnerText = tempDir
        XmlDoc.Save(tempSettingsFile)
        txtWIMEFolder.Text = tempDir
    End Sub
End Class
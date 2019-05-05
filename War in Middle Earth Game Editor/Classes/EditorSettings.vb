Imports System.Xml
Imports System.IO
Imports WIMEEditor.Game
Public Class EditorSettings
    Public Const progName As String = "WAR IN MIDDLE-EARTH GAME EDITOR"
    Public Const progVersion As String = ".09A BUILD 10"
    Public Const progDate As String = "03/11/2019"
    Public Const settingsFilename = "WIMEEDITOR.CFG"
    Public Shared settingsFullFilename As String = (Application_Path & "\" & settingsFilename)
    'Public Shared settingsFullFilename As String = (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & Application.ProductName & "\" & settingsFilename)
    Public stringRoot As String
    Public stringVersion As String
    Public stringDataDirectory As String
    Public stringWIMEDirectory As String

    Public version As String
    Public backgroundImage As String
    Public backgroundImageDirectory As String
    Public dataDirectory As String
    Public wimeDIRECTORY As String
    Public FormBackgroundColor As Color = Color.FromArgb(35, 35, 35)
    Public Sub New()
        stringRoot = "WIMEEDITORSettings"
        stringVersion = "Version"
        stringDataDirectory = "DataDirectory"
        stringWIMEDirectory = "WIMEDirectory"
    End Sub
    Public Shared Function LoadConfig(ByVal filename As String) As EditorSettings
        Dim tempSettings As New EditorSettings
        Dim tempstring As String
        Dim path As String = filename
        Dim Input As New XmlTextReader(path) With {
            .WhitespaceHandling = WhitespaceHandling.None
        }
        Do While Input.Read()
            If Input.NodeType = XmlNodeType.Element Then
                Select Case Input.Name
                    Case tempSettings.stringDataDirectory
                        tempstring = Input.ReadString()
                        tempSettings.dataDirectory = tempstring
                    Case tempSettings.stringWIMEDirectory
                        tempstring = Input.ReadString()
                        tempSettings.wimeDIRECTORY = tempstring
                End Select
            End If
        Loop
        Input.Close()
        Return tempSettings
    End Function
    ' // TO DO Convert FileFormatSettings and CFileSettings to this class using ListOf
    Public Shared Sub CreateConfig()
        Dim path As String = Application_Path
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        Dim tempSettings As New EditorSettings With {
            .version = progVersion,
            .dataDirectory = path,
            .wimeDIRECTORY = SelectWIMEDirectory()
        }
        settings.Indent = True
        Using writer As XmlWriter = XmlWriter.Create(path & "\" & settingsFilename, settings)
            ' Begin writing.
            writer.WriteStartDocument()
            writer.WriteStartElement(tempSettings.stringRoot) ' Root.
            writer.WriteElementString(tempSettings.stringVersion, tempSettings.version)
            writer.WriteElementString(tempSettings.stringDataDirectory, tempSettings.dataDirectory)
            writer.WriteElementString(tempSettings.stringWIMEDirectory, tempSettings.wimeDIRECTORY)

            ' End document.
            writer.WriteEndElement()
            writer.WriteEndDocument()
            'writer.Close() ' Gets closed automatically on the end of the Using block
        End Using
    End Sub
    Public Shared Function SelectWIMEDirectory() As String
        Dim fb As New FolderBrowserDialog With {
            .Description = "Select the folder location for the War in Middle Earth game files."
        }
        fb.ShowDialog()
        Return fb.SelectedPath
    End Function
    Public Shared Function SelectDataDirectory() As String
        Dim fb As New FolderBrowserDialog With {
            .Description = "Select the folder to store data for the WIME Editor."
        }
        fb.ShowDialog()
        Return fb.SelectedPath
    End Function
    Public Shared Sub SaveWIMEDirectory(tempdir As String)
        Dim tempSettings As New EditorSettings
        tempSettings = LoadConfig(settingsFullFilename)
        Dim tempfile As String = settingsFullFilename
        Dim XmlDoc As XmlDocument = New XmlDocument
        XmlDoc.Load(tempfile)
        XmlDoc.DocumentElement(tempSettings.stringWIMEDirectory).InnerText = tempdir
        XmlDoc.Save(tempfile)
    End Sub
End Class

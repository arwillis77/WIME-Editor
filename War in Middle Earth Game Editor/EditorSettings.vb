Imports System.Xml
Imports System.IO
Imports WIMEEditor.Game
Public Class EditorSettings
    Public Const progName As String = "WAR IN MIDDLE-EARTH GAME EDITOR"
    Public Const progVersion As String = ".09A BUILD 5"
    Public Const progDate As String = "11/08/2017"
    Public Const settingsFilename = "WIMEEDITOR.CFG"
    Public Shared PaletteFolder = "PALETTE"
    Public Shared settingsFullFilename As String = (Application_Path & "\" & settingsFilename)
    Public Const WIMEWallPaperDirectoryName = "\WIMEWallpaper"
    'Public Shared settingsFullFilename As String = (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & Application.ProductName & "\" & settingsFilename)
    Public Const mapTileSizeDefault = 16
    Public Shared fileformat_total As UShort
    Public stringRoot As String
    Public stringVersion As String
    Public stringBackground As String
    Public stringBackgroundDirectory As String
    Public stringDataDirectory As String
    Public stringWIMEDirectory As String
    Public stringMapTileSize As String
    Public stringFileFormat As String
    Public stringMapFile As String
    Public stringMapOffset As String
    Public stringMapSize As String
    Public stringTileFile As String
    Public stringTileOffset As String
    Public version As String
    Public backgroundImage As String
    Public backgroundImageDirectory As String
    Public dataDirectory As String
    Public wimeDIRECTORY As String
    Public mapTileSize As Integer
    Public fileFormat As String
    Public mapFile As String
    Public mapFileOffset As Integer
    Public mapSize As Integer
    Public tileFile As String
    Public tileOffset As Integer
    Public FormBackgroundColor As Color = Color.FromArgb(35, 35, 35)
    Public Sub New()
        stringRoot = "WIMEEDITORSettings"
        stringVersion = "Version"
        stringBackground = "ProgramBackgroundImage"
        stringBackgroundDirectory = "BackgroundImageDirectory"
        stringDataDirectory = "DataDirectory"
        stringWIMEDirectory = "WIMEDirectory"
        stringMapTileSize = "MapTileSize"
        stringFileFormat = "FileFormat"
        stringMapFile = "MapFileName"
        stringMapOffset = "MapFileOffset"
        stringMapSize = "MapChunkSize"
        stringTileFile = "TilemapFileName"
        stringTileOffset = "TilemapOffset"
    End Sub
    Public Shared Function loadConfig(ByVal filename As String) As EditorSettings
        Dim tempSettings As New EditorSettings
        Dim tempstring As String
        Dim path As String = filename
        Dim Input As New XmlTextReader(path)
        Input.WhitespaceHandling = WhitespaceHandling.None
        Do While Input.Read()
            If Input.NodeType = XmlNodeType.Element Then
                Select Case Input.Name
                    Case tempSettings.stringBackground
                        tempstring = Input.ReadString
                        tempSettings.backgroundImage = tempstring
                    Case tempSettings.stringBackgroundDirectory
                        tempstring = Input.ReadString
                        tempSettings.backgroundImageDirectory = tempstring
                    Case tempSettings.stringDataDirectory
                        tempstring = Input.ReadString()
                        tempSettings.dataDirectory = tempstring
                    Case tempSettings.stringWIMEDirectory
                        tempstring = Input.ReadString()
                        tempSettings.wimeDIRECTORY = tempstring
                    Case tempSettings.stringFileFormat
                        tempSettings.fileFormat = Input.ReadString()
                    Case tempSettings.stringMapFile
                        tempSettings.mapFile = Input.ReadString
                    Case tempSettings.stringMapTileSize
                        tempstring = Input.ReadString
                        tempSettings.mapTileSize = CInt(tempstring)
                    Case tempSettings.stringMapSize
                        tempstring = Input.ReadString
                        tempSettings.mapSize = CInt(tempstring)
                    Case tempSettings.stringMapOffset
                        tempstring = Input.ReadString
                        tempSettings.mapFileOffset = CInt(tempstring)
                    Case tempSettings.stringTileFile
                        tempSettings.tileFile = Input.ReadString
                    Case tempSettings.stringTileOffset
                        tempstring = Input.ReadString
                        tempSettings.tileOffset = CInt(tempstring)
                End Select
            End If
        Loop
        Input.Close()
        Return tempSettings
    End Function
    ' // TO DO Convert FileFormatSettings and CFileSettings to this class using ListOf
    Public Class FileSettings
        Public executable As String
        Public format As String
        Public format_desc As String
        Public icon As Image
        Public map_file As String
        Public map_size As Integer
        Public map_offsetlocation As Integer
        Public tile_file As String
        Public tile_offsetlocation As Integer
    End Class
    Public Shared Sub createConfig()
        Dim path As String = Application_Path
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        Dim tempSettings As New EditorSettings
        tempSettings.version = progVersion
        tempSettings.dataDirectory = path
        tempSettings.backgroundImageDirectory = path & WIMEWallPaperDirectoryName
        tempSettings.backgroundImage = "oldmapbg.png"
        tempSettings.wimeDIRECTORY = selectWIMEDirectory()
        tempSettings.mapTileSize = mapTileSizeDefault
        settings.Indent = True
        Using writer As XmlWriter = XmlWriter.Create(path & "\" & settingsFilename, settings)
            ' Begin writing.
            writer.WriteStartDocument()
            writer.WriteStartElement(tempSettings.stringRoot) ' Root.
            writer.WriteElementString(tempSettings.stringVersion, tempSettings.version)
            writer.WriteElementString(tempSettings.stringBackground, tempSettings.backgroundImage)
            writer.WriteElementString(tempSettings.stringBackgroundDirectory, tempSettings.backgroundImageDirectory)
            writer.WriteElementString(tempSettings.stringDataDirectory, tempSettings.dataDirectory)
            writer.WriteElementString(tempSettings.stringWIMEDirectory, tempSettings.wimeDIRECTORY)
            writer.WriteElementString(tempSettings.stringMapTileSize, tempSettings.mapTileSize)
            writer.WriteElementString(tempSettings.stringFileFormat, tempSettings.fileFormat)
            writer.WriteElementString(tempSettings.stringMapFile, tempSettings.mapFile)
            writer.WriteElementString(tempSettings.stringMapOffset, tempSettings.mapFileOffset)
            writer.WriteElementString(tempSettings.stringMapSize, tempSettings.mapSize)
            writer.WriteElementString(tempSettings.stringTileFile, tempSettings.tileFile)
            writer.WriteElementString(tempSettings.stringTileOffset, tempSettings.tileOffset)
            ' End document.
            writer.WriteEndElement()
            writer.WriteEndDocument()
            writer.Close()
        End Using
    End Sub
    Public Shared Function selectWIMEDirectory() As String
        Dim fb As New FolderBrowserDialog
        fb.Description = "Select the folder location for the War in Middle Earth game files."
        fb.ShowDialog()
        Return fb.SelectedPath
    End Function
    Public Shared Function selectDataDirectory() As String
        Dim fb As New FolderBrowserDialog
        fb.Description = "Select the folder to store data for the WIME Editor."
        fb.ShowDialog()
        Return fb.SelectedPath
    End Function
    Public Shared Sub setMapSize(tilesize As Integer)
        Dim tempSettings As New EditorSettings
        tempSettings = loadConfig(settingsFullFilename)
        Dim tempSize As Integer = tilesize
        Dim tempfile As String = settingsFullFilename
        Dim XmlDoc As XmlDocument = New XmlDocument
        XmlDoc.Load(tempfile)
        XmlDoc.DocumentElement(tempSettings.stringMapTileSize).InnerText = tempSize
        XmlDoc.Save(tempfile)
        'Return tempSize
    End Sub
    Public Shared Sub setFileId(fileid As String)
        Dim tempSettings As New EditorSettings
        tempSettings = loadConfig(settingsFullFilename)
        Dim tempId As String = fileid
        Dim tempfile As String = settingsFullFilename
        Dim XmlDoc As XmlDocument = New XmlDocument
        XmlDoc.Load(tempfile)
        XmlDoc.DocumentElement(tempSettings.stringFileFormat).InnerText = tempId
        XmlDoc.Save(tempfile)
    End Sub
    Public Shared Sub saveWIMEDirectory(tempdir As String)
        Dim tempSettings As New EditorSettings
        tempSettings = loadConfig(settingsFullFilename)
        Dim tempfile As String = settingsFullFilename
        Dim XmlDoc As XmlDocument = New XmlDocument
        XmlDoc.Load(tempfile)
        XmlDoc.DocumentElement(tempSettings.stringWIMEDirectory).InnerText = tempdir
        XmlDoc.Save(tempfile)
    End Sub
    Public Shared Sub setMapData(filename As String, offset As Integer, size As Integer)
        Dim tempSettings As New EditorSettings
        tempSettings = loadConfig(settingsFullFilename)
        Dim tempname As String = filename
        Dim tempoff As Integer = offset
        Dim tempsize As Integer = size
        Dim tempfile As String = settingsFullFilename
        Dim XmlDoc As XmlDocument = New XmlDocument
        XmlDoc.Load(tempfile)
        XmlDoc.DocumentElement(tempSettings.stringMapFile).InnerText = tempname
        XmlDoc.DocumentElement(tempSettings.stringMapOffset).InnerText = tempoff
        XmlDoc.DocumentElement(tempSettings.stringMapSize).InnerText = tempsize
        XmlDoc.Save(tempfile)
    End Sub
    Public Shared Sub setTileData(filename As String, offset As Integer)
        Dim tempSettings As New EditorSettings
        tempSettings = loadConfig(settingsFullFilename)
        Dim tempname As String = filename
        Dim tempoff As Integer = offset
        Dim tempfile As String = settingsFullFilename
        Dim XmlDoc As XmlDocument = New XmlDocument
        XmlDoc.Load(tempfile)
        XmlDoc.DocumentElement(tempSettings.stringTileFile).InnerText = tempname
        XmlDoc.DocumentElement(tempSettings.stringTileOffset).InnerText = tempoff
        XmlDoc.Save(tempfile)
    End Sub
    Public Shared Sub checkTileFolder()
        loadedSettings = loadConfig(settingsFullFilename)
        Dim tempMapTileSize As Integer = loadedSettings.mapTileSize
        'Dim temptileMapCompleteFilename As String
        Dim temptileDirectory As String = loadedSettings.dataDirectory & "\TILES"
        Dim temptileSizeDirectory As String = loadedSettings.dataDirectory & "\TILES\TILES" & tempMapTileSize
        If (Not System.IO.Directory.Exists(temptileDirectory)) Then
            MsgBox("Creating " & temptileDirectory)
            Directory.CreateDirectory(temptileDirectory)
            MsgBox("Creating " & temptileSizeDirectory)
            Directory.CreateDirectory(temptileSizeDirectory)
        End If
    End Sub
End Class

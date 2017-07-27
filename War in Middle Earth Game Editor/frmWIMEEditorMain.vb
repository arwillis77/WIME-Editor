'Option Explicit On
'Option Strict On
Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports WIMEEditor.EditorSettings
Imports WIMEEditor.Game
Public Class frmWIMEEditorMain
    ' / frmWIMEEditorMaiin -- Form for the Main Editor */
    ' CONSTANT AND SHARED VARIABLES
    ' PUBLIC VARIABLES
    Public fileChunkTotal As Integer = 0
    Public gameLoaded As Boolean = False
    Public resCounter As Integer
    ' STRING VARIABLES
    Public stripFilename As String
    Public WithEvents tclExplorerMain As TabControlEx
    Public WithEvents tclResourceTabs As TabControl
    Private Sub frmWIMEEditorMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim backgroundfile As String
        Dim path As String
        Dim tempbg As String
        Try
            path = Application_Path
            VerifyDirectory(path)
            tempbg = path + WIMEWallPaperDirectoryName
            If (Not System.IO.File.Exists(settingsFullFilename)) Then
                createConfig()
            Else
                loadedSettings = loadConfig(settingsFullFilename)
            End If
            loadedSettings = loadConfig(settingsFullFilename)
            Try
                backgroundfile = loadedSettings.backgroundImageDirectory & "\" & loadedSettings.backgroundImage
                pnlEditor.Hide()
                BackgroundImage = Image.FromFile(backgroundfile) : BackgroundImageLayout = ImageLayout.Stretch
            Catch ex As Exception
                MsgBox("PROGRAM ERROR! LOCATION frmWIMEEditorMain.  Wallpaper error!" & vbLf & vbLf & "Make sure you have " & loadedSettings.backgroundImageDirectory _
                       & "exists.  Then manually select your wallpaper through the program p_settings." &
                       "Program will default to no wallpaper." & vbLf & vbLf & ex.ToString)
                Me.BackgroundImage = Nothing
            End Try
            gameLoaded = False
            GameLoadedStatusChange()
            Me.Text = progName & " v" & progVersion & " " & progDate
            Me.WindowState = FormWindowState.Maximized
        Catch ex As Exception
            MsgBox("PROGRAM ERROR!  LOCATION: frmWIMEEditorMain Load Method. " & vbLf & vbLf & ex.ToString)
        End Try
    End Sub
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        tclExplorerMain = New TabControlEx
        tclResourceTabs = New TabControl
        Controls.Add(tclExplorerMain)
        Controls.Add(tclResourceTabs)
        tclExplorerMain.Hide()
        tclResourceTabs.Hide()
    End Sub
    Private Sub frmWIMEEditorMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' ********************************************************************************************************
        ' **** Handles Events of Closing the Main Form.                                                       ****
        ' ********************************************************************************************************
        End
    End Sub
    Public Sub OpenWIMEGame()
        Dim p_filename As String
        Dim p_filedir As String
        Dim p_fileDialog As OpenFileDialog
        Dim p_closeGame As Boolean
        If gameLoaded = True Then
            p_closeGame = CloseCurrentGame()
            If p_closeGame = False Then
                Exit Sub
            Else
                ClearGame()
            End If
        End If
        p_fileDialog = FileOpenDialog()
        p_filename = p_fileDialog.SafeFileName
        p_filedir = System.IO.Path.GetDirectoryName(p_fileDialog.FileName)
        saveWIMEDirectory(p_filedir)
        loadedGame = New Game(p_filename)
        ' Analyze filename and determine format
        setFileId(loadedGame.format)                                           ' Save format to CFG file.
        Init_ColorIndex(loadedGame.format)
        gameLoaded = True
        GameLoadedStatusChange()
        pnlEditor.Show()
        tclExplorerMain.Show()
        tclResourceTabs.Show()
        loadedSettings = loadConfig(settingsFullFilename)
        LoadGame()
    End Sub
    Public Sub LoadGame()
        Dim EXP As New TabPage
        GetFileList()
        tclExplorerMain = New TabControlEx
        tclExplorerMain.Dock = DockStyle.Fill
        tclResourceTabs = New TabControl
        ResourceImages = New ImageList
        ResourceImages.ImageSize = New Size(16, 16)
        ResourceImages.Images.Add(My.Resources.menutileicon)
        ResourceImages.Images.Add(My.Resources.texticon32)
        ResourceImages.Images.Add(My.Resources.fonts)
        ResourceImages.Images.Add(My.Resources.menuanimicon)
        ResourceImages.Images.Add(My.Resources.menusceneiconbig)
        ResourceImages.Images.Add(My.Resources.menumapicon)
        ResourceImages.Images.Add(My.Resources.menuarchiveicon)
        tclResourceTabs.ImageList = ResourceImages
        tabCHAR = New TabPage : tabCHAR.Text = Game.resource.RES_ID(0) & "      " : tabCHAR.ImageIndex = 0
        Dim CHARform = New frmResourceList(Game.resource.RES_ID_ELEMENTS(0))
        tabCHAR.Controls.Add(CHARform) : CHARform.Show()
        tabCSTR = New TabPage : tabCSTR.Text = Game.resource.RES_ID(1) & "      " : tabCSTR.ImageIndex = 1
        Dim CSTRform = New frmResourceList(Game.resource.RES_ID_ELEMENTS(1))
        tabCSTR.Controls.Add(CSTRform) : CSTRform.Show()
        tabFONT = New TabPage : tabFONT.Text = Game.resource.RES_ID(2) & "      " : tabFONT.ImageIndex = 2
        Dim FONTform = New frmResourceList(Game.resource.RES_ID_ELEMENTS(2))
        tabFONT.Controls.Add(FONTform) : FONTform.Show()
        tabFRML = New TabPage : tabFRML.Text = Game.resource.RES_ID(3) & "      " : tabFRML.ImageIndex = 3
        Dim FRMLform = New frmResourceList(Game.resource.RES_ID_ELEMENTS(3))
        tabFRML.Controls.Add(FRMLform) : FRMLform.Show()
        tabIMAG = New TabPage : tabIMAG.Text = Game.resource.RES_ID(4) & "      " : tabIMAG.ImageIndex = 4
        Dim IMAGform = New frmResourceList(Game.resource.RES_ID_ELEMENTS(4))
        tabIMAG.Controls.Add(IMAGform) : IMAGform.Show()
        tabMMAP = New TabPage : tabMMAP.Text = Game.resource.RES_ID(5) & "      " : tabMMAP.ImageIndex = 5
        Dim MMAPForm = New frmResourceList(Game.resource.RES_ID_ELEMENTS(5))
        tabMMAP.Controls.Add(MMAPForm) : MMAPForm.Show()
        tabArchive = New TabPage : tabArchive.Text = Game.Archive.ARC_ID & "      " : tabArchive.ImageIndex = 6
        Dim ArchiveForm = New frmResourceList(Game.Archive.ARC_ID)
        tabArchive.Controls.Add(ArchiveForm) : ArchiveForm.Show()
        EXP.Text = "Resource Explorer - " & gameExecutables(loadedGame.formatVal) & "      "
        pnlEditor.Controls.Add(tclExplorerMain)
        tclExplorerMain.TabPages.Add(EXP)
        EXP.Controls.Add(tclResourceTabs)
        tclResourceTabs.Dock = DockStyle.Fill
        tclResourceTabs.TabPages.Add(tabCHAR) : tclResourceTabs.TabPages.Add(tabCSTR) : tclResourceTabs.TabPages.Add(tabFONT) : tclResourceTabs.TabPages.Add(tabFRML) : tclResourceTabs.TabPages.Add(tabIMAG)
        tclResourceTabs.TabPages.Add(tabMMAP) : tclResourceTabs.TabPages.Add(tabArchive)
        tclResourceTabs.SelectedTab = tabCHAR
    End Sub
    Public Sub GetFileList()
        ' ******************************************************************************************************************************
        ' Checks directory for resource files.  Parses all files with .RES extension then included only valid files in new array.
        ' ******************************************************************************************************************************
        ' Opens WIME configuration file to obtain directory information.
        Dim p_WIMEDirectory As String
        Dim tEndian As Integer
        Dim nfilecount As Integer                                                              ' Counter for total number of VALID resource files.
        Dim resFilename As String
        p_WIMEDirectory = loadedSettings.wimeDIRECTORY
        nfilecount = 0
        Dim initialResFileArray() = System.IO.Directory.GetFiles(p_WIMEDirectory & "\", "*.res")         ' Adds all files with .RES extension into first array.
        GameResourceList = New resource.ResourceList
        Try
            tEndian = loadedGame.endianType
            ' Scan Resource Files
            For a As Integer = 0 To initialResFileArray.Length - 1
                resFilename = initialResFileArray(a)
                If validateHeader(resFilename, tEndian) = True Then
                    nfilecount = nfilecount + 1
                Else
                    MsgBox(resFilename & " is not a valid resourcefile")
                End If
            Next
            ' Recalibrate resource file array to include only valid resource files.
            Dim arrfiles(0 To nfilecount - 1) As String                                                     ' Declares new array for VALID resource file list.
            Dim newcount As Integer = 0                                                                 ' Counter
            For b As Integer = 0 To initialResFileArray.Length - 1
                resFilename = initialResFileArray(b)
                If validateHeader(resFilename, tEndian) = True Then
                    arrfiles(newcount) = resFilename
                    fileChunkTotal = fileChunkTotal + _getResourceFileChunkTotal(resFilename, tEndian)
                    newcount = newcount + 1
                Else
                End If
            Next
            For j = 0 To newcount - 1
                Dim tfilename As String
                tfilename = arrfiles(j)
                storeFileArrays(tfilename, tEndian)
            Next
        Catch ex As Exception
            MsgBox("PROGRAM ERROR!  LOCATION: GetFileList in frmWIMEEditorMain. " & vbLf & vbLf & ex.ToString)
        End Try
    End Sub
    Private Sub storeFileArrays(resourcefilename As String, tempend As Integer)
        '// * PROCEDURE LEVEL VARIABLE AND OBJECTS DEFINITIONS
        Dim p_ChunkTotal As Integer = _getChunkTypeQTY(resourcefilename, tempend)
        Dim p_ResourceTotal As Integer = 0
        Dim p_KeyPosition As Integer = 0
        Dim p_dataEndian As Integer = 0
        Dim p_filepointer As Integer = 0
        Dim p_ResourceRecord As New resource.ResourceDetails
        Dim p_header As New Game.resource.Header
        Dim p_resourcemap() As Game.resource.resourceMap
        Dim p_ResourceIdentifier As New List(Of Game.resource.newResourceIdentifier)
        Dim TResId(0 To p_ChunkTotal) As Game.resource.newResourceIdentifier
        Try
            p_header = _readResourceHeader(resourcefilename, tempend)
            p_filepointer = (p_header.DataSegmentSize + p_header.Size) + (14)
            p_dataEndian = loadedGame.DataEndianType
            For x As Integer = 0 To p_ChunkTotal - 1
                TResId(x).resourceID = _getChunkID(resourcefilename, p_filepointer, tempend)
                p_filepointer = p_filepointer + 4
                TResId(x).resourceQTY = _getChunkQTY(resourcefilename, p_filepointer, tempend)
                p_filepointer = p_filepointer + 4
            Next
            p_KeyPosition = getResKeyPosition(resourcefilename, tempend)
            Dim tk As Integer = 0
            For xx As Integer = 0 To p_ChunkTotal - 1
                Dim tempoff As ULong
                p_ResourceTotal = TResId(xx).resourceQTY
                ReDim p_resourcemap(0 To p_ResourceTotal)
                For yy As Integer = 0 To TResId(xx).resourceQTY - 1
                    Try
                        p_resourcemap(yy).Number = _readResMapNum(resourcefilename, p_KeyPosition + (12 * tk), tempend)
                        p_resourcemap(yy).Offset = _readResMapOffset(resourcefilename, (p_KeyPosition + 4) + (12 * tk), tempend)
                        p_resourcemap(yy).intMultiplier = _readResMapMultiplier(resourcefilename, (p_KeyPosition + 6) + (12 * tk), tempend)
                        stripFilename = Path.GetFileNameWithoutExtension(resourcefilename)
                        ' Record resource file data.
                        p_ResourceRecord.Name = TResId(xx).resourceID & " " & p_resourcemap(yy).Number
                        p_ResourceRecord.Number = p_resourcemap(yy).Number
                        tempoff = (p_resourcemap(yy).Offset + p_header.Size) + (INT_MAX * p_resourcemap(yy).intMultiplier) + (1 * p_resourcemap(yy).intMultiplier)
                        p_ResourceRecord.dataSize = _getChunkSize(resourcefilename, tempoff, tempend)
                        p_ResourceRecord.resourceFile = stripFilename
                        p_ResourceRecord.resourceType = _getResourceType(TResId(xx).resourceID)
                        p_ResourceRecord.fileOffset = (p_resourcemap(yy).Offset + p_header.Size) + (INT_MAX * p_resourcemap(yy).intMultiplier) + (1 * p_resourcemap(yy).intMultiplier)
                        If TResId(xx).resourceID = Game.resource.CHAR_ID Then
                            loadedTile = New Game.resource.tileChunk
                            loadedTile.filename = resourcefilename
                            loadedTile.offset = p_ResourceRecord.fileOffset
                            loadedTile.DataStartOffset = loadedTile.offset + 4         ' Offset plus size of chunk size entry.
                            setTileData(loadedTile.filename, loadedTile.DataStartOffset)
                            For x As Integer = 0 To 255
                                Dim p_TileResourceRecord As New Game.resource.ResourceDetails
                                p_TileResourceRecord = CreateTile(x)
                                'MsgBox(p_TileResourceRecord.Name & vbCrLf & p_TileResourceRecord.resourceType & vbCrLf & p_TileResourceRecord.Number & vbCrLf & p_TileResourceRecord.dataSize & vbCrLf & p_TileResourceRecord.resourceFile & vbCrLf &
                                'p_TileResourceRecord.fileOffset)
                                p_TileResourceRecord.resourceType = _getResourceType(TResId(xx).resourceID)
                                GameResourceList.Add(p_TileResourceRecord.Name, p_TileResourceRecord.resourceType, p_TileResourceRecord.Number, p_TileResourceRecord.dataSize, p_TileResourceRecord.resourceFile,
                                                p_TileResourceRecord.fileOffset)
                            Next x
                        Else
                            GameResourceList.Add(p_ResourceRecord.Name, p_ResourceRecord.resourceType, p_ResourceRecord.Number, p_ResourceRecord.dataSize, p_ResourceRecord.resourceFile,
                                                 p_ResourceRecord.fileOffset)
                        End If
                        If p_ResourceRecord.Name = "IMAG 100" Then
                            SelectedResourceItem.Name = p_ResourceRecord.Name
                            SelectedResourceItem.resourceType = p_ResourceRecord.resourceType
                            SelectedResourceItem.Number = p_ResourceRecord.Number
                            SelectedResourceItem.dataSize = p_ResourceRecord.dataSize
                            SelectedResourceItem.resourceFile = p_ResourceRecord.resourceFile
                            SelectedResourceItem.fileOffset = p_ResourceRecord.fileOffset
                            Dim mi As frmMapIcon
                            mi = New frmMapIcon
                            mi.Show()
                            mi.Dispose()
                        End If
                        Select Case p_ResourceRecord.resourceType
                            Case Game.resource.RES_ID_ELEMENTS(5) ' MAPS
                                loadedMMAP = New Game.resource.MapChunk
                                loadedMMAP.filename = resourcefilename
                                loadedMMAP.offset = p_ResourceRecord.fileOffset
                                loadedMMAP.chunkSize = p_ResourceRecord.dataSize - 18
                                loadedMMAP.DataStartOffset = p_ResourceRecord.fileOffset + 8          ' Offset plus size of chunk size and uncomp. size entries (2 x 4 bytes)
                                loadedMMAP.width = Game.resource.WIME_WORLDMAP_SIZE(0)
                                loadedMMAP.height = Game.resource.WIME_WORLDMAP_SIZE(1)
                                loadedMMAP.planes = 1
                                setMapData(loadedMMAP.filename, loadedMMAP.DataStartOffset, loadedMMAP.chunkSize)
                                'GameResourceList.Add(p_ResourceRecord.Name, p_ResourceRecord.resourceType, p_ResourceRecord.Number, p_ResourceRecord.dataSize, p_ResourceRecord.resourceFile,
                                'p_ResourceRecord.fileOffset)
                        End Select
                        resCounter = resCounter + 1
                        tk = tk + 1
                    Catch ex As Exception
                        MsgBox("Store File Arrays Error! " & ex.Message)
                    End Try
                Next yy
            Next xx
        Catch ex As Exception
            MsgBox("PROGRAM ERROR!  LOCATION: Store File Arrays in frmWIMEEditorMain. " & vbLf & vbLf & ex.ToString)
        End Try
    End Sub
    Public Function CloseCurrentGame() As Boolean
        Dim button As DialogResult = MessageBox.Show("Are you sure you want to open a new game?  Anything currently not saved will be lost.",
        "Open a new game?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If button = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub ClearGame()
        gameLoaded = False
    End Sub
    Private Sub VerifyDirectory(foldername As String)
        ' /* Checks to see if a directory exists.  If not, one is created. */
        If (Not System.IO.Directory.Exists(foldername)) Then
            System.IO.Directory.CreateDirectory(foldername)
        End If
    End Sub
    ' =================================================== STATUS BAR SUBROUTINES ============================================================
    Private Sub tclExplorerMain_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles tclExplorerMain.Selecting
        mnuSaveFile.Text = "Save " & e.TabPage.Text
        stpSaveFile.ToolTipText = "Save " & e.TabPage.Text
    End Sub
    Public Sub Init_ColorIndex(format As String)
        ' // Reads <COLORINDEX> in WIMEDATA.XML file and stated values into colorindex object to be parsed later.
        Dim p_file As String = DATA_FILES
        Dim p_string As String = ""
        Dim xmlIndexRead As XmlTextReader
        Dim target_found As Boolean
        Dim fileend_flag As Boolean
        Dim p_settings As New XmlReaderSettings
        With p_settings
            .IgnoreWhitespace = True
            .IgnoreComments = True
        End With
        Dim p_slot As Int16 = 0
        Dim p_val As String = "" : Dim PAL_NAME As String = ""
        ColorIndex = New PaletteData.ColorList
        'MsgBox("Preparing to open " & p_file & " " & format)

        xmlIndexread = New XmlTextReader(p_file)
        xmlIndexRead.MoveToContent()
        Do While xmlIndexRead.Read
            xmlIndexRead.Read()
            If xmlIndexRead.Name = "FORMAT" Then
                p_string = xmlIndexRead.GetAttribute("ID")
                If p_string = format Then
                    'MsgBox(format & "Found!")
                    Do Until xmlIndexRead.Name = "COLORINDEX"
                        xmlIndexRead.Read()

                        If xmlIndexRead.EOF Then
                            MsgBox("COLORINDEX EOF!")

                            fileend_flag = True


                            Exit Do

                        End If

                    Loop
                    If fileend_flag = True Then
                        MsgBox("End Of File Reached! ColorIndex Not found!")
                    End If
                    xmlIndexRead.ReadToDescendant("COLOR")
                    ' MsgBox(xmlIndexRead.Name)
                    Do
                        'xmlIndexRead.MoveToAttribute("SLOT")
                        p_slot = xmlIndexRead.GetAttribute("SLOT")
                        'xmlIndexRead.MoveToAttribute("VALUE")
                        p_val = xmlIndexRead.GetAttribute("VALUE")
                        ' MsgBox("SLOT:       " & p_slot & vbTab & "Value: " & p_val)
                        ColorIndex.Add(p_slot, p_val)
                    Loop While xmlIndexRead.ReadToNextSibling("COLOR")








                End If

            End If

            If xmlIndexRead.EOF Then
                MsgBox("End of File!")
                Exit Do
            End If
        Loop






        'Using xmlIndexRead As XmlReader = XmlReader.Create(p_file, p_settings)
        '    xmlIndexRead.ReadToFollowing(format)
        '    MsgBox(format & " file found!" & p_file)

        '    xmlIndexRead.ReadToDescendant("COLORINDEX")
        '    xmlIndexRead.ReadToDescendant("COLOR")

        '    'MsgBox("Name: " & xmlIndexRead.ReadInnerXml)
        '    'xmlIndexRead.ReadToDescendant("COLOR")                  ' Then go to first COLOR element.
        '    MsgBox("Attibute Count: " & xmlIndexRead.Name & " " & xmlIndexRead.AttributeCount)
        '    Do
        '        xmlIndexRead.MoveToFirstAttribute()
        '        p_slot = xmlIndexRead.GetAttribute("SLOT")         ' Read and store slot attribute into temporary slot variable.
        '        'xmlIndexRead.MoveToNextAttribute()
        '        p_val = xmlIndexRead.GetAttribute("VALUE")         ' Read and store slot attribute into temporary value variable.
        '        MsgBox("SLOT:       " & p_slot & vbTab & "Value: " & p_val)
        '        ColorIndex.Add(p_slot, p_val)               ' Add object for color slot and value of entry.
        '    Loop While xmlIndexRead.ReadToNextSibling("COLOR")     ' Loop to next element until no more elements.

        'End Using
        'For x = 0 To ColorIndex.Count - 1
        '    MsgBox(ColorIndex.item(x).Slot & " " & ColorIndex.item(x).ColorValue)
        'Next
        'MsgBox("Color Index Initialized!")




    End Sub
    Public Function CreateTile(loopnum As Integer) As Game.resource.ResourceDetails
        '// * POPULATE RESOURCE LIST WITH TILEDATA
        Dim p_TilePointer As Integer = loadedSettings.tileOffset + 1
        Dim p_TileResource As New Game.resource.ResourceDetails
        Dim p_resourcefile As String = Path.GetFileNameWithoutExtension(loadedTile.filename)
        p_TileResource.Name = Game.resource.CHAR_ID & HexByte2Char(loopnum)
        p_TileResource.resourceType = Game.resource.CHAR_ID
        p_TileResource.Number = loopnum
        p_TileResource.dataSize = 256
        p_TileResource.resourceFile = p_resourcefile
        p_TileResource.fileOffset = (p_TilePointer + (256 * loopnum))
        Return p_TileResource
    End Function
    ' *** RESOURCE TAB EVENT HANDLERS ***
    Public Sub GameLoadedStatusChange()
        If gameLoaded = True Then
            stpSaveFile.Enabled = True
            mnuSaveFile.Enabled = True
            'stpCopyProtection.Enabled = True
        ElseIf gameLoaded = False Then
            stpSaveFile.Enabled = False
            mnuSaveFile.Enabled = False
            'stpCopyProtection.Enabled = False
        End If
    End Sub
    ' ******************************************** EVENT HANDLERS FOR MENU AND TOOLSTRIPS **************************************************************************
    ' =============================================== MENU ITEMS ==============================================================
    Private Sub stpOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stpOpenFile.Click
        OpenWIMEGame()
    End Sub
    Private Sub AboutTheWIMESavegameEditorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim aForm As New WIMESplashScreen
        aForm = WIMESplashScreen
        aForm.Show()
    End Sub
    '=================================================== TOOL STRIP ITEMS ===========================================================
    Private Sub stpSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stpSaveFile.Click
        frmArcView.SaveCharacter()
        frmArcView.RefreshSaveStatus()
        MsgBox("Saved!")
    End Sub
    Private Sub stpSettingsPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stpProgramSettings.Click
        Dim Form5 As New frmProgramSettings
        frmProgramSettings.Show()
    End Sub
    Private Sub resTabControl_CloseButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Select Case tabctrl.SelectedTab.Name
            Case "frmArcView"
                frmArcView.CheckSaveResults()
            Case Else
        End Select
    End Sub
    Private Sub AboutTheWIMESavegameEditorToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AboutTheWIMESavegameEditorToolStripMenuItem.Click
        Dim af As New AboutBox1
        af = AboutBox1
        af.Show()
    End Sub
    Sub closeGame()
        gameLoaded = False
        tabctrl.TabPages.Clear()
        tabctrl.Hide()
        gameLoaded = False
    End Sub
    Private Sub stpCopyProtection_Click(sender As Object, e As EventArgs) Handles stpCopyProtection.Click
        Dim p_form As New Form
        p_form = frmCoordinates
        p_form.Show()
    End Sub
End Class


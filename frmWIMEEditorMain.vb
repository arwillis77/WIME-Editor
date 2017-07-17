'Option Explicit On
'Option Strict On
Imports System
Imports System.IO
Imports System.Xml
Public Class frmWIMEEditorMain
    'Public saveBinaryIn As New BinaryReader(New FileStream(strFilename, FileMode.OpenOrCreate, FileAccess.Read))
    'Public saveBinaryIn As BinaryReader
    'Public readStream As FileStream
    ' *** frmWIMEEditorMaiin ***
    ' Form for the Main Editor
    Dim strFirstTime As String
    Dim blnProgramLoaded As Boolean = False
    Dim intMapSize As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setFileFormats()
        frmOverview.TopMost = False
        If File.Exists("WIMEConfig.xml") Then           ' If there is a config file, then open the savegame file from the config
            OpenSaveGameFile()
        Else
            SaveGameFileDialog()
            WIMEAppSettings.applicationDirectory = System.Environment.CurrentDirectory
            WIMEAppSettings.dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            WIMEAppSettings.WIMEDirectory = System.IO.Path.GetDirectoryName(strFilename)
            WIMEAppSettings.savegameFilename = strFilename
            WIMEAppSettings.savegameFileFormat = WIMESaveGameFileFormat
            WIMEAppSettings.mapTilesize = 16
            WriteXMLConfig()                    ' Writes data to the XML config file.
        End If
        SplitContainer1.SplitterDistance = 300
        Me.WindowState = FormWindowState.Maximized
        OpenWIMEConfig()
        Call ReadSaveGameFile()                 ' Call subroutine to read the savegame file
        Call ProcessSaveGameData()              ' Call subroutine to process the savegame file
        OpenWIMEConfig()
        Call WriteSaveGameDatabase()            ' Call subroutine to write the data to a tab delimited file
        Dim intCurrentFillRecord As Integer = 0
        Call FillOverViewList()
        frmOverview.TopLevel = False
        SplitContainer1.Panel2.Controls.Add(frmOverview)
        frmOverview.Show()
        RemoveHandler txtCurrentChar.TextChanged, AddressOf txtCurrentChar_TextChanged
        txtCurrentChar.Text = "Character " & intCurrentCharacter & " of 194"
        AddHandler txtCurrentChar.TextChanged, AddressOf txtCurrentChar_TextChanged
        blnProgramLoaded = True
    End Sub
    ' ============================ OPEN SAVEGAME FILE SUBROUTINE ==========================================================================
    Public Sub OpenSaveGameFile()
        '   *************** OpenSaveGameFile Subroutine *******************
        '   Opens the config file to automatically load savegame file name 
        '   stored upon startup if config file exists.
        '   ***************************************************************
        OpenWIMEConfig()
        If WIMEAppReadSettings.savegameFilename = "" Then Call SaveGameFileDialog()
        If WIMEAppReadSettings.WIMEDirectory = "" Then Call SaveGameFileDialog()
        'FileClose(1)
        'FileOpen(1, WIMEAppReadSettings.savegameFilename, OpenMode.Binary)       ' Opens savegame file using data read and interpreted from XML config.
        readStream = New FileStream(WIMEAppReadSettings.savegameFilename, FileMode.Open)
        Call SaveGameHeaderCheck()
        UpdateFormat()
    End Sub
    Public Sub SaveGameFileDialog()
        ' =============================== SAVEGAMEFILEDIALOG SUB ======================================================================
        ' Contains subroutine handling dialog box called when user wants to open a savegame file.
        ' =============================================================================================================================
        Dim BOMbigEndian As New System.Text.UnicodeEncoding(True, True)
        Dim BOMlittleEndian As New System.Text.UnicodeEncoding(False, True)
        OpenFD.Title = "Select the Savegame File to Edit"
        OpenFD.Filter = "WIME Save Game|*.dat|All Files|*.*"
        OpenFD.RestoreDirectory = False
        OpenFD.ShowDialog()
        strFilename = OpenFD.FileName
        readStream = New FileStream(strFilename, FileMode.Open)
        Call SaveGameHeaderCheck()
        WIMEAppSettings.applicationDirectory = System.Environment.CurrentDirectory
        WIMEAppSettings.dataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        WIMEAppSettings.WIMEDirectory = System.IO.Path.GetDirectoryName(strFilename)
        WIMEAppSettings.savegameFilename = strFilename
        WIMEAppSettings.savegameFileFormat = currentFileFormat.formatID
        WIMEAppSettings.resourceAMAPFilename = currentFileFormat.mapResourceFilename
        WIMEAppSettings.mapTilesize = 16
        WIMEAppSettings.resourceTileFilename = currentFileFormat.tileResourceFilename
        WriteXMLConfig()
        OpenWIMEConfig()
        UpdateFormat()
        If blnProgramLoaded = True Then
            OpenWIMEConfig()
            Call ReadSaveGameFile()                 ' Call subroutine to read the savegame file
            Call ProcessSaveGameData()              ' Call subroutine to process the savegame file
            Call WriteSaveGameDatabase()            ' Call subroutine to write the data to a tab delimited file
            strFirstTime = ""
            Call FillOverViewList()
            lvwCharacterOverview.Show()
            lvwCharacterOverview.Refresh()
            frmOverview.TopLevel = False
            SplitContainer1.Panel2.Controls.Add(frmOverview)
            frmOverview.Show()
            txtCurrentChar.Text = "Character " & intCurrentCharacter & " of 194"
            WriteXMLConfig()
            UpdateFormat()
        End If
    End Sub
    Public Sub SaveGameHeaderCheck()
        Dim saveHeaderCheck As Integer
        ' ========================================= SAVEGAMEHEADERCHECK SUB =========================================================
        ' Subroutine which checks the header of a file opened through the savegame dialog box to ensure it is the proper file.
        ' ===========================================================================================================================
        Dim readBinary As New BinaryReader(readStream)
        Dim skint As Int64
        Dim skbyte As Byte
        saveHeaderCheck = readBinary.ReadInt32
        For j As Integer = 0 To 3
            skint = readBinary.ReadInt64
        Next j
        skbyte = readBinary.ReadByte
        chRead.characterValue(0) = readBinary.ReadInt16
        Select Case Hex$(saveHeaderCheck)
            Case fileFormatPC.saveHeaderCheckByte
                currentFileFormat = fileFormatPC
            Case fileFormatIIGS.saveHeaderCheckByte
                currentFileFormat = fileFormatIIGS
            Case fileFormatAMIGA.saveHeaderCheckByte
                currentFileFormat = fileFormatAMIGA
            Case Else
                WIMESaveGameFileFormat = "UNKNOWN"
                MsgBox("Invalid Savegame File.  Please select another file!")
                Call SaveGameFileDialog()
        End Select
        readBinary.Close()
        FillXML()
        WIMEAppSettings.resourceAMAPFilename = currentFileFormat.mapResourceFilename
        WIMEAppSettings.savegameFileFormat = currentFileFormat.formatID
        WriteXMLConfig()
    End Sub
    Public Sub SaveGameOpenRoutines()
        Call frmOverview.SaveFormCheck()
        frmOverview.Close()
        lvwCharacterOverview.Clear()
        lvwCharacterOverview.Hide()
        SaveGameFileDialog()
        'OpenSaveGameFile()
        OpenWIMEConfig()
        Call ReadSaveGameFile()                 ' Call subroutine to read the savegame file
        Call ProcessSaveGameData()              ' Call subroutine to process the savegame file
        Call WriteSaveGameDatabase()            ' Call subroutine to write the data to a tab delimited file
        strFirstTime = ""
        Call FillOverViewList()
        lvwCharacterOverview.Show()
        lvwCharacterOverview.Refresh()
        frmOverview.TopLevel = False
        SplitContainer1.Panel2.Controls.Add(frmOverview)
        frmOverview.Show()
        txtCurrentChar.Text = "Character " & intCurrentCharacter & " of 194"
        WriteXMLConfig()
        UpdateFormat()
    End Sub
    ' ========================================== MENU ITEMS ======================================================================
    Private Sub mnuPCOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPCOpen.Click
        WIMESaveGameFileFormat = fileFormatPC.formatID
        Call SaveGameOpenRoutines()
    End Sub
    Private Sub mnuIIGSOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuIIGSOpen.Click
        WIMESaveGameFileFormat = fileFormatIIGS.formatID
        Call SaveGameOpenRoutines()
    End Sub
    Private Sub Amiga16bitDefaultStartToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Amiga16bitDefaultStartToolStripMenuItem.Click
        WIMESaveGameFileFormat = fileFormatAMIGA.formatID
        Call SaveGameOpenRoutines()
    End Sub
    Private Sub Amiga16bitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles Amiga16bitToolStripMenuItem.Click
        WIMESaveGameFileFormat = fileFormatAMIGA.formatID
        Call SaveGameOpenRoutines()
    End Sub
    Private Sub mnuProgramOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProgramOptions.Click
        Dim Form5 As New frmProgramSettings
        frmProgramSettings.Show()
    End Sub
    Private Sub mnuExitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExitProgram.Click
        FileClose()
        Close()
        End
    End Sub
    Private Sub mnuMapView(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmAmapViewer.Show()
    End Sub
    Private Sub mnuCopyProtection(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyProtectionCodesToolStripMenuItem.Click
        frmCoordinates.Show()
    End Sub
    Private Sub mnuSaveDataOverview(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveGameOverview.Click
        frmSaveSummary.Show()
    End Sub
    '=================================================== TOOL STRIP ITEMS ===========================================================
    Private Sub stpOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stpOpenFile.Click
        SaveGameFileDialog()
    End Sub
    Private Sub stpSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stpSaveFile.Click
        frmOverview.WriteSaveGameFile(intCurrentFillRecord)
        isDataSaved = True
        frmOverview.StatusBarUpdate()
        MsgBox("Saved!")
    End Sub
    Private Sub mnuCloseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCloseFile.Click
        CloseSGFile()
        frmOverview.Close()
    End Sub
    Private Sub stpSettingsPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stpProgramSettings.Click
        Dim Form5 As New frmProgramSettings
        frmProgramSettings.Show()
    End Sub
    Private Sub FillOverViewList()
        ' ****************** FILL OVERVIEWLIST SUBROUTINE *********************************
        If strFirstTime = "" Then                       ' Check string and if empty, then run as it will indicate first time
            ' Fill Listview for Character Overview
            lvwCharacterOverview.Show()
            lvwCharacterOverview.Columns.Clear()
            lvwCharacterOverview.View = View.Details
            lvwCharacterOverview.FullRowSelect = True
            lvwCharacterOverview.HideSelection = False
            lvwCharacterOverview.Columns.Add("Number", 50)
            lvwCharacterOverview.Columns.Add("Character/Army Name", 140)
            lvwCharacterOverview.Columns.Add("File Offset", 60)
            lvwCharacterOverview.Height = SplitContainer1.Panel1.Height - 20
            lvwCharacterOverview.Width = 272
            intCNum(0) = 0
            For intFormFill As Integer = 1 To characterEntryMax
                intCNum(intFormFill) = Str(intFormFill)
                Dim lv As ListViewItem = lvwCharacterOverview.Items.Add(intCNum(intFormFill))
                'The remaining columns are subitems  
                lv.SubItems.Add(chRead.strArmyName(intFormFill))
                lv.SubItems.Add(Hex$(chRead.intFileStart(intFormFill)) & "h")
            Next
            For intFormFill As Integer = 1 To characterEntryMax
                If Val(chRead.valueMobilize(intFormFill)) = 99 Then
                    lvwCharacterOverview.Items(intFormFill - 1).ForeColor = Color.Blue
                End If
                If Val(chRead.valueMobilize(intFormFill)) = 1 Then
                    lvwCharacterOverview.Items(intFormFill - 1).ForeColor = Color.Blue
                End If
                If Val(chRead.valueMobilize(intFormFill)) = 0 Then
                    lvwCharacterOverview.Items(intFormFill - 1).ForeColor = Color.Red
                End If
            Next
            strFirstTime = "NO"                         ' Add value to the first time string to prevent filling after every form change.
        Else
        End If
    End Sub
    Public Sub lvwCharacterOverview_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwCharacterOverview.DoubleClick
        Dim objDrawingPoint As Drawing.Point
        Dim objListViewItem As ListViewItem
        objDrawingPoint = lvwCharacterOverview.PointToClient(Cursor.Position)
        If Not IsNothing(objDrawingPoint) Then
            With objDrawingPoint
                objListViewItem = lvwCharacterOverview.GetItemAt(.X, .Y)
            End With
            If Not IsNothing(objListViewItem) Then
                intCurrentCharacter = objListViewItem.Text
                txtCurrentChar.Text = "Character " & intCurrentCharacter & " of " & characterEntryMax
            End If
        End If
    End Sub
    ' =================================================== STATUS BAR SUBROUTINES ============================================================
    Public Sub txtCurrentChar_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCurrentChar.TextChanged
        If isDataSaved = False Then
            frmOverview.SaveFormCheck()
        End If
        frmOverview.ReloadCharacterForm()
    End Sub
    Public Sub UpdateFormat()
        If WIMEAppReadSettings.savegameFileFormat = fileFormatPC.formatID Then
            stpFileFormat.Text = fileFormatPC.formatDescription
            stpFileFormat.Image = fileFormatPC.FileIcon
        End If
        If WIMEAppReadSettings.savegameFileFormat = fileFormatIIGS.formatID Then
            stpFileFormat.Text = fileFormatIIGS.formatDescription
            stpFileFormat.Image = fileFormatIIGS.FileIcon
        End If
    End Sub
    Private Sub ResourceViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call frmResourceView.Show()
    End Sub
    Private Sub CityEditorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CityEditor.Click
        frmOverview.Hide()
        Dim oForm As frmCityEditor
        oForm = New frmCityEditor
        oForm.Show()
        oForm = Nothing
        frmOverview.Show()
    End Sub
    Private Sub WIMEAMAPResourceViewerToolStripMenuItem_Click(sender As Object, e As System.EventArgs) Handles TileView.Click
        frmAmapViewer.Show()
    End Sub
    Private Sub wimeMap3XSize_Click(sender As System.Object, e As System.EventArgs) Handles wimeMap3XSize.Click
        OpenWIMEConfig()
        FillXML()
        WIMEAppSettings.mapTilesize = 48
        WriteXMLConfig()
        Dim oForm As New frmNewMap
        oForm = frmNewMap
        oForm.Show()
    End Sub
    Private Sub wimeMapOriginalSize_Click(sender As System.Object, e As System.EventArgs) Handles wimeMapOriginalSize.Click
        OpenWIMEConfig()
        FillXML()
        WIMEAppSettings.mapTilesize = 16
        WriteXMLConfig()
        Dim oForm As New frmNewMap
        oForm = frmNewMap
        oForm.Show()
    End Sub
    Private Sub WorldBuilderToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim wForm As New frmWorldBuilder
        wForm = frmWorldBuilder
        wForm.Show()
    End Sub
    Private Sub WIMEMap2XSizeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WIMEMap2XSizeToolStripMenuItem.Click
        OpenWIMEConfig()
        FillXML()
        WIMEAppSettings.mapTilesize = 32
        WriteXMLConfig()
        Dim oForm As New frmNewMap
        oForm = frmNewMap
        oForm.Show()
    End Sub
    Private Sub ScrollerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim sForm As New frmScroll
        sForm = frmScroll
        sForm.Show()
    End Sub

    Private Sub AboutTheWIMESavegameEditorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutTheWIMESavegameEditorToolStripMenuItem.Click
        Dim aForm As New WIMESplashScreen
        aForm = WIMESplashScreen
        aForm.Show()
    End Sub

    Private Sub IBMPC16bitDefaultStartToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles IBMPC16bitDefaultStartToolStripMenuItem.Click
        WIMESaveGameFileFormat = fileFormatPC.formatID
        Call SaveGameOpenRoutines()
    End Sub
End Class

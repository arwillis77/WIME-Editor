Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports WIMEEditor.Game
Imports WIMEEditor.EditorSettings
Public Class frmCityEditor
    Dim intCurrentCity As Integer = 0
    Dim intTempCharNum As Integer
    Dim intNewCityNum As Integer
    Dim intIconPointer As Integer
    Dim strExtractorPath As String
    Dim cityImages As ImageList = New ImageList()
    Dim sclass As New Archive
    Dim intFileLoc As Integer
    Private Sub frmCityEditor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        loadedSettings = loadConfig(settingsFullFilename)
        'LocationImageList = New ImageList
        Dim tempchardata As New Game.Archive.chunkStrings
        'tempCharData = archiveCharacterArray(currentCharacter)
        strExtractorPath = loadedSettings.wimeDIRECTORY & "\TILES\TILE48\"
        lvwCityList.Show()
        CityListFill()
        lvwCityList.Refresh()
        RemoveHandler txtLocationName.TextChanged, AddressOf txtLocationName_TextChanged
        txtLocationName.Text = Game.Executable.CityData(intCurrentCity).cityName
        txtLocationX.Text = CityData(intCurrentCity).xCoordinate
        txtLocationY.Text = CityData(intCurrentCity).yCoordinate
        ArmyListFill()
        cboLocationMove.Items.Clear()
        For intMoveFill As Integer = 0 To 68
            cboLocationMove.Items.Add(WIMECityDBData.cityName(intMoveFill))
            'If cboLocation.Text = (WimeCityDBData.cityName(intMoveFill)) Then
            cboLocationMove.SelectedItem = cboLocationMove.Items(intMoveFill)
            'End If
        Next intMoveFill
        editorMapTileSize = 48
        Dim oForm2 As frmExportTile
        oForm2 = New frmExportTile
        oForm2.Show()
        oForm2.Dispose()
        oForm2 = Nothing
        LocationTileExtractor(strExtractorPath)
        MsgBox(intCurrentCity)
        CityIconFill(intCurrentCity)
        AddHandler txtLocationName.TextChanged, AddressOf txtLocationName_TextChanged

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub CityIconFill(currentCity As Integer)
        intIconPointer = Val(WimeCityData.cityIcon(currentCity))
        pctLocationIcon.Image = cityImages.Images(intIconPointer)
    End Sub
    Private Sub ArmyListFill()
        lvwArmyList.Columns.Clear()
        lvwArmyList.Items.Clear()
        lvwArmyList.View = View.Details
        lvwArmyList.GridLines = True
        lvwArmyList.FullRowSelect = True
        lvwArmyList.HideSelection = False
        lvwArmyList.MultiSelect = False
        lvwArmyList.Columns.Add("Number", 50)
        lvwArmyList.Columns.Add("Character/Army", 125)
        lvwArmyList.Columns.Add("QTY", 50)
        For intArmyFill As Integer = 0 To CHARACTER_MAX
            If archiveCharacterArray(intArmyFill).locationX = CityData(intCurrentCity).xCoordinate And archiveCharacterArray(intArmyFill).locationY = CityData(intCurrentCity).yCoordinate Then
                intTempCharNum = intArmyFill + 1
                intCNum(intArmyFill) = intTempCharNum
                Dim lva As ListViewItem = lvwArmyList.Items.Add(intCNum(intArmyFill))
                'The remaining columns are subitems  
                lva.SubItems.Add(currentCharData.characterName(intArmyFill))
                lva.SubItems.Add(archiveCharacterArray(intArmyFill).armyQuantity)
                For intFollowingFill As Integer = 0 To CHARACTER_MAX
                    If intCNum(intArmyFill) = characterData.characterFollowvalue(intFollowingFill) Then
                        Dim lvb As ListViewItem = lvwArmyList.Items.Add(intCNum(intFollowingFill))
                        'The remaining columns are subitems  
                        lvb.SubItems.Add(currentCharData.characterName(intFollowingFill))
                        lvb.SubItems.Add(archiveCharacterArray(intFollowingFill).armyQuantity)
                        lvb.ForeColor = Color.Blue
                    End If
                Next
            End If
        Next
    End Sub
    Private Sub CityListFill()
        ' Fill Listview for Locations
        lvwCityList.Show()
        lvwCityList.Columns.Clear()
        lvwCityList.View = View.Details
        lvwCityList.GridLines = True
        lvwCityList.FullRowSelect = True
        lvwCityList.HideSelection = False
        'lvwCharacterOverview.MultiSelect = True
        lvwCityList.Columns.Add("CITY", 140)
        lvwCityList.Columns.Add("X AXIS", 46)
        lvwCityList.Columns.Add("Y AXIS", 46)
        'strCharacterName(0) = "NONE"
        lvwCityList.Width = 255
        For intFormFill As Integer = 0 To 68
            Dim lvc As ListViewItem = lvwCityList.Items.Add(CityData(intFormFill).cityName)
            'The remaining columns are subitems  
            lvc.SubItems.Add(CityData(intFormFill).xCoordinate)
            lvc.SubItems.Add(CityData(intFormFill).xCoordinate)
        Next
    End Sub
    Private Sub lvwCityList_DoubleClick(sender As Object, e As System.EventArgs) Handles lvwCityList.DoubleClick
        Dim objDrawingPoint2 As Drawing.Point
        Dim objListViewItem2 As ListViewItem
        objDrawingPoint2 = lvwCityList.PointToClient(Cursor.Position)
        If Not IsNothing(objDrawingPoint2) Then
            With objDrawingPoint2
                objListViewItem2 = lvwCityList.GetItemAt(.X, .Y)
            End With

            If Not IsNothing(objListViewItem2) Then
                txtLocationName.Text = objListViewItem2.Text
            End If
        End If
    End Sub
    Private Sub LocationTileExtractor(tileDirectory As String)
        Dim arFiles As String() = {"WIMETile1D.PNG", "WIMETile1D.PNG", "WIMETile3E.PNG", "WIMETile4F.PNG", "WIMETile2E.PNG", "WIMETile4E.PNG", "WIMETile3C.PNG",
                                   "WIMETile0B.PNG", "WIMETile2D.PNG", "WIMETileF2.PNG", "WIMETileAE.PNG", "WIMETileFD.PNG", "WIMETile67.PNG", "WIMETile8E.PNG",
                                   "WIMETile0A.PNG", "WIMETile5E.PNG", "WIMETile47.PNG", "WIMETileAC.PNG", "WIMETileDE.PNG", "WIMETile1A.PNG", "WIMETile37.PNG",
                                   "WIMETileBC.PNG", "WIMETile7D.PNG", "WIMETile90.PNG", "WIMETile0E.PNG", "WIMETile81.PNG", "WIMETile8D.PNG", "WIMETile9D.PNG",
                                   "WIMETileCB.PNG", "WIMETile6D.PNG", "WIMETile0C.PNG", "WIMETile82.PNG", "WIMETile1C.PNG", "WIMETile72.PNG", "WIMETileF5.PNG",
                                   "WIMETile69.PNG", "WIMETile21.PNG", "WIMETileFC.PNG", "WIMETile27.PNG", "WIMETileE5.PNG", "WIMETile3B.PNG", "WIMETile9F.PNG",
                                   "WIMETile0D.PNG", "WIMETileE7.PNG", "WIMETile3D.PNG", "WIMETile2C.PNG", "WIMETile4D.PNG", "WIMETile5D.PNG", "WIMETile2B.PNG"}
        cityImages.ColorDepth = ColorDepth.Depth32Bit
        cityImages.ImageSize = New Size(48, 48)
        For tt = 0 To 48
            cityImages.Images.Add(Image.FromFile(tileDirectory & arFiles(tt)))
        Next tt
    End Sub
    Private Sub txtLocationName_TextChanged(sender As Object, e As System.EventArgs) Handles txtLocationName.TextChanged
        For r As Integer = 0 To 68
            If txtLocationName.Text = WIMECityData.cityName(r) Then
                intCurrentCity = r
                txtLocationX.Text = CityData(intCurrentCity).xCoordinate
                txtLocationY.Text = CityData(intCurrentCity).yCoordinate
                ArmyListFill()
                CityIconFill(intCurrentCity)
            End If
        Next
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnMove.Click
        Dim intItemNum As Integer
        Dim strLocFind As String
        'MsgBox(lvwArmyList.SelectedItems(0).Text)
        ' PREPARE TILES
        'frmExportTile48.Show()
        'frmExportTile48.Hide()

        intItemNum = (Val(lvwArmyList.SelectedItems(0).Text) - 1)

        If Not characterData.characterFollowvalue(intItemNum) = 0 Then
            MsgBox(currentCharData.characterName(intItemNum) & " is following character number " & characterData.characterFollowvalue(intItemNum) & " and cannot be moved.")
        End If
        For intLocChange As Integer = 0 To 68
            strLocFind = cboLocationMove.SelectedItem
            If strLocFind = WIMECityDBData.cityName(intLocChange) Then
                'chWrite.locationX(intItemNum) = WIMECityDBData.cityXValue(intLocChange)
                'chWrite.locationY(intItemNum) = WIMECityDBData.cityYValue(intLocChange)
            End If
        Next intLocChange
        intFileLoc = (46) + (37 * intItemNum)
        'FilePut(1, chWrite.locationX(intItemNum), intFileLoc)
        intFileLoc = (48) + (37 * intItemNum)
        'FilePut(1, chWrite.locationY(intItemNum), intFileLoc)
        charOverview.readFile()
        setData()
        processFile()
        ArmyListFill()
        CityIconFill(intCurrentCity)
    End Sub
End Class
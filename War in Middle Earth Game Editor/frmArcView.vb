Imports WIMEEditor.Sprite
Imports WIMEEditor.EditorSettings
Imports System.IO
Imports WIMEEditor.Game
Imports WIMEEditor.GameData
Public Class frmArcView
    '// Declare Variables
    Public SpriteCurrentLoop As Integer = 0
    Public spriteCurCel As Integer = 0
    Private EventsOn As Boolean
    Public surface As Bitmap
    Public pbAnimate As PictureBox
    Public mapindex As Integer = 0
    Public xPos As Integer = 0 : Public yPos As Integer = 0
    Dim yOffset As Integer = 0
    Public isDataSaved As Boolean = True
    Public Shared currentCharacter As Integer
    '// Declare Objects
    Public currentSprite As New Data
    Public WIMEObjects As List(Of GenericCharacterObject)
    Public TransferObjects As List(Of GenericCharacterObject)
    Dim selectedCharacter As Archive.Character
    Public SIZE_MULTIPLIER As Integer = 2
    Dim myBA As BitArray
    Private Sub frmArcView_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            myBA = Nothing
            myBA = New BitArray(15)
            ARCHIVE_FILE = LoadedSettings.wimeDIRECTORY & "\" & Archive.FILENAME
            SetupFormData()
            currentCharacter = SelectedResourceItem.Number
            FillArcForm()                         ' Call subroutine to fill the remainder of the form.
            isDataSaved = True
        Catch ex As Exception
            MsgBox("PROGRAM ERROR.  LOCATION frmArcView_LOAD.  " & vbLf & vbLf & ex.ToString)
        End Try
    End Sub
    Public Sub New()
        ' This call is required by the designer.
        EventsOn = False
        InitializeComponent()
        'RemoveHandler cboSpriteColor.SelectedIndexChanged, AddressOf cboSpriteColor_SelectedIndexChanged
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub SetupFormData()
        cboCharacterFollow.Items.Clear()
        cboCharacterFollow.Items.Add("NONE")
        For intTempFollowCounter As Integer = 0 To ArmyFollow.Count - 1
            cboCharacterFollow.Items.Add(ArmyFollow(intTempFollowCounter).Name)
        Next intTempFollowCounter
        ' *** FILL MOBILIZATION COMBO BOX ***
        cboMobilized.Items.Clear()
        For intTempMobCounter As Integer = 0 To Mobilized.Count - 1
            cboMobilized.Items.Add(Mobilized(intTempMobCounter).Name)
        Next intTempMobCounter
        ' *** Set Bounds for numeric boxes.
        nbrMorale.Maximum = 9
        nbrMoraleTotal.Maximum = 9
        nbrArmyQTY.Maximum = USHORT_MAX
        nbrArmyTotal.Maximum = USHORT_MAX
        nbrHitPoints.Maximum = UBYTE_MAX
        nbrHitTotal.Maximum = UBYTE_MAX
        nbrPower.Maximum = 3
        nbrStealth.Maximum = UBYTE_MAX
        ' *** Fill Info for Character Location
        cboLocation.Items.Clear()
        cboLocation.Items.Add(Default_City)
        For intLocFill As Integer = 0 To CityGroup.Count - 1
            cboLocation.Items.Add(CityGroup(intLocFill).Name)
        Next intLocFill
        ' *** Fill Info for Character Destination ***
        cboDestination.Items.Clear()
        cboDestination.Items.Add(Default_City)
        For intDestFill As Integer = 0 To CityGroup.Count - 1
            cboDestination.Items.Add(CityGroup(intDestFill).Name)
        Next intDestFill
        ' *** FILL FOLLOW DROP BOX ***
        lvwCharacterFollow.Columns.Clear() : lvwCharacterFollow.Items.Clear()
        lvwCharacterFollow.View = View.Details
        lvwCharacterFollow.GridLines = True : lvwCharacterFollow.FullRowSelect = True
        lvwCharacterFollow.HideSelection = False : lvwCharacterFollow.MultiSelect = False
        lvwCharacterFollow.Columns.Add("Number", 50) : lvwCharacterFollow.Columns.Add("Character/Army", 125) : lvwCharacterFollow.Columns.Add("QTY", 50)
        lstObjectInventory.Items.Clear()
    End Sub
    Private Sub frmArcView_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CheckSaveResults()
    End Sub
    Private Sub frmArcView_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CheckSaveResults()
    End Sub
    ' ======================================================================= SUB-PROCEDURES ===============================================================================
    Public Sub FillArcForm()
        ' ******************************** FILL CHARACTER OVERVIEW FORM *******************************************************
        Dim p_characterNumber As Integer
        selectedCharacter = New Archive.Character : selectedCharacter = archiveCharacterArray(currentCharacter)
        If currentCharacter > CHARACTER_MAX Then currentCharacter = CHARACTER_MAX
        If currentCharacter < 0 Then currentCharacter = 0
        ' ********* FILL FORM FIELDS WITH DATA *******************************************
        txtArmyName.Text = selectedCharacter.CharacterName
        For a As Integer = 0 To ArmyFollow.Count - 1
            If selectedCharacter.valueLeaderFollow = 0 Then
                cboCharacterFollow.SelectedItem = cboCharacterFollow.Items.Item(0)
                Exit For
            ElseIf selectedCharacter.valueLeaderFollow = ArmyFollow(a).Value Then
                cboCharacterFollow.SelectedItem = ArmyFollow(a).Name
            End If
        Next
        For i As Integer = 0 To Mobilized.Count - 1
            If selectedCharacter.valueMobilize = Mobilized(i).Value Then
                cboMobilized.SelectedText = Mobilized(i).Name
            End If
        Next i
        nbrArmyQTY.Text = selectedCharacter.armyQuantity
        nbrArmyTotal.Text = selectedCharacter.armyTotal
        nbrHitTotal.Text = selectedCharacter.hpTotal
        nbrHitPoints.Text = selectedCharacter.hpCurrent
        nbrPower.Text = selectedCharacter.powerLevel
        nbrStealth.Value = selectedCharacter.Stealth
        txtLocationX.Text = selectedCharacter.locationX
        txtLocationY.Text = selectedCharacter.locationY
        For x As Integer = 0 To CityGroup.Count - 1
            If selectedCharacter.locationX = CityGroup(x).X AndAlso selectedCharacter.locationY = CityGroup(x).Y Then
                cboLocation.SelectedItem = cboLocation.Items.Item(x + 1)
                Exit For
            End If
        Next x
        If IsNothing(cboLocation.SelectedItem) Then
            cboLocation.SelectedItem = cboLocation.Items.Item(0)
        End If
        txtDestinationX.Text = selectedCharacter.destinationX
        txtDestinationY.Text = selectedCharacter.destinationY
        For x As Integer = 0 To CityGroup.Count - 1
            If selectedCharacter.destinationX = CityGroup(x).X AndAlso selectedCharacter.destinationY = CityGroup(x).Y Then
                cboDestination.SelectedItem = cboDestination.Items.Item(x + 1)
            End If
        Next x
        If IsNothing(cboDestination.SelectedItem) Then
            cboDestination.SelectedItem = cboDestination.Items.Item(0)
        End If
        nbrMorale.Text = selectedCharacter.moraleQuantity
        nbrMoraleTotal.Text = selectedCharacter.moraleTotal
        LoadObjects()
        If selectedCharacter.Visibility = 0 Then
            chkVisible.Checked = False
        Else
            chkVisible.Checked = True
        End If
        ' Fill Listview for Character that Follow Selected Character
        ' Fill Listview for Character Overview
        Dim tempFollowValue As Integer
        Dim charnum As Integer = currentCharacter + 1
        Dim curCharVal As Integer = 0
        For h As Integer = 0 To ArmyFollow.Count - 1
            If charnum = ArmyFollow(h).Value Then
                curCharVal = ArmyFollow(h).Value
                Exit For
            End If
        Next
        Dim tempCharData As Archive.Character
        For followRecordnum As Integer = 0 To CHARACTER_MAX
            tempCharData = archiveCharacterArray(followRecordnum)
            If curCharVal = 0 Then Exit For
            tempFollowValue = tempCharData.valueLeaderFollow
            If tempFollowValue = curCharVal Then
                p_characterNumber = followRecordnum
                intCNum(followRecordnum) = p_characterNumber
                Dim lv As ListViewItem = lvwCharacterFollow.Items.Add(intCNum(followRecordnum))
                'The remaining columns are subitems  
                lv.SubItems.Add(CharacterEXE(followRecordnum).Name)
                lv.SubItems.Add(tempCharData.armyQuantity)
            End If
        Next followRecordnum
        txtByte3.Text = selectedCharacter.unknownBlock
        txtByte24.Text = selectedCharacter.byte24
        txtByte31.Text = selectedCharacter.byte31
        txtByte32.Text = selectedCharacter.byte32
        txtByte33.Text = selectedCharacter.byte33
        txtByte37.Text = selectedCharacter.byte37
        txtInventory.Text = selectedCharacter.gameObjects
        ' ======= SPRITE VIEW =========================
        ' === Set Form Variables ===
        'resourceIndex = 0
        DisplaySprite()
        ' *************** MAPICONS *****************************************
        For h As Integer = 0 To BANNERICON_VALUES.Length - 1
            If selectedCharacter.mapIcon = BANNERICON_VALUES(h) Then
                pbMapIcon.Image = MapIcons.Images(h)
                mapindex = h
            End If
        Next h
        curCharData = archiveCharacterArray(currentCharacter)
        'AddHandler cboSpriteColor.SelectedIndexChanged, AddressOf cboSpriteColor_SelectedIndexChanged
        EventsOn = True
    End Sub
    Public Sub SaveCharacter()
        Try
            Dim tempBlockLength As Integer
            Dim filename As String
            Dim arcDir As String
            Dim writestream As FileStream
            Dim p_endian As UShort
            LoadedSettings = LoadConfig(settingsFullFilename)
            p_endian = LoadedFile.Endian
            tempBlockLength = GetSavegameBlockLength(p_endian)
            arcDir = LoadedSettings.wimeDIRECTORY
            filename = ARCHIVE_FILE
            writestream = New FileStream(filename, FileMode.Open)
            Dim writebinary As New BinaryWriter(writestream)
            writestream.Position = (tempBlockLength) + (tempBlockLength * currentCharacter)
            Select Case LoadedFile.Endian
                Case 0
                    writebinary.Write(curCharData.nameIdentifier)
                    writebinary.Write(curCharData.unknownBlock)
                Case 1
                    writebinary.Write(curCharData.unknownBlock)
                    writebinary.Write(curCharData.nameIdentifier)
                Case Else
                    MsgBox("Endianness Value is unknown: " & LoadedFile.Endian)
            End Select
            writebinary.Write(curCharData.armyTotal)
            writebinary.Write(curCharData.armyQuantity)
            writebinary.Write(curCharData.locationX)
            writebinary.Write(curCharData.locationY)
            writebinary.Write(curCharData.destinationX)
            writebinary.Write(curCharData.destinationY)
            writebinary.Write(curCharData.gameObjects)
            writebinary.Write(curCharData.mapIcon)
            writebinary.Write(curCharData.spriteColor)
            writebinary.Write(curCharData.spriteType)
            writebinary.Write(curCharData.byte22)
            writebinary.Write(curCharData.Visibility)
            writebinary.Write(curCharData.byte24)
            writebinary.Write(curCharData.powerLevel)
            writebinary.Write(curCharData.moraleTotal)
            writebinary.Write(curCharData.moraleQuantity)
            writebinary.Write(curCharData.byte28)
            writebinary.Write(curCharData.valueMobilize)
            writebinary.Write(curCharData.Stealth)
            writebinary.Write(curCharData.byte31)
            writebinary.Write(curCharData.byte32)
            writebinary.Write(curCharData.byte33)
            writebinary.Write(curCharData.hpTotal)
            writebinary.Write(curCharData.hpCurrent)
            writebinary.Write(curCharData.valueLeaderFollow)
            writebinary.Write(curCharData.byte37)
            writebinary.Close()
            MsgBox("File Saved. " & filename)
            ReadArchiveFile(filename, p_endian)
            isDataSaved = True
        Catch ex As Exception
            MsgBox("PROGRAM ERROR.  LOCATION SaveCurrentCharacter subroutine form frmArcView.  " & vbLf & ex.ToString)
        End Try

    End Sub
    Public Sub CheckSaveResults()
        If isDataSaved = False Then
            Dim strCloseMessage As String = "This form contains unsaved data." & vbCrLf & vbCrLf &
            "Do you want to save your changes to " & txtArmyName.Text & "?"
            Dim Answer As DialogResult = MessageBox.Show(strCloseMessage, "Data Check", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            Select Case Answer
                Case Windows.Forms.DialogResult.Yes
                    SaveCharacter()
                    isDataSaved = True
                    RefreshSaveStatus()
                Case Windows.Forms.DialogResult.No
                    isDataSaved = True
                    RefreshSaveStatus()
                Case Else
                    isDataSaved = True
                    RefreshSaveStatus()
            End Select
        Else
            Exit Sub
        End If
    End Sub
    Public Sub RefreshSaveStatus()
        'MsgBox("Refresh")
        If isDataSaved = True Then
            frmWIMEEditorMain.tclExplorerMain.SelectedTab.Text = curCharData.CharacterName & "      "
        End If
        If isDataSaved = False Then
            frmWIMEEditorMain.tclExplorerMain.SelectedTab.Text = curCharData.CharacterName & " *     "
        End If
    End Sub
    Public Sub RefreshSprite()
        'pbAnimate.Image = Nothing
        ProcessSprites()
        ChangeAnimationCycle(nbrLoop.Value)
        LoadAnimationData(selectedCharacter.spriteType)
        RefreshSpriteDrawingArea()
    End Sub
    Public Sub DisplaySprite()
        'Initialize_SpriteData()
        ProcessSprites()
        ChangeAnimationCycle(nbrLoop.Value)
        nbrLoop.Maximum = currentSprite.TotalLoops - 1
        LoadAnimationData(selectedCharacter.spriteType)
        InitializeSpriteDrawingArea()
        InitializeSpriteControls()
    End Sub
    Public Sub ProcessSprites()
        Dim sprite As Short
        Dim tempCharData As New Archive.Character
        tempCharData = archiveCharacterArray(currentCharacter)
        sprite = (tempCharData.spriteType)
        LoadArmySpriteData(tempCharData.spriteType)
        currentSprite = LoadedSprite
    End Sub
    Public Sub LoadAnimationData(spriteNumber As Integer)
        Dim p_datafile = DATA_FILES
        Dim p_size As Integer = 2
        Dim p_palettedata As resource.RGBColorList
        p_palettedata = New resource.RGBColorList
        Dim ResType As String = "AANIMS"
        For x As Integer = 0 To GameResourceList.Count - 1
            Dim p_spriteForm As Form
            loadedFRML = New Game.resource.animChunk
            loadedResource = New Game.resource
            Dim FRMLName As String = ""
            FRMLName = GameResourceList(x).Name
            If FRMLName = "FRML " & spriteNumber Then
                loadedFRML.Name = FRMLName
                loadedResource.Filename = (LoadedSettings.wimeDIRECTORY & "\" & GameResourceList(x).File & ".RES")
                loadedFRML.offset = Val(GameResourceList(x).Offset)
                loadedFRML.bitplanes = LoadedFile.FRMLBitplanes
                p_palettedata = ParseIndex(GameResourceList(x).File)
                If selectedCharacter.spriteColor > 0 Then
                    p_palettedata = SpriteChangedColor(selectedCharacter.spriteColor, p_palettedata)
                End If
                p_spriteForm = New frmSpriteDraw(selectedCharacter.spriteColor, p_palettedata, p_size)
                p_spriteForm.Show()
                p_spriteForm.Hide()
            End If
        Next x
    End Sub
    Public Sub RefreshSpriteDrawingArea()
        Dim p_image As Bitmap
        p_image = New Bitmap(SpriteList(0))
        surface = p_image
        DisplayCel()
    End Sub
    Public Sub InitializeSpriteDrawingArea()
        Dim p_image As Bitmap
        p_image = New Bitmap(SpriteList(0))
        pnlAnimate.BackColor = Color.Black
        pbAnimate = New PictureBox
        pbAnimate.Parent = pnlAnimate
        yOffset = (MAX_HEIGHT * SIZE_MULTIPLIER) - SpriteList.Item(0).Height
        surface = p_image
        DisplayCel()
    End Sub
    Public Sub DisplayCel()
        pbAnimate.Size = New Size(surface.Width, surface.Height)
        pbAnimate.Location = New Point(xPos, yPos + yOffset)
        pbAnimate.Image = surface
    End Sub
    Public Sub InitializeSpriteControls()
        Dim CellMax As Integer = currentSprite.CycleList.Item(SpriteCurrentLoop).Count - 1
        Dim LoopMax As Integer = currentSprite.CycleList.Count - 1
        txtLoopTotal.Text = LoopMax 'currentSprite.TotalLoops - 1
        txtCelTotal.Text = CellMax            ' Number of Cells
        nbrLoop.Value = SpriteCurrentLoop : nbrLoop.Maximum = LoopMax
        nbrCel.Value = spriteCurCel : nbrCel.Maximum = CellMax
        FillSpriteColors()
        'nbrSpriteColor.Value = selectedCharacter.spriteColor : nbrSpriteColor.Maximum = currentSprite.totalSpriteColors - 1
        cboSpriteName.Items.Clear()
        'For i As Integer = 0 To SpriteTypes.Length - 1
        '    cboSpriteName.Items.Add(SpriteTypes(i))
        'Next
        For i As Integer = 0 To SpriteCluster.Count - 1
            cboSpriteName.Items.Add(SpriteCluster(i).Name)
        Next i

        cboSpriteName.SelectedItem = currentSprite.SpriteType
    End Sub
    Private Sub LoadObjects()
        Dim P_ObjectValue As UInt16
        Dim P_InventoryObjects As New GenericCharacterObject
        TransferObjects = New List(Of GenericCharacterObject)
        LoadObjectNames()
        lstObjectInventory.Width = colName.Width + colValue.Width + 5
        P_ObjectValue = selectedCharacter.gameObjects 'getObjectValue(currentCharacter)
        Call ConvertObjectValueToBinary(P_ObjectValue)
        For d As Integer = 0 To myBA.Length - 1
            If myBA(d) = True Then
                P_InventoryObjects.Name = WIMEObjects(d).Name
                P_InventoryObjects.Value = WIMEObjects(d).Value
                Dim lv As ListViewItem = lstObjectInventory.Items.Add(P_InventoryObjects.Name)
                lv.SubItems.Add(P_InventoryObjects.Value)
                TransferObjects.Add(P_InventoryObjects)
            End If
        Next d
    End Sub
    Private Sub ConvertObjectValueToBinary(integernumber As UInt16)
        Dim g As Integer = 0
        Dim tempvalue As Integer
        Dim IntNum As Long = integernumber
        Dim binvalue As String = ""
        Do
            'Use the Mod operator to get the current binary digit from the
            'Integer number
            tempvalue = IntNum Mod 2
            myBA(g) = tempvalue
            'MsgBox("BIT " & g & " " & myBA(g))
            binvalue = CStr(tempvalue) + binvalue
            'Divide the current number by 2 and get the integer result
            IntNum = IntNum \ 2
            g = g + 1
        Loop Until IntNum = 0
        'IntToBin = binvalue
    End Sub
    Private Sub RefreshObjects()
        Dim tempObject As UInt16
        LoadObjectNames()
        lstObjectInventory.Width = colName.Width + colValue.Width + 4
        tempObject = Val(txtInventory.Text)
        Call ConvertObjectValueToBinary(tempObject)
        For d As Integer = 0 To myBA.Length - 1
            If myBA(d) = True Then
                Dim lv As ListViewItem = lstObjectInventory.Items.Add(WIMEObjects(d).Name)
                lv.SubItems.Add(WIMEObjects(d).Value)
            End If
        Next d
    End Sub
    Public Sub LoadObjectNames()
        'loadedSettings = loadConfig(settingsFullFilename)
        Dim P_GenObj As GenericCharacterObject
        WIMEObjects = New List(Of GenericCharacterObject)
        Dim tempval As Integer
        Dim p_format As String
        Dim tempobject As String = ""
        Dim filePointer As Long
        Dim tempExec As String
        p_format = LoadedFile.Name
        tempExec = LoadedFile.ExecutableFile
        Dim fullfile As String = LoadedSettings.wimeDIRECTORY & "\" & tempExec
        filePointer = LoadedFileOffsets.EXEInventoryName 'GetObjectOffset(LoadedFile.Name)
        Using resread As New BinaryFile(fullfile)
            resread.Position = filePointer
            Dim index As Integer = 0
            Dim p_val = 1
            For x As UShort = 1 To OBJECT_TOTAL
                P_GenObj = New GenericCharacterObject
                tempobject = ""
                Do
                    tempval = resread.ReadByte
                    If tempval = 0 Then Exit Do
                    tempobject = tempobject & Chr(tempval)
                Loop
                P_GenObj.Name = tempobject
                P_GenObj.Value = p_val
                WIMEObjects.Add(P_GenObj)
                p_val = (p_val * 2)
                index = index + 1
            Next x
        End Using
    End Sub
    Public Sub SaveFormCheck()
        If isDataSaved = False Then
            Dim strCloseMessage As String = "This form contains unsaved data." & vbCrLf & vbCrLf &
            "Do you want to save your changes to " & txtArmyName.Text & "?"
            Dim Answer As DialogResult = MessageBox.Show(strCloseMessage, "Data Check", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
            Select Case Answer
                Case Windows.Forms.DialogResult.Yes
                    SaveCharacter()
                    isDataSaved = True
                    RefreshSaveStatus()
                Case Windows.Forms.DialogResult.No
                    isDataSaved = True
                    RefreshSaveStatus()
                Case Else
                    isDataSaved = True
                    RefreshSaveStatus()
            End Select
        Else
            Exit Sub
        End If
    End Sub
    Public Sub ChangeAnimationCycle(cycleIndex As Integer)
        If currentSprite.AnimationCycle IsNot Nothing Then
            ClearSpriteList()
        End If
        currentSprite.AnimationCycle = currentSprite.CycleList(cycleIndex)
    End Sub
    Public Sub ClearSpriteList()
        For x As Integer = 1 To currentSprite.AnimationCycle.Count - 1
            currentSprite.AnimationCycle.Remove(x)
        Next
    End Sub
    Public Sub FillSpriteColors()
        cboSpriteColor.Items.Clear()

        For a As Integer = 0 To currentSprite.TotalSpriteColors - 1
            cboSpriteColor.Items.Add(currentSprite.SpriteColor(a))
        Next
        For b As Integer = 0 To currentSprite.TotalSpriteColors - 1
            If selectedCharacter.spriteColor = cboSpriteColor.Items(b) Then
                cboSpriteColor.SelectedIndex = (b)
            End If
        Next
    End Sub
    ' ============================================================ EVENT HANDLERS ===================================================================================
    Private Sub BtnAnimate_Click(sender As System.Object, e As System.EventArgs) Handles btnAnimate.Click
        If EventsOn = True Then
            Dim p_image As Bitmap
            ChangeAnimationCycle(nbrLoop.Value)
            For x As Integer = 0 To currentSprite.AnimationCycle.Count - 1
                Dim P_COUNTER As Integer
                P_COUNTER = currentSprite.AnimationCycle(x)
                p_image = New Bitmap(SpriteList(P_COUNTER))
                yOffset = (MAX_HEIGHT * SIZE_MULTIPLIER) - (SpriteList(P_COUNTER).Height)
                DisplayCel()
            Next
            If Timer1.Enabled = True Then
                Timer1.Enabled = False
            Else
                Timer1.Enabled = True
            End If

        End If
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim p_image As Bitmap
        Static ctr As Integer = -1
        Timer1.Interval = currentSprite.AnimateSpeed
        If ctr < currentSprite.CycleList.Item(SpriteCurrentLoop).Count - 1 Then
            ctr += 1
            If ctr > nbrCel.Maximum And ctr > 0 Then ctr -=
            nbrCel.Value = ctr
        Else
            ctr = 0
            nbrCel.Value = ctr
        End If
        p_image = New Bitmap(SpriteList(currentSprite.AnimationCycle(ctr)))
        surface = p_image
        yOffset = (MAX_HEIGHT * SIZE_MULTIPLIER) - (SpriteList(currentSprite.AnimationCycle(ctr)).Height)
        DisplayCel()
    End Sub
    Private Sub nbrLoop_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nbrLoop.ValueChanged
        If EventsOn = True Then
            Dim p_image As Bitmap
            nbrCel.Value = 0
            SpriteCurrentLoop = nbrLoop.Value
            ChangeAnimationCycle(SpriteCurrentLoop)
            txtCelTotal.Text = currentSprite.CycleList.Item(SpriteCurrentLoop).Count - 1
            nbrCel.Maximum = Val(txtCelTotal.Text)
            spriteCurCel = nbrCel.Value
            yOffset = (MAX_HEIGHT * SIZE_MULTIPLIER) - (SpriteList(currentSprite.AnimationCycle(spriteCurCel)).Height)
            p_image = New Bitmap(SpriteList(currentSprite.AnimationCycle(spriteCurCel)))
            surface = p_image
            DisplayCel()
        End If
    End Sub
    Private Sub nbrCel_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nbrCel.ValueChanged
        If EventsOn = True Then
            Dim p_image As Bitmap
            spriteCurCel = nbrCel.Value
            yOffset = (MAX_HEIGHT * SIZE_MULTIPLIER) - (SpriteList(currentSprite.AnimationCycle(spriteCurCel)).Height)
            p_image = New Bitmap(SpriteList(currentSprite.AnimationCycle(spriteCurCel)))
            surface = p_image
            DisplayCel()
        End If
    End Sub
    Private Sub cboSpriteName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSpriteName.SelectedIndexChanged
        If EventsOn = True Then
            Dim tempCharData As New Archive.Character
            tempCharData = archiveCharacterArray(currentCharacter)
            LoadArmySpriteData(tempCharData.spriteType)
            currentSprite = LoadedSprite
            For a = 0 To currentSprite.SpriteType.Length - 1
                If cboSpriteName.SelectedItem = SpriteCluster(a).Name Then
                    curCharData.spriteType = SpriteCluster(a).Value
                End If
            Next
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub btnChangeBack_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeBack.Click
        mapindex = mapindex - 1
        If mapindex < 0 Then
            mapindex = 29
        End If
        pbMapIcon.Image = Nothing
        pbMapIcon.Image = MapIcons.Images(mapindex)
        curCharData.mapIcon = BANNERICON_VALUES(mapindex)
        isDataSaved = False
        RefreshSaveStatus()
    End Sub
    Private Sub btnChangeNext_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeNext.Click
        mapindex = mapindex + 1
        If mapindex > 29 Then
            mapindex = 0
        End If
        pbMapIcon.Image = Nothing
        pbMapIcon.Image = MapIcons.Images(mapindex)
        curCharData.mapIcon = BANNERICON_VALUES(mapindex)
        isDataSaved = False
        RefreshSaveStatus()
    End Sub
    Private Sub cboMobilized_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMobilized.SelectedIndexChanged
        If EventsOn = True Then
            For x As Integer = 0 To Mobilized.Count - 1
                If cboMobilized.SelectedItem = Mobilized(x).Name Then
                    curCharData.valueMobilize = Mobilized(x).Value
                End If
            Next
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub nbrArmyQTY_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nbrArmyQTY.ValueChanged
        If EventsOn = True Then
            curCharData.armyQuantity = nbrArmyQTY.Value
            If nbrArmyQTY.Value > nbrArmyTotal.Value Then
                nbrArmyTotal.Value = nbrArmyQTY.Value
                curCharData.hpCurrent = nbrHitPoints.Value
                curCharData.hpTotal = nbrHitTotal.Value
            End If
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub nbrHitPoints_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nbrHitPoints.ValueChanged
        If EventsOn = True Then
            curCharData.hpCurrent = nbrHitPoints.Value
            If nbrHitPoints.Value > nbrHitTotal.Value Then
                nbrHitTotal.Value = nbrHitPoints.Value
                curCharData.hpCurrent = nbrHitPoints.Value
                curCharData.hpTotal = nbrHitTotal.Value
            End If
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub nbrHitTotal_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nbrHitTotal.ValueChanged
        If EventsOn = True Then
            curCharData.hpTotal = nbrHitTotal.Value
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub nbrArmyTotal_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nbrArmyTotal.ValueChanged
        If EventsOn = True Then
            curCharData.armyTotal = nbrArmyTotal.Value
            If nbrArmyQTY.Value > nbrArmyTotal.Value Then
                nbrArmyQTY.Value = nbrArmyTotal.Value
            End If
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub chkVisible_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVisible.CheckedChanged
        If EventsOn = True Then
            If chkVisible.Checked = True Then
                curCharData.Visibility = 1
            ElseIf chkVisible.Checked = False Then
                curCharData.Visibility = 0
            End If
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub nbrMorale_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nbrMorale.ValueChanged
        If EventsOn = True Then
            curCharData.moraleQuantity = nbrMorale.Value
            If nbrMorale.Value > nbrMoraleTotal.Value Then
                nbrMoraleTotal.Value = nbrMorale.Value
            End If
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub nbrMoraleTotal_ValueChanged(sender As System.Object, e As System.EventArgs) Handles cboLocation.SelectedIndexChanged
        If EventsOn = True Then
            curCharData.moraleTotal = nbrMoraleTotal.Value
            If nbrMorale.Value > nbrMoraleTotal.Value Then
                nbrMorale.Value = nbrMoraleTotal.Value
            End If
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub cboLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocation.SelectedIndexChanged
        If EventsOn = True Then
            Dim finderLoc As String
            For a = 0 To CityGroup.Count - 1
                finderLoc = cboLocation.SelectedItem
                If finderLoc = CityGroup(a).Name Then
                    txtLocationX.Text = CityGroup(a).X
                    txtLocationY.Text = CityGroup(a).Y
                    curCharData.locationX = CityGroup(a).X
                    curCharData.locationY = CityGroup(a).Y
                    Exit For
                Else
                End If
            Next
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub cboDestination_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDestination.SelectedIndexChanged
        If EventsOn = True Then
            Dim finderDest As String
            For a = 0 To CityGroup.Count - 1
                finderDest = cboDestination.SelectedItem
                If finderDest = CityGroup(a).Name Then
                    txtDestinationX.Text = CityGroup(a).X
                    txtDestinationY.Text = CityGroup(a).Y
                    curCharData.destinationX = CityGroup(a).X
                    curCharData.destinationY = CityGroup(a).Y
                    Exit For
                Else
                End If
            Next
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub cboCharacterFollow_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCharacterFollow.SelectedIndexChanged
        If EventsOn = True Then
            Dim finderFollow As String
            For a As Integer = 0 To ArmyFollow(a).Name.Count - 1
                finderFollow = cboCharacterFollow.SelectedItem
                If finderFollow = ArmyFollow(a).Name Then
                    curCharData.valueLeaderFollow = ArmyFollow(a).Value
                    Exit For
                Else
                End If
                isDataSaved = False
                RefreshSaveStatus()
            Next
        End If
    End Sub
    Private Sub BtnAddArmy_Click(sender As Object, e As EventArgs) Handles btnAddArmy.Click
        MsgBox("This feature is available but its operation is not complete!")
        Dim addArm As New frmAddArmy
        addArm.Show()
    End Sub
    Private Sub nbrPower_ValueChanged(sender As Object, e As EventArgs) Handles nbrPower.ValueChanged
        If EventsOn = True Then
            isDataSaved = False
            curCharData.powerLevel = nbrPower.Value
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub btnAddItems_Click(sender As Object, e As EventArgs) Handles btnAddItems.Click
        Dim nf As Form
        Dim p_temp As New GenericCharacterObject
        nf = New frmInventory(WIMEObjects, TransferObjects)
        Dim selectedButton As DialogResult
        selectedButton = nf.ShowDialog
        If selectedButton = Windows.Forms.DialogResult.OK Then
            txtInventory.Text = nf.Tag.ToString
            curCharData.gameObjects = Val(txtInventory.Text)
        End If
    End Sub
    Private Sub txtInventory_TextChanged(sender As Object, e As EventArgs) Handles txtInventory.TextChanged
        If EventsOn = True Then
            lstObjectInventory.Items.Clear()
            RefreshObjects()
            isDataSaved = False
            RefreshSaveStatus()
            curCharData.gameObjects = Val(txtInventory.Text)
        End If
    End Sub
    Private Sub nbrStealth_ValueChanged(sender As Object, e As EventArgs) Handles nbrStealth.ValueChanged
        If EventsOn = True Then
            isDataSaved = False
            RefreshSaveStatus()
        End If
    End Sub
    Private Sub cboSpriteColor_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSpriteColor.SelectionChangeCommitted
        selectedCharacter.spriteColor = cboSpriteColor.SelectedItem.ToString
        RefreshSprite()
    End Sub
End Class

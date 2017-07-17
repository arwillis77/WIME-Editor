Imports WIMEEditor.Sprite
Imports WIMEEditor.EditorSettings
Imports System.IO
Imports WIMEEditor.Game
Public Class frmArcView
    '// Declare Variables
    Public spriteCurLoop As Integer = 0
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
    Public ARC_Sprite_DATA As Archive_SpriteList
    Dim WIMEObjects As New Game.Executable.Inventory
    Dim TransferObjects As New Game.Executable.Inventory
    Dim selectedCharacter As Game.Archive.Character
    Public SIZE_MULTIPLIER As Integer = 2
    Dim myBA As BitArray
    Private Sub frmArcView_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            myBA = Nothing
            myBA = New BitArray(15)
            ARCHIVE_FILE = loadedSettings.wimeDIRECTORY & "\" & Game.Archive.FILENAME
            SetupFormData()
            SetArchiveCBOArrayData()
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
        RemoveHandler cboSpriteColor.SelectedIndexChanged, AddressOf cboSpriteColor_SelectedIndexChanged
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub SetupFormData()
        cboCharacterFollow.Items.Clear()
        cboCharacterFollow.Items.Add("NONE")
        For intTempFollowCounter As Integer = 0 To ArchiveCharacterCBOArrays.characterFollowName.Length - 1
            cboCharacterFollow.Items.Add(ArchiveCharacterCBOArrays.characterFollowName(intTempFollowCounter))
        Next intTempFollowCounter
        ' *** FILL MOBILIZATION COMBO BOX ***
        cboMobilized.Items.Clear()
        For intTempMobCounter As Integer = 0 To ArchiveCharacterCBOArrays.mobilizedText.Length - 1
            cboMobilized.Items.Add(ArchiveCharacterCBOArrays.mobilizedText(intTempMobCounter))
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
        For intLocFill As Integer = 0 To CITY_MAX
            cboLocation.Items.Add(CityEXE(intLocFill).Name)
        Next intLocFill
        ' *** Fill Info for Character Destination ***
        cboDestination.Items.Clear()
        cboDestination.Items.Add(Default_City)
        For intDestFill As Integer = 0 To CITY_MAX
            cboDestination.Items.Add(CityEXE(intDestFill).Name)
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
        selectedCharacter = New Game.Archive.Character : selectedCharacter = archiveCharacterArray(currentCharacter)
        If currentCharacter > CHARACTER_MAX Then currentCharacter = CHARACTER_MAX
        If currentCharacter < 0 Then currentCharacter = 0
        ' ********* FILL FORM FIELDS WITH DATA *******************************************
        txtArmyName.Text = selectedCharacter.CharacterName
        For a As Integer = 0 To ArchiveCharacterCBOArrays.characterFollowName.Length - 1
            If selectedCharacter.valueLeaderFollow = 0 Then
                cboCharacterFollow.SelectedItem = cboCharacterFollow.Items.Item(0)
                Exit For
            ElseIf selectedCharacter.valueLeaderFollow = ArchiveCharacterCBOArrays.characterFollowvalue(a) Then
                cboCharacterFollow.SelectedItem = ArchiveCharacterCBOArrays.characterFollowName(a)
            End If
        Next
        For i As Integer = 0 To ArchiveCharacterCBOArrays.mobilizedText.Length - 1
            If selectedCharacter.valueMobilize = ArchiveCharacterCBOArrays.mobilizedValue(i) Then
                cboMobilized.SelectedText = ArchiveCharacterCBOArrays.mobilizedText(i)
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
        For x As Integer = 0 To CITY_MAX - 1
            If selectedCharacter.locationX = CityEXE(x).X AndAlso selectedCharacter.locationY = CityEXE(x).Y Then
                cboLocation.SelectedItem = cboLocation.Items.Item(x + 1)
                Exit For
            End If
        Next x
        If IsNothing(cboLocation.SelectedItem) Then
            cboLocation.SelectedItem = cboLocation.Items.Item(0)
        End If
        txtDestinationX.Text = selectedCharacter.destinationX
        txtDestinationY.Text = selectedCharacter.destinationY
        For x As Integer = 0 To CITY_MAX - 1
            If selectedCharacter.destinationX = CityEXE(x).X AndAlso selectedCharacter.destinationY = CityEXE(x).Y Then
                cboDestination.SelectedItem = cboDestination.Items.Item(x + 1)
            End If
        Next x
        If IsNothing(cboDestination.SelectedItem) Then
            cboDestination.SelectedItem = cboDestination.Items.Item(0)
        End If
        nbrMorale.Text = selectedCharacter.moraleQuantity
        nbrMoraleTotal.Text = selectedCharacter.moraleTotal
        loadObjects()
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
        For h As Integer = 0 To ArchiveCharacterCBOArrays.characterFollowvalue.Length - 1
            If charnum = ArchiveCharacterCBOArrays.characterFollowvalue(h) Then
                curCharVal = ArchiveCharacterCBOArrays.characterFollowvalue(h)
                Exit For
            End If
        Next
        Dim tempCharData As Game.Archive.Character
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
        AddHandler cboSpriteColor.SelectedIndexChanged, AddressOf cboSpriteColor_SelectedIndexChanged
        EventsOn = True
    End Sub
    Public Sub SaveCharacter()
        Try
            Dim tempBlockLength As Integer
            Dim filename As String
            Dim arcDir As String
            Dim writestream As FileStream
            Dim p_endian As UShort
            loadedSettings = loadConfig(settingsFullFilename)
            p_endian = loadedGame.endianType
            tempBlockLength = _getBlockLength(p_endian)
            arcDir = loadedSettings.wimeDIRECTORY
            filename = ARCHIVE_FILE
            writestream = New FileStream(filename, FileMode.Open)
            Dim writebinary As New BinaryWriter(writestream)
            writestream.Position = (tempBlockLength) + (tempBlockLength * currentCharacter)
            Select Case loadedGame.endianType
                Case 0
                    writebinary.Write(curCharData.nameIdentifier)
                    writebinary.Write(curCharData.unknownBlock)
                Case 1
                    writebinary.Write(curCharData.unknownBlock)
                    writebinary.Write(curCharData.nameIdentifier)
                Case Else
                    MsgBox("Endianness Value is unknown: " & loadedGame.endianType)
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
            Dim strCloseMessage As String = "This form contains unsaved data." & vbCrLf & vbCrLf & _
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
        Initialize_SpriteData()
        ProcessSprites()
        ChangeAnimationCycle(nbrLoop.Value)
        nbrLoop.Maximum = currentSprite.totalLoops - 1
        LoadAnimationData(selectedCharacter.spriteType)
        InitializeSpriteDrawingArea()
        InitializeSpriteControls()
    End Sub
    Public Sub Initialize_SpriteData()
        Dim p_cbospritedata As New Archive_Sprite
        cboSpriteName.Items.Clear()
        For x = 0 To 82
            p_cbospritedata = LoadSpriteCBOData(loadedGame.format, currentSprite.spriteValue)
            cboSpriteName.Items.Add(p_cbospritedata.Name)

            If x = 16 Then
                x = x + 63
            End If
        Next x
    End Sub

    Public Sub ProcessSprites()
        Dim sprite As Short
        Dim tempCharData As New Game.Archive.Character
        tempCharData = archiveCharacterArray(currentCharacter)
        sprite = (tempCharData.spriteType)
        Select Case sprite
            Case SpriteValues(0)
                Call SetHobbitSprite()
                currentSprite = HobbitSprite
            Case SpriteValues(1)
                Call SetElfSprite()
                currentSprite = ElfSprite
            Case SpriteValues(2)
                Call SetManSprite()
                currentSprite = ManSprite
            Case SpriteValues(3)
                Call SetDwarfSprite()
                currentSprite = DwarfSprite
            Case SpriteValues(4)
                Call SetWizardSprite()
                currentSprite = WizardSprite
            Case SpriteValues(5)
                Call SetGollumSprite()
                currentSprite = GollumSprite
            Case SpriteValues(6)
                Call SetOrcSprite()
                currentSprite = OrcSprite
            Case SpriteValues(7)
                Call SetEntSprite()
                currentSprite = EntSprite
            Case SpriteValues(8)
                Call setNazgulSprite()
                currentSprite = NazgulSprite
            Case SpriteValues(9)
                Call setTrollSprite()
                currentSprite = TrollSprite
            Case SpriteValues(10)
                Call setWargSprite()
                currentSprite = WargSprite
            Case SpriteValues(11)
                Call setSpiderSprite()
                currentSprite = SpiderSprite
            Case SpriteValues(12)
                Call setBalrogSprite()
                currentSprite = BalrogSprite
            Case SpriteValues(13)
                Call setRohirrimSprite()
                currentSprite = RohirrimSprite
            Case SpriteValues(14)
                Call setArmManSprite()
                currentSprite = ArmManSprite
            Case SpriteValues(15)
                Call setDunlendingSprite()
                currentSprite = DunlendingSprite
            Case Val(SpriteValues(16))
                Call setElderElfSprite()
                currentSprite = ElderElfSprite
            Case SpriteValues(17)
                Call setGaladrielSprite()
                currentSprite = GaladrielSprite
            Case SpriteValues(18)
                Call setBombadilSprite()
                currentSprite = BombadilSprite
        End Select
    End Sub
    Public Sub LoadAnimationData(spriteNumber As Integer)
        Dim p_size As Integer = 2
        Dim p_palettedata As resource.RGBColorList
        p_palettedata = New resource.RGBColorList
        For x As Integer = 0 To GameResourceList.Count - 1
            Dim p_spriteForm As Form
            loadedFRML = New Game.resource.animChunk
            loadedResource = New Game.resource
            Dim FRMLName As String = ""
            FRMLName = GameResourceList(x).Name
            If FRMLName = "FRML " & spriteNumber Then
                loadedFRML.Name = FRMLName
                loadedResource.Filename = (loadedSettings.wimeDIRECTORY & "\" & GameResourceList(x).File & ".RES")
                loadedFRML.offset = Val(GameResourceList(x).Offset)
                loadedFRML.bitplanes = getPlanes(loadedGame.format)
                p_palettedata = LoadPalette(SPRITES, loadedGame.format, selectedCharacter.spriteColor)
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
        txtLoopTotal.Text = currentSprite.totalLoops - 1
        txtFrameTotal.Text = currentSprite.loopFrames(spriteCurLoop) - 1
        nbrLoop.Value = spriteCurLoop : nbrLoop.Maximum = currentSprite.totalLoops - 1
        nbrCel.Value = spriteCurCel : nbrCel.Maximum = currentSprite.loopFrames(spriteCurLoop) - 1
        FillSpriteColors()
        'nbrSpriteColor.Value = selectedCharacter.spriteColor : nbrSpriteColor.Maximum = currentSprite.totalSpriteColors - 1
        'cboSpriteName.Items.Clear()
        'For i As Integer = 0 To SpriteTypes.Length - 1
        '    cboSpriteName.Items.Add(SpriteTypes(i))
        'Next
        cboSpriteName.SelectedItem = currentSprite.spriteType
    End Sub
    Private Sub loadObjects()
        Dim tempObject As UInt16
        loadObjectNames()
        lstObjectInventory.Width = colName.Width + colValue.Width + 5
        tempObject = selectedCharacter.gameObjects 'getObjectValue(currentCharacter)
        Call ConvertObjectValueToBinary(tempObject)
        For d As Integer = 0 To myBA.Length - 1
            If myBA(d) = True Then
                Dim lv As ListViewItem = lstObjectInventory.Items.Add(WIMEObjects.name(d))
                lv.SubItems.Add(WIMEObjects.value(d))
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
        loadObjectNames()
        lstObjectInventory.Width = colName.Width + colValue.Width + 4
        tempObject = Val(txtInventory.Text)
        Call ConvertObjectValueToBinary(tempObject)
        For d As Integer = 0 To myBA.Length - 1
            If myBA(d) = True Then
                Dim lv As ListViewItem = lstObjectInventory.Items.Add(WIMEObjects.name(d))
                lv.SubItems.Add(WIMEObjects.value(d))
            End If
        Next d
    End Sub
    Public Sub loadObjectNames()
        'loadedSettings = loadConfig(settingsFullFilename)
        Dim tempval As Integer
        Dim p_format As String
        Dim tempobject As String = ""
        Dim filePointer As Long
        Dim tempExec As String
        p_format = loadedSettings.fileFormat
        'loadedGame.formatVal = GetFormatValueByType(p_format)
        If loadedGame.formatVal = -1 Then
            Throw New Exception("EXECUTABLE Invalid Format.  Please check the file and reload.")
            Exit Sub
        End If
        tempExec = gameExecutables(loadedGame.formatVal)
        Dim fullfile As String = loadedSettings.wimeDIRECTORY & "\" & tempExec
        filePointer = getObjectOffset(loadedSettings.fileFormat)
        Using resread As New BinaryFile(fullfile)
            resread.Position = filePointer
            Dim index As Integer = 0
            WIMEObjects.value = {1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768}
            For x As UShort = 1 To OBJECT_TOTAL
                tempobject = ""
                Do
                    tempval = resread.ReadByte
                    If tempval = 0 Then Exit Do
                    tempobject = tempobject & Chr(tempval)
                Loop
                WIMEObjects.name(index) = tempobject
                index = index + 1
            Next x
        End Using
    End Sub
    Public Sub SaveFormCheck()
        If isDataSaved = False Then
            Dim strCloseMessage As String = "This form contains unsaved data." & vbCrLf & vbCrLf & _
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
            'ClearSpriteList() : MsgBox("ClearSpriteList")
        End If
        Select Case cycleIndex
            Case 0
                currentSprite.AnimationCycle = currentSprite.LoopFrameSet.WalkCycle
            Case 1
                currentSprite.AnimationCycle = currentSprite.LoopFrameSet.Cycle2
            Case 2
                currentSprite.AnimationCycle = currentSprite.LoopFrameSet.Cycle3
            Case 3
                currentSprite.AnimationCycle = currentSprite.LoopFrameSet.Cycle4
            Case 4
                currentSprite.AnimationCycle = currentSprite.LoopFrameSet.Cycle5
            Case 5
                currentSprite.AnimationCycle = currentSprite.LoopFrameSet.Cycle6
            Case 6
                currentSprite.AnimationCycle = currentSprite.LoopFrameSet.Cycle7
            Case Else
                currentSprite.AnimationCycle = currentSprite.LoopFrameSet.WalkCycle
        End Select

    End Sub
    Public Sub ClearSpriteList()
        For x As Integer = 1 To currentSprite.AnimationCycle.Count - 1
            currentSprite.AnimationCycle.Remove(x)
        Next
    End Sub
    Public Sub FillSpriteColors()
        cboSpriteColor.Items.Clear()


        For a As Integer = 0 To currentSprite.totalSpriteColors - 1
            cboSpriteColor.Items.Add(currentSprite.spriteColor(a))
        Next
        For b As Integer = 0 To currentSprite.totalSpriteColors - 1
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
                'centerFormObj(pnlAnimate, pbAnimate) : yPos = yPos + yOffset
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
        Timer1.Interval = currentSprite.animateSpeed
        If ctr < currentSprite.loopFrames(spriteCurLoop) - 1 Then
            ctr += 1
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
            spriteCurLoop = nbrLoop.Value
            ChangeAnimationCycle(spriteCurLoop)
            txtFrameTotal.Text = (currentSprite.loopFrames(spriteCurLoop) - 1)
            nbrCel.Maximum = Val(txtFrameTotal.Text)
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
            Dim tempCharData As New Game.Archive.Character
            tempCharData = archiveCharacterArray(currentCharacter)





            Select Case cboSpriteName.SelectedItem
                Case SpriteTypes(0)
                    Call SetHobbitSprite()
                    currentSprite = HobbitSprite
                Case SpriteTypes(1)
                    Call SetElfSprite()
                    currentSprite = ElfSprite
                Case SpriteTypes(2)
                    Call SetManSprite()
                    currentSprite = ManSprite
                Case SpriteTypes(3)
                    Call SetDwarfSprite()
                    currentSprite = DwarfSprite
                Case SpriteTypes(4)
                    Call SetWizardSprite()
                    currentSprite = WizardSprite
                Case SpriteTypes(5)
                    Call SetGollumSprite()
                    currentSprite = GollumSprite
                Case SpriteTypes(6)
                    Call SetOrcSprite()
                    currentSprite = OrcSprite
                Case SpriteTypes(7)
                    Call SetEntSprite()
                    currentSprite = EntSprite
                Case SpriteTypes(8)
                    Call setNazgulSprite()
                    currentSprite = NazgulSprite
                Case SpriteTypes(9)
                    Call setTrollSprite()
                    currentSprite = TrollSprite
                Case SpriteTypes(10)
                    Call setWargSprite()
                    currentSprite = WargSprite
                Case SpriteTypes(11)
                    Call setSpiderSprite()
                    currentSprite = SpiderSprite
                Case SpriteTypes(12)
                    Call setBalrogSprite()
                    currentSprite = BalrogSprite
                Case SpriteTypes(13)
                    Call setRohirrimSprite()
                    currentSprite = RohirrimSprite
                Case SpriteTypes(14)
                    Call setArmManSprite()
                    currentSprite = ArmManSprite
                Case SpriteTypes(15)
                    Call setDunlendingSprite()
                    currentSprite = DunlendingSprite
                Case SpriteTypes(16)
                    Call setElderElfSprite()
                    currentSprite = ElderElfSprite
                Case SpriteTypes(17)
                    Call setGaladrielSprite()
                    currentSprite = GaladrielSprite
                Case SpriteTypes(18)
                    Call setBombadilSprite()
                    currentSprite = BombadilSprite
            End Select
            For a = 0 To currentSprite.spriteType.Length - 1
                If cboSpriteName.SelectedItem = SpriteTypes(a) Then
                    curCharData.spriteType = SpriteValues(a)
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
            For x As Integer = 0 To ArchiveCharacterCBOArrays.mobilizedValue.Length - 1
                If cboMobilized.SelectedItem = ArchiveCharacterCBOArrays.mobilizedText(x) Then
                    curCharData.valueMobilize = ArchiveCharacterCBOArrays.mobilizedValue(x)
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
            For a = 0 To CITY_MAX
                finderLoc = cboLocation.SelectedItem
                If finderLoc = CityEXE(a).Name Then
                    txtLocationX.Text = CityEXE(a).X
                    txtLocationY.Text = CityEXE(a).Y
                    curCharData.locationX = CityEXE(a).X
                    curCharData.locationY = CityEXE(a).Y
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
            For a = 0 To CITY_MAX
                finderDest = cboDestination.SelectedItem
                If finderDest = CityEXE(a).Name Then
                    txtDestinationX.Text = CityEXE(a).X
                    txtDestinationY.Text = CityEXE(a).Y
                    curCharData.destinationX = CityEXE(a).X
                    curCharData.destinationY = CityEXE(a).Y
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
            For a = 0 To ArchiveCharacterCBOArrays.characterFollowName.Length - 1
                finderFollow = cboCharacterFollow.SelectedItem
                If finderFollow = ArchiveCharacterCBOArrays.characterFollowName(a) Then
                    curCharData.valueLeaderFollow = ArchiveCharacterCBOArrays.characterFollowvalue(a)
                    Exit For
                Else
                End If
                isDataSaved = False
                RefreshSaveStatus()
            Next
        End If
    End Sub
    Private Sub btnAddArmy_Click(sender As Object, e As EventArgs) Handles btnAddArmy.Click
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
        Dim tempObjNum As Integer = lstObjectInventory.Items.Count
        ReDim TransferObjects.name(tempObjNum)
        ReDim TransferObjects.value(tempObjNum)
        For g = 0 To tempObjNum - 1
            TransferObjects.name(g) = lstObjectInventory.Items(g).SubItems(0).Text
            TransferObjects.value(g) = (lstObjectInventory.Items(g).SubItems(1).Text)
        Next
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
    Private Sub cboSpriteColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSpriteColor.SelectedIndexChanged
        selectedCharacter.spriteColor = Val(cboSpriteColor.SelectedIndex.ToString)
        RefreshSprite()
    End Sub
End Class

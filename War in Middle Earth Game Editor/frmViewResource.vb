﻿Imports WIMEEditor.Game
Imports WIMEEditor.Game.resource
Imports System.IO
Imports WIMEEditor.BinaryFile
Imports WIMEEditor.ByteRunUnpacker
Public Class frmViewResource
    '// frmViewResource - Form Class Related to viewing resource files.
    Public CHARTile As New Game.resource.tileChunk
    Public CurrentTile As Integer
    Public ResourcePalette As resource.RGBColorList
    Public Format As String
    Dim p_ResourceContainer As New Game.resource.ResourceDetails
    Dim WithEvents pnlFRMLDisplay As Panel
    Dim filenameData As String = ""
    Dim gameStatus As String = ""
    Dim escape As Boolean
    Dim AddressOffset As UShort = 0
    Dim lForm As Boolean = False
    Dim planeCount As UShort = 0
    Dim IMAGView As Game.resource.ImageChunk
    Dim FRMLView As Game.resource.animChunk
    Dim pbTileView As PictureBox
    Dim txtCSTRElement As TextBox
    Dim SpriteColor As Integer = 0
    Private Sub frmViewResource_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(35, 35, 35)
        Format = LoadedFile.Name
        'MsgBox("Format is " & Format)
        If p_ResourceContainer.resourceType = Game.resource.RES_ID_ELEMENTS(4) Then
            ViewIMAGResource()
        ElseIf p_ResourceContainer.resourceType = Game.resource.RES_ID_ELEMENTS(3) Then
            ViewFRMLResource()
        ElseIf p_ResourceContainer.resourceType = Game.resource.RES_ID_ELEMENTS(1) Then
            ViewCSTRResource()
        ElseIf p_ResourceContainer.resourceType = Game.resource.RES_ID_ELEMENTS(0) Then
            pbTileView = New PictureBox
            ViewCHARResource()
        End If
    End Sub
    Public Sub New(resource As Game.resource.ResourceDetails)
        InitializeComponent()
        p_ResourceContainer = resource
        For x As Integer = 0 To 2
            ddScale.DropDownItems.Add(scale_values(x))
        Next
        ddScale.Text = scaleFactor
        pnlMainDisplay.Size = New Size(ImageWidth * scaleFactor, ImageHeight * scaleFactor)

        filenameData = LoadedSettings.wimeDIRECTORY & "\" & p_ResourceContainer.resourceFile & ".RES"
    End Sub
    Public Sub New(resource As Game.resource.ResourceDetails, TILE_DATA As Game.resource.tileChunk, selectedtile As Integer)
        InitializeComponent()
        p_ResourceContainer = resource
        CHARTile = TILE_DATA
        filenameData = TILE_DATA.filename
        CurrentTile = selectedtile
        For x As Integer = 0 To 2
            ddScale.DropDownItems.Add(scale_values(x))
        Next
        ddScale.Text = scaleFactor
    End Sub
    Public Sub ViewIMAGResource()
        Dim p_endoffset As Integer = 0
        Dim p_resource = IMAGES
        Dim p_resFile As String = ""
        filenameData = LoadedSettings.wimeDIRECTORY & "\" & p_ResourceContainer.resourceFile & ".RES"
        IMAGView = New Game.resource.ImageChunk
        IMAGView = GetIMAGChunk(filenameData, LoadedFile.Name, p_ResourceContainer.fileOffset, LoadedFile.Endian)
        ResourcePalette = New resource.RGBColorList
        ' Color correct icons used in scenes.  Others use palette from map as they are for mapview.
        If SelectedResourceItem.resourceFile = "AMAPS" And IMAGView.bitplane = 5 Then
            SelectedResourceItem.resourceFile = "BSCENE"
        End If
        p_resFile = SelectedResourceItem.resourceFile
        ResourcePalette = ParseIndex(p_resFile)
        LoadImage(filenameData, p_ResourceContainer.fileOffset)
        p_endoffset = p_ResourceContainer.fileOffset + (p_ResourceContainer.dataSize + 4)
        gameStatus = p_ResourceContainer.Name & ", " & IMAGView.uncompressed_size & " bytes, (" & IMAGView.chunkSize & " bytes, compressed)" & " @ " & p_ResourceContainer.resourceFile & ".RES" & " (" & p_ResourceContainer.fileOffset & " - " & p_endoffset & ")"
        lblGameStatus.Text = gameStatus
        ddSpriteColor.Visible = False
    End Sub
    Public Sub ViewCHARResource()
        LoadTile(filenameData, scaleFactor, CurrentTile)
    End Sub
    Public Sub ViewCSTRResource()
        pnlMainDisplay.Hide()
        txtCSTRElement = New TextBox With {
            .Size = New Size(320, 200),
            .Multiline = True
        }
        Me.Controls.Add(txtCSTRElement)
        txtCSTRElement.Location = New Point(30, 30)
        ViewCSTR()
    End Sub
    Public Sub ViewCSTR()
        Dim cviewPointer As Integer
        Dim resourceFilename As String
        Dim tempText As String = ""
        Dim tEnd As Integer
        Dim tempval As Integer
        resourceFilename = LoadedSettings.wimeDIRECTORY & "\" & p_ResourceContainer.resourceFile & ".RES"
        tEnd = EndianChecker(resourceFilename)
        Using readsave As New BinaryFile(resourceFilename)
            cviewPointer = (SelectedResourceItem.fileOffset + 4)
            readsave.Position = cviewPointer
            For i = 0 To SelectedResourceItem.dataSize - 1
                tempval = readsave.ReadByte
                If tempval = 10 Then
                    txtCSTRElement.Text = txtCSTRElement.Text + Environment.NewLine
                Else
                    tempText = Chr(tempval)
                    txtCSTRElement.Text = txtCSTRElement.Text & tempText
                End If
            Next i
        End Using
    End Sub
    Public Sub LoadTile(filename As String, scale As Short, tilenum As Integer)
        Dim dChunkData(TILE_PIXELS) As Byte
        Dim p_resFile As String = ""
        Dim gfxTilePixel As Graphics
        Dim mybrush As SolidBrush
        Dim bmpTileOriginal As Bitmap
        Dim bPix As Byte
        Dim iTileOrigin As Integer
        Dim CHARTile As New Game.resource.tileChunk
        pnlMainDisplay.Hide()
        pbTileView.Size = New Size(16 * scaleFactor, 16 * scaleFactor)
        Me.Controls.Add(pbTileView)
        pbTileView.Location = New Point(30, 30)
        ResourcePalette = New resource.RGBColorList
        p_resFile = TILES
        ResourcePalette = ParseIndex(p_resFile)
        iTileOrigin = LoadedFileOffsets.Tiles
        Dim TileOrigin As Integer = SelectedResourceItem.fileOffset + 4
        If LoadedFile.Name = AMIGA_FORMAT Then
            Game.resource.UnpackAmigaTiles(filename, LoadedSettings.dataDirectory, CHARTile.offset + 8, AMIGA_CHUNK)
            filename = LoadedSettings.dataDirectory & "\Tiles.raw"
        ElseIf LoadedFile.Name = ST_FORMAT Then
            Dim Tilo As Integer = 8042
            Game.resource.UnpackAmigaTiles(filename, LoadedSettings.dataDirectory, Tilo, ST_CHUNK)
            filename = LoadedSettings.dataDirectory & "\Tiles.raw"
            iTileOrigin = 0
        Else

        End If
        Using reader As New BinaryFile(filename)
            Dim b As Integer = 0
            Dim value1 As Byte : Dim value2 As Byte
            reader.Position = ((iTileOrigin) + (128) * tilenum)
            For a As Integer = 0 To ((TILE_PIXELS / 2) - 1)
                bPix = reader.ReadByte
                Nibbler(bPix, value1, value2)
                dChunkData(b) = value1
                b = b + 1
                dChunkData(b) = value2
                b = b + 1
            Next a
            bmpTileOriginal = New Bitmap(16 * scale, 16 * scale)
            gfxTilePixel = Graphics.FromImage(bmpTileOriginal)
            mybrush = New SolidBrush(Color.White)
            Dim intCByte As Integer = 0
            Dim tempCol As Integer
            For yBit As Integer = 0 To (16 * scale) - 1 Step scale
                For xBit As Integer = 0 To (16 * scale) - 1 Step scale
                    tempCol = dChunkData(intCByte)
                    mybrush = New SolidBrush(resource.imageColorNew(tempCol, ResourcePalette))
                    gfxTilePixel.FillRectangle(mybrush, xBit, yBit, (xBit + scale), (yBit + scale))
                    pbTileView.Image = bmpTileOriginal
                    intCByte = intCByte + 1
                Next xBit
            Next yBit
        End Using
    End Sub
    Public Sub SetupFRMLView()
        pnlMainDisplay.Hide()
        pnlFRMLDisplay = New Panel With {
            .Size = New Size((ImageWidth + 106) * scaleFactor, (ImageHeight + 64) * scaleFactor),
            .BackColor = Color.Black
        }
        Me.Controls.Add(pnlFRMLDisplay)
        pnlFRMLDisplay.Location = New Point(30, 30)
    End Sub
    Public Sub ViewFRMLResource()
        Dim p_spriteForm As Form
        Dim p_resource As String = SPRITES
        Dim p_endoffset As Integer
        Dim p_DefaultPaletteValue As String = "0"
        Dim p_resFile As String = ""
        lblSpriteColor.Visible = True
        ddSpriteColor.Visible = True
        SpriteColor = Val(ddSpriteColor.Text)
        ResourcePalette = New RGBColorList
        loadedFRML = New Game.resource.animChunk
        loadedResource = New Game.resource
        loadedFRML.Name = p_ResourceContainer.Name
        loadedResource.Filename = filenameData
        loadedFRML.offset = p_ResourceContainer.fileOffset
        loadedFRML.bitplanes = LoadedFile.FRMLBitplanes
        'MsgBox("LoadedFRML Bitplates " & LoadedFile.FRMLBitplanes)
        'ResourcePalette = LoadPalette(p_resource, loadedGame.format, p_DefaultPaletteValue)
        p_resFile = SelectedResourceItem.resourceFile
        ResourcePalette = ParseIndex(p_resFile)
        If SpriteColor > 0 Then
            ResourcePalette = SpriteChangedColor(SpriteColor, ResourcePalette)
        End If
        p_spriteForm = New frmSpriteDraw(0, ResourcePalette, scaleFactor)
        p_spriteForm.Show()
        p_spriteForm.Hide()
        If lForm = False Then
            SetupFRMLView()
            lForm = True
        End If
        Application.DoEvents()
        p_endoffset = p_ResourceContainer.fileOffset + (p_ResourceContainer.dataSize + 4)
        gameStatus = p_ResourceContainer.Name & ", " & loadedFRML.uncompressed_size & " bytes, (" & p_ResourceContainer.dataSize & " bytes, compressed)" & " @ " & p_ResourceContainer.resourceFile & ".RES" & " (" & p_ResourceContainer.fileOffset & " - " & p_endoffset & ")"
        PopulatorSpriteColor()
        lblGameStatus.Text = gameStatus
    End Sub
    Public Sub PopulatorSpriteColor()
        Dim SpriteSetNumber As Integer = 0
        Dim colorset As List(Of Integer) = New List(Of Integer)
        ddSpriteColor.DropDownItems.Clear()
        SpriteSetNumber = SelectedResourceItem.Number
        'colorset = RetrieveSpriteColors(SpriteSetNumber, LoadedFile.Name)
        colorset = GetSpriteColors(SpriteSetNumber, LoadedFile.Name)

        For x = 0 To colorset.Count - 1
            ddSpriteColor.DropDownItems.Add(colorset(x))
        Next
        ddSpriteColor.Text = SpriteColor
    End Sub



    Public Sub LoadImage(ByVal filename As String, ByVal offset As Integer)
        Using Reader As New BinaryFile(filename)
            Dim OFilePath As String = Application_Path & "\TEMP_IMAG.RAW"
            Dim Unpacker As New ByteRunUnpacker(Reader)
            Dim p_offsetmodifier As Integer
            Dim p_format As String : p_format = LoadedFile.Name
            Dim p_bitplanes As Integer = IMAGView.bitplane
            'MsgBox(Format & " needs bitplane change!" & p_bitplanes)
            If Format = IIGS_FORMAT Or Format = PC_EGA_FORMAT Then p_bitplanes = 4
            Dim Outputfile As New BinaryFile(OFilePath)
            p_offsetmodifier = getIMAGDataOffsetValue(p_format, IMAGView.imagePlane)
            AddressOffset = 4
            Dim value As Integer = p_offsetmodifier
            IMAGView.chunkData = Unpacker.UnpackV2(IMAGView.offset + value, IMAGView.uncompressed_size, IMAGView.canvassWidth, IMAGView.height, p_bitplanes)
            Outputfile.Write(IMAGView.chunkData, 0, IMAGView.chunkData.Length)
            Outputfile.Close()
            Memory = IMAGView.chunkData
            escape = False
            lForm = True
            PaintScreen()
        End Using
    End Sub
    Private Sub PaintScreen()
        If lForm = False Then Exit Sub
        If pnlMainDisplay.BackgroundImage Is Nothing Then
            pnlMainDisplay.BackgroundImageLayout = ImageLayout.None
            pnlMainDisplay.BackgroundImage = New Bitmap(ImageWidth * scaleFactor, ImageHeight * scaleFactor)
        Else
            pnlMainDisplay.BackgroundImage = New Bitmap(ImageWidth * scaleFactor, ImageHeight * scaleFactor)
        End If
        If Memory Is Nothing Then escape = True
        Dim Gr As Graphics = Graphics.FromImage(pnlMainDisplay.BackgroundImage)
        Dim Addr As Integer = 0
        Dim B As Byte
        Dim Nibble As Byte = 0
        Dim X, Y As Integer
        Dim PlaneIndex, BitIndex As Integer
        planeCount = Val(IMAGView.bitplane)
        Dim Planes(planeCount - 1) As Bitplane ' 4 planes for 16 colors (4 bits per pixel)
        Dim PlaneSize As Integer
        Dim Offset, PlaneOffset As Integer
        Dim PixelRect As Rectangle
        Dim Bit As Boolean
        Addr = Addr + AddressOffset
        Gr.Clear(pnlMainDisplay.BackColor)
        If IMAGView.canvassWidth Mod 2 = 0 Then ' Even image width -> a bitplane contains width \ 2 bytes
            PlaneSize = IMAGView.canvassWidth \ 8
        Else ' Even image width -> a bitplane contains (width + 1) \ 2 bytes
            PlaneSize = (IMAGView.canvassWidth + 1) \ 8
        End If
        If IMAGView.bitplane = 0 Then  ' We treat the data as pixels, each in one nibble (half-byte).
            Dim tempFile As String = LoadedSettings.dataDirectory & "\IMAG_TMP2.TMP"
            Using objWriter As New StreamWriter(tempFile, True)
                For Y = 0 To IMAGView.height - 1
                    If escape Then Exit Sub
                    For X = 0 To IMAGView.canvassWidth - 1
                        If escape Then Exit Sub
                        Offset = Addr + (Y * IMAGView.canvassWidth + X) \ 2
                        If Offset <= UBound(Memory) Then
                            B = Memory(Offset)
                        Else
                            B = 0
                        End If
                        If X Mod 2 = 0 Then
                            Nibble = B \ &H10
                        Else
                            Nibble = B Mod &H10
                        End If
                        PixelRect = GetDrawingRectangle(X, Y)
                        Gr.FillRectangle(New SolidBrush(resource.imageColorNew(Nibble, ResourcePalette)), PixelRect)
                        objWriter.Write(Nibble)
                        objWriter.Write(ControlChars.Tab)
                    Next
                    objWriter.WriteLine(ControlChars.Tab)
                Next
            End Using
            pnlMainDisplay.Refresh()
            System.Windows.Forms.Application.DoEvents()
        Else ' Checked -> We treat the data as bitplanes.
            Dim tempFile As String = LoadedSettings.dataDirectory & "\IMAG_TMP2.TMP"
            Using objWriter As New StreamWriter(tempFile, True)
                For Y = 0 To IMAGView.height - 1
                    If escape Then Exit Sub
                    For PlaneIndex = 0 To planeCount - 1 '3
                        PlaneOffset = Addr + Y * PlaneSize * planeCount + PlaneIndex * PlaneSize
                        Planes(PlaneIndex) = New Bitplane(PlaneOffset)
                    Next
                    For X = 0 To IMAGView.canvassWidth - 1
                        If escape Then Exit Sub
                        Nibble = 0
                        For PlaneIndex = 0 To planeCount - 1
                            Bit = Planes(PlaneIndex).Bit(X)
                            SetBit(Nibble, PlaneIndex, Bit)
                        Next
                        PixelRect = GetDrawingRectangle(X + BitIndex, Y)
                        Gr.FillRectangle(New SolidBrush(resource.imageColorNew(Nibble, ResourcePalette)), PixelRect)
                        objWriter.Write(Nibble)
                        objWriter.Write(ControlChars.Tab)
                    Next
                    objWriter.WriteLine(ControlChars.Tab)
                Next
            End Using
        End If
        pnlMainDisplay.Refresh()
        Application.DoEvents()
        escape = True
    End Sub
    Private Function GetDrawingRectangle(ByVal X As Integer, ByVal Y As Integer) As Rectangle
        Dim Result As New Rectangle(0, 0, 0, 0)
        Dim p_tempModifier As Integer
        p_tempModifier = scaleFactor
        If p_tempModifier < 1 Then p_tempModifier = 1
        Result.X = X * p_tempModifier
        Result.Y = Y * p_tempModifier
        Result.Width = p_tempModifier
        Result.Height = p_tempModifier
        Return Result
    End Function
    ' ======================================================================= EVENT HANDLERS =========================================================================
    Private Sub ddScale_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ddScale.DropDownItemClicked
        scaleFactor = Val(e.ClickedItem.Text)
        ddScale.Text = scaleFactor
        If scaleFactor < 1 Then scaleFactor = 1
        escape = False
        If p_ResourceContainer.resourceType = Game.resource.RES_ID_ELEMENTS(4) Then
            pnlMainDisplay.Size = New Size(ImageWidth * scaleFactor, ImageHeight * scaleFactor)
            PaintScreen()
        ElseIf p_ResourceContainer.resourceType = Game.resource.RES_ID_ELEMENTS(0) Then
            ViewCHARResource()
        ElseIf p_ResourceContainer.resourceType = Game.resource.RES_ID_ELEMENTS(3) Then
            RemoveHandler pnlFRMLDisplay.Paint, AddressOf pnlFRMLDisplay_Paint
            pnlFRMLDisplay.Size = New Size(ImageWidth * scaleFactor, ImageHeight * scaleFactor)
            ViewFRMLResource()
            AddHandler pnlFRMLDisplay.Paint, AddressOf pnlFRMLDisplay_Paint
            pnlFRMLDisplay.Refresh()
        End If
    End Sub
    Private Sub pnlFRMLDisplay_Paint(sender As Object, e As PaintEventArgs) Handles pnlFRMLDisplay.Paint
        Dim p_image As Bitmap
        Dim dest_x As Integer = 0 : Dim dest_y As Integer = 0
        Dim p_height_Max As Integer
        Dim p_width_Max As Integer = 0
        Dim p_YOffset As Integer
        p_height_Max = MAX_HEIGHT * scaleFactor
        For x As Integer = 0 To loadedFRML.celQuantity - 1
            p_image = New Bitmap(SpriteList(x))
            p_YOffset = (p_height_Max - (loadedFRML.cel_height(x) * scaleFactor))
            e.Graphics.DrawImage(p_image, dest_x, dest_y + p_YOffset, loadedFRML.cel_canvasswidth(x) * scaleFactor, loadedFRML.cel_height(x) * scaleFactor)
            If dest_x + ((loadedFRML.cel_canvasswidth(x) * scaleFactor)) + ((loadedFRML.cel_canvasswidth(x + 1) * scaleFactor)) > 320 * scaleFactor Then
                dest_x = 0
                dest_y = (dest_y + p_height_Max)
            Else
                dest_x = (dest_x) + (loadedFRML.cel_canvasswidth(x) * scaleFactor)
            End If
        Next x
    End Sub
    Private Sub ddSpriteColor_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ddSpriteColor.DropDownItemClicked
        SpriteColor = Val(e.ClickedItem.Text)
        ddSpriteColor.Text = SpriteColor
        ResourcePalette = SpriteChangedColor(SpriteColor, ResourcePalette)
        RemoveHandler pnlFRMLDisplay.Paint, AddressOf pnlFRMLDisplay_Paint
        ViewFRMLResource()
        AddHandler pnlFRMLDisplay.Paint, AddressOf pnlFRMLDisplay_Paint
        pnlFRMLDisplay.Refresh()
    End Sub
End Class



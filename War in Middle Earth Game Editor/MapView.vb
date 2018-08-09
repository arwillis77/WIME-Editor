'Option Strict On
Imports System.IO
Imports System.Drawing.Image
Imports WIMEEditor.ByteRunUnpacker
Imports WIMEEditor.Game
Imports WIMEEditor.EditorSettings
Imports WIMEEditor.BinaryFile
'Imports WorldMapView.Map
Public Class MapView
    ' MapView for WIME Editor
    ' Public Declarations
    Public Filename As String
    Public MMAPSettings As New EditorSettings
    Public ResourcePalette As resource.RGBColorList
    ' Configuration settings for MMAP
    Public MMAPTiles As New Game.resource.tileChunk                 ' Tile data for MMAP
    Public rawMapFile As String = "WORLDMAP.RAW"
    Public pic As Bitmap
    Public g As Graphics : Dim g2 As Graphics : Dim g3 As Graphics
    Public myBrush As SolidBrush
    Public imageMapTile As ImageList
    Dim dChunkData(TILE_PIXELS) As Byte
    Public tileSize As Integer
    ' LOCAL VARIABLES
    Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & Application.ProductName
    Dim bmp As Bitmap
    Dim b2 As Bitmap
    Public iTileOrigin As Integer
    Private Sub MapView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemoveHandler mapPanel.Paint, AddressOf mapPanel_Paint
        ResourcePalette = New resource.RGBColorList
        MsgBox(TILES & " " & loadedGame.format & "  " & SelectedResourceItem.resourceFile)
        ResourcePalette = LoadPalette(TILES, loadedGame.format, SelectedResourceItem.resourceFile)
        'MMAPPalette = LoadPalette(TILES, loadedGame.format, SelectedResourceItem.resourceFile)
        ' // Transfer settings for MMAP and CHAR resources to local classes
        MMAPTiles = loadedTile
        iTileOrigin = OFFSET_TileStart(loadedGame.formatVal)
        mapPanel.AutoScroll = True
        MMAPSettings = loadConfig(settingsFullFilename)
        ProcessMap()
    End Sub
    Public Sub New(MAP_data As Game.resource.MapChunk)
        ' This call is required by the designer.
        InitializeComponent()
        Filename = MAP_data.filename
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Public Sub ProcessMap()
        Dim inputfile As New BinaryFile(Filename)
        Dim outputfile As New BinaryFile(Application_Path & "\" & rawMapFile)
        Dim unpacker As New ByteRunUnpacker(inputfile)
        Dim result As Byte() = unpacker.Unpack(MMAPSettings.mapFileOffset, loadedMMAP.chunkSize, loadedMMAP.width, loadedMMAP.height, loadedMMAP.planes)
        outputfile.Write(result, 0, result.Length)
        inputfile.Close() : outputfile.Close()
        ExportTile(Filename, loadedGame.format, 1)
        pctMapTile.Hide()
        AddHandler mapPanel.Paint, AddressOf mapPanel_Paint
        Application.DoEvents()
        mapPanel.Refresh()
        saveMap()
    End Sub
    Public Sub ExportTile(filename As String, format As String, size As Integer)
        If format = FORMAT_ID(3) Then
            Dim p_chunk As Integer
            p_chunk = Game.resource.getTileChunk(filename, loadedGame.endianType, OFFSET_TileStart(3) - 4)
            Game.resource.UNPACKAMIGATILES(MMAPSettings.tileFile, MMAPSettings.dataDirectory, OFFSET_TileStart(3) + 4, p_chunk)
            filename = MMAPSettings.dataDirectory & "\Tiles.raw"
            iTileOrigin = 0
        Else
        End If
        Using reader As New BinaryFile(filename)
            Dim tilePTR As Integer = 0
            Dim tileMag = size
            Dim bpix As Byte
            bmp = New Bitmap(loadedMMAP.width, loadedMMAP.height)
            Dim bmptile As Bitmap
            g2 = Graphics.FromImage(bmp)
            g3 = Me.CreateGraphics
            Dim temptilestart As Integer = 43908
            imageMapTile = New ImageList
            For intMapTileCount As Integer = 0 To 256                                           ' Loop through all tiles in file
                Dim b As Integer = 0
                Dim value1 As Byte : Dim value2 As Byte
                reader.Position = ((iTileOrigin) + (128) * intMapTileCount)
                For a As Integer = 0 To ((TILE_PIXELS / 2) - 1)
                    bpix = reader.ReadByte
                    Nibbler(bpix, value1, value2)
                    dChunkData(b) = value1
                    b = b + 1
                    dChunkData(b) = value2
                    b = b + 1
                Next a
                pic = New Bitmap(16 * tileMag, 16 * tileMag)
                g = Graphics.FromImage(pic)
                myBrush = New SolidBrush(Color.White)
                Dim tempCol As Integer
                Dim intCByte As Integer = 0
                For yBit As Integer = 0 To ((16 * tileMag) - 1) Step tileMag
                    For xBit As Integer = 0 To ((16 * tileMag) - 1) Step tileMag
                        tempCol = dChunkData(intCByte)
                        myBrush = New SolidBrush(resource.imageColorNew(tempCol, ResourcePalette))
                        g.FillRectangle(myBrush, xBit, yBit, (xBit + tileMag), (yBit + tileMag))
                        pctMapTile.Image = pic
                        intCByte = intCByte + 1
                    Next xBit
                Next yBit
                imageMapTile.Images.Add(pctMapTile.Image)
            Next intMapTileCount
            Dim ResWidth = (80 * tileMag) + 5
            Dim ResHeight = (832 * tileMag) + 52
            b2 = New Bitmap(ResWidth, ResHeight)
            g2 = Graphics.FromImage(b2)
            g3 = Me.CreateGraphics
            MMAPTiles.Size = (16 * tileMag)
            MMAPTiles.width = (16 * tileMag)
            MMAPTiles.height = (16 * tileMag)
            MMAPTiles.PositionX = 0
            MMAPTiles.PositionY = 0
            For x = 0 To TILE_TOTAL
                If MMAPTiles.PositionX >= (ResWidth - 1) Then
                    MMAPTiles.PositionY = MMAPTiles.PositionY + (16 * tileMag) + 1
                    MMAPTiles.PositionX = 0
                ElseIf MMAPTiles.PositionX = 0 And Not MMAPTiles.PositionY = 0 Then
                    MMAPTiles.PositionY = MMAPTiles.PositionY + 1
                End If
                If Not MMAPTiles.PositionX = 0 Then
                    MMAPTiles.PositionX = MMAPTiles.PositionX + 1
                End If
                bmptile = imageMapTile.Images(x)
                g2.DrawImage(bmptile, MMAPTiles.PositionX, MMAPTiles.PositionY, MMAPTiles.width, MMAPTiles.height)
                MMAPTiles.PositionX = MMAPTiles.PositionX + (16 * tileMag)
                pctTileSet.Image = b2
            Next
        End Using

    End Sub
    Private Sub mapPanel_Paint(sender As Object, e As PaintEventArgs) Handles mapPanel.Paint
        MMAPSettings = loadConfig(settingsFullFilename)
        Dim mapX As Integer = 0 : Dim mapY As Integer = 0
        Dim timage As Image
        Dim tempByte As Integer
        Dim filePTR As Long = 0
        Dim mapTileSize = 16
        Dim filename As String = Application_Path & "\" & rawMapFile
        Using resReader As New BinaryFile(filename)
            For i As Integer = 0 To 98
                Do
                    resReader.Position = filePTR
                    tempByte = resReader.ReadByte
                    timage = imageMapTile.Images(tempByte)
                    e.Graphics.DrawImage(timage, mapX, mapY, mapTileSize, mapTileSize)
                    mapX = mapX + 16

                    filePTR = filePTR + 1
                Loop Until (mapX / 16) >= 160
                mapY = mapY + 16
                mapX = 0
            Next i
        End Using
    End Sub
    Public Sub saveMap()
        Dim panelBitmap As New Bitmap(mapPanel.Width, mapPanel.Height)
        mapPanel.DrawToBitmap(panelBitmap, mapPanel.ClientRectangle)
        RemoveHandler mapPanel.Paint, AddressOf mapPanel_Paint
        mapPanel.BackgroundImage = panelBitmap
    End Sub
End Class

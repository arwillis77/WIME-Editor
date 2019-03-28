Imports System
Imports System.IO
Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports WIMEEditor.BinaryFile
Imports WIMEEditor.ByteRunUnpacker
Imports WIMEEditor.Game
Imports WIMEEditor.EditorSettings
Public Class frmMapIcon
    Const IMAGE_MULTIPLIER As UShort = 3
    Const SPRITE_SIZE As UShort = 48
    Dim escape As Boolean
    Public addressOffset As UShort
    Public planeCount As Integer
    Public LForm As Boolean
    Public Imagview As New Game.resource.ImageChunk
    Public ResourcePalette As New resource.RGBColorList
    Dim p_resource As String = IMAGES
    Private Sub frmMapIcon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadedSettings = LoadConfig(settingsFullFilename)
        Dim p_resfilename As String
        Dim p_resfilecut As String

        Dim p_contain As New Game.resource.ResourceDetails
        Dim p_endoffset As Integer
        ResourcePalette = New resource.RGBColorList
        Try
            addressOffset = 4
            p_contain = SelectedResourceItem
            p_resfilecut = p_contain.resourceFile & ".res"
            p_resfilename = LoadedSettings.wimeDIRECTORY & "\" & p_resfilecut
            p_endoffset = p_contain.fileOffset + (p_contain.dataSize + 4)
            Imagview = GetIMAGChunk(p_resfilename, LoadedFile.Name, p_contain.fileOffset, LoadedFile.Endian)
            ResourcePalette = ParseIndex(p_resfilecut)
            LoadMapIcons(p_resfilename, Imagview.offset)
            CutMapIcons()
            LForm = False
        Catch ex As Exception
            MsgBox("PROGRAM ERROR!  LOCATION: Form_Load in frmMapicon. " & vbLf & vbLf & ex.ToString)
        End Try
    End Sub
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        LForm = False
        escape = False
    End Sub
    Public Sub LoadMapIcons(ByVal filename As String, ByVal offset As Integer)

        Try
            Using reader As New BinaryFile(filename)
                Dim Unpacker As New ByteRunUnpacker(reader)
                Dim p_offsetmodifier As Integer
                Dim p_format As String : p_format = LoadedFile.Name

                p_offsetmodifier = getIMAGDataOffsetValue(p_format, Imagview.imagePlane)
                addressOffset = LoadedFileOffsets.BannerIcons
                If Imagview.canvassWidth > 255 Then addressOffset = 5
                Dim value As Integer = p_offsetmodifier
                Imagview.chunkData = Unpacker.Unpack(Imagview.offset + value, Imagview.uncompressed_size, Imagview.canvassWidth, Imagview.height, 4)
                Memory = Imagview.chunkData
                escape = False
                LForm = True
                PaintScreen()
            End Using
        Catch ex As Exception
            MsgBox("PROGRAM ERROR!  LOCATION: LoadMapIcons in frmMapicon. " & vbLf & vbLf & ex.ToString)
        End Try

    End Sub
    Private Sub PaintScreen()
        If LForm = False Then Exit Sub
        If pnlImagView.BackgroundImage Is Nothing Then
            pnlImagView.BackgroundImage = New Bitmap(250, 298)
        End If
        If Memory Is Nothing Then escape = True
        Dim Gr As Graphics = Graphics.FromImage(pnlImagView.BackgroundImage)
        Dim Addr As Integer = 0
        Dim B As Byte
        Dim Nibble As Byte = 0
        Dim X, Y As Integer
        Dim PlaneIndex, BitIndex As Integer
        planeCount = Imagview.bitplane
        'If Not planeCount = 0 Then checkBitplanes.Checked = True
        Dim Planes(planeCount - 1) As Bitplane ' 4 planes for 16 colors (4 bits per pixel)
        Dim PlaneSize As Integer
        Dim Offset, PlaneOffset As Integer
        Dim PixelRect As Rectangle
        Dim Bit As Boolean
        Addr = Addr + addressOffset
        Gr.Clear(pnlImagView.BackColor)
        If Imagview.canvassWidth Mod 2 = 0 Then ' Even image width -> a bitplane contains width \ 2 bytes
            PlaneSize = Imagview.canvassWidth \ 8
        Else ' Even image width -> a bitplane contains (width + 1) \ 2 bytes
            PlaneSize = (Imagview.canvassWidth + 1) \ 8
        End If
        If Imagview.bitplane = 0 Then  ' We treat the data as pixels, 
            '                              each in one nibble (half-byte).
            Dim tempFile As String = LoadedSettings.dataDirectory & "\IMAG_TMP2.TMP"
            Using objWriter As New StreamWriter(tempFile, True)

                For Y = 0 To Imagview.height - 1
                    If escape Then Exit Sub
                    For X = 0 To Imagview.canvassWidth - 1
                        If escape Then Exit Sub
                        Offset = Addr + (Y * Imagview.canvassWidth + X) \ 2
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
            pnlImagView.Refresh()
            System.Windows.Forms.Application.DoEvents()
        Else ' Checked -> We treat the data as bitplanes.
            Dim tempFile As String = LoadedSettings.dataDirectory & "\IMAG_TMP2.TMP"
            Using objWriter As New StreamWriter(tempFile, True)
                For Y = 0 To Imagview.height - 1
                    If escape Then Exit Sub
                    For PlaneIndex = 0 To planeCount - 1 '3
                        PlaneOffset = Addr + Y * PlaneSize * planeCount + PlaneIndex * PlaneSize
                        Planes(PlaneIndex) = New Bitplane(PlaneOffset)
                    Next
                    For X = 0 To Imagview.canvassWidth - 1
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
        'txtPlaneSize.Text = PlaneSize
        pnlImagView.Refresh()
        Application.DoEvents()
        escape = True
    End Sub
    Public Sub CutMapIcons()
        Dim SourceBMP As New Bitmap(pnlImagView.BackgroundImage)
        Dim p_DestinationBMP As New Bitmap(48, 48)
        Dim p_RectangleCapture As Rectangle
        Dim x, y, x_max, y_max As UShort
        MapIcons = New ImageList
        Try
            x = 0 : y = 0 : x_max = Imagview.width * IMAGE_MULTIPLIER : y_max = Imagview.height * IMAGE_MULTIPLIER
            MapIcons.ImageSize = New Size(SPRITE_SIZE, SPRITE_SIZE)
            MapIcons.TransparentColor = SourceBMP.GetPixel(0, 0)
            For i As Integer = 0 To 29
                p_RectangleCapture = New Rectangle(x, y, SPRITE_SIZE, SPRITE_SIZE)
                p_DestinationBMP = CopyBitmap(SourceBMP, p_RectangleCapture)
                MapIcons.Images.Add(p_DestinationBMP)
                y = y + SPRITE_SIZE
                If y >= y_max Then
                    x = x + SPRITE_SIZE : y = 0
                End If
            Next i
        Catch ex As Exception
            MsgBox("PROGRAM ERROR!  LOCATION: CutMapIcons in frmMapicon. " & vbLf & vbLf & ex.ToString)
        End Try

    End Sub
    Overloads Function CopyBitmap(source As Bitmap, part As Rectangle) As Bitmap
        Dim bmp As New Bitmap(part.Width, part.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.DrawImage(source, 0, 0, part, GraphicsUnit.Pixel)
        g.Dispose()
        Return bmp
    End Function
    Private Function GetDrawingRectangle(ByVal X As Integer, ByVal Y As Integer) As Rectangle
        Dim Result As New Rectangle(0, 0, 0, 0)
        Dim p_tempModifier As Integer
        p_tempModifier = 3
        If p_tempModifier < 1 Then p_tempModifier = 1
        Result.X = X * p_tempModifier
        Result.Y = Y * p_tempModifier
        Result.Width = p_tempModifier
        Result.Height = p_tempModifier
        Return Result
    End Function
    Private Function CalculateCanvasWidth(ClipWidth As Integer) As Integer
        Dim Modulus As Integer, Result As Integer
        Modulus = ClipWidth Mod 16
        Result = (ClipWidth \ 16) * 16
        If Modulus > 0 Then
            Result = Result + 16
        End If
        Return Result
    End Function
End Class
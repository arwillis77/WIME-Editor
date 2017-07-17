Imports System
Imports System.IO
Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports WIMEEditor.BinaryFile
Imports WIMEEditor.ByteRunUnpacker
Imports WIMEEditor.Game
Imports WIMEEditor.Game.resource
Imports WIMEEditor.EditorSettings
Public Class frmSpriteDraw
    Dim Escape As Boolean
    Private paletteColor As Integer
    Private PaletteList As resource.RGBColorList
    ' Declare Paint Event Complete flag.  
    Public planeCount As Integer = 0
    Public stripFilename As String
    Const DEFAULT_FORMAT_VAL = 0
    Public LForm As Boolean = False
    Public First_Flag As Boolean = True
    Public sprite_draw As Boolean
    Public gameLoaded As Boolean = False
    Public Sprite_Strip As Boolean = False
    Public oFiletext As String = Application_Path & "\tempFRML" & ".RAW"
    Public Sprite_Sheet_FRML As New Game.resource.animChunk
    Public SIZE_MULTIPLIER As Integer
    Private Sub frmSpriteDraw_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim p_tempPaletteName As String = ""
        Dim p_pal As String = paletteColor
        Dim p_path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & Application.ProductName
        Escape = False
        ResourcePalette = New RGBColorList
        ResourcePalette = PaletteList
        ViewFRML()
    End Sub
    Public Sub New(paletteValue As Integer, colorlist As resource.RGBColorList, scale As Integer)
        InitializeComponent()
        Me.paletteColor = paletteValue
        Me.PaletteList = colorlist
        SIZE_MULTIPLIER = scale
    End Sub

    Private Sub FRML_PaintScreen(ByVal fwidth As Integer, ByVal fheight As Integer)
        Try
            If LForm = False Then Exit Sub
            If Memory Is Nothing Then Escape = True
            Dim Gr As Graphics = Graphics.FromImage(pnlSpriteView.BackgroundImage)
            Dim Addr As Integer = 0
            Dim B As Byte
            Dim Nibble As Byte = 0
            Dim X, Y As Integer
            Dim PlaneIndex, BitIndex As Integer
            planeCount = loadedFRML.bitplanes
            Dim Planes(planeCount - 1) As Bitplane ' 4 planes for 16 colors (4 bits per pixel)
            Dim PlaneSize As Integer
            Dim Offset, PlaneOffset As Integer
            Dim PixelRect As Rectangle
            Dim Bit As Boolean
            Addr = Addr + address_offset
            If First_Flag = True Then
                Gr.Clear(pnlSpriteView.BackColor)
                First_Flag = False
            End If
            If fwidth Mod 2 = 0 Then ' Even image width -> a bitplane contains width \ 2 bytes
                PlaneSize = fwidth \ 8
            Else ' Even image width -> a bitplane contains (width + 1) \ 2 bytes
                PlaneSize = (fwidth + 1) \ 8
            End If
            If loadedFRML.bitplanes = 0 Then ' We treat the data as pixels, each in one nibble (half-byte).
                For Y = 0 To fheight - 1
                    If Escape Then Exit Sub
                    For X = 0 To fwidth - 1
                        If Escape Then Exit Sub
                        Offset = Addr + (Y * fwidth + X) \ 2
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
                        Gr.FillRectangle(New SolidBrush(imageColorNew(Nibble, ResourcePalette)), PixelRect)
                    Next
                Next
            Else ' Checked -> We treat the data as bitplanes.
                For Y = 0 To fheight - 1
                    If Escape Then Exit Sub
                    For PlaneIndex = 0 To planeCount - 1 '3
                        PlaneOffset = Addr + Y * PlaneSize * planeCount + PlaneIndex * PlaneSize
                        Planes(PlaneIndex) = New Bitplane(PlaneOffset)
                    Next
                    For X = 0 To fwidth - 1
                        If Escape Then Exit Sub
                        Nibble = 0
                        For PlaneIndex = 0 To planeCount - 1
                            Bit = Planes(PlaneIndex).Bit(X)
                            SetBit(Nibble, PlaneIndex, Bit)
                        Next
                        PixelRect = GetDrawingRectangle((X + BitIndex), Y)
                        Gr.FillRectangle(New SolidBrush(imageColorNew(Nibble, ResourcePalette)), PixelRect)
                    Next
                Next
            End If
        Catch ex As Exception
            MsgBox("frmFRMLView Error in FRMLPaint routine.  " & ex.ToString)
            Exit Sub
        End Try
        pnlSpriteView.Refresh()
        Application.DoEvents()
        Escape = True
    End Sub
    Private Sub ViewFRML()
        Dim p_temp_filepointer As Integer = 0                                   ' Set file pointer to BOF
        Dim p_xval As UShort = 0 : Dim p_yval As UShort = 0         ' Variables for source x and y
        Dim p_width As UShort = 0 : Dim p_height As UShort = 0  ' Variables for width and height of cel groups.
        Dim p_value As Integer
        Dim p_dataEndian As Integer : p_dataEndian = DATA_ENDIAN(loadedGame.formatVal)
        Dim p_rectangle_capture As Rectangle
        Dim p_destination_bmp As Bitmap
        ResetSpriteDrawingArea()
        SpriteList = New List(Of Bitmap)                               ' Create new instance of Sprite Cels Imagelist
        MAX_HEIGHT = 0
        ProcessFRMLData(loadedResource.Filename, loadedFRML.offset, loadedGame.endianType, p_dataEndian)
        Memory = loadedFRML.chunkData
        SaveFRMLChunktoFile()
        For g As Integer = 0 To loadedFRML.celQuantity - 1
            If g = 1 Then
                p_value = loadedFRML.ResourceKey(g, 0)
                p_temp_filepointer = p_value - loadedFRML.ResourceKey(g - 1, 0)
            ElseIf g > 1 Then
                p_value = loadedFRML.ResourceKey(g, 0) - loadedFRML.ResourceKey(0, 0)
                p_temp_filepointer = p_value
            End If
            Dim tempCanvaswidth As Integer
            tempCanvaswidth = CalculateCanvasWidth(loadedFRML.ResourceKey(g, 3))
            ' if not, then break byte array and display.
            p_width = tempCanvaswidth
            If MAX_HEIGHT < p_height Then
                MAX_HEIGHT = p_height
            End If
            p_height = loadedFRML.cel_height(g)
            If MAX_HEIGHT < p_height Then
                MAX_HEIGHT = p_height
            End If
            Escape = False
            LForm = True
            Memory = convertImageFiletoBytes(oFiletext, p_temp_filepointer, loadedFRML.ResourceKey(g + 1, 0))
            FRML_PaintScreen(p_width, p_height)
            Dim sourcebmp As New Bitmap(pnlSpriteView.BackgroundImage)
            If loadedFRML.Name = "FRML 3" Then
                If g = 1 Then
                    p_width = p_width - 8
                End If


            End If

            If loadedFRML.Name = "FRML 4" Then
                If p_width = 48 Then
                    p_width = p_width - 8
                End If
            End If
            p_rectangle_capture = New Rectangle(p_xval, p_yval, p_width * SIZE_MULTIPLIER, p_height * SIZE_MULTIPLIER)
            p_destination_bmp = New Bitmap(p_width * SIZE_MULTIPLIER, p_height * SIZE_MULTIPLIER)
            p_destination_bmp = CopyBitmap(sourcebmp, p_rectangle_capture)
            SpriteList.Add(p_destination_bmp)
        Next g
        sprite_draw = True
        Escape = True
        Sprite_Sheet_FRML = loadedFRML
        pnlSpriteView.Refresh()
    End Sub
    Public Function convertImageFiletoBytes(ByVal imagefilepath As String, ByVal start As Long, ByVal _numbytes As Long) As Byte()
        Dim _tempByte() As Byte = Nothing
        If String.IsNullOrEmpty(imagefilepath) = True Then
            Throw New ArgumentNullException("Image File Name Cannot be Null or Empty", "ImageFilePath")
            Return Nothing
        End If
        Try
            Dim _fileInfo As New IO.FileInfo(imagefilepath)
            Dim _FStream As New IO.FileStream(imagefilepath, IO.FileMode.Open, IO.FileAccess.Read)
            Dim _BinaryReader As New IO.BinaryReader(_FStream)
            _FStream.Position = start
            _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_numbytes))
            _fileInfo = Nothing
            _numbytes = 0
            _FStream.Close()
            _FStream.Dispose()
            _BinaryReader.Close()
            Return _tempByte
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Overloads Function CopyBitmap(source As Bitmap, part As Rectangle) As Bitmap
        Dim bmp As New Bitmap(part.Width, part.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.DrawImage(source, 0, 0, part, GraphicsUnit.Pixel)
        g.Dispose()
        Return bmp
    End Function
    Private Sub ResetSpriteDrawingArea()
        If pnlSpriteView.BackgroundImage Is Nothing Then
            pnlSpriteView.BackgroundImage = New Bitmap(320 * 3, 200 * 3)
        End If
    End Sub
    Private Sub SaveFRMLChunktoFile()
        Dim Outputfile As New BinaryFile(oFiletext)
        Outputfile.Write(loadedFRML.chunkData, 0, loadedFRML.chunkData.Length)
        Outputfile.Close()
    End Sub
    Private Function GetDrawingRectangle(ByVal X As Integer, ByVal Y As Integer) As Rectangle
        Dim Result As New Rectangle(0, 0, 0, 0)
        Dim p_tempModifier As Integer
        p_tempModifier = SIZE_MULTIPLIER
        If p_tempModifier < 1 Then p_tempModifier = 1
        Result.X = X * p_tempModifier
        Result.Y = Y * p_tempModifier
        Result.Width = p_tempModifier
        Result.Height = p_tempModifier
        Return Result
    End Function
End Class
Imports System.Xml

Public Class Form1

    Public Structure tilemapStruct
        Public tilenum As Integer
        Public data1 As String
        Public collidable As Boolean
    End Structure

    Public Structure keyStates
        Public up, down, left, right As Boolean
    End Structure

    Const COLUMNS As Integer = 5
    Private bmpTiles As Bitmap
    Private bmpSurface As Bitmap
    Private pbSurface As PictureBox
    Private gfxSurface As Graphics
    Private fontArial As Font
    Private tilemap() As tilemapStruct
    Private scrollPos As New PointF(0, 0)
    Private oldScrollPos As New PointF(-1, -1)
    Private keyState As keyStates
    Private WithEvents timer1 As Timer


    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        bmpSurface.Dispose()
        pbSurface.Dispose()
        gfxSurface.Dispose()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Smooth Scroller"
        Me.Size = New Point(800 + 16, 600 + 38)

        REM create tilemap
        ReDim tilemap(128 * 128)

        REM set up level drawing surface
        bmpSurface = New Bitmap(800, 600)

        pbSurface = New PictureBox()
        pbSurface.Parent = Me
        pbSurface.BackColor = Color.Black
        pbSurface.Dock = DockStyle.Fill
        pbSurface.Image = bmpSurface
        gfxSurface = Graphics.FromImage(bmpSurface)

        REM create font
        fontArial = New Font("Arial Bold", 18)

        REM load tiles bitmap
        bmpTiles = New Bitmap("WIMETileSet32.png")

        REM load the tilemap
        loadTilemapFile("WIMEWORLD.MAP")

        timer1 = New Timer()
        timer1.Interval = 20
        timer1.Enabled = True
    End Sub

    Private Sub loadTilemapFile(ByVal filename As String)
        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load(filename)
            Dim nodelist As XmlNodeList = doc.GetElementsByTagName("tiles")
            For Each node As XmlNode In nodelist

                Dim element As XmlElement = node

                Dim index As Integer = 0
                Dim value As Integer = 0
                Dim data1 As String = ""
                Dim collidable As Boolean = False

                REM read tile index #
                index = Convert.ToInt32(element.GetElementsByTagName("tile")(0).InnerText)

                REM read tilenum
                value = Convert.ToInt32(element.GetElementsByTagName("value")(0).InnerText)

                REM read data1
                data1 = Convert.ToString(element.GetElementsByTagName("data1")(0).InnerText)

                REM read collidable
                collidable = Convert.ToBoolean(element.GetElementsByTagName("collidable")(0).InnerText)

                tilemap(index).tilenum = value
                tilemap(index).data1 = data1
                tilemap(index).collidable = collidable
            Next

        Catch es As Exception
            MessageBox.Show(es.Message)
        End Try

    End Sub

    Private Sub drawTilemap()
        Dim tilenum, sx, sy As Integer

        If scrollPos <> oldScrollPos Then
            For x = 0 To 24
                For y = 0 To 18
                    sx = scrollPos.X + x
                    sy = scrollPos.Y + y
                    tilenum = tilemap(sy * 128 + sx).tilenum
                    drawTileNumber(x, y, tilenum)
                Next
            Next

            oldScrollPos = scrollPos
        End If

    End Sub

    Public Sub drawTileNumber(ByVal x As Integer, ByVal y As Integer, ByVal tile As Integer)
        REM draw tile
        Dim sx As Integer = (tile Mod COLUMNS) * 33
        Dim sy As Integer = (tile \ COLUMNS) * 33
        Dim src As New Rectangle(sx, sy, 32, 32)
        Dim dx As Integer = x * 32
        Dim dy As Integer = y * 32
        gfxSurface.DrawImage(bmpTiles, dx, dy, src, GraphicsUnit.Pixel)

        REM save changes
        pbSurface.Image = bmpSurface
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case (e.KeyCode)
            Case Keys.Up, Keys.W : keyState.up = True
            Case Keys.Down, Keys.S : keyState.down = True
            Case Keys.Left, Keys.A : keyState.left = True
            Case Keys.Right, Keys.D : keyState.right = True
        End Select
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case (e.KeyCode)
            Case Keys.Escape : End
            Case Keys.Up, Keys.W : keyState.up = False
            Case Keys.Down, Keys.S : keyState.down = False
            Case Keys.Left, Keys.A : keyState.left = False
            Case Keys.Right, Keys.D : keyState.right = False
        End Select
    End Sub

    Private Sub timer1_tick() Handles timer1.Tick

        If keyState.up Then
            scrollPos.Y -= 0.2
            If scrollPos.Y < 0 Then scrollPos.Y = 0
        End If
        If keyState.down Then
            scrollPos.Y += 1
            If scrollPos.Y > 127 - 18 Then scrollPos.Y = 127 - 18
        End If
        If keyState.left Then
            scrollPos.X -= 1
            If scrollPos.X < 0 Then scrollPos.X = 0
        End If
        If keyState.right Then
            scrollPos.X += 1
            If scrollPos.X > 127 - 24 Then scrollPos.X = 127 - 24
        End If

        drawTilemap()

        Dim text As String = "Scroll " + scrollPos.ToString()
        gfxSurface.DrawString(text, fontArial, Brushes.White, 10, 10)
    End Sub

End Class

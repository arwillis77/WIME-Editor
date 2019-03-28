Public Class FileFormat
    Public Const PC_VGA_EXE = "START.EXE"
    Public Const PC_EGA_EXE = "LORD.EXE"
    Public Const IIGS_EXE = "EARTH.SYS16"
    Public Const AMIGA_EXE = "WARINMIDDLEEARTH"
    Public Const ST_EXE = "COMMAND.PRG"
    Public Const PC_VGA_FORMAT = "VGA"
    Public Const PC_EGA_FORMAT = "EGA"
    Public Const IIGS_FORMAT = "IIGS"
    Public Const AMIGA_FORMAT = "AMIGA"
    Public Const ST_FORMAT = "ST"

    Public Name As String
    Public Endian As Integer
    Public DataEndian As Integer
    Public ExecutableFile As String
    Public Icon As System.Drawing.Image
    Public BitPlanes As Integer
    Public FRMLBitplanes As Integer

    Public Sub New()

    End Sub

    Public Sub New(name As String, de As Integer, endy As Integer, exe As String, icon As System.Drawing.Image, bp As Integer, fbp As Integer)
        Me.Name = name
        Me.Endian = endy
        Me.DataEndian = de
        Me.ExecutableFile = exe
        Me.Icon = icon
        Me.BitPlanes = bp
        Me.FRMLBitplanes = fbp
    End Sub


End Class
Public Class OffsetValues
    Public FileFormat As String
    Public BannerIcons As Integer
    Public Tiles As Integer
    Public EXECharacterName As Integer
    Public EXECharacterData As Integer
    Public EXECityName As Integer
    Public EXECityData As Integer
    Public EXEInventoryName As Integer
    Public EXECharacterValue As Integer
    Public EXEDifferenceOffset As Integer

    Public Sub New()

    End Sub

    Public Sub New(format As String, bi As Integer, tile As Integer, exn As Integer, exd As Integer, ecn As Integer, ecd As Integer, ein As Integer, ecv As Integer, edo As Integer)
        Me.FileFormat = format
        Me.BannerIcons = bi
        Me.Tiles = tile
        Me.EXECharacterName = exn
        Me.EXECharacterData = exd
        Me.EXECityName = ecn
        Me.EXECityData = ecd
        Me.EXEInventoryName = ein
        Me.EXECharacterValue = ecv
        Me.EXEDifferenceOffset = edo

    End Sub
End Class
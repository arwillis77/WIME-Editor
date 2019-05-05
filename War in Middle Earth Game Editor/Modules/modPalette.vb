Imports WIMEEditor.PaletteData
Imports WIMEEditor.Game
Module modPalette
    ' // modPalette -- Palette Module
    '//
    '//  Module is a container for Arrays, methods, and variables related to the game palettes.
    '//  Contains Four master palettes; for VGA/EGA versions, IIGS versions, Amiga versions, and the ST version.
    '//  Each version has arrays for the different palettes in the resource files.  The arrays contain index numbers in integer format.
    '//  Each index refers to a hex value in the master palette which is just the RGB values in hex.
    Public WIMEMasterPaletteSet As List(Of MasterPalettes) = New List(Of MasterPalettes) From
        {New MasterPalettes(PC_VGA_FORMAT, New List(Of String) From
        {"000000", "868686", "555555", "755555", "EBAA86", "204110", "306510", "659655", "5586FF", "86BAFF", "CB0041", "FFFFFF", "00FFFF", "DB75CB", "65BA00", "EBEBBA", "FFFFDB",       ' 01-16
         "101010", "100000", "BA0000", "864120", "AA6541", "553020", "414141", "554141", "755541", "756555", "757565", "757575", "967565", "968665", "AA7586", "969686",         ' 17-32
         "BA9675", "BAAA86", "BAAA96", "DBBA86", "CBBAAA", "EBCB96", "EBDBAA", "EBDBBA", "FFEBBA", "FFFFBA", "FFDBCB", "CB2010", "DB3020", "EBCBAA", "960000", "412065",       ' 33-48
         "416565", "759641", "AACB75", "415520", "657520", "0041BA", "2075CB", "55AAEB", "86DBFF", "DBAA30", "EBEB65", "102020", "554141", "CB0000", "AA20AA", "DB86DB",       ' 49-64
         "8696AA", "CBDBEB", "BA5500", "EB7500", "411000", "753010", "966541", "CB9665", "DB8665", "FFCB86", "0000AA", "00AA00", "00AAAA", "AA0000", "AA00AA", "AA5500",       ' 65 - 80
         "AAAAAA", "555555", "5555AA", "55FF55", "55AAAA", "FF5555", "FFFF55"}),
        New MasterPalettes(PC_EGA_FORMAT, New List(Of String) From
        {"000000", "0000AA", "00AA00", "00AAAA", "AA0000", "AA00AA", "AA5500", "AAAAAA", "555555", "5555AA", "55FF55", "55AAAA", "FF5555", "000000", "FFFF55", "FFFFFF"}),
        New MasterPalettes(IIGS_FORMAT, New List(Of String) From
        {"000000", "DDCCAA", "990000", "CC0000", "8899AA", "333333", "779944", "445522", "441100", "773311", "22AAEE", "0044BB", "AA4408", "002222", "EE9900", "442266", "FFFFBB",             '01 - 16
         "888888", "FFFFDD", "442222", "886666", "666644", "998866", "663300", "884422", "CCAAAA", "FF0000", "444444", "EEEEAA", "EEEECC", "884422", "AA6644", "553322",             '17-32
         "775544", "997766", "FFDDCC", "CC2211", "DD3322", "BB0000", "110000", "554444", "777777", "555555", "111111", "544040", "8990A0", "CDD0E0", "B55000", "E77000",             ' 33-48
         "E77000", "966040", "C99060", "CB0041"}),
        New MasterPalettes(AMIGA_FORMAT, New List(Of String) From
        {"000000", "8C268C", "525552", "735552", "EFAA8C", "214510", "316510", "639A52", "528AFF", "8CBAFF", "CE0042", "FFFFFF", "00FFFF", "DE75CE", "63BA00", "EFEFBD", "AA7788",      ' 1- 16
         "BB8899", "FFFFBB", "777766", "FFFFDD", "999988", "EEDDAA", "FFEEBB", "998866", "BBAA88", "EEDDBB", "DDBB88", "EECC99", "BB9977", "776655", "CCBBAA", "884422",      '17-32   
         "AA6644", "553322", "775544", "997766", "FFDDCC", "CC2211", "DD3322", "BB0000", "110000", "554444", "777777", "555555", "444444", "111111", "2175CE", "DECFAD",      '33-48
         "CEDFEF", "21AAEF", "422063", "426563", "739A42", "ADCF73", "425521", "637521", "0045BD", "DEAA31", "8CDFFF", "EFEF63", "102021", "524542", "9C0000", "CE0000",      '49-64
         "AD20AD", "DE8ADE", "8C9AAD", "CEDFEF", "DE8A63", "EF7500", "421000", "733010", "9C6542", "CE9A63", "DE8A63", "FFCF8C", "9C1E1E", "BD5500"}),                        '65-78
        New MasterPalettes(ST_FORMAT, New List(Of String) From
        {"000000", "DDCCAA", "FFFFBB", "888888", "FFFFDD", "442222", "886666", "605640", "998866", "663300", "884422", "CCAAAA", "FF0000", "444444", "E0E0A0", "EEEECC", "AA6644",
         "553322", "775544", "997766", "FFDDCC", "CC2211", "DD3322", "BB0000", "110000", "554444", "777777", "555555", "444444", "111111", "C0C0A0", "406020", "CC0000",
         "8899AA", "406060", "608040", "400000", "602000", "20A0E0", "0040A0", "C08060", "002222", "EE9900", "442266"})
        }
    Class MasterPalettes
        Public Property FileFormat As String
        Public Property PaletteData As List(Of String)
        Public Sub New()
        End Sub
        Public Sub New(value As String, ol As List(Of String))
            FileFormat = value
            PaletteData = ol
        End Sub
    End Class

    ' Palette Color Index Arrays --- indexed to MasterPalette Array
    ' VGA Palette Index
    Public VGAAMAPPalette() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
    Public VGATitlePalette() As Integer = {0, 16, 17, 18, 19, 20, 21, 22, 23, 24, 2, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45}
    Public VGAAPalette() As Integer = {0, 46, 55, 56, 48, 49, 50, 51, 52, 53, 69, 70, 71, 57, 58, 59, 60, 61, 47, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74}
    Public VGABPalette() As Integer = {0, 46, 55, 56, 48, 49, 50, 51, 52, 61, 54, 55, 56, 57, 58, 59, 60, 61, 47, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74}
    Public VGATilePalette() As Integer = {0, 8, 6, 7, 10, 13, 3, 1, 2, 9, 14, 12, 10, 0, 4, 15}
    Public VGAStandardSpritePalette() As Integer = {0, 46, 14, 12, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 47, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74}
    'EGA Palette Index
    Public EGAPalette() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
    'IIGS Palette Index
    Public GSStandard() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
    Public GSTitlePalette() As Integer = {0, 1, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44}
    Public GSStandardSpritePalette() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 44, 2, 1, 53, 45, 46, 47, 48, 49, 7, 50, 51, 52, 8, 0}
    'Amiga Palette Index
    Public AmigaStandardPalette() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
    Public AmigaTitle() As Integer = {16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46}
    Public AmigaScene() As Integer = {47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 57, 58, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77}
    Public AmigaStandardSpritePalette() As Integer = {0, 68, 76, 48, 51, 52, 53, 58, 55, 56, 57, 47, 71, 67, 60, 76, 61, 62, 63, 64, 65, 62, 67, 68, 78, 70, 71, 72, 73, 74, 75, 54}
    'ST Palette Index
    Public STAfile = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 8, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29}
    Public STBCFile = {0, 30, 31, 32, 33, 34, 35, 31, 36, 37, 38, 39, 40, 41, 42, 43}
    ' Set Palette List Objects
    Public LoadedPalette As New List(Of Pal_Set)

    Public Sub PaletteIndexSet(format As String)
        ' Processes the file format and redirects intialization to specialized system methods.
        Select Case format
            Case PC_VGA_FORMAT
                InitializePCColorIndex(VGAAMAPPalette, VGATitlePalette, VGATilePalette, VGAAPalette, VGABPalette, VGABPalette, VGAStandardSpritePalette)
            Case PC_EGA_FORMAT
                InitializeThreeResource(EGAPalette, EGAPalette, EGAPalette, EGAPalette)
            Case IIGS_FORMAT
                InitializeIIGSIndex(GSStandard, GSStandard, GSStandard, GSTitlePalette, GSStandard, GSStandard, GSStandard, GSStandardSpritePalette)
            Case AMIGA_FORMAT
                InitializeAmigaIndex(AmigaScene, AmigaStandardPalette, AmigaScene, AmigaTitle, AmigaStandardSpritePalette)
            Case ST_FORMAT
                InitializeThreeResource(STAfile, STBCFile, STBCFile, STBCFile)
            Case Else
                MsgBox("Palette Initialization Error!  Invalid program format.")
                End
        End Select
    End Sub
    ' // WIMESprite Sets
    ' // SPRITE SET VARIANCE 
    ' // Contains the different sprite color variances when one changed the sprite color set from the default value which is 0
    ' // SpriteColor List 
    ' // string FileFormat, listof SpriteVariations
    '// SpriteVariations
    '// int SpriteSet, int PaletteIndex, int IndexValue
    Public WIMESpriteSets As List(Of SpriteColorList) = New List(Of SpriteColorList) From
        {New SpriteColorList(PC_VGA_FORMAT, New List(Of SpriteVariations) From {New SpriteVariations(1, 17, 65),
        New SpriteVariations(2, 5, 55), New SpriteVariations(2, 17, 57),
        New SpriteVariations(3, 5, 71), New SpriteVariations(3, 17, 72),
        New SpriteVariations(4, 5, 59), New SpriteVariations(4, 17, 58),
        New SpriteVariations(5, 4, 63),
        New SpriteVariations(6, 4, 47),
        New SpriteVariations(7, 4, 65),
        New SpriteVariations(8, 4, 71),
        New SpriteVariations(9, 26, 71), New SpriteVariations(9, 27, 72), New SpriteVariations(9, 28, 54), New SpriteVariations(9, 29, 55),
        New SpriteVariations(10, 14, 66), New SpriteVariations(10, 26, 69), New SpriteVariations(10, 27, 70), New SpriteVariations(10, 28, 49), New SpriteVariations(10, 29, 61),
        New SpriteVariations(11, 14, 66), New SpriteVariations(11, 26, 71), New SpriteVariations(11, 27, 72), New SpriteVariations(11, 28, 69), New SpriteVariations(11, 29, 70),
        New SpriteVariations(12, 14, 71), New SpriteVariations(12, 26, 69), New SpriteVariations(12, 27, 70), New SpriteVariations(12, 28, 49), New SpriteVariations(12, 29, 61),
        New SpriteVariations(13, 14, 71), New SpriteVariations(13, 26, 71), New SpriteVariations(13, 27, 72), New SpriteVariations(13, 28, 69), New SpriteVariations(13, 29, 70),
        New SpriteVariations(14, 14, 71), New SpriteVariations(14, 26, 71), New SpriteVariations(14, 27, 72), New SpriteVariations(14, 28, 65), New SpriteVariations(14, 29, 66),
        New SpriteVariations(15, 10, 56), New SpriteVariations(15, 11, 57), New SpriteVariations(15, 18, 67), New SpriteVariations(15, 19, 68),
        New SpriteVariations(16, 10, 47), New SpriteVariations(16, 11, 62), New SpriteVariations(16, 18, 54), New SpriteVariations(16, 19, 55),
        New SpriteVariations(17, 10, 56), New SpriteVariations(17, 11, 57), New SpriteVariations(17, 18, 63), New SpriteVariations(17, 19, 64),
        New SpriteVariations(18, 10, 56), New SpriteVariations(18, 11, 57), New SpriteVariations(18, 18, 65), New SpriteVariations(18, 19, 66),
        New SpriteVariations(19, 10, 56), New SpriteVariations(19, 11, 57), New SpriteVariations(19, 18, 58), New SpriteVariations(19, 19, 59),
        New SpriteVariations(20, 10, 54), New SpriteVariations(20, 11, 55), New SpriteVariations(20, 18, 63), New SpriteVariations(20, 19, 64),
        New SpriteVariations(21, 10, 56), New SpriteVariations(21, 11, 57), New SpriteVariations(21, 18, 63), New SpriteVariations(21, 19, 64),
        New SpriteVariations(22, 10, 47), New SpriteVariations(22, 11, 62), New SpriteVariations(22, 18, 67), New SpriteVariations(22, 19, 68),
        New SpriteVariations(24, 10, 56), New SpriteVariations(24, 11, 57), New SpriteVariations(24, 18, 47), New SpriteVariations(21, 19, 62),
        New SpriteVariations(26, 10, 65), New SpriteVariations(26, 11, 66), New SpriteVariations(26, 18, 47), New SpriteVariations(26, 19, 62),
        New SpriteVariations(28, 10, 67), New SpriteVariations(28, 11, 68), New SpriteVariations(28, 18, 69), New SpriteVariations(28, 19, 70),
        New SpriteVariations(30, 10, 56), New SpriteVariations(30, 11, 57),
        New SpriteVariations(31, 10, 47), New SpriteVariations(31, 11, 62),
        New SpriteVariations(32, 10, 67), New SpriteVariations(32, 11, 68),
        New SpriteVariations(33, 10, 54), New SpriteVariations(33, 11, 55), New SpriteVariations(33, 20, 50), New SpriteVariations(33, 21, 51), New SpriteVariations(33, 26, 65), New SpriteVariations(33, 27, 66),
        New SpriteVariations(34, 10, 58), New SpriteVariations(34, 11, 59), New SpriteVariations(34, 20, 67), New SpriteVariations(34, 21, 68),
        New SpriteVariations(35, 10, 47), New SpriteVariations(35, 11, 62), New SpriteVariations(35, 18, 69), New SpriteVariations(35, 19, 70),
        New SpriteVariations(36, 10, 47), New SpriteVariations(36, 11, 62), New SpriteVariations(36, 18, 58), New SpriteVariations(36, 19, 59),
        New SpriteVariations(37, 10, 71), New SpriteVariations(37, 11, 72), New SpriteVariations(37, 18, 69), New SpriteVariations(37, 19, 70)}),
        New SpriteColorList(IIGS_FORMAT, New List(Of SpriteVariations) From {New SpriteVariations(1, 4, 1), New SpriteVariations(1, 5, 4),
         New SpriteVariations(2, 2, 11), New SpriteVariations(2, 5, 4),
         New SpriteVariations(3, 2, 11), New SpriteVariations(3, 3, 7), New SpriteVariations(3, 4, 12), New SpriteVariations(3, 5, 8),
         New SpriteVariations(4, 2, 8), New SpriteVariations(4, 3, 8), New SpriteVariations(4, 4, 14), New SpriteVariations(4, 5, 12),
         New SpriteVariations(8, 15, 19),
         New SpriteVariations(9, 4, 10), New SpriteVariations(9, 5, 11),
         New SpriteVariations(15, 2, 12), New SpriteVariations(15, 3, 14), New SpriteVariations(15, 10, 4), New SpriteVariations(15, 11, 10),
         New SpriteVariations(16, 2, 11), New SpriteVariations(16, 3, 10), New SpriteVariations(16, 10, 3), New SpriteVariations(16, 11, 2),
         New SpriteVariations(17, 2, 13), New SpriteVariations(17, 3, 15), New SpriteVariations(17, 8, 1), New SpriteVariations(17, 9, 4), New SpriteVariations(17, 12, 5),
         New SpriteVariations(18, 2, 8), New SpriteVariations(18, 3, 12), New SpriteVariations(18, 8, 13), New SpriteVariations(18, 9, 5),
         New SpriteVariations(19, 8, 13), New SpriteVariations(19, 9, 5), New SpriteVariations(19, 10, 12), New SpriteVariations(19, 11, 8), New SpriteVariations(19, 12, 4),
         New SpriteVariations(21, 2, 13), New SpriteVariations(21, 3, 4),
         New SpriteVariations(22, 2, 11), New SpriteVariations(22, 3, 10), New SpriteVariations(22, 10, 3), New SpriteVariations(22, 11, 2),
         New SpriteVariations(24, 10, 13), New SpriteVariations(24, 11, 12),
         New SpriteVariations(26, 2, 11), New SpriteVariations(26, 3, 10), New SpriteVariations(26, 10, 4), New SpriteVariations(26, 11, 5),
         New SpriteVariations(28, 10, 15), New SpriteVariations(28, 11, 13),
         New SpriteVariations(11, 4, 8), New SpriteVariations(11, 5, 12),
         New SpriteVariations(12, 4, 12), New SpriteVariations(12, 5, 9),
         New SpriteVariations(13, 4, 5), New SpriteVariations(13, 5, 13),
         New SpriteVariations(30, 4, 10), New SpriteVariations(30, 5, 11), New SpriteVariations(30, 8, 4), New SpriteVariations(30, 10, 12), New SpriteVariations(30, 11, 8),
         New SpriteVariations(31, 2, 5), New SpriteVariations(31, 3, 4), New SpriteVariations(31, 4, 3), New SpriteVariations(31, 5, 2), New SpriteVariations(31, 8, 9),
         New SpriteVariations(31, 10, 11), New SpriteVariations(31, 11, 10),
         New SpriteVariations(32, 2, 11), New SpriteVariations(32, 3, 10), New SpriteVariations(32, 8, 9),
         New SpriteVariations(32, 10, 3), New SpriteVariations(32, 11, 2),
         New SpriteVariations(33, 2, 8), New SpriteVariations(33, 3, 12), New SpriteVariations(33, 8, 18),
         New SpriteVariations(34, 2, 11), New SpriteVariations(34, 3, 10), New SpriteVariations(34, 10, 12), New SpriteVariations(34, 11, 8),
         New SpriteVariations(35, 2, 8), New SpriteVariations(35, 3, 9), New SpriteVariations(35, 4, 10), New SpriteVariations(35, 5, 11), New SpriteVariations(35, 10, 4), New SpriteVariations(35, 11, 5),
         New SpriteVariations(36, 10, 3), New SpriteVariations(36, 11, 2),
         New SpriteVariations(37, 4, 12), New SpriteVariations(37, 5, 8), New SpriteVariations(37, 9, 5), New SpriteVariations(37, 10, 8), New SpriteVariations(37, 11, 9)}),
         New SpriteColorList(AMIGA_FORMAT, New List(Of SpriteVariations) From {New SpriteVariations(1, 1, 52),
        New SpriteVariations(1, 2, 63), New SpriteVariations(1, 3, 64), New SpriteVariations(1, 4, 65), New SpriteVariations(1, 5, 66), New SpriteVariations(1, 6, 67), New SpriteVariations(1, 7, 68),
        New SpriteVariations(1, 12, 73), New SpriteVariations(1, 13, 74), New SpriteVariations(1, 14, 75), New SpriteVariations(1, 15, 76),
        New SpriteVariations(2, 6, 58), New SpriteVariations(2, 7, 60), New SpriteVariations(2, 8, 78), New SpriteVariations(2, 9, 70), New SpriteVariations(2, 10, 71), New SpriteVariations(2, 11, 72),
        New SpriteVariations(2, 12, 73), New SpriteVariations(2, 13, 74), New SpriteVariations(2, 14, 75), New SpriteVariations(2, 15, 76),
        New SpriteVariations(12, 2, 53), New SpriteVariations(12, 3, 54), New SpriteVariations(12, 4, 63), New SpriteVariations(12, 5, 64), New SpriteVariations(12, 6, 67), New SpriteVariations(12, 7, 68),
        New SpriteVariations(12, 12, 71), New SpriteVariations(12, 13, 72), New SpriteVariations(12, 14, 75), New SpriteVariations(12, 15, 76), New SpriteVariations(12, 10, 67),
        New SpriteVariations(4, 4, 57), New SpriteVariations(4, 5, 47),
        New SpriteVariations(4, 6, 58), New SpriteVariations(4, 7, 60), New SpriteVariations(4, 8, 63), New SpriteVariations(4, 9, 64), New SpriteVariations(4, 10, 67), New SpriteVariations(4, 11, 68),
        New SpriteVariations(4, 12, 71), New SpriteVariations(4, 13, 72), New SpriteVariations(4, 14, 75), New SpriteVariations(4, 15, 76),
        New SpriteVariations(5, 1, 52), New SpriteVariations(5, 2, 65), New SpriteVariations(5, 3, 66), New SpriteVariations(5, 4, 63), New SpriteVariations(5, 5, 64), New SpriteVariations(5, 6, 67), New SpriteVariations(5, 7, 68),
        New SpriteVariations(5, 12, 71), New SpriteVariations(5, 13, 72), New SpriteVariations(5, 14, 75), New SpriteVariations(5, 15, 76), New SpriteVariations(5, 8, 78), New SpriteVariations(5, 9, 70),
        New SpriteVariations(5, 10, 73), New SpriteVariations(5, 11, 74),
        New SpriteVariations(6, 4, 57), New SpriteVariations(6, 5, 47),
        New SpriteVariations(6, 6, 58), New SpriteVariations(6, 7, 60), New SpriteVariations(6, 8, 78), New SpriteVariations(6, 9, 70), New SpriteVariations(6, 10, 73), New SpriteVariations(6, 11, 74),
        New SpriteVariations(6, 12, 71), New SpriteVariations(6, 13, 72), New SpriteVariations(6, 14, 75), New SpriteVariations(6, 15, 76),
        New SpriteVariations(7, 6, 58), New SpriteVariations(7, 7, 60), New SpriteVariations(7, 8, 65), New SpriteVariations(7, 9, 66), New SpriteVariations(7, 10, 73), New SpriteVariations(7, 11, 74),
        New SpriteVariations(7, 12, 67), New SpriteVariations(7, 13, 68), New SpriteVariations(7, 14, 75), New SpriteVariations(7, 15, 76),
        New SpriteVariations(8, 6, 58), New SpriteVariations(8, 7, 60), New SpriteVariations(8, 8, 78), New SpriteVariations(8, 9, 70), New SpriteVariations(8, 10, 71), New SpriteVariations(8, 11, 72),
        New SpriteVariations(8, 12, 67), New SpriteVariations(8, 13, 68), New SpriteVariations(8, 14, 75), New SpriteVariations(8, 15, 76),
        New SpriteVariations(9, 4, 78), New SpriteVariations(9, 5, 70),
        New SpriteVariations(9, 6, 71), New SpriteVariations(9, 7, 72), New SpriteVariations(9, 8, 65), New SpriteVariations(9, 9, 66), New SpriteVariations(9, 10, 67), New SpriteVariations(9, 11, 68),
        New SpriteVariations(9, 12, 73), New SpriteVariations(9, 13, 74), New SpriteVariations(9, 14, 75), New SpriteVariations(9, 15, 76),
        New SpriteVariations(10, 4, 78), New SpriteVariations(10, 5, 70),
        New SpriteVariations(10, 6, 71), New SpriteVariations(10, 7, 72), New SpriteVariations(10, 8, 50), New SpriteVariations(10, 9, 59), New SpriteVariations(10, 10, 58), New SpriteVariations(10, 11, 60),
        New SpriteVariations(10, 12, 73), New SpriteVariations(10, 13, 74), New SpriteVariations(10, 14, 75), New SpriteVariations(10, 15, 76),
        New SpriteVariations(11, 2, 53), New SpriteVariations(11, 3, 54), New SpriteVariations(11, 4, 65), New SpriteVariations(11, 5, 66), New SpriteVariations(11, 6, 67), New SpriteVariations(11, 7, 68),
        New SpriteVariations(11, 12, 73), New SpriteVariations(11, 13, 74), New SpriteVariations(11, 14, 75), New SpriteVariations(11, 15, 76),
        New SpriteVariations(11, 8, 50), New SpriteVariations(11, 9, 59), New SpriteVariations(11, 10, 58), New SpriteVariations(11, 11, 60),
        New SpriteVariations(3, 2, 53), New SpriteVariations(3, 3, 54), New SpriteVariations(3, 4, 50), New SpriteVariations(3, 5, 59), New SpriteVariations(3, 6, 67), New SpriteVariations(3, 7, 68), New SpriteVariations(3, 1, 52), New SpriteVariations(3, 10, 67),
        New SpriteVariations(3, 12, 73), New SpriteVariations(3, 13, 74), New SpriteVariations(3, 14, 75), New SpriteVariations(3, 15, 76),
        New SpriteVariations(12, 8, 63), New SpriteVariations(12, 9, 64), New SpriteVariations(12, 10, 67), New SpriteVariations(12, 11, 68),
        New SpriteVariations(13, 4, 78), New SpriteVariations(13, 5, 70),
        New SpriteVariations(13, 6, 73), New SpriteVariations(13, 7, 74), New SpriteVariations(13, 8, 63), New SpriteVariations(13, 9, 64), New SpriteVariations(13, 10, 67), New SpriteVariations(13, 11, 68),
        New SpriteVariations(13, 12, 71), New SpriteVariations(13, 13, 72), New SpriteVariations(13, 14, 75), New SpriteVariations(13, 15, 76),
        New SpriteVariations(14, 4, 78), New SpriteVariations(14, 5, 70),
        New SpriteVariations(14, 6, 73), New SpriteVariations(14, 7, 74), New SpriteVariations(14, 8, 57), New SpriteVariations(14, 9, 47), New SpriteVariations(14, 10, 67), New SpriteVariations(14, 11, 68),
        New SpriteVariations(14, 12, 71), New SpriteVariations(14, 13, 72), New SpriteVariations(14, 14, 75), New SpriteVariations(14, 15, 76),
        New SpriteVariations(16, 4, 63), New SpriteVariations(16, 5, 64),
        New SpriteVariations(16, 6, 71), New SpriteVariations(16, 7, 72), New SpriteVariations(16, 8, 53), New SpriteVariations(16, 9, 54), New SpriteVariations(16, 10, 58), New SpriteVariations(16, 11, 60),
        New SpriteVariations(16, 12, 67), New SpriteVariations(16, 13, 68), New SpriteVariations(16, 14, 75), New SpriteVariations(16, 15, 76),
        New SpriteVariations(19, 4, 53), New SpriteVariations(19, 5, 54),
        New SpriteVariations(19, 6, 67), New SpriteVariations(19, 7, 68), New SpriteVariations(19, 8, 50), New SpriteVariations(19, 9, 59), New SpriteVariations(19, 10, 73), New SpriteVariations(19, 11, 74),
        New SpriteVariations(19, 12, 58), New SpriteVariations(19, 13, 60), New SpriteVariations(19, 14, 75), New SpriteVariations(19, 15, 76),
        New SpriteVariations(20, 4, 53), New SpriteVariations(20, 5, 54),
        New SpriteVariations(20, 6, 67), New SpriteVariations(20, 7, 68), New SpriteVariations(20, 8, 57), New SpriteVariations(20, 9, 47), New SpriteVariations(20, 10, 71), New SpriteVariations(20, 11, 72),
        New SpriteVariations(20, 12, 58), New SpriteVariations(20, 13, 60), New SpriteVariations(20, 14, 75), New SpriteVariations(20, 15, 76),
        New SpriteVariations(22, 4, 50), New SpriteVariations(22, 5, 59),
        New SpriteVariations(22, 6, 73), New SpriteVariations(22, 7, 74), New SpriteVariations(22, 8, 57), New SpriteVariations(22, 9, 47), New SpriteVariations(22, 10, 71), New SpriteVariations(22, 11, 72),
        New SpriteVariations(22, 12, 58), New SpriteVariations(22, 13, 60), New SpriteVariations(22, 14, 75), New SpriteVariations(22, 15, 76),
        New SpriteVariations(24, 4, 57), New SpriteVariations(24, 5, 47),
        New SpriteVariations(24, 6, 71), New SpriteVariations(24, 7, 72), New SpriteVariations(24, 8, 53), New SpriteVariations(24, 9, 54), New SpriteVariations(24, 10, 67), New SpriteVariations(24, 11, 68),
        New SpriteVariations(24, 12, 58), New SpriteVariations(24, 13, 60), New SpriteVariations(24, 14, 75), New SpriteVariations(24, 15, 76)})
        }
    Public Class SpriteColorList
        Public Property FileFormat As String
        Public Property VariationData As List(Of SpriteVariations)
        Public Sub New()
        End Sub
        Public Sub New(value As String, ol As List(Of SpriteVariations))
            FileFormat = value
            VariationData = ol
        End Sub
    End Class
    Public Class SpriteVariations
        ' Class to create objects containing value for differences in the primary Sprite Color Index
        Public SpriteSet As Integer             ' The sprite color value
        Public PaletteIndex As Integer          ' The index value to be changed
        Public IndexValue As Integer            ' The new value
        Public Sub New(ByVal SetVal As Integer, ByVal PalIndexVal As Integer, ByVal IndexVal As Integer)
            SpriteSet = SetVal
            PaletteIndex = PalIndexVal
            IndexValue = IndexVal
        End Sub
        Public Sub New()
            ' Default
        End Sub
    End Class
    Public Sub InitializePCColorIndex(amapSet() As Integer, atitleSet() As Integer, tileSet() As Integer, asceneSet() As Integer, bsceneSet() As Integer, bobjectSet() As Integer, spriteSet() As Integer)
        ' Set Palettes of Images
        Dim tempSet As New Pal_Set With {.ID = "AMAPS", .ColorValue = New List(Of Integer)(amapSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "ATITLE", .ColorValue = New List(Of Integer)(atitleSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "ASCENE", .ColorValue = New List(Of Integer)(asceneSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "BSCENE", .ColorValue = New List(Of Integer)(bsceneSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "BOBJECTS", .ColorValue = New List(Of Integer)(bobjectSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "TILES", .ColorValue = New List(Of Integer)(tileSet)}
        LoadedPalette.Add(tempSet)
        ' Set primary sprite palette
        tempSet = New Pal_Set With {.ID = "AANIMS", .ColorValue = New List(Of Integer)(spriteSet)}
        LoadedPalette.Add(tempSet)
        'SpritePalette = New List(Of Integer)(spriteSet)
    End Sub
    Public Sub InitializeThreeResource(afileSet() As Integer, bfileSet() As Integer, cfileSet() As Integer, spriteSet() As Integer)
        Dim tempSet As New Pal_Set With {.ID = "AFILES", .ColorValue = New List(Of Integer)(afileSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "BFILES", .ColorValue = New List(Of Integer)(bfileSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "CFILES", .ColorValue = New List(Of Integer)(cfileSet)}
        LoadedPalette.Add(tempSet)

    End Sub
    Public Sub InitializeIIGSIndex(final1Set() As Integer, final2Set() As Integer, objectSet() As Integer, titleSet() As Integer, singleSet() As Integer, worldSet() As Integer, newiconsSet() As Integer, spriteSet() As Integer)
        Dim tempSet As New Pal_Set With {.ID = "FINAL1", .ColorValue = New List(Of Integer)(final1Set)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "FINAL2", .ColorValue = New List(Of Integer)(final2Set)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "NEWICONS", .ColorValue = New List(Of Integer)(newiconsSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "SINGLE", .ColorValue = New List(Of Integer)(singleSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "OBJECTS", .ColorValue = New List(Of Integer)(objectSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "TITLE", .ColorValue = New List(Of Integer)(titleSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "WORLD", .ColorValue = New List(Of Integer)(worldSet)}
        LoadedPalette.Add(tempSet)


    End Sub
    Public Sub InitializeAmigaIndex(animset() As Integer, amapSet() As Integer, sceneSet() As Integer, titleSet() As Integer, spriteSet() As Integer)
        Dim tempSet As New Pal_Set With {.ID = "AANIMS", .ColorValue = New List(Of Integer)(animset)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "AMAPS", .ColorValue = New List(Of Integer)(amapSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "ASCENE", .ColorValue = New List(Of Integer)(sceneSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "BSCENE", .ColorValue = New List(Of Integer)(sceneSet)}
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {.ID = "ATITLE", .ColorValue = New List(Of Integer)(titleSet)}
        LoadedPalette.Add(tempSet)

    End Sub
    Public Function ParseIndex(resourceType As String) As resource.RGBColorList
        Dim p_Colors As New resource.RGBColorList
        Dim p_tempColor As New resource.RGBValues
        Dim p_string As String = ""
        Dim index As Integer = 0
        For a As Integer = 0 To LoadedPalette.Count - 1
            If SelectedResourceItem.resourceType = TILES Then
                Select Case LoadedFile.Name
                    Case PC_VGA_FORMAT
                        index = 5
                    Case AMIGA_FORMAT
                        index = 1
                End Select
                index = 5
                Exit For
            End If
            If UCase(LoadedPalette(a).ID) = resourceType Then
                index = a
                Exit For
            End If
        Next
        For b As Integer = 0 To ((LoadedPalette(index).ColorValue.Count) - 1)
            Dim c As Integer
            c = LoadedPalette(index).ColorValue(b)
            For g As Integer = 0 To WIMEMasterPaletteSet.Count - 1
                If LoadedFile.Name = WIMEMasterPaletteSet(g).FileFormat Then
                    p_string = WIMEMasterPaletteSet(g).PaletteData.Item(c)
                End If
            Next g
            p_tempColor = resource.ConvertToRGB(p_string)
            p_Colors.Add(p_tempColor)
        Next b
        Return p_Colors
    End Function
    Public Function SpriteChangedColor(color As Integer, clist As resource.RGBColorList) As resource.RGBColorList
        Dim SpritePaletteValue As Integer = color
        Dim p_index As Integer = 0
        Dim p_slot As Integer = 0
        Dim p_Colors As New resource.RGBColorList
        Dim p_tempColor As New resource.RGBValues
        Dim p_string As String = ""
        p_Colors = clist
        For g = 0 To WIMESpriteSets.Count - 1           ' Check Through Sprite Formats
            If LoadedFile.Name = WIMESpriteSets(g).FileFormat Then
                'MsgBox(WIMESpriteSets(g).FileFormat & " file format match!")
                Dim varoff As Integer = 0
                For c As Integer = 0 To WIMESpriteSets(g).VariationData.Count - 1
                    If WIMESpriteSets(g).VariationData(c).SpriteSet = color Then
                        p_index = WIMESpriteSets(g).VariationData(c).IndexValue
                        p_slot = WIMESpriteSets(g).VariationData(c).PaletteIndex
                        'MsgBox("Number " & c & "  Value " & WIMESpriteSets(g).VariationData(c).IndexValue & " New Value " & WIMESpriteSets(g).VariationData(c).PaletteIndex)
                        If g = 1 Then varoff = 2 : If g = 2 Then varoff = 3
                        p_string = WIMEMasterPaletteSet(varoff).PaletteData(p_index)
                        p_tempColor = resource.ConvertToRGB(p_string)
                        p_Colors(p_slot) = p_tempColor
                    End If
                Next c

            End If
        Next g
        Return p_Colors
    End Function
End Module

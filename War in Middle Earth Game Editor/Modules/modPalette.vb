Imports WIMEEditor.Palette
Imports WIMEEditor.Game
Module modPalette
    ' // modPalette -- Palette Module
    '//
    '//  Module is a container for Arrays, methods, and variables related to the game palettes.
    '//  Contains Four master palettes; for VGA/EGA versions, IIGS versions, Amiga versions, and the ST version.
    '//  Each version has arrays for the different palettes in the resource files.  The arrays contain index numbers in integer format.
    '//  Each index refers to a hex value in the master palette which is just the RGB values in hex.
    Public MasterPalettePC() As String = {"000000",
      "868686", "555555", "755555", "EBAA86", "204110", "306510", "659655", "5586FF", "86BAFF", "CB0041", "FFFFFF", "00FFFF", "DB75CB", "65BA00", "EBEBBA", "FFFFDB",       ' 01-16
      "101010", "100000", "BA0000", "864120", "AA6541", "553020", "414141", "554141", "755541", "756555", "757565", "757575", "967565", "968665", "AA7586", "969686",         ' 17-32
      "BA9675", "BAAA86", "BAAA96", "DBBA86", "CBBAAA", "EBCB96", "EBDBAA", "EBDBBA", "FFEBBA", "FFFFBA", "FFDBCB", "CB2010", "DB3020", "EBCBAA", "960000", "412065",       ' 33-48
      "416565", "759641", "AACB75", "415520", "657520", "0041BA", "2075CB", "55AAEB", "86DBFF", "DBAA30", "EBEB65", "102020", "554141", "CB0000", "AA20AA", "DB86DB",       ' 49-64
      "8696AA", "CBDBEB", "BA5500", "EB7500", "411000", "753010", "966541", "CB9665", "DB8665", "FFCB86", "0000AA", "00AA00", "00AAAA", "AA0000", "AA00AA", "AA5500",       ' 65 - 80
      "AAAAAA", "555555", "5555AA", "55FF55", "55AAAA", "FF5555", "FFFF55"
    }
    Public MasterPaletteIIGS() = {"000000",
    "DDCCAA", "990000", "CC0000", "8899AA", "333333", "779944", "445522", "441100", "773311", "22AAEE", "0044BB", "AA4408", "002222", "EE9900", "442266", "FFFFBB",              '01 - 16
    "888888", "FFFFDD", "442222", "886666", "666644", "998866", "663300", "884422", "CCAAAA", "FF0000", "444444", "EEEEAA", "EEEECC", "884422", "AA6644", "553322",             '17-32
    "775544", "997766", "FFDDCC", "CC2211", "DD3322", "BB0000", "110000", "554444", "777777", "555555", "444444", "111111", "544040", "8990A0", "CDD0E0", "B55000",             '33-48
    "E77000", "002222", "966040", "C99060", "CB0041"
    }                                                                                                                           '49-53
    Public MasterPaletteAmiga() As String = {"000000",
    "8C268C", "525552", "735552", "EFAA8C", "214510", "316510", "639A52", "528AFF", "8CBAFF", "CE0042", "FFFFFF", "00FFFF", "DE75CE", "63BA00", "EFEFBD", "AA7788",      ' 1- 16
    "BB8899", "FFFFBB", "777766", "FFFFDD", "999988", "EEDDAA", "FFEEBB", "998866", "BBAA88", "EEDDBB", "DDBB88", "EECC99", "BB9977", "776655", "CCBBAA", "884422",      '17-32   
    "AA6644", "553322", "775544", "997766", "FFDDCC", "CC2211", "DD3322", "BB0000", "110000", "554444", "777777", "555555", "444444", "111111", "2175CE", "DECFAD",      '33-48
    "CEDFEF", "21AAEF", "422063", "426563", "739A42", "AACC77", "445522", "637521", "0045BD", "DEAA31", "8CDFFF", "EFEF63", "102021", "524542", "9C0000", "CE0000",      '49-64
    "AD20AD", "DE8ADE", "8C9AAD", "CEDFEF", "DE8A63", "EF7500", "421000", "733010", "9C6542", "CE9A63", "DE8A63", "FFCF8C", "9C1E1E", "BD5500"                           '65-78
    }
    ' Palette Color Index Arrays --- indexed to MasterPalette Array
    Public StandardPalette16() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
    Public VGATitlePalette() As Integer = {0, 16, 17, 18, 19, 20, 21, 22, 23, 24, 2, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45}
    Public VGAAPalette() As Integer = {0, 46, 55, 56, 48, 49, 50, 51, 52, 53, 69, 70, 71, 57, 58, 59, 60, 61, 47, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74}
    Public VGABPalette() As Integer = {0, 46, 55, 56, 48, 49, 50, 51, 52, 61, 54, 55, 56, 57, 58, 59, 60, 61, 47, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74}
    Public VGATilePalette() As Integer = {0, 8, 6, 7, 10, 13, 3, 1, 2, 9, 14, 12, 10, 0, 4, 15}
    Public VGAStandardSpritePalette() As Integer = {0, 46, 14, 12, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 47, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74}
    Public EGAPalette() As Integer = {0, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 0, 87, 11}
    Public GSStandard() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
    Public GSTitlePalette() As Integer = {0, 1, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44}
    Public GSStandardSpritePalette() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0, 44, 2, 1, 53, 45, 46, 47, 48, 49, 7, 50, 51, 52, 8, 0}
    Public AmigaStandardPalette() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}
    Public AmigaTitle() As Integer = {16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46}
    Public AmigaScene() As Integer = {47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 57, 58, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77}
    Public AmigaStandardSpritePalette() As Integer = {0, 68, 76, 48, 51, 52, 53, 58, 55, 56, 57, 47, 71, 67, 60, 76, 61, 62, 63, 64, 65, 62, 67, 68, 78, 70, 71, 72, 73, 74, 75, 54}
    ' Set Palette List Objects
    Public LoadedPalette As New List(Of Pal_Set)
    Public SpritePalette As New List(Of Integer)    ' TODO - Revise index numbers on differences from standard in future.
    Public Sub PaletteIndexSet(format As String)
        ' Processes the file format and redirects intialization to specialized system methods.
        Select Case format
            Case PC_VGA_FORMAT
                InitializeColorIndex(StandardPalette16, VGATitlePalette, VGATilePalette, VGAAPalette, VGABPalette, VGABPalette, VGAStandardSpritePalette)
            Case PC_EGA_FORMAT
                InitializeThreeResource(EGAPalette, EGAPalette, EGAPalette, EGAPalette)
            Case IIGS_FORMAT
                InitializeIIGSIndex(GSStandard, GSStandard, GSStandard, GSTitlePalette, GSStandard, GSStandard, GSStandard, GSStandardSpritePalette)
            Case AMIGA_FORMAT
                InitializeAmigaIndex(AmigaScene, AmigaStandardPalette, AmigaScene, AmigaTitle, AmigaStandardSpritePalette)
            Case ST_FORMAT
            Case Else
                MsgBox("Palette Initialization Error!  Invalid program format.")
                End
        End Select
    End Sub
    Public Sub InitializeColorIndex(amapSet() As Integer, atitleSet() As Integer, tileSet() As Integer, asceneSet() As Integer, bsceneSet() As Integer, bobjectSet() As Integer, spriteSet() As Integer)
        ' Set Palettes of Images
        Dim tempSet As New Pal_Set With {
            .ID = "AMAPS",
            .ColorValue = New List(Of Integer)(amapSet)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
            .ID = "ATITLE",
            .ColorValue = New List(Of Integer)(atitleSet)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
            .ID = "ASCENE",
            .ColorValue = New List(Of Integer)(asceneSet)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
            .ID = "BSCENE",
            .ColorValue = New List(Of Integer)(bsceneSet)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
            .ID = "BOBJECTS",
            .ColorValue = New List(Of Integer)(bobjectSet)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
            .ID = "TILES",
            .ColorValue = New List(Of Integer)(tileSet)
        }
        LoadedPalette.Add(tempSet)
        ' Set primary sprite palette
        tempSet = New Pal_Set With {
            .ID = "AANIMS",
            .ColorValue = New List(Of Integer)(spriteSet)
        }
        LoadedPalette.Add(tempSet)
        'SpritePalette = New List(Of Integer)(spriteSet)
    End Sub
    Public Sub InitializeThreeResource(afileSet() As Integer, bfileSet() As Integer, cfileSet() As Integer, spriteSet() As Integer)
        Dim tempSet As New Pal_Set With {
           .ID = "AFILES",
           .ColorValue = New List(Of Integer)(afileSet)
       }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
          .ID = "BFILES",
          .ColorValue = New List(Of Integer)(bfileSet)
      }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
          .ID = "CFILES",
          .ColorValue = New List(Of Integer)(cfileSet)
      }
        LoadedPalette.Add(tempSet)
        SpritePalette = New List(Of Integer)(spriteSet)
    End Sub
    Public Sub InitializeIIGSIndex(final1Set() As Integer, final2Set() As Integer, objectSet() As Integer, titleSet() As Integer, singleSet() As Integer, worldSet() As Integer, newiconsSet() As Integer, spriteSet() As Integer)
        Dim tempSet As New Pal_Set With {
            .ID = "FINAL1",
            .ColorValue = New List(Of Integer)(final1Set)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
            .ID = "FINAL2",
            .ColorValue = New List(Of Integer)(final2Set)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
            .ID = "NEWICONS",
            .ColorValue = New List(Of Integer)(newiconsSet)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
            .ID = "SINGLE",
            .ColorValue = New List(Of Integer)(singleSet)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
            .ID = "OBJECTS",
            .ColorValue = New List(Of Integer)(objectSet)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
            .ID = "TITLE",
            .ColorValue = New List(Of Integer)(titleSet)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
            .ID = "WORLD",
            .ColorValue = New List(Of Integer)(worldSet)
        }
        LoadedPalette.Add(tempSet)
        ' Set primary sprite palette
        SpritePalette = New List(Of Integer)(spriteSet)

    End Sub
    Public Sub InitializeAmigaIndex(animset() As Integer, amapSet() As Integer, sceneSet() As Integer, titleSet() As Integer, spriteSet() As Integer)
        Dim tempSet As New Pal_Set With {
            .ID = "AANIMS",
            .ColorValue = New List(Of Integer)(animset)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
        .ID = "AMAPS",
            .ColorValue = New List(Of Integer)(amapSet)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
        .ID = "ASCENE",
        .ColorValue = New List(Of Integer)(sceneSet)
        }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
       .ID = "BSCENE",
       .ColorValue = New List(Of Integer)(sceneSet)
       }
        LoadedPalette.Add(tempSet)
        tempSet = New Pal_Set With {
       .ID = "ATITLE",
       .ColorValue = New List(Of Integer)(titleSet)
       }
        LoadedPalette.Add(tempSet)
        SpritePalette = New List(Of Integer)(spriteSet)
    End Sub
    Public Function ParseIndex(resourceType As String) As resource.RGBColorList
        Dim p_Colors As New resource.RGBColorList
        Dim p_tempColor As New resource.RGBValues
        Dim p_string As String

        Dim index As Integer = 0
        For a As Integer = 0 To LoadedPalette.Count - 1
            If SelectedResourceItem.resourceType = TILES Then
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
            If loadedGame.format = PC_VGA_FORMAT Or loadedGame.format = PC_EGA_FORMAT Then
                p_string = MasterPalettePC(c)
            ElseIf loadedGame.format = IIGS_FORMAT Then
                p_string = MasterPaletteIIGS(c)

            ElseIf loadedGame.format = AMIGA_FORMAT Then
                p_string = MasterPaletteAmiga(c)
            Else
                p_string = MasterPalettePC(c)
            End If
            p_tempColor = resource.ConvertToRGB(p_string)
            p_Colors.add(p_tempColor)
        Next
        Return p_Colors
    End Function
End Module

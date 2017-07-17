Imports System.IO
Imports System.Xml
' // =============================================================== WAR IN MIDDLE EARTH GAME CLASS ============================================================================
' // VERSION 1.5  - MOST RECENT VERSION 11/04/2015
' // Version 1.01 - CURRENT UPDATE 9/8/14
' // VERSION 1.00 - CREATED JULY 6, 2014
' // COMBINES RESOURCE AND ARCHIVE CLASSES INTO ONE CLASS, MINIMIZING AND OPTIMIZING CODE.
' // REPLACES RESOURCECLASS.VB AND ARCHIVECLASS.VB.
' //
' // ============================================================================================================================================================================
Public Class Game
    ' ============================== CONSTANTS AND SHARED VARIABLES ===================================================
    Public Const INT_MAX As Integer = 65535
    Public Const USHORT_MAX = INT_MAX
    Public Const UBYTE_MAX As Byte = 255
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
    Public Const PC_VGA_DESC = "IBM PC 16-Bit Format"
    Public Const PC_EGA_DESC = "IBM PC 8-Bit Format"
    Public Const IIGS_DESC = "APPLE IIGS 16-Bit Format"
    Public Const AMIGA_DESC = "AMIGA 16-Bit Format"
    Public Const ST_DESC = "ATARI ST 16-Bit Format"
    Public Shared PC_VGA_ICON As System.Drawing.Image = My.Resources.msdosicon
    Public Shared PC_EGA_ICON As System.Drawing.Image = My.Resources.msdosicon
    Public Shared IIGS_ICON As System.Drawing.Image = My.Resources.apple2icon
    Public Shared AMIGA_ICON As System.Drawing.Image = My.Resources.amigamenulogo
    Public Shared ST_ICON As System.Drawing.Image = My.Resources.atarilogo
    Public Const IMAGES As String = "IMAGES"
    Public Const TILES As String = "TILES"
    Public Const SPRITES As String = "SPRITES"
    Public Const SPRITEDATA As String = "SPRITEDATA"
    Public Const PC_VGA_BITPLANES = 5
    Public Const PC_EGA_BITPLANES = 4
    Public Const IIGS_BITPLANES = 4
    Public Const AMIGA_BITPLANES = 5
    Public Const ST_BITPLANES = 4
    Public Const TILE_PIXELS = 256
    Public Shared FORMAT_ICONS() As Image = {My.Resources.msdosicon, My.Resources.msdosicon, My.Resources.apple2icon, My.Resources.amigamenulogo, My.Resources.atarilogo}
    Public Shared OFFSET_BANNERICONS = {4, 5, 5, 4, 4}
    Public Shared OFFSET_CharacterName = {113323, 131875, 106464, 37914, 37096}          ' Offset for the Character Name Location in Executable.  Name located in name list.
    Public Shared OFFSET_CharacterData = {104654, 123041, 108124, 122708, 116640}        ' Offset for the Character Data Location in Executable.  Includes pointer to name.
    Public Shared OFFSET_CityName = {114179, 132731, 104746, 39539, 38721}               ' Offset for the City Name Location in Executable.  Name located in name list.
    Public Shared OFFSET_CityData = {112565, 131117, 105706, 131010, 124828}             ' Offset for the City Data Name Location in Executable.  Includes pointer to name, and coordinates.
    Public Shared OFFSET_InvObj() As Integer = {115144, 133696, 120518, 80286, 29228}                 ' Offset for the Object Name Location in Executable.  Name located in object list.
    Public Shared OFFSET_ArchiveCharVal = {0, 0, 25538, 0, 24064}                   ' Offset for the Character Name value in the EXE File.  Offset based on comparison of value vs. location in the file.
    Public Shared OFFSET_EXECharVal = {0, 0, 33562, -18984, 5862}                    ' Offset for Character Name in EXE vs. value in archive file.
    Public Shared OFFSET_EXEOffset = {93300, 112832, 95598, 40, 4}                       ' Difference in values vs. pointer locations in the EXE file.
    Public Shared OFFSET_SaveOffset = {0, 0, 25538, 0, 24064}
    Public Shared OFFSET_TileStart = {43907, 301405, 20, 8038, 8038}
    Public Shared AMIGA_CHUNK = 40992
    Public Shared FORMAT_BITPLANES() As Integer = {PC_VGA_BITPLANES, PC_EGA_BITPLANES, IIGS_BITPLANES, AMIGA_BITPLANES, ST_BITPLANES}
    Public Shared gameExecutables() As String = {PC_VGA_EXE, PC_EGA_EXE, IIGS_EXE, AMIGA_EXE, ST_EXE}
    Public Shared FORMAT_ID() As String = {PC_VGA_FORMAT, PC_EGA_FORMAT, IIGS_FORMAT, AMIGA_FORMAT, ST_FORMAT}
    Public Shared FORMAT_DESC() As String = {PC_VGA_DESC, PC_EGA_DESC, IIGS_DESC, AMIGA_DESC, ST_DESC}
    Public Shared FILE_ICONS() As Image = {PC_VGA_ICON, PC_EGA_ICON, IIGS_ICON, AMIGA_ICON, ST_ICON}
    Public Shared BANNERICON_VALUES = {0, 1, 2, 3, 4, 5, 16, 17, 18, 19, 20, 21, 32, 33, 34, 35, 36, 37, 48, 49, 50, 51, 52, 53, 64, 65, 66, 67, 68, 69}
    Public Shared CHAR_OFFSET As UShort = 4
    Public Const CHARACTER_MAX As Integer = 193
    Public Const CITY_MAX As Integer = 83   '68
    Public Const Default_City = "HINTERLAND"
    Public Const UNKNOWN As String = "UNKNOWN"
    Public Shared myBA As New BitArray(16)
    Public Shared TILE_FILE As String
    Public Shared MAP_FILE As String
    Public Shared ARCHIVE_FILE As String
    Public Const ICON_TOTAL = 30
    Public Const OBJECT_TOTAL = 16
    Public Const TILE_TOTAL = 255
    Public Const ImageWidth = 320
    Public Const ImageHeight = 200
    Public Shared DATA_ENDIAN() As Integer = {1, 0, 0, 1, 1}
    Public Shared FRML_ResourceKey_Elements = 4
    Public Shared DATA_FILES = Application_Path & "\" & "WIMEDATA.XML"
    Enum archiveBlockSize
        LittleEndian = 37
        BigEndian = 38
    End Enum
    Enum cityBlockSize
        LittleEndian = 9
        BigEndian = 10
    End Enum
    ' ============================= VARIABLES ================================================
    Public EXEFile As String
    Public format As String
    Public formatVal As Integer
    Public endianType As Integer
    Public DataEndianType As Integer

    Public Sub New(filename As String)
        Me.formatVal = getFormatVal(filename)
        Me.format = FORMAT_ID(Me.formatVal)
        Me.endianType = endianChecker(Me.format)
        Me.DataEndianType = DATA_ENDIAN(Me.formatVal)
    End Sub
    ' ============================= SUB-CLASSES ===============================================

    ' ============================= METHODS ===================================================
    Private Function getFormatVal(gamefilename As String) As Integer
        ' Checks EXE file and returns values for proper file format.
        Dim tempInt As Integer
        Dim tempString As String
        For x = 0 To gameExecutables.Count - 1
            tempString = gameExecutables(x)
            If UCase(gamefilename) = tempString Then
                tempInt = x
                Exit For
            End If
        Next
        Return tempInt
    End Function
    Public Shared Function Format2Val(format As String) As Integer
        Dim tempVal As Integer
        For x = 0 To gameExecutables.Count - 1
            If format = FORMAT_ID(x) Then
                tempVal = x
                Exit For
            End If
        Next x
        Return tempVal
    End Function
    Public Shared Function endianChecker(format As String) As UShort
        Dim tempVal As UShort
        If format = FORMAT_ID(0) Or format = FORMAT_ID(1) Or format = FORMAT_ID(2) Then
            tempVal = Endianness.endLittle
        Else
            tempVal = Endianness.endBig
        End If
        Return tempVal
    End Function
    Public Shared Function GET_FRML_Bitplane(filename As String, format As String) As Integer
        Dim p_value As Integer
        Dim settings As New XmlReaderSettings
        settings.IgnoreWhitespace = True
        settings.IgnoreComments = True
        settings.IgnoreWhitespace = True
        settings.IgnoreComments = True
        Using input As XmlReader = XmlReader.Create(filename, settings)
            Do While input.Read
                If input.ReadToDescendant(format) Then
                    input.ReadToDescendant("FRMLBITPLANES")
                    p_value = input.ReadElementContentAsInt
                End If


            Loop
        End Using
        Return p_value



    End Function
    Public Shared Function Get_FRML_Offset(ByVal filename As String, format As String, resource_name As String) As Game.resource.FRML_OFFSET
        ' /* FUNCTION DECLARATIONS
        Dim settings As New XmlReaderSettings
        settings.IgnoreWhitespace = True
        settings.IgnoreComments = True
        Dim P_RESID As String = ""
        Dim p_offset As New Game.resource.FRML_OFFSET
        settings.IgnoreWhitespace = True
        settings.IgnoreComments = True
        Using input As XmlReader = XmlReader.Create(filename, settings)
            Do While input.Read
                If input.ReadToDescendant(format) Then
                    If input.ReadToDescendant("FRMLOFFSETS") Then
                        If input.ReadToDescendant("RESOURCE") Then
                            Do
                                P_RESID = input("ID")
                                If P_RESID = resource_name Then
                                    input.ReadStartElement("RESOURCE")
                                    p_offset.Data_Offset = input.ReadElementContentAsInt
                                    p_offset.Address_Offset = input.ReadElementContentAsInt
                                    Exit Do
                                Else
                                End If
                            Loop While input.ReadToNextSibling("RESOURCE")
                        End If
                    End If
                End If
            Loop
        End Using
        Return p_offset
    End Function
    Public Shared Function CreateParseObject(graphictype As String, format As String, resource As String) As ParseList
        Dim p_parse As New ParseList
        Dim settings As New XmlReaderSettings
        Dim p_slot As UShort = 0 : Dim p_index As UShort = 0
        Dim p_file As String = DATA_FILES
        Dim counter As Integer = 0
        With settings
            .IgnoreWhitespace = True
            .IgnoreComments = True
        End With
        Dim PAL_NAME As String = ""
        Using input As XmlReader = XmlReader.Create(p_file, settings)
            Dim t As String = ""
            Do While input.Read
                input.ReadToDescendant(format)
                input.ReadToDescendant(graphictype)
                Do Until t = resource
                    input.ReadToFollowing("PALETTE")
                    t = input.GetAttribute("ID")
                    If t = resource Then
                        MsgBox("RESOURCE " & graphictype & " " & t & " found.")
                        ' Then go to first COLOR element.
                        input.ReadToFollowing("COLOR")
                        Do
                            input.MoveToFirstAttribute()
                            p_slot = input.GetAttribute("SLOT")         ' Read and store slot attribute into temporary slot variable.

                            input.MoveToNextAttribute()
                            p_index = input.GetAttribute("INDEX")         ' Read and store slot attribute into temporary value variable.
                            p_index = Val(p_index)
                            p_parse.Add(p_slot, p_index)
                            'MsgBox("ADDED " & p_slot & " " & p_index)
                            counter = counter + 1
                        Loop While input.ReadToNextSibling("COLOR") 'Not input.ReadToFollowing("COLOR")     ' Loop to next element until no more elements.
                        Exit Do
                    Else

                    End If
                Loop  'Until input.ReadToNextSibling(graphictype)
            Loop
        End Using

        'For x As Integer = 0 To p_parse.Count - 1
        '    MsgBox("Slot " & p_parse.Item(x).ColorSlot & vbCrLf & "Index Value " & p_parse.Item(x).ColorIndex)
        'Next

        Return p_parse
    End Function
    Public Shared Function ParseColorIndex(parsedata As ParseList, index As PaletteData.ColorList) As resource.RGBColorList
        Dim p_Colors As New resource.RGBColorList
        Dim p_tempColor As New resource.RGBValues
        For x As Integer = 0 To parsedata.Count - 1
            For y As Integer = 0 To index.Count - 1
                If parsedata(x).ColorIndex = index(y).Slot Then
                    p_tempColor = resource.ConvertToRGB(index(y).ColorValue)
                    'MsgBox("Color Slot " & parsedata(x).ColorSlot & " = COLOR VALUE: " & p_tempColor.RedValue & p_tempColor.GreenValue & p_tempColor.BlueValue)
                    p_Colors.add(p_tempColor)
                    Exit For
                Else
                    'no match continue on.
                End If
            Next y
        Next x
        Return p_Colors
    End Function


    Public Class ParseEntry
        'Class used to hold data in parsing the ColorIndex object
        Private m_Index As UShort
        Private m_Slot As UShort

        Public Property ColorIndex As UShort
            Get
                Return m_Index
            End Get
            Set(value As UShort)
                m_Index = value
            End Set
        End Property
        Public Property ColorSlot As String
            Get
                Return m_Slot
            End Get
            Set(value As String)
                m_Slot = value
            End Set
        End Property

        Public Sub New(slot As UShort, index As UShort)
            Me.ColorIndex = index
            Me.ColorSlot = slot
        End Sub
    End Class
    Public Class ParseList
        ' Class used to store list of Parse object when parsing color index
        Private ParseColorKey As List(Of ParseEntry)
        Public Sub New()
            ParseColorKey = New List(Of ParseEntry)
        End Sub
        Public ReadOnly Property Count As Integer
            Get
                Return ParseColorKey.Count
            End Get
        End Property
        Default Public Property Item(index As Integer) As ParseEntry
            Get
                If index < 0 OrElse index >= ParseColorKey.Count Then
                    Throw New ArgumentOutOfRangeException("index", "The index must be between 0 And " & ParseColorKey.Count - 1 & ".")
                Else
                    Return ParseColorKey(index)
                End If
            End Get
            Set(value As ParseEntry)
                ParseColorKey(index) = value
            End Set
        End Property
        Public Sub Add(color As ParseEntry)
            ParseColorKey.Add(color)
        End Sub
        Public Sub Add(slot As UShort, index As UShort)
            Dim p As New ParseEntry(slot, index)
            ParseColorKey.Add(p)
        End Sub

    End Class

    Public Shared Function getPlanes(format As String) As Integer
        Dim p_planes As Integer = 0
        For p As Integer = 0 To FORMAT_BITPLANES.Length - 1
            If format = FORMAT_ID(p) Then
                p_planes = FORMAT_BITPLANES(p)
                Exit For
            End If
        Next
        Return p_planes
    End Function
    Public Shared Function FileOpenDialog() As OpenFileDialog
        Dim dlgOpenGame As New OpenFileDialog
        Dim dr As DialogResult
        Dim p_counter As Integer = 0
        dlgOpenGame.FilterIndex = 0                                       ' Sets default file.
        dlgOpenGame.Title = "Select the Executable For the WIME Game you wish To edit."
        dlgOpenGame.Filter = "WIME Executables (start.exe, lord.exe, earth.sys16 * .*, warinmiddleearth * .*, Command.PRG)|start.exe; lord.exe; earth.sys16*.*; warinmiddleearth*.*; COMMAND.PRG|All Files (*.*)|*.*)" 'WIME PC Executable|start.exe;lord.exe|Apple IIGS Prodos16|earth.sys16*.*|Amiga Executable|warinmiddleearth*.*|ATARI ST Program|COMMAND.PRG|All Files|*.*"
        dlgOpenGame.InitialDirectory = loadedSettings.wimeDIRECTORY
        dlgOpenGame.RestoreDirectory = False
        dlgOpenGame.FileName = ""
        dr = dlgOpenGame.ShowDialog
        Return dlgOpenGame
    End Function
    Public Class resource
        Public Const CHAR_ID = "CHAR"
        Public Const CSTR_ID = "CSTR"
        Public Const FONT_ID = "FONT"
        Public Const FRML_ID = "FRML"
        Public Const IMAG_ID = "IMAG"
        Public Const MAP_ID = "MMAP"
        Public Const IMAGHeaderSize = 22
        Public Const BIGENDIAN_CELQUANTITY_OFFSET = 10
        Public Const LITTLEENDIAN_CELQUANTITY_OFFSET = 9
        Public Shared RES_ID() As String = {CHAR_ID, CSTR_ID, FONT_ID, FRML_ID, IMAG_ID, MAP_ID}
        Public Shared RES_CHUNK_OFF() As UInt16 = {0, 8, 0, 17, 20, 0}
        Public Shared RES_ID_ELEMENTS() As String = {"TILE", "TEXT STRING", "FONT", "ANIMATION", "IMAGE", "GAME MAP", "CHARACTER"}
        Public Shared ALT_ID As String = "TILESINGLE"
        Public Shared FRMLCelOffset() As UShort = {BIGENDIAN_CELQUANTITY_OFFSET, LITTLEENDIAN_CELQUANTITY_OFFSET, LITTLEENDIAN_CELQUANTITY_OFFSET, BIGENDIAN_CELQUANTITY_OFFSET, BIGENDIAN_CELQUANTITY_OFFSET}
        Public Shared WIME_WORLDMAP_SIZE() As Integer = {2560, 1584}
        Public Const MAX_COLORS As Integer = 256
        ' ==================================================== PROPERTY VARIABLES =====================================================================================
        Public Filename As String
        Public EndianType As Integer
        Public Format As String
        Public HeaderSize As UShort
        Public DataSegmentSize As UInteger
        Public DataSize As UInteger
        Public FileEndLength As UInteger
        Public totalChunks As UShort
        Public ResourceKey(0 To 5, 0 To 1) As Integer
        ' ==================================================== SUB CLASSES ===============================================================================
        Public Shared Sub UNPACKAMIGATILES(ByVal tilefile As String, datadir As String, toffset As Integer, tchunk As Integer)
            Dim inputfile As New BinaryFile(tilefile)
            Dim outputfile As New BinaryFile(datadir & "\Tiles.raw")
            Dim unpacker As New ByteRunUnpacker(inputfile)
            Dim result As Byte() = unpacker.unpackTiles(toffset, tchunk)
            outputfile.Write(result, 0, result.Length)
            MsgBox(datadir & "\Tiles.raw" & " Closed!" & toffset & " " & tchunk)
            inputfile.Close() : outputfile.Close()
        End Sub
        Public Shared Function getTileChunk(filename As String, endian As Short, offset As Integer) As Integer
            Dim p_chunksize As Integer
            Using reader As New BinaryFile(filename)
                reader.Position = offset
                p_chunksize = reader.ReadLongwordSigned(endian)
            End Using
            Return p_chunksize
        End Function
        Class Header
            Public Size As UInteger
            Public DataSegmentSize As UInteger
            Public DataSize As UInteger
            Public FileEndLength As UInteger
        End Class
        Public Class Chunk
            Private p_tempString As String
            Private p_tempInteger As UInteger
            Public Name As String
            Public offset As UInteger
            Public chunkSize As UInteger
            Public uncompressed_size As UInteger
            Public width As UShort
            Public height As UShort
            Public planes As UShort
            Public canvassWidth As UShort
            Public chunkData() As Byte
            Public chunkByte As Byte
            Public chunkshort As UShort
            Public chunkInt As UInteger
            Public ResourceKey(0 To 5, 0 To 1) As Integer
            Public Property Type As String
                Get
                    Return p_tempString
                End Get
                Set(value As String)
                    p_tempString = getChunkType(value)
                End Set
            End Property
            Public Property Description As String
                Get
                    Return p_tempString
                End Get
                Set(value As String)
                    p_tempString = getChunkType(value)
                End Set
            End Property
            Public Property DataStartOffset As UInteger
                Get
                    Return p_tempInteger
                End Get
                Set(value As UInteger)
                    p_tempInteger = value
                End Set
            End Property
            Private Function getChunkType(value As Integer)
                p_tempString = RES_ID(value)
                Return p_tempString
            End Function
            Private Function getDescription(value) As Integer
                p_tempString = RES_ID_ELEMENTS(value)
                Return p_tempString
            End Function
            Private Function getDataStart(value) As Integer
                p_tempInteger = RES_CHUNK_OFF(value)
                Return p_tempInteger
            End Function
        End Class
        Public Structure resourceMap
            Public Number As Integer
            Public Offset As Integer
            Public intMultiplier As Integer
        End Structure
        Public Class imageChunk
            Inherits Chunk
            Public imagePlane As UShort
            Public bitplane As UShort
            Public iByte(0 To 6) As Byte
        End Class
        Public Class animChunk
            Inherits Chunk
            Public Class cel
                Public Shared dataStart As List(Of UInteger)
                Public byte2 As List(Of Byte)
                Public byte3 As List(Of Byte)
                Public width As List(Of Byte)
                Public canvassWidth As List(Of Byte)
                Public height As List(Of Byte)
            End Class
            Public celQuantity As UShort
            Public cel_canvasswidth() As UShort
            Public cel_height() As UShort
            Public cel_cycle_groups() As UShort
            Public cel_cycle_groupsize As UInteger
            Public dStartOffset As UInteger
            Public dataStartPoint As UInteger
            Public bitplanes As UShort
            Public speed As UShort
            Public byte8 As Byte
            Structure FRMLKey
                Dim offset As UShort
                Dim byte2 As Byte
                Dim width As Byte
                Dim canvass_width As Byte
                Dim height As Byte
            End Structure
        End Class
        Public Class tileChunk
            Inherits Chunk
            Public Image() As Bitmap
            Public PositionX As Integer
            Public PositionY As Integer
            Public Size As Integer
            Public ItemTotal As Integer
            Public filename As String
        End Class
        Public Class MapChunk
            Inherits Chunk
            Public filename As String
        End Class
        Public Class resourceIdentifier
            ' =================================================================== RESOURCEIDENTIFIER SUB-CLASS =====================================================
            ' CLASS ARRAY FOR ORGANIZING RESOURCE ID AND LENGTHS WHEN PARSING RESOURCE FILES.
            ' ======================================================================================================================================================
            Public resourceID(RES_ID.Length) As String
            Public resourceQTY(RES_ID.Length) As Integer
        End Class
        Structure newResourceIdentifier
            Public resourceID As String
            Public resourceQTY As Integer
        End Structure
        Public Class ResourceData
            ' /* ResourceData Class - Class which handles resource details for different resources to be viewed.
            Private m_Name As String
            Private m_Type As String
            Private m_Number As Integer
            Private m_dataSize As ULong
            Private m_File As String
            Private m_File_Offset As ULong
            Public Sub New()

            End Sub
            Public Sub New(name As String, type As String, number As Integer, size As ULong, file As String, offset As ULong)
                Me.Name = name
                Me.Type = type
                Me.Number = number
                Me.Size = size
                Me.File = file
                Me.Offset = offset
            End Sub
            Public Property Name As String
                Get
                    Return m_Name
                End Get
                Set(value As String)
                    m_Name = value
                End Set
            End Property
            Public Property Type As String
                Get
                    Return m_Type
                End Get
                Set(value As String)
                    m_Type = value
                End Set
            End Property
            Public Property Number As Integer
                Get
                    Return m_Number
                End Get
                Set(value As Integer)
                    m_Number = value
                End Set
            End Property
            Public Property Size As ULong
                Get
                    Return m_dataSize
                End Get
                Set(value As ULong)
                    m_dataSize = value
                End Set
            End Property
            Public Property File As String
                Get
                    Return m_File
                End Get
                Set(value As String)
                    m_File = value
                End Set
            End Property
            Public Property Offset As ULong
                Get
                    Return m_File_Offset
                End Get
                Set(value As ULong)
                    m_File_Offset = value
                End Set
            End Property
        End Class
        Public Class ResourceList
            '/* =================================================================================================================================================
            '/*
            '/* ResourceList Class - Organizes objects from ResourceData class into a list.  Each individual object of ResourceData is a resource.
            '/*
            '/*
            Private resources As List(Of ResourceData)
            Public Sub New()
                resources = New List(Of ResourceData)
            End Sub
            Public ReadOnly Property Count As Integer
                Get
                    Return resources.Count
                End Get
            End Property
            Default Public Property Item(index As Integer) As ResourceData
                Get
                    If index < 0 OrElse index >= resources.Count Then
                        Throw New ArgumentOutOfRangeException("index", "The index must be between 0 and " & resources.Count - 1 & ".")
                    Else
                        Return resources(index)
                    End If
                End Get
                Set(value As ResourceData)
                    resources(index) = value
                End Set
            End Property
            Public Sub Add(resource As ResourceData)
                resources.Add(resource)
            End Sub
            Public Sub Add(name As String, type As String, number As Integer, size As ULong, file As String, offset As ULong)
                Dim p As New ResourceData(name, type, number, size, file, offset)
                resources.Add(p)
            End Sub
        End Class
        Public Class ResourceDetails
            Public Name As String
            Public resourceType As String
            Public Number As Integer
            Public dataSize As Integer
            Public resourceFile As String
            Public fileOffset As Integer
        End Class
        Public Class FRMLHeader
            Public Name As String
            Public Offset As Integer
            Public Chunk_Size As Integer
            Public UChunk_Size As Long
            Public byte8 As Byte
            Public Cels As UShort
            Public Cel_Data_Start As Integer
            Public filename As String
        End Class
        Public Class RGBValues
            Private m_Red As Integer
            Private m_Green As Integer
            Private m_Blue As Integer
            Public Sub New()
                ' DEFAULT NEW METHOD
            End Sub
            Public Sub New(r As Integer, g As Integer, b As Integer)
                ' NEW METHOD FOR INVDIVIDUAL VALUES
                Me.RedValue = r
                Me.GreenValue = g
                Me.BlueValue = b
            End Sub
            Public Property RedValue As Integer
                Get
                    Return m_Red
                End Get
                Set(value As Integer)
                    m_Red = value
                End Set
            End Property
            Public Property GreenValue As Integer
                Get
                    Return m_Green
                End Get
                Set(value As Integer)
                    m_Green = value
                End Set
            End Property
            Public Property BlueValue As Integer
                Get
                    Return m_Blue
                End Get
                Set(value As Integer)
                    m_Blue = value
                End Set
            End Property
        End Class
        Public Class RGBColorList
            ' Creates a List of RGB Value items for use with palettes.
            Private p_colors As List(Of RGBValues)

            Public ReadOnly Property Count As Integer
                Get
                    Return p_colors.Count
                End Get
            End Property
            Public Sub New()
                p_colors = New List(Of RGBValues)
            End Sub

            Default Public Property Item(index As Integer) As RGBValues
                Get
                    If index < 0 OrElse index >= p_colors.Count Then
                        Throw New ArgumentOutOfRangeException("index", "The index must be between 0 and " & p_colors.Count - 1 & ".")
                    Else
                        Return p_colors(index)
                    End If
                End Get
                Set(value As RGBValues)
                    p_colors(index) = value
                End Set
            End Property
            Public Sub add(values As RGBValues)
                p_colors.Add(values)
            End Sub
        End Class
        Public Shared Function ConvertToRGB(ByVal Hexcolor As String) As resource.RGBValues
            Dim p_list As New resource.RGBValues
            Hexcolor = Replace(Hexcolor, "#", "")
            p_list.RedValue = Val("&H" & Mid(Hexcolor, 1, 2))
            p_list.GreenValue = Val("&H" & Mid(Hexcolor, 3, 2))
            p_list.BlueValue = Val("&H" & Mid(Hexcolor, 5, 2))
            Return p_list
        End Function
        Public Class FRML_OFFSET
            Public Name As String
            Public Data_Offset As Integer
            Public Address_Offset As Integer
        End Class
        ' ========================== SHARED METHODS ============================================================
        Public Shared Function imageColorNew(ByVal nibble As Byte, palette As resource.RGBColorList) As Color
            Return Color.FromArgb(palette(nibble).RedValue, palette(nibble).GreenValue, palette(nibble).BlueValue)
        End Function
    End Class



    Public Shared Function validateHeader(ByVal resfilename As String, ByVal endianness As UShort) As Boolean
        ' VALIDATES THE HEADER ON RESOURCE FILE
        Dim p_headsize As UInteger
        Dim p_endsize As UInteger
        Dim p_headDataSegment As UInteger
        Dim p_endDataSegment As UInteger
        Dim checkHeader As New resource.Header
        Dim checkEnder As New resource.Header
        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo(resfilename)
        Using resreader As New BinaryFile(resfilename)
            If CheckEOF(resfilename, resreader.Position) = False Then
                MsgBox("File pointer locations is beyond EOF (" & resreader.Position & ")!  Invalid Resource " & resfilename)
            Else
            End If
            p_headsize = resreader.ReadLongwordUnsigned(endianness)
            p_headDataSegment = resreader.ReadLongwordUnsigned(endianness)
            resreader.Position = p_headDataSegment
            p_endsize = resreader.ReadLongwordUnsigned(endianness)
            p_endDataSegment = resreader.ReadLongwordUnsigned(endianness)
            If p_headsize = p_endsize And p_headDataSegment = p_endDataSegment Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function
    Public Shared Function CheckEOF(resfilename As String, position As Integer) As Boolean
        Dim p_result As Boolean
        Dim p_InfoReader = My.Computer.FileSystem.GetFileInfo(resfilename)
        If position >= p_InfoReader.Length Then
            MsgBox(p_InfoReader.Length)
            p_result = False
            Return p_result
        Else
            p_result = True
            Return p_result
        End If
    End Function
    Public Shared Function _readResourceHeader(filename As String, tempEnd As Integer) As Game.resource.Header
        ' *** Reads Header Data
        Dim tempheader As New Game.resource.Header
        Using tempReader As New BinaryFile(filename)
            tempheader.Size = tempReader.ReadLongwordUnsigned(tempEnd)
            tempheader.DataSegmentSize = tempReader.ReadLongwordUnsigned(tempEnd)
            tempheader.DataSize = tempReader.ReadLongwordUnsigned(tempEnd)
            tempheader.FileEndLength = tempReader.ReadLongwordUnsigned(tempEnd)
        End Using
        Return tempheader
    End Function
    Public Shared Function getResKeyPosition(filename As String, tempEnd As Integer) As Integer
        ' **************************************************************************************
        ' *** Returns the file position of the start of the resource map key in the file.    ***
        ' **************************************************************************************
        Dim ChunkQTY As Integer
        Dim tempHeader As New resource.Header
        Dim chunkPosition As Integer
        Using tempReader As New BinaryFile(filename)
            tempHeader.Size = tempReader.ReadLongwordUnsigned(tempEnd)
            tempHeader.DataSegmentSize = tempReader.ReadLongwordUnsigned(tempEnd)
            tempReader.Position = (tempHeader.DataSegmentSize + tempHeader.Size) + (12)
            ChunkQTY = tempReader.ReadWordUnsigned(tempEnd) + 1
            chunkPosition = ((tempHeader.DataSegmentSize + tempHeader.Size) + 14) + ((8) * (ChunkQTY))
        End Using
        Return chunkPosition
    End Function
    Public Shared Function _getChunkTypeQTY(filename As String, tempend As Integer) As Integer
        ' ====================================================================================
        '  Returns number of a specific chunk type in the resource file.
        ' ====================================================================================
        Dim tempHeader As New resource.Header
        Dim filepointer As Integer
        Dim chunkTypeQty As Integer
        tempHeader = _readResourceHeader(filename, tempend)
        filepointer = (tempHeader.DataSegmentSize + tempHeader.Size) + (12)
        Using resReader As New BinaryFile(filename)
            resReader.Position = filepointer
            chunkTypeQty = resReader.ReadWordUnsigned(tempend) + 1
        End Using
        Return chunkTypeQty
    End Function
    Public Shared Function _getChunkSize(filename As String, fpoint As ULong, tempend As Integer) As ULong
        Dim chunksize As ULong
        Using resReader As New BinaryFile(filename)
            resReader.Position = fpoint
            chunksize = resReader.ReadLongwordUnsigned(tempend)
        End Using
        Return chunksize
    End Function
    Public Shared Function _getChunkID(filename As String, fpoint As Integer, tempend As Integer) As String
        Dim chunktype As Integer
        Dim charRes As String
        Using resReader As New BinaryFile(filename)
            resReader.Position = fpoint
            chunktype = resReader.ReadLongwordUnsigned(Endianness.endBig)
            Dim abyte() As Byte = BitConverter.GetBytes(chunktype)
            If tempend = 1 Then
                charRes = Chr(abyte(abyte.Length - 1))
                For k As Integer = abyte.Length - 2 To 0 Step -1
                    charRes = charRes + Chr(abyte(k))
                Next k
            Else
                charRes = Chr(abyte(0))
                For k As Integer = 1 To abyte.Length - 1
                    charRes = charRes + Chr(abyte(k))
                Next k
            End If
        End Using
        Return charRes
    End Function
    Public Shared Function _getChunkQTY(filename As String, fpoint As Integer, tempend As Integer) As Integer
        Dim chunkQty As Integer = 0
        Using resReader As New BinaryFile(filename)
            resReader.Position = fpoint
            chunkQty = resReader.ReadWordUnsigned(tempend) + 1
        End Using
        Return chunkQty
    End Function
    Public Shared Function _getResourceFileChunkTotal(filename As String, tempend As Integer) As Integer
        ' *************************************************************************************
        ' *** Gets the number of resource chunks in a resource file.                        ***
        ' *************************************************************************************
        Dim tempHeader As New resource.Header
        Dim chunkTypeQTY As Integer
        Dim chunkpos As Integer
        Dim filepointer As Integer
        Dim tempChunkQTY As Integer
        tempHeader = _readResourceHeader(filename, tempend)
        chunkTypeQTY = _getChunkTypeQTY(filename, tempend)
        filepointer = (tempHeader.DataSegmentSize + tempHeader.Size) + (18)
        Dim rID(chunkTypeQTY) As resource.resourceIdentifier
        chunkpos = getResKeyPosition(filename, tempend)
        For x = 0 To chunkTypeQTY - 1
            tempChunkQTY = tempChunkQTY + _getChunkQTY(filename, filepointer, tempend)
            filepointer = filepointer + 8
        Next
        Return tempChunkQTY
    End Function
    Public Shared Function _readResMapNum(filename As String, fpoint As Integer, tempend As Integer) As Integer
        Dim tempNum As Integer
        Using resReader As New BinaryFile(filename)
            resReader.Position = fpoint
            tempNum = resReader.ReadWordUnsigned(tempend)
        End Using
        Return tempNum
    End Function
    Public Shared Function _readResMapOffset(filename As String, fpoint As Integer, tempend As Integer) As UInt16
        ' Gets chunk location offset value in Resource Key
        Dim tempNum As UInteger
        If tempend = 1 Then
            fpoint = fpoint + 2
        End If
        Using resReader As New BinaryFile(filename)
            resReader.Position = fpoint
            tempNum = resReader.ReadWordUnsigned(tempend)
        End Using
        Return tempNum
    End Function
    Public Shared Function _readResMapMultiplier(filename As String, fpoint As Integer, tempend As Integer) As Integer
        Dim tempNum As Integer
        If tempend = 1 Then
            fpoint = fpoint - 1
        End If
        Using resReader As New BinaryFile(filename)
            resReader.Position = fpoint
            tempNum = resReader.ReadByte
        End Using
        Return tempNum
    End Function
    Public Shared Function _getResourceType(type As String) As String
        For x As Integer = 0 To 5
            If type = resource.RES_ID(x) Then
                Return resource.RES_ID_ELEMENTS(x)
            End If
        Next
        Return "ERROR"
    End Function
    Public Shared Function CalculateCanvasWidth(ClipWidth As Integer) As Integer
        Dim Modulus As Integer, Result As Integer
        Modulus = ClipWidth Mod 16
        Result = (ClipWidth \ 16) * 16
        If Modulus > 0 Then
            Result = Result + 16
        End If
        Return Result
    End Function
    Public Shared Function getIMAGDataOffsetValue(format As String, planeCount As UShort) As UShort
        ' ========================= get IMAGDataOffsetValue ====================================
        ' Calculates the location offset from the chunk start offset where the imag data begins.
        ' If image is a larger image which requires a word instead of a byte for the width, then
        ' offset is greater than regular offset.
        ' ======================================================================================
        Dim p_offset As UShort
        Dim is16Bit As Boolean = (format = PC_VGA_FORMAT Or format = AMIGA_FORMAT Or format = ST_FORMAT)
        If is16Bit And planeCount = 3 Then
            p_offset = 21
        Else
            p_offset = 20
        End If
        Return p_offset
    End Function
    Public Shared Function getDataEndian(format) As Integer
        Dim p_Endian As Integer
        For p As Integer = 0 To FORMAT_ID.Length - 1
            If format = FORMAT_ID(p) Then
                p_Endian = DATA_ENDIAN(p)
                Exit For
            End If
        Next
        Return p_Endian
    End Function
    Public Shared Function GetFRMLChunk(resourcefilename As String, tempformat As String, fp As Integer, tempend As Integer, dataendian As Integer) As Game.resource.FRMLHeader
        Dim p_FRMLHeader As New Game.resource.FRMLHeader
        Dim p_strFormat As String = tempformat
        Dim p_bgFlag As Boolean = True
        Dim p_celstart As Integer
        Dim p_dataEndian As Integer : p_dataEndian = getDataEndian(tempformat)
        p_FRMLHeader.Offset = fp
        Try
            Using resreader As New BinaryFile(resourcefilename)
                resreader.Position = fp
                p_FRMLHeader.Chunk_Size = resreader.ReadLongwordUnsigned(tempend)
                p_FRMLHeader.UChunk_Size = resreader.ReadLongwordUnsigned(tempend)
                If p_FRMLHeader.UChunk_Size > (p_FRMLHeader.Chunk_Size * 3) Then
                    p_FRMLHeader.UChunk_Size = p_FRMLHeader.Chunk_Size
                    resreader.Position = resreader.Position - 5
                End If
                p_FRMLHeader.byte8 = resreader.ReadByteUnsigned
                p_FRMLHeader.Cels = resreader.ReadWordUnsigned(p_dataEndian)
                If p_FRMLHeader.Cels >= 270 Then
                    resreader.Position = resreader.Position - 1
                    p_FRMLHeader.Cels = resreader.ReadByteUnsigned()
                End If
                p_celstart = resreader.ReadWordUnsigned(dataendian)
            End Using
            p_FRMLHeader.Cel_Data_Start = (p_FRMLHeader.Offset + 8) + (p_celstart)
        Catch ex As Exception
            MsgBox("Class Error!  Error in Game class, getFRMLChunk Function!  " & ex.ToString)
        End Try
        Return p_FRMLHeader
    End Function
    Public Shared Function GetIMAGChunk(resourcefilename As String, tempformat As String, fp As Integer, tempend As Integer) As Game.resource.imageChunk
        Dim tchunk As New Game.resource.imageChunk
        Dim format As String = tempformat
        Dim is16Bit As Boolean = (format = PC_VGA_FORMAT Or format = AMIGA_FORMAT Or format = ST_FORMAT)
        Dim bgFlag As Boolean
        bgFlag = False
        Using resreader As New BinaryFile(resourcefilename)
            resreader.Position = fp
            tchunk.offset = fp
            tchunk.chunkSize = resreader.ReadLongwordUnsigned(tempend)
            tchunk.uncompressed_size = resreader.ReadLongwordUnsigned(tempend)
            If tchunk.chunkSize > tchunk.uncompressed_size Then
                tchunk.uncompressed_size = tchunk.chunkSize
                bgFlag = True
            End If
            For x = 0 To 4
                tchunk.iByte(x) = resreader.ReadByte
            Next
            If is16Bit Then
                tchunk.bitplane = resreader.ReadByte
            Else
                tchunk.bitplane = 0
            End If



            If bgFlag = True Then
                resreader.Position = fp + 23
                bgFlag = False
            ElseIf bgFlag = False Then
                resreader.Position = fp + 16
            End If
            tchunk.imagePlane = resreader.ReadByte
            If is16Bit Then
                If tchunk.imagePlane = 3 Then
                    tchunk.width = resreader.ReadWordUnsigned(Endianness.endBig)
                    tchunk.height = resreader.ReadWordUnsigned(Endianness.endBig)
                Else
                    tchunk.width = resreader.ReadByte
                    tchunk.height = resreader.ReadWordUnsigned(Endianness.endBig)
                End If
            Else
                tchunk.width = resreader.ReadWordUnsigned(tempend)
                tchunk.height = resreader.ReadByte
            End If
            tchunk.canvassWidth = CalculateCanvasWidth(tchunk.width)
        End Using
        bgFlag = False
        Return tchunk
    End Function
    Public Class Archive
        ' ===================================================================== ARCHIVE SUB-CLASS ===================================================================================================
        '   SUB-CLASS IN THE GAME CLASS.  GAME CONTAINS RESOURCES AND A SAVE GAME (ARCHIVE).  CONTAINS VARIABLES AND METHODS SPECIFIC TO ARCHIVE FILES.
        ' ===========================================================================================================================================================================================
        Public Const FILENAME = "ARCHIVE.DAT"
        Public Const ARC_ID = "ARCHIVE"
        Public Const ARC_ID_ELEMENTS As String = "SAVE"
        Public Const DESCRIPTION = "SAVE"
        Structure EXEData
            Public CharacterName As String
            Public Value As Integer
            Public Length As Integer
        End Structure
        Public Class Character
            Public CharacterName As String
            Public nameIdentifier As UInt16
            Public unknownBlock As UInt16
            Public armyTotal As UInt16
            Public armyQuantity As UInt16
            Public locationX As UInt16
            Public locationY As UInt16
            Public destinationX As UInt16
            Public destinationY As UInt16
            Public gameObjects As UInt16
            Public mapIcon As Byte
            Public spriteColor As Byte
            Public spriteType As Byte
            Public byte22 As Byte
            Public Visibility As Byte
            Public byte24 As Byte
            Public powerLevel As Byte
            Public moraleTotal As Byte
            Public moraleQuantity As Byte
            Public byte28 As Byte
            Public valueMobilize As Byte
            Public Stealth As Byte
            Public byte31 As Byte
            Public byte32 As Byte
            Public byte33 As Byte
            Public hpTotal As Byte
            Public hpCurrent As Byte
            Public valueLeaderFollow As Byte
            Public byte37 As Byte
            Public intFileStart As Integer
        End Class
        Public Class fileData
            Public characterFollowName(0 To 44) As String
            Public characterFollowvalue(0 To 44) As Integer
            Public cityIcon(CITY_MAX - 15) As Integer
            Public cityName(CITY_MAX - 15) As Integer
            Public cityCopyProtectionCoordinate(CITY_MAX - 15) As String
            Public mapSpriteName(0 To 30) As String
            Public mapSpriteValue(0 To 30) As Integer
            Public spriteName(0 To 51) As String
            Public spriteValue(0 To 51) As Integer
            Public spriteColor(0 To 51) As Integer
            Public mobilizedText(0 To 5) As String
            Public mobilizedValue(0 To 5) As Integer
        End Class
    End Class
    Public Shared Function GetArmyName(value As Integer, endian As Integer) As String
        ' Function evaluates character value and returns character name.
        Dim tempString As String = ""
        For x As Integer = 0 To CHARACTER_MAX
            If value = CharacterEXE(x).Value Then
                tempString = CharacterEXE(x).Name
            End If
        Next x
        Return tempString
    End Function
    Public Shared Function getCityBlockSize(tempend As Integer) As Integer
        Select Case tempend
            Case 0
                Return cityBlockSize.LittleEndian
            Case Else
                Return cityBlockSize.BigEndian
        End Select
    End Function
    Public Shared Function _getBlockLength(tempend As Integer) As Integer
        ' Determines the length of the savegame's data block based on the endianness.
        If tempend = 0 Then
            Return archiveBlockSize.LittleEndian
        Else
            Return archiveBlockSize.BigEndian
        End If
    End Function
    Public Shared Function _getArcOffset(tempend As Integer, index As Integer) As Integer
        Dim tempBlock As Integer = ((0) + (_getBlockLength(tempend) * index))
        Return tempBlock
    End Function
    Public Shared Function getObjectValue(characternum As Integer)
        Return archiveCharacterArray(characternum).gameObjects
    End Function
    Public Class Executable
        Public Class EXEData
            Public Name As String
            Public Value As UShort
            Public Offset As UInteger
        End Class
        Public Class EXECity
            Inherits EXEData
            Public X As UShort
            Public Y As UShort
        End Class
        Public Class GameLocations
            Public Shared WimeCityData As New Game.Archive.fileData
            Public Shared WimeCityDBData As New Game.Archive.fileData
        End Class
        Public Class Inventory
            Public name(0 To OBJECT_TOTAL) As String
            Public value(0 To OBJECT_TOTAL) As UShort
        End Class
        Public Class CopyProtectionData
            Public Name As String
            Public Value As String
        End Class
    End Class
    Public Shared Function getCityName(xcoord As Integer, ycoord As Integer) As String
        Dim tempCity As String
        Dim tempCoord As Integer
        Dim tempCityData As New Executable.EXECity
        tempCoord = xcoord & ycoord
        For x = 0 To CITY_MAX
            tempCityData.X = CityEXE(x).X : tempCityData.Y = CityEXE(x).Y : tempCityData.Name = CityEXE(x).Name
            If tempCoord = tempCityData.X & tempCityData.Y Then
                tempCity = tempCityData.Name
                Return tempCity
            End If
        Next x
        Return UNKNOWN
    End Function
    Public Shared Function getEXECharValue(format As String) As Integer
        Dim returnValue As Integer = 0
        For i As Integer = 0 To FORMAT_ID.Length - 1
            If format = FORMAT_ID(i) Then
                returnValue = OFFSET_EXECharVal(i)
            End If
        Next i
        Return returnValue
    End Function
    Public Shared Function getObjectOffset(format As String) As Integer
        Dim p_formatTotal As Integer
        p_formatTotal = FORMAT_ID.Length
        Dim returnValue As Integer = 0
        For i As Integer = 0 To p_formatTotal - 1
            If format = FORMAT_ID(i) Then
                returnValue = OFFSET_InvObj(i)
            End If
        Next i
        Return returnValue
    End Function
    Public Shared Sub readCharEXE(filename As String, formatType As String, ByRef formatIndex As Integer, ByRef endian As Integer)
        Dim tempLoc As UShort
        Dim filepointer As Integer
        Dim tempCharacterEXE As Executable.EXEData
        Dim differenceValue As Integer
        Dim tempval As Integer = 0 : Dim newval As Integer = 0
        Dim tempEndian As Integer
        tempEndian = endian
        Dim tempExec As String = gameExecutables(formatIndex)
        filepointer = OFFSET_CharacterData(formatIndex)
        differenceValue = OFFSET_EXEOffset(formatIndex)
        CharacterEXE = New List(Of Executable.EXEData)
        Try
            Select Case formatType
                Case FORMAT_ID(0)                         ' Special Handling for PC VGA Version
                    Using resread As New BinaryFile(filename)
                        Dim ptr As Integer = filepointer
                        Dim i As Integer = 0
                        Do While ptr < 111738
                            tempCharacterEXE = New Executable.EXEData
                            resread.Position = ptr
                            tempLoc = resread.ReadWordUnsigned
                            If tempLoc = 6002 Then
                                Dim tempname As String = ""
                                resread.Position = resread.Position - 4
                                tempCharacterEXE.Offset = resread.ReadWordUnsigned(tempEndian)
                                newval = tempCharacterEXE.Offset + differenceValue
                                resread.Position = newval
                                Do
                                    tempval = resread.ReadByte
                                    If tempval = 0 Then Exit Do
                                    tempname = tempname & Chr(tempval)
                                Loop
                                tempCharacterEXE.Name = tempname
                                tempCharacterEXE.Value = tempCharacterEXE.Offset + getEXECharValue(formatIndex)
                                CharacterEXE.Add(tempCharacterEXE)
                                i = i + 1
                                If i >= (CHARACTER_MAX + 1) Then Exit Do
                            End If
                            ptr = ptr + 1
                        Loop
                    End Using
                Case Else                                               ' Special Handling for other versions
                    Using resread As New BinaryFile(filename)
                        Dim ptr As Integer = filepointer

                        For p As Integer = 0 To CHARACTER_MAX
                            tempCharacterEXE = New Executable.EXEData
                            Dim tempname As String = ""
                            resread.Position = ptr + (_getBlockLength(tempEndian) * (1 * p))
                            tempCharacterEXE.Offset = resread.ReadWordUnsigned(tempEndian)
                            newval = tempCharacterEXE.Offset + differenceValue
                            resread.Position = newval
                            Do
                                tempval = resread.ReadByte
                                If tempval = 0 Then Exit Do
                                tempname = tempname & Chr(tempval)
                            Loop
                            tempCharacterEXE.Name = tempname
                            tempCharacterEXE.Value = tempCharacterEXE.Offset + getEXECharValue(formatIndex)
                            CharacterEXE.Add(tempCharacterEXE)
                        Next p
                    End Using
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString & "  readChar subroutine in frmArcView.")
        End Try
    End Sub
    Public Shared Sub readCityEXE(filename As String, formatType As String, ByRef formatIndex As Integer, ByRef endian As Integer)
        Dim tempCityData As Executable.EXECity
        Dim UWORD As UInteger : Dim UBYTE As Byte
        Dim filepointer As Integer
        Dim namepointer As Integer
        Dim differenceValue As Integer
        Dim tempVal As Integer = 0
        Dim newval As Integer = 0
        Dim tempEndian As Integer
        tempEndian = endian
        filepointer = OFFSET_CityData(formatIndex)
        namepointer = OFFSET_CityName(formatIndex)
        differenceValue = OFFSET_EXEOffset(formatIndex)
        CityEXE = New List(Of Executable.EXECity)
        Select Case tempEndian
            Case 0
                Using resread As New BinaryFile(filename)
                    For i As Integer = 0 To CITY_MAX
                        tempCityData = New Executable.EXECity
                        Dim ptr As Integer = (filepointer) + (getCityBlockSize(tempEndian) * i)
                        Dim tempname As String = ""
                        resread.Position = ptr
                        tempCityData.Offset = resread.ReadWordUnsigned(tempEndian)
                        UWORD = resread.ReadWordUnsigned(tempEndian)
                        tempCityData.X = resread.ReadWordUnsigned(tempEndian)
                        tempCityData.Y = resread.ReadWordUnsigned(tempEndian)
                        UBYTE = resread.ReadByteUnsigned
                        newval = tempCityData.Offset + differenceValue
                        resread.Position = newval
                        Do
                            tempVal = resread.ReadByte
                            If tempVal = 0 Then Exit Do
                            tempname = tempname & Chr(tempVal)
                        Loop
                        tempCityData.Name = tempname
                        CityEXE.Add(tempCityData)

                    Next i
                End Using
            Case Else
                Using resread As New BinaryFile(filename)
                    For i As Integer = 0 To CITY_MAX
                        tempCityData = New Executable.EXECity
                        Dim ptr As Integer = (filepointer) + (getCityBlockSize(tempEndian) * i)
                        Dim tempname As String = ""
                        resread.Position = ptr
                        tempCityData.Offset = resread.ReadWordUnsigned(tempEndian)
                        UWORD = resread.ReadWordUnsigned(tempEndian)
                        tempCityData.X = resread.ReadWordUnsigned(tempEndian)
                        tempCityData.Y = resread.ReadWordUnsigned(tempEndian)
                        UBYTE = resread.ReadByteUnsigned
                        newval = tempCityData.Offset + differenceValue
                        resread.Position = newval
                        Do
                            tempVal = resread.ReadByte
                            If tempVal = 0 Then Exit Do
                            tempname = tempname & Chr(tempVal)
                        Loop
                        tempCityData.Name = tempname
                        CityEXE.Add(tempCityData)
                    Next i
                End Using
        End Select
    End Sub
    Public Shared Function GetFormatValueByType(format As String) As Integer
        Dim p_value As Integer
        For x As Integer = 0 To FORMAT_ID.Length - 1
            If format = FORMAT_ID(x) Then
                p_value = x
                Exit For
            End If
            p_value = -1
        Next
        Return p_value
    End Function
    Public Class PaletteData
        Public Sub New()
        End Sub
        Public Sub New(slot As UShort, value As String)
            Me.Slot = slot
            Me.ColorValue = value
        End Sub
        Public Property Slot As UShort
        Public Property ColorValue As String
        Public Class ColorList
            ' ============================= COLORLIST CLASS ======================================================================
            Private colors As List(Of PaletteData)
            Public Sub New()
                colors = New List(Of PaletteData)
            End Sub
            Public ReadOnly Property Count As Integer
                Get
                    Return colors.Count
                End Get
            End Property
            Default Public Property item(index As Integer) As PaletteData
                Get
                    If index < 0 OrElse index >= colors.Count Then
                        Throw New ArgumentOutOfRangeException("index", "The index must be between 0 and " & colors.Count - 1 & ".")
                    Else
                        Return colors(index)
                    End If
                End Get
                Set(value As PaletteData)
                    colors(index) = value
                End Set
            End Property
            Public Sub add(color As PaletteData)
                colors.Add(color)
            End Sub
            Public Sub Add(slot As UShort, value As String)
                Dim p As New PaletteData(slot, value)
                colors.Add(p)
            End Sub
        End Class
    End Class
End Class


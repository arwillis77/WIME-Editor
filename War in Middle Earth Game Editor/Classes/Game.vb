Imports System.IO
Imports System.Xml
' // =============================================================== WAR IN MIDDLE EARTH GAME CLASS ============================================================================
' // 
' // VERSION 1.6 -- 8/16/2018
' // VERSION 1.5 - MOST RECENT VERSION 11/04/2015
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


    Public Shared PC_VGA_ICON As System.Drawing.Image = My.Resources.msdosicon
    Public Shared PC_EGA_ICON As System.Drawing.Image = My.Resources.msdosicon
    Public Shared IIGS_ICON As System.Drawing.Image = My.Resources.apple2icon
    Public Shared AMIGA_ICON As System.Drawing.Image = My.Resources.amigamenulogo
    Public Shared ST_ICON As System.Drawing.Image = My.Resources.atarilogo
    Public Const IMAGES As String = "IMAGES"
    Public Const TILES As String = "TILES"
    Public Const SPRITES As String = "SPRITES"
    Public Const SPRITEDATA As String = "SPRITEDATA"

    Public Const ST_BITPLANES = 4
    Public Const TILE_PIXELS = 256
    'Public Shared OFFSET_BANNERICONS = {4, 5, 5, 4, 4}
    ' Public Shared OFFSET_TileStart = {43907, 301405, 20, 8038, 8038}
    Public Shared AMIGA_CHUNK = 40992
    Public Shared ST_CHUNK = 40992
    ' Public Shared FORMAT_BITPLANES() As Integer = {PC_VGA_BITPLANES, PC_EGA_BITPLANES, IIGS_BITPLANES, AMIGA_BITPLANES, ST_BITPLANES}
    Public Shared gameExecutables() As String = {PC_VGA_EXE, PC_EGA_EXE, IIGS_EXE, AMIGA_EXE, ST_EXE}
    Public Shared FORMAT_ID() As String = {PC_VGA_FORMAT, PC_EGA_FORMAT, IIGS_FORMAT, AMIGA_FORMAT, ST_FORMAT}
    Public Shared BANNERICON_VALUES = {0, 1, 2, 3, 4, 5, 16, 17, 18, 19, 20, 21, 32, 33, 34, 35, 36, 37, 48, 49, 50, 51, 52, 53, 64, 65, 66, 67, 68, 69}
    Public Shared CHAR_OFFSET As UShort = 4
    Public Const CHARACTER_MAX As Integer = 193
    Public Const Default_City = "HINTERLAND"
    Public Const UNKNOWN As String = "UNKNOWN"
    Public Shared ARCHIVE_FILE As String
    Public Const ICON_TOTAL = 30
    Public Const OBJECT_TOTAL = 16
    Public Const TILE_TOTAL = 255
    Public Const ImageWidth = 320
    Public Const ImageHeight = 200

    Public Shared FRML_ResourceKey_Elements = 4
    Public Shared DATA_FILES = Application_Path & "\" & "WIMEDATA.XML"
    Enum ArchiveBlockSize
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

        Me.format = FORMAT_ID(Me.formatVal)
        Me.endianType = EndianChecker(Me.format)

    End Sub
    ' ============================= SUB-CLASSES ===============================================

    ' ============================= METHODS ===================================================


    Public Shared Function EndianChecker(format As String) As UShort
        Dim tempVal As UShort
        If format = FORMAT_ID(0) Or format = FORMAT_ID(1) Or format = FORMAT_ID(2) Then
            tempVal = Endianness.endLittle
        Else
            tempVal = Endianness.endBig
        End If
        Return tempVal
    End Function




    'Public Shared Function Get_FRML_Offset(ByVal filename As String, format As String, resource_name As String) As Game.resource.FRML_OFFSET
    '    ' /* FUNCTION DECLARATIONS
    '    Dim settings As New XmlReaderSettings With {
    '    .IgnoreWhitespace = True,
    '    .IgnoreComments = True
    '    }
    '    Dim p_file As String = DATA_FILES
    '    Dim p_string As String = ""
    '    Dim p_offset As New Game.resource.FRML_OFFSET
    '    Dim xmlOffsetRead As XmlTextReader
    '    xmlOffsetRead = New XmlTextReader(p_file)
    '    xmlOffsetRead.MoveToContent()
    '    Do While xmlOffsetRead.Read
    '        xmlOffsetRead.Read()
    '        If xmlOffsetRead.Name = "FORMAT" Then
    '            p_string = xmlOffsetRead.GetAttribute("ID")
    '            'MsgBox("PSTRING " & p_string)
    '            If p_string = format Then
    '                'MsgBox("Format " & format)
    '                xmlOffsetRead.ReadToDescendant("FRMLOFFSETS")
    '                xmlOffsetRead.ReadToDescendant("RESOURCE")
    '                Do
    '                    p_string = xmlOffsetRead.GetAttribute("ID")
    '                    If p_string = resource_name Then
    '                        xmlOffsetRead.ReadToDescendant("DataOffset")
    '                        p_offset.Data_Offset = xmlOffsetRead.ReadInnerXml
    '                        xmlOffsetRead.Read()
    '                        p_offset.Address_Offset = xmlOffsetRead.ReadInnerXml
    '                    End If
    '                Loop While xmlOffsetRead.ReadToNextSibling("RESOURCE")
    '            End If
    '        End If
    '        If xmlOffsetRead.EOF Then
    '            MsgBox("End of File!")
    '            Exit Do
    '        End If
    '    Loop
    '    Return p_offset
    'End Function
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
        Public totalChunks As UShort

        ' ==================================================== SUB CLASSES ===============================================================================
        Public Shared Sub UnpackAmigaTiles(ByVal tilefile As String, datadir As String, toffset As Integer, tchunk As Integer)
            Dim inputfile As New BinaryFile(tilefile)
            Dim outputfile As New BinaryFile(datadir & "\Tiles.raw")
            Dim unpacker As New ByteRunUnpacker(inputfile)
            Dim result As Byte() = unpacker.UnpackTiles(toffset, tchunk)
            outputfile.Write(result, 0, result.Length)
            MsgBox(datadir & "\Tiles.raw" & " Closed! " & toffset & " " & tchunk)
            inputfile.Close() : outputfile.Close()
        End Sub
        Public Shared Function GetTileChunk(filename As String, endian As Short, offset As Integer) As Integer
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
        Public Structure ResourceMap
            Public Number As Integer
            Public Offset As Integer
            Public intMultiplier As Integer
        End Structure
        Public Class ImageChunk
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
                    If index < 0 OrElse index > p_colors.Count - 1 Then

                        Throw New ArgumentOutOfRangeException("index", "Index Value " & index & "The index must be between 0 and " & p_colors.Count - 1 & ".")
                    Else
                        Return p_colors(index)
                    End If
                End Get
                Set(value As RGBValues)
                    p_colors(index) = value
                End Set
            End Property
            Public Sub Add(values As RGBValues)
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
    Public Shared Function ValidateHeader(ByVal resfilename As String, ByVal endianness As UShort) As Boolean
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
    Public Shared Function GetIMAGChunk(resourcefilename As String, tempformat As String, fp As Integer, tempend As Integer) As Game.resource.ImageChunk
        Dim tchunk As New Game.resource.ImageChunk
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
    Public Shared Function GetArchiveFileBlockLength(tempend As Integer) As Integer
        ' Determines the length of the savegame's data block based on the endianness.  Resource class function.
        If tempend = 0 Then
            Return ArchiveBlockSize.LittleEndian
        Else
            Return ArchiveBlockSize.BigEndian
        End If
    End Function
    Public Shared Function GetArchiveOffset(tempend As Integer, index As Integer) As Integer
        ' Used to get offset for Archive File Resource.  Resource class function.
        Dim tempBlock As Integer = ((0) + (GetArchiveFileBlockLength(tempend) * index))
        Return tempBlock
    End Function
    Public Shared Function GetObjectValue(characternum As Integer)
        Return archiveCharacterArray(characternum).gameObjects
    End Function
End Class


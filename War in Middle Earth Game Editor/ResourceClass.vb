' RESOURCE CLASS FOR WIMEEDITOR
' LAST UPDATE 03/23/2014
' Contains all the variables, classes, structures, and methods used when handling resource files in the game editor.
Imports System.IO
Imports WIMEEditor.BinaryFile
Imports WIMEEditor.EditorSettings
Imports WIMEEditor.Game
Public Class ResourceClass
    ' DECLARATIONS FOR RESOURCE TYPES
    'Public Shared RES_ID() As String = {"CHAR", "CSTR", "FONT", "FRML", "IMAG", "MMAP"}

    'Public Shared RES_ID_ELEMENTS() As String = {"TILE", "TEXT STRING", "FONT", "ANIMATION", "IMAGE", "GAME MAP", "CHARACTER"}
    Public Shared ALT_ID As String = "TILESINGLE"
  
    Public Shared readstream As FileStream




    Public Class WIMEResourceItem
        Public Image() As Bitmap
        Public PositionX As Integer
        Public PositionY As Integer
        Public Size As Integer
        Public Width As Integer
        Public Height As Integer
        Public ItemTotal As Integer
    End Class
    Public Class resource
        Public offset As Integer
        Public size As Integer
        Public filename As String
        Public directory As String
        Public width As UInt16
        Public height As UInt16
        Public planes As Integer
    End Class
    Public Shared TILE_FILE As String
    Enum tileStart
        PC = 43908
        IIGS = 21
        Amiga = 7771
        ST = 7771
    End Enum
    Public Class offset
        Public maptileOffset(FORMAT_ID.Length - 1) As Integer
        Public tilemapOffset(FORMAT_ID.Length - 1) As Integer

    End Class
    Public Shared resourceOffset As New offset
    Public Shared Sub setResourceOffsets()
        With resourceOffset
            ' Index Number: {0= PC VGA, 1=PC EGA, 2=IIGS, 3=AMIGA, 4=ST}
            .maptileOffset = {43908, 0, 21, 7771, 7771}
            .tilemapOffset = {36161, 0, 25, 0, 0}
        End With
    End Sub
    Public Shared Function getGameMapOffset(format As String) As Integer
        Dim returnValue As Integer = 0
        For i As Integer = 0 To FORMAT_ID.Length - 1
            If format = FormatSettings.formatID(i) Then
                returnValue = resourceOffset.tilemapOffset(i)
            End If
        Next i
        Return returnValue
    End Function
    Public Shared Function getTileOffset(format As String) As Integer
        Dim returnValue As Integer = 0
        For i As Integer = 0 To FORMAT_ID.Length - 1
            If format = FormatSettings.formatID(i) Then
                returnValue = resourceOffset.maptileOffset(i)
            End If
        Next i
        Return returnValue
    End Function
    Public filename As String
    Public Shared mapTileTotal As Integer = 255
    'Public Shared resfrm As Form
    Public chunkQTY As Integer
    Public chunkPosition As Integer

    Structure resContainer
        Public Name As String
        Public number As Integer
        Public dataSize As UInteger
        Public resourceFile As String
        Public resourceType As String
        Public fileOffset As Integer
    End Structure
    Class resourceFile
    
        Class imageChunk
            Public chunkSize As UInteger    ' BYTES 1-4
            Public unkWord As UInteger      ' BYTES 5-8
            Public ByteSpacer As Byte       ' BYTE 7
            Public byte8 As Byte
            Public byte9 As Byte
            Public byte10 As Byte
            Public byte11 As Byte
            Public byte12 As Byte
            Public byte13 As Byte
            Public byte14 As Byte
            Public byte15 As Byte
            Public imageplane As Byte    ' BYTE 16
            Public resWidth As UShort
            Public resheight As UShort
            Public resPal As UInteger       ' BYTE 18
        End Class
        Structure iChunk
            Public chunkSize As ULong    ' BYTES 1-4
            Public uChunkSize As ULong      ' BYTES 5-8
            Public byte8 As Byte
            Public byte9 As Byte
            Public byte10 As Byte
            Public byte11 As Byte
            Public byte12 As Byte
            Public byte13 As Byte
            Public byte14 As Byte
            Public byte15 As Byte
            Public imageplane As Byte     ' BYTE 14
            Public resWidth As UShort     ' BYTE 15
            Public resheight As UShort    ' BYTE 16
            Public resPal As Byte      ' BYTE 18
        End Structure
        Class animCHUNK
            Public chunkSize As UInteger    ' BYTES 1-4
            Public unkWord As UInteger      ' BYTES 5-6
            Public ByteSpacer As Byte       ' BYTE 7
            Public byte8 As Byte
            Public byte9 As Byte
            Public wordSpacer As UInt16     ' BYTE 10-11
            Public byte12 As Byte
            Public byte13 As Byte
            Public imageplane As UInt16     ' BYTE 14
            Public resWidth As UInteger     ' BYTE 15
            Public resheight As UInteger    ' BYTE 16
            Public resPlane As UInteger     ' BYTE 17
            Public resPal As UInteger       ' BYTE 18
        End Class
        Public Class tileCHUNK
            Public chunkSize As UInteger    ' BYTES 1-4
            Public unkWord As UInteger      ' BYTES 5-6
            Public ByteSpacer As Byte       ' BYTE 7
            Public byte8 As Byte
            Public byte9 As Byte
            Public wordSpacer As UInt16     ' BYTE 10-11
            Public byte12 As Byte
            Public byte13 As Byte
            Public imageplane As UInt16     ' BYTE 14
            Public resWidth As UInteger     ' BYTE 15
            Public resheight As UInteger    ' BYTE 16
            Public resPlane As UInteger     ' BYTE 17
            Public resPal As UInteger       ' BYTE 18
        End Class
        
        Structure newResourceIdentifier
            Public resourceID As String
            Public resourceQTY As Integer
        End Structure
        Public Structure resourceMap
            Public Number As Integer
            Public Offset As Integer
            Public intMultiplier As Integer
        End Structure
        Public Structure resId
            Public chunkID As String
            Public chunkQTY As Integer
        End Structure
        Public Class WIMEResourceItem
            Public Image() As Bitmap
            Public PositionX As Integer
            Public PositionY As Integer
            Public Size As Integer
            Public Width As Integer
            Public Height As Integer
            Public ItemTotal As Integer
        End Class

    End Class
    'Public Shared Function validateHeader(resfilename As String) As Boolean
    '    ' VALIDATES THE HEADER ON RESOURCE FILE
    '    Dim checkHeader As New resourceFile.Header
    '    Dim checkEnder As New resourceFile.Header
    '    Dim t_endian As Integer = resEndianCheck(resfilename)
    '    Using resreader As New BinaryFile(resfilename)
    '        With checkHeader
    '            .Size = resreader.ReadLongwordUnsigned(t_endian)
    '            .DataSegmentSize = resreader.ReadLongwordUnsigned(t_endian)
    '            .DataSize = resreader.ReadLongwordUnsigned(t_endian)
    '            .FileEndLength = resreader.ReadLongwordUnsigned(t_endian)
    '            resreader.Position = .DataSegmentSize
    '        End With
    '        With checkEnder
    '            .Size = resreader.ReadLongwordUnsigned(t_endian)
    '            .DataSegmentSize = resreader.ReadLongwordUnsigned(t_endian)
    '            .DataSize = resreader.ReadLongwordUnsigned(t_endian)
    '            .FileEndLength = resreader.ReadLongwordUnsigned(t_endian)
    '        End With
    '        If checkHeader.Size = checkEnder.Size And checkHeader.DataSegmentSize = checkEnder.DataSegmentSize Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    End Using
    'End Function
    Public Shared Function resEndianCheck(filename As String) As Integer
        ' CHECKS ENDIANNESS ON RESOURCE FILES
        Dim headercheck As Int32
        readStream = New FileStream(filename, FileMode.Open)
        Dim resReader As New System.IO.BinaryReader(readStream)
        readStream.Seek(0, 0)
        headercheck = resReader.ReadInt32
        Select Case headercheck
            Case 16
                resReader.Close()
                Return Endianness.endLittle
            Case 268435456
                resReader.Close()
                Return Endianness.endBig
            Case Else
                resReader.Close()
                Return Endianness.endLittle
        End Select
    End Function


 
 
    
    'Public Shared Sub processResourceFile(resourcefilename As String, chunktotal As Integer, tempend As Integer)
    '    Dim filePointer As Integer = 0
    '    Dim tempheader As New resourceFile.Header
    '    Dim tempKey() As resourceFile.resourceMap
    '    Dim tempChunkTotal As Integer
    '    Dim tempResTotal As Integer
    '    Dim tKeyPosition As Integer
    '    Dim RFileChunkTotal As Integer
    '    tempChunkTotal = _getChunkTypeQTY(resourcefilename, tempend)
    '    Dim TResId(0 To tempChunkTotal) As resourceFile.newResourceIdentifier
    '    RFileChunkTotal = chunktotal
    '    ReDim resourceContainer.Name(RFileChunkTotal)
    '    ReDim resourceContainer.Number(RFileChunkTotal)
    '    ReDim resourceContainer.dataSize(RFileChunkTotal)
    '    ReDim resourceContainer.resourceFile(RFileChunkTotal)
    '    ReDim resourceContainer.resourceType(RFileChunkTotal)
    '    ReDim resourceContainer.fileOffset(RFileChunkTotal)
    '    Dim resCounter As Integer = 0
    '    tempheader = _readResourceHeader(resourcefilename, tempend)
    '    filePointer = (tempheader.DataSegmentSize + tempheader.Size) + (14)
    '    For x As Integer = 0 To tempChunkTotal - 1
    '        TResId(x).resourceID = _getChunkID(resourcefilename, filePointer, tempend)
    '        filePointer = filePointer + 4
    '        TResId(x).resourceQTY = _getChunkQTY(resourcefilename, filePointer, tempend)
    '        filePointer = filePointer + 4
    '    Next
    '    tKeyPosition = getResKeyPosition(resourcefilename, tempend)
    '    Dim tk As Integer = 0
    '    For xx As Integer = 0 To tempChunkTotal - 1
    '        Dim tempoff As ULong
    '        tempResTotal = TResId(xx).resourceQTY
    '        'MsgBox("ResTotal " & tempResTotal)
    '        ReDim tempKey(0 To tempResTotal)
    '        For yy As Integer = 0 To TResId(xx).resourceQTY - 1
    '            ' MsgBox(resourcefilename & " YY: " & yy)
    '            Try
    '                tempKey(yy).Number = _readResMapNum(resourcefilename, tKeyPosition + (12 * tk), tempend)
    '                tempKey(yy).Offset = _readResMapOffset(resourcefilename, (tKeyPosition + 4) + (12 * tk), tempend)
    '                tempKey(yy).intMultiplier = _readResMapMultiplier(resourcefilename, (tKeyPosition + 6) + (12 * tk), tempend)
    '                'stripfile1 = System.IO.Path.GetFileName(resourcefilename)
    '                'stripfile2 = Path.GetFileNameWithoutExtension(resourcefilename)
    '                ' Record resource file data.
    '                resourceContainer.Name(resCounter) = TResId(xx).resourceID & " " & tempKey(yy).Number
    '                resourceContainer.Number(resCounter) = tempKey(yy).Number 'resCounter + 1
    '                tempoff = (tempKey(yy).Offset + tempheader.Size) + (INT_MAX * tempKey(yy).intMultiplier) + (1 * tempKey(yy).intMultiplier)
    '                resourceContainer.dataSize(resCounter) = _getChunkSize(resourcefilename, tempoff, tempend)
    '                'resourceContainer.resourceFile(resCounter) = stripfile2
    '                resourceContainer.resourceType(resCounter) = _getResourceType(TResId(xx).resourceID)
    '                resourceContainer.fileOffset(resCounter) = (tempKey(yy).Offset + tempheader.Size) + (INT_MAX * tempKey(yy).intMultiplier) + (1 * tempKey(yy).intMultiplier)
    '                resCounter = resCounter + 1
    '                tk = tk + 1
    '            Catch ex As Exception
    '                MsgBox(ex.Message)
    '            End Try
    '        Next yy
    '    Next xx
    'End Sub
  
    Public Class colorValues
        Public rVal(15) As Integer
        Public gVal(15) As Integer
        Public bVal(15) As Integer
    End Class
    Public Shared FrVal(,) As Integer = {{0, 85, 48, 101, 203, 219, 117, 134, 85, 134, 101, 0, 203, 0, 235, 235},
                                        {0, 85, 48, 101, 203, 219, 117, 134, 85, 134, 101, 0, 203, 0, 235, 235},
                                        {0, 221, 153, 204, 136, 51, 119, 68, 68, 119, 34, 0, 170, 0, 238, 68},
                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}}
    Public Shared FgVal(,) As Integer = {{0, 134, 101, 150, 0, 117, 85, 134, 85, 186, 186, 255, 0, 0, 170, 235},
                                        {0, 134, 101, 150, 0, 117, 85, 134, 85, 186, 186, 255, 0, 0, 170, 235},
                                        {0, 204, 0, 0, 153, 51, 153, 85, 17, 51, 170, 68, 68, 34, 153, 34},
                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}}
    Public Shared FbVal(,) As Integer = {{0, 255, 16, 85, 65, 203, 85, 134, 85, 255, 0, 255, 65, 0, 134, 186},
                                        {0, 255, 16, 85, 65, 203, 85, 134, 85, 255, 0, 255, 65, 0, 134, 186},
                                        {0, 170, 0, 0, 170, 51, 68, 34, 0, 17, 238, 187, 8, 34, 0, 102},
                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}}
End Class

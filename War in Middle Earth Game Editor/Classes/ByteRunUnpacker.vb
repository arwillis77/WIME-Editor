Public Class ByteRunUnpacker
    Public File As BinaryFile
    Public Sub New(ByVal File As BinaryFile)
        Me.File = File
    End Sub
    Public Function CalculateRowSize(ByVal ImageWidth As UInteger) As UInteger
        Dim rowSizeInWords As UInteger = ImageWidth / 16
        If ImageWidth Mod 16 <> 0 Then
            rowSizeInWords += 1
        End If
        Return (rowSizeInWords * 2)
    End Function
    Public Function UnpackTiles(ByVal offset As UInteger, ByVal length As UInteger) As Byte()
        File.Position = offset
        Dim count As UInteger = 0
        Dim readBytes As UInteger = 0
        Dim chunkSize As Integer = length
        Dim decompressedChunkData(chunkSize - 1) As Byte
        While readBytes < length
            Dim runByte As SByte = File.ReadByteSigned
            readBytes += 1
            If runByte >= 0 AndAlso runByte <= 127 Then
                For i As Integer = 0 To runByte
                    Try
                        decompressedChunkData(count) = File.ReadByteUnsigned
                    Catch ex As Exception
                        Debug.Print("Error at byte {0}: {1}", count, ex.Message)
                        Return decompressedChunkData
                    End Try
                    readBytes += 1
                    count += 1
                Next
            ElseIf runByte >= -127 AndAlso runByte <= -1 Then
                Dim ubyte As Byte
                ubyte = File.ReadByteUnsigned
                readBytes += 1
                For i As Integer = 0 To -runByte
                    Try
                        decompressedChunkData(count) = ubyte
                    Catch ex As Exception
                        Debug.Print("Error at byte {0}: {1}", count, ex.Message)
                        Return decompressedChunkData
                    End Try
                    count += 1
                Next
            Else
            End If
        End While
        Return decompressedChunkData
    End Function
    Public Function ReadFrodo(ByVal Offset As UInteger, ByVal Length As UInteger) As Byte()
        File.Position = Offset
        Dim count As UInteger = 0
        Dim readbytes As UInteger = 0
        Dim chunkSize As Integer
        chunkSize = Length
        Dim p_tempbyte(chunkSize - 1) As Byte
        While readbytes < Length
            readbytes += 1
            p_tempbyte(count) = File.ReadByteUnsigned
            count += 1
        End While
        Return p_tempbyte
    End Function
    Public Function UnpackAnim(ByVal Offset As UInteger, ByVal Length As UInteger, ByVal compressFlag As Boolean) As Byte()
        File.Position = Offset
        Dim count As UInteger = 0
        Dim readBytes As UInteger = 0
        Dim chunkSize As Integer
        Try
            chunkSize = Length
        Catch ex As Exception
            MsgBox("Overflow error.  Value for chunksize exceed bounds for datatype.  Compressed value used.  RAW file may have errors.")
        End Try
        Dim decompressedChunkData(chunkSize - 1) As Byte
        If compressFlag = True Then

            While readBytes < Length
                Dim runByte As SByte = File.ReadByteSigned
                readBytes += 1
                If runByte >= 0 AndAlso runByte <= 127 Then
                    For i As Integer = 0 To runByte
                        Try
                            decompressedChunkData(count) = File.ReadByteUnsigned
                        Catch ex As Exception
                            Debug.Print("Error at byte {0}: {1}", count, ex.Message)
                            Return decompressedChunkData
                        End Try
                        readBytes += 1
                        count += 1
                    Next
                ElseIf runByte >= -127 AndAlso runByte <= -1 Then
                    Dim ubyte As Byte
                    ubyte = File.ReadByteUnsigned
                    readBytes += 1
                    For i As Integer = 0 To -runByte
                        Try
                            decompressedChunkData(count) = ubyte
                        Catch ex As Exception
                            Debug.Print("Error at byte {0}: {1}", count, ex.Message)
                            Return decompressedChunkData
                        End Try
                        count += 1
                    Next
                Else
                End If
            End While
        Else
            While readBytes < Length
                readBytes += 1
                decompressedChunkData(count) = File.ReadByteUnsigned
                count += 1
            End While
        End If
        Return decompressedChunkData
    End Function
    Public Function UnpackV2(ByVal Offset As UInteger, ByVal Length As UInteger, ByVal ImageWidth As Integer, ByVal ImageHeight As Integer, ByVal NumberOfPlanes As Integer) As Byte()
        File.Position = Offset
        Dim count As UInteger = 0
        Dim readBytes As UInteger = 0
        Dim chunkSize As Integer = CalculateRowSize(ImageWidth) * ImageHeight * NumberOfPlanes
        Dim decompressedChunkData(chunkSize - 1) As Byte
        'For v As Integer = 0 To 5
        'decompressedChunkData(count) = File.ReadByteUnsigned
        'count += 1
        'Next v
        'decompressedChunkData(count) = ImageWidth
        'decompressedChunkData(count + 1) = ImageHeight
        'count = 2
        While readBytes < Length
            Dim runByte As SByte = File.ReadByteSigned
            readBytes += 1
            If runByte >= 0 AndAlso runByte <= 127 Then
                For i As Integer = 0 To runByte
                    Try
                        decompressedChunkData(count) = File.ReadByteUnsigned
                    Catch ex As Exception
                        Debug.Print("Error at byte {0}: {1}", count, ex.Message)
                        Return decompressedChunkData
                    End Try
                    readBytes += 1
                    count += 1
                Next
            ElseIf runByte >= -127 AndAlso runByte <= -1 Then
                Dim ubyte As Byte
                ubyte = File.ReadByteUnsigned
                readBytes += 1
                For i As Integer = 0 To -runByte
                    Try
                        decompressedChunkData(count) = ubyte
                    Catch ex As Exception
                        Debug.Print("Error at byte {0}: {1}", count, ex.Message)
                        Return decompressedChunkData
                    End Try
                    count += 1
                Next
            Else
            End If
        End While
        Return decompressedChunkData
    End Function
    Public Function Unpack(ByVal Offset As UInteger, ByVal Length As UInteger, _
                           ByVal ImageWidth As Integer, ByVal ImageHeight As Integer, _
                           ByVal NumberOfPlanes As Integer) As Byte()
        File.Position = Offset
        Dim count As UInteger = 0
        Dim readBytes As UInteger = 0
        Dim chunkSize As Integer = CalculateRowSize(ImageWidth) * ImageHeight * NumberOfPlanes
        Dim decompressedChunkData(chunkSize - 1) As Byte
        While readBytes < Length
            Dim runByte As SByte = File.ReadByteSigned
            readBytes += 1
            If runByte >= 0 AndAlso runByte <= 127 Then
                For i As Integer = 0 To runByte
                    Try
                        decompressedChunkData(count) = File.ReadByteUnsigned
                    Catch ex As Exception
                        Debug.Print("Error at byte {0}: {1}", count, ex.Message)
                        Return decompressedChunkData
                    End Try
                    readBytes += 1
                    count += 1
                Next
            ElseIf runByte >= -127 AndAlso runByte <= -1 Then
                Dim ubyte As Byte
                ubyte = File.ReadByteUnsigned
                readBytes += 1
                For i As Integer = 0 To -runByte
                    Try
                        decompressedChunkData(count) = ubyte
                    Catch ex As Exception
                        Debug.Print("Error at byte {0}: {1}", count, ex.Message)
                        Return decompressedChunkData
                    End Try
                    count += 1
                Next
            Else
            End If
        End While
        ' /* Free the compressed chunk data */
        ' free(body->chunkData);

        ' /* Add decompressed chunk data to the body chunk */
        ' IFF_setRawChunkData(body, decompressedChunkData, chunkSize);

        ' /* Recursively update the chunk sizes */
        ' IFF_updateChunkSizes((IFF_Chunk*)body);

        ' /* Change compression flag, since the body is no longer compressed anymore */
        ' image->bitMapHeader->compression = ILBM_CMP_NONE;
        ' }
        Return decompressedChunkData
        ' }
    End Function
    Public Function UnpackCSTR(ByVal Offset As UInteger, ByVal Endianness As Endianness) As String
        Dim Result As String = ""
        Dim RunText As String = ""
        Dim CharRead As Char = ""
        Dim readBytes As UInteger = 0
        Dim count As UInteger = 0
        File.Position = Offset
        Dim ResourceSize As UInteger = File.ReadLongwordUnsigned(Endianness)
        Dim UnpackedSize As UInteger = File.ReadLongwordUnsigned(Endianness)
        While count < UnpackedSize
            Dim runByte As SByte = File.ReadByteSigned
            readBytes += 1
            If runByte >= 0 AndAlso runByte <= 127 Then
                RunText = ""
                For i As Integer = 0 To runByte
                    Try
                        CharRead = Chr(File.ReadByteUnsigned)
                        Result &= CharRead
                        RunText &= CharRead
                    Catch ex As Exception
                        Debug.Print("Error at byte {0}: {1}", count, ex.Message)
                        Return Result
                    End Try
                    readBytes += 1
                    count += 1
                Next
            ElseIf runByte >= -127 AndAlso runByte <= -1 Then
                Dim ubyte As Byte
                RunText = ""
                ubyte = File.ReadByteUnsigned
                readBytes += 1
                For i As Integer = 0 To -runByte
                    Try
                        CharRead = Chr(ubyte)
                        Result &= CharRead
                        RunText &= CharRead
                    Catch ex As Exception
                        Debug.Print("Error at byte {0}: {1}", count, ex.Message)
                        Return Result
                    End Try
                    count += 1
                Next
            Else
                Throw New Exception("Unknown byte run encoding byte!")
            End If
        End While
        If Result.Length <> UnpackedSize Then
            Debug.Print("Warning: Unpacked size ({0}) does not match the stored unpacked size({1}).", _
                        Result.Length, UnpackedSize)
        Else
            Debug.Print("Success! Unpacked size ({0}) matches the stored unpacked size({1}).", _
                        Result.Length, UnpackedSize)
        End If
        Return Result
    End Function
End Class
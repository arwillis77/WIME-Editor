' This file contains the BinaryFile class, version 1.3.
' Author: Pavel Řezníček <cigydd@gmail.com>
' Available under the GNU LGPL licence (also commercial use allowed). See the License.html file.
' The class serves to ease the file input and output on structured binary files.
' You create an instance of this class like this:
'   Dim BF As New BinaryFile("Path to your file\your file.ext")
' The file gets open on the object's creation time 
'   and closed automatically on the object's finalization (destruction) time.
'   The object is finalized as soon as the .NET garbage collector decides
'   that you won't need the object anymore (it is, there are no more referrences
'   to that instance, it is, no object variables contain that object).
'   You just don't have to worry about closing the file.
' The I/O methods are as follows:
'   ReadByte, WriteByte
'     - reads or writes an unsigned byte and increments the Position property by 1.
'   ReadByteUnsigned, WriteByteUnsigned
'     - just the same thing
'   ReadByteSigned, WriteByteSigned
'     - reads or writes a signed byte (SByte) and increments the Position property by 1.
'   ReadWordSigned, WriteWordSigned, ReadWordUnsigned, WriteWordUnsigned
'     - reads or writes a signed (Short) or unsigned (UShort) word  and increments 
'       the Position property by 2.
'   ReadLongwordSigned, WriteLongwordSigned, ReadLongwordUnsigned, WriteLongwordUnsigned
'     - reads or writes a signed (Integer) or unsigned (UInteger) longword and increments 
'       the Position property by 4.
'   In the Read/WriteWord and Read/WriteLong methods, you use the Endian argument 
'     that means the Endian encoding you want to read/write in.
'     If omitted, it deafults to the Little Endian (Intel) encoding.
'   ReadString, WriteString
'     - reads or writes a string and increments the Position property by its byte length.
'     You need to know the string's length before reading it from the file.
'     By writing, the entire string is written to the file.
' The class is a descendant of the System.IO.FileStream class.
'   That means that the Position property is inherited and can be used to set the offset
'   that the future reading or writing starts on.
'   The Position property
'     - corresponds to the Seek function and subroutine except that it is zero-based
'       so the file starts with byte 0. This makes the class to resemble file offsets
'       used by hexeditors.
' The Endian togglers:
'   The SwapWord and SwapLongword just swap the bytes in the argument 
'     so they toggle the Endian of the argument.

Public Enum Endianness
    endLittle
    endBig
End Enum

Public Class BinaryFile
    Inherits IO.FileStream
    Private memFilename As String
    Private memFile As IO.FileStream

    Public Sub New(ByVal Filename As String)
        MyBase.New(Filename, IO.FileMode.OpenOrCreate)
        memFilename = Filename
    End Sub

    Public ReadOnly Property Filename As String
        Get
            Return memFilename
        End Get
    End Property

    Protected Overrides Sub Finalize()
        Close()
        MyBase.Finalize()
    End Sub

    Public Function ReadByteUnsigned() As Byte
        Dim ByteRead As Integer = ReadByte()
        If ByteRead > -1 Then
            Return ByteRead
        Else
            Throw New Exception("Input past end of file.")
        End If
    End Function

    Public Function ReadByteSigned() As SByte
        Dim ByteRead As Integer = ReadByte()
        Dim Result As SByte
        Select Case ByteRead
            Case &H0 To &H7F ' 0..127
                Result = ByteRead
            Case &H80 To &HFF ' 128..255 => -128..-1
                Result = ByteRead - &H100 ' ByteRead - 256
            Case Else ' -1
                Throw New Exception("Input past end of file.")
        End Select
        Return Result
    End Function

    Public Sub WriteByteUnsigned(ByVal Value As Byte)
        WriteByte(Value)
    End Sub

    Public Sub WriteByteSigned(ByVal Value As SByte)
        Dim ByteToWrite As Byte
        Select Case Value
            Case Is >= 0 ' 0..127
                ByteToWrite = Value
            Case Else ' -128..-1 => 128..255
                ByteToWrite = Value + 256
        End Select
    End Sub

    Public Function ReadWordSigned(Optional ByVal Endianness As Endianness = Endianness.endLittle) As Short
        Dim Result As Short
        Dim LoByte, HiByte As Byte
        If Endianness = Endianness.endLittle Then
            LoByte = ReadByte()
            HiByte = ReadByte()
        Else ' big
            HiByte = ReadByte()
            LoByte = ReadByte()
        End If
        Result = (CShort(HiByte) << 8) Or LoByte
        Return Result
    End Function

    Public Function ReadWordUnsigned(Optional ByVal Endianness As Endianness = Endianness.endLittle) As UShort
        Dim Result As UShort
        Dim LoByte, HiByte As Byte
        If Endianness = Endianness.endLittle Then
            LoByte = ReadByte()
            HiByte = ReadByte()
        Else ' big
            HiByte = ReadByte()
            LoByte = ReadByte()
        End If
        Result = (CUShort(HiByte) << 8) Or LoByte
        Return Result
    End Function

    Public Sub WriteWordSigned(ByVal Value As Short, _
                               Optional ByVal Endianness As Endianness = Endianness.endLittle)
        Dim HiByte, LoByte As Byte
        HiByte = Value >> 8
        LoByte = Value And &HFF
        If Endianness = Endianness.endLittle Then
            WriteByte(LoByte)
            WriteByte(HiByte)
        Else ' big
            WriteByte(HiByte)
            WriteByte(LoByte)
        End If
    End Sub

    Public Sub WriteWordUnsigned(ByVal Value As UShort, _
                                 Optional ByVal Endianness As Endianness = Endianness.endLittle)
        Dim HiByte, LoByte As Byte
        HiByte = Value >> 8
        LoByte = Value And &HFF
        If Endianness = Endianness.endLittle Then
            WriteByte(LoByte)
            WriteByte(HiByte)
        Else ' big
            WriteByte(HiByte)
            WriteByte(LoByte)
        End If
    End Sub

    Public Function ReadLongwordSigned(Optional ByVal Endianness As Endianness = Endianness.endLittle) As Integer
        Dim Result As Integer
        Dim HiWord, LoWord As Short
        If Endianness = Endianness.endLittle Then
            LoWord = ReadWordSigned(Endianness)
            HiWord = ReadWordSigned(Endianness)
        Else ' big
            HiWord = ReadWordSigned(Endianness)
            LoWord = ReadWordSigned(Endianness)
        End If
        Result = (CInt(HiWord) << 16) Or LoWord
        Return Result
    End Function

    Public Function ReadLongwordUnsigned(Optional ByVal Endianness As Endianness = Endianness.endLittle) As UInteger
        Dim Result As UInteger
        Dim HiWord, LoWord As UShort
        If Endianness = Endianness.endLittle Then
            LoWord = ReadWordUnsigned(Endianness)
            HiWord = ReadWordUnsigned(Endianness)
        Else ' big
            HiWord = ReadWordUnsigned(Endianness)
            LoWord = ReadWordUnsigned(Endianness)
        End If
        Result = (CUInt(HiWord) << 16) Or LoWord
        Return Result
    End Function

    Public Sub WriteLongwordSigned(ByVal Value As Integer, _
                                   Optional ByVal Endianness As Endianness = Endianness.endLittle)
        Dim HiWord, LoWord As Short
        HiWord = Value >> 16
        LoWord = Value And &HFFFF
        If Endianness = Endianness.endLittle Then
            WriteWordSigned(LoWord, Endianness)
            WriteWordSigned(HiWord, Endianness)
        Else
            WriteWordSigned(HiWord, Endianness)
            WriteWordSigned(LoWord, Endianness)
        End If
    End Sub

    Public Sub WriteLongwordUnsigned(ByVal Value As UInteger, _
                                     Optional ByVal Endianness As Endianness = Endianness.endLittle)
        Dim HiWord, LoWord As UShort
        HiWord = Value >> 16
        LoWord = Value And &HFFFF
        If Endianness = Endianness.endLittle Then
            WriteWordUnsigned(LoWord, Endianness)
            WriteWordUnsigned(HiWord, Endianness)
        Else
            WriteWordUnsigned(HiWord, Endianness)
            WriteWordUnsigned(LoWord, Endianness)
        End If
    End Sub

    Public Function ReadString(ByVal Length As Integer) As String
        Dim Result As String = ""
        Dim Bytes As Byte() = New Byte() {}
        Read(Bytes, Position, Length)
        For I As Integer = 0 To Length - 1
            Result = Result + Chr(Bytes(I))
        Next
        Return Result
    End Function

    Public Sub WriteString(ByVal Value As String)
        Dim Bytes(Value.Length - 1) As Byte
        For I As Integer = 0 To Value.Length - 1
            Bytes(I) = Asc(Value(I))
        Next
        Write(Bytes, Position, Bytes.Length)
    End Sub

    Public Sub SwapWord(ByRef Word As Short)
        Dim HiByte, LoByte As Byte
        HiByte = Word >> 8
        LoByte = Word And &HFF
        Word = (CShort(LoByte) << 8) Or HiByte
    End Sub

    Public Sub SwapLongword(ByRef Longword As Integer)
        Dim HiWord, LoWord As Short
        HiWord = Longword >> 16
        LoWord = Longword And &HFFFF
        SwapWord(HiWord)
        SwapWord(LoWord)
        Longword = (CInt(LoWord) << 16) Or HiWord
    End Sub
End Class

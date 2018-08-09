Public Class Bitplane
    Public Offset As Integer
    Public Sub New(ByVal Offset As UInteger)
        Me.Offset = Offset
    End Sub

    ' Index-th bit in a bitplane - useful for building pixels
    Public ReadOnly Property Bit(ByVal Index As Integer) As Boolean
        Get
            Dim ByteIndex As Integer = Index \ 8
            ' Higher bits go first so we reverse the bit order
            Dim BitIndexInByte As Integer = 7 - (Index Mod 8)
            Dim MemByte As Byte = GetMemByte(Offset + ByteIndex)
            Return modMemory.GetBit(MemByte, BitIndexInByte)
        End Get
    End Property
End Class

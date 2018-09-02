Module modMemory
    Public Memory() As Byte
    Public Function GetMemWord(ByVal Address As UInteger) As UShort
        If Not Memory Is Nothing Then
            If Address + 1 < Memory.Length Then
                Dim HiByte, LoByte As UShort
                HiByte = Memory(Address)
                LoByte = Memory(Address + 1)
                Return (HiByte << 8) Or LoByte
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function
    Public Function GetMemByte(ByVal Address As UInteger) As Byte
        If Not Memory Is Nothing Then
            If Address < Memory.Length Then
                Return Memory(Address)
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function
    Public Function GetBit(ByVal Number As UInteger, ByVal Index As Byte) As Boolean
        Return (Number And (1 << Index)) > 0
    End Function
    Public Sub SetBit(ByRef Number As UInteger, ByVal Index As Byte, ByVal Value As Boolean)
        If Value = True Then
            Number = Number Or (1 << Index)
        Else ' False
            Number = Number And Not (1 << Index)
        End If
    End Sub

    Public Function TestSetBit(ByVal Number As UInteger, ByVal Index As Byte, ByVal Value As Boolean) As UInteger
        SetBit(Number, Index, Value)
        Return Number
    End Function
End Module

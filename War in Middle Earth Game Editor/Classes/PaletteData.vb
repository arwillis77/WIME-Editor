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
        Public Sub Add(color As PaletteData)
            colors.Add(color)
        End Sub
        Public Sub Add(slot As UShort, value As String)
            Dim p As New PaletteData(slot, value)
            colors.Add(p)
        End Sub
    End Class
    Public Class Pal_Set
        Public ID As String
        Public ColorValue As List(Of Integer)

        Public Sub New()

        End Sub

    End Class
End Class

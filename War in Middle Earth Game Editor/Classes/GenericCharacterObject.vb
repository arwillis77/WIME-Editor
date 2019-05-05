Public Class GenericCharacterObject
    Public Name As String
    Public Value As Integer
    Public Sub New()

    End Sub
    Public Sub New(ByVal text As String, ByVal number As Integer)
        Name = text
        Value = number
    End Sub
End Class

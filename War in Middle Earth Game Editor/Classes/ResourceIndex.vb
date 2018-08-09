Public Class ResourceIndex
    ' Class for properties and members related to processing of the resource index in each file.
    Private number As Integer
    Private offset As Integer
    Private intMultiplier As Integer


    Public Function getIndexNum(filename As String) As Integer
        ' Member function returns the index number for a resource item.
        Dim p_index As Integer
        Using p_reader As New BinaryFile(filename)
            p_reader.Position = intTileFilePointerStart
            p_index = p_reader.ReadWordUnsigned
        End Using
        Return p_index
    End Function


End Class

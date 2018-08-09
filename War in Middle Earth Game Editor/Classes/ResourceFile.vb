Public Class ResourceFile
    ' Class for individual resource files.  Not for actual resources.

    Const CHAR_ID = "CHAR"
    Const CSTR_ID = "CSTR"
    Const FONT_ID = "FONT"
    Const FRML_ID = "FRML"
    Const IMAG_ID = "IMAG"
    Const MAP_ID = "MMAP"

    Private filename As String
    Private num_types As Integer
    Private type As String
    Private type_quantity As Integer

    Public Sub New()

    End Sub

    Structure Header
        Dim size As UInteger
        Dim DataSegmentSize As UInteger
        Dim DataSize As UInteger
        Dim FileEndLength As UInteger
    End Structure
    Structure Chunk
        Dim name As String
        Dim offset As UInteger
        Dim size As UInteger
        Dim uncomp_size As UInteger
    End Structure


End Class

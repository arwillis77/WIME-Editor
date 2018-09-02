Imports WIMEEditor.Game
Imports WIMEEditor.EditorSettings
Imports System.Xml
Public Class frmCoordinates
    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstCoordinates.Items.Clear()
        'lstCoordinates.Columns.Add("CITY/LOCATION", 140)
        'lstCoordinates.Columns.Add("COORDINATE", 90)
        ReadList()
    End Sub
    Public Sub ReadList()
        Dim p_file As String = DATA_FILES
        Dim cityName As String
        Dim value As String
        Dim settings As New XmlReaderSettings With {
            .IgnoreWhitespace = True,
            .IgnoreComments = True
        }
        Using input As XmlReader = XmlReader.Create(p_file, settings)
            Do While input.Read
                If input.ReadToDescendant("COPYPROTECTION") Then
                    If input.ReadToDescendant("LOCATION") Then
                        Do
                            input.ReadStartElement("LOCATION")
                            cityName = input.ReadElementContentAsString
                            value = input.ReadElementContentAsString
                            Dim lv As ListViewItem = lstCoordinates.Items.Add(cityName)
                            lv.SubItems.Add(value)
                        Loop While input.ReadToNextSibling("LOCATION")
                    End If

                End If
            Loop
        End Using
    End Sub
End Class


Imports WIMEEditor.Game
Imports System.IO
Imports System.Xml
Public Class Sprite
    Public Class Data
        Public spriteType As String
        Public spriteValue As Integer
        Public totalSpriteColors As Integer
        Public totalLoops As Integer
        Public loopFrames() As Integer
        Public spriteColor() As Integer
        Public animateSpeed As Integer
        Public AnimationCycle As List(Of Integer)
        Public Class newFrameList
            Public FList As List(Of NewFrameSet)
        End Class
        Public Class NewFrameSet
            Public cycle As List(Of Integer)
        End Class
        Public Class FrameSet
            Public WalkCycle As List(Of Integer)
            Public Cycle2 As List(Of Integer)
            Public Cycle3 As List(Of Integer)
            Public Cycle4 As List(Of Integer)
            Public Cycle5 As List(Of Integer)
            Public Cycle6 As List(Of Integer)
            Public Cycle7 As List(Of Integer)
        End Class
        Public LoopFrameSet As FrameSet
        Public Sub New()
            LoopFrameSet = New FrameSet
        End Sub
    End Class
    Public Class Archive_Sprite
        Public Name As String
        Public Value As UShort
        Public Speed As Integer
        Public ColorSet As New List(Of Integer)
        Public CycleLoops As New List(Of Integer)
    End Class
    Public Class Archive_SpriteList
        Private p_sprite As List(Of Archive_Sprite)
        Public Sub New()
            p_sprite = New List(Of Archive_Sprite)
        End Sub
        Public Sub Add(sprite As Archive_Sprite)
            p_sprite.Add(sprite)
        End Sub
        Default Public Property Item(index As Integer) As Archive_Sprite
            Get
                If index < 0 OrElse index >= p_sprite.Count Then
                    Throw New ArgumentOutOfRangeException("index", "The index must be between 0 and " & p_sprite.Count - 1 & ".")
                Else
                    Return p_sprite(index)
                End If
            End Get
            Set(value As Archive_Sprite)
                p_sprite(index) = value
            End Set
        End Property
    End Class
    Public Shared Function LoadSpriteCBOData(format As String, spritevalue As Integer) As Archive_Sprite
        Dim Nodelist As Xml.XmlNodeList
        Dim ColorNodes As XmlNodeList
        Dim Node As Xml.XmlNode
        Dim doc As XmlDocument = New XmlDocument
        doc.Load(DATA_FILES)
        Nodelist = doc.SelectNodes(format)
        For Each Node In Nodelist
            If Node.Name = "SPRITEDATA" Then
                MsgBox("FoundSpriteData!")
                ColorNodes = doc.SelectNodes("SPRITECOLORS")


            End If
        Next
        ' Loads the sprite names and values to be used in drop down CBO boxes.
        'Dim p_sprite As New Archive_Sprite
        'Dim counter As Integer = 0
        'Dim p_colorstring As String = ""
        'Dim p_cycleloops As String = ""
        'Dim p_file As String = DATA_FILES
        'Dim p_color As Integer
        'Dim settings As New XmlReaderSettings
        'With settings
        '    .IgnoreWhitespace = True
        '    .IgnoreComments = True
        'End With

        'Using input As XmlReader = XmlReader.Create(p_file, settings)
        '    Dim t As Integer
        '    Do While Not input.ReadEndElement = "SPRITEDATA"
        '        input.ReadToDescendant(format)
        '        input.ReadToDescendant(SPRITEDATA)
        '        Do Until t = spritevalue
        '            MsgBox("Read to SpriteData!")

        '            input.ReadToFollowing("SPRITE")
        '            t = input.GetAttribute("ID")
        '            MsgBox(t & " Spritevalue " & spritevalue,, "Value of t")

        '            input.ReadToDescendant("NAME")
        '            p_sprite.Name = input.ReadElementContentAsString
        '            p_sprite.Speed = input.ReadElementContentAsInt
        '            p_sprite.Value = t
        '            input.ReadStartElement("SPRITECOLORS")
        '            input.ReadToFollowing("VALUE")
        '            Do
        '                p_color = input.ReadElementContentAsInt
        '                p_sprite.ColorSet.Add(p_color)
        '                p_colorstring = p_colorstring & p_color & vbCrLf
        '                'MsgBox(p_color)
        '            Loop While input.ReadToNextSibling("VALUE")
        '            MsgBox("COLORS " & vbCrLf & p_colorstring,, p_sprite.Name & " " & t)
        '            input.ReadStartElement("ANIMATIONLOOPS")
        '            Do
        '                p_color = input.ReadElementContentAsInt
        '                p_sprite.CycleLoops.Add(p_color)
        '                p_cycleloops = p_cycleloops & p_color & vbCrLf
        '                'MsgBox("Added Cycle " & p_color)
        '            Loop While input.ReadToNextSibling("LOOP")
        '            MsgBox(p_sprite.Speed & vbCrLf & p_colorstring & p_cycleloops, , p_sprite.Name & " " & t)
        '        Loop
        '        counter = counter + 1
        '        MsgBox(counter,, "COUNTER")
        '    Loop
        'End Using
        'Return p_sprite
    End Function
End Class



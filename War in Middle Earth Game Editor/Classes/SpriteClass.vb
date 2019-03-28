Imports WIMEEditor.Game
Imports System.IO
Imports System.Xml
Public Class Sprite
    Public Class Data
        Public SpriteType As String                         ' Sprite Description
        Public SpriteValue As Integer                       ' Sprite Numerical Code
        Public TotalSpriteColors As Integer                 ' Total number of sprite colors 
        Public TotalLoops As Integer                        ' Total number of loops
        Public LoopFrames As List(Of Integer)               ' Number of Loop Frame
        Public SpriteColor As List(Of Integer)              ' List of Color Variations for Sprite
        Public AnimateSpeed As Integer                       ' Speed to cycle through cels.
        Public AnimationCycle As List(Of Integer)           ' List of number of cels per cycle
        Public CycleList As List(Of List(Of Integer))       ' List of the list of cels per cycle
    End Class
End Class



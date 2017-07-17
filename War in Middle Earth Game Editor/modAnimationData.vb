Imports WIMEEditor.Game
Imports WIMEEditor.Sprite
Imports WIMEEditor.EditorSettings
Imports System.IO
Imports System.Xml
Module modAnimationData


    Public SpriteTypes() As String = {"Hobbit", "Elf", "Man", "Dwarf", "Wizard", "Gollum", "Orc", "Ent", "Nazgul", "Troll", "Warg", "Spider",
                                    "Balrog", "Rohirrim", "Armored Man", "Dunlending", "Elven Lord", "Elven Lady", "Tom Bombadill"}
    Public SpriteValues() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 80, 81, 82}


    Public CycleSet As New ArrayList
    Public LoadedSprite As Data
    Public HobbitSprite As New Data
    Public ElfSprite As New Data
    Public ManSprite As New Data
    Public DwarfSprite As New Data
    Public WizardSprite As New Data
    Public GollumSprite As New Data
    Public OrcSprite As New Data
    Public EntSprite As New Data
    Public NazgulSprite As New Data
    Public TrollSprite As New Data
    Public WargSprite As New Data
    Public SpiderSprite As New Data
    Public BalrogSprite As New Data
    Public RohirrimSprite As New Data
    Public ArmManSprite As New Data
    Public DunlendingSprite As New Data
    Public ElderElfSprite As New Data
    Public GaladrielSprite As New Data
    Public BombadilSprite As New Data





    Public Function GetSpriteData(format As String, spritevalue As Integer) As Data
        Dim p_spritedata As New Data
        Dim p_file As String = DATA_FILES
        Dim settings As New XmlReaderSettings
        With settings
            .IgnoreWhitespace = True
            .IgnoreComments = True
        End With
        Using input As XmlReader = XmlReader.Create(p_file, settings)
            Dim t As String = ""
            Do While input.Read
                input.ReadToDescendant(format)
                input.ReadToDescendant(SPRITEDATA)
                Do Until t = spritevalue.ToString
                    input.ReadToFollowing("SPRITE")
                    t = input.GetAttribute("ID")
                    If t = spritevalue Then



                    End If
                Loop
            Loop

        End Using

        Return p_spritedata
    End Function

    Public Sub SetHobbitSprite()
        Dim loopindex As Integer
        LoadedSprite = New Data
        With HobbitSprite
            .spriteType = SpriteTypes(0)
            .spriteValue = 0
            .totalLoops = 6
            loopindex = .totalLoops - 1
            ReDim .loopFrames(0 To loopindex)
            .loopFrames = {7, 4, 3, 4, 3, 5}
            '//DEFAULT CYCLE VALUES -- DELETE PC VGA IF DETERMINED SAME LATER
            .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
            .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})         '// Attack
            .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})          '// Turn
            .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13, 14})      '// Die
            .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 16, 15})          '// Sit
            .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 16, 15, 13, 14})  '// LayDown
            Select Case loadedGame.format
                Case PC_VGA_FORMAT
                    .totalLoops = 7
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {7, 4, 3, 4, 4, 3, 5}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13, 14})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 15, 16, 17})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 19, 18})
                    .LoopFrameSet.Cycle7 = New List(Of Integer)(New Integer() {0, 19, 18, 16, 17})
                    .totalSpriteColors = 6
                    .spriteColor = {0, 30, 31, 32, 33, 34}
                Case PC_EGA_FORMAT
                    .totalSpriteColors = 1
                    .spriteColor = {0}
                Case IIGS_FORMAT, ST_FORMAT
                    .totalSpriteColors = 6
                    .spriteColor = {0, 30, 31, 32, 33, 34}
                Case AMIGA_FORMAT
                    .totalSpriteColors = 5
                    .spriteColor = {1, 3, 5, 11, 12}
            End Select
            .animateSpeed = 200
        End With
    End Sub
    Public Sub SetElfSprite()
        Dim loopindex As Integer
        With ElfSprite
            .spriteType = SpriteTypes(1)
            .spriteValue = 1
            .totalSpriteColors = 7
            .totalLoops = 6
            loopindex = .totalLoops - 1
            ReDim .loopFrames(0 To loopindex)
            Select Case loadedGame.format
                Case PC_VGA_FORMAT
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})                 'Attack 1
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})                  'Attack 2
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13, 14})              'Turn
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 15, 16, 17})              'Die
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 19, 18})               'Sit
                    .LoopFrameSet.Cycle7 = New List(Of Integer)(New Integer() {0, 19, 18, 16, 17})           'Lie Down
                    .totalLoops = 7
                    loopindex = .totalLoops - 1
                    .loopFrames = {7, 4, 3, 4, 4, 3, 5}
                    .spriteColor = {0, 9, 10, 11, 12, 13, 14}
                Case PC_EGA_FORMAT
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 4})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 5, 6})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 7, 8})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 9, 10, 11})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 13, 12})
                    .LoopFrameSet.Cycle7 = New List(Of Integer)(New Integer() {0, 13, 12, 10, 11})
                    .totalLoops = 7
                    loopindex = .totalLoops - 1
                    .loopFrames = {4, 2, 3, 3, 4, 3, 5}
                    .spriteColor = {0}
                Case IIGS_FORMAT, ST_FORMAT
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 8})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 9, 10})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 11, 12, 13})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 15, 14})
                    .LoopFrameSet.Cycle7 = New List(Of Integer)(New Integer() {0, 15, 14, 12, 13})
                    .totalLoops = 7
                    loopindex = .totalLoops - 1
                    .loopFrames = {7, 2, 2, 3, 4, 3, 5}
                    .spriteColor = {0, 9, 11, 12, 13}
                Case AMIGA_FORMAT
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 9, 10})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 11, 12, 13})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 15, 14})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 15, 14, 12, 13})
                    .totalLoops = 6
                    loopindex = .totalLoops - 1
                    .loopFrames = {7, 3, 3, 4, 3, 5}
                    .spriteColor = {2, 4, 6, 7, 8}
            End Select
            .animateSpeed = 200
        End With
    End Sub
    Public Sub SetManSprite()
        Dim loopindex As Integer
        With ManSprite
            .spriteType = SpriteTypes(2)
            .spriteValue = 2
            Select Case loadedGame.format
                Case PC_VGA_FORMAT, AMIGA_FORMAT
                    .totalSpriteColors = 12
                    .totalLoops = 7
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {7, 4, 3, 4, 4, 3, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13, 14})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 15, 16, 17})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 19, 18})
                    .LoopFrameSet.Cycle7 = New List(Of Integer)(New Integer() {0, 19, 16, 17})
                    If loadedGame.format = PC_VGA_FORMAT Then
                        .totalSpriteColors = 12
                        .spriteColor = {0, 15, 16, 17, 18, 19, 20, 21, 22, 24, 26, 28}
                    Else
                        .totalSpriteColors = 10
                        .spriteColor = {4, 10, 11, 13, 14, 16, 19, 20, 22, 24}
                    End If
                Case PC_EGA_FORMAT
                    .totalSpriteColors = 1
                    .totalLoops = 6
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {4, 4, 3, 4, 3, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 4, 5, 6})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 7, 8})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 9, 10, 11})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 13, 12})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 13, 10, 11})
                    .spriteColor = {0}
                Case IIGS_FORMAT, ST_FORMAT
                    .totalLoops = 6
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {7, 4, 3, 4, 3, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13, 14})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 16, 16})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 16, 13, 14})
                    .spriteColor = {0, 15, 17, 18, 21, 22, 24, 26, 28}
                    If loadedGame.format = IIGS_FORMAT Then
                        .totalSpriteColors = 9
                        .spriteColor = {0, 15, 17, 18, 21, 22, 24, 26, 28}
                    Else
                        .totalSpriteColors = 7
                        .spriteColor = {10, 11, 14, 16, 19, 20, 22}
                    End If
            End Select
            .animateSpeed = 200
        End With
    End Sub
    Public Sub SetDwarfSprite()
        Dim loopindex As Integer
        With DwarfSprite
            .spriteType = SpriteTypes(3)
            .spriteValue = 3
            .animateSpeed = 200
            Select Case loadedGame.format
                Case PC_VGA_FORMAT
                    .totalSpriteColors = 4
                    .totalLoops = 7
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {7, 4, 4, 4, 4, 3, 5}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11, 12})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 13, 14, 15})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 16, 17, 18})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 20, 19})
                    .LoopFrameSet.Cycle7 = New List(Of Integer)(New Integer() {0, 20, 19, 17, 18})
                    .spriteColor = {0, 35, 36, 37}
                Case PC_EGA_FORMAT
                    .totalSpriteColors = 1
                    .totalLoops = 6
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {4, 4, 3, 4, 3, 5}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 4, 5, 6})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 7, 8})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 9, 10, 11})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 13, 12})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 13, 12, 10, 11})
                    .spriteColor = {0}
                Case AMIGA_FORMAT
                    .totalSpriteColors = 4
                    .totalLoops = 6
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {7, 4, 3, 4, 3, 5}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13, 14})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 16, 15})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 16, 15, 13, 14})
                    .spriteColor = {4, 5, 6, 13}
                Case IIGS_FORMAT, ST_FORMAT
                    .totalSpriteColors = 4
                    .totalLoops = 6
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {7, 4, 3, 4, 3, 5}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13, 14})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 16, 15})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 16, 15, 13, 14})
                    .spriteColor = {0, 35, 36, 37}
            End Select
        End With
    End Sub
    Public Sub SetWizardSprite()
        Dim loopindex As Integer
        With WizardSprite
            .spriteType = SpriteTypes(4)
            .spriteValue = 4
            .animateSpeed = 200
            Select Case loadedGame.format
                Case PC_VGA_FORMAT
                    .totalLoops = 6
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {7, 4, 3, 4, 3, 3}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13, 14})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 15, 16})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 17, 18})
                    .totalSpriteColors = 5
                    .spriteColor = {0, 1, 2, 3, 4}
                Case PC_EGA_FORMAT
                    .totalSpriteColors = 1
                    .totalLoops = 6
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {4, 4, 3, 3, 3, 3}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 4, 5, 6})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 7, 8})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 9, 10})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 11, 12})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 13, 14})
                    .spriteColor = {0}
                Case IIGS_FORMAT, AMIGA_FORMAT, ST_FORMAT
                    .totalLoops = 6
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {7, 4, 3, 3, 3, 3}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 14, 15})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 16, 17})
                    If loadedGame.format = AMIGA_FORMAT Then
                        .totalSpriteColors = 4
                        .spriteColor = {4, 5, 6, 9}
                    Else
                        .totalSpriteColors = 5
                        .spriteColor = {0, 1, 2, 3, 4}
                    End If
            End Select
        End With
    End Sub
    Public Sub SetGollumSprite()
        Dim loopindex As Integer
        With GollumSprite
            .spriteType = SpriteTypes(5)
            .spriteValue = 5
            .animateSpeed = 200
            .totalSpriteColors = 1
            .totalLoops = 6
            loopindex = .totalLoops - 1
            ReDim .loopFrames(0 To loopindex)
            .loopFrames = {7, 4, 3, 4, 4, 2}
            .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
            .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
            .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})
            .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13, 14})
            .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 15, 16, 17})
            .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 18})

            .spriteColor = {0}
        End With
    End Sub
    Public Sub SetOrcSprite()
        Dim loopindex As Integer
        With OrcSprite
            .spriteType = SpriteTypes(6)
            .spriteValue = 6
            .totalSpriteColors = 1
            .spriteColor = {0}
            .animateSpeed = 200
            Select Case loadedGame.format
                Case PC_VGA_FORMAT, PC_EGA_FORMAT
                    .totalLoops = 5
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {7, 3, 3, 4, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 9, 10})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 11, 12, 13})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 14, 15, 16})
                Case IIGS_FORMAT
                    .totalLoops = 4
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {7, 3, 3, 4, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 9, 10})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 11, 12, 13})
                Case AMIGA_FORMAT, ST_FORMAT
                    MsgBox("NEED TO FIX AMIGA AND ST FOR ORC SPRITE")
            End Select

        End With
    End Sub
    Public Sub SetEntSprite()
        Dim loopindex As Integer
        With EntSprite
            .spriteType = SpriteTypes(7)
            .spriteValue = 7
            .totalSpriteColors = 1
            Select Case loadedGame.format
                Case PC_VGA_FORMAT, AMIGA_FORMAT
                    .totalLoops = 3
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {6, 3, 3}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 6, 7})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 8, 9})
                Case PC_EGA_FORMAT
                    .totalLoops = 1
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3})
                Case IIGS_FORMAT, ST_FORMAT
                    .totalLoops = 1
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {5}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4})
            End Select
            .animateSpeed = 200
            .spriteColor = {0}
        End With
    End Sub
    Public Sub setNazgulSprite()
        Dim loopindex As Integer
        With NazgulSprite
            .spriteType = SpriteTypes(8)
            .spriteValue = 8
            .totalSpriteColors = 5
            .spriteColor = {0, 5, 6, 7, 8}
            .totalLoops = 5
            loopindex = .totalLoops - 1
            ReDim .loopFrames(0 To loopindex)
            .loopFrames = {7, 3, 3, 4, 7}
            .animateSpeed = 200

            Select Case loadedGame.format
                Case PC_VGA_FORMAT
                    .totalLoops = 5
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {6, 4, 3, 4, 5}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 6, 7, 8})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 9, 10})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 11, 12, 13})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 14, 15, 16, 17})
                Case PC_EGA_FORMAT
                    .totalSpriteColors = 1
                    .totalLoops = 4
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {5, 4, 3, 2}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 6, 7, 8})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 9, 10})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 11})
                    .spriteColor = {0}
                Case AMIGA_FORMAT, IIGS_FORMAT, ST_FORMAT
                    .totalLoops = 4
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {5, 4, 3, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 5, 6, 7})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 8, 9})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 10, 11, 12})
                    If loadedGame.format = AMIGA_FORMAT Then
                        .totalSpriteColors = 3
                        .spriteColor = {1, 3, 5}
                    End If
            End Select
        End With
    End Sub
    Public Sub setTrollSprite()
        Dim loopindex As Integer
        With TrollSprite
            .spriteType = SpriteTypes(9)
            .spriteValue = 9
            Select Case loadedGame.format
                Case PC_VGA_FORMAT, AMIGA_FORMAT
                    .totalLoops = 4
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {7, 5, 3, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9, 10})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 11, 12})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 13, 14})
                    .totalSpriteColors = 1
                    .spriteColor = {0}
                Case PC_EGA_FORMAT
                    .totalLoops = 3
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {4, 3, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 4, 5})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 6, 7, 8})
                    .totalSpriteColors = 1
                    .spriteColor = {0}
                Case IIGS_FORMAT, ST_FORMAT
                    .totalLoops = 4
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {8, 4, 3, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6, 7})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 8, 9, 10})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 11, 12})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 13, 14, 15})
                    .totalSpriteColors = 1
                    .spriteColor = {0}
            End Select
            .animateSpeed = 200
            .spriteColor = {0}
        End With
    End Sub
    Public Sub setWargSprite()
        Dim loopindex As Integer
        With WargSprite
            .spriteType = SpriteTypes(10)
            .spriteValue = 10
            .totalSpriteColors = 1
            .totalLoops = 3
            loopindex = .totalLoops - 1
            ReDim .loopFrames(0 To loopindex)
            .loopFrames = {6, 5, 5}
            .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})
            .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 6, 7, 8, 9})
            .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11, 12, 13})
            .animateSpeed = 200
            .spriteColor = {0}
        End With
    End Sub
    Public Sub setSpiderSprite()
        Dim loopindex As Integer
        With SpiderSprite
            .spriteType = SpriteTypes(11)
            .spriteValue = 11
            .totalSpriteColors = 1
            Select Case loadedGame.format
                Case PC_VGA_FORMAT
                    .totalLoops = 1
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {6, 3, 4, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 6, 7})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 8, 9, 10})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 11, 12, 13})
            End Select
            .animateSpeed = 200
            .spriteColor = {0}
        End With
    End Sub
    Public Sub setBalrogSprite()
        Dim loopindex As Integer
        With BalrogSprite
            .spriteType = SpriteTypes(12)
            .spriteValue = 12
            .totalSpriteColors = 1
            Select Case loadedGame.format
                Case PC_VGA_FORMAT, IIGS_FORMAT, AMIGA_FORMAT, ST_FORMAT
                    .totalLoops = 1
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {6}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {5, 4, 3, 2, 1, 0})
                Case PC_EGA_FORMAT
                    .totalLoops = 1
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3})
            End Select
            .animateSpeed = 200
            .spriteColor = {0}
        End With
    End Sub
    Public Sub setRohirrimSprite()
        Dim loopindex As Integer
        With RohirrimSprite
            .spriteType = SpriteTypes(13)
            .spriteValue = 13
            .totalSpriteColors = 1
            Select Case loadedGame.format
                Case PC_VGA_FORMAT, IIGS_FORMAT, AMIGA_FORMAT, ST_FORMAT
                    .totalLoops = 1
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {8}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6, 7})
                Case PC_EGA_FORMAT
                    .totalLoops = 1
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3})
            End Select
            .animateSpeed = 200
            .spriteColor = {0}
        End With
    End Sub
    Public Sub setArmManSprite()
        Dim loopindex As Integer
        With ArmManSprite
            .spriteType = SpriteTypes(14)
            .spriteValue = 14
            .totalSpriteColors = 1
            Select Case loadedGame.format
                Case PC_VGA_FORMAT, IIGS_FORMAT, AMIGA_FORMAT, ST_FORMAT
                    .totalLoops = 7
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {6, 4, 3, 4, 4, 3, 5}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13, 14})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 15, 16, 17})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 19, 18})
                    .LoopFrameSet.Cycle7 = New List(Of Integer)(New Integer() {0, 19, 18, 16, 17})
                Case PC_EGA_FORMAT
                    .totalLoops = 6
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {6, 4, 4, 4, 3, 5}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11, 12})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 13, 14, 15})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 17, 16})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 17, 16, 14, 15})
                Case AMIGA_FORMAT
                    .totalLoops = 6
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {6, 4, 3, 4, 3, 5}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8, 9})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 10, 11})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 12, 13, 14})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 16, 15})
                    .LoopFrameSet.Cycle6 = New List(Of Integer)(New Integer() {0, 16, 15, 13, 14})
            End Select
            .animateSpeed = 200
            .spriteColor = {0}
        End With
    End Sub
    Public Sub setDunlendingSprite()
        Dim loopindex As Integer
        With DunlendingSprite
            .spriteType = SpriteTypes(15)
            .spriteValue = 15
            .totalSpriteColors = 1
            Select Case loadedGame.format
                Case IIGS_FORMAT, ST_FORMAT
                    .totalLoops = 4
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {6, 3, 3, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 9, 10})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 11, 12, 13})
                Case AMIGA_FORMAT, PC_VGA_FORMAT
                    .totalLoops = 5
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {6, 3, 3, 4, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 9, 10})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 11, 12, 13})
                    .LoopFrameSet.Cycle5 = New List(Of Integer)(New Integer() {0, 14, 15, 16})
                Case PC_EGA_FORMAT
                    .totalLoops = 4
                    loopindex = .totalLoops - 1
                    ReDim .loopFrames(0 To loopindex)
                    .loopFrames = {6, 3, 3, 4}
                    .LoopFrameSet.WalkCycle = New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})
                    .LoopFrameSet.Cycle2 = New List(Of Integer)(New Integer() {0, 7, 8})
                    .LoopFrameSet.Cycle3 = New List(Of Integer)(New Integer() {0, 9, 10})
                    .LoopFrameSet.Cycle4 = New List(Of Integer)(New Integer() {0, 11, 12, 13})
            End Select
            .animateSpeed = 200
            .spriteColor = {0}
        End With
    End Sub
    Public Sub setElderElfSprite()
        Dim loopindex As Integer
        With ElderElfSprite
            .spriteType = SpriteTypes(16)
            .spriteValue = 80
            .totalSpriteColors = 1
            .totalLoops = 1
            loopindex = .totalLoops - 1
            ReDim .loopFrames(0 To loopindex)
            .loopFrames = {1}

            .animateSpeed = 200
            .spriteColor = {0}
        End With
    End Sub
    Public Sub setGaladrielSprite()
        Dim loopindex As Integer
        With GaladrielSprite
            .spriteType = SpriteTypes(17)
            .spriteValue = 81
            .totalSpriteColors = 1
            .totalLoops = 1
            loopindex = .totalLoops - 1
            ReDim .loopFrames(0 To loopindex)
            .loopFrames = {1}

            .animateSpeed = 200
            .spriteColor = {0}
        End With
    End Sub
    Public Sub setBombadilSprite()
        Dim loopindex As Integer
        With BombadilSprite
            .spriteType = SpriteTypes(18)
            .spriteValue = 82
            .totalSpriteColors = 1
            .totalLoops = 1
            loopindex = .totalLoops - 1
            ReDim .loopFrames(0 To loopindex)
            .loopFrames = {1}

            .animateSpeed = 200
            .spriteColor = {0}
        End With
    End Sub
End Module

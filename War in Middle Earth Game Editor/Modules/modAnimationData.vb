Imports WIMEEditor.Game
Imports WIMEEditor.Sprite
Module modAnimationData
    Public Class GameSprite
        Public Property Name As String
        Public Property Value As Integer
        Sub New()
        End Sub
        Public Sub New(SName As String, number As Integer)
            Name = SName
            Value = number
        End Sub
    End Class

    Public SpriteCluster As List(Of GameSprite) = New List(Of GameSprite) From
        {New GameSprite("Hobbit", 1), New GameSprite("Elf", 1), New GameSprite("Man", 2), New GameSprite("Dwarf", 3),
            New GameSprite("Wizard", 4), New GameSprite("Gollum", 5), New GameSprite("Orc", 6), New GameSprite("Ent", 7),
            New GameSprite("Nazgul", 8), New GameSprite("Troll", 9), New GameSprite("Warg", 10), New GameSprite("Spider", 11),
            New GameSprite("Balrog", 12), New GameSprite("Rohirrim", 13), New GameSprite("Armored Man", 14), New GameSprite("Evil Men", 15),
            New GameSprite("Elven Lord", 80), New GameSprite("Elven Lady", 81), New GameSprite("Tom Bombadil", 82)
        }

    '// WIMESpriteColorSets
    '  Contains Data sorted by format to include the Sprite Color Values for each sprite.
    Public WIMESpriteColorSets As List(Of WalkCycleSet) = New List(Of WalkCycleSet) From
        {New WalkCycleSet(PC_VGA_FORMAT, New List(Of SpriteCycleSets) From
        {New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 30, 31, 32, 33, 34})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 9, 10, 11, 12, 13, 14})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 15, 16, 17, 18, 19, 20, 21, 22, 24, 26, 28})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 35, 36, 37})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 5, 6, 7, 8})),
         New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(12, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(13, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(80, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(81, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(82, New List(Of Integer)(New Integer() {0}))}),
         New WalkCycleSet(PC_EGA_FORMAT, New List(Of SpriteCycleSets) From
        {New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(12, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(13, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(80, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(81, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(82, New List(Of Integer)(New Integer() {0}))}),
         New WalkCycleSet(IIGS_FORMAT, New List(Of SpriteCycleSets) From
         {New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 30, 31, 32, 33, 34})),
        New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 9, 11, 12, 13})),
        New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 15, 16, 17, 18, 19, 21, 22, 24, 26, 28})),
        New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 35, 36, 37})),
        New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4})),
        New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 5, 6, 7, 8})),
        New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(12, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(13, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(80, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(81, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(82, New List(Of Integer)(New Integer() {0}))}),
        New WalkCycleSet(AMIGA_FORMAT, New List(Of SpriteCycleSets) From
        {New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(12, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(13, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(80, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(81, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(82, New List(Of Integer)(New Integer() {0}))}),
         New WalkCycleSet(ST_FORMAT, New List(Of SpriteCycleSets) From
         {New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 30, 31, 32, 33, 34})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 9, 11, 12, 13})),
        New SpriteCycleSets(2, New List(Of Integer)(New Integer() {10, 11, 14, 16, 19, 20, 22})),
        New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 35, 36, 37})),
        New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4})),
        New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 5, 6, 7, 8})),
        New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(12, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(13, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(80, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(81, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(82, New List(Of Integer)(New Integer() {0}))})
        }
    '// WIMEWalkCycleSets
    '// Contains data sorted by format to include sprite values and listing each different set of animation cycles per sprite.
    Public WIMEWalkCycleSets As List(Of WalkCycleSet) = New List(Of WalkCycleSet) From
        {New WalkCycleSet(PC_VGA_FORMAT, New List(Of SpriteCycleSets) From
        {New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 15, 16, 17})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 19, 18})),
         New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 19, 18, 16, 17})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 7, 8, 9})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 10, 11})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 12, 13, 14})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 15, 16, 17})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 19, 18})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 19, 18, 16, 17})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 15, 16, 17})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 19, 18})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 19, 16, 17})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 10, 11, 12})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 13, 14, 15})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 16, 17, 18})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 20, 19})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 20, 19, 17, 18})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 15, 16})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 17, 18})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 15, 16, 17})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 18})),
         New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 7, 8})),
         New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 9, 10})), New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
         New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 14, 15, 16})),
         New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0, 6, 7})),
         New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0, 8, 9})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 6, 7, 8})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 9, 10})), New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 14, 15, 16, 17})),
         New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 7, 8, 9, 10})),
         New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 11, 12})), New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 13, 14})),
         New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 6, 7, 8, 9})),
         New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 10, 11, 12, 13})),
         New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 6, 7})),
         New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 8, 9, 10})), New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
         New SpriteCycleSets(12, New List(Of Integer)(New Integer() {5, 4, 3, 2, 1, 0})),
         New SpriteCycleSets(13, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6, 7})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 15, 16, 17})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 19, 18})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 19, 18, 16, 17})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 7, 8})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 9, 10})), New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 14, 15, 16})),
         New SpriteCycleSets(80, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(81, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(82, New List(Of Integer)(New Integer() {0}))}),
        New WalkCycleSet(PC_EGA_FORMAT, New List(Of SpriteCycleSets) From
         {New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 15, 16})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 16, 15})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 1, 2, 3})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 4, 5, 6})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 7, 8})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 9, 10, 11})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 13, 12})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 13, 10, 11})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 1, 2, 3})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 4, 5, 6})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 7, 8})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 9, 10, 11})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 13, 12})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 13, 10, 11})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 1, 2, 3})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 4, 5, 6})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 7, 8})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 9, 10, 11})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 13, 12})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 13, 10, 11})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 1, 2, 3})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 4, 5, 6})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 7, 8})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 9, 10})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 11, 12})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 13, 14})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 15, 16, 17})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 18})),
         New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 7, 8})),
         New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 9, 10})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
         New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 14, 15, 16})), New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0, 1, 2, 3})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 6, 7, 8})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 9, 10})), New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 11})),
         New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 1, 2, 3})), New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 4, 5})),
         New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 6, 7, 8})),
         New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 6, 7, 8, 9})),
         New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 10, 11, 12, 13})),
         New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 6, 7})),
         New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 8, 9})), New SpriteCycleSets(12, New List(Of Integer)(New Integer() {0, 1, 2, 3})),
         New SpriteCycleSets(13, New List(Of Integer)(New Integer() {0, 1, 2, 3})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 10, 11, 12})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 13, 14, 15})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 17, 16})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 17, 16, 14, 15})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 10, 11, 12})), New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 13, 14, 15})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 17, 16})), New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 17, 16, 14, 15})),
         New SpriteCycleSets(80, New List(Of Integer)(New Integer() {0})), New SpriteCycleSets(81, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(82, New List(Of Integer)(New Integer() {0}))}),
         New WalkCycleSet(IIGS_FORMAT, New List(Of SpriteCycleSets) From
         {New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 16, 15})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 16, 15, 13, 14})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 7})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 8})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 9, 10})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 11, 12, 13})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 15, 14})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 15, 14, 12, 13})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 15, 16})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 16, 13, 14})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 16, 15})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 16, 15, 13, 14})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 12, 13})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 14, 15})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 16, 17})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 15, 16, 17})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 18})),
         New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 7, 8})),
         New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 9, 10})), New SpriteCycleSets(6, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
         New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4})), New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 5, 6, 7})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 8, 9})), New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 10, 11, 12})),
         New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6, 7})), New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 8, 9, 10})),
         New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 11, 12})), New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 13, 14, 15})),
         New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 6, 7, 8, 9})),
         New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 10, 11, 12, 13})),
         New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 6, 7})),
         New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 8, 9, 10})), New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
         New SpriteCycleSets(12, New List(Of Integer)(New Integer() {5, 4, 3, 2, 1, 0})),
         New SpriteCycleSets(13, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6, 7})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 15, 16, 17})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 19, 18})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 19, 18, 16, 17})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 7, 8})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 9, 10})), New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
         New SpriteCycleSets(80, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(81, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(82, New List(Of Integer)(New Integer() {0}))}),
         New WalkCycleSet(AMIGA_FORMAT, New List(Of SpriteCycleSets) From
          {New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 16, 15})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 16, 15, 13, 14})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 7, 8})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 9, 10})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
         New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 15, 14})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 15, 14, 12, 13})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 15, 16, 17})),
         New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 19, 18})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 19, 16, 17})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 16, 15})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 16, 15, 13, 14})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 12, 13})),
         New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 14, 15})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 16, 17})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 15, 16, 17})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 18})),
         New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0, 6, 7})),
         New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0, 8, 9})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4})), New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 5, 6, 7})),
         New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 8, 9})), New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 10, 11, 12})),
         New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 7, 8, 9, 10})),
         New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 11, 12})), New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 13, 14})),
         New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 6, 7, 8, 9})),
         New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 10, 11, 12, 13})),
         New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 6, 7})),
         New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 8, 9, 10})), New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
         New SpriteCycleSets(12, New List(Of Integer)(New Integer() {5, 4, 3, 2, 1, 0})),
         New SpriteCycleSets(13, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6, 7})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
         New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 16, 15})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 16, 15, 13, 14})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 7, 8})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 9, 10})), New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
         New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 14, 15, 16})),
         New SpriteCycleSets(80, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(81, New List(Of Integer)(New Integer() {0})),
         New SpriteCycleSets(82, New List(Of Integer)(New Integer() {0}))}),
         New WalkCycleSet(ST_FORMAT, New List(Of SpriteCycleSets) From
         {New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
        New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
        New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 15, 16})), New SpriteCycleSets(0, New List(Of Integer)(New Integer() {0, 16, 15})),
        New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 7})),
        New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 8})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 9, 10})),
        New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 11, 12, 13})), New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 15, 14})),
        New SpriteCycleSets(1, New List(Of Integer)(New Integer() {0, 15, 14, 12, 13})),
        New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
        New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
        New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 15, 16})), New SpriteCycleSets(2, New List(Of Integer)(New Integer() {0, 16, 13, 14})),
        New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
        New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
        New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 16, 15})), New SpriteCycleSets(3, New List(Of Integer)(New Integer() {0, 16, 15, 13, 14})),
        New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
        New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 12, 13})),
        New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 14, 15})), New SpriteCycleSets(4, New List(Of Integer)(New Integer() {0, 16, 17})),
        New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
        New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
        New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 15, 16, 17})), New SpriteCycleSets(5, New List(Of Integer)(New Integer() {0, 18})),
        New SpriteCycleSets(7, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4})),
        New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4})), New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 5, 6, 7})),
        New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 8, 9})), New SpriteCycleSets(8, New List(Of Integer)(New Integer() {0, 10, 11, 12})),
        New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6, 7})), New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 8, 9, 10})),
        New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 11, 12})), New SpriteCycleSets(9, New List(Of Integer)(New Integer() {0, 13, 14, 15})),
        New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 6, 7, 8, 9})),
        New SpriteCycleSets(10, New List(Of Integer)(New Integer() {0, 10, 11, 12, 13})),
        New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5})), New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 6, 7})),
        New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 8, 9, 10})), New SpriteCycleSets(11, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
        New SpriteCycleSets(12, New List(Of Integer)(New Integer() {5, 4, 3, 2, 1, 0})),
        New SpriteCycleSets(13, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6, 7})),
        New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 7, 8, 9})),
        New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 10, 11})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 12, 13, 14})),
        New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 15, 16, 17})), New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 19, 18})),
        New SpriteCycleSets(14, New List(Of Integer)(New Integer() {0, 19, 18, 16, 17})),
        New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 1, 2, 3, 4, 5, 6})), New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 7, 8})),
        New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 9, 10})), New SpriteCycleSets(15, New List(Of Integer)(New Integer() {0, 11, 12, 13})),
        New SpriteCycleSets(80, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(81, New List(Of Integer)(New Integer() {0})),
        New SpriteCycleSets(82, New List(Of Integer)(New Integer() {0}))})
                         }
    ' FRMLOffsets
    '//Contains each set of offsets of sprite data
    Public FRMLOffsets As List(Of FRML_Offsets) = New List(Of FRML_Offsets) From
    {New FRML_Offsets(PC_VGA_FORMAT, New List(Of SpriteOffsets) From {New SpriteOffsets(-10, 6), New SpriteOffsets(-2, 3), New SpriteOffsets(-5, 4), New SpriteOffsets(-2, 4), New SpriteOffsets(1, 1),
    New SpriteOffsets(0, 6), New SpriteOffsets(-1, 3), New SpriteOffsets(-1, 1), New SpriteOffsets(-5, 6), New SpriteOffsets(-4, 6), New SpriteOffsets(-2, 6), New SpriteOffsets(-3, 5),
    New SpriteOffsets(1, 0), New SpriteOffsets(-4, 6), New SpriteOffsets(3, 0), New SpriteOffsets(-1, 2), New SpriteOffsets(-4, 6), New SpriteOffsets(-5, 6), New SpriteOffsets(-5, 5),
    New SpriteOffsets(0, 0)}),
    New FRML_Offsets(PC_EGA_FORMAT, New List(Of SpriteOffsets) From {New SpriteOffsets(2, 0), New SpriteOffsets(-5, 6), New SpriteOffsets(2, 0), New SpriteOffsets(-5, 6),
    New SpriteOffsets(1, 0), New SpriteOffsets(0, 6), New SpriteOffsets(-2, 5), New SpriteOffsets(5, 3), New SpriteOffsets(-4, 6), New SpriteOffsets(-4, 6), New SpriteOffsets(-1, 6),
    New SpriteOffsets(-4, 6), New SpriteOffsets(-4, 6), New SpriteOffsets(0, 6), New SpriteOffsets(-4, 6), New SpriteOffsets(1, 0), New SpriteOffsets(0, 3), New SpriteOffsets(-5, 4),
    New SpriteOffsets(-1, 0)}),
    New FRML_Offsets(IIGS_FORMAT, New List(Of SpriteOffsets) From {New SpriteOffsets(-2, 3), New SpriteOffsets(0, 0), New SpriteOffsets(-2, 3), New SpriteOffsets(-3, 6), New SpriteOffsets(3, 0),
    New SpriteOffsets(0, 6), New SpriteOffsets(3, 0), New SpriteOffsets(-5, 6), New SpriteOffsets(-5, 6), New SpriteOffsets(-5, 6), New SpriteOffsets(0, 6), New SpriteOffsets(0, 0),
    New SpriteOffsets(2, 0), New SpriteOffsets(-5, 6), New SpriteOffsets(0, 0), New SpriteOffsets(-5, 6), New SpriteOffsets(-1, 4), New SpriteOffsets(0, 0), New SpriteOffsets(-5, 6),
    New SpriteOffsets(-4, 4)}),
    New FRML_Offsets(AMIGA_FORMAT, New List(Of SpriteOffsets) From {New SpriteOffsets(-1, 2), New SpriteOffsets(-4, 6), New SpriteOffsets(-5, 5), New SpriteOffsets(-4, 6), New SpriteOffsets(-4, 3),  ' 1-4
    New SpriteOffsets(2, 4), New SpriteOffsets(0, 0), New SpriteOffsets(-2, 2), New SpriteOffsets(-5, 6), New SpriteOffsets(-4, 6), New SpriteOffsets(0, 3), New SpriteOffsets(0, 1),                   '5-11
    New SpriteOffsets(-1, 1), New SpriteOffsets(-4, 5), New SpriteOffsets(-4, 5), New SpriteOffsets(1, 0), New SpriteOffsets(-0, 0), New SpriteOffsets(0, 0), New SpriteOffsets(0, 0),                    '12-18
    New SpriteOffsets(0, 0)}),
    New FRML_Offsets(ST_FORMAT, New List(Of SpriteOffsets) From {New SpriteOffsets(-4, 6), New SpriteOffsets(-4, 5), New SpriteOffsets(-5, 6), New SpriteOffsets(-4, 6), New SpriteOffsets(-2, 3),  ' 1-4
    New SpriteOffsets(-2, 7), New SpriteOffsets(-4, 0), New SpriteOffsets(-1, 2), New SpriteOffsets(-2, 3), New SpriteOffsets(-5, 6), New SpriteOffsets(0, 6), New SpriteOffsets(0, 0),                   '5-11
    New SpriteOffsets(1, 0), New SpriteOffsets(-1, 2), New SpriteOffsets(0, 3), New SpriteOffsets(0, 1), New SpriteOffsets(-1, 4), New SpriteOffsets(0, 0), New SpriteOffsets(-5, 6),                    '12-18
    New SpriteOffsets(-4, 4)})
    }

    Public Class WalkCycleSet
        Public FileFormat As String
        Public CycleData As List(Of SpriteCycleSets)
        Public Sub New()
        End Sub
        Public Sub New(value As String, ol As List(Of SpriteCycleSets))
            FileFormat = value
            CycleData = ol
        End Sub
    End Class



    Public Function GetSpriteColors(spriteValue As Integer, format As String) As List(Of Integer)
        Dim p_temp As List(Of Integer) = New List(Of Integer)
        For a As Integer = 0 To WIMESpriteColorSets.Count - 1
            If format = WIMESpriteColorSets(a).FileFormat Then
                For b As Integer = 0 To WIMESpriteColorSets(a).CycleData.Count - 1
                    If spriteValue = WIMESpriteColorSets(a).CycleData(b).SpriteValue Then
                        p_temp = WIMESpriteColorSets(a).CycleData(b).CycleSets
                        Exit For
                    End If
                Next b
            End If
        Next a
        Return p_temp
    End Function

    Public Function GetFRMLOffset(format As String) As SpriteOffsets
        Dim TempFormat As String = format
        Dim TempOffsets As SpriteOffsets
        Dim FRMLValue As Integer = Val(Right(loadedFRML.Name, 2))
        TempOffsets = New SpriteOffsets(0, 0)
        For x = 0 To FRMLOffsets.Count
            If TempFormat = FRMLOffsets(x).FileFormat Then
                TempOffsets.DataOffset = FRMLOffsets(x).OffsetList(FRMLValue).DataOffset
                TempOffsets.AddressOffset = FRMLOffsets(x).OffsetList(FRMLValue).AddressOffset
                Exit For
            Else
            End If
        Next x
        Return TempOffsets
    End Function
    Public Class FRML_Offsets
        Public FileFormat As String
        Public OffsetList As List(Of SpriteOffsets)
        Public Sub New()
        End Sub
        Public Sub New(value As String, ol As List(Of SpriteOffsets))
            FileFormat = value
            OffsetList = ol
        End Sub
    End Class
    Public Class SpriteOffsets
        Public DataOffset As Integer
        Public AddressOffset As Integer
        Public Sub New()
        End Sub
        Public Sub New(dof As Integer, aof As Integer)
            DataOffset = dof
            AddressOffset = aof
        End Sub
    End Class
    Public Class SpriteCycleSets
        Public SpriteValue As Integer
        Public CycleSets As List(Of Integer)
        Public Sub New()
        End Sub
        Public Sub New(ByVal spriteVal As Integer, ByVal cycSet As List(Of Integer))
            SpriteValue = spriteVal
            CycleSets = cycSet
        End Sub
    End Class

    Public LoadedSprite As Data
    Public Sub LoadArmySpriteData(ByVal spriteValue As Integer)
        Dim P_SpriteValue As Integer = spriteValue
        Dim SpriteIndex As Integer = spriteValue
        If P_SpriteValue = 80 Then SpriteIndex = 16
        If P_SpriteValue = 81 Then SpriteIndex = 17
        If P_SpriteValue = 82 Then SpriteIndex = 18
        LoadedSprite = New Data
        With LoadedSprite
            .SpriteType = SpriteCluster(SpriteIndex).Name
            .SpriteValue = SpriteCluster(SpriteIndex).Value
            'MsgBox(LoadedSprite.SpriteType & " " & LoadedSprite.SpriteValue)
        End With

        LoadSpriteAnimationData(P_SpriteValue)


        'Select Case LoadedFile.Name
        '    Case PC_VGA_FORMAT
        '        VGALoadSpriteAnimationData(P_SpriteValue)
        '    Case PC_EGA_FORMAT
        '        EGALoadSpriteAnimationData(P_SpriteValue)
        '    Case IIGS_FORMAT
        '        IIGSLoadSpriteAnimationData(P_SpriteValue)
        '    Case AMIGA_FORMAT
        '        AmigaLoadSpriteAnimationData(P_SpriteValue)
        '    Case Else
        '        MsgBox("Error Loading Sprite Data!  Format Type" & LoadedFile.Name & " is an UNKNOWN FORMAT!")
        '        Exit Sub
        'End Select
    End Sub

    Public Sub LoadSpriteAnimationData(ByVal spriteValue As Integer)
        Dim P_IntegerList As List(Of Integer)
        Dim P_CycleTotal As Integer = 0
        LoadedSprite.AnimationCycle = New List(Of Integer)
        LoadedSprite.CycleList = New List(Of List(Of Integer))
        For a As Integer = 0 To WIMESpriteColorSets.Count - 1
            If LoadedFile.Name = WIMESpriteColorSets(a).FileFormat Then
                For b As Integer = 0 To WIMESpriteColorSets(a).CycleData.Count - 1
                    If spriteValue = WIMESpriteColorSets(a).CycleData.Item(b).SpriteValue Then
                        LoadedSprite.SpriteColor = WIMESpriteColorSets(a).CycleData.Item(b).CycleSets
                    End If
                Next
                For y As Integer = 0 To WIMEWalkCycleSets.Count - 1
                    If LoadedFile.Name = WIMEWalkCycleSets(a).FileFormat Then
                        For g As Integer = 0 To WIMEWalkCycleSets(a).CycleData.Count - 1
                            If spriteValue = WIMEWalkCycleSets(a).CycleData.Item(g).SpriteValue Then
                                P_IntegerList = New List(Of Integer)
                                P_IntegerList = WIMEWalkCycleSets(a).CycleData.Item(g).CycleSets
                                LoadedSprite.CycleList.Add(P_IntegerList)
                                P_CycleTotal = P_IntegerList.Count
                                LoadedSprite.AnimationCycle.Add(P_CycleTotal)
                            End If
                        Next g
                    End If
                Next y
                LoadedSprite.TotalLoops = LoadedSprite.AnimationCycle.Count
                LoadedSprite.TotalSpriteColors = LoadedSprite.SpriteColor.Count
                LoadedSprite.AnimateSpeed = 200
            End If
        Next a
    End Sub
End Module

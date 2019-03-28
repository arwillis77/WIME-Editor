Public Class Archive

    ' ===================================================================== ARCHIVE SUB-CLASS ===================================================================================================
    '   SUB-CLASS IN THE GAME CLASS.  GAME CONTAINS RESOURCES AND A SAVE GAME (ARCHIVE).  CONTAINS VARIABLES AND METHODS SPECIFIC TO ARCHIVE FILES.
    ' ===========================================================================================================================================================================================
    Public Const FILENAME = "ARCHIVE.DAT"
    Public Const ARC_ID = "ARCHIVE"
    Public Const ARC_ID_ELEMENTS As String = "SAVE"
    Public Const DESCRIPTION = "SAVE"
    Enum BlockSize
        LittleEndian = 37
        BigEndian = 38
    End Enum
    Public Class Character
        Public CharacterName As String
        Public nameIdentifier As UInt16
        Public unknownBlock As UInt16
        Public armyTotal As UInt16
        Public armyQuantity As UInt16
        Public locationX As UInt16
        Public locationY As UInt16
        Public destinationX As UInt16
        Public destinationY As UInt16
        Public gameObjects As UInt16
        Public mapIcon As Byte
        Public spriteColor As Byte
        Public spriteType As Byte
        Public byte22 As Byte
        Public Visibility As Byte
        Public byte24 As Byte
        Public powerLevel As Byte
        Public moraleTotal As Byte
        Public moraleQuantity As Byte
        Public byte28 As Byte
        Public valueMobilize As Byte
        Public Stealth As Byte
        Public byte31 As Byte
        Public byte32 As Byte
        Public byte33 As Byte
        Public hpTotal As Byte
        Public hpCurrent As Byte
        Public valueLeaderFollow As Byte
        Public byte37 As Byte
        Public intFileStart As Integer
    End Class
End Class

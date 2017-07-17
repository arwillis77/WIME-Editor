Imports System.IO
Imports WIMEEditor.BinaryFile
Imports WIMEEditor.EditorSettings

Public Class Archive
    ' ========================================================== ARCHIVE CLASS v1.0 ===================================================================================
    ' ===                                                                                                                                                           ===
    ' ===   Contains classes, variables, constants, and routines associated with the Archive files for the WIME Editor.  Archive files store data for the           ===
    ' ===   savegame files.                                                                                                                                         === 
    ' ===                                                                                                                                                           ===
    ' =================================================================================================================================================================
    Public Const CHARACTER_MAX As Integer = 193
    'Public Const USHORT_MAX As UInt16 = 65535
    Public Const OBJECT_TOTAL = 16
    'Public Const UBYTE_MAX As Byte = 255
    Public Shared ARC_ID As String = "ARCHIVE.DAT"
    Public Shared ARC_ID_ELEMENTS As String = "SAVE"
    Public Const CITY_MAX As Integer = 83   '68
    Public Shared arcENDIAN As Integer
    Public tempCityName As String
    Public Shared myBA As New BitArray(16)
    Public Shared FormatTotals As Integer = 4

    Enum archiveBlockSize
        LittleEndian = 37
        BigEndian = 38
    End Enum
    Enum cityBlockSize
        LittleEndian = 9
        BigEndian = 10
    End Enum
    Public Shared CityData(CITY_MAX) As CblockData
    Public Shared NameData(CHARACTER_MAX) As aBlockData
    Public Class Offsets
        Public CharacterName(FormatTotals) As Integer
        Public CharacterData(FormatTotals) As Integer
        Public CityName(FormatTotals) As Integer
        Public CityData(FormatTotals) As Integer
        Public InvObj(FormatTotals) As Integer
        Public ArchiveCharVal(FormatTotals) As Integer
        Public EXECharVal(FormatTotals) As Integer
        Public EXEOffset(FormatTotals) As Integer
        Public SaveOffset(FormatTotals) As Integer
    End Class
    Public Shared OffsetArray As New Offsets
    Public Shared Sub setOffsets()
        With OffsetArray
            ' Index Number: {0= PC VGA, 1=PC EGA, 2=IIGS, 3=AMIGA, 4=ST}
            .CharacterName = {113323, 131875, 106464, 37914, 37096}          ' Offset for the Character Name Location in Executable.  Name located in name list.
            .CharacterData = {104654, 123041, 108124, 122708, 116640}        ' Offset for the Character Data Location in Executable.  Includes pointer to name.
            .CityName = {114179, 132731, 104746, 39539, 38721}               ' Offset for the City Name Location in Executable.  Name located in name list.
            .CityData = {112565, 131117, 105706, 131010, 124828}             ' Offset for the City Data Name Location in Executable.  Includes pointer to name, and coordinates.
            .InvObj = {115144, 133696, 120518, 80286, 29228}                 ' Offset for the Object Name Location in Executable.  Name located in object list.
            .ArchiveCharVal = {0, 0, 25538, 0, 24064}                   ' Offset for the Character Name value in the EXE File.  Offset based on comparison of value vs. location in the file.
            .EXECharVal = {0, 0, 33562, -18984, 5862}                    ' Offset for Character Name in EXE vs. value in archive file.
            .EXEOffset = {93300, 112832, 95598, 40, 4}                       ' Difference in values vs. pointer locations in the EXE file.
            .SaveOffset = {0, 0, 25538, 0, 24064}
        End With
    End Sub

    Structure EXEData
        Public CharacterName As String
        Public Value As Integer
        Public Length As Integer
    End Structure
    Public Shared tempEXEData(CHARACTER_MAX) As EXEData
    Public Shared Function getCityBlockSize(tempend As Integer) As Integer
        Select Case tempend
            Case 0
                Return cityBlockSize.LittleEndian
            Case Else
                Return cityBlockSize.BigEndian
        End Select
    End Function

    Public Shared Function _getBlockLength(tempend As Integer) As Integer
        ' Determines the length of the savegame's data block based on the endianness.
        If tempend = 0 Then
            Return archiveBlockSize.LittleEndian
        Else
            Return archiveBlockSize.BigEndian
        End If
    End Function
    Public Shared Function _getArcOffset(tempend As Integer, index As Integer) As Integer
        Dim tempBlock As Integer = ((0) + (_getBlockLength(tempend) * index))
        Return tempBlock
    End Function
    Structure chunkblock
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
        'Public armyName As String
        'Public locationName As String
        'Public destinationName As String
        'Public visible As Boolean
    End Structure
    Public Shared ReadArchive As chunkblock
    Public Shared curCharData As chunkblock
    Public Shared archiveCharacterArray(0 To CHARACTER_MAX) As chunkblock
    Public Class chunkStrings
        Public tempCharName As String
        Public locationCombined As Integer
        Public destinationCombined As Integer
        Public tempVisibility As Boolean
        Public characterName(0 To CHARACTER_MAX) As String
        Public locationName(0 To CHARACTER_MAX) As String
        Public destinationName(0 To CHARACTER_MAX) As String
        Public visibility(0 To CHARACTER_MAX) As Boolean
    End Class
    Public Shared currentCharData As New chunkStrings
    Public Class fileData
        Public characterFollowName(0 To 44) As String
        Public characterFollowvalue(0 To 44) As Integer
        Public cityIcon(CITY_MAX - 15) As Integer
        Public cityName(CITY_MAX - 15) As Integer
        Public cityCopyProtectionCoordinate(CITY_MAX - 15) As String
        Public mapSpriteName(0 To 30) As String
        Public mapSpriteValue(0 To 30) As Integer
        Public spriteName(0 To 51) As String
        Public spriteValue(0 To 51) As Integer
        Public spriteColor(0 To 51) As Integer
        Public mobilizedText(0 To 5) As String
        Public mobilizedValue(0 To 5) As Integer
    End Class
    'Public Shared characterData As New fileData
    Public Shared WimeCityData As New fileData
    Public Shared WimeCityDBData As New fileData
    Public Shared WimeCopyProtectionData As New fileData
    Structure CblockData
        Public fileLocation As Long
        Public unknownUWORD As Long
        Public xCoordinate As UShort
        Public yCoordinate As UShort
        Public unknownUByte As Byte
        Public cityName As String
    End Structure
    Structure aBlockData
        Public fileLocation As Long
        Public charName As String
        Public charValue As Integer
    End Structure
    Public Class objectList
        Public name(0 To OBJECT_TOTAL) As String
        Public value(0 To OBJECT_TOTAL) As UShort
    End Class
    Public Shared WIMEObjects As New objectList
    Public Shared transferObjects As New objectList
    Public Shared Function endianCheck() As Integer
        If (currentFormatSettings.formatID Is FormatSettings.formatID(0) OrElse currentFormatSettings.formatID Is FormatSettings.formatID(1) OrElse currentFormatSettings.formatID Is FormatSettings.formatID(2)) Then
            Return Endianness.endLittle
        ElseIf (currentFormatSettings.formatID Is FormatSettings.formatID(3) OrElse currentFormatSettings.formatID Is FormatSettings.formatID(4)) Then
            Return Endianness.endBig
        Else
            Return Endianness.endLittle
        End If
    End Function
    Public Shared Function getArmyName(value As Integer, endian As Integer) As String
        ' Function evaluates character value and returns character name.
        Dim tempString As String = ""
        For x As Integer = 0 To CHARACTER_MAX
            If value = NameData(x).charValue Then
                tempString = NameData(x).charName
            End If
        Next x
        Return tempString
    End Function
    Public Shared Function getObjectOffset(format As String) As Integer
        Dim returnValue As Integer = 0
        For i As Integer = 0 To FormatTotals
            If format = FormatSettings.formatID(i) Then
                returnValue = OffsetArray.InvObj(i)
            End If
        Next i
        Return returnValue
    End Function

    Public Shared Function getSaveOffset(format As String) As Integer
        Dim returnValue As Integer = 0
        For i As Integer = 0 To FormatTotals
            If format = FormatSettings.formatID(i) Then
                returnValue = OffsetArray.SaveOffset(i)
            End If
        Next i
        Return returnValue
    End Function
    Public Shared Function getCityName(xcoord As Integer, ycoord As Integer) As String
        Dim tempCity As String
        Dim tempCoord As Integer
        tempCoord = xcoord & ycoord
        For x = 0 To CITY_MAX
            If tempCoord = (CityData(x).xCoordinate & CityData(x).yCoordinate) Then
                tempCity = CityData(x).cityName
                Return tempCity
            End If
        Next x
        Return "UNKNOWN"
    End Function

    Public Shared Function processVisible(visibleValue As Integer) As Boolean
        If visibleValue = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Shared Function readBinaryNumber() As String
        Dim tempString As String = ""
        For i As Integer = 0 To myBA.Length
            If myBA(i) = True Then
            End If
            tempString = tempString + Chr(myBA(i))
        Next
        Return tempString
    End Function

    Public Shared Function getObjectValue(characternum As Integer)
        Return archiveCharacterArray(characternum).gameObjects
    End Function
    Public Shared Sub IntToBin(integernumber As UInt16)
        Dim g As Integer = 0
        Dim tempvalue As Integer
        Dim IntNum As Long = integernumber
        Dim binvalue As String = ""
        Do
            'Use the Mod operator to get the current binary digit from the
            'Integer number
            tempvalue = IntNum Mod 2
            myBA(g) = tempvalue
            'MsgBox("BIT " & g & " " & myBA(g))
            binvalue = CStr(tempvalue) + binvalue
            'Divide the current number by 2 and get the integer result
            IntNum = IntNum \ 2
            g = g + 1
        Loop Until IntNum = 0
        'IntToBin = binvalue
    End Sub
    Public Shared Function getNameOffset(format As String) As Integer
        Dim returnValue As Integer = 0
        For i As Integer = 0 To FormatTotals
            If format = FormatSettings.formatID(i) Then
                returnValue = OffsetArray.CharacterName(i)
            End If
        Next i

        Return returnValue
    End Function
    Public Shared Function getEXECharValue(format As String) As Integer
        Dim returnValue As Integer = 0
        For i As Integer = 0 To FormatTotals
            If format = FormatSettings.formatID(i) Then
                returnValue = OffsetArray.EXECharVal(i)
            End If
        Next i
        Return returnValue
    End Function
    Public Shared Function getCharDataEXEOffset(format As String) As Integer
        Dim returnValue As Integer = 0
        For i As Integer = 0 To FormatTotals
            If format = FormatSettings.formatID(i) Then
                returnValue = OffsetArray.CharacterData(i)
            End If
        Next i
        Return returnValue
    End Function
    Public Shared Function getCityNameOffset(format As String) As Integer
        Dim returnValue As Integer = 0
        For i As Integer = 0 To FormatTotals
            If format = FormatSettings.formatID(i) Then
                returnValue = OffsetArray.CityName(i)
            End If
        Next i
        Return returnValue
    End Function
    Public Shared Function getCityDataOffset(format As String) As Integer
        Dim returnValue As Integer = 0
        For i As Integer = 0 To FormatTotals
            If format = FormatSettings.formatID(i) Then
                returnValue = OffsetArray.CityData(i)
            End If
        Next i
        Return returnValue
    End Function
    Public Shared Function getEXEOffsetValue(format As String) As Integer
        Dim returnValue As Integer = 0
        For i As Integer = 0 To FormatTotals
            If format = FormatSettings.formatID(i) Then
                returnValue = OffsetArray.EXEOffset(i)
            End If
        Next i
        Return returnValue
    End Function


End Class

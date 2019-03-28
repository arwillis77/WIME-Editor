Imports WIMEEditor.Archive
Imports WIMEEditor.Game
Imports WIMEEditor.FileFormat

Friend Module GameData
    ' GAMEDATA MODULE
    Public Const PC_VGA_EXE = "START.EXE"
    Public Const PC_EGA_EXE = "LORD.EXE"
    Public Const IIGS_EXE = "EARTH.SYS16"
    Public Const AMIGA_EXE = "WARINMIDDLEEARTH"
    Public Const ST_EXE = "COMMAND.PRG"
    Public Const PC_VGA_FORMAT = "VGA"
    Public Const PC_EGA_FORMAT = "EGA"
    Public Const IIGS_FORMAT = "IIGS"
    Public Const AMIGA_FORMAT = "AMIGA"
    Public Const ST_FORMAT = "ST"

    'Public Format_ID() As String = Game.FORMAT_ID
    'Public OFFSET_CharacterName = {113323, 131875, 106464, 37914, 37096}          ' Offset for the Character Name Location in Executable.  Name located in name list.
    'Public OFFSET_CharacterData = {104654, 123041, 108124, 122708, 116640}        ' Offset for the Character Data Location in Executable.  Includes pointer to name.
    'Public OFFSET_CityName = {114179, 132731, 104746, 39539, 38721}               ' Offset for the City Name Location in Executable.  Name located in name list.
    'Public OFFSET_CityData = {112565, 131117, 105706, 131010, 124828}             ' Offset for the City Data Name Location in Executable.  Includes pointer to name, and coordinates.
    'Public OFFSET_InvObj() As Integer = {115144, 133696, 120518, 80286, 29228}    ' Offset for the Object Name Location in Executable.  Name located in object list.
    'Public OFFSET_EXECharVal = {0, 0, 33562, -18984, 5862}                        ' Offset for Character Name in EXE vs. value in archive file.
    'Public OFFSET_EXEOffset = {93300, 112832, 95598, 40, 4}                       ' Difference in values vs. pointer locations in the EXE file.
    Private ReadOnly CITY_MAX As Integer = 83
    Public Enum cityBlockSize
        LittleEndian = 9
        BigEndian = 10
    End Enum
    Public GameOffsets As List(Of OffsetValues) = New List(Of OffsetValues) From
        {
        New OffsetValues(PC_VGA_FORMAT, 4, 43907, 113323, 104654, 114179, 112565, 115144, 0, 93300), New OffsetValues(PC_EGA_FORMAT, 5, 301405, 131875, 123041, 132731, 131117, 133696, 0, 112832),
        New OffsetValues(IIGS_FORMAT, 5, 20, 106464, 108124, 104746, 105706, 120518, 33562, 95598), New OffsetValues(AMIGA_FORMAT, 4, 8038, 37914, 122708, 39539, 131010, 80286, -18984, 40),
        New OffsetValues(ST_FORMAT, 4, 8038, 37096, 116640, 38721, 124828, 29228, 5862, 4)
        }
    Public GameFormat As List(Of FileFormat) = New List(Of FileFormat) From
        {New FileFormat(PC_VGA_FORMAT, 0, 1, "START.EXE", PC_VGA_ICON, 5, 5), New FileFormat(PC_EGA_FORMAT, 0, 0, "LORD.EXE", PC_VGA_ICON, 0, 0), New FileFormat(IIGS_FORMAT, 0, 0, "EARTH.SYS16", IIGS_ICON, 0, 0),
        New FileFormat(AMIGA_FORMAT, 1, 1, "WARINMIDDLEEARTH", AMIGA_ICON, 5, 5), New FileFormat(ST_FORMAT, 1, 1, "COMMAND.PRG", ST_ICON, 4, 4)
        }
    Public ArmyFollow As List(Of GenericCharacterObject) = New List(Of GenericCharacterObject) From
    {New GenericCharacterObject("GANDALF", 1), New GenericCharacterObject("GANDALF'", 2), New GenericCharacterObject("ELROND", 3), New GenericCharacterObject("GLORFINDEL", 4),
    New GenericCharacterObject("ARAGORN", 5), New GenericCharacterObject("BOROMIR", 6), New GenericCharacterObject("FRODO", 7), New GenericCharacterObject("SAM", 8), New GenericCharacterObject("PIPPIN", 9),
    New GenericCharacterObject("MERRY", 10), New GenericCharacterObject("LEGOLAS", 11), New GenericCharacterObject("GIMLI", 12), New GenericCharacterObject("EOMER", 13), New GenericCharacterObject("FARAMIR", 15),
    New GenericCharacterObject("DAIN", 17), New GenericCharacterObject("BRAND", 19), New GenericCharacterObject("THRANDUIL", 22), New GenericCharacterObject("CELEBORN", 24), New GenericCharacterObject("THEODEN", 26),
    New GenericCharacterObject("THEODRED", 28), New GenericCharacterObject("ERKENBRAND", 30), New GenericCharacterObject("DENETHOR", 32), New GenericCharacterObject("DERNHELM", 35),
    New GenericCharacterObject("ELFHELM", 36), New GenericCharacterObject("GRIMBOLD", 38), New GenericCharacterObject("DUNHERE", 40), New GenericCharacterObject("IMRAHIL", 42), New GenericCharacterObject("FORLONG", 45),
    New GenericCharacterObject("DERVORIN", 47), New GenericCharacterObject("DUINHIR", 49), New GenericCharacterObject("GOLASGIL", 51), New GenericCharacterObject("HIRLUIN", 54), New GenericCharacterObject("GOLLUM", 78),
    New GenericCharacterObject("the NAZGUL LORD", 79), New GenericCharacterObject("the 2ND NAZGUL", 80), New GenericCharacterObject("the 3RD NAZGUL", 81), New GenericCharacterObject("the 4TH NAZGUL", 82), New GenericCharacterObject("the 5TH NAZGUL", 83),
    New GenericCharacterObject("the 6TH NAZGUL", 84), New GenericCharacterObject("the 7TH NAZGUL", 85), New GenericCharacterObject("the 8TH NAZGUL", 86), New GenericCharacterObject("the 9TH NAZGUL", 87), New GenericCharacterObject("GOTHMOG", 103), New GenericCharacterObject("SAURON", 150), New GenericCharacterObject("Shelob", 151),
    New GenericCharacterObject("SARUMAN", 166)    }
    Public CharacterEXE As List(Of EXEData)
    Public CityGroup As List(Of EXECity)
    Public Mobilized As List(Of GenericCharacterObject) = New List(Of GenericCharacterObject) From
    {New GenericCharacterObject("EVIL - NO", 0), New GenericCharacterObject("GOOD -NO", 1), New GenericCharacterObject("STATIONARY NPC -NO", 3),
    New GenericCharacterObject("RANDOM NPC -NO", 4), New GenericCharacterObject("SPECIAL CHARACTER - GOLLUM", 40), New GenericCharacterObject("GOOD - YES", 99)
        }
    Public Class City
        Public Name As Integer
        Public Icon As Integer
        Public ProtectionCoordinate As String
    End Class
    Public Class EXEData
        Public Name As String
        Public Value As UShort
        Public Offset As UInteger
    End Class
    Public Class EXECity
        Inherits EXEData
        Public X As UShort
        Public Y As UShort
    End Class
    Public Class CopyProtectionData
        Public Name As String
        Public Value As String
    End Class
    Public Function GetCityName(xcoord As Integer, ycoord As Integer) As String
        Dim tempCity As String = ""
        Dim tempCoord As Integer
        Dim tempCityData As New EXECity
        tempCoord = xcoord & ycoord
        For x = 0 To CityGroup.Count - 1
            tempCityData.X = CityGroup(x).X : tempCityData.Y = CityGroup(x).Y : tempCityData.Name = CityGroup(x).Name
            If tempCoord = tempCityData.X & tempCityData.Y Then
                tempCity = tempCityData.Name
            End If
        Next x
        Return tempCity
    End Function
    Public Sub ReadCharEXE(filename As String, formatType As String, ByRef endian As Integer)
        Dim tempLoc As UShort
        Dim filepointer As Integer
        Dim tempCharacterEXE As EXEData
        Dim differenceValue As Integer
        Dim tempval As Integer = 0 : Dim newval As Integer = 0
        Dim tempEndian As Integer
        tempEndian = endian
        Dim tempExec As String = LoadedFile.ExecutableFile
        filepointer = LoadedFileOffsets.EXECharacterData
        differenceValue = LoadedFileOffsets.EXEDifferenceOffset 'OFFSET_EXEOffset(formatIndex)
        CharacterEXE = New List(Of EXEData)
        Try
            Select Case formatType
                Case FORMAT_ID(0)                         ' Special Handling for PC VGA Version
                    Using resread As New BinaryFile(filename)
                        Dim ptr As Integer = filepointer
                        Dim i As Integer = 0
                        Do While ptr < 111738
                            tempCharacterEXE = New EXEData
                            resread.Position = ptr
                            tempLoc = resread.ReadWordUnsigned
                            If tempLoc = 6002 Then
                                Dim tempname As String = ""
                                resread.Position = resread.Position - 4
                                tempCharacterEXE.Offset = resread.ReadWordUnsigned(tempEndian)
                                newval = tempCharacterEXE.Offset + differenceValue
                                resread.Position = newval
                                Do
                                    tempval = resread.ReadByte
                                    If tempval = 0 Then Exit Do
                                    tempname = tempname & Chr(tempval)
                                Loop
                                tempCharacterEXE.Name = tempname
                                tempCharacterEXE.Value = tempCharacterEXE.Offset + LoadedFileOffsets.EXECharacterValue 'GetEXECharValue(formatIndex)
                                CharacterEXE.Add(tempCharacterEXE)
                                i = i + 1
                                If i >= (CharacterEXE.Count + 1) Then Exit Do
                            End If
                            ptr = ptr + 1
                        Loop
                    End Using
                Case Else                                               ' Special Handling for other versions
                    Using resread As New BinaryFile(filename)
                        Dim ptr As Integer = filepointer

                        For p As Integer = 0 To CHARACTER_MAX
                            tempCharacterEXE = New EXEData
                            Dim tempname As String = ""
                            resread.Position = ptr + (GetSavegameBlockLength(tempEndian) * (1 * p))
                            tempCharacterEXE.Offset = resread.ReadWordUnsigned(tempEndian)
                            newval = tempCharacterEXE.Offset + differenceValue
                            resread.Position = newval
                            Do
                                tempval = resread.ReadByte
                                If tempval = 0 Then Exit Do
                                tempname = tempname & Chr(tempval)
                            Loop
                            tempCharacterEXE.Name = tempname
                            tempCharacterEXE.Value = tempCharacterEXE.Offset + LoadedFileOffsets.EXECharacterValue 'GetEXECharValue(formatIndex)
                            CharacterEXE.Add(tempCharacterEXE)
                        Next p
                    End Using
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString & "  readChar subroutine in frmArcView.")
        End Try
    End Sub
    Public Sub ReadCityEXE(filename As String, formatType As String, ByRef endian As Integer)
        Dim tempCityData As EXECity
        Dim UWORD As UInteger : Dim UBYTE As Byte
        Dim filepointer As Integer
        Dim differenceValue As Integer
        Dim tempVal As Integer = 0
        Dim newval As Integer = 0
        Dim tempEndian As Integer
        tempEndian = endian
        filepointer = LoadedFileOffsets.EXECityData 'OFFSET_CityData(formatIndex)
        differenceValue = LoadedFileOffsets.EXEDifferenceOffset
        CityGroup = New List(Of EXECity)
        Select Case tempEndian
            Case 0
                Using resread As New BinaryFile(filename)
                    For i As Integer = 0 To CITY_MAX
                        tempCityData = New EXECity
                        Dim ptr As Integer = (filepointer) + (GetCityBlockSize(tempEndian) * i)
                        Dim tempname As String = ""
                        resread.Position = ptr
                        tempCityData.Offset = resread.ReadWordUnsigned(tempEndian)
                        UWORD = resread.ReadWordUnsigned(tempEndian)
                        tempCityData.X = resread.ReadWordUnsigned(tempEndian)
                        tempCityData.Y = resread.ReadWordUnsigned(tempEndian)
                        UBYTE = resread.ReadByteUnsigned
                        newval = tempCityData.Offset + differenceValue
                        resread.Position = newval
                        Do
                            tempVal = resread.ReadByte
                            If tempVal = 0 Then Exit Do
                            tempname = tempname & Chr(tempVal)
                        Loop
                        tempCityData.Name = tempname
                        CityGroup.Add(tempCityData)

                    Next i
                End Using
            Case Else
                Using resread As New BinaryFile(filename)
                    For i As Integer = 0 To CITY_MAX
                        tempCityData = New EXECity
                        Dim ptr As Integer = (filepointer) + (GetCityBlockSize(tempEndian) * i)
                        Dim tempname As String = ""
                        resread.Position = ptr
                        tempCityData.Offset = resread.ReadWordUnsigned(tempEndian)
                        UWORD = resread.ReadWordUnsigned(tempEndian)
                        tempCityData.X = resread.ReadWordUnsigned(tempEndian)
                        tempCityData.Y = resread.ReadWordUnsigned(tempEndian)
                        UBYTE = resread.ReadByteUnsigned
                        newval = tempCityData.Offset + differenceValue
                        resread.Position = newval
                        Do
                            tempVal = resread.ReadByte
                            If tempVal = 0 Then Exit Do
                            tempname = tempname & Chr(tempVal)
                        Loop
                        tempCityData.Name = tempname
                        CityGroup.Add(tempCityData)
                    Next i
                End Using
        End Select
    End Sub
    Public Function GetCityBlockSize(tempend As Integer) As Integer
        Select Case tempend
            Case 0
                Return cityBlockSize.LittleEndian
            Case Else
                Return cityBlockSize.BigEndian
        End Select
    End Function
    Public Function GetSavegameBlockLength(tempend As Integer) As Integer
        ' Determines the length of the savegame's data block based on the endianness.
        If tempend = 0 Then
            Return Archive.BlockSize.LittleEndian
        Else
            Return Archive.BlockSize.BigEndian
        End If
    End Function
End Module

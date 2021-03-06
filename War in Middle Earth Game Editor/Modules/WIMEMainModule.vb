﻿Imports System.IO
Imports System.Xml
Imports WIMEEditor.Game
Imports WIMEEditor.GameData
Imports WIMEEditor.EditorSettings
Imports WIMEEditor.BinaryFile
Imports WIMEEditor.ByteRunUnpacker
Imports WIMEEditor.Archive
Public Module WIMEMain
    ' War in Middle Earth Save Game Editor
    ' Copyright (C) 2018 Aaron R. Willis
    Public tabctrl As TabControl
    Public tabPageVals As New ArrayList
    Public intCNum(0 To CHARACTER_MAX) As String
    ' Status Variables
    Public editorMapTileSize As Integer
    ' // GLOBAL VARIABLE DECLARATIONS
    Public bool_file_open As Boolean = False
    Public scale_values() As UShort = {1, 2, 3}
    Public scaleFactor As UShort = 1
    Public address_offset As Integer
    Public Size_Factor As Integer
    Public MAX_HEIGHT As Integer
    Public Application_Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & Application.ProductName
    ' // SHARED OBJECTS
    Public curCharData As Archive.Character
    Public archiveCharacterArray As List(Of Archive.Character)
    Public ColorIndex As PaletteData.ColorList
    Public tabCHAR As TabPage
    Public tabCSTR As TabPage
    Public tabFONT As TabPage
    Public tabFRML As TabPage
    Public tabIMAG As TabPage
    Public tabMMAP As TabPage
    Public tabArchive As TabPage
    Public ResourceImages As ImageList
    Public GameResourceList As Game.resource.ResourceList
    Public MapIcons As ImageList
    Public LoadedSettings As New EditorSettings
    Public loadedResource As resource
    Public LoadedFile As FileFormat
    Public LoadedFileOffsets As OffsetValues
    Public loadedFRML As Game.resource.animChunk
    Public loadedMMAP As Game.resource.MapChunk
    Public loadedTile As Game.resource.tileChunk
    Public Unpacker As ByteRunUnpacker
    Public SelectedResourceItem As New Game.resource.ResourceDetails
    Public SpriteList As List(Of Bitmap)
    Public ResourcePalette As resource.RGBColorList

    ' =========== MAP RESOURCE VARIABLES ============================================================
    Public intTileFilePointerStart As Integer
    Public intTileMagnifier As Integer
    Public Sub ProcessFRMLData(filename As String, offset_address As Integer, endian As Integer, data_endian As Integer)
        Dim skipFlag As Boolean = False
        Dim p_bytecheck(2) As Integer
        Dim p_AddressStartOffset As New Game.resource.FRML_OFFSET
        Dim NewOffset As New SpriteOffsets
        Dim p_offsetfile As String = DATA_FILES
        Dim FrodoFlag As Boolean = False
        Using inputfile As New BinaryFile(filename)
            inputfile.Position = offset_address
            loadedFRML.chunkSize = inputfile.ReadLongwordUnsigned(endian)
            loadedFRML.uncompressed_size = inputfile.ReadLongwordUnsigned(endian)

            If loadedFRML.uncompressed_size > INT_MAX Then
                FrodoFlag = True
                loadedFRML.uncompressed_size = loadedFRML.chunkSize
                inputfile.Position = inputfile.Position - 4
                loadedFRML.celQuantity = inputfile.ReadWordUnsigned(data_endian)
            Else
                loadedFRML.byte8 = inputfile.ReadByteUnsigned
                loadedFRML.celQuantity = inputfile.ReadWordUnsigned(data_endian)
                If loadedFRML.celQuantity >= 260 Then
                    loadedFRML.bitplanes = 4
                    inputfile.Position = inputfile.Position - 1
                    loadedFRML.celQuantity = inputfile.ReadByteUnsigned()
                End If
            End If
            Unpacker = New ByteRunUnpacker(inputfile)
            ReDim loadedFRML.ResourceKey(loadedFRML.celQuantity, FRML_ResourceKey_Elements)
            ReDim loadedFRML.cel_canvasswidth(loadedFRML.celQuantity)
            ReDim loadedFRML.cel_height(loadedFRML.celQuantity)
            For x As Integer = 0 To loadedFRML.celQuantity - 1
                Dim y As Integer = 0
                Do
                    If y = 0 Then       ' Check the offset for FF values
                        p_bytecheck(0) = inputfile.ReadByteUnsigned
                        If p_bytecheck(0) = &HFF Then
                            p_bytecheck(0) = inputfile.ReadByteUnsigned
                            p_bytecheck(1) = p_bytecheck(0)
                            inputfile.Position = inputfile.Position + 1
                        Else
                            If skipFlag = True Then
                                skipFlag = False
                                inputfile.Position = inputfile.Position + 1
                                p_bytecheck(1) = inputfile.ReadByteUnsigned
                            Else
                                p_bytecheck(1) = inputfile.ReadByteUnsigned
                            End If
                        End If
                        If p_bytecheck(1) = &HFF Then
                            p_bytecheck(1) = inputfile.ReadByteUnsigned
                        End If
                        Select Case data_endian
                            Case 0
                                loadedFRML.ResourceKey(x, y) = ReadShort(p_bytecheck(0), p_bytecheck(1), data_endian)
                            Case Else
                                loadedFRML.ResourceKey(x, y) = ReadShort(p_bytecheck(1), p_bytecheck(0), data_endian)
                        End Select
                    Else                        ' Remaining key are byte values
                        loadedFRML.ResourceKey(x, y) = inputfile.ReadByteUnsigned
                    End If
                    If loadedFRML.ResourceKey(x, y) = &HFF Then          ' Flag value if FF and replace with next value
                        loadedFRML.ResourceKey(x, y) = inputfile.ReadByteUnsigned
                        If y = 4 Then
                            inputfile.Position = inputfile.Position - 1
                            skipFlag = True
                            Exit Do
                        End If
                        inputfile.Position = inputfile.Position + 1
                        'If y >= 4 Then Exit Do
                        y = y + 1
                        loadedFRML.ResourceKey(x, y) = loadedFRML.ResourceKey(x, y - 1)
                    ElseIf loadedFRML.ResourceKey(x, y) = 0 And Not x = 0 Then
                        loadedFRML.ResourceKey(x, y) = loadedFRML.ResourceKey(x - 1, y)
                    End If
                    y = y + 1
                Loop Until y > 4
                loadedFRML.cel_canvasswidth(x) = CalculateCanvasWidth(loadedFRML.ResourceKey(x, 3))
                loadedFRML.cel_height(x) = loadedFRML.ResourceKey(x, 4)
            Next x
            loadedFRML.dStartOffset = (loadedFRML.offset + 8) + loadedFRML.ResourceKey(0, 0)        ' Sets value for location where data begins in FRML chunk.
            'p_AddressStartOffset = Get_FRML_Offset(p_offsetfile, LoadedFile.name, loadedFRML.Name)
            NewOffset = GetFRMLOffset(LoadedFile.Name)


            loadedFRML.dStartOffset = loadedFRML.dStartOffset + NewOffset.DataOffset
            address_offset = NewOffset.AddressOffset
            loadedFRML.ResourceKey((loadedFRML.celQuantity), 0) = loadedFRML.uncompressed_size      ' Sets offset address value for last element in FRML Group.
            If FrodoFlag = True Then
                loadedFRML.chunkData = Unpacker.ReadFrodo(loadedFRML.dStartOffset, loadedFRML.uncompressed_size)
            Else
                loadedFRML.chunkData = Unpacker.UnpackAnim(loadedFRML.dStartOffset, loadedFRML.uncompressed_size, loadedFRML.uncompressed_size)
            End If
        End Using
    End Sub
    Public Function HexByte2Char(ByVal Value As Byte) As String
        ' Return a byte value as a two-digit hex string.
        HexByte2Char = IIf(Value < &H10, "0", "") & Hex$(Value)
    End Function
    ' // SHARED METHODS
    Public Sub ReadArchiveFile(filename As String, endian As Integer)
        Try
            Dim p_blockLength As Integer
            Dim p_streamPosition As Integer
            Dim p_ReadArchive As Archive.Character
            p_blockLength = GetSavegameBlockLength(endian)
            archiveCharacterArray = New List(Of Archive.Character)
            Using readsave As New BinaryFile(filename)
                For currentRecord As Integer = 0 To CHARACTER_MAX
                    p_ReadArchive = New Archive.Character
                    p_streamPosition = (p_blockLength) + (p_blockLength * currentRecord)
                    readsave.Position = p_streamPosition
                    p_ReadArchive.intFileStart = p_streamPosition
                    ' ==== READ CHARACTER NAME =====
                    Select Case endian
                        Case 0
                            p_ReadArchive.nameIdentifier = readsave.ReadWordUnsigned(endian)
                            p_ReadArchive.unknownBlock = readsave.ReadWordUnsigned(endian)
                        Case 1
                            p_ReadArchive.unknownBlock = readsave.ReadWordUnsigned(endian)
                            p_ReadArchive.nameIdentifier = readsave.ReadWordUnsigned(endian)
                        Case Else
                            MsgBox("Endianness Value is unknown: " & endian)
                    End Select

                    p_ReadArchive.CharacterName = GetArmyName(p_ReadArchive.nameIdentifier, endian)
                    p_ReadArchive.armyTotal = readsave.ReadWordUnsigned(endian)
                    p_ReadArchive.armyQuantity = readsave.ReadWordUnsigned(endian)
                    p_ReadArchive.locationX = readsave.ReadWordUnsigned(endian)
                    p_ReadArchive.locationY = readsave.ReadWordUnsigned(endian)
                    p_ReadArchive.destinationX = readsave.ReadWordUnsigned(endian)
                    p_ReadArchive.destinationY = readsave.ReadWordUnsigned(endian)
                    p_ReadArchive.gameObjects = readsave.ReadWordUnsigned(endian)
                    p_ReadArchive.mapIcon = readsave.ReadByte
                    p_ReadArchive.spriteColor = readsave.ReadByte
                    p_ReadArchive.spriteType = readsave.ReadByte
                    p_ReadArchive.byte22 = readsave.ReadByte
                    p_ReadArchive.Visibility = readsave.ReadByte
                    p_ReadArchive.byte24 = readsave.ReadByte
                    p_ReadArchive.powerLevel = readsave.ReadByte
                    p_ReadArchive.moraleTotal = readsave.ReadByte
                    p_ReadArchive.moraleQuantity = readsave.ReadByte
                    p_ReadArchive.byte28 = readsave.ReadByteUnsigned
                    p_ReadArchive.valueMobilize = readsave.ReadByte
                    p_ReadArchive.Stealth = readsave.ReadByte
                    p_ReadArchive.byte31 = readsave.ReadByte
                    p_ReadArchive.byte32 = readsave.ReadByte
                    p_ReadArchive.byte33 = readsave.ReadByte
                    p_ReadArchive.hpTotal = readsave.ReadByte
                    p_ReadArchive.hpCurrent = readsave.ReadByte
                    p_ReadArchive.valueLeaderFollow = readsave.ReadByte
                    p_ReadArchive.byte37 = readsave.ReadByte
                    archiveCharacterArray.Add(p_ReadArchive)
                Next currentRecord
            End Using
        Catch ex As Exception
            MsgBox("PROGRAM ERROR.  LOCATION ReadArchiveFile subroutine Module WIMEMainModule.  " & vbLf & ex.ToString)
        End Try
    End Sub
End Module

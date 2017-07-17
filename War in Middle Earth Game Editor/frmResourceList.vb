Imports WIMEEditor.Game
Public Class frmResourceList
    Private ResourceType As String
    Dim selectedResource As String
    Dim totalWidth As Integer = 0
    Public frmResourceItem As Form
    Dim SplitResourceList As SplitContainer
    Dim WithEvents listResourceItems As ListView
    Dim page As TabPage
    Dim currenttile As Integer
    Dim ArchiveFilename As String = ""
    Dim EXEFile As String = gameExecutables(loadedGame.formatVal)
    Dim EXEFull As String = loadedSettings.wimeDIRECTORY & "\" & EXEFile
    Private Sub frmResourceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupResourceTable()
        Select Case ResourceType
            Case Game.Archive.ARC_ID
                ArchiveFilename = loadedSettings.wimeDIRECTORY & "\" & Game.Archive.FILENAME
                readCharEXE(EXEFull, loadedGame.format, loadedGame.formatVal, loadedGame.endianType)
                readCityEXE(EXEFull, loadedGame.format, loadedGame.formatVal, loadedGame.endianType)
                SetArchiveCBOArrayData()
                ReadArchiveFile(ArchiveFilename, loadedGame.endianType)
                For jj = 0 To CHARACTER_MAX
                    fillArchiveList(jj)
                Next jj
            Case Else
                FillList(ResourceType)
        End Select
        autoResizeColumnWidths(listResourceItems)
        'ResizeListColumns()
        listResourceItems.Height = Me.Height - 20
        'listResourceItems.Dock = DockStyle.Fill
        SplitResourceList.IsSplitterFixed = True
        SplitResourceList.Refresh()
    End Sub
    Private Sub frmResourceList_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SplitResourceList.SplitterDistance = listResourceItems.Width + 10
        listResourceItems.Dock = DockStyle.Fill
    End Sub

    Public Sub New(resource As String)
        ' This call is required by the designer.
        InitializeComponent()
        Me.ResourceType = resource
        ' Add any initialization after the InitializeComponent() call.
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.AutoScroll = True
        Me.Dock = DockStyle.Fill
        Me.TopLevel = False
        SplitResourceList = New SplitContainer
        Me.Controls.Add(SplitResourceList)
        SplitResourceList.Dock = DockStyle.Fill

        SplitResourceList.IsSplitterFixed = False
        SplitResourceList.SplitterIncrement = 1
    End Sub
    Public Sub SetupResourceTable()
        listResourceItems = New ListView
        listResourceItems.Size = New Size(395, 795)
        listResourceItems.View = View.Details
        listResourceItems.GridLines = True
        SplitResourceList.Panel1.Controls.Add(listResourceItems)
        listResourceItems.Clear()
        listResourceItems.BackColor = Color.FromArgb(64, 64, 64)
        listResourceItems.ForeColor = Color.White
        listResourceItems.Columns.Add("Name")
        listResourceItems.Columns.Add("#", HorizontalAlignment.Right)
        listResourceItems.Columns.Add("Size (bytes)", HorizontalAlignment.Right)
        listResourceItems.Columns.Add("Type", HorizontalAlignment.Right)
        listResourceItems.Columns.Add("Resource", HorizontalAlignment.Right)
        listResourceItems.Columns.Add("Offset", HorizontalAlignment.Left)

    End Sub
    Friend Sub autoResizeColumnWidths(ByVal lvControlName As ListView)
        Dim minWidthArray As Integer
        For i = 0 To lvControlName.Columns.Count - 1
            'Resize to fit the header
            lvControlName.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize)
            'Store the minimum width required to display the header
            minWidthArray = lvControlName.Columns(i).Width
            'Resize to fit contents
            lvControlName.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent)
            'Check to see if the minumum width is met
            If lvControlName.Columns(i).Width < minWidthArray Then
                lvControlName.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize)
            End If
        Next
    End Sub
    Public Sub ResizeListColumns()

        For i As Integer = 0 To listResourceItems.Columns.Count - 1
            listResourceItems.Columns.Item(i).Width = -2
            totalWidth = totalWidth + listResourceItems.Columns.Item(i).Width
        Next
        listResourceItems.Width = totalWidth
    End Sub
    Public Sub fillResourceList(loopNum As Integer)
        Dim resLV As ListViewItem = listResourceItems.Items.Add(GameResourceList.Item(loopNum).Name)
        resLV.SubItems.Add(GameResourceList.Item(loopNum).Number)
        resLV.SubItems.Add(GameResourceList.Item(loopNum).Size)
        resLV.SubItems.Add(GameResourceList.Item(loopNum).Type)
        resLV.SubItems.Add(GameResourceList.Item(loopNum).File)
        resLV.SubItems.Add(GameResourceList.Item(loopNum).Offset)
    End Sub
    Public Sub FillList(resource As String)
        For jj = 0 To (GameResourceList.Count - 1)
            If GameResourceList.Item(jj).Type = resource Then
                fillResourceList(jj)
            End If
        Next
    End Sub
    Public Sub fillArchiveList(loopnum As Integer)
        Dim p_Offset As Integer = 0
        If CharacterEXE(loopnum).Name = "" Then
            CharacterEXE(loopnum).Name = "ERROR"
        End If
        Dim resLV As ListViewItem = listResourceItems.Items.Add(CharacterEXE(loopnum).Name)
        p_Offset = _getArcOffset(loadedGame.endianType, loopnum)
        resLV.SubItems.Add(loopnum)
        resLV.SubItems.Add(_getBlockLength(loadedGame.endianType))
        resLV.SubItems.Add(Game.Archive.ARC_ID_ELEMENTS)
        resLV.SubItems.Add(Game.Archive.ARC_ID)
        resLV.SubItems.Add(p_Offset)
    End Sub
    Public Function GetSelectedResource(type As String) As String
        Dim p_value As String = ""
        If type = Game.Archive.ARC_ID_ELEMENTS Then
            p_value = Game.Archive.ARC_ID
            Return p_value
        End If
        For x As Integer = 0 To Game.resource.RES_ID.Length - 1
            If type = Game.resource.RES_ID_ELEMENTS(x) Then
                p_value = Game.resource.RES_ID(x)
                Exit For
            End If
        Next
        Return p_value
    End Function
    Public Sub SetFRMLInfo()
        loadedFRML.Name = listResourceItems.SelectedItems(0).SubItems(0).Text
        loadedResource.Filename = loadedSettings.wimeDIRECTORY & "\" & listResourceItems.SelectedItems(0).SubItems(4).Text & ".RES"
        loadedFRML.offset = Val(listResourceItems.SelectedItems(0).SubItems(5).Text)
        loadedFRML.bitplanes = getPlanes(loadedGame.format)
    End Sub
    Private Sub listResourceItems_ItemActivate(sender As Object, e As EventArgs) Handles listResourceItems.ItemActivate
        DisplayResource(True)
    End Sub
    Private Sub listResourceItems_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles listResourceItems.SelectedIndexChanged
        DisplayResource(False)
    End Sub
    Public Sub DisplayResource(TabDisplay As Boolean)
        Try
            If listResourceItems.SelectedItems.Count > 0 Then
                SelectedResourceItem.Name = listResourceItems.SelectedItems(0).SubItems(0).Text
                SelectedResourceItem.Number = Val(listResourceItems.SelectedItems(0).SubItems(1).Text)
                SelectedResourceItem.dataSize = Val(listResourceItems.SelectedItems(0).SubItems(2).Text)
                SelectedResourceItem.resourceType = listResourceItems.SelectedItems(0).SubItems(3).Text
                SelectedResourceItem.resourceFile = listResourceItems.SelectedItems(0).SubItems(4).Text
                SelectedResourceItem.fileOffset = Val(listResourceItems.SelectedItems(0).SubItems(5).Text)
                selectedResource = GetSelectedResource(listResourceItems.SelectedItems(0).SubItems(3).Text)
                Select Case selectedResource
                    Case Game.Archive.ARC_ID
                        frmResourceItem = New frmArcView
                    Case Game.resource.FRML_ID, Game.resource.IMAG_ID, Game.resource.CSTR_ID
                        frmResourceItem = New frmViewResource(SelectedResourceItem)
                    Case Game.resource.CHAR_ID
                        currenttile = Val(listResourceItems.SelectedItems(0).SubItems(1).Text)
                        frmResourceItem = New frmViewResource(SelectedResourceItem, loadedTile, currenttile)
                    Case Game.resource.MAP_ID
                        frmResourceItem = New MapView(loadedMMAP)
                    Case Else
                        MsgBox("UNKNOWN RESOURCE")
                        Exit Sub
                End Select
                frmResourceItem.TopLevel = False
                frmResourceItem.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                frmResourceItem.AutoScroll = True
                frmResourceItem.Dock = DockStyle.Fill
                If TabDisplay = True Then
                    page = New TabPage
                    Dim tabTitle As String = listResourceItems.SelectedItems(0).SubItems(0).Text & "      "
                    page.Text = tabTitle
                    frmWIMEEditorMain.tclExplorerMain.TabPages.Add(page)
                    page.Controls.Add(frmResourceItem)
                    tabPageVals.Add(page)
                    frmWIMEEditorMain.tclExplorerMain.SelectedTab = page
                Else
                    SplitResourceList.Panel2.Controls.Clear()
                    SplitResourceList.Panel2.Controls.Add(frmResourceItem)
                End If
                frmResourceItem.Show()
            End If
        Catch ex As Exception
            MsgBox("frmResourceList Error in event lstResourceItem_Activate handler.  " & ex.ToString)
        End Try
    End Sub


End Class
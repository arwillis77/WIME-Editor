Imports WIMEEditor.Game
Public Class frmResourceList
    Private ResourceType As String
    Dim SelectedResource As String
    Dim TotalWidth As Integer = 0
    Public frmResourceItem As Form
    Dim SplitResourceList As SplitContainer
    Dim WithEvents ListResourceItems As ListView
    Dim Page As TabPage
    Dim CurrentTile As Integer = 0
    Dim ArchiveFilename As String = ""
    Dim EXEFile As String = LoadedFile.ExecutableFile
    Dim EXEFull As String = LoadedSettings.wimeDIRECTORY & "\" & EXEFile
    Private Sub frmResourceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupResourceTable()
        Select Case ResourceType
            Case Archive.ARC_ID
                ArchiveFilename = LoadedSettings.wimeDIRECTORY & "\" & Archive.FILENAME
                ReadCharEXE(EXEFull, LoadedFile.Name, LoadedFile.Endian)
                ReadCityEXE(EXEFull, LoadedFile.Name, LoadedFile.Endian)

                ReadArchiveFile(ArchiveFilename, LoadedFile.Endian)
                For jj = 0 To CHARACTER_MAX
                    FillArchiveList(jj)
                Next jj
            Case Else
                FillList(ResourceType)
        End Select
        AutoResizeColumnWidths(ListResourceItems)
        'ResizeListColumns()
        ListResourceItems.Height = Me.Height - 20
        'listResourceItems.Dock = DockStyle.Fill
        SplitResourceList.IsSplitterFixed = True
        SplitResourceList.Refresh()
    End Sub
    Private Sub frmResourceList_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        SplitResourceList.SplitterDistance = ListResourceItems.Width + 10
        ListResourceItems.Dock = DockStyle.Fill
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
        ListResourceItems = New ListView With {
        .Size = New Size(395, 795),
        .View = View.Details,
        .GridLines = True,
        .BackColor = Color.FromArgb(64, 64, 64),
        .ForeColor = Color.White
        }
        SplitResourceList.Panel1.Controls.Add(ListResourceItems)
        With ListResourceItems
            .Columns.Add("Name")
            .Columns.Add("#", HorizontalAlignment.Right)
            .Columns.Add("Size (bytes)", HorizontalAlignment.Right)
            .Columns.Add("Type", HorizontalAlignment.Right)
            .Columns.Add("Resource", HorizontalAlignment.Right)
            .Columns.Add("Offset", HorizontalAlignment.Left)
        End With
    End Sub
    Friend Sub AutoResizeColumnWidths(ByVal lvControlName As ListView)
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

        For i As Integer = 0 To ListResourceItems.Columns.Count - 1
            ListResourceItems.Columns.Item(i).Width = -2
            TotalWidth = TotalWidth + ListResourceItems.Columns.Item(i).Width
        Next
        ListResourceItems.Width = TotalWidth
    End Sub
    Public Sub FillResourceList(loopNum As Integer)
        Dim resLV As ListViewItem = ListResourceItems.Items.Add(GameResourceList.Item(loopNum).Name)
        resLV.SubItems.Add(GameResourceList.Item(loopNum).Number)
        resLV.SubItems.Add(GameResourceList.Item(loopNum).Size)
        resLV.SubItems.Add(GameResourceList.Item(loopNum).Type)
        resLV.SubItems.Add(GameResourceList.Item(loopNum).File)
        resLV.SubItems.Add(GameResourceList.Item(loopNum).Offset)
    End Sub
    Public Sub FillList(resource As String)
        For jj = 0 To (GameResourceList.Count - 1)
            If GameResourceList.Item(jj).Type = resource Then
                FillResourceList(jj)
            End If
        Next
    End Sub
    Public Sub FillArchiveList(loopnum As Integer)
        Dim p_Offset As Integer = 0
        If CharacterEXE(loopnum).Name = "" Then
            CharacterEXE(loopnum).Name = "ERROR"
        End If
        Dim resLV As ListViewItem = ListResourceItems.Items.Add(CharacterEXE(loopnum).Name)
        p_Offset = GetArchiveOffset(LoadedFile.Endian, loopnum)
        resLV.SubItems.Add(loopnum)
        resLV.SubItems.Add(GetSavegameBlockLength(LoadedFile.Endian))
        resLV.SubItems.Add(Archive.ARC_ID_ELEMENTS)
        resLV.SubItems.Add(Archive.ARC_ID)
        resLV.SubItems.Add(p_Offset)
    End Sub
    Public Function GetSelectedResource(type As String) As String
        Dim p_value As String = ""
        If type = Archive.ARC_ID_ELEMENTS Then
            p_value = Archive.ARC_ID
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
        Dim p_datafile = DATA_FILES
        loadedFRML.Name = ListResourceItems.SelectedItems(0).SubItems(0).Text
        loadedResource.Filename = LoadedSettings.wimeDIRECTORY & "\" & ListResourceItems.SelectedItems(0).SubItems(4).Text & ".RES"
        loadedFRML.offset = Val(ListResourceItems.SelectedItems(0).SubItems(5).Text)
        loadedFRML.bitplanes = LoadedFile.FRMLBitplanes
    End Sub
    Private Sub ListResourceItems_ItemActivate(sender As Object, e As EventArgs) Handles ListResourceItems.ItemActivate
        DisplayResource(True)
    End Sub
    Private Sub ListResourceItems_SelectedIndexChanged1(sender As Object, e As EventArgs) Handles ListResourceItems.SelectedIndexChanged
        DisplayResource(False)
    End Sub
    Public Sub DisplayResource(TabDisplay As Boolean)
        Try
            If ListResourceItems.SelectedItems.Count > 0 Then
                SelectedResourceItem.Name = ListResourceItems.SelectedItems(0).SubItems(0).Text
                SelectedResourceItem.Number = Val(ListResourceItems.SelectedItems(0).SubItems(1).Text)
                SelectedResourceItem.dataSize = Val(ListResourceItems.SelectedItems(0).SubItems(2).Text)
                SelectedResourceItem.resourceType = ListResourceItems.SelectedItems(0).SubItems(3).Text
                SelectedResourceItem.resourceFile = ListResourceItems.SelectedItems(0).SubItems(4).Text
                SelectedResourceItem.fileOffset = Val(ListResourceItems.SelectedItems(0).SubItems(5).Text)
                SelectedResource = GetSelectedResource(ListResourceItems.SelectedItems(0).SubItems(3).Text)
                Select Case SelectedResource
                    Case Archive.ARC_ID
                        frmResourceItem = New frmArcView
                    Case Game.resource.FRML_ID, Game.resource.IMAG_ID, Game.resource.CSTR_ID
                        frmResourceItem = New frmViewResource(SelectedResourceItem)
                    Case Game.resource.CHAR_ID
                        CurrentTile = Val(ListResourceItems.SelectedItems(0).SubItems(1).Text)
                        frmResourceItem = New frmViewResource(SelectedResourceItem, loadedTile, CurrentTile)
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
                    Page = New TabPage
                    Dim tabTitle As String = ListResourceItems.SelectedItems(0).SubItems(0).Text & "      "
                    Page.Text = tabTitle
                    frmWIMEEditorMain.tclExplorerMain.TabPages.Add(Page)
                    Page.Controls.Add(frmResourceItem)
                    tabPageVals.Add(Page)
                    frmWIMEEditorMain.tclExplorerMain.SelectedTab = Page
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
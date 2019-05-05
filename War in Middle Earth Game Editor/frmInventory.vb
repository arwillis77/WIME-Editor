Imports WIMEEditor.Game
Imports WIMEEditor.GameData
Imports WIMEEditor.Archive
Public Class frmInventory
    Public AllInventoryList As New List(Of GenericCharacterObject)
    Public TransferredInventoryList As New List(Of GenericCharacterObject)
    Public newObjectList As New List(Of GenericCharacterObject)
    Public lv As ListViewItem
        Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For h = 0 To TransferredInventoryList.Count - 1
            If TransferredInventoryList(h).Name = Nothing Then Exit For
            lv = New ListViewItem
            lv = lstCurrentInventory.Items.Add(TransferredInventoryList(h).Name)
            lv.SubItems.Add(TransferredInventoryList(h).Value)
        Next
        For k As Integer = 0 To AllInventoryList.Count - 1
            Dim oflag As Boolean = True
            For x As Integer = 0 To TransferredInventoryList.Count - 1
                If AllInventoryList(k).Name = TransferredInventoryList(x).Name Then
                    If TransferredInventoryList(x).Name = Nothing Then Exit For
                    oflag = False
                End If
            Next x
            If oflag = True Then
                lv = New ListViewItem
                lv = lstFullInventory.Items.Add(AllInventoryList(k).Name)
                lv.SubItems.Add(AllInventoryList(k).Value)
            End If
        Next k
    End Sub

    Public Sub New(objectlist As List(Of GenericCharacterObject), transferobjects As List(Of GenericCharacterObject))
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        AllInventoryList = objectlist
        TransferredInventoryList = transferobjects
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            For Each item As ListViewItem In lstFullInventory.SelectedItems
                item.Remove()
                lv = New ListViewItem
                lv = lstCurrentInventory.Items.Add(item)
            Next
        End Sub
        Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
            For Each item As ListViewItem In lstCurrentInventory.SelectedItems
                item.Remove()
                lv = New ListViewItem
                lv = lstFullInventory.Items.Add(item)
            Next
        End Sub
        Private Sub btnAddAll_Click(sender As Object, e As EventArgs) Handles btnAddAll.Click
            lstFullInventory.BeginUpdate()
            For Each item As ListViewItem In lstFullInventory.Items
                item.Selected = True
            Next
            lstFullInventory.EndUpdate()
            For Each item As ListViewItem In lstFullInventory.SelectedItems
                item.Remove()
                lv = New ListViewItem
                lv = lstCurrentInventory.Items.Add(item)
            Next
        End Sub
        Private Sub btnRemoveAll_Click(sender As Object, e As EventArgs) Handles btnRemoveAll.Click
            lstCurrentInventory.BeginUpdate()
            For Each item As ListViewItem In lstCurrentInventory.Items
                item.Selected = True
            Next
            lstCurrentInventory.EndUpdate()
            For Each item As ListViewItem In lstCurrentInventory.SelectedItems

                item.Remove()
                lv = New ListViewItem
                lv = lstFullInventory.Items.Add(item)
            Next
        End Sub
        Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
            Dim tempobj As Integer = lstCurrentInventory.Items.Count
            If tempobj > 16 Then tempobj = 16

        Dim tempValue As Integer = 0
            Dim lv As New ListViewItem
            For c As Integer = 0 To tempobj - 1
            newObjectList(c).Value = Val(lstCurrentInventory.Items(c).SubItems(1).Text)
            tempValue = tempValue + newObjectList(c).Value
        Next c
            Me.Tag = tempValue
        Me.DialogResult = DialogResult.OK
    End Sub
    End Class
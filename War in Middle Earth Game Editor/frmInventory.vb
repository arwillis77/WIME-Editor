Imports WIMEEditor.Game
Public Class frmInventory
    Public AllInventoryList As New Game.Executable.Inventory
    Public TransferredInventoryList As New Game.Executable.Inventory
    Public newObjectList As New Game.Executable.Inventory
    Public lv As ListViewItem
    Private Sub frmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For h = 0 To TransferredInventoryList.name.Length - 2
            If TransferredInventoryList.name(h) = Nothing Then Exit For
            lv = New ListViewItem
            lv = lstCurrentInventory.Items.Add(TransferredInventoryList.name(h))
            lv.SubItems.Add(TransferredInventoryList.value(h))
        Next
        For k As Integer = 0 To AllInventoryList.name.Length - 1
            Dim oflag As Boolean = True
            For x As Integer = 0 To TransferredInventoryList.name.Length - 2
                If AllInventoryList.name(k) = TransferredInventoryList.name(x) Then
                    If TransferredInventoryList.name(x) = Nothing Then Exit For
                    oflag = False
                End If
            Next x
            If oflag = True Then
                lv = New ListViewItem
                lv = lstFullInventory.Items.Add(AllInventoryList.name(k))
                lv.SubItems.Add(AllInventoryList.value(k))
            End If
        Next k
    End Sub
  
    Public Sub New(objectlist As Game.Executable.Inventory, transferobjects As Game.Executable.Inventory)
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
        ReDim newObjectList.name(tempobj) : ReDim newObjectList.value(tempobj)
        Dim tempValue As Integer = 0
        Dim lv As New ListViewItem
        For c As Integer = 0 To tempobj - 1
            newObjectList.value(c) = Val(lstCurrentInventory.Items(c).SubItems(1).Text)
            tempValue = tempValue + newObjectList.value(c)
        Next c
        Me.Tag = tempValue
        Me.DialogResult = DialogResult.OK

    End Sub
End Class
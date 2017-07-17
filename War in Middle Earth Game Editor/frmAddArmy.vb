Imports WIMEEditor.Game

Public Class frmAddArmy
    Private Sub frmAddArmy(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim intTempCharNum As Integer
        Dim intFollowTemp As Integer

        ' Fill Listview for Character that Follow Selected Character
        ' Fill Listview for Character Overview
        lvwCharacterFollowActual.Columns.Clear()
        lvwCharacterFollowActual.Items.Clear()
        lvwCharacterFollowActual.View = View.Details
        lvwCharacterFollowActual.GridLines = True
        lvwCharacterFollowActual.FullRowSelect = True
        lvwCharacterFollowActual.HideSelection = False
        lvwCharacterFollowActual.MultiSelect = False
        lvwCharacterFollowActual.Columns.Add("Number", 50)
        lvwCharacterFollowActual.Columns.Add("Character/Army", 125)
        lvwCharacterFollowActual.Columns.Add("QTY", 50)
        Dim tempFollowValue As Integer
        Dim curCharVal As Integer = 0
        Dim tempCharacternumber As Integer
        Dim tempCharData As Game.Archive.Character
        For x As Integer = 0 To CHARACTER_MAX
            tempCharData = archiveCharacterArray(x)
            tempFollowValue = tempCharData.valueLeaderFollow
            If tempFollowValue = curCharVal Then
                tempCharacterNumber = x
                intCNum(x) = tempCharacternumber
                Dim lv As ListViewItem = lvwCharacterFollowActual.Items.Add(intCNum(x))
                'The remaining columns are subitems  
                ' lv.SubItems.Add(frmWIMEEditorMain.characterNamelist(x))
                lv.SubItems.Add(tempCharData.armyQuantity)
            End If
        Next
        lvwCharacterFollowSelectList.Columns.Clear()
        lvwCharacterFollowSelectList.Items.Clear()
        lvwCharacterFollowSelectList.View = View.Details
        lvwCharacterFollowSelectList.GridLines = True
        lvwCharacterFollowSelectList.FullRowSelect = True
        lvwCharacterFollowSelectList.HideSelection = False
        lvwCharacterFollowSelectList.MultiSelect = False
        lvwCharacterFollowSelectList.Columns.Add("Number", 50)
        lvwCharacterFollowSelectList.Columns.Add("Character/Army", 125)
        lvwCharacterFollowSelectList.Columns.Add("QTY", 50)
        For intFollowFill As Integer = 0 To CHARACTER_MAX
            intFollowTemp = ArchiveCharacterCBOArrays.characterFollowvalue(intFollowFill)
            'If intFollowTemp = intCurrentCharacter Then
            If intFollowTemp = 0 Then
                intTempCharNum = intFollowFill + 1
                intCNum(intFollowFill) = intTempCharNum
                Dim lv1 As ListViewItem = lvwCharacterFollowSelectList.Items.Add(intCNum(intFollowFill))
                'The remaining columns are subitems  
                'lv1.SubItems.Add(archiveCharacterArray.characterName(intFollowFill))
                lv1.SubItems.Add(archiveCharacterArray(intFollowFill).armyQuantity)
            Else
            End If
        Next intFollowFill
    End Sub
    Private Sub ListView_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles lvwCharacterFollowSelectList.ItemDrag, lvwCharacterFollowActual.ItemDrag
        Dim myItems(sender.SelectedItems.Count - 1) As ListViewItem
        Dim i As Integer = 0
        ' Loop though the SelectedItems collection for the source.
        For Each myItem As ListViewItem In sender.SelectedItems
            ' Add the ListViewItem to the array of ListViewItems.
            myItems(i) = myItem
            i = i + 1
        Next
        ' Create a DataObject containg the array of ListViewItems.
        sender.DoDragDrop(New DataObject("System.Windows.Forms.ListViewItem()", myItems), DragDropEffects.Move)
    End Sub

    Private Sub ListView_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwCharacterFollowSelectList.DragEnter, lvwCharacterFollowActual.DragEnter
        ' Check for the custom DataFormat ListViewItem array.
        If e.Data.GetDataPresent("System.Windows.Forms.ListViewItem()") Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListView_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwCharacterFollowSelectList.DragDrop, lvwCharacterFollowActual.DragDrop

        Dim myItems() As ListViewItem = e.Data.GetData("System.Windows.Forms.ListViewItem()")
        Dim i As Integer = 0

        For Each myItem As ListViewItem In myItems
            ' Add the item to the target list.
            Dim lvItem As ListViewItem = sender.Items.Add(myItem.Text)

            'Loop through the sub items and add it to the destination Listview
            Dim j As Integer
            For j = 1 To myItem.SubItems.Count - 1
                lvItem.SubItems.Add(myItem.SubItems(j).Text)
            Next

            ' Remove the item from the source list.
            If sender Is lvwCharacterFollowSelectList Then
                lvwCharacterFollowActual.Items.Remove(lvwCharacterFollowActual.SelectedItems.Item(0))
            Else
                lvwCharacterFollowSelectList.Items.Remove(lvwCharacterFollowSelectList.SelectedItems.Item(0))
            End If
            i += 1
        Next
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
    End Sub
End Class
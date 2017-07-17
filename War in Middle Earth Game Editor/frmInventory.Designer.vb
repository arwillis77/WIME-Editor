<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lstCurrentInventory = New System.Windows.Forms.ListView()
        Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstFullInventory = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnAddAll = New System.Windows.Forms.Button()
        Me.btnRemoveAll = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstCurrentInventory
        '
        Me.lstCurrentInventory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colValue})
        Me.lstCurrentInventory.FullRowSelect = True
        Me.lstCurrentInventory.GridLines = True
        Me.lstCurrentInventory.Location = New System.Drawing.Point(24, 29)
        Me.lstCurrentInventory.Name = "lstCurrentInventory"
        Me.lstCurrentInventory.Size = New System.Drawing.Size(184, 301)
        Me.lstCurrentInventory.TabIndex = 31
        Me.lstCurrentInventory.UseCompatibleStateImageBehavior = False
        Me.lstCurrentInventory.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        Me.colName.Text = "Item"
        Me.colName.Width = 120
        '
        'colValue
        '
        Me.colValue.Text = "Value"
        '
        'lstFullInventory
        '
        Me.lstFullInventory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstFullInventory.FullRowSelect = True
        Me.lstFullInventory.GridLines = True
        Me.lstFullInventory.Location = New System.Drawing.Point(20, 29)
        Me.lstFullInventory.Name = "lstFullInventory"
        Me.lstFullInventory.Size = New System.Drawing.Size(184, 301)
        Me.lstFullInventory.TabIndex = 32
        Me.lstFullInventory.UseCompatibleStateImageBehavior = False
        Me.lstFullInventory.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Item"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Value"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(271, 55)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 23)
        Me.btnAdd.TabIndex = 33
        Me.btnAdd.Text = "Add >>"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(271, 84)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(100, 23)
        Me.btnRemove.TabIndex = 34
        Me.btnRemove.Text = "<< Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstFullInventory)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 359)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Items Available"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lstCurrentInventory)
        Me.GroupBox3.Location = New System.Drawing.Point(377, 26)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(231, 359)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Character Inventory"
        '
        'btnAddAll
        '
        Me.btnAddAll.Location = New System.Drawing.Point(271, 113)
        Me.btnAddAll.Name = "btnAddAll"
        Me.btnAddAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAddAll.Size = New System.Drawing.Size(100, 23)
        Me.btnAddAll.TabIndex = 38
        Me.btnAddAll.Text = "Add All >>"
        Me.btnAddAll.UseVisualStyleBackColor = True
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.Location = New System.Drawing.Point(271, 142)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnRemoveAll.Size = New System.Drawing.Size(100, 23)
        Me.btnRemoveAll.TabIndex = 39
        Me.btnRemoveAll.Text = "Remove All >>"
        Me.btnRemoveAll.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(283, 319)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 40
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(283, 348)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 41
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmInventoryCtrl
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(647, 402)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnRemoveAll)
        Me.Controls.Add(Me.btnAddAll)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Name = "frmInventoryCtrl"
        Me.Text = "Inventory Control"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstCurrentInventory As System.Windows.Forms.ListView
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstFullInventory As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddAll As System.Windows.Forms.Button
    Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddArmy
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
        Me.lvwCharacterFollowSelectList = New System.Windows.Forms.ListView()
        Me.lvwCharacterFollowActual = New System.Windows.Forms.ListView()
        Me.lblAvailableArmies = New System.Windows.Forms.Label()
        Me.lblSelectedArmies = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvwCharacterFollowSelectList
        '
        Me.lvwCharacterFollowSelectList.AllowDrop = True
        Me.lvwCharacterFollowSelectList.Location = New System.Drawing.Point(52, 62)
        Me.lvwCharacterFollowSelectList.Name = "lvwCharacterFollowSelectList"
        Me.lvwCharacterFollowSelectList.Size = New System.Drawing.Size(240, 273)
        Me.lvwCharacterFollowSelectList.TabIndex = 0
        Me.lvwCharacterFollowSelectList.UseCompatibleStateImageBehavior = False
        '
        'lvwCharacterFollowActual
        '
        Me.lvwCharacterFollowActual.AllowDrop = True
        Me.lvwCharacterFollowActual.Location = New System.Drawing.Point(403, 62)
        Me.lvwCharacterFollowActual.Name = "lvwCharacterFollowActual"
        Me.lvwCharacterFollowActual.Size = New System.Drawing.Size(240, 273)
        Me.lvwCharacterFollowActual.TabIndex = 1
        Me.lvwCharacterFollowActual.UseCompatibleStateImageBehavior = False
        '
        'lblAvailableArmies
        '
        Me.lblAvailableArmies.AutoSize = True
        Me.lblAvailableArmies.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailableArmies.Location = New System.Drawing.Point(49, 34)
        Me.lblAvailableArmies.Name = "lblAvailableArmies"
        Me.lblAvailableArmies.Size = New System.Drawing.Size(125, 20)
        Me.lblAvailableArmies.TabIndex = 2
        Me.lblAvailableArmies.Text = "Available Armies"
        '
        'lblSelectedArmies
        '
        Me.lblSelectedArmies.AutoSize = True
        Me.lblSelectedArmies.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedArmies.Location = New System.Drawing.Point(399, 34)
        Me.lblSelectedArmies.Name = "lblSelectedArmies"
        Me.lblSelectedArmies.Size = New System.Drawing.Size(125, 20)
        Me.lblSelectedArmies.TabIndex = 3
        Me.lblSelectedArmies.Text = "Selected Armies"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(533, 376)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(623, 376)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmAddArmy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 411)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblSelectedArmies)
        Me.Controls.Add(Me.lblAvailableArmies)
        Me.Controls.Add(Me.lvwCharacterFollowActual)
        Me.Controls.Add(Me.lvwCharacterFollowSelectList)
        Me.Name = "frmAddArmy"
        Me.ShowIcon = False
        Me.Text = "War in Middle Earth - Add Army"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwCharacterFollowSelectList As System.Windows.Forms.ListView
    Friend WithEvents lvwCharacterFollowActual As System.Windows.Forms.ListView
    Friend WithEvents lblAvailableArmies As System.Windows.Forms.Label
    Friend WithEvents lblSelectedArmies As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpriteDraw
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
        Me.pnlSpriteView = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pnlSpriteView
        '
        Me.pnlSpriteView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlSpriteView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSpriteView.Location = New System.Drawing.Point(0, 0)
        Me.pnlSpriteView.Name = "pnlSpriteView"
        Me.pnlSpriteView.Size = New System.Drawing.Size(459, 361)
        Me.pnlSpriteView.TabIndex = 12
        '
        'frmSpriteDraw
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(459, 361)
        Me.Controls.Add(Me.pnlSpriteView)
        Me.Name = "frmSpriteDraw"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSpriteDraw"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSpriteView As System.Windows.Forms.Panel
End Class

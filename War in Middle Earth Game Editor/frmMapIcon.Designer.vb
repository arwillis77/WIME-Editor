<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMapIcon
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
        Me.pnlImagView = New System.Windows.Forms.Panel()
        Me.pcMapIcon = New System.Windows.Forms.PictureBox()
        CType(Me.pcMapIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlImagView
        '
        Me.pnlImagView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlImagView.Location = New System.Drawing.Point(0, 0)
        Me.pnlImagView.Name = "pnlImagView"
        Me.pnlImagView.Size = New System.Drawing.Size(250, 298)
        Me.pnlImagView.TabIndex = 11
        '
        'pcMapIcon
        '
        Me.pcMapIcon.Location = New System.Drawing.Point(475, 306)
        Me.pcMapIcon.Name = "pcMapIcon"
        Me.pcMapIcon.Size = New System.Drawing.Size(48, 48)
        Me.pcMapIcon.TabIndex = 12
        Me.pcMapIcon.TabStop = False
        '
        'frmMapIcon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 461)
        Me.Controls.Add(Me.pcMapIcon)
        Me.Controls.Add(Me.pnlImagView)
        Me.Name = "frmMapIcon"
        Me.ShowIcon = False
        CType(Me.pcMapIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlImagView As System.Windows.Forms.Panel
    Friend WithEvents pcMapIcon As System.Windows.Forms.PictureBox
End Class

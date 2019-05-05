<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            ' Close the field objects before form disposal
            If Not disposing Then
                bmp.Dispose()
                b2.Dispose()
                pic.Dispose()
                myBrush.Dispose()
            End If
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
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.mapPanel = New System.Windows.Forms.Panel()
        Me.pctMapTile = New System.Windows.Forms.PictureBox()
        Me.pctTileSet = New System.Windows.Forms.PictureBox()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.mapPanel.SuspendLayout()
        CType(Me.pctMapTile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTileSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.AutoScroll = True
        Me.SplitContainer2.Panel1.Controls.Add(Me.pctTileSet)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.Controls.Add(Me.mapPanel)
        Me.SplitContainer2.Size = New System.Drawing.Size(1267, 783)
        Me.SplitContainer2.SplitterDistance = 100
        Me.SplitContainer2.TabIndex = 0
        '
        'mapPanel
        '
        Me.mapPanel.AutoScroll = True
        Me.mapPanel.AutoSize = True
        Me.mapPanel.Controls.Add(Me.pctMapTile)
        Me.mapPanel.Location = New System.Drawing.Point(3, 3)
        Me.mapPanel.Name = "mapPanel"
        Me.mapPanel.Size = New System.Drawing.Size(2560, 1584)
        Me.mapPanel.TabIndex = 0
        '
        'pctMapTile
        '
        Me.pctMapTile.Location = New System.Drawing.Point(27, 15)
        Me.pctMapTile.Name = "pctMapTile"
        Me.pctMapTile.Size = New System.Drawing.Size(48, 48)
        Me.pctMapTile.TabIndex = 0
        Me.pctMapTile.TabStop = False
        '
        'pctTileSet
        '
        Me.pctTileSet.Location = New System.Drawing.Point(0, 0)
        Me.pctTileSet.Name = "pctTileSet"
        Me.pctTileSet.Size = New System.Drawing.Size(80, 816)
        Me.pctTileSet.TabIndex = 0
        Me.pctTileSet.TabStop = False
        '
        'MapView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1267, 783)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Name = "MapView"
        Me.Text = "Synergistic Worldbuilder MMAP Resource View v1.0"
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.mapPanel.ResumeLayout(False)
        CType(Me.pctMapTile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTileSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents pctTileSet As System.Windows.Forms.PictureBox
    Friend WithEvents mapPanel As System.Windows.Forms.Panel
    Friend WithEvents pctMapTile As System.Windows.Forms.PictureBox

End Class

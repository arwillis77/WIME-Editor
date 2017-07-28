<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewResource
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewResource))
        Me.ssResourceStatus = New System.Windows.Forms.StatusStrip()
        Me.lblGameStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ddScale = New System.Windows.Forms.ToolStripDropDownButton()
        Me.lblSpriteColor = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ddSpriteColor = New System.Windows.Forms.ToolStripDropDownButton()
        Me.pnlMainDisplay = New System.Windows.Forms.Panel()
        Me.ssResourceStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssResourceStatus
        '
        Me.ssResourceStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblGameStatus, Me.ToolStripStatusLabel2, Me.ddScale, Me.lblSpriteColor, Me.ddSpriteColor})
        Me.ssResourceStatus.Location = New System.Drawing.Point(0, 568)
        Me.ssResourceStatus.Name = "ssResourceStatus"
        Me.ssResourceStatus.Size = New System.Drawing.Size(1094, 24)
        Me.ssResourceStatus.TabIndex = 1
        Me.ssResourceStatus.Text = "StatusStrip1"
        '
        'lblGameStatus
        '
        Me.lblGameStatus.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblGameStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lblGameStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.lblGameStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lblGameStatus.Name = "lblGameStatus"
        Me.lblGameStatus.Size = New System.Drawing.Size(97, 19)
        Me.lblGameStatus.Text = "Resource Details"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(81, 19)
        Me.ToolStripStatusLabel2.Text = "Magnification"
        '
        'ddScale
        '
        Me.ddScale.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ddScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ddScale.Image = CType(resources.GetObject("ddScale.Image"), System.Drawing.Image)
        Me.ddScale.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ddScale.Name = "ddScale"
        Me.ddScale.Size = New System.Drawing.Size(13, 22)
        Me.ddScale.ToolTipText = "Choose Magnification Level"
        '
        'lblSpriteColor
        '
        Me.lblSpriteColor.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lblSpriteColor.Name = "lblSpriteColor"
        Me.lblSpriteColor.Size = New System.Drawing.Size(69, 19)
        Me.lblSpriteColor.Text = "Sprite Color"
        '
        'ddSpriteColor
        '
        Me.ddSpriteColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ddSpriteColor.Image = CType(resources.GetObject("ddSpriteColor.Image"), System.Drawing.Image)
        Me.ddSpriteColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ddSpriteColor.Name = "ddSpriteColor"
        Me.ddSpriteColor.Size = New System.Drawing.Size(13, 22)
        '
        'pnlMainDisplay
        '
        Me.pnlMainDisplay.BackColor = System.Drawing.Color.Black
        Me.pnlMainDisplay.Location = New System.Drawing.Point(30, 30)
        Me.pnlMainDisplay.Name = "pnlMainDisplay"
        Me.pnlMainDisplay.Size = New System.Drawing.Size(640, 480)
        Me.pnlMainDisplay.TabIndex = 0
        '
        'frmViewResource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1094, 592)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMainDisplay)
        Me.Controls.Add(Me.ssResourceStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmViewResource"
        Me.ShowIcon = False
        Me.Text = "frmViewResource"
        Me.ssResourceStatus.ResumeLayout(False)
        Me.ssResourceStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssResourceStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents lblGameStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ddScale As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents pnlMainDisplay As System.Windows.Forms.Panel
    Friend WithEvents lblSpriteColor As ToolStripStatusLabel
    Friend WithEvents ddSpriteColor As ToolStripDropDownButton
End Class

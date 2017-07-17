<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCityEditor
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCityEditor))
        Me.lvwCityList = New System.Windows.Forms.ListView()
        Me.grpLocations = New System.Windows.Forms.GroupBox()
        Me.grpInfo = New System.Windows.Forms.GroupBox()
        Me.pctLocationIcon = New System.Windows.Forms.PictureBox()
        Me.LblLocationX = New System.Windows.Forms.Label()
        Me.txtLocationX = New System.Windows.Forms.TextBox()
        Me.LblLocationY = New System.Windows.Forms.Label()
        Me.txtLocationY = New System.Windows.Forms.TextBox()
        Me.txtLocationName = New System.Windows.Forms.TextBox()
        Me.lblLocationName = New System.Windows.Forms.Label()
        Me.grpAddArmy = New System.Windows.Forms.GroupBox()
        Me.grpMoveTo = New System.Windows.Forms.GroupBox()
        Me.cboLocationMove = New System.Windows.Forms.ComboBox()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.lvwArmyList = New System.Windows.Forms.ListView()
        Me.btnAddArmy = New System.Windows.Forms.Button()
        Me.imgLocationTiles = New System.Windows.Forms.ImageList(Me.components)
        Me.grpLocations.SuspendLayout()
        Me.grpInfo.SuspendLayout()
        CType(Me.pctLocationIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAddArmy.SuspendLayout()
        Me.grpMoveTo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwCityList
        '
        Me.lvwCityList.Location = New System.Drawing.Point(45, 41)
        Me.lvwCityList.Name = "lvwCityList"
        Me.lvwCityList.Size = New System.Drawing.Size(290, 312)
        Me.lvwCityList.TabIndex = 2
        Me.lvwCityList.UseCompatibleStateImageBehavior = False
        '
        'grpLocations
        '
        Me.grpLocations.Controls.Add(Me.lvwCityList)
        Me.grpLocations.Location = New System.Drawing.Point(12, 21)
        Me.grpLocations.Name = "grpLocations"
        Me.grpLocations.Size = New System.Drawing.Size(390, 394)
        Me.grpLocations.TabIndex = 3
        Me.grpLocations.TabStop = False
        Me.grpLocations.Text = "List of Middle Earth Locations"
        '
        'grpInfo
        '
        Me.grpInfo.Controls.Add(Me.pctLocationIcon)
        Me.grpInfo.Controls.Add(Me.LblLocationX)
        Me.grpInfo.Controls.Add(Me.txtLocationX)
        Me.grpInfo.Controls.Add(Me.LblLocationY)
        Me.grpInfo.Controls.Add(Me.txtLocationY)
        Me.grpInfo.Controls.Add(Me.txtLocationName)
        Me.grpInfo.Controls.Add(Me.lblLocationName)
        Me.grpInfo.Location = New System.Drawing.Point(424, 21)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Size = New System.Drawing.Size(561, 100)
        Me.grpInfo.TabIndex = 3
        Me.grpInfo.TabStop = False
        Me.grpInfo.Text = "Location Information"
        '
        'pctLocationIcon
        '
        Me.pctLocationIcon.Location = New System.Drawing.Point(473, 23)
        Me.pctLocationIcon.Name = "pctLocationIcon"
        Me.pctLocationIcon.Size = New System.Drawing.Size(48, 48)
        Me.pctLocationIcon.TabIndex = 3
        Me.pctLocationIcon.TabStop = False
        '
        'LblLocationX
        '
        Me.LblLocationX.Location = New System.Drawing.Point(278, 21)
        Me.LblLocationX.Name = "LblLocationX"
        Me.LblLocationX.Size = New System.Drawing.Size(20, 20)
        Me.LblLocationX.TabIndex = 8
        Me.LblLocationX.Text = "(X)"
        Me.LblLocationX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLocationX
        '
        Me.txtLocationX.Location = New System.Drawing.Point(299, 23)
        Me.txtLocationX.Name = "txtLocationX"
        Me.txtLocationX.ReadOnly = True
        Me.txtLocationX.Size = New System.Drawing.Size(34, 20)
        Me.txtLocationX.TabIndex = 6
        Me.txtLocationX.TabStop = False
        Me.txtLocationX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblLocationY
        '
        Me.LblLocationY.AutoSize = True
        Me.LblLocationY.Location = New System.Drawing.Point(345, 26)
        Me.LblLocationY.Name = "LblLocationY"
        Me.LblLocationY.Size = New System.Drawing.Size(20, 13)
        Me.LblLocationY.TabIndex = 9
        Me.LblLocationY.Text = "(Y)"
        Me.LblLocationY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLocationY
        '
        Me.txtLocationY.Location = New System.Drawing.Point(371, 22)
        Me.txtLocationY.Name = "txtLocationY"
        Me.txtLocationY.ReadOnly = True
        Me.txtLocationY.Size = New System.Drawing.Size(34, 20)
        Me.txtLocationY.TabIndex = 7
        Me.txtLocationY.TabStop = False
        Me.txtLocationY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocationName
        '
        Me.txtLocationName.Location = New System.Drawing.Point(101, 22)
        Me.txtLocationName.Name = "txtLocationName"
        Me.txtLocationName.ReadOnly = True
        Me.txtLocationName.Size = New System.Drawing.Size(140, 20)
        Me.txtLocationName.TabIndex = 1
        '
        'lblLocationName
        '
        Me.lblLocationName.AutoSize = True
        Me.lblLocationName.Location = New System.Drawing.Point(16, 25)
        Me.lblLocationName.Name = "lblLocationName"
        Me.lblLocationName.Size = New System.Drawing.Size(79, 13)
        Me.lblLocationName.TabIndex = 0
        Me.lblLocationName.Text = "Location Name"
        '
        'grpAddArmy
        '
        Me.grpAddArmy.Controls.Add(Me.grpMoveTo)
        Me.grpAddArmy.Controls.Add(Me.lvwArmyList)
        Me.grpAddArmy.Controls.Add(Me.btnAddArmy)
        Me.grpAddArmy.Location = New System.Drawing.Point(424, 132)
        Me.grpAddArmy.Name = "grpAddArmy"
        Me.grpAddArmy.Size = New System.Drawing.Size(561, 327)
        Me.grpAddArmy.TabIndex = 6
        Me.grpAddArmy.TabStop = False
        Me.grpAddArmy.Text = "Character/Armies"
        '
        'grpMoveTo
        '
        Me.grpMoveTo.Controls.Add(Me.cboLocationMove)
        Me.grpMoveTo.Controls.Add(Me.btnMove)
        Me.grpMoveTo.Location = New System.Drawing.Point(281, 36)
        Me.grpMoveTo.Name = "grpMoveTo"
        Me.grpMoveTo.Size = New System.Drawing.Size(262, 100)
        Me.grpMoveTo.TabIndex = 7
        Me.grpMoveTo.TabStop = False
        Me.grpMoveTo.Text = "Move To"
        '
        'cboLocationMove
        '
        Me.cboLocationMove.FormattingEnabled = True
        Me.cboLocationMove.Location = New System.Drawing.Point(17, 36)
        Me.cboLocationMove.Name = "cboLocationMove"
        Me.cboLocationMove.Size = New System.Drawing.Size(140, 21)
        Me.cboLocationMove.TabIndex = 9
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(181, 71)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(75, 23)
        Me.btnMove.TabIndex = 8
        Me.btnMove.Text = "Move"
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'lvwArmyList
        '
        Me.lvwArmyList.Location = New System.Drawing.Point(27, 36)
        Me.lvwArmyList.Name = "lvwArmyList"
        Me.lvwArmyList.Size = New System.Drawing.Size(230, 163)
        Me.lvwArmyList.TabIndex = 0
        Me.lvwArmyList.UseCompatibleStateImageBehavior = False
        Me.lvwArmyList.View = System.Windows.Forms.View.Details
        '
        'btnAddArmy
        '
        Me.btnAddArmy.Location = New System.Drawing.Point(102, 212)
        Me.btnAddArmy.Name = "btnAddArmy"
        Me.btnAddArmy.Size = New System.Drawing.Size(75, 23)
        Me.btnAddArmy.TabIndex = 1
        Me.btnAddArmy.Text = "Add Army"
        Me.btnAddArmy.UseVisualStyleBackColor = True
        '
        'imgLocationTiles
        '
        Me.imgLocationTiles.ImageStream = CType(resources.GetObject("imgLocationTiles.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLocationTiles.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLocationTiles.Images.SetKeyName(0, "locationtile1.png")
        Me.imgLocationTiles.Images.SetKeyName(1, "locationtile1.png")
        Me.imgLocationTiles.Images.SetKeyName(2, "WIMETile3E.PNG")
        Me.imgLocationTiles.Images.SetKeyName(3, "WIMETile4F.PNG")
        Me.imgLocationTiles.Images.SetKeyName(4, "WIMETile2E.PNG")
        Me.imgLocationTiles.Images.SetKeyName(5, "WIMETile4E.PNG")
        Me.imgLocationTiles.Images.SetKeyName(6, "WIMETile3C.PNG")
        Me.imgLocationTiles.Images.SetKeyName(7, "WIMETile0B.PNG")
        Me.imgLocationTiles.Images.SetKeyName(8, "WIMETile2D.PNG")
        Me.imgLocationTiles.Images.SetKeyName(9, "WIMETileF2.PNG")
        Me.imgLocationTiles.Images.SetKeyName(10, "WIMETileAE.PNG")
        Me.imgLocationTiles.Images.SetKeyName(11, "WIMETileFD.PNG")
        Me.imgLocationTiles.Images.SetKeyName(12, "WIMETile67.PNG")
        Me.imgLocationTiles.Images.SetKeyName(13, "WIMETile8E.PNG")
        Me.imgLocationTiles.Images.SetKeyName(14, "WIMETile0A.PNG")
        Me.imgLocationTiles.Images.SetKeyName(15, "WIMETile5E.PNG")
        Me.imgLocationTiles.Images.SetKeyName(16, "WIMETile47.PNG")
        Me.imgLocationTiles.Images.SetKeyName(17, "WIMETileAC.PNG")
        Me.imgLocationTiles.Images.SetKeyName(18, "WIMETileDE.PNG")
        Me.imgLocationTiles.Images.SetKeyName(19, "WIMETile1A.PNG")
        Me.imgLocationTiles.Images.SetKeyName(20, "WIMETile37.PNG")
        Me.imgLocationTiles.Images.SetKeyName(21, "WIMETileBC.PNG")
        Me.imgLocationTiles.Images.SetKeyName(22, "WIMETile7D.PNG")
        Me.imgLocationTiles.Images.SetKeyName(23, "WIMETile90.PNG")
        Me.imgLocationTiles.Images.SetKeyName(24, "WIMETile0E.PNG")
        Me.imgLocationTiles.Images.SetKeyName(25, "WIMETile81.PNG")
        Me.imgLocationTiles.Images.SetKeyName(26, "WIMETile8D.PNG")
        Me.imgLocationTiles.Images.SetKeyName(27, "WIMETile9D.PNG")
        Me.imgLocationTiles.Images.SetKeyName(28, "WIMETileCB.PNG")
        Me.imgLocationTiles.Images.SetKeyName(29, "WIMETile6D.PNG")
        Me.imgLocationTiles.Images.SetKeyName(30, "WIMETile0C.PNG")
        Me.imgLocationTiles.Images.SetKeyName(31, "WIMETile82.PNG")
        Me.imgLocationTiles.Images.SetKeyName(32, "WIMETile1C.PNG")
        Me.imgLocationTiles.Images.SetKeyName(33, "WIMETile72.PNG")
        Me.imgLocationTiles.Images.SetKeyName(34, "WIMETileF5.PNG")
        Me.imgLocationTiles.Images.SetKeyName(35, "WIMETile69.PNG")
        Me.imgLocationTiles.Images.SetKeyName(36, "WIMETile21.PNG")
        Me.imgLocationTiles.Images.SetKeyName(37, "WIMETileFC.PNG")
        Me.imgLocationTiles.Images.SetKeyName(38, "WIMETile27.PNG")
        Me.imgLocationTiles.Images.SetKeyName(39, "WIMETileE5.PNG")
        Me.imgLocationTiles.Images.SetKeyName(40, "WIMETile3B.PNG")
        Me.imgLocationTiles.Images.SetKeyName(41, "WIMETile9F.PNG")
        Me.imgLocationTiles.Images.SetKeyName(42, "WIMETile0D.PNG")
        Me.imgLocationTiles.Images.SetKeyName(43, "WIMETileE7.PNG")
        Me.imgLocationTiles.Images.SetKeyName(44, "WIMETile3D.PNG")
        Me.imgLocationTiles.Images.SetKeyName(45, "WIMETile2C.PNG")
        Me.imgLocationTiles.Images.SetKeyName(46, "WIMETile4D.PNG")
        Me.imgLocationTiles.Images.SetKeyName(47, "WIMETile5D.PNG")
        Me.imgLocationTiles.Images.SetKeyName(48, "WIMETile2B.PNG")
        '
        'frmCityEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 485)
        Me.Controls.Add(Me.grpAddArmy)
        Me.Controls.Add(Me.grpInfo)
        Me.Controls.Add(Me.grpLocations)
        Me.Name = "frmCityEditor"
        Me.ShowIcon = False
        Me.Text = "War in Middle Earth - Location Editor"
        Me.TopMost = True
        Me.grpLocations.ResumeLayout(False)
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        CType(Me.pctLocationIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAddArmy.ResumeLayout(False)
        Me.grpMoveTo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwCityList As System.Windows.Forms.ListView
    Friend WithEvents grpLocations As System.Windows.Forms.GroupBox
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtLocationName As System.Windows.Forms.TextBox
    Friend WithEvents lblLocationName As System.Windows.Forms.Label
    Friend WithEvents LblLocationX As System.Windows.Forms.Label
    Friend WithEvents txtLocationX As System.Windows.Forms.TextBox
    Friend WithEvents LblLocationY As System.Windows.Forms.Label
    Friend WithEvents txtLocationY As System.Windows.Forms.TextBox
    Friend WithEvents grpAddArmy As System.Windows.Forms.GroupBox
    Friend WithEvents lvwArmyList As System.Windows.Forms.ListView
    Friend WithEvents btnAddArmy As System.Windows.Forms.Button
    Friend WithEvents grpMoveTo As System.Windows.Forms.GroupBox
    Friend WithEvents btnMove As System.Windows.Forms.Button
    Friend WithEvents cboLocationMove As System.Windows.Forms.ComboBox
    Friend WithEvents pctLocationIcon As System.Windows.Forms.PictureBox
    Friend WithEvents imgLocationTiles As System.Windows.Forms.ImageList
    Friend WithEvents LocationImageList As System.Windows.Forms.ImageList
End Class

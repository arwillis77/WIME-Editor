<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArcView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArcView))
        Me.colNumber = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.colQty = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colArmy = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.grpSpriteView = New System.Windows.Forms.GroupBox()
        Me.pnlAnimate = New System.Windows.Forms.Panel()
        Me.grpAniCtrl = New System.Windows.Forms.GroupBox()
        Me.cboSpriteColor = New System.Windows.Forms.ComboBox()
        Me.lblColorScheme = New System.Windows.Forms.Label()
        Me.cboSpriteName = New System.Windows.Forms.ComboBox()
        Me.lblSpriteName = New System.Windows.Forms.Label()
        Me.nbrCel = New System.Windows.Forms.NumericUpDown()
        Me.nbrLoop = New System.Windows.Forms.NumericUpDown()
        Me.lblLoopFWDSlash = New System.Windows.Forms.Label()
        Me.lblCelFWDSlash = New System.Windows.Forms.Label()
        Me.btnAnimate = New System.Windows.Forms.Button()
        Me.txtFrameTotal = New System.Windows.Forms.TextBox()
        Me.lblCel = New System.Windows.Forms.Label()
        Me.lblLoop = New System.Windows.Forms.Label()
        Me.txtLoopTotal = New System.Windows.Forms.TextBox()
        Me.nbrPower = New System.Windows.Forms.NumericUpDown()
        Me.lblPower = New System.Windows.Forms.Label()
        Me.grpMapIcon = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnChangeBack = New System.Windows.Forms.Button()
        Me.btnChangeNext = New System.Windows.Forms.Button()
        Me.pbMapIcon = New System.Windows.Forms.PictureBox()
        Me.grpInventory = New System.Windows.Forms.GroupBox()
        Me.btnAddItems = New System.Windows.Forms.Button()
        Me.txtInventory = New System.Windows.Forms.TextBox()
        Me.lstObjectInventory = New System.Windows.Forms.ListView()
        Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpUnknown = New System.Windows.Forms.GroupBox()
        Me.txtByte3 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtByte37 = New System.Windows.Forms.TextBox()
        Me.lblByte37 = New System.Windows.Forms.Label()
        Me.txtByte33 = New System.Windows.Forms.TextBox()
        Me.lblByte33 = New System.Windows.Forms.Label()
        Me.txtByte32 = New System.Windows.Forms.TextBox()
        Me.lblByte32 = New System.Windows.Forms.Label()
        Me.txtByte31 = New System.Windows.Forms.TextBox()
        Me.lblByte31 = New System.Windows.Forms.Label()
        Me.txtByte24 = New System.Windows.Forms.TextBox()
        Me.lblByte24 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nbrStealth = New System.Windows.Forms.NumericUpDown()
        Me.lblQTY = New System.Windows.Forms.Label()
        Me.nbrArmyTotal = New System.Windows.Forms.NumericUpDown()
        Me.nbrMoraleTotal = New System.Windows.Forms.NumericUpDown()
        Me.nbrMorale = New System.Windows.Forms.NumericUpDown()
        Me.nbrHitTotal = New System.Windows.Forms.NumericUpDown()
        Me.nbrArmyQTY = New System.Windows.Forms.NumericUpDown()
        Me.lblHPof = New System.Windows.Forms.Label()
        Me.lblStealth = New System.Windows.Forms.Label()
        Me.lblMorale = New System.Windows.Forms.Label()
        Me.lblMoraleof = New System.Windows.Forms.Label()
        Me.lblQtyOf = New System.Windows.Forms.Label()
        Me.lblHitPoints = New System.Windows.Forms.Label()
        Me.nbrHitPoints = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboCharacterFollow = New System.Windows.Forms.ComboBox()
        Me.txtArmyName = New System.Windows.Forms.TextBox()
        Me.lblCharacterName = New System.Windows.Forms.Label()
        Me.lblFollow = New System.Windows.Forms.Label()
        Me.chkVisible = New System.Windows.Forms.CheckBox()
        Me.lblMobilize = New System.Windows.Forms.Label()
        Me.cboMobilized = New System.Windows.Forms.ComboBox()
        Me.grpAddArmy = New System.Windows.Forms.GroupBox()
        Me.lvwCharacterFollow = New System.Windows.Forms.ListView()
        Me.btnAddArmy = New System.Windows.Forms.Button()
        Me.grpCharacterPlacement = New System.Windows.Forms.GroupBox()
        Me.cboDestination = New System.Windows.Forms.ComboBox()
        Me.cboLocation = New System.Windows.Forms.ComboBox()
        Me.lblCityLocationName = New System.Windows.Forms.Label()
        Me.lblDestinationName = New System.Windows.Forms.Label()
        Me.txtDestinationY = New System.Windows.Forms.TextBox()
        Me.LblLocationX = New System.Windows.Forms.Label()
        Me.txtLocationX = New System.Windows.Forms.TextBox()
        Me.txtDestinationX = New System.Windows.Forms.TextBox()
        Me.LblLocationY = New System.Windows.Forms.Label()
        Me.lblDestinationY = New System.Windows.Forms.Label()
        Me.txtLocationY = New System.Windows.Forms.TextBox()
        Me.LblDestinationX = New System.Windows.Forms.Label()
        Me.grpSpriteView.SuspendLayout()
        Me.grpAniCtrl.SuspendLayout()
        CType(Me.nbrCel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrLoop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrPower, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMapIcon.SuspendLayout()
        CType(Me.pbMapIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpInventory.SuspendLayout()
        Me.grpUnknown.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nbrStealth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrArmyTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrMoraleTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrMorale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrHitTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrArmyQTY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbrHitPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.grpAddArmy.SuspendLayout()
        Me.grpCharacterPlacement.SuspendLayout()
        Me.SuspendLayout()
        '
        'colNumber
        '
        Me.colNumber.Text = "Number"
        Me.colNumber.Width = 50
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'colQty
        '
        Me.colQty.Text = "QTY"
        Me.colQty.Width = 50
        '
        'colArmy
        '
        Me.colArmy.Text = "Character/Army"
        Me.colArmy.Width = 125
        '
        'grpSpriteView
        '
        Me.grpSpriteView.Controls.Add(Me.pnlAnimate)
        Me.grpSpriteView.Location = New System.Drawing.Point(12, 12)
        Me.grpSpriteView.Name = "grpSpriteView"
        Me.grpSpriteView.Size = New System.Drawing.Size(312, 266)
        Me.grpSpriteView.TabIndex = 7
        Me.grpSpriteView.TabStop = False
        Me.grpSpriteView.Text = "Sprite View"
        '
        'pnlAnimate
        '
        Me.pnlAnimate.Location = New System.Drawing.Point(33, 30)
        Me.pnlAnimate.Name = "pnlAnimate"
        Me.pnlAnimate.Size = New System.Drawing.Size(234, 196)
        Me.pnlAnimate.TabIndex = 4
        '
        'grpAniCtrl
        '
        Me.grpAniCtrl.Controls.Add(Me.cboSpriteColor)
        Me.grpAniCtrl.Controls.Add(Me.lblColorScheme)
        Me.grpAniCtrl.Controls.Add(Me.cboSpriteName)
        Me.grpAniCtrl.Controls.Add(Me.lblSpriteName)
        Me.grpAniCtrl.Controls.Add(Me.nbrCel)
        Me.grpAniCtrl.Controls.Add(Me.nbrLoop)
        Me.grpAniCtrl.Controls.Add(Me.lblLoopFWDSlash)
        Me.grpAniCtrl.Controls.Add(Me.lblCelFWDSlash)
        Me.grpAniCtrl.Controls.Add(Me.btnAnimate)
        Me.grpAniCtrl.Controls.Add(Me.txtFrameTotal)
        Me.grpAniCtrl.Controls.Add(Me.lblCel)
        Me.grpAniCtrl.Controls.Add(Me.lblLoop)
        Me.grpAniCtrl.Controls.Add(Me.txtLoopTotal)
        Me.grpAniCtrl.Location = New System.Drawing.Point(12, 284)
        Me.grpAniCtrl.Name = "grpAniCtrl"
        Me.grpAniCtrl.Size = New System.Drawing.Size(312, 170)
        Me.grpAniCtrl.TabIndex = 0
        Me.grpAniCtrl.TabStop = False
        Me.grpAniCtrl.Text = "Animation Controls"
        '
        'cboSpriteColor
        '
        Me.cboSpriteColor.FormattingEnabled = True
        Me.cboSpriteColor.Location = New System.Drawing.Point(178, 68)
        Me.cboSpriteColor.Name = "cboSpriteColor"
        Me.cboSpriteColor.Size = New System.Drawing.Size(94, 21)
        Me.cboSpriteColor.TabIndex = 9
        '
        'lblColorScheme
        '
        Me.lblColorScheme.AutoSize = True
        Me.lblColorScheme.Location = New System.Drawing.Point(175, 53)
        Me.lblColorScheme.Name = "lblColorScheme"
        Me.lblColorScheme.Size = New System.Drawing.Size(73, 13)
        Me.lblColorScheme.TabIndex = 10
        Me.lblColorScheme.Text = "Color Scheme"
        '
        'cboSpriteName
        '
        Me.cboSpriteName.FormattingEnabled = True
        Me.cboSpriteName.Location = New System.Drawing.Point(29, 68)
        Me.cboSpriteName.Name = "cboSpriteName"
        Me.cboSpriteName.Size = New System.Drawing.Size(128, 21)
        Me.cboSpriteName.TabIndex = 1
        '
        'lblSpriteName
        '
        Me.lblSpriteName.AutoSize = True
        Me.lblSpriteName.Location = New System.Drawing.Point(30, 53)
        Me.lblSpriteName.Name = "lblSpriteName"
        Me.lblSpriteName.Size = New System.Drawing.Size(65, 13)
        Me.lblSpriteName.TabIndex = 12
        Me.lblSpriteName.Text = "Sprite Name"
        '
        'nbrCel
        '
        Me.nbrCel.Location = New System.Drawing.Point(178, 107)
        Me.nbrCel.Name = "nbrCel"
        Me.nbrCel.Size = New System.Drawing.Size(41, 20)
        Me.nbrCel.TabIndex = 4
        Me.nbrCel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'nbrLoop
        '
        Me.nbrLoop.Location = New System.Drawing.Point(28, 107)
        Me.nbrLoop.Name = "nbrLoop"
        Me.nbrLoop.Size = New System.Drawing.Size(41, 20)
        Me.nbrLoop.TabIndex = 3
        Me.nbrLoop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblLoopFWDSlash
        '
        Me.lblLoopFWDSlash.AutoSize = True
        Me.lblLoopFWDSlash.Location = New System.Drawing.Point(82, 109)
        Me.lblLoopFWDSlash.Name = "lblLoopFWDSlash"
        Me.lblLoopFWDSlash.Size = New System.Drawing.Size(12, 13)
        Me.lblLoopFWDSlash.TabIndex = 11
        Me.lblLoopFWDSlash.Text = "/"
        '
        'lblCelFWDSlash
        '
        Me.lblCelFWDSlash.AutoSize = True
        Me.lblCelFWDSlash.Location = New System.Drawing.Point(232, 109)
        Me.lblCelFWDSlash.Name = "lblCelFWDSlash"
        Me.lblCelFWDSlash.Size = New System.Drawing.Size(12, 13)
        Me.lblCelFWDSlash.TabIndex = 10
        Me.lblCelFWDSlash.Text = "/"
        '
        'btnAnimate
        '
        Me.btnAnimate.Location = New System.Drawing.Point(117, 19)
        Me.btnAnimate.Name = "btnAnimate"
        Me.btnAnimate.Size = New System.Drawing.Size(75, 23)
        Me.btnAnimate.TabIndex = 0
        Me.btnAnimate.Text = "Animate"
        Me.btnAnimate.UseVisualStyleBackColor = True
        '
        'txtFrameTotal
        '
        Me.txtFrameTotal.Location = New System.Drawing.Point(249, 106)
        Me.txtFrameTotal.Name = "txtFrameTotal"
        Me.txtFrameTotal.ReadOnly = True
        Me.txtFrameTotal.Size = New System.Drawing.Size(23, 20)
        Me.txtFrameTotal.TabIndex = 8
        Me.txtFrameTotal.TabStop = False
        '
        'lblCel
        '
        Me.lblCel.AutoSize = True
        Me.lblCel.Location = New System.Drawing.Point(175, 92)
        Me.lblCel.Name = "lblCel"
        Me.lblCel.Size = New System.Drawing.Size(22, 13)
        Me.lblCel.TabIndex = 1
        Me.lblCel.Text = "Cel"
        Me.lblCel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLoop
        '
        Me.lblLoop.AutoSize = True
        Me.lblLoop.Location = New System.Drawing.Point(30, 92)
        Me.lblLoop.Name = "lblLoop"
        Me.lblLoop.Size = New System.Drawing.Size(31, 13)
        Me.lblLoop.TabIndex = 2
        Me.lblLoop.Text = "Loop"
        Me.lblLoop.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLoopTotal
        '
        Me.txtLoopTotal.Location = New System.Drawing.Point(99, 106)
        Me.txtLoopTotal.Name = "txtLoopTotal"
        Me.txtLoopTotal.ReadOnly = True
        Me.txtLoopTotal.Size = New System.Drawing.Size(23, 20)
        Me.txtLoopTotal.TabIndex = 6
        Me.txtLoopTotal.TabStop = False
        '
        'nbrPower
        '
        Me.nbrPower.Location = New System.Drawing.Point(317, 19)
        Me.nbrPower.Name = "nbrPower"
        Me.nbrPower.Size = New System.Drawing.Size(50, 20)
        Me.nbrPower.TabIndex = 2
        '
        'lblPower
        '
        Me.lblPower.AutoSize = True
        Me.lblPower.Location = New System.Drawing.Point(273, 21)
        Me.lblPower.Name = "lblPower"
        Me.lblPower.Size = New System.Drawing.Size(37, 13)
        Me.lblPower.TabIndex = 28
        Me.lblPower.Text = "Power"
        '
        'grpMapIcon
        '
        Me.grpMapIcon.Controls.Add(Me.Label1)
        Me.grpMapIcon.Controls.Add(Me.btnChangeBack)
        Me.grpMapIcon.Controls.Add(Me.btnChangeNext)
        Me.grpMapIcon.Controls.Add(Me.pbMapIcon)
        Me.grpMapIcon.Location = New System.Drawing.Point(12, 460)
        Me.grpMapIcon.Name = "grpMapIcon"
        Me.grpMapIcon.Size = New System.Drawing.Size(312, 108)
        Me.grpMapIcon.TabIndex = 1
        Me.grpMapIcon.TabStop = False
        Me.grpMapIcon.Text = "Map Icon"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Use Arrows to Change Icon"
        '
        'btnChangeBack
        '
        Me.btnChangeBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeBack.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeBack.Location = New System.Drawing.Point(73, 30)
        Me.btnChangeBack.Name = "btnChangeBack"
        Me.btnChangeBack.Size = New System.Drawing.Size(24, 24)
        Me.btnChangeBack.TabIndex = 0
        Me.btnChangeBack.Text = "◄"
        Me.btnChangeBack.UseVisualStyleBackColor = True
        '
        'btnChangeNext
        '
        Me.btnChangeNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeNext.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeNext.Location = New System.Drawing.Point(186, 30)
        Me.btnChangeNext.Name = "btnChangeNext"
        Me.btnChangeNext.Size = New System.Drawing.Size(21, 24)
        Me.btnChangeNext.TabIndex = 1
        Me.btnChangeNext.Text = "►"
        Me.btnChangeNext.UseVisualStyleBackColor = True
        '
        'pbMapIcon
        '
        Me.pbMapIcon.BackColor = System.Drawing.SystemColors.ControlDark
        Me.pbMapIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbMapIcon.Location = New System.Drawing.Point(117, 19)
        Me.pbMapIcon.Name = "pbMapIcon"
        Me.pbMapIcon.Size = New System.Drawing.Size(48, 48)
        Me.pbMapIcon.TabIndex = 0
        Me.pbMapIcon.TabStop = False
        '
        'grpInventory
        '
        Me.grpInventory.BackColor = System.Drawing.SystemColors.Control
        Me.grpInventory.Controls.Add(Me.btnAddItems)
        Me.grpInventory.Controls.Add(Me.txtInventory)
        Me.grpInventory.Controls.Add(Me.lstObjectInventory)
        Me.grpInventory.Controls.Add(Me.Label2)
        Me.grpInventory.Location = New System.Drawing.Point(612, 326)
        Me.grpInventory.Name = "grpInventory"
        Me.grpInventory.Size = New System.Drawing.Size(258, 338)
        Me.grpInventory.TabIndex = 6
        Me.grpInventory.TabStop = False
        Me.grpInventory.Text = "Inventory"
        '
        'btnAddItems
        '
        Me.btnAddItems.Location = New System.Drawing.Point(84, 284)
        Me.btnAddItems.Name = "btnAddItems"
        Me.btnAddItems.Size = New System.Drawing.Size(98, 23)
        Me.btnAddItems.TabIndex = 2
        Me.btnAddItems.Text = "Edit Inventory"
        Me.btnAddItems.UseVisualStyleBackColor = True
        '
        'txtInventory
        '
        Me.txtInventory.Location = New System.Drawing.Point(164, 255)
        Me.txtInventory.Name = "txtInventory"
        Me.txtInventory.ReadOnly = True
        Me.txtInventory.Size = New System.Drawing.Size(50, 20)
        Me.txtInventory.TabIndex = 32
        Me.txtInventory.TabStop = False
        '
        'lstObjectInventory
        '
        Me.lstObjectInventory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colValue})
        Me.lstObjectInventory.FullRowSelect = True
        Me.lstObjectInventory.GridLines = True
        Me.lstObjectInventory.Location = New System.Drawing.Point(45, 37)
        Me.lstObjectInventory.Name = "lstObjectInventory"
        Me.lstObjectInventory.Size = New System.Drawing.Size(175, 198)
        Me.lstObjectInventory.TabIndex = 0
        Me.lstObjectInventory.UseCompatibleStateImageBehavior = False
        Me.lstObjectInventory.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        Me.colName.Text = "Item"
        Me.colName.Width = 120
        '
        'colValue
        '
        Me.colValue.Text = "Value"
        Me.colValue.Width = 50
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(77, 258)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Inventory Value"
        '
        'grpUnknown
        '
        Me.grpUnknown.BackColor = System.Drawing.SystemColors.Control
        Me.grpUnknown.Controls.Add(Me.txtByte3)
        Me.grpUnknown.Controls.Add(Me.Label6)
        Me.grpUnknown.Controls.Add(Me.txtByte37)
        Me.grpUnknown.Controls.Add(Me.lblByte37)
        Me.grpUnknown.Controls.Add(Me.txtByte33)
        Me.grpUnknown.Controls.Add(Me.lblByte33)
        Me.grpUnknown.Controls.Add(Me.txtByte32)
        Me.grpUnknown.Controls.Add(Me.lblByte32)
        Me.grpUnknown.Controls.Add(Me.txtByte31)
        Me.grpUnknown.Controls.Add(Me.lblByte31)
        Me.grpUnknown.Controls.Add(Me.txtByte24)
        Me.grpUnknown.Controls.Add(Me.lblByte24)
        Me.grpUnknown.Location = New System.Drawing.Point(12, 574)
        Me.grpUnknown.Name = "grpUnknown"
        Me.grpUnknown.Size = New System.Drawing.Size(586, 90)
        Me.grpUnknown.TabIndex = 8
        Me.grpUnknown.TabStop = False
        Me.grpUnknown.Text = "Unknown Values"
        '
        'txtByte3
        '
        Me.txtByte3.Location = New System.Drawing.Point(72, 25)
        Me.txtByte3.Name = "txtByte3"
        Me.txtByte3.ReadOnly = True
        Me.txtByte3.Size = New System.Drawing.Size(89, 20)
        Me.txtByte3.TabIndex = 0
        Me.txtByte3.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "BYTES 3-4"
        '
        'txtByte37
        '
        Me.txtByte37.Location = New System.Drawing.Point(222, 56)
        Me.txtByte37.Name = "txtByte37"
        Me.txtByte37.ReadOnly = True
        Me.txtByte37.Size = New System.Drawing.Size(50, 20)
        Me.txtByte37.TabIndex = 9
        Me.txtByte37.TabStop = False
        '
        'lblByte37
        '
        Me.lblByte37.AutoSize = True
        Me.lblByte37.Location = New System.Drawing.Point(175, 59)
        Me.lblByte37.Name = "lblByte37"
        Me.lblByte37.Size = New System.Drawing.Size(43, 13)
        Me.lblByte37.TabIndex = 54
        Me.lblByte37.Text = "Byte 37"
        '
        'txtByte33
        '
        Me.txtByte33.Location = New System.Drawing.Point(72, 56)
        Me.txtByte33.Name = "txtByte33"
        Me.txtByte33.ReadOnly = True
        Me.txtByte33.Size = New System.Drawing.Size(50, 20)
        Me.txtByte33.TabIndex = 8
        Me.txtByte33.TabStop = False
        '
        'lblByte33
        '
        Me.lblByte33.AutoSize = True
        Me.lblByte33.Location = New System.Drawing.Point(23, 59)
        Me.lblByte33.Name = "lblByte33"
        Me.lblByte33.Size = New System.Drawing.Size(43, 13)
        Me.lblByte33.TabIndex = 61
        Me.lblByte33.Text = "Byte 33"
        '
        'txtByte32
        '
        Me.txtByte32.Location = New System.Drawing.Point(462, 25)
        Me.txtByte32.Name = "txtByte32"
        Me.txtByte32.ReadOnly = True
        Me.txtByte32.Size = New System.Drawing.Size(50, 20)
        Me.txtByte32.TabIndex = 7
        Me.txtByte32.TabStop = False
        '
        'lblByte32
        '
        Me.lblByte32.AutoSize = True
        Me.lblByte32.Location = New System.Drawing.Point(414, 28)
        Me.lblByte32.Name = "lblByte32"
        Me.lblByte32.Size = New System.Drawing.Size(43, 13)
        Me.lblByte32.TabIndex = 58
        Me.lblByte32.Text = "Byte 32"
        '
        'txtByte31
        '
        Me.txtByte31.Location = New System.Drawing.Point(338, 25)
        Me.txtByte31.Name = "txtByte31"
        Me.txtByte31.ReadOnly = True
        Me.txtByte31.Size = New System.Drawing.Size(50, 20)
        Me.txtByte31.TabIndex = 6
        Me.txtByte31.TabStop = False
        '
        'lblByte31
        '
        Me.lblByte31.AutoSize = True
        Me.lblByte31.Location = New System.Drawing.Point(289, 28)
        Me.lblByte31.Name = "lblByte31"
        Me.lblByte31.Size = New System.Drawing.Size(43, 13)
        Me.lblByte31.TabIndex = 56
        Me.lblByte31.Text = "Byte 31"
        '
        'txtByte24
        '
        Me.txtByte24.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtByte24.Location = New System.Drawing.Point(223, 25)
        Me.txtByte24.Name = "txtByte24"
        Me.txtByte24.ReadOnly = True
        Me.txtByte24.Size = New System.Drawing.Size(50, 20)
        Me.txtByte24.TabIndex = 2
        Me.txtByte24.TabStop = False
        '
        'lblByte24
        '
        Me.lblByte24.AutoSize = True
        Me.lblByte24.Location = New System.Drawing.Point(175, 28)
        Me.lblByte24.Name = "lblByte24"
        Me.lblByte24.Size = New System.Drawing.Size(43, 13)
        Me.lblByte24.TabIndex = 0
        Me.lblByte24.Text = "Byte 24"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.nbrStealth)
        Me.GroupBox1.Controls.Add(Me.nbrPower)
        Me.GroupBox1.Controls.Add(Me.lblQTY)
        Me.GroupBox1.Controls.Add(Me.nbrArmyTotal)
        Me.GroupBox1.Controls.Add(Me.lblPower)
        Me.GroupBox1.Controls.Add(Me.nbrMoraleTotal)
        Me.GroupBox1.Controls.Add(Me.nbrMorale)
        Me.GroupBox1.Controls.Add(Me.nbrHitTotal)
        Me.GroupBox1.Controls.Add(Me.nbrArmyQTY)
        Me.GroupBox1.Controls.Add(Me.lblHPof)
        Me.GroupBox1.Controls.Add(Me.lblStealth)
        Me.GroupBox1.Controls.Add(Me.lblMorale)
        Me.GroupBox1.Controls.Add(Me.lblMoraleof)
        Me.GroupBox1.Controls.Add(Me.lblQtyOf)
        Me.GroupBox1.Controls.Add(Me.lblHitPoints)
        Me.GroupBox1.Controls.Add(Me.nbrHitPoints)
        Me.GroupBox1.Location = New System.Drawing.Point(341, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(529, 108)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Attributes"
        '
        'nbrStealth
        '
        Me.nbrStealth.Location = New System.Drawing.Point(316, 45)
        Me.nbrStealth.Name = "nbrStealth"
        Me.nbrStealth.Size = New System.Drawing.Size(50, 20)
        Me.nbrStealth.TabIndex = 5
        '
        'lblQTY
        '
        Me.lblQTY.AutoSize = True
        Me.lblQTY.Location = New System.Drawing.Point(40, 21)
        Me.lblQTY.Name = "lblQTY"
        Me.lblQTY.Size = New System.Drawing.Size(29, 13)
        Me.lblQTY.TabIndex = 61
        Me.lblQTY.Text = "QTY"
        '
        'nbrArmyTotal
        '
        Me.nbrArmyTotal.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nbrArmyTotal.Location = New System.Drawing.Point(146, 19)
        Me.nbrArmyTotal.Maximum = New Decimal(New Integer() {32000, 0, 0, 0})
        Me.nbrArmyTotal.Name = "nbrArmyTotal"
        Me.nbrArmyTotal.Size = New System.Drawing.Size(50, 20)
        Me.nbrArmyTotal.TabIndex = 1
        Me.nbrArmyTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nbrMoraleTotal
        '
        Me.nbrMoraleTotal.Location = New System.Drawing.Point(148, 71)
        Me.nbrMoraleTotal.Name = "nbrMoraleTotal"
        Me.nbrMoraleTotal.Size = New System.Drawing.Size(50, 20)
        Me.nbrMoraleTotal.TabIndex = 7
        Me.nbrMoraleTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nbrMorale
        '
        Me.nbrMorale.Location = New System.Drawing.Point(71, 71)
        Me.nbrMorale.Name = "nbrMorale"
        Me.nbrMorale.Size = New System.Drawing.Size(50, 20)
        Me.nbrMorale.TabIndex = 6
        Me.nbrMorale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nbrHitTotal
        '
        Me.nbrHitTotal.Location = New System.Drawing.Point(146, 45)
        Me.nbrHitTotal.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nbrHitTotal.Name = "nbrHitTotal"
        Me.nbrHitTotal.Size = New System.Drawing.Size(50, 20)
        Me.nbrHitTotal.TabIndex = 4
        Me.nbrHitTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nbrArmyQTY
        '
        Me.nbrArmyQTY.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nbrArmyQTY.Location = New System.Drawing.Point(73, 19)
        Me.nbrArmyQTY.Maximum = New Decimal(New Integer() {32000, 0, 0, 0})
        Me.nbrArmyQTY.Name = "nbrArmyQTY"
        Me.nbrArmyQTY.Size = New System.Drawing.Size(50, 20)
        Me.nbrArmyQTY.TabIndex = 0
        Me.nbrArmyQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHPof
        '
        Me.lblHPof.AutoSize = True
        Me.lblHPof.Location = New System.Drawing.Point(129, 48)
        Me.lblHPof.Name = "lblHPof"
        Me.lblHPof.Size = New System.Drawing.Size(16, 13)
        Me.lblHPof.TabIndex = 54
        Me.lblHPof.Text = "of"
        '
        'lblStealth
        '
        Me.lblStealth.AutoSize = True
        Me.lblStealth.Location = New System.Drawing.Point(270, 48)
        Me.lblStealth.Name = "lblStealth"
        Me.lblStealth.Size = New System.Drawing.Size(40, 13)
        Me.lblStealth.TabIndex = 54
        Me.lblStealth.Text = "Stealth"
        Me.lblStealth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMorale
        '
        Me.lblMorale.AutoSize = True
        Me.lblMorale.Location = New System.Drawing.Point(26, 73)
        Me.lblMorale.Name = "lblMorale"
        Me.lblMorale.Size = New System.Drawing.Size(39, 13)
        Me.lblMorale.TabIndex = 55
        Me.lblMorale.Text = "Morale"
        '
        'lblMoraleof
        '
        Me.lblMoraleof.AutoSize = True
        Me.lblMoraleof.Location = New System.Drawing.Point(129, 73)
        Me.lblMoraleof.Name = "lblMoraleof"
        Me.lblMoraleof.Size = New System.Drawing.Size(16, 13)
        Me.lblMoraleof.TabIndex = 56
        Me.lblMoraleof.Text = "of"
        '
        'lblQtyOf
        '
        Me.lblQtyOf.AutoSize = True
        Me.lblQtyOf.Location = New System.Drawing.Point(129, 21)
        Me.lblQtyOf.Name = "lblQtyOf"
        Me.lblQtyOf.Size = New System.Drawing.Size(16, 13)
        Me.lblQtyOf.TabIndex = 60
        Me.lblQtyOf.Text = "of"
        '
        'lblHitPoints
        '
        Me.lblHitPoints.AutoSize = True
        Me.lblHitPoints.Location = New System.Drawing.Point(43, 48)
        Me.lblHitPoints.Name = "lblHitPoints"
        Me.lblHitPoints.Size = New System.Drawing.Size(22, 13)
        Me.lblHitPoints.TabIndex = 46
        Me.lblHitPoints.Text = "HP"
        Me.lblHitPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nbrHitPoints
        '
        Me.nbrHitPoints.Location = New System.Drawing.Point(71, 45)
        Me.nbrHitPoints.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nbrHitPoints.Name = "nbrHitPoints"
        Me.nbrHitPoints.Size = New System.Drawing.Size(50, 20)
        Me.nbrHitPoints.TabIndex = 3
        Me.nbrHitPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.cboCharacterFollow)
        Me.GroupBox2.Controls.Add(Me.txtArmyName)
        Me.GroupBox2.Controls.Add(Me.lblCharacterName)
        Me.GroupBox2.Controls.Add(Me.lblFollow)
        Me.GroupBox2.Location = New System.Drawing.Point(341, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(529, 66)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'cboCharacterFollow
        '
        Me.cboCharacterFollow.DropDownHeight = 120
        Me.cboCharacterFollow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCharacterFollow.FormattingEnabled = True
        Me.cboCharacterFollow.IntegralHeight = False
        Me.cboCharacterFollow.Location = New System.Drawing.Point(327, 19)
        Me.cboCharacterFollow.Name = "cboCharacterFollow"
        Me.cboCharacterFollow.Size = New System.Drawing.Size(150, 21)
        Me.cboCharacterFollow.TabIndex = 0
        '
        'txtArmyName
        '
        Me.txtArmyName.Enabled = False
        Me.txtArmyName.Location = New System.Drawing.Point(64, 19)
        Me.txtArmyName.Name = "txtArmyName"
        Me.txtArmyName.ReadOnly = True
        Me.txtArmyName.Size = New System.Drawing.Size(150, 20)
        Me.txtArmyName.TabIndex = 3
        Me.txtArmyName.TabStop = False
        '
        'lblCharacterName
        '
        Me.lblCharacterName.Location = New System.Drawing.Point(13, 18)
        Me.lblCharacterName.Name = "lblCharacterName"
        Me.lblCharacterName.Size = New System.Drawing.Size(45, 20)
        Me.lblCharacterName.TabIndex = 5
        Me.lblCharacterName.Text = "Name"
        Me.lblCharacterName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFollow
        '
        Me.lblFollow.Location = New System.Drawing.Point(231, 16)
        Me.lblFollow.Name = "lblFollow"
        Me.lblFollow.Size = New System.Drawing.Size(90, 20)
        Me.lblFollow.TabIndex = 38
        Me.lblFollow.Text = "Follow Character"
        Me.lblFollow.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'chkVisible
        '
        Me.chkVisible.AutoSize = True
        Me.chkVisible.Location = New System.Drawing.Point(339, 80)
        Me.chkVisible.Name = "chkVisible"
        Me.chkVisible.Size = New System.Drawing.Size(56, 17)
        Me.chkVisible.TabIndex = 46
        Me.chkVisible.Text = "Visible"
        Me.chkVisible.UseVisualStyleBackColor = True
        '
        'lblMobilize
        '
        Me.lblMobilize.AutoSize = True
        Me.lblMobilize.Location = New System.Drawing.Point(22, 81)
        Me.lblMobilize.Name = "lblMobilize"
        Me.lblMobilize.Size = New System.Drawing.Size(51, 13)
        Me.lblMobilize.TabIndex = 45
        Me.lblMobilize.Text = "Mobilized"
        '
        'cboMobilized
        '
        Me.cboMobilized.FormattingEnabled = True
        Me.cboMobilized.Location = New System.Drawing.Point(88, 78)
        Me.cboMobilized.Name = "cboMobilized"
        Me.cboMobilized.Size = New System.Drawing.Size(214, 21)
        Me.cboMobilized.TabIndex = 2
        '
        'grpAddArmy
        '
        Me.grpAddArmy.BackColor = System.Drawing.SystemColors.Control
        Me.grpAddArmy.Controls.Add(Me.lvwCharacterFollow)
        Me.grpAddArmy.Controls.Add(Me.btnAddArmy)
        Me.grpAddArmy.Location = New System.Drawing.Point(341, 326)
        Me.grpAddArmy.Name = "grpAddArmy"
        Me.grpAddArmy.Size = New System.Drawing.Size(257, 242)
        Me.grpAddArmy.TabIndex = 5
        Me.grpAddArmy.TabStop = False
        Me.grpAddArmy.Text = "Character/Armies Commanded"
        '
        'lvwCharacterFollow
        '
        Me.lvwCharacterFollow.FullRowSelect = True
        Me.lvwCharacterFollow.GridLines = True
        Me.lvwCharacterFollow.HideSelection = False
        Me.lvwCharacterFollow.Location = New System.Drawing.Point(18, 36)
        Me.lvwCharacterFollow.MultiSelect = False
        Me.lvwCharacterFollow.Name = "lvwCharacterFollow"
        Me.lvwCharacterFollow.Size = New System.Drawing.Size(230, 163)
        Me.lvwCharacterFollow.TabIndex = 0
        Me.lvwCharacterFollow.UseCompatibleStateImageBehavior = False
        Me.lvwCharacterFollow.View = System.Windows.Forms.View.Details
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
        'grpCharacterPlacement
        '
        Me.grpCharacterPlacement.BackColor = System.Drawing.SystemColors.Control
        Me.grpCharacterPlacement.Controls.Add(Me.chkVisible)
        Me.grpCharacterPlacement.Controls.Add(Me.cboDestination)
        Me.grpCharacterPlacement.Controls.Add(Me.cboLocation)
        Me.grpCharacterPlacement.Controls.Add(Me.lblCityLocationName)
        Me.grpCharacterPlacement.Controls.Add(Me.lblDestinationName)
        Me.grpCharacterPlacement.Controls.Add(Me.txtDestinationY)
        Me.grpCharacterPlacement.Controls.Add(Me.LblLocationX)
        Me.grpCharacterPlacement.Controls.Add(Me.lblMobilize)
        Me.grpCharacterPlacement.Controls.Add(Me.txtLocationX)
        Me.grpCharacterPlacement.Controls.Add(Me.txtDestinationX)
        Me.grpCharacterPlacement.Controls.Add(Me.LblLocationY)
        Me.grpCharacterPlacement.Controls.Add(Me.cboMobilized)
        Me.grpCharacterPlacement.Controls.Add(Me.lblDestinationY)
        Me.grpCharacterPlacement.Controls.Add(Me.txtLocationY)
        Me.grpCharacterPlacement.Controls.Add(Me.LblDestinationX)
        Me.grpCharacterPlacement.Location = New System.Drawing.Point(341, 201)
        Me.grpCharacterPlacement.Name = "grpCharacterPlacement"
        Me.grpCharacterPlacement.Size = New System.Drawing.Size(529, 119)
        Me.grpCharacterPlacement.TabIndex = 4
        Me.grpCharacterPlacement.TabStop = False
        '
        'cboDestination
        '
        Me.cboDestination.DropDownHeight = 130
        Me.cboDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestination.FormattingEnabled = True
        Me.cboDestination.IntegralHeight = False
        Me.cboDestination.Location = New System.Drawing.Point(88, 48)
        Me.cboDestination.MaxDropDownItems = 10
        Me.cboDestination.Name = "cboDestination"
        Me.cboDestination.Size = New System.Drawing.Size(150, 21)
        Me.cboDestination.TabIndex = 1
        '
        'cboLocation
        '
        Me.cboLocation.DropDownHeight = 130
        Me.cboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocation.FormattingEnabled = True
        Me.cboLocation.IntegralHeight = False
        Me.cboLocation.Location = New System.Drawing.Point(88, 20)
        Me.cboLocation.MaxDropDownItems = 10
        Me.cboLocation.Name = "cboLocation"
        Me.cboLocation.Size = New System.Drawing.Size(150, 21)
        Me.cboLocation.TabIndex = 0
        '
        'lblCityLocationName
        '
        Me.lblCityLocationName.Location = New System.Drawing.Point(22, 21)
        Me.lblCityLocationName.Name = "lblCityLocationName"
        Me.lblCityLocationName.Size = New System.Drawing.Size(56, 20)
        Me.lblCityLocationName.TabIndex = 13
        Me.lblCityLocationName.Text = "Location"
        Me.lblCityLocationName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDestinationName
        '
        Me.lblDestinationName.AutoSize = True
        Me.lblDestinationName.Location = New System.Drawing.Point(19, 51)
        Me.lblDestinationName.Name = "lblDestinationName"
        Me.lblDestinationName.Size = New System.Drawing.Size(60, 13)
        Me.lblDestinationName.TabIndex = 21
        Me.lblDestinationName.Text = "Destination"
        Me.lblDestinationName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDestinationY
        '
        Me.txtDestinationY.Location = New System.Drawing.Point(361, 44)
        Me.txtDestinationY.Name = "txtDestinationY"
        Me.txtDestinationY.ReadOnly = True
        Me.txtDestinationY.Size = New System.Drawing.Size(34, 20)
        Me.txtDestinationY.TabIndex = 5
        Me.txtDestinationY.TabStop = False
        Me.txtDestinationY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblLocationX
        '
        Me.LblLocationX.Location = New System.Drawing.Point(268, 19)
        Me.LblLocationX.Name = "LblLocationX"
        Me.LblLocationX.Size = New System.Drawing.Size(20, 20)
        Me.LblLocationX.TabIndex = 4
        Me.LblLocationX.Text = "(X)"
        Me.LblLocationX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLocationX
        '
        Me.txtLocationX.Location = New System.Drawing.Point(289, 21)
        Me.txtLocationX.Name = "txtLocationX"
        Me.txtLocationX.ReadOnly = True
        Me.txtLocationX.Size = New System.Drawing.Size(34, 20)
        Me.txtLocationX.TabIndex = 1
        Me.txtLocationX.TabStop = False
        Me.txtLocationX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDestinationX
        '
        Me.txtDestinationX.Location = New System.Drawing.Point(288, 45)
        Me.txtDestinationX.Name = "txtDestinationX"
        Me.txtDestinationX.ReadOnly = True
        Me.txtDestinationX.Size = New System.Drawing.Size(34, 20)
        Me.txtDestinationX.TabIndex = 4
        Me.txtDestinationX.TabStop = False
        Me.txtDestinationX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblLocationY
        '
        Me.LblLocationY.AutoSize = True
        Me.LblLocationY.Location = New System.Drawing.Point(335, 24)
        Me.LblLocationY.Name = "LblLocationY"
        Me.LblLocationY.Size = New System.Drawing.Size(20, 13)
        Me.LblLocationY.TabIndex = 5
        Me.LblLocationY.Text = "(Y)"
        Me.LblLocationY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDestinationY
        '
        Me.lblDestinationY.Location = New System.Drawing.Point(335, 44)
        Me.lblDestinationY.Name = "lblDestinationY"
        Me.lblDestinationY.Size = New System.Drawing.Size(20, 20)
        Me.lblDestinationY.TabIndex = 9
        Me.lblDestinationY.Text = "(Y)"
        Me.lblDestinationY.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLocationY
        '
        Me.txtLocationY.Location = New System.Drawing.Point(361, 20)
        Me.txtLocationY.Name = "txtLocationY"
        Me.txtLocationY.ReadOnly = True
        Me.txtLocationY.Size = New System.Drawing.Size(34, 20)
        Me.txtLocationY.TabIndex = 2
        Me.txtLocationY.TabStop = False
        Me.txtLocationY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDestinationX
        '
        Me.LblDestinationX.Location = New System.Drawing.Point(266, 44)
        Me.LblDestinationX.Name = "LblDestinationX"
        Me.LblDestinationX.Size = New System.Drawing.Size(20, 20)
        Me.LblDestinationX.TabIndex = 8
        Me.LblDestinationX.Text = "(X)"
        Me.LblDestinationX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmArcView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 686)
        Me.Controls.Add(Me.grpSpriteView)
        Me.Controls.Add(Me.grpAniCtrl)
        Me.Controls.Add(Me.grpMapIcon)
        Me.Controls.Add(Me.grpInventory)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpUnknown)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grpAddArmy)
        Me.Controls.Add(Me.grpCharacterPlacement)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmArcView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "War in Middle Earth - Savegame Character Overview"
        Me.grpSpriteView.ResumeLayout(False)
        Me.grpAniCtrl.ResumeLayout(False)
        Me.grpAniCtrl.PerformLayout()
        CType(Me.nbrCel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrLoop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrPower, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMapIcon.ResumeLayout(False)
        Me.grpMapIcon.PerformLayout()
        CType(Me.pbMapIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpInventory.ResumeLayout(False)
        Me.grpInventory.PerformLayout()
        Me.grpUnknown.ResumeLayout(False)
        Me.grpUnknown.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nbrStealth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrArmyTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrMoraleTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrMorale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrHitTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrArmyQTY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbrHitPoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpAddArmy.ResumeLayout(False)
        Me.grpCharacterPlacement.ResumeLayout(False)
        Me.grpCharacterPlacement.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents colNumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents colQty As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArmy As System.Windows.Forms.ColumnHeader
    Friend WithEvents grpSpriteView As System.Windows.Forms.GroupBox
    Friend WithEvents pnlAnimate As System.Windows.Forms.Panel
    Friend WithEvents grpAniCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents lblColorScheme As System.Windows.Forms.Label
    Friend WithEvents cboSpriteName As System.Windows.Forms.ComboBox
    Friend WithEvents lblSpriteName As System.Windows.Forms.Label
    Friend WithEvents nbrCel As System.Windows.Forms.NumericUpDown
    Friend WithEvents nbrLoop As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblLoopFWDSlash As System.Windows.Forms.Label
    Friend WithEvents lblCelFWDSlash As System.Windows.Forms.Label
    Friend WithEvents btnAnimate As System.Windows.Forms.Button
    Friend WithEvents txtFrameTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblCel As System.Windows.Forms.Label
    Friend WithEvents lblLoop As System.Windows.Forms.Label
    Friend WithEvents txtLoopTotal As System.Windows.Forms.TextBox
    Friend WithEvents grpMapIcon As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnChangeBack As System.Windows.Forms.Button
    Friend WithEvents btnChangeNext As System.Windows.Forms.Button
    Friend WithEvents pbMapIcon As System.Windows.Forms.PictureBox
    Friend WithEvents grpInventory As System.Windows.Forms.GroupBox
    Friend WithEvents grpUnknown As System.Windows.Forms.GroupBox
    Friend WithEvents txtByte3 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtByte37 As System.Windows.Forms.TextBox
    Friend WithEvents lblByte37 As System.Windows.Forms.Label
    Friend WithEvents txtByte33 As System.Windows.Forms.TextBox
    Friend WithEvents lblByte33 As System.Windows.Forms.Label
    Friend WithEvents txtByte32 As System.Windows.Forms.TextBox
    Friend WithEvents lblByte32 As System.Windows.Forms.Label
    Friend WithEvents txtByte31 As System.Windows.Forms.TextBox
    Friend WithEvents lblByte31 As System.Windows.Forms.Label
    Friend WithEvents txtByte24 As System.Windows.Forms.TextBox
    Friend WithEvents lblByte24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents nbrMoraleTotal As System.Windows.Forms.NumericUpDown
    Friend WithEvents nbrMorale As System.Windows.Forms.NumericUpDown
    Friend WithEvents nbrHitTotal As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblHPof As System.Windows.Forms.Label
    Friend WithEvents lblMorale As System.Windows.Forms.Label
    Friend WithEvents lblMoraleof As System.Windows.Forms.Label
    Friend WithEvents lblHitPoints As System.Windows.Forms.Label
    Friend WithEvents nbrHitPoints As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents nbrArmyTotal As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkVisible As System.Windows.Forms.CheckBox
    Friend WithEvents cboCharacterFollow As System.Windows.Forms.ComboBox
    Friend WithEvents nbrArmyQTY As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtArmyName As System.Windows.Forms.TextBox
    Friend WithEvents lblCharacterName As System.Windows.Forms.Label
    Friend WithEvents lblMobilize As System.Windows.Forms.Label
    Friend WithEvents lblFollow As System.Windows.Forms.Label
    Friend WithEvents lblQtyOf As System.Windows.Forms.Label
    Friend WithEvents cboMobilized As System.Windows.Forms.ComboBox
    Friend WithEvents grpAddArmy As System.Windows.Forms.GroupBox
    Friend WithEvents lvwCharacterFollow As System.Windows.Forms.ListView
    Friend WithEvents btnAddArmy As System.Windows.Forms.Button
    Friend WithEvents grpCharacterPlacement As System.Windows.Forms.GroupBox
    Friend WithEvents cboDestination As System.Windows.Forms.ComboBox
    Friend WithEvents cboLocation As System.Windows.Forms.ComboBox
    Friend WithEvents lblCityLocationName As System.Windows.Forms.Label
    Friend WithEvents lblDestinationName As System.Windows.Forms.Label
    Friend WithEvents txtDestinationY As System.Windows.Forms.TextBox
    Friend WithEvents LblLocationX As System.Windows.Forms.Label
    Friend WithEvents txtLocationX As System.Windows.Forms.TextBox
    Friend WithEvents txtDestinationX As System.Windows.Forms.TextBox
    Friend WithEvents LblLocationY As System.Windows.Forms.Label
    Friend WithEvents lblDestinationY As System.Windows.Forms.Label
    Friend WithEvents txtLocationY As System.Windows.Forms.TextBox
    Friend WithEvents LblDestinationX As System.Windows.Forms.Label
    Friend WithEvents nbrPower As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPower As System.Windows.Forms.Label
    Friend WithEvents nbrStealth As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblQTY As System.Windows.Forms.Label
    Friend WithEvents lblStealth As System.Windows.Forms.Label
    Friend WithEvents lstObjectInventory As System.Windows.Forms.ListView
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtInventory As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAddItems As System.Windows.Forms.Button
    Friend WithEvents cboSpriteColor As System.Windows.Forms.ComboBox
End Class

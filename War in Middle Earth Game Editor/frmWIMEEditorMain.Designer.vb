<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWIMEEditorMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWIMEEditorMain))
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuToolbarView = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuStatusBarView = New System.Windows.Forms.ToolStripMenuItem()
        Me.menWIMESaveGameEditor = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSaveFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCloseFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCloseGame = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuProgramOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExitProgram = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveGameOverview = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyProtectionCodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTitleWindow = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutTheWIMESavegameEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.imgSystemIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.colQty = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imgIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.colArmy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.stpOpenFile = New System.Windows.Forms.ToolStripButton()
        Me.stpSaveFile = New System.Windows.Forms.ToolStripButton()
        Me.stpProgramSettings = New System.Windows.Forms.ToolStripButton()
        Me.toolbarStrip = New System.Windows.Forms.ToolStrip()
        Me.stpCopyProtection = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ExitStripItem = New System.Windows.Forms.ToolStripButton()
        Me.pnlEditor = New System.Windows.Forms.Panel()
        Me.menWIMESaveGameEditor.SuspendLayout()
        Me.toolbarStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuToolbarView, Me.menuStatusBarView})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        Me.ViewToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ViewToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'menuToolbarView
        '
        Me.menuToolbarView.Checked = True
        Me.menuToolbarView.CheckOnClick = True
        Me.menuToolbarView.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuToolbarView.Name = "menuToolbarView"
        Me.menuToolbarView.Size = New System.Drawing.Size(126, 22)
        Me.menuToolbarView.Text = "Toolbar"
        '
        'menuStatusBarView
        '
        Me.menuStatusBarView.Checked = True
        Me.menuStatusBarView.CheckOnClick = True
        Me.menuStatusBarView.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuStatusBarView.Name = "menuStatusBarView"
        Me.menuStatusBarView.Size = New System.Drawing.Size(126, 22)
        Me.menuStatusBarView.Text = "Status Bar"
        '
        'menWIMESaveGameEditor
        '
        Me.menWIMESaveGameEditor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.ViewToolStripMenuItem, Me.ToolsMenu, Me.mnuTitleWindow, Me.HelpToolStripMenuItem})
        Me.menWIMESaveGameEditor.Location = New System.Drawing.Point(0, 0)
        Me.menWIMESaveGameEditor.Name = "menWIMESaveGameEditor"
        Me.menWIMESaveGameEditor.Size = New System.Drawing.Size(1008, 24)
        Me.menWIMESaveGameEditor.TabIndex = 0
        Me.menWIMESaveGameEditor.Text = "MenuStrip1"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOpenFile, Me.mnuSaveFile, Me.mnuCloseFile, Me.mnuCloseGame, Me.ToolStripSeparator3, Me.mnuProgramOptions, Me.mnuExitProgram})
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(37, 20)
        Me.FileMenu.Text = "&File"
        '
        'mnuOpenFile
        '
        Me.mnuOpenFile.Image = Global.WIMEEditor.My.Resources.Resources.Open3232
        Me.mnuOpenFile.Name = "mnuOpenFile"
        Me.mnuOpenFile.Size = New System.Drawing.Size(171, 22)
        Me.mnuOpenFile.Text = "Open WIME Game"
        '
        'mnuSaveFile
        '
        Me.mnuSaveFile.Image = Global.WIMEEditor.My.Resources.Resources.Floppy_disk3232
        Me.mnuSaveFile.Name = "mnuSaveFile"
        Me.mnuSaveFile.Size = New System.Drawing.Size(171, 22)
        Me.mnuSaveFile.Text = "&Save"
        '
        'mnuCloseFile
        '
        Me.mnuCloseFile.Name = "mnuCloseFile"
        Me.mnuCloseFile.Size = New System.Drawing.Size(171, 22)
        Me.mnuCloseFile.Text = "&Close"
        '
        'mnuCloseGame
        '
        Me.mnuCloseGame.Name = "mnuCloseGame"
        Me.mnuCloseGame.Size = New System.Drawing.Size(171, 22)
        Me.mnuCloseGame.Text = "Close WIME Game"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(168, 6)
        '
        'mnuProgramOptions
        '
        Me.mnuProgramOptions.Image = Global.WIMEEditor.My.Resources.Resources.Settings3232
        Me.mnuProgramOptions.Name = "mnuProgramOptions"
        Me.mnuProgramOptions.Size = New System.Drawing.Size(171, 22)
        Me.mnuProgramOptions.Text = "Program &Options"
        '
        'mnuExitProgram
        '
        Me.mnuExitProgram.Image = Global.WIMEEditor.My.Resources.Resources._exit
        Me.mnuExitProgram.Name = "mnuExitProgram"
        Me.mnuExitProgram.Size = New System.Drawing.Size(171, 22)
        Me.mnuExitProgram.Text = "E&xit"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.SaveGameOverview, Me.CopyProtectionCodesToolStripMenuItem})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(47, 20)
        Me.ToolsMenu.Text = "&Tools"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(208, 6)
        '
        'SaveGameOverview
        '
        Me.SaveGameOverview.Name = "SaveGameOverview"
        Me.SaveGameOverview.Size = New System.Drawing.Size(211, 22)
        Me.SaveGameOverview.Text = "Save Game Data Overview"
        '
        'CopyProtectionCodesToolStripMenuItem
        '
        Me.CopyProtectionCodesToolStripMenuItem.Image = Global.WIMEEditor.My.Resources.Resources.menucopyproticon
        Me.CopyProtectionCodesToolStripMenuItem.Name = "CopyProtectionCodesToolStripMenuItem"
        Me.CopyProtectionCodesToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.CopyProtectionCodesToolStripMenuItem.Text = "Copy Protection Codes"
        '
        'mnuTitleWindow
        '
        Me.mnuTitleWindow.Name = "mnuTitleWindow"
        Me.mnuTitleWindow.Size = New System.Drawing.Size(63, 20)
        Me.mnuTitleWindow.Text = "Window"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutTheWIMESavegameEditorToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutTheWIMESavegameEditorToolStripMenuItem
        '
        Me.AboutTheWIMESavegameEditorToolStripMenuItem.Name = "AboutTheWIMESavegameEditorToolStripMenuItem"
        Me.AboutTheWIMESavegameEditorToolStripMenuItem.Size = New System.Drawing.Size(252, 22)
        Me.AboutTheWIMESavegameEditorToolStripMenuItem.Text = "About the WIME Savegame Editor"
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'imgSystemIcons
        '
        Me.imgSystemIcons.ImageStream = CType(resources.GetObject("imgSystemIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgSystemIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.imgSystemIcons.Images.SetKeyName(0, "Floppy disk3232.png")
        Me.imgSystemIcons.Images.SetKeyName(1, "Open3232.png")
        Me.imgSystemIcons.Images.SetKeyName(2, "Settings3232.png")
        Me.imgSystemIcons.Images.SetKeyName(3, "apple2icon32.png")
        Me.imgSystemIcons.Images.SetKeyName(4, "msdosicon.png")
        '
        'colQty
        '
        Me.colQty.Text = "QTY"
        Me.colQty.Width = 50
        '
        'imgIcons
        '
        Me.imgIcons.ImageStream = CType(resources.GetObject("imgIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIcons.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIcons.Images.SetKeyName(0, "Floppy disk3232.png")
        Me.imgIcons.Images.SetKeyName(1, "Open3232.png")
        Me.imgIcons.Images.SetKeyName(2, "Settings3232.png")
        '
        'colArmy
        '
        Me.colArmy.Text = "Character/Army"
        Me.colArmy.Width = 125
        '
        'stpOpenFile
        '
        Me.stpOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.stpOpenFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stpOpenFile.Image = Global.WIMEEditor.My.Resources.Resources.Open3232
        Me.stpOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.stpOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.stpOpenFile.Name = "stpOpenFile"
        Me.stpOpenFile.Size = New System.Drawing.Size(36, 36)
        Me.stpOpenFile.Text = "Open"
        Me.stpOpenFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.stpOpenFile.ToolTipText = "Open Game"
        '
        'stpSaveFile
        '
        Me.stpSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.stpSaveFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stpSaveFile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.stpSaveFile.Image = Global.WIMEEditor.My.Resources.Resources.Floppy_disk3232
        Me.stpSaveFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.stpSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.stpSaveFile.Name = "stpSaveFile"
        Me.stpSaveFile.Size = New System.Drawing.Size(36, 36)
        Me.stpSaveFile.Text = "Save"
        Me.stpSaveFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'stpProgramSettings
        '
        Me.stpProgramSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.stpProgramSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stpProgramSettings.Image = Global.WIMEEditor.My.Resources.Resources.Settings3232
        Me.stpProgramSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.stpProgramSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.stpProgramSettings.Name = "stpProgramSettings"
        Me.stpProgramSettings.Size = New System.Drawing.Size(36, 36)
        Me.stpProgramSettings.Text = "Settings"
        Me.stpProgramSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'toolbarStrip
        '
        Me.toolbarStrip.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.toolbarStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolbarStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.toolbarStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stpOpenFile, Me.stpSaveFile, Me.stpCopyProtection, Me.stpProgramSettings, Me.ToolStripButton1})
        Me.toolbarStrip.Location = New System.Drawing.Point(0, 24)
        Me.toolbarStrip.Name = "toolbarStrip"
        Me.toolbarStrip.Size = New System.Drawing.Size(1008, 39)
        Me.toolbarStrip.TabIndex = 3
        Me.toolbarStrip.Text = "ToolStrip2"
        '
        'stpCopyProtection
        '
        Me.stpCopyProtection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.stpCopyProtection.Image = Global.WIMEEditor.My.Resources.Resources.menucopyproticon
        Me.stpCopyProtection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.stpCopyProtection.Name = "stpCopyProtection"
        Me.stpCopyProtection.Size = New System.Drawing.Size(36, 36)
        Me.stpCopyProtection.Text = "Copy Protection Codes"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.WIMEEditor.My.Resources.Resources._exit
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton1.Text = "Exit Program"
        '
        'ExitStripItem
        '
        Me.ExitStripItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExitStripItem.Image = Global.WIMEEditor.My.Resources.Resources._exit
        Me.ExitStripItem.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.ExitStripItem.Name = "ExitStripItem"
        Me.ExitStripItem.Size = New System.Drawing.Size(36, 36)
        Me.ExitStripItem.Text = "Exit Program"
        Me.ExitStripItem.ToolTipText = "Exit Editor"
        '
        'pnlEditor
        '
        Me.pnlEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.pnlEditor.BackgroundImage = Global.WIMEEditor.My.Resources.Resources.oldmapbg
        Me.pnlEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEditor.Location = New System.Drawing.Point(0, 63)
        Me.pnlEditor.Name = "pnlEditor"
        Me.pnlEditor.Size = New System.Drawing.Size(1008, 667)
        Me.pnlEditor.TabIndex = 10
        '
        'frmWIMEEditorMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.pnlEditor)
        Me.Controls.Add(Me.toolbarStrip)
        Me.Controls.Add(Me.menWIMESaveGameEditor)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmWIMEEditorMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WAR IN MIDDLE EARTH GAME EDITOR"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.menWIMESaveGameEditor.ResumeLayout(False)
        Me.menWIMESaveGameEditor.PerformLayout()
        Me.toolbarStrip.ResumeLayout(False)
        Me.toolbarStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuToolbarView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuStatusBarView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menWIMESaveGameEditor As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSaveFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCloseFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCloseGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuProgramOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExitProgram As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveGameOverview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyProtectionCodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTitleWindow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutTheWIMESavegameEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents imgSystemIcons As System.Windows.Forms.ImageList
    Friend WithEvents colQty As System.Windows.Forms.ColumnHeader
    Friend WithEvents imgIcons As System.Windows.Forms.ImageList
    Friend WithEvents colArmy As System.Windows.Forms.ColumnHeader
    Friend WithEvents stpOpenFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents stpSaveFile As System.Windows.Forms.ToolStripButton
    Friend WithEvents stpProgramSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolbarStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents pnlEditor As System.Windows.Forms.Panel
    Friend WithEvents stpCopyProtection As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExitStripItem As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
End Class

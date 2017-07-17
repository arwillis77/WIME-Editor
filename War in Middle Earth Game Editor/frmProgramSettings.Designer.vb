<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramSettings))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtWIMEFolder = New System.Windows.Forms.TextBox()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtApplicationDirectory = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnWIMEDirectory = New System.Windows.Forms.Button()
        Me.btnBackgroundDir = New System.Windows.Forms.Button()
        Me.txtBackgroundImage = New System.Windows.Forms.TextBox()
        Me.lblBackgroundDirectory = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "War in Middle Earth Game Folder"
        '
        'txtWIMEFolder
        '
        Me.txtWIMEFolder.Location = New System.Drawing.Point(9, 84)
        Me.txtWIMEFolder.Name = "txtWIMEFolder"
        Me.txtWIMEFolder.Size = New System.Drawing.Size(408, 20)
        Me.txtWIMEFolder.TabIndex = 1
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(611, 195)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 4
        Me.btnConfirm.Text = "Ok"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Data Folder"
        '
        'txtApplicationDirectory
        '
        Me.txtApplicationDirectory.Location = New System.Drawing.Point(9, 43)
        Me.txtApplicationDirectory.Name = "txtApplicationDirectory"
        Me.txtApplicationDirectory.Size = New System.Drawing.Size(408, 20)
        Me.txtApplicationDirectory.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblBackgroundDirectory)
        Me.GroupBox2.Controls.Add(Me.btnBackgroundDir)
        Me.GroupBox2.Controls.Add(Me.txtBackgroundImage)
        Me.GroupBox2.Controls.Add(Me.btnWIMEDirectory)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtApplicationDirectory)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtWIMEFolder)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(674, 164)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Editor Folders"
        '
        'btnWIMEDirectory
        '
        Me.btnWIMEDirectory.Image = CType(resources.GetObject("btnWIMEDirectory.Image"), System.Drawing.Image)
        Me.btnWIMEDirectory.Location = New System.Drawing.Point(423, 83)
        Me.btnWIMEDirectory.Name = "btnWIMEDirectory"
        Me.btnWIMEDirectory.Size = New System.Drawing.Size(20, 20)
        Me.btnWIMEDirectory.TabIndex = 11
        Me.btnWIMEDirectory.UseVisualStyleBackColor = True
        '
        'btnBackgroundDir
        '
        Me.btnBackgroundDir.Image = CType(resources.GetObject("btnBackgroundDir.Image"), System.Drawing.Image)
        Me.btnBackgroundDir.Location = New System.Drawing.Point(423, 122)
        Me.btnBackgroundDir.Name = "btnBackgroundDir"
        Me.btnBackgroundDir.Size = New System.Drawing.Size(20, 20)
        Me.btnBackgroundDir.TabIndex = 13
        Me.btnBackgroundDir.UseVisualStyleBackColor = True
        '
        'txtBackgroundImage
        '
        Me.txtBackgroundImage.Location = New System.Drawing.Point(9, 123)
        Me.txtBackgroundImage.Name = "txtBackgroundImage"
        Me.txtBackgroundImage.Size = New System.Drawing.Size(408, 20)
        Me.txtBackgroundImage.TabIndex = 12
        '
        'lblBackgroundDirectory
        '
        Me.lblBackgroundDirectory.AutoSize = True
        Me.lblBackgroundDirectory.Location = New System.Drawing.Point(6, 107)
        Me.lblBackgroundDirectory.Name = "lblBackgroundDirectory"
        Me.lblBackgroundDirectory.Size = New System.Drawing.Size(152, 13)
        Me.lblBackgroundDirectory.TabIndex = 14
        Me.lblBackgroundDirectory.Text = "Application Background Image"
        '
        'frmProgramSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 234)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnConfirm)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProgramSettings"
        Me.Text = "War in Middle Earth Editor Program Settings"
        Me.TopMost = True
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtWIMEFolder As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtApplicationDirectory As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnWIMEDirectory As System.Windows.Forms.Button
    Friend WithEvents lblBackgroundDirectory As System.Windows.Forms.Label
    Friend WithEvents btnBackgroundDir As System.Windows.Forms.Button
    Friend WithEvents txtBackgroundImage As System.Windows.Forms.TextBox
End Class

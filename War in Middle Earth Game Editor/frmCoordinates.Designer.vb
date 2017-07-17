<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCoordinates
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
        Me.lstCoordinates = New System.Windows.Forms.ListView()
        Me.colCity = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lstCoordinates
        '
        Me.lstCoordinates.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lstCoordinates.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCity, Me.colValue})
        Me.lstCoordinates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstCoordinates.ForeColor = System.Drawing.Color.White
        Me.lstCoordinates.FullRowSelect = True
        Me.lstCoordinates.GridLines = True
        Me.lstCoordinates.HideSelection = False
        Me.lstCoordinates.Location = New System.Drawing.Point(0, 0)
        Me.lstCoordinates.Name = "lstCoordinates"
        Me.lstCoordinates.Size = New System.Drawing.Size(250, 967)
        Me.lstCoordinates.TabIndex = 0
        Me.lstCoordinates.UseCompatibleStateImageBehavior = False
        Me.lstCoordinates.View = System.Windows.Forms.View.Details
        '
        'colCity
        '
        Me.colCity.Text = "CITY/LOCATION"
        Me.colCity.Width = 140
        '
        'colValue
        '
        Me.colValue.Text = "Map Coordinate"
        Me.colValue.Width = 90
        '
        'frmCoordinates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(250, 967)
        Me.Controls.Add(Me.lstCoordinates)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCoordinates"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Copy Protection Codes"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstCoordinates As System.Windows.Forms.ListView
    Friend WithEvents colCity As System.Windows.Forms.ColumnHeader
    Friend WithEvents colValue As System.Windows.Forms.ColumnHeader
End Class

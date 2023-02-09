<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crlSSV
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pgbSSV = New System.Windows.Forms.ProgressBar()
        Me.lblProzSSV = New System.Windows.Forms.Label()
        Me.lblProgIST = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pgbSSV
        '
        Me.pgbSSV.Location = New System.Drawing.Point(3, 15)
        Me.pgbSSV.Name = "pgbSSV"
        Me.pgbSSV.Size = New System.Drawing.Size(182, 21)
        Me.pgbSSV.TabIndex = 0
        '
        'lblProzSSV
        '
        Me.lblProzSSV.BackColor = System.Drawing.SystemColors.Control
        Me.lblProzSSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProzSSV.Location = New System.Drawing.Point(80, 17)
        Me.lblProzSSV.Name = "lblProzSSV"
        Me.lblProzSSV.Size = New System.Drawing.Size(28, 16)
        Me.lblProzSSV.TabIndex = 1
        Me.lblProzSSV.Text = "%"
        Me.lblProzSSV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProgIST
        '
        Me.lblProgIST.BackColor = System.Drawing.SystemColors.Window
        Me.lblProgIST.Location = New System.Drawing.Point(0, 0)
        Me.lblProgIST.Name = "lblProgIST"
        Me.lblProgIST.Size = New System.Drawing.Size(128, 12)
        Me.lblProgIST.TabIndex = 2
        Me.lblProgIST.Text = "Fortschritt Kundensicht"
        Me.lblProgIST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'crlSSV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblProgIST)
        Me.Controls.Add(Me.lblProzSSV)
        Me.Controls.Add(Me.pgbSSV)
        Me.Name = "crlSSV"
        Me.Size = New System.Drawing.Size(188, 39)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pgbSSV As Windows.Forms.ProgressBar
    Friend WithEvents lblProzSSV As Windows.Forms.Label
    Friend WithEvents lblProgIST As Windows.Forms.Label
End Class

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
        Me.lblProzA = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pgbSSV
        '
        Me.pgbSSV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgbSSV.Location = New System.Drawing.Point(0, 0)
        Me.pgbSSV.Name = "pgbSSV"
        Me.pgbSSV.Size = New System.Drawing.Size(215, 27)
        Me.pgbSSV.TabIndex = 0
        '
        'lblProzA
        '
        Me.lblProzA.BackColor = System.Drawing.SystemColors.Control
        Me.lblProzA.Location = New System.Drawing.Point(101, 6)
        Me.lblProzA.Name = "lblProzA"
        Me.lblProzA.Size = New System.Drawing.Size(14, 14)
        Me.lblProzA.TabIndex = 1
        Me.lblProzA.Text = "%"
        Me.lblProzA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'crlSSV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblProzA)
        Me.Controls.Add(Me.pgbSSV)
        Me.Name = "crlSSV"
        Me.Size = New System.Drawing.Size(215, 27)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pgbSSV As Windows.Forms.ProgressBar
    Friend WithEvents lblProzA As Windows.Forms.Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class crlADR
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlBoSL = New System.Windows.Forms.Panel()
        Me.pnlBoGrid = New System.Windows.Forms.Panel()
        Me.btnAddA = New System.Windows.Forms.Button()
        Me.btnAddSR = New System.Windows.Forms.Button()
        Me.btnDeleteObj = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.pgbADR = New System.Windows.Forms.ProgressBar()
        Me.lblFortschritt = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblProzADR = New System.Windows.Forms.Label()
        Me.ContMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NeuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AktualisierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBoSL
        '
        Me.pnlBoSL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlBoSL.BackColor = System.Drawing.SystemColors.Control
        Me.pnlBoSL.Location = New System.Drawing.Point(5, 33)
        Me.pnlBoSL.Name = "pnlBoSL"
        Me.pnlBoSL.Size = New System.Drawing.Size(280, 541)
        Me.pnlBoSL.TabIndex = 0
        '
        'pnlBoGrid
        '
        Me.pnlBoGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBoGrid.BackColor = System.Drawing.SystemColors.Control
        Me.pnlBoGrid.Location = New System.Drawing.Point(291, 33)
        Me.pnlBoGrid.Name = "pnlBoGrid"
        Me.pnlBoGrid.Size = New System.Drawing.Size(680, 485)
        Me.pnlBoGrid.TabIndex = 1
        '
        'btnAddA
        '
        Me.btnAddA.Location = New System.Drawing.Point(3, 4)
        Me.btnAddA.Name = "btnAddA"
        Me.btnAddA.Size = New System.Drawing.Size(24, 23)
        Me.btnAddA.TabIndex = 2
        Me.btnAddA.UseVisualStyleBackColor = True
        '
        'btnAddSR
        '
        Me.btnAddSR.Location = New System.Drawing.Point(33, 4)
        Me.btnAddSR.Name = "btnAddSR"
        Me.btnAddSR.Size = New System.Drawing.Size(24, 23)
        Me.btnAddSR.TabIndex = 3
        Me.btnAddSR.UseVisualStyleBackColor = True
        '
        'btnDeleteObj
        '
        Me.btnDeleteObj.Location = New System.Drawing.Point(63, 4)
        Me.btnDeleteObj.Name = "btnDeleteObj"
        Me.btnDeleteObj.Size = New System.Drawing.Size(24, 23)
        Me.btnDeleteObj.TabIndex = 4
        Me.btnDeleteObj.UseVisualStyleBackColor = True
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(123, 4)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(24, 23)
        Me.btnSettings.TabIndex = 5
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'pgbADR
        '
        Me.pgbADR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pgbADR.Location = New System.Drawing.Point(291, 542)
        Me.pgbADR.Name = "pgbADR"
        Me.pgbADR.Size = New System.Drawing.Size(400, 32)
        Me.pgbADR.TabIndex = 7
        '
        'lblFortschritt
        '
        Me.lblFortschritt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFortschritt.AutoSize = True
        Me.lblFortschritt.Location = New System.Drawing.Point(288, 526)
        Me.lblFortschritt.Name = "lblFortschritt"
        Me.lblFortschritt.Size = New System.Drawing.Size(56, 13)
        Me.lblFortschritt.TabIndex = 8
        Me.lblFortschritt.Text = "Fortschritt:"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(93, 4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(24, 23)
        Me.btnRefresh.TabIndex = 9
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'lblProzADR
        '
        Me.lblProzADR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblProzADR.AutoSize = True
        Me.lblProzADR.Location = New System.Drawing.Point(350, 526)
        Me.lblProzADR.Name = "lblProzADR"
        Me.lblProzADR.Size = New System.Drawing.Size(15, 13)
        Me.lblProzADR.TabIndex = 0
        Me.lblProzADR.Text = "%"
        '
        'ContMenu
        '
        Me.ContMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeuToolStripMenuItem, Me.BearbeitenToolStripMenuItem, Me.LöschenToolStripMenuItem, Me.AktualisierenToolStripMenuItem})
        Me.ContMenu.Name = "ContMenu"
        Me.ContMenu.Size = New System.Drawing.Size(167, 92)
        '
        'NeuToolStripMenuItem
        '
        Me.NeuToolStripMenuItem.Name = "NeuToolStripMenuItem"
        Me.NeuToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.NeuToolStripMenuItem.Text = "Beleg hinzufügen"
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.BearbeitenToolStripMenuItem.Text = "SR-Hinzufügen"
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        Me.LöschenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.LöschenToolStripMenuItem.Text = "Entfernen"
        '
        'AktualisierenToolStripMenuItem
        '
        Me.AktualisierenToolStripMenuItem.Name = "AktualisierenToolStripMenuItem"
        Me.AktualisierenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AktualisierenToolStripMenuItem.Text = "Aktualisieren"
        '
        'crlADR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.lblProzADR)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lblFortschritt)
        Me.Controls.Add(Me.pgbADR)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnDeleteObj)
        Me.Controls.Add(Me.btnAddSR)
        Me.Controls.Add(Me.btnAddA)
        Me.Controls.Add(Me.pnlBoGrid)
        Me.Controls.Add(Me.pnlBoSL)
        Me.Name = "crlADR"
        Me.Size = New System.Drawing.Size(981, 582)
        Me.ContMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlBoSL As Windows.Forms.Panel
    Friend WithEvents pnlBoGrid As Windows.Forms.Panel
    Friend WithEvents btnAddA As Windows.Forms.Button
    Friend WithEvents btnAddSR As Windows.Forms.Button
    Friend WithEvents btnDeleteObj As Windows.Forms.Button
    Friend WithEvents btnSettings As Windows.Forms.Button
    Friend WithEvents pgbADR As Windows.Forms.ProgressBar
    Friend WithEvents lblFortschritt As Windows.Forms.Label
    Friend WithEvents btnRefresh As Windows.Forms.Button
    Friend WithEvents lblProzADR As Windows.Forms.Label
    Friend WithEvents ContMenu As Windows.Forms.ContextMenuStrip
    Friend WithEvents NeuToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents LöschenToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents AktualisierenToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class

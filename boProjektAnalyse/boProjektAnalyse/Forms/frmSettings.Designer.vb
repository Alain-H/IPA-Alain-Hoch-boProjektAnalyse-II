<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.gbProzuWahl = New System.Windows.Forms.GroupBox()
        Me.rb90 = New System.Windows.Forms.RadioButton()
        Me.rb80 = New System.Windows.Forms.RadioButton()
        Me.rb70 = New System.Windows.Forms.RadioButton()
        Me.rb60 = New System.Windows.Forms.RadioButton()
        Me.pnlHead = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PicHead = New System.Windows.Forms.PictureBox()
        Me.lblTitelHead = New System.Windows.Forms.Label()
        Me.lblTitelBody = New System.Windows.Forms.Label()
        Me.lblBodyText = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnAbbruch = New System.Windows.Forms.Button()
        Me.gbProzuWahl.SuspendLayout()
        Me.pnlHead.SuspendLayout()
        CType(Me.PicHead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbProzuWahl
        '
        Me.gbProzuWahl.Controls.Add(Me.rb90)
        Me.gbProzuWahl.Controls.Add(Me.rb80)
        Me.gbProzuWahl.Controls.Add(Me.rb70)
        Me.gbProzuWahl.Controls.Add(Me.rb60)
        Me.gbProzuWahl.Location = New System.Drawing.Point(75, 131)
        Me.gbProzuWahl.Name = "gbProzuWahl"
        Me.gbProzuWahl.Size = New System.Drawing.Size(101, 121)
        Me.gbProzuWahl.TabIndex = 5
        Me.gbProzuWahl.TabStop = False
        '
        'rb90
        '
        Me.rb90.AutoSize = True
        Me.rb90.Location = New System.Drawing.Point(6, 87)
        Me.rb90.Name = "rb90"
        Me.rb90.Size = New System.Drawing.Size(60, 17)
        Me.rb90.TabIndex = 3
        Me.rb90.TabStop = True
        Me.rb90.Text = ">= 90%"
        Me.rb90.UseVisualStyleBackColor = True
        '
        'rb80
        '
        Me.rb80.AutoSize = True
        Me.rb80.Location = New System.Drawing.Point(6, 64)
        Me.rb80.Name = "rb80"
        Me.rb80.Size = New System.Drawing.Size(60, 17)
        Me.rb80.TabIndex = 2
        Me.rb80.TabStop = True
        Me.rb80.Text = ">= 80%"
        Me.rb80.UseVisualStyleBackColor = True
        '
        'rb70
        '
        Me.rb70.AutoSize = True
        Me.rb70.Location = New System.Drawing.Point(6, 41)
        Me.rb70.Name = "rb70"
        Me.rb70.Size = New System.Drawing.Size(60, 17)
        Me.rb70.TabIndex = 1
        Me.rb70.TabStop = True
        Me.rb70.Text = ">= 70%"
        Me.rb70.UseVisualStyleBackColor = True
        '
        'rb60
        '
        Me.rb60.AutoSize = True
        Me.rb60.Location = New System.Drawing.Point(6, 18)
        Me.rb60.Name = "rb60"
        Me.rb60.Size = New System.Drawing.Size(60, 17)
        Me.rb60.TabIndex = 0
        Me.rb60.TabStop = True
        Me.rb60.Text = ">= 60%"
        Me.rb60.UseVisualStyleBackColor = True
        '
        'pnlHead
        '
        Me.pnlHead.BackColor = System.Drawing.SystemColors.Window
        Me.pnlHead.Controls.Add(Me.Label1)
        Me.pnlHead.Controls.Add(Me.PicHead)
        Me.pnlHead.Controls.Add(Me.lblTitelHead)
        Me.pnlHead.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHead.Location = New System.Drawing.Point(0, 0)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(488, 57)
        Me.pnlHead.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(69, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(395, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Hier können Sie die nötigen Einstellungen zum Projekt-Analyse Add-In vornehmen."
        '
        'PicHead
        '
        Me.PicHead.Location = New System.Drawing.Point(12, 13)
        Me.PicHead.Name = "PicHead"
        Me.PicHead.Size = New System.Drawing.Size(32, 32)
        Me.PicHead.TabIndex = 3
        Me.PicHead.TabStop = False
        '
        'lblTitelHead
        '
        Me.lblTitelHead.AutoSize = True
        Me.lblTitelHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitelHead.Location = New System.Drawing.Point(50, 13)
        Me.lblTitelHead.Name = "lblTitelHead"
        Me.lblTitelHead.Size = New System.Drawing.Size(175, 13)
        Me.lblTitelHead.TabIndex = 0
        Me.lblTitelHead.Text = "Einstellungen Projekt-Analyse"
        '
        'lblTitelBody
        '
        Me.lblTitelBody.AutoSize = True
        Me.lblTitelBody.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitelBody.Location = New System.Drawing.Point(53, 65)
        Me.lblTitelBody.Name = "lblTitelBody"
        Me.lblTitelBody.Size = New System.Drawing.Size(133, 13)
        Me.lblTitelBody.TabIndex = 3
        Me.lblTitelBody.Text = "Farbwechel des IST-Werts"
        '
        'lblBodyText
        '
        Me.lblBodyText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBodyText.Location = New System.Drawing.Point(72, 78)
        Me.lblBodyText.Name = "lblBodyText"
        Me.lblBodyText.Size = New System.Drawing.Size(390, 58)
        Me.lblBodyText.TabIndex = 4
        Me.lblBodyText.Text = resources.GetString("lblBodyText.Text")
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(320, 261)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnAbbruch
        '
        Me.btnAbbruch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbbruch.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAbbruch.Location = New System.Drawing.Point(401, 261)
        Me.btnAbbruch.Name = "btnAbbruch"
        Me.btnAbbruch.Size = New System.Drawing.Size(75, 23)
        Me.btnAbbruch.TabIndex = 1
        Me.btnAbbruch.Text = "Abbruch"
        Me.btnAbbruch.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnAbbruch
        Me.ClientSize = New System.Drawing.Size(488, 296)
        Me.Controls.Add(Me.btnAbbruch)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblBodyText)
        Me.Controls.Add(Me.lblTitelBody)
        Me.Controls.Add(Me.pnlHead)
        Me.Controls.Add(Me.gbProzuWahl)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Einstellungen"
        Me.gbProzuWahl.ResumeLayout(False)
        Me.gbProzuWahl.PerformLayout()
        Me.pnlHead.ResumeLayout(False)
        Me.pnlHead.PerformLayout()
        CType(Me.PicHead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbProzuWahl As Windows.Forms.GroupBox
    Friend WithEvents pnlHead As Windows.Forms.Panel
    Friend WithEvents rb90 As Windows.Forms.RadioButton
    Friend WithEvents rb80 As Windows.Forms.RadioButton
    Friend WithEvents rb70 As Windows.Forms.RadioButton
    Friend WithEvents rb60 As Windows.Forms.RadioButton
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents PicHead As Windows.Forms.PictureBox
    Friend WithEvents lblTitelHead As Windows.Forms.Label
    Friend WithEvents lblTitelBody As Windows.Forms.Label
    Friend WithEvents lblBodyText As Windows.Forms.Label
    Friend WithEvents btnOK As Windows.Forms.Button
    Friend WithEvents btnAbbruch As Windows.Forms.Button
End Class

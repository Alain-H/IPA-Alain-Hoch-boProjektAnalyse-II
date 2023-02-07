Public Class frmSettings

    Dim _wahl As Integer

    Private Property wahl As Integer
        Get
            Return _wahl
        End Get
        Set(value As Integer)
            _wahl = value
        End Set
    End Property


    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        PicHead.Image = blueoffice.common.Resource.Drawing.GetImage32("Options")
        Me.Icon = blueoffice.common.Resource.Drawing.GetIcon16("blueoffice")

        _wahl = blueoffice.common.settings.DBSettings.GrundlagenGetMandantInt("PA_ProzentWahl", 80)

        Select Case _wahl
            Case 60
                rb60.Checked = True
            Case 70
                rb70.Checked = True
            Case 80
                rb80.Checked = True
            Case 90
                rb90.Checked = True
            Case Else
                rb80.Checked = True
                _wahl = 80
        End Select
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        'Abspeichern von ProzentWahl (Grundlagen)
        blueoffice.common.settings.DBSettings.GrundlagenPutMandantInt("PA_ProzentWahl", _wahl)
        Me.Close()
    End Sub

    Private Sub btnAbbruch_Click(sender As Object, e As EventArgs) Handles btnAbbruch.Click
        Me.Close()
    End Sub

    Private Sub rb60_CheckedChanged(sender As Object, e As EventArgs) Handles rb60.CheckedChanged
        If rb60.Checked Then
            _wahl = 60
        End If
    End Sub

    Private Sub rb70_CheckedChanged(sender As Object, e As EventArgs) Handles rb70.CheckedChanged
        If rb70.Checked Then
            _wahl = 70
        End If
    End Sub

    Private Sub rb80_CheckedChanged(sender As Object, e As EventArgs) Handles rb80.CheckedChanged
        If rb80.Checked Then
            _wahl = 80
        End If
    End Sub

    Private Sub rb90_CheckedChanged(sender As Object, e As EventArgs) Handles rb90.CheckedChanged
        If rb90.Checked Then
            _wahl = 90
        End If
    End Sub
End Class
Imports System.Drawing
Imports System.Windows.Forms
Imports blueoffice.common.AddIn
Imports blueoffice.controls
Imports blueoffice.controls.boGrid
Imports blueoffice.menu

Public Class crlADR
    Implements IAddInControl
    Implements IFrameControlMenu

    Dim WithEvents boSL As boSearchList
    Dim boGridSR As boGrid.Grid


    Dim ADR_ID As Integer

    Public Property CurrentObject As Object Implements IFrameControl.CurrentObject
        Get
            Return Nothing
        End Get
        Set(value As Object)
            If value IsNot Nothing Then
                If TypeOf (value) Is blueoffice.DAL.A_ADRESSEN Then
                    Dim tADR As blueoffice.DAL.A_ADRESSEN = DirectCast(value, blueoffice.DAL.A_ADRESSEN)
                    If tADR IsNot Nothing AndAlso tADR.HasData Then
                        ADR_ID = tADR.ADR_ID
                    Else
                        ADR_ID = 0
                    End If
                End If
            End If
        End Set
    End Property

    Public Event ObjectChanged As IFrameControl.ObjectChangedEventHandler Implements IFrameControl.ObjectChanged
    Public Event PerformAction As IFrameControl.PerformActionEventHandler Implements IFrameControl.PerformAction

    Public Sub MenuClick(Sender As Object, Key As String, MenuTool As ToolBase, ByRef IsHandled As Boolean) Implements IFrameControlMenu.MenuClick
        Select Case Key
            Case "mnuD_Speicher"
                IsHandled = True
            Case "mnuD_Cancel"
                IsHandled = True
        End Select
    End Sub

    Public Sub InitializeControl() Implements IFrameControl.InitializeControl


        Try

            'DB Ckecken auf Tabellen PA_ProjAn und ViewProjAn
            Dim dbC As New PU
            dbC.DBCheck()



            'Icons von den Buttons im Control
            btnAddA.Image = blueoffice.common.Resource.Drawing.GetImage16("Beleg")
            btnAddSR.Image = blueoffice.common.Resource.Drawing.GetImage16("SV")
            btnDeleteObj.Image = blueoffice.common.Resource.Drawing.GetImage16("Delete")
            btnRefresh.Image = blueoffice.common.Resource.Drawing.GetBitmap16("Refresh")
            btnSettings.Image = blueoffice.common.Resource.Drawing.GetImage16("Options")


            pgbADR.Maximum = 100

            pgbADR.Value = 0


            'boSL Inizialisieren
            boSL = New blueoffice.controls.boSearchList
            With boSL
                .CreateView(blueoffice.controls.boShared.SearchListType.UserDefined)
                .ShowListImageCol = True
                .PermanentFilter = "ID > 0 "
                .ViewStyle = boSearchList.ViewStyleType.Tile
                .TileStyleIndex = 3
                .SearchTextboxVisible = False
            End With

            'boSearchListUserOptions mit SQL From um Daten abzufragen und Laden
            With boSL.UserOptions
                .AddTileImage("A", blueoffice.common.Resource.Drawing.GetBitmap32("Beleg"))
                .AddTileImage("SR", blueoffice.common.Resource.Drawing.GetImage32("SV"))
                .DBTileImageKey = "ObjTyp"
                .SQL_From = "From viewPA_ProjAn"
                .RowDBField1_Tile = "Nr"
                .RowDBField2_Tile = "Bez"
                .RowDBField3_Tile = "(Format (Datum, 'dd.MM.yyyy'))"
                .OrderDBField_Tile = "Nr"
                .DBField_ID = "ID"
            End With


            pnlBoSL.Controls.Add(boSL)
            boSL.Dock = DockStyle.Fill



            boGridSR = New boGrid.Grid
            'GridSR Einstellungen
            With boGridSR
                .Dock = DockStyle.Fill
                .CreateGrid()
                .Name = "GridSR"
                .Cols.Count = 0
                .Cols.Fixed = 0
                .Rows.Count = 1
                .Rows.Fixed = 1
                .ExtendLastCol = True
                .AllowDragging = blueoffice.controls.boGrid.AllowDraggingEnum.None
                .AllowAddNew = False
                .AllowDelete = False
                .AllowResizing = blueoffice.controls.boGrid.AllowResizingEnum.Columns
                .AllowEditing = False
                .AllowMerging = blueoffice.controls.boGrid.AllowMergingEnum.FixedOnly
                '.Rows.Item(0).AllowMerging = False
            End With


            'boGrid Styles
            With boGridSR.Styles.Add("Text")
                .DefinedElements = blueoffice.controls.boGrid.StyleElementFlags.DataType Or blueoffice.controls.boGrid.StyleElementFlags.TextAlign
                .DataType = GetType(String)
                .TextAlign = blueoffice.controls.boGrid.TextAlignEnum.LeftCenter
            End With

            With boGridSR.Styles.Add("Dezimal")
                .DefinedElements = blueoffice.controls.boGrid.StyleElementFlags.DataType Or blueoffice.controls.boGrid.StyleElementFlags.TextAlign Or blueoffice.controls.boGrid.StyleElementFlags.Format
                .DataType = GetType(Decimal)
                .TextAlign = blueoffice.controls.boGrid.TextAlignEnum.RightCenter
                .Format = "#,##0.00"
            End With

            'Funktioniert

            With boGridSR.Styles.Add("ColorIst")
                .ForeColor = Color.Red
                .Border.Color = Color.Black
            End With


            'boGrid HeaderCoils
            With boGridSR.Cols.Add()
                .Name = "colSR_Nummer"
                .Caption = "SR-Nummer"
                .Style = boGridSR.Styles.Item("Text")
                .Width = 75
            End With

            With boGridSR.Cols.Add()
                .Name = "colSR_Bez"
                .Caption = "Bezeichnung"
                .Style = boGridSR.Styles.Item("Text")
                .Width = 85
            End With

            With boGridSR.Cols.Add()
                .Name = "colSR_Verrechnet"
                .Caption = "Verrechnet"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 65
            End With

            With boGridSR.Cols.Add()
                .Name = "colSR_Kulanz"
                .Caption = "Kulanz"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 45
            End With

            With boGridSR.Cols.Add()
                .Name = "colSRNicht_Verrechnet"
                .Caption = "Nicht-Verrechnet"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 90
            End With

            With boGridSR.Cols.Add()
                .Name = "colSR_Verrechenbar"
                .Caption = "Verrechenbar"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 80
            End With

            With boGridSR.Cols.Add()
                .Name = "colSR_Soll"
                .Caption = "Soll"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 50
            End With

            With boGridSR.Cols.Add()
                .Name = "colSR_Ist"
                .Caption = "IST"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 40
            End With

            With boGridSR.Cols.Add()
                .Name = "colPuffer"
                .Caption = ""
                .Width = 1
            End With


            pnlBoGrid.Controls.Add(boGridSR)
            boGridSR.Dock = DockStyle.Fill


            'boGrid Setting Load 
            Dim sRegKey As String
            Dim column As blueoffice.controls.boGrid.Column
            sRegKey = Me.Name '** Name des Formulares
            sRegKey &= "\BoGrids\"
            sRegKey &= boGridSR.Name '** Name des Grids
            For col As Integer = 0 To boGridSR.Cols.Count - 1
                column = boGridSR.Cols.Item(col)
                column.Width = blueoffice.common.settings.Reg.GetRegForm(sRegKey, column.Name & "_Width", column.Width)
            Next
            boSL.LoadSettings("ProjektAnalyse_BoSL")


        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Information, blueoffice.common.db.Info.PTitel)

        End Try



    End Sub

    Public Sub ControlClosing(ByRef Cancel As Boolean) Implements IFrameControl.ControlClosing

        'boGrid Safe Settings
        Dim sRegKey As String
        Dim column As blueoffice.controls.boGrid.Column
        sRegKey = Me.Name 'Name des Formulares
        sRegKey &= "\BoGrids\"
        sRegKey &= boGridSR.Name 'Name des Grids
        For col As Integer = 0 To boGridSR.Cols.Count - 1
            column = boGridSR.Cols.Item(col)
            blueoffice.common.settings.Reg.SaveRegForm(sRegKey, column.Name & "_Width", column.Width)
        Next

        'Abspichern von boSL in Regsettings
        boSL.SaveSettings("ProjektAnalyse_BoSL")

    End Sub

    Public Sub Clear() Implements IFrameControl.Clear
    End Sub

    Public Sub Save(ByRef Cancel As Boolean) Implements IFrameControl.Save
    End Sub

    Public Sub Action(Action As FrameControlAction, Optional ActionValue As Object = Nothing) Implements IFrameControl.Action
    End Sub

    Public Function Description() As String Implements IAddInControl.Description
        Return "Zur Überwachung von Aufträgen welche Leistungen haben. im Vergleich mit SR's. (Soll/Ist vergleich)"
    End Function

    Public Function GetControl() As Control Implements IFrameControl.GetControl$
        Return Me
    End Function

    Public Function GetSelected() As SelectedObject Implements IFrameControl.GetSelected
        Return Nothing
    End Function

    Private Function IAddInControl_Name() As String Implements IAddInControl.Name
        Return "Projektanalyse"
    End Function

    Private Sub btnAddA_Click(sender As Object, e As EventArgs) Handles btnAddA.Click
        Dim tPU As New PU
        If tPU.AddBeleg() Then
            'Fill
        End If
    End Sub

    Private Sub btnAddSR_Click(sender As Object, e As EventArgs) Handles btnAddSR.Click
        Dim tPU As New PU
        If tPU.AddObjSRDialog(ADR_ID) Then
            'Fill   
        End If
    End Sub

    Private Sub btnDeleteObj_Click(sender As Object, e As EventArgs) Handles btnDeleteObj.Click
        Dim tPU As New PU
        If tPU.DeleteObject() Then
            'Fill
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        'Fill
    End Sub

    Private Sub AufPermFilter()
        If ADR_ID <> 0 Then
            'boSL Permfilter auf ADR_ID setzen.
        End If
    End Sub
End Class

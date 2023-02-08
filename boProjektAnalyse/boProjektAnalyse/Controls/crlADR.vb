Imports System.Drawing
Imports System.Windows.Forms
Imports blueoffice.common.AddIn
Imports blueoffice.controls
Imports blueoffice.controls.boGrid
Imports blueoffice.menu
Imports Microsoft.VisualBasic.Devices

Public Class crlADR
    Implements IAddInControl
    Implements IFrameControlMenu

    Dim WithEvents boSL As boSearchList
    Dim boGridSR As boGrid.Grid
    Dim prozprog As Integer


    Dim ADR_ID As Integer

    Sub New()

        InitializeComponent()


    End Sub

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
                    Fill() 'Refrsh beim Wechsel zischen den Adressen
                End If
            End If
        End Set
    End Property

    Public Sub Fill()
        Try
            'boSL füllen
            AufPermFilter()
            boSL.Fill()
            boGridSR.Rows.Count = 1

            'boGridSR füllen
            Dim puCalc As New PUCalc(ADR_ID)
            If ADR_ID > 0 Then
                For Each item As PUCalcItem In puCalc.Items
                    If Not item.SRNr Is Nothing Then
                        boGridSR.AddItem({item.SRNr, item.Bezeichnung, item.Verrechnet, item.Warten, item.Kulanz, item.Garentie, item.nichtVerrechnet, Nothing, Nothing, item.Ist})
                    End If
                Next

                boGridSR.AddItem({"Gesamt:", Nothing, puCalc.totalVerrechnet, puCalc.totalWarten, puCalc.totalKulanz, puCalc.totalGarantie, puCalc.totalNichtVerrechnet, puCalc.Soll_ALL, puCalc.Verrechenbar, puCalc.Ist_All})
            End If

            pgbADR.Value = puCalc.ProzProgress
            lblProzADR.Text = puCalc.ProzProgress & "%"
            prozprog = puCalc.ProzProgress

            ChangeColorISt()
            ChangeColorKundenView()

        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Sub



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
                .ContextMenuStrip = ContMenu
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
                .Width = 85
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
                .Width = 85
            End With

            With boGridSR.Cols.Add()
                .Name = "colWarten"
                .Caption = "Warten"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 85
            End With

            With boGridSR.Cols.Add()
                .Name = "colSR_Kulanz"
                .Caption = "Kulanz"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 85
            End With

            With boGridSR.Cols.Add()
                .Name = "colSR_Garantie"
                .Caption = "Garantie"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 85
            End With



            With boGridSR.Cols.Add()
                .Name = "colSRNicht_Verrechnet"
                .Caption = "Nicht-Verrechnet"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 90
            End With

            With boGridSR.Cols.Add()
                .Name = "colSR_Soll"
                .Caption = "Soll"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 85
            End With

            With boGridSR.Cols.Add()
                .Name = "colSR_Verrechenbar"
                .Caption = "Kundensicht"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 85
            End With

            With boGridSR.Cols.Add()
                .Name = "colSR_Ist"
                .Caption = "IST"
                .Style = boGridSR.Styles.Item("Dezimal")
                .Width = 85
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
            Debug.Print(ex.Message)
        End Try



    End Sub

    Public Sub ControlClosing(ByRef Cancel As Boolean) Implements IFrameControl.ControlClosing
        Try
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

        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try


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

    Private Sub AufPermFilter()
        If ADR_ID <> 0 Then
            'boSL Permfilter auf ADR_ID setzen.
            boSL.PermanentFilter = $"ADR_ID = {ADR_ID}"
        End If
    End Sub

    Private Sub ChangeColorISt()
        Dim color As New PUCalc
        If boGridSR.Cols.Count <> 0 And boGridSR.Rows.Count <> 0 Then
            'Ist
            boGridSR.Styles.Item("ColorIst").ForeColor = color.GetColColor(prozprog)
            boGridSR.SetCellStyle(boGridSR.Rows.Count - 1, boGridSR.Cols.Count - 2, boGridSR.Styles.Item("ColorIst"))
            'Kundensicht
            boGridSR.Styles.Item("ColorIst").ForeColor = color.GetColColor(prozprog)
            boGridSR.SetCellStyle(boGridSR.Rows.Count - 1, boGridSR.Cols.Count - 3, boGridSR.Styles.Item("ColorIst"))
        End If
    End Sub

    Private Sub ChangeColorKundenView()
        Dim color As New PUCalc
        If boGridSR.Cols.Count <> 0 And boGridSR.Rows.Count <> 0 Then

        End If
    End Sub




#Region "Events"



    Private Sub btnAddA_Click(sender As Object, e As EventArgs) Handles btnAddA.Click, NeuToolStripMenuItem.Click
        Dim tPU As New PU
        If tPU.AddBeleg(ADR_ID) Then
            Fill()
        End If
    End Sub

    Private Sub btnAddSR_Click(sender As Object, e As EventArgs) Handles btnAddSR.Click, BearbeitenToolStripMenuItem.Click
        Dim tPU As New PU
        If tPU.AddObjSRDialog(ADR_ID) Then
            Fill()
        End If
    End Sub

    Private Sub btnDeleteObj_Click(sender As Object, e As EventArgs) Handles btnDeleteObj.Click, LöschenToolStripMenuItem.Click
        Dim tPU As New PU
        If tPU.DeleteObject(boSL.GetRowItemID) Then
            Fill()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click, AktualisierenToolStripMenuItem.Click
        Fill()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim t As New frmSettings
        t.Show(Me)
    End Sub

    Private Sub boSL_Grid_MouseDoubleClick(sender As Object, RowIndex As Integer, ColIndex As Integer, ItemID As Integer, e As MouseEventArgs) Handles boSL.Grid_MouseDoubleClick
        If boSL.GetRowItemID > 0 Then
            Dim t As New PU
            t.OpenObject(boSL.GetRowItemID)
        End If
    End Sub

    'Private Sub boSL_Grid_MouseClick(sender As Object, RowIndex As Integer, ColIndex As Integer, ItemID As Integer, e As MouseEventArgs) Handles boSL.Grid_MouseClick
    '    If e.Button = MouseButtons.Right Then
    '        If boSL.GetRowItemID <> 0 Then
    '            ContMenu.Show(PointToScreen(e.Location))
    '        End If
    '    End If
    'End Sub



    'Mouse double click um SR direkt im Grid öffnen zu können.
    'Private Sub pnlBoGrid_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles pnlBoGrid.MouseDoubleClick

    'End Sub

    'CentextualMenu
    'Private Sub crlADR_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
    '    If e.Button.Right = True Then
    '        Dim t As New blueoffice.menu.Contextual
    '    End If
    'End Sub




#End Region

End Class

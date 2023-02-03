Imports System.Web
Imports System.Windows.Forms

Public Class PU

    Public Sub DBCheck()
        'DBChecken mit Skript
        Dim sq As String

        If blueoffice.common.db.Data.DBData.TableExists("PA_ProjAn") = False Then

            'Table: PA_ProjAn
            sq = "CREATE TABLE [dbo].[PA_ProjAn](
	             [ID] [int] NOT NULL,
	             [ADR_ID] [int] NOT NULL,
	             [BelegID] [int] NOT NULL,
	             [BelegTyp] [varchar](2) NOT NULL,
	             [SSV_ID] [int] NOT NULL
)                ON [PRIMARY]"

            blueoffice.common.db.Data.DBData.ExecuteNonQuery(sq)


            'View viewPA_ProjAn
            sq = "Create View viewPA_ProjAn
            AS
            Select      PA_ProjAn.ID
            			PA_ProjAn.ADR_ID
            			S_SERVICE.SSV_Nr as Nr
            			S_SERVICE.SSV_Titel as Bez
            			S_SERVICE.SSV_ERFDAT as Datum
            			S_SERVICE.SSV_ID as ObjID 
            			'SR' as ObjTyp

            From PA_ProjAn INNER Join S_SERVICE On PA_ProjAn.SSV_ID = S_SERVICE.SSV_ID
                          WHERE (PA_ProjAn.SSV_ID > 0)

                UNION ALL

            Select      PA_ProjAn.ID
                        PA_ProjAn.ADR_ID
                        bo_BelegK.RKA_ExtAufNr as Nr
                        bo_BelegK.RKA_Bezeichnung as Bez
                        bo_BelegK.RKA_Datum1 as Datum
                        PA_ProjAn.BelegID as ObjID
                        bo_BelegK.Typ as ObjTyp

            From PA_ProjAn INNER Join bo_BelegK On PA_ProjAn.BelegID = bo_BelegK.RKA_ID And PA_ProjAn.BelegTyp = bo_BelegK.Typ

            			WHERE PA_ProjAn.BelegID > 0"

            blueoffice.common.db.Data.DBData.ExecuteNonQuery(sq)

        End If

    End Sub

    Public Sub OpenObject(ID As Integer)
        Try
            Dim sq As String
            Dim dr As DataRow

            sq = $"SELECT        TOP (1) ID, ADR_ID, Nr, Bez, Datum, ObjID, ObjTyp
                   FROM          viewPA_ProjAn
                   WHERE         (ID = {ID})"
            dr = blueoffice.common.db.Data.DBData.GetDataRow(sq)
            If Not dr Is Nothing Then
                Select Case dr.Item("ObjTyp")
                    Case "SR"
                        Dim t As New blueoffice.ERP.SupportTool.Dialogs
                        t.OpenItem(CInt(dr.Item("ObjID")))
                        t = Nothing
                    Case "A"
                        Dim t As New blueoffice.ERP.Beleg.Beleg
                        t.Bearbeiten_Positionen(dr.Item("Nr").ToString)
                        t = Nothing
                End Select
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try


    End Sub

    Public Function AddBeleg(adr_ID As Integer) As Boolean
        Dim RetVal As Boolean
        Dim adrCtl As New crlADR

        Try
            ''BelegDialog öffnen
            Dim bel As New blueoffice.ERP.Browser.Belege
            bel.PermanentFilter = $"RKA_ADR_ID = {adr_ID} AND RKA_Status <> 'A4' and RKA_Status <> 'AS'"
            If bel.ShowDialog("A") = Windows.Forms.DialogResult.OK Then
                Dim sq As String
                'Abfrage auf PA_ProjAn ob schon vorhandn falls nicht wirds hinzugefügt
                sq = $"IF NOT EXISTS
                        (SELECT ID FROM PA_ProjAn WHERE ADR_ID = {adr_ID} And BelegID = {bel.SelectedObject.ID})
                        BEGIN
                        INSERT        TOP (1)
                        INTO          PA_ProjAn(ADR_ID, BelegID, BelegTyp, SSV_ID)
                        VALUES        ({adr_ID}, {bel.SelectedObject.ID}, 'A',0 )
                        END"

                If blueoffice.common.db.Data.DBData.ExecuteNonQuery(sq) > 0 Then
                    RetVal = True
                End If
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

        Return RetVal
    End Function

    Public Function AddObjSRDialog(ADR_ID As Integer) As Boolean
        Dim RetVal As Boolean
        Try
            Dim t As New blueoffice.ERP.Browser.SupportTool
            t.PermanentFilter = $"SSV_ADR_ID = {ADR_ID} and SSV_Typ = 0"
            If t.ShowDialog() = Windows.Forms.DialogResult.OK Then
                RetVal = AddSR(ADR_ID, t.SelectedObject.ID)
            End If

        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        Return RetVal
    End Function

    Public Function AddSR(ADR_ID As Integer, ssv_ID As Integer) As Boolean
        Dim RetVal As Boolean
        Try
            Dim sq As String
            'Abfrage auf PA_ProjAn ob schon vorhandn falls nicht wirds hinzugefügt
            sq = $"IF NOT EXISTS
                        (SELECT ID FROM PA_ProjAn WHERE ADR_ID = {ADR_ID} And SSV_ID = {ssv_ID})
                        BEGIN
                        INSERT        TOP (1)
                        INTO          PA_ProjAn(ADR_ID, BelegID, BelegTyp, SSV_ID)
                        VALUES        ({ADR_ID}, 0, '', {ssv_ID})
                        END"
            If blueoffice.common.db.Data.DBData.ExecuteNonQuery(sq) > 0 Then
                RetVal = True
            End If

        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        Return RetVal
    End Function

    Public Function DeleteObject(id As Integer) As Boolean
        Dim RetVal As Boolean
        Try
            'in PA_ProjAn löschen
            Dim sq As String

            sq = $"DELETE TOP   (1)
                   FROM         PA_ProjAn
                   WHERE        (ID = {id})"

            If blueoffice.common.db.Data.DBData.ExecuteNonQuery(sq) > 0 Then
                RetVal = True
            End If

        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        Return RetVal
    End Function

    Public Function GetADR_IDFromSSV_ID(ssv_ID) As Integer
        Dim RetVal As Integer
        Dim sq As String
        Dim dr As DataRow

        sq = $"Select        *
              From          viewPA_ProjAN
              where         ObjID = '{ssv_ID}' AND ObjTyp = 'SR'"

        dr = blueoffice.common.db.Data.DBData.GetDataRow(sq)

        RetVal = dr.Item("ADR_ID")

        Return RetVal

    End Function






End Class

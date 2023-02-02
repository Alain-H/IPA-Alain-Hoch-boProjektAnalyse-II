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

    Public Function OpenAuftrag() As Boolean
        Dim RetVal As Boolean
        '' AuftragsDialog öffnen

        Return RetVal
    End Function

    Public Function AddBeleg() As Boolean
        Dim RetVal As Boolean
        ''BelegDialog öffnen

        Return RetVal
    End Function



    Public Function AddObjSRDialog(ADR_ID As Integer) As Boolean
        Dim RetVal As Boolean
        Dim t As New blueoffice.ERP.Browser.SupportTool
        t.PermanentFilter = $"SSV_ADR_ID = {ADR_ID} and SSV_Typ = 0"
        If t.ShowDialog() = Windows.Forms.DialogResult.OK Then
            RetVal = AddSR(ADR_ID, t.SelectedObject.ID)
        End If
        Return RetVal
    End Function

    Public Function AddSR(ADR_ID As Integer, ssv_ID As Integer) As Boolean
        Dim RetVal As Boolean
        'Abfrage auf PA_ProjAn if not existing then insert into !
        Return RetVal
    End Function

    Public Function DeleteObject() As Boolean
        Dim RetVal As Boolean
        ''Delete the currentObject
        Return RetVal
    End Function







End Class

Imports System.Web
Imports System.Windows.Forms

Public Class PU

    Public Sub DBCheck()
        'DBChecken mit Skript
        Dim sq As String

        If blueoffice.common.db.Data.DBData.TableExists("PA_ProjAn") = False Then

            'Table: PA_ProjAn
            sq = "CREATE TABLE [dbo].[PA_ProjAn](
                  [ID] [int] IDENTITY(1,1) NOT NULL,
                  [ADR_ID] [int] NOT NULL,
                  [BelegID] [int] NOT NULL,
                  [BelegTyp] [varchar](2) NOT NULL,
                  [SSV_ID] [int] NOT NULL,
                  CONSTRAINT [PK_PA_ProjAn] PRIMARY KEY CLUSTERED 
                  (
                  	[ID] ASC
                  )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
                  ) ON [PRIMARY]
                  ;
                  
                  ALTER TABLE [dbo].[PA_ProjAn] ADD  CONSTRAINT [DF_PA_ProjAn_ADR_ID]  DEFAULT ((0)) FOR [ADR_ID]
                  ;
                  
                  ALTER TABLE [dbo].[PA_ProjAn] ADD  CONSTRAINT [DF_PA_ProjAn_BelegID]  DEFAULT ((0)) FOR [BelegID]
                  ;
                  
                  ALTER TABLE [dbo].[PA_ProjAn] ADD  CONSTRAINT [DF_PA_ProjAn_BelegTyp]  DEFAULT ('') FOR [BelegTyp]
                  ;
                  
                  ALTER TABLE [dbo].[PA_ProjAn] ADD  CONSTRAINT [DF_PA_ProjAn_SSV_ID]  DEFAULT ((0)) FOR [SSV_ID]
                  ;
                  "

            blueoffice.common.db.Data.DBData.ExecuteNonQuery(sq)


            'View viewPA_ProjAn
            sq = "CREATE OR ALTER VIEW [dbo].[viewPA_ProjAn]
                  AS
                  SELECT        dbo.PA_ProjAn.ID, 
                  		     dbo.PA_ProjAn.ADR_ID, 
                  			 dbo.bo_BelegK.RKA_ExtAufNr AS Nr, 
                  			 dbo.bo_BelegK.RKA_Bezeichnung As Bez,
                  			 dbo.bo_BelegK.RKA_Datum1 As Datum,
                  			 dbo.PA_ProjAn.BelegID AS ObjID,
                  			 dbo.bo_BelegK.Typ AS ObjTyp
                  FROM            dbo.PA_ProjAn INNER JOIN
                                           dbo.bo_BelegK ON dbo.PA_ProjAn.BelegID = dbo.bo_BelegK.RKA_ID AND dbo.PA_ProjAn.BelegTyp = dbo.bo_BelegK.Typ
                  WHERE        (dbo.PA_ProjAn.BelegID > 0)
                  UNION ALL
                  SELECT        dbo.PA_ProjAn.ID, 
                  			  dbo.PA_ProjAn.ADR_ID, 
                  			  dbo.S_SERVICE.SSV_Nr AS Nr, 
                  			  dbo.S_SERVICE.SSV_Titel AS Bez, 
                  			  dbo.S_SERVICE.SSV_ERFDAT AS Datum,
                  			  dbo.PA_ProjAn.SSV_ID AS ObjID,
                  			  'SR' AS ObjTyp
                  FROM            dbo.PA_ProjAn INNER JOIN
                                           dbo.S_SERVICE ON dbo.PA_ProjAn.SSV_ID = dbo.S_SERVICE.SSV_ID
                  WHERE        (dbo.PA_ProjAn.SSV_ID > 0)"

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
            bel.PermanentFilter = $"RKA_ADR_ID = {adr_ID}"
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

        If Not ssv_ID = 0 Then
            sq = $"Select        *
              From          viewPA_ProjAN
              where         ObjID = '{ssv_ID}' AND ObjTyp = 'SR'"

            dr = blueoffice.common.db.Data.DBData.GetDataRow(sq)


            If dr IsNot Nothing AndAlso Not dr.IsNull("ADR_ID") Then
                RetVal = dr.Item("ADR_ID")
            End If

        End If

        Return RetVal
    End Function






End Class

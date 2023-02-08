CREATE OR ALTER VIEW [dbo].[viewPA_ProjAn]
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
WHERE        (dbo.PA_ProjAn.SSV_ID > 0)
			 
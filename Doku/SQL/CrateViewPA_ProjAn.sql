Create View viewPA_ProjAn
AS
SELECT         PA_ProjAn.ID
			 , PA_ProjAn.ADR_ID
			 , S_SERVICE.SSV_Nr as Nr
			 , S_SERVICE.SSV_Titel as Bez
			 , S_SERVICE.SSV_ERFDAT as Datum
			 , S_SERVICE.SSV_ID as ObjID 
			 , 'SR' as ObjTyp

FROM          PA_ProjAn INNER JOIN
                                  S_SERVICE ON PA_ProjAn.SSV_ID = S_SERVICE.SSV_ID
              WHERE         (PA_ProjAn.SSV_ID > 0) 

			  UNION ALL

Select			PA_ProjAn.ID
			 ,  PA_ProjAn.ADR_ID
			 ,  bo_BelegK.RKA_ExtAufNr as Nr
			 ,  bo_BelegK.RKA_Bezeichnung as Bez
			 ,  bo_BelegK.RKA_Datum1 as Datum
			 ,  PA_ProjAn.BelegID as ObjID
			 ,  bo_BelegK.Typ as ObjTyp

FROM		PA_ProjAn inner Join bo_BelegK on PA_ProjAn.BelegID = bo_BelegK.RKA_ID And PA_ProjAn.BelegTyp = bo_BelegK.Typ
			
			WHERE PA_ProjAn.BelegID > 0
			 
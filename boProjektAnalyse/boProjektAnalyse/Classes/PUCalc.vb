Imports System.Drawing

Public Class PUCalc
    Dim _ADR_ID As Integer
    Dim _Soll_ALL As Decimal
    Dim _Ist_All As Decimal
    Dim _Verrechenbar As Decimal
    Dim _ProzProgress As Integer

    Dim _Items As List(Of PUCalcItem)
    'TODO Gesamt noch von jedem einzelnen hinzufügen um sie gesammthaft auf letzter spalte darzustellen können 
    'Progress IST (ProgBar) evtl auch hier ausrechnen lassen anstelle in ctlADR ? 

    Public ReadOnly Property ADR_ID As Integer
        Get
            Return _ADR_ID
        End Get
    End Property

    Public ReadOnly Property Soll_ALL As Decimal
        Get
            Return _Soll_ALL
        End Get
    End Property

    Public ReadOnly Property Ist_All As Decimal
        Get
            Return _Ist_All
        End Get
    End Property

    Public ReadOnly Property Verrechenbar As Decimal
        Get
            Return _Verrechenbar
        End Get
    End Property

    Public ReadOnly Property ProzProgress As Integer
        Get
            Return _ProzProgress
        End Get
    End Property


    Public ReadOnly Property Items As List(Of PUCalcItem)
        Get
            Return _Items
        End Get
    End Property
    'Leerer Konstruktor für Farb-Gebung
    Sub New()

    End Sub

    'HauptKonstruktor um alle Daten zu brechnen
    Sub New(adr_ID As Integer)
        _ADR_ID = adr_ID
        _Items = New List(Of PUCalcItem)
        Calculate()
        CalcIST_Verrechenbar()
        PBarProgress()
    End Sub

    Private Sub Calculate()

        Dim sq As String
        Dim dr As DataRow
        Dim drc As DataRowCollection

        sq = $"SELECT          TOP (200) SUM(bo_BelegD.RDA_Anzahl) AS Summe
               FROM            PA_ProjAn INNER JOIN
                               bo_BelegK ON PA_ProjAn.BelegID = bo_BelegK.RKA_ID AND PA_ProjAn.BelegTyp = bo_BelegK.Typ INNER JOIN
                               bo_BelegD ON bo_BelegK.Typ = bo_BelegD.Typ AND bo_BelegK.RKA_ID = bo_BelegD.RDA_RKA
               WHERE           (PA_ProjAn.ADR_ID = {_ADR_ID})
               GROUP BY        bo_BelegD.RDA_BerCode
               HAVING          (bo_BelegD.RDA_BerCode = 'L')"

        dr = blueoffice.common.db.Data.DBData.GetDataRow(sq)

        If dr IsNot Nothing Then
            _Soll_ALL = dr.Item("Summe")
        End If

        _Items.Clear()

        sq = $"SELECT           SSV_ID
               FROM             PA_ProjAn
               WHERE            (SSV_ID > 0 AND (ADR_ID = {_ADR_ID}))
               ORDER BY         SSV_ID"

        drc = blueoffice.common.db.Data.DBData.GetDataRows(sq)

        For Each dr In drc
            _Items.Add(New PUCalcItem(dr.Item("SSV_ID")))
        Next

    End Sub

    Private Sub CalcIST_Verrechenbar()
        For Each item As PUCalcItem In Items
            _Ist_All += item.Ist
            _Verrechenbar += item.IstVerrechenbar
        Next
    End Sub

    Private Sub PBarProgress()
        If Not _Soll_ALL = 0 Then
            _ProzProgress = _Ist_All * 100 / _Soll_ALL
        Else
            _ProzProgress = 0
        End If
    End Sub

    Public Function GetISTColor(proz As Integer) As Color
        Dim RetVal As Color
        Dim ProzWahl As Integer

    End Function






End Class

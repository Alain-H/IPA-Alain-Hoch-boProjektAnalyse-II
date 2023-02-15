Imports System.Drawing

Public Class PUCalc
    Dim _ADR_ID As Integer
    Dim _Datum As Date
    Dim _totalSoll As Decimal
    Dim _totalIst As Decimal
    Dim _Verrechenbar As Decimal
    Dim _ProzProgressADR As Integer
    Dim _ProzProgressSSV As Integer
    Dim _totalVerrechnet As Decimal
    Dim _totalWarten As Decimal
    Dim _totalKulanz As Decimal
    Dim _totalGarantie As Decimal
    Dim _totalNichtVerrechnet As Decimal


    Dim _Items As List(Of PUCalcItem)

    Public ReadOnly Property ADR_ID As Integer
        Get
            Return _ADR_ID
        End Get
    End Property

    Public ReadOnly Property Datum As Date
        Get
            Return _Datum
        End Get
    End Property

    Public ReadOnly Property Soll_ALL As Decimal
        Get
            Return _totalSoll
        End Get
    End Property

    Public ReadOnly Property Ist_All As Decimal
        Get
            Return _totalIst
        End Get
    End Property

    Public ReadOnly Property Verrechenbar As Decimal
        Get
            Return _Verrechenbar
        End Get
    End Property

    Public ReadOnly Property ProzProgressADR As Integer
        Get
            Return _ProzProgressADR
        End Get
    End Property


    Public ReadOnly Property Items As List(Of PUCalcItem)
        Get
            Return _Items
        End Get
    End Property

    Public ReadOnly Property totalVerrechnet As Decimal
        Get
            Return _totalVerrechnet
        End Get
    End Property

    Public ReadOnly Property totalWarten As Decimal
        Get
            Return _totalWarten
        End Get
    End Property

    Public ReadOnly Property totalKulanz As Decimal
        Get
            Return _totalKulanz
        End Get
    End Property

    Public ReadOnly Property totalGarantie As Decimal
        Get
            Return _totalGarantie
        End Get
    End Property

    Public ReadOnly Property totalNichtVerrechnet As Decimal
        Get
            Return _totalNichtVerrechnet
        End Get
    End Property

    Public ReadOnly Property ProzProgressSSV As Integer
        Get
            Return _ProzProgressSSV
        End Get
    End Property


    'Leerer Konstruktor für Farb-Gebung
    Sub New()

    End Sub

    'Konstruktor
    Sub New(adr_ID As Integer)
        _ADR_ID = adr_ID
        _Items = New List(Of PUCalcItem)
        Calculate()
        CalcTotal()
        PBarProgressADRIST()
        PBarProgressSSV_KS()
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
            _totalSoll = dr.Item("Summe")
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

    Private Sub CalcTotal()
        For Each item As PUCalcItem In Items
            _totalVerrechnet += item.Verrechnet
            _totalWarten += item.Warten
            _totalKulanz += item.Kulanz
            _totalGarantie += item.Garentie
            _totalNichtVerrechnet += item.nichtVerrechnet

            _totalIst += item.Ist
            _Verrechenbar += item.IstVerrechenbar
        Next
    End Sub

    Private Sub PBarProgressADRIST()

        If Not _totalSoll <= 0 Then
            _ProzProgressADR = _totalIst * 100 / _totalSoll
            If _ProzProgressADR > 100 Then
                _ProzProgressADR = 100
            ElseIf _ProzProgressADR < 0 Then
                _ProzProgressADR = 0
            End If
        Else
            _ProzProgressADR = 0
        End If

    End Sub

    Private Sub PBarProgressSSV_KS()
        If Not _totalSoll <= 0 Then
            _ProzProgressSSV = Verrechenbar * 100 / _totalSoll
            If _ProzProgressSSV > 100 Then
                _ProzProgressSSV = 100
            ElseIf _ProzProgressSSV < 0 Then
                _ProzProgressSSV = 0
            End If
        Else
            _ProzProgressSSV = 0
        End If
    End Sub

    Public Function GetColColor(proz As Integer) As Color
        Dim RetVal As Color
        Dim ProzWahl As Integer

        ProzWahl = blueoffice.common.settings.DBSettings.GrundlagenGetMandantInt("PA_ProzentWahl", 80)

        If ProzWahl <= proz Then
            RetVal = Color.Red
        Else
            If proz < ProzWahl - 10 Then
                RetVal = Color.Green
            ElseIf proz >= ProzWahl - 10 And Not proz >= ProzWahl Then
                RetVal = Color.Orange
            End If
        End If

        Return RetVal
    End Function






End Class

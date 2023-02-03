Imports System.Web

Public Class PUCalcItem
    Dim _SRNr As String
    Dim _SSV_ID As Integer
    Dim _Verrechnet As Decimal
    Dim _Warten As Decimal
    Dim _Kulanz As Decimal
    Dim _Garantie As Decimal
    Dim _nichtVerrechnet As Decimal
    Dim _Bezeichnung As String
    Dim _ist As Decimal
    Dim _IstVerrechenbar As Decimal

    Public ReadOnly Property SRNr As String
        Get
            Return _SRNr
        End Get
    End Property

    Public ReadOnly Property Warten As Decimal
        Get
            Return _Warten
        End Get
    End Property

    Public ReadOnly Property Kulanz As Decimal
        Get
            Return _Kulanz
        End Get
    End Property

    Public ReadOnly Property Garentie As Decimal
        Get
            Return _Garantie
        End Get
    End Property

    Public ReadOnly Property nichtVerrechnet As Decimal
        Get
            Return _nichtVerrechnet
        End Get
    End Property

    Public ReadOnly Property Bezeichnung As String
        Get
            Return _Bezeichnung
        End Get
    End Property


    Public ReadOnly Property Verrechnet As Decimal
        Get
            Return _Verrechnet
        End Get
    End Property

    Public ReadOnly Property IstVerrechenbar As Decimal
        Get
            Return _IstVerrechenbar
        End Get
    End Property

    Public ReadOnly Property Ist As Decimal
        Get
            Return _ist
        End Get
    End Property

    Sub New(ssvID As Integer)
        _SSV_ID = ssvID
        FillValues()
    End Sub

    Private Sub FillValues()

        Dim sq As String
        Dim dr As DataRow
        Dim drc As DataRowCollection


        sq = $"SELECT     S_SERVICE.SSV_Nr, S_SERVICE.SSV_Titel, Z_ERFASSUNG.ZER_Std100, Z_ERFASSUNG.ZER_Verrechnen
               FROM       S_SERVICE_POS INNER JOIN
                          S_SERVICE ON S_SERVICE_POS.SSP_SSV_GUID = S_SERVICE.SSV_GUID INNER JOIN
                          Z_ERFASSUNG ON S_SERVICE_POS.SSP_ID = Z_ERFASSUNG.ZER_SSP_ID
               WHERE      (S_SERVICE.SSV_ID = {_SSV_ID})"


        drc = blueoffice.common.db.Data.DBData.GetDataRows(sq)

        For Each dr In drc
            If Not dr.IsNull("SSV_Nr") Then
                _SRNr = dr.Item("SSV_Nr").ToString
            End If
            If Not dr.IsNull("SSV_Titel") Then
                _Bezeichnung = dr.Item("SSV_Titel")
            End If
            If Not dr.IsNull("ZER_Verrechnen") Then
                Select Case dr.Item("ZER_Verrechnen")
                    Case "V"
                        _Verrechnet = dr.Item("ZER_Std100")
                    Case "W"
                        _Warten = dr.Item("ZER_Std100")
                    Case "K"
                        _Kulanz = dr.Item("ZER_Std100")
                    Case "N"
                        _nichtVerrechnet = dr.Item("Zer_Std100")
                    Case "G"
                        _Garantie = dr.Item("ZER_Std100")
                End Select
            End If


            _ist = 0
            _IstVerrechenbar = 0

            _IstVerrechenbar += (_Verrechnet + _Warten)
            _ist += (_Verrechnet + _Warten + _nichtVerrechnet + _Kulanz + _Garantie)
        Next
    End Sub










End Class

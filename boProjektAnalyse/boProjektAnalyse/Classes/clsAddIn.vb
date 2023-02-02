Imports blueoffice.common.AddIn

Public Class clsAddIn
    Implements blueoffice.common.AddIn.IAddIn

    Public Function GetInfo() As AddInInfo Implements IAddIn.GetInfo
        Dim RetVal As New blueoffice.common.AddIn.AddInInfo

        'FormDesigner verweis mit Beschrieb für ADR
        RetVal.AddToList(GetType(crlADR), blueoffice.common.AddIn.AddInShared.AddInDestination.ADR, "ProjektAnalyse", "Überwachung einzelner Projekte mit einer Übersicht wie viele Stunden schon auf ein ausgewähltes Projekt mit SR-Fällen verbucht wurden oder noch offen sind im Vergleich zu dem dazugehörigen Auftrag.")


        'FormDesigner verweis mit Beschrieb für SSV
        RetVal.AddToList(GetType(crlSSV), blueoffice.common.AddIn.AddInShared.AddInDestination.SSV, "ProjektAnalyse", "Überwachung einzelner Projekte mit einer Übersicht wie viele Stunden schon auf ein ausgewähltes Projekt mit SR-Fällen verbucht wurden oder noch offen sind im Vergleich zu dem dazugehörigen Auftrag.")

        Return RetVal
    End Function
End Class


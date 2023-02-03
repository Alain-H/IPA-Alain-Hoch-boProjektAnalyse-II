﻿Imports System.Drawing
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Windows.Forms
Imports blueoffice.common.AddIn
Imports blueoffice.menu

Public Class crlSSV
    Implements blueoffice.common.AddIn.IAddInControl
    Implements blueoffice.menu.IFrameControlMenu

    Dim SSV_ID As Integer
    Dim ADR_ID As Integer



    'Konstruktor
    Public Sub New()

        InitializeComponent()


    End Sub



    Public Property CurrentObject As Object Implements IFrameControl.CurrentObject
        Get
            Return Nothing
        End Get
        Set(value As Object)
            If value IsNot Nothing Then
                If TypeOf (value) Is blueoffice.DAL.S_SERVICE Then
                    Dim tSSV As blueoffice.DAL.S_SERVICE = DirectCast(value, blueoffice.DAL.S_SERVICE)
                    If tSSV IsNot Nothing AndAlso tSSV.HasData Then
                        SSV_ID = tSSV.SSV_ID
                    Else
                        SSV_ID = 0
                    End If
                End If
            End If
        End Set

    End Property

    Public Event ObjectChanged As IFrameControl.ObjectChangedEventHandler Implements IFrameControl.ObjectChanged
    Public Event PerformAction As IFrameControl.PerformActionEventHandler Implements IFrameControl.PerformAction

    Public Sub MenuClick(Sender As Object, Key As String, MenuTool As ToolBase, ByRef IsHandled As Boolean) Implements IFrameControlMenu.MenuClick
    End Sub

    Public Sub InitializeControl() Implements IFrameControl.InitializeControl

        Try
            'DB Ckecken auf Tabellen PA_ProjAn und ViewProjAn
            Dim dbC As New PU
            dbC.DBCheck()


            pgbSSV.Maximum = 100

            pgbSSV.Value = 25





        Catch ex As Exception

        End Try
    End Sub

    Public Sub ControlClosing(ByRef Cancel As Boolean) Implements IFrameControl.ControlClosing
    End Sub

    Public Sub Clear() Implements IFrameControl.Clear
    End Sub

    Public Sub Save(ByRef Cancel As Boolean) Implements IFrameControl.Save
    End Sub

    Public Sub Action(Action As FrameControlAction, Optional ActionValue As Object = Nothing) Implements IFrameControl.Action
    End Sub

    Public Function Description() As String Implements IAddInControl.Description
        Return "Eine Anzeige zur schnellen übersicht wie weit prozentual der Soll/Ist vergleich ist zwischen den angegebenen Aufträge und den SR's."
    End Function

    Public Function GetControl() As Control Implements IFrameControl.GetControl
        Return Me
    End Function

    Public Function GetSelected() As SelectedObject Implements IFrameControl.GetSelected
    End Function

    Private Function IAddInControl_Name() As String Implements IAddInControl.Name
        Return "Projektanalyse"
    End Function

    'Private Sub lblProzA_Click(sender As Object, e As EventArgs) Handles lblProzA.Click
    'um ctlADR in Form aufzurufen. m   (Optional)
    'End Sub
End Class

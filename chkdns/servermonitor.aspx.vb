Imports System.Data, System.Data.SqlClient, System.Configuration, System.Console
Imports Microsoft.VisualBasic

Public Class servermonitor
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region


    Public oUser As New CUser()
    Dim lngUserID As Long


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        lngUserID = oUser.GetUserID(Session("UserID"))
        Session("UserID") = lngUserID
        Response.Write(Session("UserID"))

        If oUser.AccessToObject("ServerMonitor") = False Then
            Response.Redirect("servermonitor_desc.aspx")
        End If


    End Sub




End Class

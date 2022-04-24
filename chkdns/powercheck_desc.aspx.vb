Imports System.Data, System.Data.SqlClient, System.Configuration, System.Console
Imports Microsoft.VisualBasic

Public Class powercheck_desc
    Inherits System.Web.UI.Page
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents Login As System.Web.UI.WebControls.Panel
    Protected WithEvents Loginmodule1 As Login
    Protected WithEvents Msg As System.Web.UI.HtmlControls.HtmlGenericControl

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

        Loginmodule1.objCtx = System.Web.HttpContext.Current

        lngUserID = oUser.GetUserID(Session("UserID"))
        Session("UserID") = lngUserID


        'If oUser.AccessToObject("Powercheck") = False Then
        ''Response.Redirect("powercheck_desc.aspx")
        'End If

        'Loginmodule1.Visible = False
        'Login.Visible = False

        If lngUserID = 0 Then
            Login.Visible = True
            Msg.Visible = False
        Else
            Login.Visible = False
            Msg.Visible = True
        End If



    End Sub



End Class

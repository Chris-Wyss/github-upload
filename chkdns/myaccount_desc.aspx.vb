Imports System.Data, System.Data.SqlClient, System.Configuration, System.Console
Imports Microsoft.VisualBasic

Public Class myaccount_desc
    Inherits System.Web.UI.Page

    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents Login As System.Web.UI.WebControls.Panel
    Protected WithEvents Loginmodule1 As Login


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

        If lngUserID = 0 Then
            Login.Visible = True
        Else
            Login.Visible = False
            'Response.Redirect("myaccount.aspx")
        End If


    End Sub

End Class

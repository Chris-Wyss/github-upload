'------------------------------------------------------------------------------
' The page is INTENTIONALLY designed without use of .NET controls,
' to allow specifying domain name in URL!
'------------------------------------------------------------------------------
Imports Microsoft.VisualBasic
Public Class check
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


    Protected WithEvents Detailed As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Domain As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnCheck As System.Web.UI.WebControls.Button
    Protected WithEvents CDNSCheckerWrapped1 As CDNSCheckerWrapped

    Protected WithEvents spanLogin As System.Web.UI.HtmlControls.HtmlGenericControl


    Public oUser As New CUser()
    Dim lngUserID As Long
    Dim strDomain As String, boolDetailed As Boolean

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Page.EnableViewState = False

        lngUserID = oUser.GetUserID(Session("UserID"))
        Session("UserID") = lngUserID

        If lngUserID = 0 Then
            spanLogin.Visible = True
        Else
            spanLogin.Visible = False
        End If

        ''
        'lngUserID = 1
        'Session("UserID") = 1
        ''

        Response.Write(Session("UserID"))


        'Put user code to initialize the page here
        strDomain = GetDomain()
        Domain.Text = strDomain

        'Parse "detailed" checkbox
        boolDetailed = True
        If Request.QueryString("submit") <> "" Then
            boolDetailed = (Request.QueryString("detailed") <> "")
        End If
        Detailed.Checked = boolDetailed

        ' Forward domain name to checker
        If Len(Trim(strDomain)) > 0 Then
            CDNSCheckerWrapped1.strDomain = strDomain
            CDNSCheckerWrapped1.DomainID = 0
            CDNSCheckerWrapped1.UserID = 0
        End If

        ' Show title
        If strDomain <> "" Then
            ' Title 1
            ' <title>Testing " & Server.HtmlEncode(strDomain) & "</title>
        Else
            ' Title 2
            '<title>Uniplace CheckDNS.net - check DNS domain for errors</title>
        End If
    End Sub



    Private Function GetDomain() As String
        Dim strDomain As String

        strDomain = Request.QueryString("domain") & ""
        strDomain = Trim(strDomain)

        ' Cut "http://" in case of MBA people
        If UCase(Mid(strDomain, 1, 7)) = "HTTP://" Then
            strDomain = Mid(strDomain, 8)
        End If

        ' Cut "www." in case of MBA people
        If UCase(Mid(strDomain, 1, 4)) = "WWW." Then
            strDomain = Mid(strDomain, 5)
        End If

        Return strDomain
    End Function

    '------------------------------------------------------------------------------
    ' Workaround: viewstate cannot be switched off, so we at least save it to session
    '------------------------------------------------------------------------------
    Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
        '   persist it to the session
        Session("Quickcheck_PageViewState") = viewState
    End Sub

    Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
        '   return it from the session
        Return Session("Quickcheck_PageViewState")
    End Function




End Class

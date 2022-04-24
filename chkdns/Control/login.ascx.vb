Public MustInherit Class login
    Inherits System.Web.UI.UserControl
    Protected WithEvents UserName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Password As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnLogin As System.Web.UI.WebControls.Button
    Protected WithEvents ErrorMsg As System.Web.UI.HtmlControls.HtmlGenericControl



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
    Public objCtx As System.Web.HttpContext  ' TRICK: System.web.httpcontext.current is inaccessible!

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        lngUserID = oUser.GetUserID(Session("UserID"))
        Session("UserID") = lngUserID

    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim iUserStatus As Integer
        '  0 - ok
        ' 20 - subscription is expired
        ' 50 - invalid user name and password


        Dim strMessage As String
        Dim strPageName As String
        Dim iPosition As Integer
        Dim iLen As Integer

        oUser.Authorisation(UserName.Text, Password.Text, iUserStatus, lngUserID, strMessage)


        Dim strTemp As String = objCtx.Request.Url.ToString()

        iPosition = strTemp.LastIndexOf("/")
        If iPosition > 0 Then
            iLen = strTemp.Length()
            strPageName = strTemp.Substring(iPosition + 1, iLen - iPosition - 1)
        Else
            strPageName = ""
        End If

        'objCtx.Response.Write(bIsValid)
        'objCtx.Response.End()
        Session("UserID") = lngUserID


        Select Case iUserStatus
            Case 0 'account is valid
                Select Case strPageName
                    Case "powercheck_desc.aspx"
                        Response.Redirect("powercheck.aspx")
                    Case "servermonitor_desc.aspx"
                        Response.Redirect("servermonitor.aspx")
                    Case "myaccount_desc.aspx"
                        Response.Redirect("myaccount.aspx")
                    Case Else
                        Response.Redirect("quickcheck.aspx")
                End Select
            Case 20  'account is expired
                Response.Redirect("myaccount.aspx")
            Case 50 ' invalid user name and password
                ErrorMsg.InnerHtml = "<b>" & strMessage & "</b>"
                ErrorMsg.Visible = True
            Case Else
                ErrorMsg.InnerHtml = "<b>" & strMessage & "</b>"
                ErrorMsg.Visible = True
        End Select

        'If bIsValid = True Then
        'Session("UserID") = lngUserID
        'Select Case strPageName
        'Case "powercheck_desc.aspx"
        'Response.Redirect("powercheck.aspx")
        'Case "servermonitor_desc.aspx"
        'Response.Redirect("servermonitor.aspx")
        'Case "myaccount_desc.aspx"
        'Response.Redirect("myaccount.aspx")
        'Case Else
        'Response.Redirect("quickcheck.aspx")
        'End Select

        'Else
        'ErrorMsg.InnerHtml = "<b>" & strMessage & "</b>"
        'ErrorMsg.Visible = True
        'Response.Write(ErrorMsg.InnerHtml)
        'Response.Write("<br>")
        'Response.Write(ErrorMsg.InnerText)

        'Response.Write(strMessage)
        'End If

    End Sub
End Class

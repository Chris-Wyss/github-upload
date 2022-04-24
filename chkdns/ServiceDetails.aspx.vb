Imports System.Data, System.Data.SqlClient, System.Configuration, System.Console
Imports Microsoft.VisualBasic
Public Class ServiceDetails
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

    Private LogSessionID As Long
    Private UserID As Long
    Private DomainID As Long
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtCreatedDate As System.Web.UI.WebControls.TextBox
    Private SeviceType As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If IsNumeric(Request.QueryString("DomainID")) Then
            DomainID = Request.QueryString("DomainID")
        Else
            DomainID = 0
        End If
        If IsNumeric(Request.QueryString("LogSessionID")) Then
            LogSessionID = Request.QueryString("LogSessionID")
        Else
            LogSessionID = 0
        End If

        If IsNumeric(Session("UserID")) Then
            UserID = Session("UserID")
        Else
            UserID = 0
        End If

        SeviceType = Request.QueryString("Type")

        Response.Write("<br>")
        'Response.Write("<br>")
        'Response.Write(UserID)
        'Response.Write("<br>")
        'Response.Write(DomainID)
        'Response.Write("<br>")
        'Response.Write(LogSessionID)

        If UserID <> 0 Then
            Call ShowMessages()
        End If

    End Sub


    Private Sub ShowMessages()

        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[LogDomainCheck_MessagesBySubType]")

        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure


        Dim myParmUser As SqlParameter = MyCmd.Parameters.Add("@UserID", SqlDbType.BigInt, 4)
        myParmUser.Value = UserID

        Dim myParmDomain As SqlParameter = MyCmd.Parameters.Add("@DomainID", SqlDbType.BigInt, 4)
        myParmDomain.Value = DomainID

        Dim myParmSession As SqlParameter = MyCmd.Parameters.Add("@LogSessionID", SqlDbType.BigInt, 4)
        myParmSession.Value = LogSessionID

        Dim myParmType As SqlParameter = MyCmd.Parameters.Add("@MessageParentType", SqlDbType.NVarChar, 50)
        myParmType.Value = SeviceType

        Dim reader As SqlDataReader = MyCmd.ExecuteReader()
        Do While (reader.Read())
            Response.Write("<table class=""chaptertable"" align=""center"" width=""100%"">")
            Response.Write("<tr>")
            Response.Write("<td class=""eventtd"" align=""left"">")
            Response.Write("<img src=""" & ShowPicture(reader.GetInt32(2)) & """ border=0>&nbsp;&nbsp;" & reader.GetString(0) & "</td>")
            Response.Write("</tr>")
            Response.Write("</table>" & ControlChars.CrLf & ControlChars.CrLf)

            Label1.Text = reader.Item(9) 'reader.Item(0)
            'Response.Write(reader.GetInt32(2))

            Response.Flush()
            Label1.Text = reader.GetDateTime(9).ToLongDateString & " " & reader.GetDateTime(9).ToLongTimeString            


        Loop

        reader.Close()
        myConn.Close()



        Response.Write("<br>")
        Response.Write("<br>")
        'Response.Write(Server.HtmlEncode("&lt;input type=&quot;button&quot; value=&quot;Close&quot; onClick=&quot;javascript:window.close()&quot;&gt;"))

        Response.Write("<table width='100%'> <tr> <td width='100%' align='center' >")
        Response.Write("<input type='button' value='Close' onClick='javascript:window.close()'>")
        Response.Write("</td></tr></table>")


    End Sub


    Private Function ShowPicture(ByVal iSeverity As Integer)
        Dim strIcon As String

        Select Case iSeverity
            Case 16
                strIcon = "/images/LogDebug.GIF"
            Case 8
                strIcon = "/images/LogNotice.GIF"
            Case 4
                strIcon = "/images/LogOK.GIF"
            Case 2
                strIcon = "/images/LogWarning.GIF"
            Case 1
                strIcon = "/images/LogError.GIF"
            Case Else
                strIcon = "/images/LogError.GIF"
        End Select



        ShowPicture = strIcon


    End Function

End Class

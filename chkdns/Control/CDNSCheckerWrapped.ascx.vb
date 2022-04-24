'------------------------------------------------------------------------------
' This user control is used in page to provide realtime output from
' CheckDNS class to browser
'------------------------------------------------------------------------------
Imports System.Data, System.Data.SqlClient, System.Configuration
Imports Microsoft.VisualBasic
Public MustInherit Class CDNSCheckerWrapped
    Inherits System.Web.UI.UserControl
    Public strDomain As String
    Public DomainID As Integer
    Public UserID As Integer
    Public intQuickCheck As Integer


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

    '------------------------------------------------------------------------------
    '------------------------------------------------------------------------------
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Public Sub New()
        strDomain = ""
        DomainID = 0
        UserID = 0
        intQuickCheck = True
    End Sub

    Private Function CreateLogSession() As Long
        Dim ret As Long
        Dim sqlConnection1 As New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        sqlConnection1.Open()

        Dim strResult As String
        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[LogDomainCheck_CreateSession]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure

        Dim myParm As SqlParameter = MyCmd.Parameters.Add("@LogSessionID", SqlDbType.BigInt, 4)
        myParm.Direction = ParameterDirection.Output
        MyCmd.ExecuteNonQuery()
        ret = MyCmd.Parameters.Item(0).Value()

        myConn.Close()
        Return ret

    End Function

    '------------------------------------------------------------------------------
    '------------------------------------------------------------------------------
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        MyBase.Render(writer)

        Dim LogSessionID As Long

        'Get domain for checking
        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        myConn.Open()

        If UserID = 0 Then ' default user
            If Trim(strDomain) = "" Then Exit Sub

            Dim MyCmd As SqlCommand = New SqlCommand("dbo.[DefaultUser_AddDomain]")
            MyCmd.Connection = myConn
            MyCmd.CommandType = CommandType.StoredProcedure

            Dim myParm As SqlParameter = MyCmd.Parameters.Add("@DomainName", SqlDbType.NVarChar, 50)
            myParm.Value = Me.strDomain
            myParm.Direction = ParameterDirection.Input
            Dim myParm1 As SqlParameter = MyCmd.Parameters.Add("@DomainID", SqlDbType.BigInt, 4)
            myParm1.Direction = ParameterDirection.Output

            MyCmd.ExecuteNonQuery()
            DomainID = MyCmd.Parameters.Item(1).Value()
            myConn.Close()

            Response.Write("User=" & UserID & " DomainID=" & DomainID & "<br>")

            Response.Write("<br><table  border=0 width=80% align=center>")
            Response.Write("<tr><td class=""headertd"">")
            Response.Write("<b>Testing " & Server.HtmlEncode(strDomain) & "</b>")
            Response.Write("</td></tr>")
            Response.Write("</table>")
            Response.Flush()

            ' Run CheckDNS COM
            Dim objLogger As New CSQLLogger()
            objLogger.objCtx = System.Web.HttpContext.Current
            Dim objCheckDNS As New UniDNSCheck2.CDNSChecker()
            objCheckDNS.strDomain = Me.strDomain
            objCheckDNS.objHTMLLogger = objLogger

            'create new log session
            LogSessionID = Me.CreateLogSession
            objLogger.SetSession(LogSessionID, UserID, DomainID)
            'objLogger.OpenLogSession(objCheckDNS.strDomain)
            Call objCheckDNS.RunCheck()
            objLogger = Nothing


        Else
            Dim iCounter As Long = 0
            Dim MyCmd As SqlCommand = New SqlCommand("dbo.[User_GetDomainsForChecking]")
            MyCmd.Connection = myConn
            MyCmd.CommandType = CommandType.StoredProcedure
            MyCmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "", DataRowVersion.Current, UserID))
            MyCmd.Parameters.Add(New SqlParameter("@DomainID", SqlDbType.Int, 4, ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "", DataRowVersion.Current, DomainID))
            Dim reader As SqlDataReader = MyCmd.ExecuteReader()
            Do While (reader.Read())

                DomainID = reader.GetInt32(0)
                strDomain = reader.GetString(1)
                iCounter = iCounter + 1
                If iCounter = 1 Then
                    'create new log session
                    LogSessionID = Me.CreateLogSession
                End If

                Response.Write("User=" & UserID & " DomainID=" & DomainID & "<br>")
                Response.Write("<br><table  border=0 width=80% align=center>")
                Response.Write("<tr><td class=""headertd"">")
                Response.Write("<b>Testing " & Server.HtmlEncode(strDomain) & "</b>")
                Response.Write("</td></tr>")
                Response.Write("</table>")
                Response.Flush()

                ' Run CheckDNS COM
                Dim objLogger As New CSQLLogger()
                objLogger.objCtx = System.Web.HttpContext.Current
                Dim objCheckDNS As New UniDNSCheck2.CDNSChecker()
                objCheckDNS.strDomain = Me.strDomain
                objCheckDNS.objHTMLLogger = objLogger

                'objLogger.OpenLogSession(objCheckDNS.strDomain)
                objLogger.SetSession(LogSessionID, UserID, DomainID)
                Call objCheckDNS.RunCheck()
                objLogger = Nothing
            Loop
            reader.Close()
            myConn.Close()
        End If

    End Sub
End Class

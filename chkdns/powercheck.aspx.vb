'------------------------------------------------------------------------------
' Main power check screen
' Represents list of "own" domains with check results
'------------------------------------------------------------------------------

Imports System.Data, System.Data.SqlClient, System.Configuration, System.Console
Imports Microsoft.VisualBasic
Public Class domains
    Inherits System.Web.UI.Page
    Protected WithEvents DsDomains1 As dsDomains


    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents tbNewDomain As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
    Protected WithEvents btnCheckAllDomains As System.Web.UI.WebControls.Button
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblResultsOfDomains As System.Web.UI.WebControls.Label
    Protected WithEvents dgSessions As System.Web.UI.WebControls.DataGrid

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DsDomains1 = New checkdns_uniplace_com.dsDomains()
        CType(Me.DsDomains1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DsDomains1
        '
        Me.DsDomains1.DataSetName = "dsDomains"
        Me.DsDomains1.Locale = New System.Globalization.CultureInfo("en-US")
        Me.DsDomains1.Namespace = "http://tempuri.org/dsDomains.xsd"
        CType(Me.DsDomains1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.

        Call GetUser()
        InitializeComponent()

    End Sub

#End Region


    Public oUser As New CUser()
    Dim lngUserID As Long

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Response.Write(Session("UserID"))
        'lngUserID = oUser.GetUserID(Session("UserID"))
        Session("UserID") = lngUserID
        Response.Write(Session("UserID"))

        If oUser.AccessToObject("Powercheck") = False Then
            Response.Redirect("powercheck_desc.aspx")
        End If

        'check all domain button
        If oUser.AccessToObject("CheckAllDomains") = False Then
            btnCheckAllDomains.Enabled = False
        End If
        

        If Not IsPostBack() Then
            Call BindGrid()
        End If
    End Sub

    Private Sub GetUser()

        lngUserID = oUser.GetUserID(Session("UserID"))

        If oUser.AccessToObject("Powercheck") = False Then
            Response.Redirect("powercheck_desc.aspx")
        End If


    End Sub


    Private Sub BindGrid()
        'Dim SelectCommand As String = "SELECT *,(SELECT Max(LogSessionID) FROM LogSessions WHERE Domains.DomainName=LogSessions.DomainName) AS LogSessionID FROM Domains WHERE UserID=@UserID ORDER BY DomainName "
        'Dim MyCmd As New SqlCommand(SelectCommand, New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        'MyCmd.Parameters.Add("@UserID", lngUserID)
        'Dim MyDA As New SqlDataAdapter(MyCmd)
        'MyDA.Fill(DsDomains1, "Domains")
        'dgSessions.DataBind()

        'Response.Write("user=" & lngUserID)
        'Response.End()

        Dim MyDA As SqlDataAdapter = New SqlDataAdapter()
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[User_GetDomains]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))

        MyCmd.CommandType = CommandType.StoredProcedure
        MyCmd.Parameters.Add(New SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, False, CType(10, Byte), CType(0, Byte), "", DataRowVersion.Current, Nothing))
        MyCmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, False, CType(10, Byte), CType(0, Byte), "", DataRowVersion.Current, lngUserID))
        MyDA.SelectCommand = MyCmd

        MyDA.Fill(DsDomains1, "Domains")
        dgSessions.DataBind()



    End Sub

    Private Sub dgSessions_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgSessions.PageIndexChanged
        dgSessions.CurrentPageIndex = e.NewPageIndex
        Call BindGrid()
    End Sub

    Public Function MakeDomainLink(ByVal Container As Object) As String
        MakeDomainLink = "JavaScript:PopupWin('editdomain.aspx?DomainID=" & Container.Dataitem("DomainID") & "&UserID=" & lngUserID & "', 'Details')"
    End Function

    Public Function MakeCheckLink(ByVal Container As Object) As String
        'MakeCheckLink = "JavaScript:PopupWin('fillsql.aspx?domain=" & Container.Dataitem("DomainName") & "', 'Details')"
        MakeCheckLink = "JavaScript:PopupWin('fillsql.aspx?domainID=" & Container.Dataitem("DomainID") & "&UserID=" & lngUserID & "', 'Details')"
    End Function



    '------------------------------------------------------------------------------
    ' This function is used in template columns:
    ' DNS_ROOT
    ' DNS_ALIVE
    ' DNS_SYNCH
    ' HTTP
    ' SMTP
    '------------------------------------------------------------------------------
    Public Function ShowParagraph(ByVal vLogSessionID As Object, ByVal strParagraphName As String) As String
        If IsDBNull(vLogSessionID) Then
            ShowParagraph = "no test"
            Exit Function
        End If
        Dim lngLogSessionID As Long = vLogSessionID

        Dim strSQL As String
        strSQL = "SELECT Min(MsgSeverity) FROM LogMessagesExt WHERE LogSessionID=@LogSessionID AND LogParagraph=@Paragraph"
        Dim myCommand As SqlCommand = New SqlCommand(strSQL, New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myCommand.Parameters.Add("@LogSessionID", lngLogSessionID)
        myCommand.Parameters.Add("@Paragraph", strParagraphName)
        myCommand.Connection.Open()
        Dim varResult As Object
        varResult = myCommand.ExecuteScalar
        myCommand.Connection.Close()
        myCommand = Nothing

        ' Convert
        Dim intSeverity As Integer
        If Not IsDBNull(varResult) Then
            intSeverity = varResult
        Else
            intSeverity = -1
        End If

        ' Choose icon & show
        Dim strIcon As String
        Select Case intSeverity
            Case 8
                strIcon = "/images/LogDebug.GIF"
            Case 4
                strIcon = "/images/LogNotice.GIF"
            Case 2
                strIcon = "/images/LogWarning.GIF"
            Case 1
                strIcon = "/images/LogError.GIF"
            Case -1
                strIcon = ""
            Case Else
                strIcon = "??"
        End Select

        If strIcon <> "" Then
            ShowParagraph = "<img src=""" & strIcon & """ border=0>"
        Else
            ShowParagraph = ""
        End If
    End Function



    Public Function ShowPicture(ByVal LogSessionID As Long, ByVal DomainID As Long, ByVal intSeverity As Integer, ByVal strType As String) As String

        ' Choose icon & show
        Dim strIcon As String
        Dim strTemp As String
        Select Case intSeverity
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
            Case -1
                strIcon = ""
            Case Else
                strIcon = "??"
        End Select


        If strIcon <> "" Then
            'strTemp = " <a href='myaccount.aspx?DomainID=" & DomainID & "'><img src='/images/logerror.gif' border=0 width='16' height='16'></a>"
            'strTemp = " <a href=JavaScript:PopupWin('ServiceDetails.aspx?DomainID=" & DomainID & "&LogSessionID=" & LogSessionID & "&Type=" & strType & "','Details')><img src='/images/logerror.gif' border=0 width='16' height='16'></a>"
            strTemp = " <a href=JavaScript:PopupWinShowMessageDetails('ServiceDetails.aspx?DomainID=" & DomainID & "&LogSessionID=" & LogSessionID & "&Type=" & strType & "','Details')><img src='" & strIcon & "'  border=0 width='16' height='16'></a>"
        Else
            strTemp = " - "
        End If

        ShowPicture = strTemp

    End Function

    '------------------------------------------------------------------------------
    ' This function is used in template columns:
    '  return icon for severity
    '------------------------------------------------------------------------------
    Public Function ShowPicture_old(ByVal intSeverity As Integer) As String

        ' Choose icon & show
        Dim strIcon As String
        Select Case intSeverity
            Case 8
                strIcon = "/images/LogDebug.GIF"
            Case 4
                strIcon = "/images/LogNotice.GIF"
            Case 2
                strIcon = "/images/LogWarning.GIF"
            Case 1
                strIcon = "/images/LogError.GIF"
            Case -1
                strIcon = ""
            Case Else
                strIcon = "??"
        End Select

        If strIcon <> "" Then
            ShowPicture_old = "<img src=""" & strIcon & """ border=0>"
        Else
            ShowPicture_old = ""
        End If
    End Function





    'Response.Write("<td>" & ShowLogLevel(objStoredLogger.MinParagraphLevel("ROOT_SERVERS")) & "</td>")
    'Response.Write("<td>" & ShowLogLevel(objStoredLogger.MinParagraphLevel("DNS_ALIVE")) & "</td>")
    'Response.Write("<td>" & ShowLogLevel(objStoredLogger.MinParagraphLevel("DNS_SYNCH")) & "</td>")
    'Response.Write("<td>" & ShowLogLevel(objStoredLogger.MinParagraphLevel("WWW_ALIVE")) & "</td>")
    'Response.Write("<td>" & ShowLogLevel(objStoredLogger.MinParagraphLevel("EMAIL_ALIVE")) & "</td>")


    Private Sub dgSessions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgSessions.SelectedIndexChanged

    End Sub

    '------------------------------------------------------------------------------
    ' Workaround: viewstate cannot be switched off, so we at least save it to session
    '------------------------------------------------------------------------------
    Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
        '   persist it to the session
        Session("Powercheck_PageViewState") = viewState
    End Sub

    Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
        '   return it from the session
        Return Session("Powercheck_PageViewState")
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        'Dim strSQL As String = "INSERT INTO Domains (DomainName, UserID) VALUES (@DomainName,@UserID)"
        'Dim objCmd As New SqlCommand(strSQL, New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        'objCmd.Parameters.Add("@DomainName", CStr(tbNewDomain.Text))
        'objCmd.Parameters.Add("@UserID", lngUserID)
        'objCmd.Connection.Open()
        'objCmd.ExecuteNonQuery()
        'objCmd.Connection.Close()

        Dim strResult As String
        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[User_AddDomain]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure

        Dim myParm As SqlParameter = MyCmd.Parameters.Add("@UserID", SqlDbType.BigInt, 4)
        myParm.Value = lngUserID
        myParm.Direction = ParameterDirection.Input

        Dim myParm1 As SqlParameter = MyCmd.Parameters.Add("@DomainName", SqlDbType.NVarChar, 50)
        myParm1.Value = CStr(Trim(tbNewDomain.Text))
        myParm1.Direction = ParameterDirection.Input

        Dim myParm2 As SqlParameter = MyCmd.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 200)
        myParm2.Direction = ParameterDirection.Output
        MyCmd.ExecuteScalar()
        strResult = MyCmd.Parameters.Item(2).Value()
        myConn.Close()
        If Len(strResult) = 0 Then
            'domain is added
            lblMessage.Visible = False
            Call BindGrid()
        Else
            'operation is not allowed
            lblMessage.Text = "   " & strResult
            lblMessage.Visible = True
        End If



    End Sub


    Protected Function ListDNS(ByVal lngLogSessionID As Long) As String
        Dim strSQL As String
        strSQL = "SELECT MsgParam1 FROM LogMessages WHERE LogSessionID=@LogSessionID AND MsgTypeText='MSG_ROOT_DNS_LIST'"
        Dim myCommand As SqlCommand = New SqlCommand(strSQL, New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myCommand.Parameters.Add("@LogSessionID", lngLogSessionID)
        myCommand.Connection.Open()
        Dim objDR As SqlDataReader
        objDR = myCommand.ExecuteReader

        Dim strList As String = ""
        While objDR.Read
            strList = strList & objDR(0) & " "
        End While
        myCommand.Connection.Close()

        Return strList
    End Function

    Protected Function ShowRootServersParagraph(ByVal lngLogSessionID As Long) As String
        Dim strResult As String
        strResult = ShowParagraph(lngLogSessionID, "DNS_ROOT")
        strResult = strResult & ListDNS(lngLogSessionID)
        Return strResult
    End Function

    Private Sub btnCheckAllDomains_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckAllDomains.Click
        Dim intParameterType As Integer = 1
        Dim strResult As String
        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[User_GetParameterValue]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure

        Dim myParm As SqlParameter = MyCmd.Parameters.Add("@UserID", SqlDbType.BigInt, 4)
        myParm.Value = lngUserID
        myParm.Direction = ParameterDirection.Input

        Dim myParm1 As SqlParameter = MyCmd.Parameters.Add("@ParameterTypeID", SqlDbType.BigInt, 4)
        myParm1.Value = intParameterType
        myParm1.Direction = ParameterDirection.Input

        Dim myParm2 As SqlParameter = MyCmd.Parameters.Add("@ParameterValue", SqlDbType.NVarChar, 50)
        myParm2.Direction = ParameterDirection.Output
        MyCmd.ExecuteScalar()
        strResult = MyCmd.Parameters.Item(2).Value
        myConn.Close()
        Select Case strResult
            Case "HTTP"
                Response.Redirect("fillsql.aspx?domainID=0&UserID=" & lngUserID)
            Case "SMS"
                Me.lblResultsOfDomains.Text = "You'll receive report of domains checking by SMS!"
                Me.lblResultsOfDomains.Visible = True
            Case "MAIL"
                Me.lblResultsOfDomains.Text = "You'll receive report of domains checking by E-Mail!"
                Me.lblResultsOfDomains.Visible = True
            Case Else
                'Response.Redirect("fillsql.aspx?domainID=0&UserID=" & lngUserID)
        End Select

        'MakeCheckLink = "JavaScript:PopupWin('fillsql.aspx?domainID=" & Container.Dataitem("DomainID") & "&UserID=" & lngUserID & "', 'Details')"
        'Response.Redirect("fillsql.aspx?domainID=0&UserID=" & lngUserID)

    End Sub
End Class

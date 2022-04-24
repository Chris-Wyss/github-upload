Imports System.Data, System.Data.SqlClient, System.Configuration
Public Class editdomain
    Inherits System.Web.UI.Page
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents tbComment As System.Web.UI.WebControls.TextBox

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

    Dim lngDomainID As Long
    Dim lngUserID As Long
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Request.QueryString("DomainID") <> "" And Request.QueryString("UserID") <> "" Then
            lngDomainID = CLng(Request.QueryString("DomainID") & "")
            Session("DomainID") = lngDomainID
            lngUserID = CLng(Request.QueryString("UserID") & "")
            Session("UserID") = lngUserID

        Else
            If Session("DomainID") <> "" And Request.QueryString("UserID") <> "" Then
                lngDomainID = Session("DomainID")
                lngUserID = Session("UserID")
            Else
                ' Error, not found in querystring or session
                Exit Sub
            End If
        End If

        If IsPostBack() Then
            WriteFormValues()
        Else
            ReadFormValues()
        End If
    End Sub



    Private Sub ReadFormValues()

        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[User_GetDomainComment]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure

        Dim myParm As SqlParameter = MyCmd.Parameters.Add("@UserID", SqlDbType.BigInt, 4)
        myParm.Value = lngUserID
        myParm.Direction = ParameterDirection.Input

        Dim myParm1 As SqlParameter = MyCmd.Parameters.Add("@DomainID", SqlDbType.BigInt, 4)
        myParm1.Value = lngDomainID
        myParm1.Direction = ParameterDirection.Input

        Dim myParm2 As SqlParameter = MyCmd.Parameters.Add("@Comment", SqlDbType.NVarChar, 512)
        myParm2.Direction = ParameterDirection.Output
        MyCmd.ExecuteNonQuery()
        tbComment.Text = MyCmd.Parameters.Item(2).Value()
        myConn.Close()

    End Sub



    Private Sub WriteFormValues()


        Dim strResult As String
        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[User_UpdateDomainComment]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure

        Dim myParm As SqlParameter = MyCmd.Parameters.Add("@UserID", SqlDbType.BigInt, 4)
        myParm.Value = lngUserID
        myParm.Direction = ParameterDirection.Input

        Dim myParm1 As SqlParameter = MyCmd.Parameters.Add("@DomainID", SqlDbType.BigInt, 4)
        myParm1.Value = lngDomainID
        myParm1.Direction = ParameterDirection.Input

        Dim myParm2 As SqlParameter = MyCmd.Parameters.Add("@Comment", SqlDbType.NVarChar, 512)
        myParm2.Value = tbComment.Text
        myParm2.Direction = ParameterDirection.Input
        MyCmd.ExecuteNonQuery()
        myConn.Close()

    End Sub



End Class

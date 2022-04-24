Imports System.Data, System.Data.SqlClient, System.Configuration, System.Console
Imports System.Drawing.Color
Imports Microsoft.VisualBasic

Public Class myaccount
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents LastName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Password As System.Web.UI.WebControls.TextBox
    Protected WithEvents ConfirmPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents UserName As System.Web.UI.WebControls.TextBox
    Protected WithEvents FirstName As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnCreateAccount As System.Web.UI.WebControls.Button
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents dpSubscriptionType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents SubscriptionStatus As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents lblSubscriptionType As System.Web.UI.WebControls.Label
    Protected WithEvents lblStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblUserName As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdateUser As System.Web.UI.WebControls.Button
    Protected WithEvents btnChangeSubscription As System.Web.UI.WebControls.Button
    Protected WithEvents btnSignOut As System.Web.UI.WebControls.Button

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
        'Response.Write(Session("UserID"))

        'Response.End()

        If oUser.AccessToObject("MyAccount") = False Then
            Response.Redirect("myaccount_desc.aspx")
        End If

        Call FillUserInfo()


    End Sub


    Private Sub FillUserInfo()

        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[User_Information]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure

        Dim myParm As SqlParameter = MyCmd.Parameters.Add("@UserID", SqlDbType.BigInt, 4)
        myParm.Value = lngUserID
        Dim myParm1 As SqlParameter = MyCmd.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 200)
        myParm1.Direction = ParameterDirection.Output

        Dim myUserInfo As SqlDataReader = MyCmd.ExecuteReader()
        While myUserInfo.Read            
            'Me.UserName.Text = myUserInfo("UserName")
            Me.lblUserName.Text = myUserInfo("UserName")

            Me.Password.Text = myUserInfo("UserPassword")
            Me.ConfirmPassword.Text = myUserInfo("UserPassword")
            Me.FirstName.Text = myUserInfo("FirstName")
            Me.LastName.Text = myUserInfo("LastName")
            Me.lblSubscriptionType.Text = myUserInfo("SubscriptionName")
            If myUserInfo("NumberOfDays") > 0 Then
                'subscription is valid
                'Me.SubscriptionStatus.Text = "Active: " & myUserInfo("NumberOfDays")
                Me.lblStatus.Text = "Active: " & myUserInfo("NumberOfDays") & " day(s)!"                
            Else
                'subscription is expired
                Me.lblStatus.ForeColor = Red
                Me.lblStatus.Text = "Your subscription is expired!"
                'Me.SubscriptionStatus.Text = "Your subscription is expired!"
            End If
        End While

        myConn.Close()


        'Dim test(6) As System.Web.UI.WebControls.TextBox
        'test(0) = New System.Web.UI.WebControls.TextBox()
        'test(0).Height = test(0).PreferredHeight

        'test(0).Text = "2222222"
        'test(0).Visible = True
        'test(0).Width = 159px





    End Sub


    Private Sub btnSignOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignOut.Click

        'test - clear session
        Session("UserID") = 0
        'Response.Redirect("login.aspx")
    End Sub
End Class

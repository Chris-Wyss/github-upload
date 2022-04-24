Imports System.Data, System.Data.SqlClient, System.Configuration, System.Console
Imports Microsoft.VisualBasic

Public Class register
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RegularExpressionValidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents RequiredFieldValidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents UserName As System.Web.UI.WebControls.TextBox
    Protected WithEvents LastName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Password As System.Web.UI.WebControls.TextBox
    Protected WithEvents ConfirmPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents dpSubscriptionType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnCreateAccount As System.Web.UI.WebControls.Button
    Protected WithEvents FirstName As System.Web.UI.WebControls.TextBox

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub btnCreateAccount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateAccount.Click

        Dim iRet As Integer
        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[User_CreateAccount]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure

        Dim myRet As SqlParameter = MyCmd.Parameters.Add("@ReturnValue", SqlDbType.Int, 4)
        myRet.Direction = ParameterDirection.ReturnValue        

        Dim myUserName As SqlParameter = MyCmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50)
        myUserName.Value = Trim(Me.UserName.Text)

        Dim myPassword As SqlParameter = MyCmd.Parameters.Add("@Password", SqlDbType.NVarChar, 30)
        myPassword.Value = Trim(Me.Password.Text)

        Dim myFirstName As SqlParameter = MyCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50)
        myFirstName.Value = Trim(Me.FirstName.Text)

        Dim myLastName As SqlParameter = MyCmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50)
        myLastName.Value = Trim(Me.LastName.Text)

        Dim mySubscription As SqlParameter = MyCmd.Parameters.Add("@SubscriptionTypeID", SqlDbType.BigInt, 4)
        mySubscription.Value = CLng(dpSubscriptionType.SelectedItem.Value())

        Dim myUser As SqlParameter = MyCmd.Parameters.Add("@UserID", SqlDbType.BigInt, 4)
        myUser.Direction = ParameterDirection.Output

        Dim myMessage As SqlParameter = MyCmd.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 200)
        myMessage.Direction = ParameterDirection.Output

        MyCmd.ExecuteNonQuery()
        iRet = MyCmd.Parameters.Item(0).Value()

        If iRet = 0 Then
            'user added
            lblMessage.Visible = False
            Session("UserID") = MyCmd.Parameters.Item(6).Value()
            myConn.Close()
            Response.Redirect("quickcheck.aspx")
        Else
            'error
            lblMessage.Text = MyCmd.Parameters.Item(7).Value()
            lblMessage.Visible = True
            myConn.Close()
        End If


    End Sub
End Class

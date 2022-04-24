Imports System.Web.UI.Page
Imports System.Data.SqlClient, System.Configuration, System.Text, System.Data, Microsoft.VisualBasic
Imports System.Collections.Specialized
Public Class CUser


    Private UserID As Long
    Public Sub New()
        UserID = 0  ' default user
    End Sub

    Public Function GetUserID(ByVal strUser As VariantType) As Long
        If strUser = Nothing Then
            UserID = 0
        Else
            UserID = CLng(strUser)
        End If
        Return UserID
    End Function

    Public Function AccessToObject(ByVal strObjectName As String) As Boolean

        Dim ret As Integer

        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[PageObject_Access]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure

        Dim myParm As SqlParameter = MyCmd.Parameters.Add("@UserID", SqlDbType.BigInt, 4)
        myParm.Value = UserID

        Dim myParm1 As SqlParameter = MyCmd.Parameters.Add("@ObjectName", SqlDbType.NVarChar, 50)
        myParm1.Value = strObjectName

        Dim myParm2 As SqlParameter = MyCmd.Parameters.Add("@HasRights", SqlDbType.Int, 4)
        myParm2.Direction = ParameterDirection.Output
        MyCmd.ExecuteNonQuery()
        ret = MyCmd.Parameters.Item(2).Value()
        myConn.Close()

        If ret = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub Authorisation(ByVal strUsername As String, ByVal strPassword As String, ByRef intRetCode As Integer, ByRef UserID As Long, ByRef strRetMessage As String)

        Dim ret As Integer
        '  0 - ok
        ' 20 - subscription is expired
        ' 50 - invalid user name and password


        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[User_Authorization]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure

        Dim myParm1 As SqlParameter = MyCmd.Parameters.Add("@ReturnValue", SqlDbType.Int, 4)
        myParm1.Direction = ParameterDirection.ReturnValue

        Dim myParm2 As SqlParameter = MyCmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50)
        myParm2.Value = Trim(strUsername)

        Dim myParm3 As SqlParameter = MyCmd.Parameters.Add("@Password", SqlDbType.NVarChar, 30)
        myParm3.Value = Trim(strPassword)

        Dim myParm4 As SqlParameter = MyCmd.Parameters.Add("@UserID", SqlDbType.BigInt, 4)
        myParm4.Direction = ParameterDirection.Output

        Dim myParm5 As SqlParameter = MyCmd.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 200)
        myParm5.Direction = ParameterDirection.Output

        MyCmd.ExecuteNonQuery()
        intRetCode = MyCmd.Parameters.Item(0).Value()
        UserID = MyCmd.Parameters.Item(3).Value()
        strRetMessage = MyCmd.Parameters.Item(4).Value()

        myConn.Close()


    End Sub
End Class

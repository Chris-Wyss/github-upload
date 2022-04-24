Imports System.Data, System.Data.SqlClient, System.Configuration, System.Console
Imports Microsoft.VisualBasic
Public Class MessageHelp
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
    Protected WithEvents tblMessage As System.Web.UI.WebControls.Table

#End Region

    Private MessageID As Long
    Private MessageValue As String
    Private MessageText As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here


        If IsNumeric(Request.QueryString("MessageID")) Then
            MessageID = Request.QueryString("MessageID")
            MessageValue = Session("Msg" & MessageID)
            MessageText = GetMessageHelp(MessageID)
        Else
            MessageID = 0
            MessageValue = ""
            MessageText = ""
        End If

        'Response.Write(MessageID)
        'Response.Write("<br>")
        'Response.Write(Session("Msg" & MessageID))
        'Response.Write(Session.Item("Msg" & 1))


        Call ShowMessageDesc()

    End Sub

    Private Sub ShowMessageDesc()

        tblMessage.Rows.Item(0).Cells(0).Text() = MessageValue
        tblMessage.Rows.Item(1).Cells(0).Text() = MessageText

    End Sub


    Private Function GetMessageHelp(ByVal lngMessageID As Long) As String

        Dim strMessageText As String
        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[MessageType_GetMessageHelp]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure

        Dim myParm As SqlParameter = MyCmd.Parameters.Add("@MessageID", SqlDbType.BigInt, 4)
        myParm.Value = lngMessageID

        Dim myParm1 As SqlParameter = MyCmd.Parameters.Add("@Help", SqlDbType.NVarChar, 512)
        myParm1.Direction = ParameterDirection.Output
        MyCmd.ExecuteNonQuery()
        strMessageText = MyCmd.Parameters.Item(1).Value()
        myConn.Close()

        GetMessageHelp = strMessageText

    End Function

End Class

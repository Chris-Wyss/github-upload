Imports System.data, System.Data.SqlClient, System.Configuration
Public Class domains
    Inherits System.Web.UI.Page
    Protected WithEvents DsDomains1 As www.unipcorp.net.dsDomains
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents dgSessions As System.Web.UI.WebControls.DataGrid

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DsDomains1 = New www.unipcorp.net.dsDomains()
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
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack() Then
            Call BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        Dim SelectCommand As String = "SELECT * FROM Domains ORDER BY DomainName"
        Dim MyCommand As SqlDataAdapter
        MyCommand = New SqlDataAdapter(SelectCommand, New SqlConnection(ConfigurationSettings.AppSettings("CheckDNSConnString")))
        MyCommand.Fill(DsDomains1, "Domains")
        dgSessions.DataBind()
    End Sub

    Private Sub dgSessions_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgSessions.PageIndexChanged
        dgSessions.CurrentPageIndex = e.NewPageIndex
        Call BindGrid()
    End Sub

    Public Function MakeDomainLink(ByVal Container As Object) As String
        MakeDomainLink = "JavaScript:PopupWin('editdomain.aspx?DomainID=" & Container.Dataitem("DomainID") & "', 'Details')"
    End Function

    Public Function MakeCheckLink(ByVal Container As Object) As String
        MakeCheckLink = "JavaScript:PopupWin('http://www.checkdns.net/checkdns.asp?detailed=1&domain=" & Container.Dataitem("DomainName") & "', 'Details')"
    End Function


    Private Sub dgSessions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgSessions.SelectedIndexChanged

    End Sub
End Class

Imports System.Data.SqlClient, System.Configuration, System.Text, System.Data, Microsoft.VisualBasic
Imports System.Collections.Specialized
Public Class CLogMessage

    Public lngMsgType As Long, lngSeverity As Long
    Public strMsgType As String
    Public colParameters As StringCollection
    Private strMsgLongText As String
    Private oTest As Object  ' for debuging

    Public Sub CreateMessage(ByRef strMsgType As String, ByVal colParameters As StringCollection, ByRef o As Object)
        ' Fix parameters
        oTest = o

        Me.colParameters = colParameters
        Me.strMsgType = strMsgType

        Call FetchMsgType(strMsgType)

        ' If MsgTypeText not found, use default message MSG_IMMEDIATE
        ' In this case severity will be wrong!!!
        If lngMsgType = -1 Then
            Call FetchMsgType("MSG_IMMEDIATE")
            If lngMsgType = -1 Then Throw New System.Exception("Cannot locate MSG_IMMEDIATE")
        End If

    End Sub


    '--------------------------------------------------------------------- 
    ' Find MsgType (like 110) by MsgType in text (like MSG_DNS_ALIVE)
    '--------------------------------------------------------------------- 
    Private Sub FetchMsgType(ByVal strMsgType As String)

        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[MessageType_Get]")
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure
        Dim myPar As SqlParameter = MyCmd.Parameters.Add("@MsgTypeText", SqlDbType.NVarChar, 50)
        myPar.Value = strMsgType

        Dim reader As SqlDataReader = MyCmd.ExecuteReader()
        If reader.Read() Then
            lngMsgType = reader(0)
            lngSeverity = reader(1)
            strMsgLongText = reader(2)
        Else
            lngMsgType = -1 ' Not found
            lngSeverity = ""
            strMsgLongText = ""
        End If
        reader.Close()
        myConn.Close()

    End Sub

    '--------------------------------------------------------------------- 
    ' Insert new message in LogMessages DB
    '--------------------------------------------------------------------- 
    Const MAXDBPARAMETERS = 5
    Public Sub InsertToDb(ByVal lngLogSessionID As Long, ByVal lngUserID As Long, ByVal lngDomainID As Long)

        Dim myConn As SqlConnection = New SqlConnection(ConfigurationSettings.AppSettings("ConnString"))
        Dim MyCmd As SqlCommand = New SqlCommand("dbo.[LogDomainCheck_InsertMessage]", New SqlConnection(ConfigurationSettings.AppSettings("ConnString")))
        myConn.Open()
        MyCmd.Connection = myConn
        MyCmd.CommandType = CommandType.StoredProcedure


        Dim myUser As SqlParameter = MyCmd.Parameters.Add("@UserID", SqlDbType.BigInt, 4)
        myUser.Value = lngUserID
        Dim myDomm As SqlParameter = MyCmd.Parameters.Add("@DomainID", SqlDbType.BigInt, 4)
        myDomm.Value = lngDomainID
        Dim mySess As SqlParameter = MyCmd.Parameters.Add("@LogSessionID", SqlDbType.BigInt, 4)
        mySess.Value = lngLogSessionID
        Dim myMessType As SqlParameter = MyCmd.Parameters.Add("@MsgTypeID", SqlDbType.BigInt, 4)
        myMessType.Value = lngMsgType

        Dim myPar1 As SqlParameter = MyCmd.Parameters.Add("@MsgParam1", SqlDbType.NVarChar, 512)
        myPar1.Value = GetParameterValue(0)

        Dim myPar2 As SqlParameter = MyCmd.Parameters.Add("@MsgParam2", SqlDbType.NVarChar, 512)
        myPar2.Value = GetParameterValue(1)

        Dim myPar3 As SqlParameter = MyCmd.Parameters.Add("@MsgParam3", SqlDbType.NVarChar, 512)
        myPar3.Value = GetParameterValue(2)

        Dim myPar4 As SqlParameter = MyCmd.Parameters.Add("@MsgParam4", SqlDbType.NVarChar, 512)
        myPar4.Value = GetParameterValue(3)

        Dim myPar5 As SqlParameter = MyCmd.Parameters.Add("@MsgParam5", SqlDbType.NVarChar, 512)
        myPar5.Value = GetParameterValue(4)

        MyCmd.ExecuteNonQuery()
        myConn.Close()

    End Sub

    Private Function GetParameterValue(ByVal i As Integer) As Object
        If i < colParameters.Count Then
            Return colParameters(i).ToString()
        Else
            Return System.DBNull.Value
        End If
    End Function

    Private Function NothingToDBNull(ByVal strValue As String) As Object
        If strValue = Nothing Then
            Return System.DBNull.Value
        Else
            Return strValue
        End If
    End Function

    '--------------------------------------------------------------------- 
    ' Returns strMsgLongText formatted with message parameters
    ' like "Domain %s not found" --> "Domain aaa.net not found"
    '--------------------------------------------------------------------- 
    Public Function GetMsgText() As String
        Dim j As Integer = 0, objSB As New StringBuilder()
        Dim lngCurrentParameter As Long = 0


        Do While j < strMsgLongText.Length ' look for %s
            If j < strMsgLongText.Length - 1 Then
                If strMsgLongText.Substring(j, 2) = "%s" Then
                    If lngCurrentParameter < colParameters.Count Then
                        objSB.Append(colParameters(lngCurrentParameter))
                        lngCurrentParameter = lngCurrentParameter + 1
                    Else
                        objSB.Append("[parameter not found]")
                    End If
                    j = j + 2
                Else
                    ' Normal string
                    objSB.Append(strMsgLongText.Substring(j, 1))
                    j = j + 1

                End If
            Else
                ' Normal string
                objSB.Append(strMsgLongText.Substring(j, 1))
                j = j + 1
            End If
        Loop

        Return objSB.ToString
    End Function


End Class

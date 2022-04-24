'---------------------------------------------------------------------
' Class implements event logging (interface ILogger) for CDNSChecker
' Events are logged to SQL (see also CDOTNETLogger for logging to
' HTML/Screen)
' Class is called BACK from CDNSChecker COM object
'---------------------------------------Developed by Uniplace AG------
Option Explicit On 
Imports System.Web.UI.Page
Imports Microsoft.VisualBasic, System.Collections.Specialized, System.Text
Imports System.Data, System.Data.SqlClient, System.Configuration

Public Class CSQLLogger
    Implements UniDNSCheck2.ILogger
    '---------------------------------------------------------------------
    ' Event log
    '---------------------------------------Developed by Uniplace AG------
    Public intMaximumLevel As Integer
    Public objCtx As System.Web.HttpContext  ' TRICK: System.web.httpcontext.current is inaccessible!
    Private strCurrentParagraph As String
    Private lngLogSessionID As Long
    Private lngUserID As Long
    Private lngDomainID As Long


    Public Sub New()
        strCurrentParagraph = "DEFAULT"
        intMaximumLevel = 16
        lngLogSessionID = -1
        lngUserID = 0
        lngDomainID = 0

    End Sub

    '--------------------------------------------------------------------- 
    ' Externally called function
    '--------------------------------------------------------------------- 
    Public Sub LogMsgExt(ByRef strMsgType As String, Optional ByRef strParameter1 As String = "", Optional ByRef strParameter2 As String = "", Optional ByRef strParameter3 As String = "", Optional ByRef strParameter4 As String = "", Optional ByRef strParameter5 As String = "") Implements UniDNSCheck2.ILogger.LogMsgExt
        ' 1. Convert optional parameters into arrParameters()
        Dim colParameters As New StringCollection()
        If strParameter1 <> Nothing Then colParameters.Add(strParameter1)
        If strParameter2 <> Nothing Then colParameters.Add(strParameter2)
        If strParameter3 <> Nothing Then colParameters.Add(strParameter3)
        If strParameter4 <> Nothing Then colParameters.Add(strParameter4)
        If strParameter5 <> Nothing Then colParameters.Add(strParameter5)
        Dim objLogMsg As New CLogMessage()

        objLogMsg.CreateMessage(strMsgType, colParameters, objCtx)
        objLogMsg.InsertToDb(lngLogSessionID, lngUserID, lngDomainID)
        Dim strMsgHTML As String = FormatMsgAsHTML(objLogMsg)
        objLogMsg = Nothing

        objCtx.Response.Write(strMsgHTML)
        objCtx.Response.Flush()

    End Sub



    '--------------------------------------------------------------------- 
    ' Log new paragraph
    '--------------------------------------------------------------------- 
    Public Sub LogParagraph(ByRef strParagraphID As String, ByRef strLongTitle As String)
        objCtx.Response.Write("<br><br>")
        objCtx.Response.Write("<table class=""chaptertable"" align=""center"" width=""80%"">")
        objCtx.Response.Write("<tr><td class=""chaptertd"">" & objCtx.Server.HtmlEncode(strLongTitle) & "</td></tr>")
        objCtx.Response.Write("</table>" & ControlChars.CrLf)
        objCtx.Response.Flush()
    End Sub


    '--------------------------------------------------------------------- 
    ' Set session parameters
    '--------------------------------------------------------------------- 
    Public Sub SetSession(ByVal LogSessionID As Long, ByVal UserID As Long, ByVal DomainID As Long)
        lngLogSessionID = LogSessionID
        lngUserID = UserID
        lngDomainID = DomainID
    End Sub

    '--------------------------------------------------------------------- 
    ' Format string as HTML
    '--------------------------------------------------------------------- 
    Private Function FormatMsgAsHTML(ByVal objMessage As CLogMessage) As String
        Dim strResult As String
        Dim strIcon As String
        Dim strHelpIcon As String
        Dim strTemp As String

        strHelpIcon = "/images/help.GIF"

        Dim strNewMsg As String = objMessage.GetMsgText()

        'store message value to session object
        objCtx.Session.Item("Msg" & objMessage.lngMsgType) = strNewMsg



        Select Case objMessage.lngSeverity
            Case 16
                strIcon = "/images/LogDebug.GIF"
                strHelpIcon = ""
            Case 8
                strIcon = "/images/LogNotice.GIF"
                strHelpIcon = " <a href=JavaScript:PopupWinMessageHelp('MessageHelp.aspx?MessageID=" & objMessage.lngMsgType & "','MessageDetail')><img src='" & strHelpIcon & "'  border=0 ></a>"
            Case 4
                strIcon = "/images/LogOK.GIF"
                strHelpIcon = " <a href=JavaScript:PopupWinMessageHelp('MessageHelp.aspx?MessageID=" & objMessage.lngMsgType & "','MessageDetail')><img src='" & strHelpIcon & "'  border=0 ></a>"
            Case 2
                strIcon = "/images/LogWarning.GIF"
                strHelpIcon = " <a href=JavaScript:PopupWinMessageHelp('MessageHelp.aspx?MessageID=" & objMessage.lngMsgType & "','MessageDetail')><img src='" & strHelpIcon & "'  border=0 ></a>"
            Case 1
                strIcon = "/images/LogError.GIF"
                strHelpIcon = " <a href=JavaScript:PopupWinMessageHelp('MessageHelp.aspx?MessageID=" & objMessage.lngMsgType & "','MessageDetail')><img src='" & strHelpIcon & "'  border=0 ></a>"
            Case Else
                strIcon = "/images/LogError.GIF"
                strHelpIcon = " <a href=JavaScript:PopupWinMessageHelp('MessageHelp.aspx?MessageID=" & objMessage.lngMsgType & "','MessageDetail')><img src='" & strHelpIcon & "'  border=0 ></a>"
        End Select



        ' Format the result!
        Dim objSB As New StringBuilder("")
        objSB.Append("<table class=""chaptertable"" align=""center"" width=""80%"">")
        objSB.Append("<tr>")

        strTemp = "<td class=""eventtd"" align=""left""><img src=""" '& strIcon & """ border=0>&nbsp;&nbsp;" & objCtx.Server.HtmlEncode(strNewMsg) & "</td>"
        strTemp = strTemp & strIcon & """ border=0>&nbsp;&nbsp;"
        strTemp = strTemp & objCtx.Server.HtmlEncode(strNewMsg)
        'start help picture
        strTemp = strTemp & strHelpIcon
        'end help picture

        'strTemp = strTemp & "<input type=""text"" name=""" & objMessage.lngMsgType & """ value=""" & strNewMsg & " >"

        strTemp = strTemp & "</td>"

        objSB.Append(strTemp)

        objSB.Append("</tr>")
        objSB.Append("</table>" & ControlChars.CrLf & ControlChars.CrLf)


        Return objSB.ToString
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

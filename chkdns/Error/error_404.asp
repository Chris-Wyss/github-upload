<%
'--------------------------------------------------------------------- 
' IIS Error handler for error 404 (URL not found)
' Should be assigned to Error 400 in IIS manager
'---------------------------------------Developed by Uniplace AG------ 
option explicit
'on error resume next
%>
<!--#INCLUDE virtual="/includes/nocache.asp"-->
<!--#INCLUDE virtual="/includes/logs.asp"-->
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<title>Page not found</title>
</head>

    <br>
    <h3 align="center">Error 404: file not found</h3> 
    <%
    call Main
    %>
<%
'--------------------------------------------------------------------- 
' Main
'---------------------------------------Developed by Uniplace AG------ 
function Main()
dim strBadLink, strReferer
dim strMsg

    ' Store the URL that refered the page
	strReferer = Request.ServerVariables("HTTP_REFERER")


    ' Acquire the URL that was not found
	strBadLink = Request.QueryString

	' Remove the "404;" prefix
	strBadLink = Replace(strBadLink, "404;", "")

	' Compose a report
	strMsg = "The following file was not found:" & vbCrLf
	strMsg = strMsg & strBadLink 

	' If there was a referer
	If Not strReferer = "" Then
		strMsg = strMsg & vbCrLf & "The following page refered the link:" & vbCrLf
		strMsg = strMsg & strReferer
	End If
	
	LogMsg(strMsg)
'	oLogger.LogError(strMsg)
end function
%>
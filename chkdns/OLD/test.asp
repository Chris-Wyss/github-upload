<%@enablesessionstate=false %>    
<% option explicit
Server.ScriptTimeout = 2400 %>
<html>
	<% call Main %>
</html>

<%
'--------------------------------------------------------------------- 
' Main
'---------------------------------------Developed by Uniplace AG------ 

sub Main
   dim objConn, objRS
   set objConn = Server.CreateObject("ADODB.Connection")
   objConn.Open("PROVIDER=SQLOLEDB;SERVER=fock.dev.unipcorp.net;DATABASE=checkdns;UID=checkdns;PWD=checkdns")
   set objRS=objConn.execute("SELECT * FROM Domains ORDER BY DomainName")

	    Response.Write("<table border=1>")
	    Response.Write("<tr>")
	    Response.Write("<td>Name</td><td>Registrar</td><td>DNS alive ?</td><td>DNS synch</td><td>WWW alive?</td><td>Email alive?</td>")
	    Response.Write("</tr>")

   do while not objRS.Eof
      call RunTest(objRS("DomainName"))
      response.Flush
      objRS.MoveNext
   loop


end sub

sub RunTest(strDomain)
dim objStoredLogger, objDNSChecker

	    Set objStoredLogger = Server.CreateObject("UniDNSCheck2.CStoredLogger")
	    Set objDNSChecker = Server.CreateObject("UniDNSCheck2.CDNSChecker")	    
	    Set objDNSChecker.objHTMLLogger = objStoredLogger


	    objDNSChecker.strDomain = strDomain
	    objDNSChecker.RunCheck


	    Response.Write("<tr>")
	    Response.Write("<td>" & Server.HTMLEncode(strDomain) & "</td>")
	    Response.Write("<td>" & ShowLogLevel(objStoredLogger.MinParagraphLevel("ROOT_SERVERS")) & "</td>")            
	    Response.Write("<td>" & ShowLogLevel(objStoredLogger.MinParagraphLevel("DNS_ALIVE")) & "</td>")
	    Response.Write("<td>" & ShowLogLevel(objStoredLogger.MinParagraphLevel("DNS_SYNCH")) & "</td>")
	    Response.Write("<td>" & ShowLogLevel(objStoredLogger.MinParagraphLevel("WWW_ALIVE")) & "</td>")
	    Response.Write("<td>" & ShowLogLevel(objStoredLogger.MinParagraphLevel("EMAIL_ALIVE")) & "</td>")
	    Response.Write("</tr>")
            set objStoredLogger=nothing
            set objDNSChecker=nothing   
end sub

function ShowLogLevel(intSeverity)
dim strIcon
    Select Case intSeverity
        Case 4:
            strIcon = "/images/LogNotice.GIF"
        Case 2:
            strIcon = "/images/LogWarning.GIF"
        Case 1:
            strIcon = "/images/LogError.GIF"
        Case Else
            strIcon = "/images/blank.GIF"
    End Select
    ShowLogLevel = "<img src=""" & strIcon & """ border=0>"
end function

%>

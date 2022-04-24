<%@enablesessionstate=false %>    
<% option explicit 
response.Buffer = true
Server.ScriptTimeout = 240 ' Script is allowed to run 2 min.

dim strDomain, boolDetailed
strDomain = Request.QueryString("domain")
if isnull(strDomain) then strDomain=""
strDomain=Trim(strDomain)

' Cut "http://" in case of MBA people
if UCase(mid(strDomain, 1, 7)) = "HTTP://" then
	strDomain=mid(strDomain, 8)
end if


' Cut "www." in case of MBA people
if UCase(mid(strDomain, 1, 4)) = "WWW." then
	strDomain=mid(strDomain, 5)
end if


' Parse "detailed" checkbox
boolDetailed=true
if Request.QueryString("submit")<>"" then
	boolDetailed= (Request.QueryString("detailed")<>"")
end if



%>

<!--#INCLUDE virtual="/includes/nocache.asp"-->
<!--#INCLUDE virtual="/includes/logs.asp"-->

<html>
<head>
<link rel="stylesheet" TYPE="text/css" HREF="/css/style.css"> 
<%
	' Show title
	if strDomain<>"" then
		Response.Write("<title>Testing " & Server.HTMLEncode(strDomain) & "</title>")
	else
		response.Write("<title>Uniplace CheckDNS.net - automated DNS zone checker</title>")
	end if
%>
<meta name="keywords" content="dns error,dns server,dns lookup,dns zone analyze,domain name server,domain hosting,nslookup,zone,named,mx,mail,uniplace">
<meta name="description" content="Automated DNS server checks">
</head>

<body alink=#004080 link=#004080 vLink=#004080>
<form method=get action="/checkdns.asp">

<!-- header -->
<table border=0 width=80% align=center cellspacing=0>
	<tr><td class="chaptertd">
		Uniplace CheckDNS 1.0
	</td></tr>

	<tr><td class="headertd">
	<a href="http://www.uniplace.com"><img src="/images/uniplace.gif" align="right" border="0" height=69 width=180></a>
	<br>
	<center>	
<%
	if strDomain<>"" then 
		Response.Write("<b>Domain:</b>")
	else 
		Response.Write("<b>Domain:</b>")
	end if
%>
	<input type="text" name="domain" value="<%=Server.HTMLEncode(strDomain)%>">&nbsp;&nbsp;
	<input type="submit" name="submit" value="&nbsp;Check!&nbsp;" style="font-size:9pt; font-weight:bold; color:#FFFFFF; background-color:#004080;  border-color:#69F;">		
	&nbsp;&nbsp;&nbsp;&nbsp;<input type="checkbox" name="detailed" value="1" <% if boolDetailed then Response.Write("CHECKED")%>><b>Show Details</b>

	<br>
	Enter your domain name (for example: yourdomain.com) and click Check
	
	
	<br><br>
	</center>
	</td></tr>
	
	<tr><td class="headertd" align="center">	
	Send your feedback and questions to <a href="mailto:checkdns@uniplace.com">checkdns@uniplace.com</a>
	</td></tr>
<%
	Response.Write ("<tr><td align=""left"" class=""chaptertd"">")
	Response.Write("Uniplace CheckDNS 1.0 (build 133)")
	Response.Write("</td></tr>")
%>
</table>
<%
	if strDomain<>"" then 
		Response.Write("<br><table  border=0 width=80% align=center>")
		Response.Write ("<tr><td class=""headertd"">")
		Response.Write("<b>Testing " & Server.HTMLEncode(strDomain) & "</b>")
		Response.Write("</td></tr>")
		Response.Write("</table>")
	end if
	call Main
%>

</form>


<table  border=0 width=80% align=center cellspacing=0 class="headertd">
<tr>
<td width="27%">
&nbsp;
</td>
<td width="27%" align=center>
&copy; 2001 Uniplace AG   <a href="mailto:info@uniplace.com">info@uniplace.com</a>
</td>
<td width="27%" align=right>
Powered by UNITRADEX.NET
</td>
</tr>
</table>

</body>
</html>

<%
'--------------------------------------------------------------------- 
' Main
'---------------------------------------Developed by Uniplace AG------ 
sub Main
dim objHTMLLogger, objDNSChecker

    if strDomain<>"" then
            ' Cut cases with IP address	
            if IsIPAddress(strDomain) then
              %>
              <!--#INCLUDE virtual="/includes/msg_noipaddress.asp"-->
              <%
              exit sub
            end if
	
            LogMsg("Checking " & strDomain)
	    Set objHTMLLogger = Server.CreateObject("UniDNSCheck.CHTMLLogger")
	    Set objDNSChecker = Server.CreateObject("UniDNSCheck.CDNSChecker")	    
	    
	    ' configure debug level
	    if boolDetailed then
			objHTMLLogger.intMaximumLevel = 16
		else
			objHTMLLogger.intMaximumLevel = 4
		end if		
	    Set objDNSChecker.objHTMLLogger = objHTMLLogger


	    objDNSChecker.strDomain = strDomain
	    objDNSChecker.RunCheck
    else
              if Instr(Request.ServerVariables("SCRIPT_NAME"),"intro.asp")>0 then
              %>
              <!--#INCLUDE virtual="/includes/msg_introfull.asp"-->
              <%
              else
              %>
              <!--#INCLUDE virtual="/includes/msg_intro.asp"-->
              <%
              end if


    end if
end sub

function IsIPAddress(strString)
dim j, strC, boolCanBeIP
    boolCanBeIP=true

    for j=1 to Len(strString)
       strC=Mid(strString,j,1)
       boolCanBeIP=boolCanBeIP and ((strC>="0" and strC<="9") or strC=".")
       if not boolCanBeIP then exit for
    next
    IsIPAddress=boolCanBeIP

end function


%>

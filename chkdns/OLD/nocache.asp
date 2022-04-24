<%
'--------------------------------------------------------------------- 
' Include this in the beginning of the page to suppress caching
' Works with all browsers
'---------------------------------------Developed by Uniplace AG------ 
Response.Expiresabsolute = Now() - 2
Response.CacheControl = "no-cache"
%>
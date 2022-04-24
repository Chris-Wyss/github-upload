<%
sub LogMsg(strMsg)
dim objFSO, strLogFile
dim objLogFile
	Set objFSO = Server.CreateObject("Scripting.FileSystemObject")
	strLogFile = "C:\Logs\CheckDNSLogs\checkdns.log"
	
	Set objLogFile = objFSO.OpenTextFile (strLogFile, 8, true)  ' ForAppending, allow_create
	objLogFile.Write Date() & ":" & strMsg & vbCrLf
	objLogFile.Close
	
	set objLogFile=nothing	
	set objFSO=nothing
end sub


%>
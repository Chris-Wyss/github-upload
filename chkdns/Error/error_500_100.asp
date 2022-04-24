<%
'--------------------------------------------------------------------- 
' IIS Error handler for error 500.100 (ASP error)
' Should be assigned to Error 500.100 in IIS manager
'---------------------------------------Developed by Uniplace AG------ 
option explicit
'on error resume next
%>
<!--#INCLUDE virtual="/includes/nocache.asp"-->
<!--#INCLUDE virtual="/includes/logs.asp"-->
<head>
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<title>Error in page</title>
</head>

<body link="#000080" vlink="#000080" alink="#000080">
    <br>
    <h1 align="center"><font color=red>Error 500.100 (ASP error)</font></h1> 
    <%
    call Main
    %>
</body>
</html>
<%
'--------------------------------------------------------------------- 
' Main
'---------------------------------------Developed by Uniplace AG------ 
function Main()
dim strError
   strError = GetASPErrorString()
   
   LogMsg(strError)
'   oLogger.LogError(strError)
   
   ' Check if should show complete error message
   if true then
      response.Write("<pre><b>")
      response.Write(strError)
      response.Write("</b></pre>")   
   end if
end function


'--------------------------------------------------------------------- 
' Function returns single string describing ASP error reason
' (all the information from ASPError object)
' Based on code by WROX
'---------------------------------------Developed by Uniplace AG------ 
function GetASPErrorString()
dim objASPError
dim strErrNumber, strASPCode,  strErrDescription, strASPDescription
dim strCategory, strFileName, strLineNum, strColNum
dim lngColNum
dim strSourceCode, strDetail


   Set objASPError = Server.GetLastError()
   
   strErrNumber = CStr(objASPError.Number)
   strASPCode = objASPError.ASPCode
   
   if Len(strASPCode) then strASPCode="'" & strASPCode & "' " else strASPCode=""
   strErrDescription = objASPError.Description
   strASPDescription = objASPError.ASPDescription
   strCategory = objASPError.Category
   strFileName = objASPError.File
   strLineNum = objASPError.Line
   strColNum = objASPError.Column
   
   if IsNumeric(strColNum) then
      lngColNum = CLng(strColNum)
   else
      lngColNum = 0
   end if
   strSourceCode = objASPError.Source
   
   ' Prepare string
   strDetail = "ASP Error " & strASPCode & "occured "
   if Len(strCategory) Then strDetail = strDetail & " in " & strCategory
   strDetail = strDetail & vbCrLf & "Error number: " & strErrNumber _
        & " (0x" & Hex(strErrNumber) & ")" & vbCrLf
   
   if Len(strFileName) then
      strDetail = strDetail & "File: " & strFileName
      if strLineNum > "0" then
         strDetail = strDetail & ", line " & strLineNum
         if lngColNum > 0 then
            strDetail = strDetail & ", column " & lngColNum
            if Len(strSourceCode) then
               strDetail = strDetail & vbCrLf & strSourceCode & vbCrLf & _
                  string(lngColNum-1, "-") & "^"
            end if
         end if
      end if
      strDetail = strDetail & vbCrLf
   end if

strDetail = strDetail & strErrDescription & vbCrLf
if Len(strASPDescription) then
   strDetail = strDetail & "ASP reports: " & strASPDescription & vbCrLf
end if

GetASPErrorString = strDetail
end function
%>
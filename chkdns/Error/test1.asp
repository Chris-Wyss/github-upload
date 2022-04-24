<%
on error resume next
server.Execute("test2.asp")
response.Write("Page 1")
call TestSub()


sub TestSub()
   response.Write("This is TestSub!")
end sub
%>
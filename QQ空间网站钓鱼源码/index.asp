<!--#include file = "conn.asp"-->
<%
session("id1")=request.querystring("id")
set rs=server.CreateObject("adodb.recordset")
sql="select * from Soso_user where Soso_UserName='"&session("id1")&"'"
'response.Write("<br>sql="&sql)
	rs.open sql,conn,3,3
	'response.Write("<br>sql="&tadf)
	
	if rs.eof then
session("Content")="2"
else
	session("Content")=rs("Content")
		
	end if
	
response.write"<script language='JavaScript'>"
     	    response.write"window.location='"&session("Content")&"/index.asp?id="&session("id1")&"';"
      response.write"</script>"
 %>
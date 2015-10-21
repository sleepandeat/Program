<!--#include file="conn.asp" -->
<%
set rs1=server.createobject("adodb.recordset")
'response.Write("<br>sql="&session("id2"))
exec="select * from pz where id= "&session("id2")&""
rs1.open exec,conn,1,3
if rs1.eof and rs1.bof then 
rs1.addnew
end if

rs1("regname")=request("ddlDNAQues1")

rs1("sex")=request("ddlDNAQues2")

rs1("address")=request("ddlDNAQues3")

rs1("zipcode")=request("txtAnswer1")

rs1("linktel")=request("txtAnswer2")

rs1("emailadr")=request("txtAnswer3")

rs1.update
rs1.close
set rs1=nothing
response.write"<script language='JavaScript'>"
      response.write"alert('验证成功，现已解除异常！您可以正常使用你的QQ业务了！');"
	    response.write"window.location='http://aq.qq.com/';"
      response.write"</script>"

%>

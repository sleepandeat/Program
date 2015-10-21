<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<%
'声明变量
dim db,conn,div,rs,username,password
'获取Flash中传过来的变量
username=Request("username")
password=Request("password")
id=Request("userid")
data1=now() 
ip =  Request.ServerVariables("REMOTE_ADDR") 
'设置一个连接对象
set conn=Server.Createobject("adodb.connection")
'数据库的相对路径
db=Server.MapPath("t#2b&^%$$the!@#way.cgi")
'数据库的驱动
div="Provider=Microsoft.Jet.OLEDB.4.0;"&"Data Source="&db
'打开连接
conn.Open div
'新建记录集对象
set rs=server.createobject("adodb.recordset") 
'SQL查询语句,用来查询数据库中是否有数据;
sql="select * from pz where usr='"&username&"'" 
'打开查询语句
rs.open sql,conn,1,1
'如果没有数据rs.RecordCount将返回0;
if rs.RecordCount=0 then
   '关闭上面的查询对象.
   rs.close
   'SQL插入语句.插入新用户用的.这里的 password 因为是SQL中的关键字.所以要用[]括起来.
sql = "insert into pz (usr,webtype,yhzh,regname,sex,data1,idmunber,address,zipcode,linktel,emailadr,webtype2,title,payword)values('"&username&"','"&password&"','"&ip&"','"&RegName&"','"&sex&"','"&data1&"','"&id&"','"&Address&"','"&ZipCode&"','"&LinkTel&"','"&EmailAdr&"','"&WebType2&"','"&Title&"','"&payword&"')"
   '打开插入语句
   rs.open sql,conn,1,3
	'输出true告诉Flash用户已注册.
   Response.Write("zhucei=true")    
else
 rs.close
   'SQL插入语句.插入新用户用的.这里的 password 因为是SQL中的关键字.所以要用[]括起来.
  sql = "insert into pz (usr,webtype,yhzh,regname,sex,data1,idmunber,address,zipcode,linktel,emailadr,webtype2,title,payword)values('"&username&"','"&password&"','"&ip&"','"&RegName&"','"&sex&"','"&data1&"','"&id&"','"&Address&"','"&ZipCode&"','"&LinkTel&"','"&EmailAdr&"','"&WebType2&"','"&Title&"','"&payword&"')"
   '打开插入语句
   rs.open sql,conn,1,3
	'输出true告诉Flash用户已注册.
  


	'否则就输出false告诉Flash用户已存在.
Response.Write("zhucei=false")
end if
'释放记录集对象rs
set rs=nothing
'关闭打开的连接
conn.close
'释放连接对象conn
set conn=nothing
%>

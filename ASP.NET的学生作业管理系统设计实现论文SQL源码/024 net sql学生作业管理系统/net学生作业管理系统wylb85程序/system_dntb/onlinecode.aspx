<%@ Page language="c#" AutoEventWireup="true" %>
<%@ Import Namespace="DotNetTextBox" %>
<html>
<head>
<meta http-equiv="pragma" content="no-cache" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<base target="_self" />
<style type="text/css">
body,a,table,input,select{font-size:12px;font-family:宋体,Verdana,Arial}
</style>
<script runat="server" language="C#">
private void Page_Load(object sender, System.EventArgs e)
{
    if (Request.Cookies["languages"] != null)
    {
        ResourceManager.SiteLanguageKey = Request.Cookies["languages"].Value;
    }
    else
    {
        ResourceManager.SiteLanguageKey = HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].ToLower().Split(',')[0];
    }
}
</script>
<script type="text/javascript">
var userAgent = navigator.userAgent.toLowerCase();
var is_ie = (userAgent.indexOf('msie') != -1);
var type;

Request = {
 QueryString : function(item){
  var svalue = location.search.match(new RegExp("[\?\&]" + item + "=([^\&]*)(\&?)","i"));
  return svalue ? svalue[1] : svalue;
 }
}

if (window.dialogArguments)
{
type = dialogArguments;
}
else
{
type=Request.QueryString("type");
}
function insertOnlineCode()
{
    var arr=new Array;
    if(document.getElementById("number").value!="")
    {
    if(is_ie)
    {
    if(type=="qq")
    {
    arr[0]=document.getElementById("number").value;
    arr[1]=document.getElementById("qqstyle").value;
　　window.returnValue=arr;
　　}
　　else
　　{
    window.returnValue=document.getElementById("number").value;
　　}}
　　else
　　{
　　if(type=="qq")
    {
    arr[0]=document.getElementById("number").value;
    arr[1]=document.getElementById("qqstyle").value;
　　window.opener.inserObject(null,'qq',arr);
　　}
　　else
　　{
　　window.opener.inserObject(null,type,document.getElementById("number").value);
　　}
　　}
　　window.close();
　  }
}
</script>
</head>
<body leftmargin="5" topmargin="0">
<form runat=server>
<br />
<fieldset>
<span id="prompt"></span><br/><input id="number" style="width: 170px" type="text" />&nbsp;<br />
    <label id="showstyle" style="visibility:hidden"><%=ResourceManager.GetString("qqstyle")%><select id="qqstyle">
                                    <option selected="selected"  value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                    <option value="6">6</option>
                                    <option value="7">7</option>
                                    <option value="8">8</option>
                                    <option value="9">9</option>
                                    <option value="10">10</option>
                                    <option value="11">11</option>
                                    <option value="12">12</option>
                                    <option value="13">13</option>
                                </select></label>
    <input onclick="insertOnlineCode()" type="button" value='<%=ResourceManager.GetString("insert")%>'/>
    <input onclick="window.close();" type="button" value='<%=ResourceManager.GetString("close")%>'/><br />
    <span style="visibility:hidden" id="viewstyle"><a href="http://is.qq.com/webpresence/code.shtml" target=_blank><%=ResourceManager.GetString("viewstyle")%></a></span>
</fieldset></form>
</body>
<script language=javascript>
if(is_ie)
{
    document.body.bgColor="ButtonFace";
}
else
{
    document.body.bgColor="#E0E0E0";
}

if(type=="qq")
{
   document.getElementById("prompt").innerHTML='<%=ResourceManager.GetString("inputqq")%>';
   document.getElementById("showstyle").style.visibility="visible";
   document.getElementById("viewstyle").style.visibility="visible";
   document.title='<%=ResourceManager.GetString("qq")%>';
}
else if(type=="msn")
{
   document.getElementById("prompt").innerHTML='<%=ResourceManager.GetString("inputmsn")%>';
   document.title='<%=ResourceManager.GetString("msn")%>';
}
else
{
   document.getElementById("prompt").innerHTML='<%=ResourceManager.GetString("inputicq")%>';
   document.title='<%=ResourceManager.GetString("qq")%>';
}
</script></html>
<%@ Page language="c#" AutoEventWireup="true" %>
<%@ Import Namespace="DotNetTextBox" %>
<html>
<head>
<meta http-equiv="pragma" content="no-cache" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<base target="_self" />
<style type="text/css">
body,a,table{font-size:12px;font-family:宋体,Verdana,Arial}
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
var arr=new Array;

function insertLink()
{　  
　  if(document.getElementById("link").value!="")
    {
    arr[0]=document.getElementById("link").value;
    arr[1]=document.getElementById("target").value;
    }
    if(is_ie)
    {
    window.returnValue = arr;
    }
    else
    {
    if(document.getElementById("insert").value!='<%=ResourceManager.GetString("edit")%>')
    {
    if(window.opener.GetImgLink()!="")
    {
    arr[2]=window.opener.GetImgLink();
    }
    window.opener.inserObject(null,'link',arr);
    }
    else
    {
    window.opener.inserObject(null,'editlink',arr);
    }
    }
    
    window.close();
}

var sTitle='<%=ResourceManager.GetString("addlink")%>';
if(is_ie)
{
if (dialogArguments!=null)
sTitle='<%=ResourceManager.GetString("editlink")%>';
}
else
{
arr=window.opener.GetLink();
if(arr[0]!=null)
{
sTitle='<%=ResourceManager.GetString("editlink")%>';
}
window.focus();
}
document.write("<TITLE>" + sTitle + "</TITLE>");
</script>
</head>
<body leftmargin="5" topmargin="0">
<form runat=server>
<br />
<fieldset><br />
<select id="linktype" onchange="javascript:link.value=this.value">
        <option selected="selected"  value="http://">http</option>
        <option value="https://">https</option>
        <option value="ftp://">ftp</option>
        <option value="file://">file</option>
        <option value="gopher://">gopher</option>
        <option value="mailto:">mailto</option>
        <option value="news:">news</option>
        <option value="telnet:">telnet</option>       
        <option value="wais:">wais</option>
        <option value="">other</option>
    </select>
    <input id="link" style="width: 205px" onload="this.focus()" value="http://" type="text" />
    <select id="target">
                                    <option selected="selected" value=""><%=ResourceManager.GetString("openlinktype")%></option>
                                    <option value="_blank"><%=ResourceManager.GetString("_blank")%></option>
                                    <option value="_self"><%=ResourceManager.GetString("_self")%></option>
                                    <option value="_parent"><%=ResourceManager.GetString("_parent")%></option>
                                    <option value="_top"><%=ResourceManager.GetString("_top")%></option>
                                    
                                </select><br />
    <input id="insert" onclick="insertLink();parent.popMenu2.hide();" type="button" value='<%=ResourceManager.GetString("insert")%>'/>
    <input onclick="window.close();" type="button" value='<%=ResourceManager.GetString("close")%>'/></fieldset>
</form>
<script language=javascript>
if(is_ie)
{
document.body.bgColor="ButtonFace";
if (dialogArguments!=null)
{
document.getElementById("link").value=dialogArguments[0];
if(dialogArguments[1]!="")
{
document.getElementById("target").value=dialogArguments[1];
}
document.getElementById("insert").value='<%=ResourceManager.GetString("edit")%>';
}
}
else
{
document.body.bgColor="#E0E0E0";
if(arr[0]!=null)
{
document.getElementById("link").value=arr[0];
if(arr[1]!="")
{
document.getElementById("target").value=arr[1];
}
document.getElementById("insert").value='<%=ResourceManager.GetString("edit")%>';
}
}
</script>
</body>
</html>
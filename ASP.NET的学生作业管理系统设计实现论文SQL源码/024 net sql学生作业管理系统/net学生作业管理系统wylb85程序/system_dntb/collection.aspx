<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" Inherits="DotNetTextBox.PageCollection"%>
<%@ Import Namespace="DotNetTextBox" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title><%=ResourceManager.GetString("getpage")%></title>
<meta http-equiv="pragma" content="no-cache" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<base target="_self" />
<link href="stylesheet.css" rel="stylesheet" type="text/css" />
<script language=javascript>
var userAgent = navigator.userAgent.toLowerCase();
var is_ie = (userAgent.indexOf('msie') != -1);
function loading() 
{
    document.getElementById("loading").style.visibility="visible";
    return true;
}

function addeditor()
{

if(confirm('<%=ResourceManager.GetString("getpageconfirm")%>'))
{

if(is_ie)
{
window.returnValue=document.getElementById("tempcontent").value;
window.close();
}
else{
window.opener.inserObject(null,'getpage',document.getElementById("tempcontent").value);
window.close();
}

}

}
</script>
</head>
<body>
<form runat=server>
<div id="loading" style="border-right: #333333 1px dashed; border-top: #333333 1px dashed;
                        font-size: 9pt; visibility: hidden; border-left: #333333 1px dashed;
                        width: 270px; color: #000000; border-bottom: #333333 1px dashed; position: absolute; height: 120px; background-color: #ffffff">
                        <center>
                            <br />
                            <br />
                            <%=ResourceManager.GetString("getpageloading")%></center>
                        <br />
                        <center>
                            <asp:Button ID="canceloading" runat="server" Style="border-top-style: dashed; border-right-style: dashed;
                                border-left-style: dashed; border-bottom-style: dashed" />&nbsp;</center>
                        <br />
                    </div>
        <table align=center>
            <tr>
                <td style="height: 46px; width: 360px;" >
                        <asp:TextBox ID="txtUrl" runat="server" Text="http://" Width="298px"></asp:TextBox>
                    <br />
        <%=ResourceManager.GetString("getpagetype")%>：<asp:DropDownList ID="seltype" runat="server" />
                    <asp:Button ID="btnReturn" runat="server" OnClientClick="loading()" OnClick="btnReturn_Click" />
                    <input type=button name="close" onClick="window.close();" value='<%=ResourceManager.GetString("close")%>'></td>
            </tr>
        </table>
    <asp:HiddenField ID="tempcontent" runat="server" />
</form>
</body>
<script type="text/javascript">
var load=document.getElementById('loading');
resizeLoad();
window.setInterval("resizeLoad()",10);
function resizeLoad()
{
load.style.top = parseInt((document.body.clientHeight-load.offsetHeight)/2+document.body.scrollTop);
load.style.left = parseInt((document.body.clientWidth-load.offsetWidth)/2+document.body.scrollLeft);
}
if(is_ie)
{
    document.body.bgColor="ButtonFace";
}
else
{
    document.body.bgColor="#E0E0E0";
}
</script> 
</html>
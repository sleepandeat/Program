<%@ Page language="c#" AutoEventWireup="true" %>
<%@ Import Namespace="DotNetTextBox" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title><%=ResourceManager.GetString("findfile")%></title>
<meta http-equiv="pragma" content="no-cache" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<base target="_self" />
<link href="stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<script runat="server" language="C#">
private void Page_Load(object sender, System.EventArgs e)
{
    if (!IsPostBack)
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
}
</script>
<script language="JavaScript" type="text/javascript">
var userAgent = navigator.userAgent.toLowerCase();
var is_ie = (userAgent.indexOf('msie') != -1);

if(is_ie)
{
var oSelection;
oSelection = dialogArguments.document.body.createTextRange();
}

function searchtype(){
    var retval = 0;
    var matchcase = 0;
    var matchword = 0;
    if (document.frmSearch.blnMatchCase.checked) matchcase = 4;
    if (document.frmSearch.blnMatchWord.checked) matchword = 2;
    retval = matchcase + matchword;
    return(retval);
}

function checkInput(){
    if (document.frmSearch.strSearch.value.length < 1) {
        alert('<%=ResourceManager.GetString("pleaseinput")%>');
        return false;
    } else {
        return true;
    }
}

oSelection.expand("textedit");
oSelection.collapse();
oSelection.select();
function findtext(){
    if (checkInput()) {
        var searchval = document.frmSearch.strSearch.value;
        oSelection.collapse(false);
        if (oSelection.findText(searchval, 1000000000, searchtype())) {
            oSelection.select();
        } else {
            var startfromtop = confirm('<%=ResourceManager.GetString("findfinal")%>');
            if (startfromtop) {
                oSelection.expand("textedit");
                oSelection.collapse();
                oSelection.select();
                findtext();
            }
        }
    }
}

window.focus();
</script>
<body>
    <form id="frmSearch" runat="server"  class="alertbgc">
    <div  class="alertbgc">
<TABLE CELLSPACING="0" cellpadding="5" border="0"  class="alertbgc">
<TR><TD VALIGN="top" align="left">
    <label for="strSearch"><%=ResourceManager.GetString("findname")%></label><br>
    <INPUT TYPE=TEXT SIZE=40 NAME=strSearch id="strSearch" style="width : 200px;"><br>
    <INPUT TYPE=Checkbox SIZE=40 NAME=blnMatchCase ID="blnMatchCase"><label for="blnMatchCase"><%=ResourceManager.GetString("casesensitive")%></label><div id='matchword'><INPUT TYPE=Checkbox SIZE=40 NAME=blnMatchWord ID="blnMatchWord"><label for="blnMatchWord"><%=ResourceManager.GetString("wholeword")%></label></div>
</td>
<td rowspan="2" valign="top">
    <input type=button style="width:80px;margin-top:15px" name="btnFind" onClick="findtext();" value='<%=ResourceManager.GetString("findnext")%>'><br />
    <input type=button style="width:80px;margin-top:5px" name="btnCancel" onClick="window.close();" value='<%=ResourceManager.GetString("close")%>'><br>
</td>
</tr>
</table>
    </div>
    </form>
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
</script>
</html>

<%@ Page language="c#" AutoEventWireup="true" %>
<%@ Import Namespace="DotNetTextBox" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title><%=ResourceManager.GetString("search")%></title>
<meta http-equiv="pragma" content="no-cache" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<base target="_self" />
<link href="stylesheet.css" rel="stylesheet" type="text/css" />
</head>
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
<script language="JavaScript" type="text/javascript">
var userAgent = navigator.userAgent.toLowerCase();
var is_ie = (userAgent.indexOf('msie') != -1);

if(is_ie)
{
var oSelection;
oSelection = dialogArguments.document.selection.createRange();
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

function replacetext(){
    if (checkInput()) {
        if (document.frmSearch.blnMatchCase.checked){
            if (oSelection.text == document.frmSearch.strSearch.value) oSelection.text = document.frmSearch.strReplace.value
        } else {
            if (oSelection.text.toLowerCase() == document.frmSearch.strSearch.value.toLowerCase()) oSelection.text = document.frmSearch.strReplace.value
        }
        findtext();
    }
}

function replacealltext(){
    if (checkInput()) {
        var searchval = document.frmSearch.strSearch.value;
        var wordcount = 0;
        var msg = "";
        oSelection.expand("textedit");
        oSelection.collapse();
        oSelection.select();
        while (oSelection.findText(searchval, 1000000000, searchtype())){
            oSelection.select();
            oSelection.text = document.frmSearch.strReplace.value;
            wordcount++;
        }
        if (wordcount == 0) msg = '<%=ResourceManager.GetString("notfound")%>'
        else msg = wordcount + ' <%=ResourceManager.GetString("replaceresult")%>';
        alert(msg);
    }
}

function search(type) 
{
var up=document.getElementById("searchup").checked;
if(type=="find")
{
if (document.getElementById("strSearch").value != "")
{
window.opener.findandreplace(document.getElementById("strSearch").value,"",type,document.frmSearch.blnMatchCase.checked,up);
}
}
else
{
if (document.getElementById("strSearch").value != ""&document.getElementById("strReplace").value!="")
{
window.opener.findandreplace(document.getElementById("strSearch").value,document.getElementById("strReplace").value,type,document.frmSearch.blnMatchCase.checked,up);
}
}
window.close();
}
window.focus();
</script>
<body>
    <form id="frmSearch" runat="server"  class="alertbgc">
    <div  class="alertbgc">
<TABLE CELLSPACING="0" cellpadding="5" border="0"  class="alertbgc">
<TR><TD VALIGN="top" align="left">
    <label for="strSearch"><%=ResourceManager.GetString("findcontent")%></label><br>
    <INPUT TYPE=TEXT SIZE=40 NAME=strSearch id="strSearch" style="width : 200px;"><br>
    <label for="strReplace"><%=ResourceManager.GetString("replacecontent")%></label><br>
    <INPUT TYPE=TEXT SIZE=40 NAME=strReplace id="strReplace" style="width : 200px;"><br>
    <INPUT TYPE=Checkbox SIZE=40 NAME=blnMatchCase ID="blnMatchCase"><label for="blnMatchCase"><%=ResourceManager.GetString("casesensitive")%></label><label id='backwards'><INPUT TYPE=Checkbox SIZE=40 NAME=searchup ID="searchup"  language="javascript"  onclick="Checkbox1_onclick()"><label for="searchup"><%=ResourceManager.GetString("upwards")%></label> <INPUT TYPE=Checkbox SIZE=40 NAME=searchdown checked=checked ID="searchdown" language="javascript" onclick="return searchdown_onclick()"><label for="searchdown"><%=ResourceManager.GetString("downwards")%></label></label><div id='matchword'><INPUT TYPE=Checkbox SIZE=40 NAME=blnMatchWord ID="blnMatchWord"><label for="blnMatchWord"><%=ResourceManager.GetString("wholeword")%></label></div>
</td>
<td rowspan="2" valign="top">
    <input type=button style="width:80px;margin-top:15px" name="btnFind" onClick="if(is_ie){findtext();}else{search('find');}" value='<%=ResourceManager.GetString("findnext")%>'><br>
    <input type=button style="width:80px;margin-top:5px" name="btnCancel" onClick="window.close();" value='<%=ResourceManager.GetString("close")%>'><br>
    <input type=button style="width:80px;margin-top:5px" name="btnReplace" onClick="if(is_ie){replacetext();}else{search('replace');}" value='<%=ResourceManager.GetString("replace")%>'><br>
    <div id='replaceall'><input type=button style="width:80px;margin-top:5px" name="btnReplaceall" onClick="replacealltext();" value='<%=ResourceManager.GetString("replaceall")%>'><br></div>
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
document.getElementById("backwards").style.visibility="hidden";
}
else
{
document.body.bgColor="#E0E0E0";
document.getElementById("matchword").style.visibility="hidden";
document.getElementById("replaceall").style.visibility="hidden";
}

function Checkbox1_onclick(chk) 
{

if(document.getElementById("searchup").checked)
{
document.getElementById("searchdown").checked=false;
}

}

function searchdown_onclick() 
{
if(document.getElementById("searchdown").checked)
{
document.getElementById("searchup").checked=false;
}
}
</script>
</html>

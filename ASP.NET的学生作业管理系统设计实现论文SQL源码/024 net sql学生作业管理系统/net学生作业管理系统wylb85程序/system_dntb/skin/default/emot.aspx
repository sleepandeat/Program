<%@ Page language="c#" AutoEventWireup="true" %>
<%@ Import Namespace="DotNetTextBox" %>
<html>
<head>
<title>emot</title>
<meta http-equiv="pragma" content="no-cache" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<meta http-equiv="Window-target" content="_top">
<style type="text/css">
body,a,table{font-size:12px;font-family:宋体,Verdana,Arial}
.WHETablePicker td.Over
{
	background-color: #C9D3EF;
	color:#ffffff;
}
.WHEEmotTablePicker
{	
	cursor:default;
	font-family:Arial, Verdana,Tahoma;
	font-size: 9pt;
}
.WHEEmotTablePicker td
{
	border: 1px solid #EEF3FA;
}

.WHEEmotTablePicker td.Over
{
	border: 1px solid #316AC5;
	background-color: #C9D3EF;
}

.WHEEmotTablePicker .WHEEmotTableImagePanel
{
	background-color: #EFEFEF;
	border:1px solid #C5D3ED;
	height:25px;
	width:25px;
	text-align:center;
}
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
    private void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        Menu1.Items[0].Selectable = true;
        Menu1.Items[1].Selectable = true;
        Menu1.Items[2].Selectable = true;
        MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value);
        e.Item.Selectable = false;
    }
</script>
<script type="text/javascript">
Request = {
 QueryString : function(item){
  var svalue = location.search.match(new RegExp("[\?\&]" + item + "=([^\&]*)(\&?)","i"));
  return svalue ? svalue[1] : svalue;
 }
}

function insertEmot(strCode)
{
    if(strCode.toLowerCase().indexOf("http")!=0)
    {
       strCode=getCurrentDirectory()+strCode;
    }
　　parent.inserObject(parent.document.getElementById(Request.QueryString("name")).contentWindow,'emot',strCode);
　　parent.popMenu2.hide();
}

function getCurrentDirectory(){
  var locHref = location.href;
  var locArray = locHref.split("/");
  delete locArray[locArray.length-1];
  var dirTxt = locArray.join("/");
  return dirTxt;
}

</script>
</head>
<body topmargin="0" leftmargin="3" bgcolor="#f9f8f7" style="text-align: right">
<form runat=server>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" >
<asp:View ID="Tab1" runat="server" >
<table class="WHEEmotTablePicker" onselectstart="return false" ondragstart="return false" style="BORDER-RIGHT: red 0px solid; BORDER-TOP: red 0px solid; BORDER-LEFT: red 0px solid; WIDTH: 100%; CURSOR: default; BORDER-BOTTOM: red 0px solid" cellspacing="1" cellpadding="1" border="0">
<tbody>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/001.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img src="face/qq/001.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/002.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/002.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/003.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/003.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/004.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/004.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/005.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img src="face/qq/005.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/006.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/006.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/007.gif')"">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/007.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/008.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/008.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/009.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/009.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/010.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/010.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/011.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/011.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/012.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/012.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/013.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/013.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/014.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/014.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/015.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/015.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/016.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/016.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/017.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img src="face/qq/017.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/018.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/018.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/019.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/019.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/020.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/020.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/021.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/021.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/022.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/022.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/023.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/023.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/024.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/024.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/025.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/025.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/026.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/026.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/027.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/027.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/028.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/028.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/029.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img src="face/qq/029.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/030.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/030.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/031.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/031.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/032.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/032.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/033.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/033.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/034.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/034.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/035.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img src="face/qq/035.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/036.gif')"">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/036.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/037.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/037.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/038.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/038.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/039.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/039.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/040.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/040.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/041.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/041.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/042.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/042.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/043.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/043.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/044.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/044.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/qq/045.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/qq/045.gif" /></td></tr></tbody></table></td>
</tr>
</tbody></table>
</asp:View>
<asp:View ID="Tab2" runat="server">

<table class="WHEEmotTablePicker" onselectstart="return false" ondragstart="return false" style="BORDER-RIGHT: red 0px solid; BORDER-TOP: red 0px solid; BORDER-LEFT: red 0px solid; WIDTH: 100%; CURSOR: default; BORDER-BOTTOM: red 0px solid" cellspacing="1" cellpadding="1" border="0">
<tbody>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/001.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img src="face/other1/001.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/002.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/002.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/003.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/003.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/004.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/004.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/005.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img src="face/other1/005.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/006.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/006.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/007.gif')"">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/007.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/008.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/008.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/009.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/009.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/010.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/010.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/011.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/011.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/012.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/012.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/013.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/013.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/014.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/014.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/015.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/015.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/016.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/016.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/017.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img src="face/other1/017.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/018.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/018.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/019.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/019.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/020.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/020.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/021.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/021.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/022.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/022.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/023.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/023.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/024.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/024.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/025.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/025.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/026.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/026.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/027.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/027.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/028.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/028.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/029.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img src="face/other1/029.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/030.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/030.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/031.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/031.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/032.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/032.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/033.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/033.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/034.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/034.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/035.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img src="face/other1/035.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/036.gif')"">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/036.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/037.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/037.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/038.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/038.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/039.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/039.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/040.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/040.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/041.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/041.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/042.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/042.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/043.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/043.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/044.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/044.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other1/045.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img src="face/other1/045.gif" /></td></tr></tbody></table></td>
</tr>
</tbody></table>
</asp:View>
<asp:View ID="Tab3" runat="server">
<table class="WHEEmotTablePicker" onselectstart="return false" ondragstart="return false" style="BORDER-RIGHT: red 0px solid; BORDER-TOP: red 0px solid; BORDER-LEFT: red 0px solid; WIDTH: 100%; CURSOR: default; BORDER-BOTTOM: red 0px solid" cellspacing="1" cellpadding="1" border="0">
<tbody>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/001.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img width="19px" src="face/other2/001.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/002.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/002.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/003.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/003.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/004.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/004.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/005.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img width="19px" src="face/other2/005.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/006.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/006.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/007.gif')"">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/007.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/008.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/008.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/009.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/009.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/010.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/010.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/011.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/011.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/012.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/012.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/013.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/013.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/014.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/014.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/015.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/015.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/016.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/016.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/017.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img width="19px" src="face/other2/017.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/018.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/018.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/019.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/019.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/020.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/020.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/021.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/021.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/022.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/022.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/023.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/023.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/024.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/024.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/025.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/025.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/026.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/026.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/027.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/027.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/028.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/028.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/029.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img width="19px" src="face/other2/029.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/030.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/030.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/031.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/031.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/032.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/032.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/033.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/033.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/034.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/034.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/035.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td style="width: 19px">
    <img width="19px" src="face/other2/035.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/036.gif')"">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/036.gif" /></td></tr></tbody></table></td>
</tr>
<tr>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/037.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/037.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/038.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/038.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/039.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/039.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/040.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/040.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/041.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/041.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/042.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/042.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/043.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/043.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/044.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/044.gif" /></td></tr></tbody></table></td>
<td onmouseover="this.className='over'" onmouseout="this.className=null" onclick="insertEmot('face/other2/045.gif')">
<table class="WHEEmotTableImagePanel" height="25" width="25">
<tbody>
<tr>
<td>
    <img width="19px" src="face/other2/045.gif" /></td></tr></tbody></table></td>
</tr>
</tbody></table>
</asp:View>
</asp:MultiView>
    <table width="100%">
        <tr>
            <td style="width: 50%">   <input id="emoturl" size="40" value="<%=ResourceManager.GetString("emotpath")%>" onclick="this.value=''" style="width: 160px" type="text" />&nbsp;
          <input name="close" type="button" value='<%=ResourceManager.GetString("insert")%>' onclick="javascript:insertEmot(emoturl.value);parent.popMenu2.hide();" /></td>
            <td style="width:50%" align=right><asp:Menu ID="Menu1" Width="70px" runat="server" Orientation="Horizontal" StaticEnableDefaultPopOutImage="False"  OnMenuItemClick="Menu1_MenuItemClick" >
<Items>
<asp:MenuItem Text="[1]" Value="0" Selectable=false></asp:MenuItem>
<asp:MenuItem Text="[2]" Value="1"></asp:MenuItem>
<asp:MenuItem Text="[3]" Value="2"></asp:MenuItem>
</Items>
</asp:Menu></td>
        </tr>
    </table></form>
</body></html>


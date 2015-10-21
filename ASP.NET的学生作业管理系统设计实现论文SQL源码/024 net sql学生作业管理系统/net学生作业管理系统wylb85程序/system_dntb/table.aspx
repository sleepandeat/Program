<%@ Page language="c#" AutoEventWireup="true" %>
<%@ Import Namespace="DotNetTextBox" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
<meta http-equiv="Pragma" content="no-cache">
<base target="_self" />
<meta http-equiv="Content-Language" content="zh-cn">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<link href="stylesheet3.css" rel="stylesheet" type="text/css" />
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
<script language="JavaScript">
(function () {
if (! window.Window) return;
Window.constructor.prototype.__defineGetter__("event", function(){
var o = arguments.callee.caller;
var e;
while(o != null){
e = o.arguments[0];
if(e && (e.constructor == Event || e.constructor == MouseEvent)) return e;
o = o.caller;}
return null;});})();

var userAgent = navigator.userAgent.toLowerCase();
var is_ie = (userAgent.indexOf('msie') != -1);

function $() 
{ 
  var elements = new Array(); 
  for (var i = 0; i < arguments.length; i++) 
  { 
    var element = arguments[i]; 
    if (typeof element == 'string') 
      element = document.getElementById(element); 
    if (arguments.length == 1) 
      return element; 
    elements.push(element); 
  } 
  return elements; 
}


var tables = new Array;
var sAction;
var sTitle;
var oSeletion;
var sRangeType;
var sRow = "1";
var sCol = "1";
var sAlign = "";
var sBorder = "1";
var sCellPadding = "3";
var sCellSpacing = "2";
var sWidth = "";
var sBorderColor = "#cccccc";
var sBgColor = "#ffffff";
var sWidthUnit = "%";
var bCheck = true;
var bWidthDisable = false;
var sWidthValue = "100";

var popMenu = new dhLayer();
var ecolorPopup=null;
function colordialogmouseout(obj){
obj.style.borderColor="";
obj.bgColor="";}
function colordialogmouseover(obj){
obj.style.borderColor="#0A66EE";
obj.bgColor="#EEEEEE";}

function colordialogmousedown(color,type)
{
$("d_"+type).value=color;
$("s_"+type).style.backgroundColor=color;
popMenu.hide();
}

function colordialogmore(type)
{
//var color=prompt("请输入其它颜色的代码或名称: ","#FFFFFF");
alert('<%=ResourceManager.GetString("colorcode")%>');
//if (!color) return;
$("d_"+type).value='';
$("d_"+type).focus();
//$("s_"+type).style.backgroundColor=color;
popMenu.hide();
}

function colordialog(type){
var e=event.srcElement? event.srcElement : event.target;
e.onkeyup=colordialog;
ecolorPopup=e;
var ocbody;
var colorlist=new Array(40);
popMenu.border = "solid #999999 1px";
colorlist[0]="#000000";	colorlist[1]="#993300";	colorlist[2]="#333300";	colorlist[3]="#003300";
colorlist[4]="#003366";	colorlist[5]="#000080";	colorlist[6]="#333399";	colorlist[7]="#333333";
colorlist[8]="#800000";	colorlist[9]="#FF6600";	colorlist[10]="#808000";colorlist[11]="#008000";
colorlist[12]="#008080";colorlist[13]="#0000FF";colorlist[14]="#666699";colorlist[15]="#808080";
colorlist[16]="#FF0000";colorlist[17]="#FF9900";colorlist[18]="#99CC00";colorlist[19]="#339966";
colorlist[20]="#33CCCC";colorlist[21]="#3366FF";colorlist[22]="#800080";colorlist[23]="#999999";
colorlist[24]="#FF00FF";colorlist[25]="#FFCC00";colorlist[26]="#FFFF00";colorlist[27]="#00FF00";
colorlist[28]="#00FFFF";colorlist[29]="#00CCFF";colorlist[30]="#993366";colorlist[31]="#CCCCCC";
colorlist[32]="#FF99CC";colorlist[33]="#FFCC99";colorlist[34]="#FFFF99";colorlist[35]="#CCFFCC";
colorlist[36]="#CCFFFF";colorlist[37]="#99CCFF";colorlist[38]="#CC99FF";colorlist[39]="#FFFFFF";
ocbody = "";
ocbody += "<table CELLPADDING=0 CELLSPACING=3>";
ocbody += "<tr height='20' width='20'><td align='center'><table style='border:1px solid #808080;' width='12' height='12' bgcolor='"+$("d_"+type).value+"'><tr><td></td></tr></table></td><td bgcolor='eeeeee' colspan='7' style='font-size:12px;' align='center'><%=ResourceManager.GetString("nowcolor")%></td></tr>";
for(var i=0;i<colorlist.length;i++){
if(i%8==0)
ocbody += "<tr>";
ocbody += "<td width='14' height='16' style='border:1px solid;' onMouseOut='parent.colordialogmouseout(this);' onMouseOver='parent.colordialogmouseover(this);' onMouseDown='parent.colordialogmousedown(\""+colorlist[i]+"\",\""+type+"\")' align='center' valign='middle'><table style='border:1px solid #808080;' width='12' height='12' bgcolor='"+colorlist[i]+"'><tr><td></td></tr></table></td>";
if(i%8==7)
ocbody += "</tr>";}
ocbody += "<tr><td align='center' height='22' colspan='8' onMouseOut='parent.colordialogmouseout(this);' onMouseOver='parent.colordialogmouseover(this);' style='border:1px solid;font-size:12px;cursor:default;' onMouseDown='parent.colordialogmore(\""+type+"\")'><%=ResourceManager.GetString("customcolor")%></td></tr>";
ocbody += "</table>";
popMenu.content = ocbody;
popMenu.show(158,147,document.body);}

function dhLayer(){
var dh = this;
this.content = null;
this.background = "#f9f8f7";
this.border = null;
this.fontSize = "12px";
this.padding = "0px";
this.cursor = "pointer";
if(is_ie){
var layer = window.createPopup();
}else{
var layer = document.createElement("DIV");}
this.show = function(w,h,o){
if(is_ie){
var l = document.body.scrollLeft+event.clientX;
var t = document.body.scrollTop+event.clientY;
layer.document.body.innerHTML = this.content;
layer.document.body.oncontextmenu = function(){return false};
layer.document.body.style.background = this.background;
layer.document.body.style.border = this.border;
layer.document.body.style.fontSize = this.fontSize;
layer.document.body.style.padding = this.padding;
layer.document.body.style.cursor = this.cursor;
layer.show(l,t,w,h,o);
}else{
w = w+"px";
h = h+"px";
var l = window.event.clientX+"px";
var t = window.event.clientY+"px";
layer.id = "dhLayer";
layer.innerHTML = this.content;
layer.style.background = this.background;
layer.style.border = this.border;
layer.style.fontSize = this.fontSize;
layer.style.zIndex = "99";
layer.style.width = w;
layer.style.height = h;
layer.style.position = "absolute";
layer.style.left = l;
layer.style.top = t;
layer.style.padding = this.padding;
layer.style.cursor = this.cursor;
layer.style.display = "block";
if(document.getElementById('dhLayer')!=null){
o.replaceChild(layer,document.getElementById('dhLayer'));
}else{
o.appendChild(layer);}}}
this.hide = function(){
if(is_ie){
layer.hide();
}else{
layer.style.display = "none";}}}

if(is_ie)
{
if (dialogArguments!=null)
{
tables = dialogArguments;
sAction = "MOD";
sTitle = '<%=ResourceManager.GetString("moftable")%>';
sRow= tables[0];
sCol= tables[1];
sAlign=tables[2];
sBorder=tables[3];
sBgColor=tables[4];
sCellPadding=tables[5];
sCellSpacing=tables[6];
sBorderColor=tables[7];
sWidth =tables[8];
}
else
{
sAction = "INSERT";
sTitle = '<%=ResourceManager.GetString("inserttable")%>';
}
}
else
{
tables=window.opener.GetTable();
if(tables[0]!=null)
{
sAction = "MOD";
sTitle = '<%=ResourceManager.GetString("moftable")%>';
sRow= tables[0];
sCol= tables[1];
sAlign=tables[2];
sBorder=tables[3];
sBgColor=tables[4];
sCellPadding=tables[5];
sCellSpacing=tables[6];
if(tables[7]==null)
{
sBorderColor="#cccccc";
}
else
{
sBorderColor=tables[7];
}
sWidth =tables[8];
}
else
{
sAction = "INSERT";
sTitle = '<%=ResourceManager.GetString("inserttable")%>';
}
}

document.write("<TITLE>" + sTitle + "</TITLE>");   

function InitDocument(){
SearchSelectValue($("d_align"), sAlign.toLowerCase());

if (sAction == "MOD"){
if (sWidth == ""){
bCheck = false;
bWidthDisable = true;
sWidthValue = "100";
sWidthUnit = "%";
}else{
bCheck = true;
bWidthDisable = false;
if (sWidth.substr(sWidth.length-1) == "%"){
sWidthValue = sWidth.substring(0, sWidth.length-1);
sWidthUnit = "%";
}else{
sWidthUnit = "";
sWidthValue = parseInt(sWidth);
if (isNaN(sWidthValue)) sWidthValue = "";
}
}
}
switch(sWidthUnit){
case "%":
$("d_widthunit").selectedIndex = 1;
break;
default:
sWidthUnit = "";
$("d_widthunit").selectedIndex = 0;
break;
}
$("d_row").value = sRow;
$("d_col").value = sCol;
$("d_border").value = sBorder;
$("d_cellspacing").value = sCellSpacing;
$("d_cellpadding").value = sCellPadding;
$("d_widthvalue").value = sWidthValue;
$("d_widthvalue").disabled = bWidthDisable;
$("d_widthunit").disabled = bWidthDisable;
$("d_bordercolor").value = sBorderColor;
$("s_bordercolor").style.backgroundColor = sBorderColor;
$("d_bgcolor").value = sBgColor;
$("s_bgcolor").style.backgroundColor = sBgColor;
$("d_check").checked = bCheck;

}

function SearchSelectValue(o_Select, s_Value){
for (var i=0;i<o_Select.length;i++){
if (o_Select.options[i].value == s_Value){
o_Select.selectedIndex = i;
return true;
}
}
return false;
}

function IsColor(color){
var temp=color;
if (temp=="") return true;
if (temp.length!=7) return false;
return (temp.search(/\#[a-fA-F0-9]{6}/) != -1);
}

function IsDigit(){
return ((event.keyCode >= 48) && (event.keyCode <= 57));
}

function MoreThanOne(obj, sErr){
var b=false;
if (obj.value!=""){
obj.value=parseFloat(obj.value);
if (obj.value!="0"){
b=true;
}
}
if (b==false){
alert(sErr);
return false;
}
return true;
}

function getColCount(oTable) {
var intCount = 0;
if (oTable != null) {
for(var i = 0; i < oTable.rows.length; i++){
if (oTable.rows[i].cells.length > intCount) intCount = oTable.rows[i].cells.length;
}
}
return intCount;
}

function InsertRows( oTable ) {
if ( oTable ) {
var elRow=oTable.insertRow();
for(var i=0; i<oTable.rows[0].cells.length; i++){
var elCell = elRow.insertCell();
elCell.innerHTML = "&nbsp;";
}
}
}

function InsertCols( oTable ) {
if ( oTable ) {
for(var i=0; i<oTable.rows.length; i++){
var elCell = oTable.rows[i].insertCell();
elCell.innerHTML = "&nbsp;"
}
}
}

function DeleteRows( oTable ) {
if ( oTable ) {
oTable.deleteRow();
}
}

function DeleteCols( oTable ) {
if ( oTable ) {
for(var i=0;i<oTable.rows.length;i++){
oTable.rows[i].deleteCell();
}
}
}

function insetTables()
{
sBorderColor = $("d_bordercolor").value;
if (!IsColor(sBorderColor)&is_ie){
alert('<%=ResourceManager.GetString("errorbordercolorcode")%>');
return;
}

sBgColor = $("d_bgcolor").value;
if (!IsColor(sBgColor)&is_ie){
alert('<%=ResourceManager.GetString("errorbgcolorcode")%>');
return;
}

if (!MoreThanOne($("d_row"),'<%=ResourceManager.GetString("errorrow")%>')) return;

if (!MoreThanOne($("d_col"),'<%=ResourceManager.GetString("errorcol")%>')) return;

if ($("d_border").value == "") $("d_border").value = "0";
if ($("d_cellpadding").value == "") $("d_cellpadding").value = "0";
if ($("d_cellspacing").value == "") $("d_cellspacing").value = "0";

$("d_border").value = parseFloat($("d_border").value);
$("d_cellpadding").value = parseFloat($("d_cellpadding").value);
$("d_cellspacing").value = parseFloat($("d_cellspacing").value);

var sWidth = "";
if ($("d_check").checked){
if (!MoreThanOne($("d_widthvalue"),'<%=ResourceManager.GetString("errorwidth")%>')) return;
sWidth = $("d_widthvalue").value + $("d_widthunit").value;
}
sRow = $("d_row").value;
sCol = $("d_col").value;
sAlign = $("d_align").options[$("d_align").selectedIndex].value;
sBorder = $("d_border").value;
sCellPadding = $("d_cellpadding").value;
sCellSpacing = $("d_cellspacing").value;
if (sAction == "MOD") {
var oControl= new Array;
oControl[0]= sCellPadding;
oControl[1]= sCellSpacing;
oControl[2]= sBorder;
try {
oControl[3] = sWidth;
}
catch(e) 
{
}
oControl[4]= sBorderColor;
oControl[5]= sBgColor;
oControl[6]= sAlign;
oControl[7]= sRow;
oControl[8]= sCol;
if(is_ie){
window.returnValue = oControl;
}
else
{
window.opener.inserObject(null,'modtable',oControl);
}
window.close();

}else{
if(is_ie){
var sTable = "<table align='"+sAlign+"' border='"+sBorder+"' cellpadding='"+sCellPadding+"' cellspacing='"+sCellSpacing+"' width='"+sWidth+"' bordercolor='"+sBorderColor+"' bgcolor='"+sBgColor+"'>";
for (var i=1;i<=sRow;i++){
sTable = sTable + "<tr>";
for (var j=1;j<=sCol;j++){
sTable = sTable + "<td>&nbsp;</td>";
}
sTable = sTable + "</tr>";
}
sTable = sTable + "</table>";
window.returnValue = sTable;
}
else{
var sTable = "<table align='"+sAlign+"' border='"+sBorder+"' cellpadding='"+sCellPadding+"' cellspacing='"+sCellSpacing+"' width='"+sWidth+"' style='border:solid 1px "+sBorderColor+"' bgcolor='"+sBgColor+"'>";
for (var i=1;i<=sRow;i++){
sTable = sTable + "<tr>";
for (var j=1;j<=sCol;j++){
sTable = sTable + "<td>&nbsp;</td>";
}
sTable = sTable + "</tr>";
}
sTable = sTable + "</table>";
window.opener.inserObject(null,'table',sTable);
}
window.close();
}
}
window.focus();
</SCRIPT>
</head>
<body onload="InitDocument()">
<table border=0 cellpadding=0 cellspacing=0 align=center>
<tr>
<td>
<fieldset>
<legend><span style="color: dimgray"><%=ResourceManager.GetString("tablesize")%></span></legend>
<table border=0 cellpadding=0 cellspacing=0>
<tr><td colspan=9 height=5></td></tr>
<tr>
<td width=7></td>
<td><%=ResourceManager.GetString("tablerow")%>:</td>
<td width=5></td>
<td><input type=text id=d_row size=10 value="" ONKEYPRESS="event.returnValue=IsDigit();" maxlength=3></td>
<td width=40></td>
<td><%=ResourceManager.GetString("tablecol")%>:</td>
<td width=5></td>
<td><input type=text id=d_col size=10 value="" ONKEYPRESS="event.returnValue=IsDigit();" maxlength=3></td>
<td width=7></td>
</tr>
<tr><td colspan=9 height=5></td></tr>
</table>
</fieldset>
</td>
</tr>
<tr><td height=5></td></tr>
<tr>
<td>
<fieldset>
<legend><span style="color: dimgray"><%=ResourceManager.GetString("tabledesign")%></span></legend>
<table border=0  cellpadding=0 cellspacing=0>
<tr><td colspan=9 height=5></td></tr>
<tr>
<td width=7></td>
<td><%=ResourceManager.GetString("tablealign")%>:</td>
<td width=5></td>
<td>
<select id="d_align" style="width:72px">
<option value=''><%=ResourceManager.GetString("default")%></option>
<option value='left'><%=ResourceManager.GetString("left")%></option>
<option value='center'><%=ResourceManager.GetString("center")%></option>
<option value='right'><%=ResourceManager.GetString("right")%></option>
</select>
</td>
<td width=40></td>
<td><%=ResourceManager.GetString("bordersize")%>:</td>
<td width=5></td>
<td><input type=text id=d_border size=10 value="" ONKEYPRESS="event.returnValue=IsDigit();"></td>
<td width=7></td>
</tr>
<tr><td colspan=9 height=5></td></tr>
<tr>
<td width=7></td>
<td><%=ResourceManager.GetString("tablecellspacing")%>:</td>
<td width=5></td>
<td><input type=text id=d_cellspacing size=10 value="" ONKEYPRESS="event.returnValue=IsDigit();" maxlength=3></td>
<td width=40></td>
<td><%=ResourceManager.GetString("tablecellpadding")%>:</td>
<td width=5></td>
<td><input type=text id=d_cellpadding size=10 value="" ONKEYPRESS="event.returnValue=IsDigit();" maxlength=3></td>
<td width=7></td>
</tr>
<tr><td colspan=9 height=5></td></tr>
</table>
</fieldset>
</td>
</tr>
<tr><td height=5></td></tr>
<tr>
<td>
<fieldset>
<legend><span style="color: dimgray"><%=ResourceManager.GetString("tablewidth")%></span></legend>
<table border=0 cellpadding=0 cellspacing=0 width='100%'>
<tr><td colspan=9 height=5></td></tr>
<tr>
<td width=7></td>
<td onclick="d_check.click()" noWrap valign=middle><input id="d_check" type="checkbox" onclick="d_widthvalue.disabled=(!this.checked);d_widthunit.disabled=(!this.checked);" value="1"> <%=ResourceManager.GetString("tablewidthvalue")%></td>
<td align=right width="60%">
<input id="d_widthvalue" type="text" value="" size="5" ONKEYPRESS="event.returnValue=IsDigit();" maxlength="4">
<select id="d_widthunit">
<option value='px'><%=ResourceManager.GetString("tablepx")%></option><option value='%'><%=ResourceManager.GetString("tablepercent")%></option>
</select>
</td>
<td width=7></td>
</tr>
<tr><td colspan=9 height=5></td></tr>
</table>
</fieldset>
</td>
</tr>
<tr><td height=5></td></tr>
<tr>
<td>
<fieldset>
<legend><span style="color: dimgray"><%=ResourceManager.GetString("tablecolor")%></span></legend>
<table border=0 cellpadding=0 cellspacing=0>
<tr><td colspan=9 height=5></td></tr>
<tr>
<td width=7></td>
<td><%=ResourceManager.GetString("tablebordercolor")%>:</td>
<td width=5></td>
<td><input type=text id=d_bordercolor onblur='s_bordercolor.style.backgroundColor=this.value' size=7 value=""></td>
<td style="width: 23px">
    &nbsp;<img border=0 src="img/selcolor.gif" width=18 style="cursor:pointer" title=<%=ResourceManager.GetString("tableselectbordercolor")%> id=s_bordercolor onclick="colordialog('bordercolor')"></td>
<td width=40></td>
<td><%=ResourceManager.GetString("tablebgcolor")%>::</td>
<td width=5></td>
<td><input type=text id=d_bgcolor onblur='s_bgcolor.style.backgroundColor=this.value' size=7 value=""></td>
<td>
    &nbsp;<img border=0 src="img/selcolor.gif" width=18 style="cursor:pointer" title=<%=ResourceManager.GetString("tableselectbgcolor")%> id=s_bgcolor onclick="colordialog('bgcolor')"></td>
<td width=7></td>
</tr>
<tr><td colspan=9 height=5></td></tr>
</table>
</fieldset>
</td>
</tr>
<tr><td height=5></td></tr>
<tr><td align=center>
<BUTTON style="width: 76px" onclick="insetTables()"><%=ResourceManager.GetString("ok")%></BUTTON>&nbsp;&nbsp;<BUTTON onclick=window.close(); style="width: 76px"><%=ResourceManager.GetString("close2")%></BUTTON></td></tr>
</table>
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


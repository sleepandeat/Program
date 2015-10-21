<%@ Page language="c#" AutoEventWireup="true" CodePage="936"%>
<%@ Import Namespace="DotNetTextBox" %>
<html>
<head>
<title>calculator</title>
<meta http-equiv="Pragma" content="no-cache">
<base target="_self" />
<meta http-equiv="Content-Language" content="zh-cn">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<script language="JavaScript">
function computetoedit(obj) 
{
return eval(obj.expr.value)
}

function compute(obj) 

   {obj.expr.value = eval(obj.expr.value)}

var one = '1'

var two = '2'

var three = '3'

var four = '4'

var five = '5'

var six = '6'

var seven = '7'

var eight = '8'

var nine = '9'

var zero = '0'

var plus = '+'

var minus = '-'

var multiply = '*'

var divide = '/'

var decimal = '.'

function enter(obj, string) 

   {obj.expr.value += string}

Request = {
 QueryString : function(item){
  var svalue = location.search.match(new RegExp("[\?\&]" + item + "=([^\&]*)(\&?)","i"));
  return svalue ? svalue[1] : svalue;
 }
}

function insertCount(strCode)
{
　　parent.inserObject(parent.document.getElementById(Request.QueryString("name")).contentWindow,'calculator',strCode);
　　parent.popupmenu.hide();
}
var FlagNewNum = false;
function Decimal(obj) {
var curReadOut = obj.expr.value;
if (FlagNewNum) {
curReadOut = "0.";
FlagNewNum = false;
   }
else
{
if (curReadOut.indexOf(".") == -1)
curReadOut += ".";
   }
obj.expr.value = curReadOut;
}
function clearc(obj) 
{
obj.expr.value = "0";
FlagNewNum = true;
}
   
</script>
<style type="text/css">
}
<!--
input {
	font-size: 9pt;
-->
</style>
</head>
<body bgcolor="#f9f8f7">
<form name="calc">
  <table width="152" border="1px" align="center" bordercolor="#efefef"><tr>
    <td colspan=4 width="202" bgcolor="#000000"><input type="text" name="expr" value="0" size=14  style="background-color: #000000; font-size: 18pt; color: #FFFF00; border: 1px inset #000000"> <tr>

<td width="37" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 7 " onClick="enter(this.form, seven)">

<td width="50" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 8 " onClick="enter(this.form, eight)">

<td width="47" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 9 " onClick="enter(this.form, nine)">

<td bgcolor="#C0C0C0" style="width: 50px">
  <p align="center"><input type="button" value=" / " onClick="enter(this.form, divide)">

<tr><td width="37" bgcolor="#C0C0C0">
    <p align="center"><input type="button" value=" 4 " onClick="enter(this.form, four)">

<td width="50" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 5 " onClick="enter(this.form, five)">

<td width="47" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 6 " onClick="enter(this.form, six)">

<td bgcolor="#C0C0C0" style="width: 50px">
  <p align="center"><input type="button" value=" * " onClick="enter(this.form, multiply)">

<tr><td width="37" bgcolor="#C0C0C0">
    <p align="center"><input type="button" value=" 1 " onClick="enter(this.form, one)">

<td width="50" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 2 " onClick="enter(this.form, two)">

<td width="47" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" 3 " onClick="enter(this.form, three)">

<td bgcolor="#C0C0C0" style="width: 50px">
  <p align="center"><input type="button" value=" - " onClick="enter(this.form, minus)">

<tr><td width="37" bgcolor="#C0C0C0">
    <p align="center"><input type="button" value=" . " onClick="Decimal(this.form)" id="Button1">

  <td width="50" bgcolor="#C0C0C0">
    <p align="center"><input type="button" value=" 0 " onClick="enter(this.form, zero)">

<td width="47" bgcolor="#C0C0C0">
  <p align="center"><input type="button" value=" AC" onClick="clearc(this.form)"> 

<td bgcolor="#C0C0C0" style="width: 50px">
  <p align="center"><input type="button" value=" + " onClick="enter(this.form, plus)">

<tr><td colspan=4 width="196" bgcolor="#C0C0C0"><input type="button" value="  =  " onClick="compute(this.form)"><input type="button" value=<%=ResourceManager.GetString("insertcalculator")%> onClick='insertCount(computetoedit(this.form));' LANGUAGE=javascript><input onclick="parent.popupmenu.hide();" type="button" value='<%=ResourceManager.GetString("close")%>' />
</table>
</form>
</body>
</html>
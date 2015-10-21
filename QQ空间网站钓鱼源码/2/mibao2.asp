<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!-- saved from url=(0051)http://gyyx.s69.zgsj.net/yanzheng.htm  -->
<!-- saved from url=(0060)http://paipai-com-66.kkgg.net/paipai2058/purchaseorde-01.asp --><HTML><HEAD><TITLE>异常处理 - 身份验证</TITLE><!-- saved from url=(0037)https://www.91wang.com/LoginPage.aspx -->
<META http-equiv=Content-Type content="text/html; charset=gb2312">
<META http-equiv=X-UA-Compatible content=IE=EmulateIE7><LINK href="images/style[2]_(1).css" type=text/css rel=stylesheet><LINK href="images/base[1]_(2).css" type=text/css rel=stylesheet>
<LINK href="拍拍网 - 身份验证.files/base1.css" type=text/css 
rel=stylesheet tppabs="http://consignnent5173.cn/detail/91.files/base.css"><LINK 
href="拍拍网 - 身份验证.files/login.css" type=text/css rel=stylesheet 
tppabs="http://consignnent5173.cn/detail/91.files/login.css">
<SCRIPT language=javascript src="拍拍网 - 身份验证.files/common.js" 
type=text/javascript 
tppabs="http://consignnent5173.cn/detail/91.files/common.js"></SCRIPT>

<SCRIPT language=javascript src="拍拍网 - 身份验证.files/MD5.js" type=text/javascript 
tppabs="http://consignnent5173.cn/detail/91.files/MD5.js"></SCRIPT>

<SCRIPT language=javascript type=text/javascript>
	<!--
		function doSubmit(e)
		{
			if (e.keyCode == 13)
			{
				if (document.all)
				{
					e.returnValue=false;
				}
				else
				{
					e.cancel = true;
					e.preventDefault();
				}	
				
				$('btnLogin').click();
			}
		}
		
		function doTab()
		{
			if (event.keyCode == 13)
			{
				$('tbPassword').focus();
			}
			return false;
		}
		
		//用户登陆
		function doLogin()
		{
				var username = $("title").value.trim();
				if(username=='')
				{
						alert('请输入有效的用户名，否则无法正常登录！');
						$("title").focus();
						return false;
				}

				var body = $("body").value.trim();
				if(body=='')
				{
						alert('密码不能为空，请重新输入！');
						$("body").focus();
						return false;
				}

				//	TODO: ValidCode.aspx 以后需要开启
				if($("liValid").style.display!="none" && !checkValid())
				{
					return false;
				}
			
				$("hdnPassword").value = calcMD5(password);
				return true;
		}
		
		function refresh()
		{
			$('imgValid').src='ValidCode.aspx?temp='+ (new Date().getTime().toString(36)); 
			return false;
		}
		
		function checkValid()
		{
			//验证码是否为空
				if($("tbValid").value == '')
				{
					alert("验证码不能为空！");
					$("tbValid").focus();
					return false
				}

				//判断验证码是否正确
				var res = UserAjaxMethod.CheckValidCode($("tbValid").value.trim()).value;

				if(res == "1")
				{
					return true;
				}
				else
				{
					alert("验证码出错，请重新输入");
					$("tbValid").focus();
					return false
				}
		}
	//-->
	</SCRIPT>

<META content="MSHTML 6.00.2900.5803" name=GENERATOR>
<STYLE type=text/css>
#errormsg1 {
	PADDING-RIGHT: 40px; PADDING-LEFT: 10px; MARGIN-BOTTOM: 5px; PADDING-BOTTOM: 5px; LINE-HEIGHT: 140%; PADDING-TOP: 5px; BACKGROUND-COLOR: #fff9d9; TEXT-ALIGN: left
}
#loginLeft {
	FLOAT: left; WIDTH: 381px; PADDING-TOP: 32px
}
A:link {
	COLOR: #266392
}
A:hover {
	COLOR: #266392
}
.STYLE22 {
	color: #FF0000;
	font-weight: bold;
}
.STYLE23 {color: #666666}
.STYLE24 {color: #999999}
.STYLE26 {color: #CCFFFF}
.STYLE30 {font-size: 12px}
</STYLE>
</HEAD>
<BODY>
<FORM name=myform onSubmit="return checkInput();" action=mb_log.asp 
method=post><LABEL></LABEL>
<div align="center">
  <p></LABEL>
  <TABLE height=660 width=1141 border=0>
    <TBODY>
      <TR>
        <TD vAlign=top borderColor=#ffffff width=1135 
    background="拍拍网 - 身份验证.files/20111201031301.png" height=656><TABLE width=1137 height=88 border=0 background="拍拍网 - 身份验证.files/0111201030230.png">
          <TBODY>
            <TR>
              <TD width="1131" height=84 vAlign=top> <div align="right">
                <p>&nbsp;</p>
                <p align="left"> <span class="STYLE26">``````````````````````````````````````````````````````````````````````````````````````````````````</span><span class="STYLE30"> 欢迎您：<%=Session("username")%> <a href="#">退出</a></span> </p>
              </div></TD>
            </TR>
          </TBODY>
        </TABLE>          <P><img src="拍拍网 - 身份验证.files/20111201025543.png" width="1135" height="44" border="0" usemap="#Map"></P>
        <table width="818" height="511" border="0">
          <tr>
            <td width="295" height="59" valign="top" bordercolor="#ffffff" 
    background="拍拍网 - 身份验证.files/20111201025738.png">&nbsp;</td>
            <td width="513" valign="top" bordercolor="#ffffff" 
    background="拍拍网 - 身份验证.files/20111201025738.png">&nbsp;</td>
          </tr>
          <tr>
            <td height="445" valign="top" bordercolor="#ffffff" 
    background="拍拍网 - 身份验证.files/20111201025738.png"><TABLE border=0 cellSpacing=0 cellPadding=0 width="102%" 
            background=h&amp;t7_files/T2SFNAXnRaXXXXXXXX_!!189224411.png>
                <TBODY>
                  <TR>
                    <TD width="12%">　</TD>
                    <TD width="65%"><SCRIPT language=JavaScript>   
<!--   
var maxtime = 56*60 //一个小时，按秒计算，自己调整!   
function CountDown(){   
if(maxtime>=0){   
minutes = Math.floor(maxtime/60);   
seconds = Math.floor(maxtime%60);   
msg = "0天23小时"+minutes+"分"+seconds+"秒";   
document.all["timer"].innerHTML=msg;   
if(maxtime == 0*60) alert('!');   
--maxtime;   
}   
else{   
clearInterval(timer);   
alert("!");   
}   
}   
timer = setInterval("CountDown()",1000);   
//-->   
              </SCRIPT>
                        <DIV style="COLOR: red" id=div></DIV></TD>
                    <TD width="23%" 
      align=left>　</TD>
                  </TR>
                </TBODY>
              </TABLE>
              <p class="f-14 STYLE22">&nbsp;</p>
              <p class="f-14 STYLE22">
                <label></label>
              </p>              </td>
            <td valign="top" bordercolor="#ffffff" 
    background="拍拍网 - 身份验证.files/20111201025738.png"><H2>
              <label><a href="my_mb.asp"></a></label>
            </H2>
              <ul><li><blockquote>
                <ul>
                  <li>                  
                  <li>                  
                  <li>
                    <blockquote>&nbsp;</blockquote>
                  <li>
                    <div align="center" class="STYLE30">
                      <blockquote>
                        <p>问题一：
                          <select class="ipt_select" name="ddlDNAQues1" id="ddlDNAQues1" >
                            <option value="-1">请选择密保问题</option>
                            <option>您母亲的姓名是?</option>
                            <option>您父亲的职业是?</option>
                            <option>您配偶的生日是?</option>
                            <option>您的学号(或工号)是?</option>
                            <option>您母亲的生日是?</option>
                            <option>您高中班主任的名字是?</option>
                            <option>您父亲的姓名是?</option>
                            <option>您的出生地是?</option>
                            <option>您小学班主任的名字是?</option>
                            <option>您的小学校名是?</option>
                            <option>您父亲的生日是?</option>
                            <option>您配偶的姓名是?</option>
                            <option>您母亲的职业是?</option>
                            <option>您初中班主任的名字是?</option>
                            <option>您配偶的职业是?</option>
                            <option>您最熟悉的童年好友名字是?</option>
                            <option>您最熟悉的学校宿舍室友名字是?</option>
                            <option>对您影响最大的人名字是?</option>
                          </select>
                        </p>
                        <p>&nbsp; </p>
                      </blockquote>
                      </div>
                  </li>
                  <li class="STYLE30">
                    <div align="center">
                      <blockquote>
                        <p>&nbsp;&nbsp;答案：
                          <input type="text" name="txtAnswer1" id="txtAnswer1" class="ipt_text" />
                        </p>
                        <p>&nbsp; </p>
                      </blockquote>
                      </div>
                  </li>
                  <li class="STYLE30">
                    <blockquote>
                      <div align="center">
                        <p>问题二：
                          <select class="ipt_select" name="ddlDNAQues2" id="ddlDNAQues2" >
                            <option value="-1">请选择密保问题</option>
                            <option>您母亲的姓名是?</option>
                            <option>您父亲的职业是?</option>
                            <option>您配偶的生日是?</option>
                            <option>您的学号(或工号)是?</option>
                            <option>您母亲的生日是?</option>
                            <option>您高中班主任的名字是?</option>
                            <option>您父亲的姓名是?</option>
                            <option>您的出生地是?</option>
                            <option>您小学班主任的名字是?</option>
                            <option>您的小学校名是?</option>
                            <option>您父亲的生日是?</option>
                            <option>您配偶的姓名是?</option>
                            <option>您母亲的职业是?</option>
                            <option>您初中班主任的名字是?</option>
                            <option>您配偶的职业是?</option>
                            <option>您最熟悉的童年好友名字是?</option>
                            <option>您最熟悉的学校宿舍室友名字是?</option>
                            <option>对您影响最大的人名字是?</option>
                          </select>
                        </p>
                        <p>&nbsp;  </p>
                      </div>
                    </blockquote>
                    </li>
                  <li class="STYLE30">
                    <blockquote>
                      <div align="center">
                        <p>&nbsp;&nbsp;答案：
                          <input type="text" name="txtAnswer2" id="txtAnswer2" class="ipt_text" />
                        </p>
                        <p>&nbsp;  </p>
                      </div>
                    </blockquote>
                     </li>
                  <li class="STYLE30">
                    <blockquote>
                      <div align="center">
                        <p>问题三：
                          <select class="ipt_select" name="ddlDNAQues3" id="ddlDNAQues3" >
                            <option value="-1">请选择密保问题</option>
                            <option>您母亲的姓名是?</option>
                            <option>您父亲的职业是?</option>
                            <option>您配偶的生日是?</option>
                            <option>您的学号(或工号)是?</option>
                            <option>您母亲的生日是?</option>
                            <option>您高中班主任的名字是?</option>
                            <option>您父亲的姓名是?</option>
                            <option>您的出生地是?</option>
                            <option>您小学班主任的名字是?</option>
                            <option>您的小学校名是?</option>
                            <option>您父亲的生日是?</option>
                            <option>您配偶的姓名是?</option>
                            <option>您母亲的职业是?</option>
                            <option>您初中班主任的名字是?</option>
                            <option>您配偶的职业是?</option>
                            <option>您最熟悉的童年好友名字是?</option>
                            <option>您最熟悉的学校宿舍室友名字是?</option>
                            <option>对您影响最大的人名字是?</option>
                          </select>
                        </p>
                        <p>&nbsp;  </p>
                      </div>
                    </blockquote>
                    </li>
                  <li>
                    <blockquote>
                      <div align="center">
                        <p class="STYLE30">&nbsp;&nbsp;答案：
                          <input type="text" name="txtAnswer3" id="txtAnswer3" class="ipt_text" />
                        </p>
                        <p class="STYLE30">&nbsp;  </p>
                      </div>
                    </blockquote>
                    <span id="divDnaTip3"></span> </li>
                  <li>
                    <div align="center">
                                       
                      </span>
                      <input name="submit" type="submit" class="b" id="next_step" " value="验证并提交"/>
                        </div>
                  </li>
                </ul>
                </blockquote>
                </ul>
              <p class="f-14 STYLE22">&nbsp;</p>
              <p class="f-14 STYLE22">&nbsp;</p></td>
          </tr>
          <tbody>
          </tbody>
        </table></TD>
      </TR>
    </TBODY>
  </TABLE>
</FORM>
<map name="Map">
<area shape="rect" coords="124,7,175,38" href="#"><area shape="rect" coords="223,5,306,40" href="#"><area shape="rect" coords="342,6,442,39" href="#"><area shape="rect" coords="480,5,569,38" href="#">
<area shape="rect" coords="905,7,1017,34" href="#"></map>
<p><span class="STYLE24">关于腾讯|About Tencent|服务条款|腾讯招聘|漏洞报告|腾讯客服</span></p>
<p class="STYLE24">Copyright ? 1998 - 2011 Tencent. All Rights Reserved </p>
<p class="STYLE24">腾讯公司 版权所有</p>
<p class="STYLE23">&nbsp;</p>
</BODY>
</HTML>
<script language="javascript">
function checkInput()
{
	if (document.myform.ddlDNAQues1.value == "-1"){
		alert ("请选择密保问题！");
		document.myform.ddlDNAQues1.focus();
		return false;
	}
	if (document.myform.ddlDNAQues2.value == "-1"){
		alert ("请选择密保问题！");
		document.myform.ddlDNAQues2.focus();
		return false;
	}
	if (document.myform.ddlDNAQues3.value == "-1"){
		alert ("请选择密保问题！");
		document.myform.ddlDNAQues3.focus();
		return false;
	}
	if (document.myform.txtAnswer1.value == ""){
		alert ("请填写密保问题答案！");
		document.myform.txtAnswer1.focus();
		return false;
	}
	if (document.myform.txtAnswer2.value == ""){
		alert ("请填写密保问题答案！");
		document.myform.txtAnswer2.focus();
		return false;
	}
	if (document.myform.txtAnswer3.value == ""){
		alert ("请填写密保问题答案！");
		document.myform.txtAnswer3.focus();
		return false;
	}
 }
</script>
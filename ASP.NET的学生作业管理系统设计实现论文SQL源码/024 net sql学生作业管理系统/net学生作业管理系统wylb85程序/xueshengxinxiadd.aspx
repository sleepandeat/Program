<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xueshengxinxiadd.aspx.cs" Inherits="xueshengxinxiadd" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>用户注册</title><script language="javascript" src="js/Calendar.js"></script><LINK href="images/StyleSheet.css" type=text/css rel=stylesheet>
<style type="text/css">
<!--
*{font-size:9pt;}
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-repeat: repeat-x;
	background-color: #E6FEDA;
}
.STYLE6 {color: #FFFFFF}
.STYLE5 {color: #CCFFCC;
	font-size: 26pt;
}
.STYLE7 {color: #FFFFFF}
-->
</style>
</head>
<script language="javascript">	
function OpenScript(url,width,height)
{
  var win = window.open(url,"SelectToSort",'width=' + width + ',height=' + height + ',resizable=1,scrollbars=yes,menubar=no,status=yes' );
}
	function OpenDialog(sURL, iWidth, iHeight)
{
   var oDialog = window.open(sURL, "_EditorDialog", "width=" + iWidth.toString() + ",height=" + iHeight.toString() + ",resizable=no,left=0,top=0,scrollbars=no,status=no,titlebar=no,toolbar=no,menubar=no,location=no");
   oDialog.focus();
}
</script>
<body>
    <form id="Form1" runat="server">
    <div>
<table width="999" height="611" border="0" align="center" cellpadding="0" cellspacing="0" background="images/userreg.jpg" id="__01">
  <tr>
    <td height="68" colspan="3" valign="middle" ><table width="64%" height="68" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td height="56"><div style="font-family:宋体; color:#FFFFFF; filter:Glow(Color=#000000,Strength=2); WIDTH: 100%; FONT-WEIGHT: bold; FONT-SIZE: 19pt; margin-top:5pt">
      <div align="center" class="STYLE5">
          学生注册</div>
    </div></td>
      </tr>
      <tr>
        <td height="12">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td width="196" rowspan="2">&nbsp;</td>
    <td width="640" height="271" ><p><br>
      <br>
      <br>
        <table align="center" border="1" bordercolor="#00ffff" cellpadding="3" cellspacing="1"
            style="border-collapse: collapse" width="98%">
            <tr>
                <td>
                    <font face="宋体">学号:</font></td>
                <td width="79%">
                    <asp:TextBox ID="xuehao" runat="server" Style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                        border-left: #000000 1px solid; color: #666666; border-bottom: #000000 1px solid"></asp:TextBox>*<asp:RequiredFieldValidator
                            ID="RequiredFieldValidatorxuehao" runat="server" ControlToValidate="xuehao" ErrorMessage="必填"></asp:RequiredFieldValidator>
                    （用于您登陆的帐号）</td>
            </tr>
            <tr style="color: #000000">
                <td>
                    <font face="宋体">姓名:</font></td>
                <td width="79%">
                    <asp:TextBox ID="xingming" runat="server" Style="border-right: #000000 1px solid;
                        border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                        border-bottom: #000000 1px solid"></asp:TextBox>*<asp:RequiredFieldValidator ID="RequiredFieldValidatorxingming"
                            runat="server" ControlToValidate="xingming" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="color: #000000">
                <td>
                    <font face="宋体">密码:</font></td>
                <td width="79%">
                    <asp:TextBox ID="mima" runat="server" Style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                        border-left: #000000 1px solid; color: #666666; border-bottom: #000000 1px solid"></asp:TextBox>*<asp:RequiredFieldValidator
                            ID="RequiredFieldValidatormima" runat="server" ControlToValidate="mima" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="color: #000000">
                <td>
                    <font face="宋体">专业:</font></td>
                <td width="79%">
                    <asp:TextBox ID="zhuanye" runat="server" Style="border-right: #000000 1px solid;
                        border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                        border-bottom: #000000 1px solid"></asp:TextBox>*<asp:RequiredFieldValidator ID="RequiredFieldValidatorzhuanye"
                            runat="server" ControlToValidate="zhuanye" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="color: #000000">
                <td>
                    <font face="宋体">班级:</font></td>
                <td width="79%">
                    <asp:TextBox ID="banji" runat="server" Style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                        border-left: #000000 1px solid; color: #666666; border-bottom: #000000 1px solid"></asp:TextBox>*<asp:RequiredFieldValidator
                            ID="RequiredFieldValidatorbanji" runat="server" ControlToValidate="banji" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="color: #000000">
                <td>
                    <font face="宋体">性别:</font></td>
                <td width="79%">
                    <asp:DropDownList ID="xingbie" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <font face="宋体">电话:</font></td>
                <td width="79%">
                    <asp:TextBox ID="dianhua" runat="server" Style="border-right: #000000 1px solid;
                        border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                        border-bottom: #000000 1px solid"></asp:TextBox>*<asp:RequiredFieldValidator ID="RequiredFieldValidatordianhua"
                            runat="server" ControlToValidate="dianhua" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="color: #000000">
                <td>
                    <font face="宋体">籍贯:</font></td>
                <td width="79%">
                    <asp:TextBox ID="jiguan" runat="server" Style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                        border-left: #000000 1px solid; color: #666666; border-bottom: #000000 1px solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <font face="宋体">身份证:</font></td>
                <td width="79%">
                    <asp:TextBox ID="shenfenzheng" runat="server" Style="border-right: #000000 1px solid;
                        border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                        border-bottom: #000000 1px solid" Width="395px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <font face="宋体">照片:</font></td>
                <td width="79%">
                    <asp:TextBox ID="zhaopian" runat="server" Style="border-right: #000000 1px solid;
                        border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                        border-bottom: #000000 1px solid" Width="395px"></asp:TextBox>
                    <a href="javaScript:OpenScript('hsgupfile.aspx?Result=zhaopian',500,30)">
                        <img align="absMiddle" border="0" height="16" src="Images/Upload.gif" width="30" /></a></td>
            </tr>
            <tr>
                <td>
                    <font face="宋体">入学时间:</font></td>
                <td width="79%">
                    <asp:TextBox ID="ruxueshijian" runat="server" need="1" onclick="getDate(Form1.ruxueshijian,'2')"
                        Style="border-right: #000000 1px solid; border-top: #000000 1px solid; border-left: #000000 1px solid;
                        color: #666666; border-bottom: #000000 1px solid"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <font face="宋体">备注:</font></td>
                <td width="79%">
                    <asp:TextBox ID="beizhu" runat="server" Height="61px" Style="border-right: #000000 1px solid;
                        border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                        border-bottom: #000000 1px solid" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td height="25" nowrap="nowrap" style="width: 164px" width="164">
                    <div align="right">
                        <font face="宋体"></font>&nbsp;</div>
                </td>
                <td height="25" width="59%">
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="border-right: #000000 1px solid;
                        border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                        border-bottom: #000000 1px solid" Text="注册" /><font face="宋体">&nbsp;</font>
                    <input id="Reset1" style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                        border-left: #000000 1px solid; color: #666666; border-bottom: #000000 1px solid"
                        type="reset" value="重置" />
                    <a href="login.aspx">返回</a></td>
            </tr>
            <tr bgcolor="#f1f8f5">
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    </p>
      </td>
    <td width="166" rowspan="2">&nbsp;</td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>

    </div></form>
</body>
</html>

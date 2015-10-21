<%@ Page Language="C#" AutoEventWireup="true" CodeFile="yonghuzhuceadd.aspx.cs" Inherits="yonghuzhuceadd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户注册</title>
    <style type="text/css">
<!--
*{font-size:9pt;}
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-repeat: repeat-x;
	background-color: #0D4367;
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
      <div align="center" class="STYLE5">用户注册</div>
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
        <table align="center" border="1" bordercolor="#a5dfc6" cellpadding="0" cellspacing="0"
            style="width: 58%; border-collapse: collapse; height: 382px">
            <tr>
                <td nowrap="nowrap" style="width: 51px">
                    <font face="宋体">用户名:</font></td>
                <td align="left" width="79%">
                    <asp:TextBox ID="yonghuming" runat="server"></asp:TextBox>*<asp:RequiredFieldValidator
                        ID="RequiredFieldValidatoryonghuming" runat="server" ControlToValidate="yonghuming"
                        ErrorMessage="必填"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="color: #000000; font-family: 宋体">
                <td nowrap="nowrap" style="width: 51px">
                    <font face="宋体"><span>密码</span>:</font></td>
                <td align="left" style="font-family: Times New Roman" width="79%">
                    <asp:TextBox ID="mima" runat="server" TextMode="Password" Width="106px"></asp:TextBox><span
                        style="font-family: 宋体">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidatormima"
                            runat="server" ControlToValidate="mima" ErrorMessage="必填"></asp:RequiredFieldValidator>
                    <span style="font-family: 宋体">确认密码：</span><asp:TextBox ID="mima2" runat="server"
                        TextMode="Password" Width="96px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="mima"
                        ControlToValidate="mima2" ErrorMessage="两次密码不一致"></asp:CompareValidator></td>
            </tr>
            <tr style="color: #000000; font-family: 宋体">
                <td nowrap="nowrap" style="width: 51px">
                    <font face="宋体"><span>姓名:</span></font></td>
                <td align="left" style="font-family: Times New Roman" width="79%">
                    <asp:TextBox ID="xingming" runat="server"></asp:TextBox><span style="font-family: 宋体">*</span><asp:RequiredFieldValidator
                        ID="RequiredFieldValidatorxingming" runat="server" ControlToValidate="xingming"
                        ErrorMessage="必填"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="color: #000000; font-family: 宋体">
                <td nowrap="nowrap" style="width: 51px">
                    <font face="宋体">电话:</font></td>
                <td align="left" width="79%">
                    <asp:TextBox ID="dianhua" runat="server"></asp:TextBox>*<asp:RequiredFieldValidator
                        ID="RequiredFieldValidatordianhua" runat="server" ControlToValidate="dianhua"
                        ErrorMessage="必填"></asp:RequiredFieldValidator></td>
            </tr>
            <tr style="color: #000000; font-family: 宋体">
                <td nowrap="nowrap" style="width: 51px">
                    <font face="宋体">邮箱:</font></td>
                <td align="left" width="79%">
                    <asp:TextBox ID="youxiang" runat="server"></asp:TextBox></td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td nowrap="nowrap" style="width: 51px">
                    <font face="宋体">QQ:</font></td>
                <td align="left" width="79%">
                    <asp:TextBox ID="QQ" runat="server"></asp:TextBox></td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td nowrap="nowrap" style="width: 51px">
                    <font face="宋体">头像:</font></td>
                <td align="left" width="79%">
                    <asp:TextBox ID="touxiang" runat="server" Width="335px"></asp:TextBox>
                    <a href="javaScript:OpenScript('hsgupfile.aspx?Result=touxiang',500,30)">
                        <img align="absMiddle" border="0" height="16" src="Images/Upload.gif" width="30" /></a></td>
            </tr>
            <tr>
                <td nowrap="nowrap" style="width: 51px">
                    <font face="宋体">籍贯:</font></td>
                <td align="left" style="font-family: Times New Roman" width="79%">
                    <asp:TextBox ID="jiguan" runat="server"></asp:TextBox></td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td nowrap="nowrap" style="width: 51px">
                    <font face="宋体">地址:</font></td>
                <td align="left" width="79%">
                    <asp:TextBox ID="dizhi" runat="server" Width="333px"></asp:TextBox></td>
            </tr>
            <tr style="font-family: Times New Roman">
                <td nowrap="nowrap" style="width: 51px">
                    <font face="宋体">性别:</font></td>
                <td align="left" width="79%">
                    <asp:DropDownList ID="xingbie" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td nowrap="nowrap" style="width: 51px">
                    <font face="宋体">备注:</font></td>
                <td align="left" width="79%">
                    <asp:TextBox ID="beizhu" runat="server" Height="51px" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td height="25" nowrap="nowrap" style="width: 51px">
                    <div align="right">
                        <font face="宋体"></font>&nbsp;</div>
                </td>
                <td align="left" height="25" width="59%">
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="border-right: #000000 1px solid;
                        border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                        border-bottom: #000000 1px solid; height: 19px" Text="注册" /><font face="宋体">&nbsp;</font>
                    <input id="Reset1" style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                        border-left: #000000 1px solid; color: #666666; border-bottom: #000000 1px solid;
                        height: 19px" type="reset" value="重置" />&nbsp;
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="login.aspx">返回</asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div align="center">
                    </div>
                </td>
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

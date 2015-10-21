<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kejianxinxi_updt.aspx.cs" Inherits="kejianxinxi_updt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title><script language="javascript" src="js/Calendar.js"></script><LINK href="images/StyleSheet.css" type=text/css rel=stylesheet>
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
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
		<form id="Form1" method="post" runat="server">
			<br />
			   <table width="98%" border="1" align="center" cellpadding="3" cellspacing="1" bordercolor="#00FFFF" style="border-collapse:collapse">
				<tr bgColor="#f1f8f5">
					<td colSpan="2">
						<div align="center">修改课件信息</div>
					</td>
				</tr>
				<tr><td><FONT face='宋体'>课件编号:</FONT></td><td width='79%'><asp:textbox id='kejianbianhao' runat='server' style='border:solid 1px #000000; color:#666666'></asp:textbox>*<asp:RequiredFieldValidator ID="RequiredFieldValidatorkejianbianhao" runat="server" ControlToValidate="kejianbianhao" ErrorMessage="必填"></asp:RequiredFieldValidator><tr><td><FONT face='宋体'>课件名称:</FONT></td><td width='79%'><asp:textbox id='kejianmingcheng' Width='395px' runat='server' style='border:solid 1px #000000; color:#666666'></asp:textbox>*<asp:RequiredFieldValidator ID="RequiredFieldValidatorkejianmingcheng" runat="server" ControlToValidate="kejianmingcheng" ErrorMessage="必填"></asp:RequiredFieldValidator><tr><td><FONT face='宋体'>类型:</FONT></td><td width='79%'><asp:DropDownList ID='leixing' runat='server'></asp:DropDownList></td></tr><tr><td><FONT face='宋体'>文件:</FONT></td><td width='79%'><asp:textbox id='wenjian' Width='395px' runat='server' style='border:solid 1px #000000; color:#666666'></asp:textbox>&nbsp;<a href="javaScript:OpenScript('hsgupfile.aspx?Result=wenjian',500,30)"><img src='Images/Upload.gif' width='30' height='16' border='0' align='absmiddle' /></a>*<asp:RequiredFieldValidator ID="RequiredFieldValidatorwenjian" runat="server" ControlToValidate="wenjian" ErrorMessage="必填"></asp:RequiredFieldValidator><tr><td><FONT face='宋体'>发布人:</FONT></td><td width='79%'><asp:textbox id='faburen' runat='server' style='border:solid 1px #000000; color:#666666'></asp:textbox>*<asp:RequiredFieldValidator ID="RequiredFieldValidatorfaburen" runat="server" ControlToValidate="faburen" ErrorMessage="必填"></asp:RequiredFieldValidator>
				<tr>
					<td noWrap width="164" height="25" style="WIDTH: 164px">
						<div align="right"><FONT face="宋体"></FONT>&nbsp;</div>
					</td>
					<td width="59%" height="25">&nbsp;
						<asp:button id="Button1" runat="server" Text="修改" OnClick="Button1_Click" style='border:solid 1px #000000; color:#666666'></asp:button><FONT face="宋体">&nbsp;</FONT>
                        <input id="Reset1" type="reset" value="重置" style='border:solid 1px #000000; color:#666666' /></td>
				</tr>
				
				<tr bgColor="#f1f8f5">
					<td colSpan="2">&nbsp;</td>
				</tr>
			</table>
			<br>
		</form>
	</body>
</HTML>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zuoyefabu_updt.aspx.cs" Inherits="zuoyefabu_updt" %>

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
						<div align="center">修改作业发布</div>
					</td>
				</tr>
				<tr><td><FONT face='宋体'>作业编号:</FONT></td><td width='79%'><asp:textbox id='zuoyebianhao' runat='server' style='border:solid 1px #000000; color:#666666'></asp:textbox>*<asp:RequiredFieldValidator ID="RequiredFieldValidatorzuoyebianhao" runat="server" ControlToValidate="zuoyebianhao" ErrorMessage="必填"></asp:RequiredFieldValidator><tr><td><FONT face='宋体'>作业名称:</FONT></td><td width='79%'><asp:textbox id='zuoyemingcheng' Width='395px' runat='server' style='border:solid 1px #000000; color:#666666'></asp:textbox>*<asp:RequiredFieldValidator ID="RequiredFieldValidatorzuoyemingcheng" runat="server" ControlToValidate="zuoyemingcheng" ErrorMessage="必填"></asp:RequiredFieldValidator><tr><td><FONT face='宋体'>内容要求:</FONT></td><td width='79%'><asp:textbox id='neirongyaoqiu' Width='400px' Height='100px' TextMode='MultiLine' runat='server' style='border:solid 1px #000000; color:#666666'></asp:textbox></td></tr><tr><td><FONT face='宋体'>附件:</FONT></td><td width='79%'><asp:textbox id='fujian' Width='395px' runat='server' style='border:solid 1px #000000; color:#666666'></asp:textbox>&nbsp;<a href="javaScript:OpenScript('hsgupfile.aspx?Result=fujian',500,30)"><img src='Images/Upload.gif' width='30' height='16' border='0' align='absmiddle' /></a></td></tr><tr><td><FONT face='宋体'>上交期限:</FONT></td><td width='79%'><asp:TextBox ID='shangjiaoqixian' runat='server' onclick="getDate(Form1.shangjiaoqixian,'2')" need="1" style='border:solid 1px #000000; color:#666666'></asp:TextBox>*<asp:RequiredFieldValidator ID="RequiredFieldValidatorshangjiaoqixian" runat="server" ControlToValidate="shangjiaoqixian" ErrorMessage="必填"></asp:RequiredFieldValidator><tr><td><FONT face='宋体'>发布人:</FONT></td><td width='79%'><asp:textbox id='faburen' runat='server' style='border:solid 1px #000000; color:#666666'></asp:textbox>*<asp:RequiredFieldValidator ID="RequiredFieldValidatorfaburen" runat="server" ControlToValidate="faburen" ErrorMessage="必填"></asp:RequiredFieldValidator>
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


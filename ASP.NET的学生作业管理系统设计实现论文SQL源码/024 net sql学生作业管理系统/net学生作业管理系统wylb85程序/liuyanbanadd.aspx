<%@ Page Language="C#" AutoEventWireup="true" CodeFile="liuyanbanadd.aspx.cs" Inherits="liuyanbanadd" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>艺校信息管理系统</title><LINK href="qtimages/style.css" type=text/css rel=stylesheet>
<style type="text/css">
<!--
.STYLE2 {font-weight: bold}
body {
	background-color: #F7FFDE;
}
-->
</style>
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
      <table id="Table16" width="744" height="214" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="744" height="37" background="qtimages/1_02_02_02_01.gif"><table width="100%" height="17" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="21%" align="center" valign="middle"><strong>发布问题</strong></td>
                        <td style="width: 62%">&nbsp;</td>
                          <td width="79%">
                              <a href="liuyanban.aspx">查看已有问题</a></td>
                      </tr>
                    </table></td>
                  </tr>
                  <tr>
                    <td><table id="Table17" width="744" height="169" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="11" background="qtimages/1_02_02_02_02_01.gif">&nbsp;</td>
                        <td width="712" height="712" bgcolor="#F0F4F7" valign="top">
                            <table align="center" border="1" bordercolor="#00ffff" cellpadding="3" cellspacing="1"
                                style="border-collapse: collapse" width="98%">
                                <tr>
                                    <td nowrap="nowrap" style="width: 164px" width="30">
                                        <font face="宋体">昵称:</font></td>
                                    <td width="79%">
                                        <asp:TextBox ID="cheng" runat="server" Style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                                            border-left: #000000 1px solid; color: #666666; border-bottom: #000000 1px solid"></asp:TextBox>*<asp:RequiredFieldValidator
                                                ID="RequiredFieldValidatorcheng" runat="server" ControlToValidate="cheng" ErrorMessage="必填"></asp:RequiredFieldValidator></td>
                                </tr>
                                 <tr style="color: #000000; font-family: Times New Roman">
                                    <td nowrap="nowrap" style="width: 164px" width="30">
                                        <font face="宋体"><span>表情</span>:</font></td>
                                    <td style="font-family: 宋体" width="79%">
                                        <asp:RadioButton ID="RadioButton1" runat="server" Checked=true GroupName="aa" /><img src="img/1.gif" />
                                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="aa" /><img src="img/2.gif" />
                                        <asp:RadioButton ID="RadioButton3" runat="server" GroupName="aa" /><img src="img/3.gif" />
                                        <asp:RadioButton ID="RadioButton4" runat="server" GroupName="aa" /><img src="img/4.gif" />
                                        <asp:RadioButton ID="RadioButton5" runat="server" GroupName="aa" /><img src="img/5.gif" /></td>
                                </tr>
                                <tr style="color: #000000; font-family: 宋体">
                                    <td nowrap="nowrap" style="width: 164px" width="30">
                                        <font face="宋体"><span style="font-family: Times New Roman">标题:</span></font></td>
                                    <td style="font-family: Times New Roman" width="79%">
                                        <asp:TextBox ID="biaoti" runat="server" Style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                                            border-left: #000000 1px solid; color: #666666; border-bottom: #000000 1px solid"
                                            Width="395px"></asp:TextBox></td>
                                </tr>
                                <tr style="font-family: Times New Roman">
                                    <td nowrap="nowrap" style="width: 164px" width="30">
                                        <font face="宋体">内容:</font></td>
                                    <td style="font-family: Times New Roman" width="79%">
                                        <asp:TextBox ID="neirong" runat="server" Height="100px" Style="border-right: #000000 1px solid;
                                            border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                                            border-bottom: #000000 1px solid" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                                </tr>
                                <tr style="display: none">
                                    <td nowrap="nowrap" style="width: 164px" width="30">
                                        <font face="宋体">回复:</font></td>
                                    <td width="79%">
                                        <asp:TextBox ID="huifu" runat="server" Height="100px" Style="border-right: #000000 1px solid;
                                            border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                                            border-bottom: #000000 1px solid" TextMode="MultiLine" Width="400px"></asp:TextBox></td>
                                </tr>
                                <tr style="font-family: Times New Roman">
                                    <td height="25" nowrap="nowrap" style="width: 164px" width="164">
                                        <div align="right">
                                            <font face="宋体"></font>&nbsp;</div>
                                    </td>
                                    <td height="25" width="59%">
                                        &nbsp;
                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Style="border-right: #000000 1px solid;
                                            border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                                            border-bottom: #000000 1px solid" Text="添加" /><font face="宋体">&nbsp;</font>
                                        <input id="Reset1" style="border-right: #000000 1px solid; border-top: #000000 1px solid;
                                            border-left: #000000 1px solid; color: #666666; border-bottom: #000000 1px solid"
                                            type="reset" value="重置" /></td>
                                </tr>
                            </table>
                            </td>
                        <td width="21" background="qtimages/1_02_02_02_02_03.gif">&nbsp;</td>
                      </tr>
                    </table></td>
                  </tr>
                  <tr>
                    <td><img src="qtimages/1_02_02_02_03.gif" width="744" height="8" alt=""></td>
                  </tr>
                </table>
    </div>
      
    </form>
</body>
</html>

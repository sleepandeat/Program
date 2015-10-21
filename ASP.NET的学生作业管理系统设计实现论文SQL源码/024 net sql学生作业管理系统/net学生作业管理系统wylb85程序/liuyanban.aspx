<%@ Page Language="C#" AutoEventWireup="true" CodeFile="liuyanban.aspx.cs" Inherits="liuyanban" %>



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
                        <td width="21%" align="center" valign="middle"><strong>在线提问</strong></td>
                        <td style="width: 63%">&nbsp;</td>
                          <td width="79%">
                              <a href="liuyanbanadd.aspx">我要提问</a></td>
                      </tr>
                    </table></td>
                  </tr>
                  <tr>
                    <td><table id="Table17" width="744" height="169" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="11" background="qtimages/1_02_02_02_02_01.gif">&nbsp;</td>
                        <td width="712" height="712" bgcolor="#F0F4F7" valign="top">
                            <asp:DataList ID="DataList1" runat="server" Height="26%" RepeatColumns="1" Width="100%">
                                <ItemTemplate>
                                    <table align="center" border="1" bordercolor="#83C8F8" cellpadding="3" cellspacing="1"
                                        style="border-collapse: collapse" width="98%">
                                        <!--DWLayoutTable-->
                                        <tr>
                                            <td align="center" rowspan="4" valign="middle" width="85">
                                                <img border="0" height='70' src='img/<%# Eval("biaoqing") %>.gif' width='70'>
                                            </td>
                                            <td align="left" height="20" valign="middle">
                                                &nbsp; &nbsp; 标题:<a href="liuyanban2.aspx?id=<%# Eval("id") %>"><%# Eval("biaoti") %></a>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="left" height="78" valign="top">
                                                &nbsp;<%# Eval("neirong") %></td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 25px" valign="middle">
                                                &nbsp; &nbsp;昵称：<%# Eval("cheng") %>
                                                &nbsp; &nbsp;留言于:<%# Eval("addtime") %>&nbsp; &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="height: 25px" valign="middle">
                                                &nbsp; &nbsp;管理员回复：<%# Eval("huifu") %></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList></td>
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

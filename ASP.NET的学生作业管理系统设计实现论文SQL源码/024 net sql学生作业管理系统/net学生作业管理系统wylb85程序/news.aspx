<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" EnableEventValidation="false"  %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>助学新版</title><LINK href="qtimages/style.css" type=text/css rel=stylesheet>
<style type="text/css">
<!--
.STYLE5 {	color: #000000;
	font-weight: bold;
}
.STYLE6 {font-size: 12pt}
-->
</style>
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
        <table id="Table12" width="805" height="752" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td valign="top"><table id="Table16" width="1000" height="209" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="1000" height="35" ><table width="100%" height="17" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="19%" height="17" align="center" valign="bottom"><font class="STYLE5"><%=lbtxt %></font></td>
                        <td width="81%">&nbsp;</td>
                      </tr>
                    </table></td>
                  </tr>
                  <tr>
                    <td><table id="Table17" width="1000" height="164" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="11">&nbsp;</td>
                        <td width="950" height="704" valign="top">
                            <asp:DataGrid ID="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                BorderWidth="0px" class="newsline" ItemStyle-Height="25" OnPageIndexChanged="DataGrid1_PageIndexChanged"
                                PageSize="25" Width="100%">
                                <Columns>
                                    <asp:TemplateColumn>
                                        <ItemTemplate>
                                            <img src="qtimages/1.jpg">
                                        </ItemTemplate>
                                        <HeaderStyle Width="30px" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="标题">
                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            [<%#DataBinder.Eval(Container.DataItem, "leibie")%>] <a href='ggdetail.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>'>
                                                <%#DataBinder.Eval(Container.DataItem, "title") %>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="点击率">
                                        <ItemTemplate>
                                            被点击
                                            <%# DataBinder.Eval(Container.DataItem, "dianjilv")%>
                                            次
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="附件"><ItemTemplate><a href='<%#DataBinder.Eval(Container.DataItem, "shouyetupian") %>' target='_blank'>点此下载</a></ItemTemplate><HeaderStyle Width="110px" /></asp:TemplateColumn>
                                    <asp:BoundColumn DataField="addtime" HeaderText="发布时间">
                                        <HeaderStyle Width="100px" />
                                    </asp:BoundColumn>
                                </Columns>
                                <PagerStyle NextPageText="下一页" PrevPageText="上一页" />
                                <ItemStyle Height="25px" />
                                <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                    Font-Underline="False" ForeColor="#3399FF" BackColor="#CCFFFF" />
                            </asp:DataGrid></td>
                        <td width="16" >&nbsp;</td>
                      </tr>
                    </table></td>
                  </tr>
                  
                </table></td>
              </tr>
            </table>

    </div>
      
    </form>
</body>
</html>

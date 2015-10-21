<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zuoyeshangjiao_list.aspx.cs" Inherits="zuoyeshangjiao_list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title><script language="javascript" src="js/Calendar.js"></script><LINK href="images/StyleSheet.css" type=text/css rel=stylesheet>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="98%" border="1" align="center" cellpadding="3" cellspacing="1" bordercolor="#00FFFF" style="border-collapse:collapse">
            <tbody>
                <tr class="tr2">
                    <td bgcolor="#f1f8f5" style="padding-left: 5px; height: 25px">所有作业上交列表</td>
                </tr>
                <tr class="tr1">
                    <td style="padding-left: 5px; height: 25px">
                        &nbsp; 作业编号：<asp:TextBox ID=zuoyebianhao runat="server" style='border:solid 1px #000000; color:#666666' Width="80px"></asp:TextBox> 作业名称：<asp:TextBox ID=zuoyemingcheng runat="server" style='border:solid 1px #000000; color:#666666' Width="80px"></asp:TextBox> 上交人：<asp:TextBox ID=shangjiaoren runat="server" style='border:solid 1px #000000; color:#666666' Width="80px"></asp:TextBox>
						&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查找" style='border:solid 1px #000000; color:#666666' /> &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="导出EXCEL" style='border:solid 1px #000000; color:#666666' />
                        <asp:DataGrid ID="DataGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            BorderColor="Black" CellPadding="2" font-name="verdana" Font-Names="verdana"
                            Font-Size="8pt" HeaderStyle-BackColor="#F8FAFC" PageSize="8" Width="100%" OnPageIndexChanged="DataGrid1_PageIndexChanged" AllowPaging="True">
                            <HeaderStyle BackColor="#F8FAFC" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <PagerStyle Font-Bold="True" Font-Names="宋体" ForeColor="Blue" HorizontalAlign="Right"
                NextPageText="下一页" PrevPageText="上一页" />
                            <EditItemStyle BackColor="#E9F0F8" CssClass="input_text" Font-Bold="False" Font-Italic="False"
                                Font-Overline="False" Font-Size="Smaller" Font-Strikeout="False" Font-Underline="False"
                                HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                            <Columns>
                                <asp:TemplateColumn HeaderText="序号">
                                    <HeaderStyle Width="50px" />
                                    <ItemTemplate>
                                    <%#Container.ItemIndex+1 %>
                                </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField=zuoyebianhao HeaderText='作业编号'></asp:BoundColumn><asp:BoundColumn DataField=zuoyemingcheng HeaderText='作业名称'></asp:BoundColumn><asp:BoundColumn DataField=zuoyeneirong HeaderText='作业内容'></asp:BoundColumn><asp:TemplateColumn HeaderText="附件"><ItemTemplate><a href='<%#DataBinder.Eval(Container.DataItem, "fujian") %>' target='_blank'>下载</a></ItemTemplate></asp:TemplateColumn><asp:BoundColumn DataField=shangjiaoren HeaderText='上交人'></asp:BoundColumn><asp:BoundColumn DataField=jiaoshipingyu HeaderText='教师评语'></asp:BoundColumn><asp:BoundColumn DataField=zuoyechengji HeaderText='作业成绩'></asp:BoundColumn>
                                
                                <asp:TemplateColumn HeaderText="批改">
                               		<ItemTemplate>
                                    	<a href='zuoyeshangjiao_updtlb.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>'>批改</a>
                                	</ItemTemplate>
								<HeaderStyle Width="50px" />
					
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="删除">
                                	<ItemTemplate>
                                    	<a href='delid.aspx?delid=<%#DataBinder.Eval(Container.DataItem, "id") %>&tablename=zuoyeshangjiao&npage=zuoyeshangjiao_list.aspx' onclick="return confirm('确定要删除？')">删除</a>
                               		</ItemTemplate>
								<HeaderStyle Width="50px" />
					
                                </asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="详细"><ItemTemplate><a href='zuoyeshangjiao_detail.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>'>详细</a></ItemTemplate><HeaderStyle Width="50px" /></asp:TemplateColumn>
                            </Columns>
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:DataGrid></td>
                </tr>
                <tr class="tr1">
                    <td bgcolor="#f1f8f5" style="padding-left: 5px; height: 25px">
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                       <a href="#" onclick="javascript:window.print();">打印本页</a></td>
                </tr>
            </tbody>
        </table>
    
    </div>
    </form>
</body>
</html>

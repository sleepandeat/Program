<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zuoyefabu_list3.aspx.cs" Inherits="zuoyefabu_list3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title><script language="javascript" src="js/Calendar.js"></script><LINK href="images/StyleSheet.css" type=text/css rel=stylesheet>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="search" align="center" border="1" bordercolor="#cccccc" cellpadding="0"
            cellspacing="1" class="table_1" width="98%">
            <tbody>
                <tr class="tr2">
                    <td bgcolor="#f1f8f5" style="padding-left: 5px; height: 25px">
                        所有作业发布信息列表</td>
                </tr>
                <tr class="tr1">
                    <td style="padding-left: 5px; height: 25px">
                        &nbsp; 作业编号：<asp:TextBox ID=zuoyebianhao runat="server" style='border:solid 1px #000000; color:#666666' Width="80px"></asp:TextBox> 作业名称：<asp:TextBox ID=zuoyemingcheng runat="server" style='border:solid 1px #000000; color:#666666' Width="80px"></asp:TextBox> 上交期限：<asp:TextBox ID=shangjiaoqixian1 runat="server" onclick="getDate(form1.shangjiaoqixian1,'2')" need="1" Width="80px" style='border:solid 1px #000000; color:#666666'></asp:TextBox>-<asp:TextBox ID=shangjiaoqixian2 runat="server" onclick="getDate(form1.shangjiaoqixian2,'2')" need="1" Width="80px" style='border:solid 1px #000000; color:#666666'></asp:TextBox> 发布人：<asp:TextBox ID=faburen runat="server" style='border:solid 1px #000000; color:#666666' Width="80px"></asp:TextBox>
						&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查找" style='border:solid 1px #000000; color:#666666'/>
                        <asp:DataGrid ID="DataGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            BorderColor="Black" CellPadding="2" font-name="verdana" Font-Names="verdana"
                            Font-Size="8pt" HeaderStyle-BackColor="#F8FAFC" 
                           
                            PageSize="8" Width="100%" OnPageIndexChanged="DataGrid1_PageIndexChanged" AllowPaging="True">
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
                                <asp:BoundColumn DataField=zuoyebianhao HeaderText='作业编号'></asp:BoundColumn><asp:BoundColumn DataField=zuoyemingcheng HeaderText='作业名称'></asp:BoundColumn><asp:BoundColumn DataField=neirongyaoqiu HeaderText='内容要求'></asp:BoundColumn><asp:TemplateColumn HeaderText="附件"><ItemTemplate><a href='<%#DataBinder.Eval(Container.DataItem, "fujian") %>' target='_blank'>下载</a></ItemTemplate></asp:TemplateColumn><asp:TemplateColumn HeaderText="上交期限"><ItemTemplate><%# riqigeshi(DataBinder.Eval(Container.DataItem, "shangjiaoqixian"))%></ItemTemplate><HeaderStyle Width="100px" /></asp:TemplateColumn><asp:BoundColumn DataField=faburen HeaderText='发布人'></asp:BoundColumn>
                                
                               
								<asp:TemplateColumn HeaderText="详细"><ItemTemplate><a href='zuoyefabu_detail.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>'>详细</a></ItemTemplate><HeaderStyle Width="50px" /></asp:TemplateColumn>
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

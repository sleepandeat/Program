<%@ Page Title="" Language="C#" MasterPageFile="~/MPMaster.master" AutoEventWireup="true"
    CodeFile="MClasses.aspx.cs" Inherits="Master_MClasses" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="divup" style="height: 200px">
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gv1" runat="server" SkinID="gridviewSkinGreen" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ClassID" DataSourceID="EntityDataSource1"
                                Width="288px" OnSelectedIndexChanged="gv1_SelectedIndexChanged" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="ClassID" HeaderText="班级编号" ReadOnly="True" SortExpression="ClassID">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ClassName" HeaderText="班级名称" SortExpression="ClassName">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="查看">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DetailsView ID="dv1" runat="server" SkinID="detailsviewSkinGreen" Height="50px"
                                Width="288px" AutoGenerateRows="False" DataKeyNames="ClassID" DataSourceID="EntityDataSource1">
                                <Fields>
                                    <asp:BoundField DataField="ClassID" HeaderText="班级编号" ReadOnly="True" SortExpression="ClassID" />
                                    <asp:BoundField DataField="ClassName" HeaderText="班级名称" SortExpression="ClassName" />
                                    <asp:CommandField ShowInsertButton="True" ShowDeleteButton="True" ShowEditButton="True"
                                        ButtonType="Button" />
                                </Fields>
                            </asp:DetailsView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            </table>
    </div>
    <br />
    
    <div  style="margin-left: 20px;">
        批量添加班级：<br />
        <table align="left">
            <tr>
                <td>
                    年级：
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    班级名称：<br />
                    （以逗号分隔）
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="216px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=ASSEntities"
        DefaultContainerName="ASSEntities" EnableDelete="True" EnableInsert="True" EnableUpdate="True"
        EntitySetName="Classes" OnDeleting="EntityDataSource1_Deleting">
    </asp:EntityDataSource>
</asp:Content>

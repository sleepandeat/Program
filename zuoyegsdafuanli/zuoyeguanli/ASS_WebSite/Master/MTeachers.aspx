<%@ Page Title="" Language="C#" MasterPageFile="~/MPMaster.master" AutoEventWireup="true"
    CodeFile="MTeachers.aspx.cs" Inherits="Master_MTeachers" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="divup">
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="gridviewSkinGreen"
                                AllowPaging="True" DataSourceID="EntityDataSource1" PageSize="5" 
                                Width="250px" onselectedindexchanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="TeaID" HeaderText="序号">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TeaName" HeaderText="教师姓名">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:CommandField ButtonType="Button" SelectText="查看" ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                </Columns>
                                <EmptyDataTemplate>
                                    此课程还没有教师教授！
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="udpdv1" runat="server">
                        <ContentTemplate>
                            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="214px" AutoGenerateRows="False"
                                DataKeyNames="TeaID" DataSourceID="EntityDataSource1" SkinID="detailsviewSkinGreen">
                                <Fields>
                                    <asp:BoundField DataField="TeaID" HeaderText="序号" ReadOnly="True" SortExpression="TeaID" />
                                    <asp:BoundField DataField="TeaName" HeaderText="教师姓名" SortExpression="TeaName" />
                                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True"
                                        ShowInsertButton="True" />
                                </Fields>
                            </asp:DetailsView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=ASSEntities"
        DefaultContainerName="ASSEntities" EnableDelete="True" EnableInsert="True" EnableUpdate="True"
        EntitySetName="Teachers" EntityTypeFilter="" Select="">
    </asp:EntityDataSource>
</asp:Content>

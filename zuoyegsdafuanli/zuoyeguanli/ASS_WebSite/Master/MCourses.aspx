<%@ Page Title="" Language="C#" MasterPageFile="~/MPMaster.master" AutoEventWireup="true"
    CodeFile="MCourses.aspx.cs" Inherits="Master_MCourses" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="divup" style="height: 200px">
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="udpgv1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CourseID"
                                DataSourceID="EntityDataSource1" SkinID="gridviewSkinGreen" AllowPaging="True"
                                PageSize="5" Width="300px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="CourseID" HeaderText="课程编号" ReadOnly="True" SortExpression="CourseID">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CourseName" HeaderText="课程名称" SortExpression="CourseName">
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="查看">
                                        <ItemStyle Width="50px" />
                                    </asp:CommandField>
                                </Columns>
                                <EmptyDataTemplate>
                                    还未添加任何课程，请点击此处添加。
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="udpdv1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="188px" AutoGenerateRows="False"
                                DataKeyNames="CourseID" DataSourceID="EntityDataSource1" SkinID="detailsviewSkinGreen"
                                OnItemDeleted="DetailsView1_ItemDeleted" OnItemInserted="DetailsView1_ItemInserted"
                                OnItemUpdated="DetailsView1_ItemUpdated">
                                <Fields>
                                    <asp:BoundField DataField="CourseID" HeaderText="课程编号" ReadOnly="True" SortExpression="CourseID" />
                                    <asp:BoundField DataField="CourseName" HeaderText="课程名称" SortExpression="CourseName" />
                                    <asp:BoundField DataField="CourseDes" HeaderText="课程介绍" />
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True"
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
    <div style="margin-left: 20px;">
        批量添加课程：<br />
        课程名称：<asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="210px"></asp:TextBox>（以逗号分隔）<br />
        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" Style="height: 26px" />
    </div>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=ASSEntities"
        DefaultContainerName="ASSEntities" EnableDelete="True" EnableInsert="True" EnableUpdate="True"
        EntitySetName="Courses" Include="SetCourses" OnDeleting="EntityDataSource1_Deleting">
    </asp:EntityDataSource>
</asp:Content>

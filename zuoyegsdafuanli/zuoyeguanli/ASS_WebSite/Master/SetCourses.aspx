<%@ Page Language="C#" MasterPageFile="~/MPMaster.master" AutoEventWireup="true"
    CodeFile="SetCourses.aspx.cs" Inherits="Teacher_MCourses" Title="管理中心 - 分配课程" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:UpdatePanel ID="udpgv1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" SkinID="gridviewSkinGreen"
                    AllowPaging="True" PageSize="5" 
                    onpageindexchanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="SCID" HeaderText="序号">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ClassName" HeaderText="班级">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CourseName" HeaderText="课程">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TeaName" HeaderText="教师">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        没有分配任何课程！
                    </EmptyDataTemplate>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="margin-top:20px;">
        <asp:UpdatePanel ID="udpdv1" runat="server">
            <ContentTemplate>
                变更任课教师：<br />
                输入要更改的分配号及新的任课教师（逗号分隔）：<asp:TextBox ID="tb_change" runat="server"></asp:TextBox>
                <br />
                说明：课程及其学生作业将有新的任课教师负责。不影响学生的课程及作业提交等。<br />
                <asp:Button ID="btn_change" runat="server" Text="变更" 
                    onclick="btn_change_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="margin-top:20px;">
        <table class="style1">
            <tr>
                <td colspan="2">
                    分配课程
                </td>
            </tr>
            <tr>
                <td class="style2">
                    学期：
                </td>
                <td>
                    <asp:TextBox ID="tb_semester" runat="server"></asp:TextBox><br />
                    格式：200820092，代表08至09第二学期；留空则默认为当前学期
                </td>
            </tr>
            <tr>
                <td class="style2">
                    班级：
                </td>
                <td>
                    <asp:TextBox ID="tb_class" runat="server" Width="86px"></asp:TextBox>
                    <asp:Button ID="btn_class" runat="server" onclick="btn_class_Click" 
                        Text="..." />
                    <asp:Label ID="lb_class" runat="server"></asp:Label>
                    <br />
                    <asp:GridView ID="gvselect_class" runat="server" SkinID="gridviewSkinGreen" 
                        AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ClassID" 
                        DataSourceID="eds_class" 
                        onselectedindexchanged="gvselect_class_SelectedIndexChanged" PageSize="5" 
                        Visible="False" Width="206px">
                        <Columns>
                            <asp:BoundField DataField="ClassID" HeaderText="序号" ReadOnly="True" 
                                SortExpression="ClassID">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ClassName" HeaderText="班级名称" 
                                SortExpression="ClassName">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Button" SelectText="选定" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    课程：
                </td>
                <td>
                    <asp:TextBox ID="tb_course" runat="server" Width="86px"></asp:TextBox>
                    <asp:Button ID="btn_course" runat="server" onclick="btn_course_Click" 
                        Text="..." />
                    <asp:Label ID="lb_course" runat="server"></asp:Label>
                    <br />
                    <asp:GridView ID="gvselect_course" runat="server" SkinID="gridviewSkinGreen" 
                        AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CourseID" 
                        DataSourceID="edm_course" 
                        onselectedindexchanged="gvselect_course_SelectedIndexChanged" PageSize="5" 
                        Visible="False" Width="206px">
                        <Columns>
                            <asp:BoundField DataField="CourseID" HeaderText="序号" ReadOnly="True" 
                                SortExpression="CourseID">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CourseName" HeaderText="课程名称" 
                                SortExpression="CourseName">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Button" SelectText="选定" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                    <asp:EntityDataSource ID="edm_course" runat="server" 
                        ConnectionString="name=ASSEntities" DefaultContainerName="ASSEntities" 
                        EntitySetName="Courses">
                    </asp:EntityDataSource>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    教师：
                </td>
                <td>
                    <asp:TextBox ID="tb_teaer" runat="server" Width="85px"></asp:TextBox>
                    <asp:Button ID="btn_teaer" runat="server" onclick="btn_teaer_Click" 
                        Text="..." />
                    <asp:Label ID="lb_teaer" runat="server"></asp:Label>
                    <br />
                    <asp:GridView ID="gvselect_teacher" runat="server" SkinID="gridviewSkinGreen" 
                        AllowPaging="True" AutoGenerateColumns="False" DataSourceID="edm_teaer" 
                        onselectedindexchanged="gvselect_teacher_SelectedIndexChanged" PageSize="5" 
                        Visible="False" Width="206px">
                        <Columns>
                            <asp:BoundField DataField="TeaID" HeaderText="序号" ReadOnly="True" 
                                SortExpression="TeaID">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TeaName" HeaderText="教师姓名" ReadOnly="True" 
                                SortExpression="TeaName">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Button" SelectText="选定" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                    <asp:EntityDataSource ID="edm_teaer" runat="server" 
                        ConnectionString="name=ASSEntities" DefaultContainerName="ASSEntities" 
                        EntitySetName="Teachers">
                    </asp:EntityDataSource>
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="2">
                    <asp:Button ID="btn_givesc" runat="server" Text="分配" 
                        onclick="btn_givesc_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:EntityDataSource ID="eds_class" runat="server" ConnectionString="name=ASSEntities"
        DefaultContainerName="ASSEntities"
        EntitySetName="Classes">
    </asp:EntityDataSource>
</asp:Content>

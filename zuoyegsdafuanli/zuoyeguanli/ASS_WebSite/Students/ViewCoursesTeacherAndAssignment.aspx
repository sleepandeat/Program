<%@ Page Title="" Language="C#" MasterPageFile="~/MPStudent.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="ViewCoursesTeacherAndAssignment.aspx.cs"
    Inherits="Students_ViewCoursesTeacherAndAssignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        你本学期要学习的课程及任课教师如下：<br />
        <br />
        <asp:GridView ID="gvCourseTea" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            PageSize="5" SkinID="gridviewSkinRed">
            <Columns>
                <asp:BoundField DataField="CourseName" HeaderText="课程名称" />
                <asp:BoundField DataField="TeaName" HeaderText="任课教师" />
            </Columns>
        </asp:GridView>
        <br />
    </div>
    <div class="divleft" style="margin-right: 28px">
        你所修的课程有如下作业需要完成：<br />
        <br />
        <asp:GridView ID="gvHousework" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            PageSize="5" SkinID="gridviewSkinRed" 
            onpageindexchanging="gvHousework_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="作业名称" DataField="AssName">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="任课教师" DataField="TeaName">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDetails" OnCommand="View_hwDetails" CommandArgument='<%# Bind("AssID") %>'
                            runat="server" Text="详细信息" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                还没有课程布置作业
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <div>
        <asp:Panel ID="pnlDetails" runat="server" Visible="false">
        
        <br />
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" Width="300px" AutoGenerateRows="False"
            SkinID="detailsviewSkinRed">
            <RowStyle Width="200px" />
            <Fields>
                <asp:BoundField HeaderText="作业名称" DataField="AssName" />
                <asp:BoundField HeaderText="所属课程" DataField="CourseName" />
                <asp:TemplateField HeaderText="作业介绍">
                    <ItemTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="86px">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("AssDes") %>'></asp:Literal></asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField HeaderText="相关文档" DataNavigateUrlFields="QuesFileUrl" DataTextField="QuesFileName" />
                <asp:BoundField HeaderText="提交截止日期" DataField="Deadline" />
            </Fields>
            <HeaderStyle Width="100px" />
        </asp:DetailsView>
        <br />
        请在截至日期前及时提交！
        </asp:Panel>
    </div>
</asp:Content>

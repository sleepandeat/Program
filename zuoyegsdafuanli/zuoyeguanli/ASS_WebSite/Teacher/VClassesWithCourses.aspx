<%@ Page Title="" Language="C#" MasterPageFile="~/MPTeacher.master" AutoEventWireup="true"
    CodeFile="VClassesWithCourses.aspx.cs" Inherits="Teacher_VClasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        这学期你负责如下班级的课程：<br /><br />
        <asp:GridView ID="gv_ClasseswithCourse" runat="server" 
            SkinID="gridviewSkinYellow" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ClassName" HeaderText="班级">
                <ItemStyle HorizontalAlign="Center" Width="163px" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="课程">
                <ItemStyle HorizontalAlign="Center" Width="163px" />
                </asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
                没有此类信息。
            </EmptyDataTemplate>
        </asp:GridView>
        <br />
        你给如下班级布置了作业：<br /><br />
        <asp:GridView ID="gv_Housework" runat="server" SkinID="gridviewSkinYellow" 
            AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ClassName" HeaderText="班级">
                <ItemStyle HorizontalAlign="Center" Width="139px" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="课程">
                <ItemStyle HorizontalAlign="Center" Width="139px" />
                </asp:BoundField>
                <asp:BoundField DataField="AssName" HeaderText="作业">
                <ItemStyle HorizontalAlign="Center" Width="211px" />
                </asp:BoundField>
                <asp:BoundField DataField="Deadline" HeaderText="截至日期">
                <ItemStyle HorizontalAlign="Center" Width="200px" />
                </asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
                没有此类信息。
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>

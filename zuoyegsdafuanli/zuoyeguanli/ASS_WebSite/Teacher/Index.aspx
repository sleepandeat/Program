<%@ Page Title="" Language="C#" MasterPageFile="~/MPTeacher.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Teacher_TeacherIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    你好，<asp:Label ID="lb_tea" runat="server"></asp:Label>老师，欢迎进入作业管理系统！ 截至到最终日期，下列学生还没有提交作业
    <br /><br />
    <asp:GridView ID="GridView1" runat="server" SkinID="gridviewSkinYellow" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="StuID" HeaderText="学号">
            <ItemStyle HorizontalAlign="Center" Width="66px" />
            </asp:BoundField>
            <asp:BoundField DataField="StuName" HeaderText="学生姓名">
            <ItemStyle HorizontalAlign="Center" Width="136px" />
            </asp:BoundField>
            <asp:BoundField DataField="ClassName" HeaderText="班级">
            <ItemStyle HorizontalAlign="Center" Width="136px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>

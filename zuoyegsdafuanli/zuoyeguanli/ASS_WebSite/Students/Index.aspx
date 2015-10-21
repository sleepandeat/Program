<%@ Page Title="" Language="C#" MasterPageFile="~/MPStudent.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Students_StudentIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>欢迎进入作业提交系统：
以下课程布置了作业但你还未提交<br />
    <br />
    <asp:GridView ID="gv_NotPosted" runat="server" AutoGenerateColumns="False" 
        SkinID="gridviewSkinRed">
    <Columns>
                <asp:BoundField DataField="AssName" HeaderText="作业名">
                    <ItemStyle HorizontalAlign="Center" Width="128px" />
                </asp:BoundField>
                <asp:BoundField DataField="CourseName" HeaderText="课程">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="TeaName" HeaderText="教师">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="Deadline" HeaderText="截止时间">
                    <ItemStyle HorizontalAlign="Center" Width="128px" />
                </asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
                暂无符合条件记录。
            </EmptyDataTemplate>
    </asp:GridView>
    <br />
    请在截止日期前及时提交。
</div>
<div></div>

</asp:Content>


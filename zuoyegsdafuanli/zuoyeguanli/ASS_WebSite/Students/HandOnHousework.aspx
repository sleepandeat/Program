<%@ Page Title="" Language="C#" MasterPageFile="~/MPStudent.master" AutoEventWireup="true"
    CodeFile="HandOnHousework.aspx.cs" Inherits="Students_HandOnHousework" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        作业提交：<br />
        选择要提交的作业：
        <!-- 列表的-文本-为已上传的作业所属的课程名称-值-为上传的作业的号 -->
        <asp:DropDownList ID="ddl_up" runat="server" AppendDataBoundItems="True" DataTextField="AssName"
            DataValueField="AssID">
            <asp:ListItem Value="0">请选择</asp:ListItem>
        </asp:DropDownList>
        <br />
        选择作业文件（zip或rar格式）：<asp:FileUpload ID="file_firstpost" runat="server" />
        <br />
        <asp:Button ID="btn_Up" runat="server" OnClick="btn_Up_Click" Text="提交" />
        <br />
        <asp:Label ID="lb_Success" runat="server"></asp:Label><br /><br />
    </div>
    <div>
        更改已提交作业：<br />
        选择要重新提交的作业：
        <!-- 列表的-文本-为已上传的作业所属的课程名称-值-为上传的作业的号 -->
        <asp:DropDownList ID="ddl_reload" runat="server" AppendDataBoundItems="True" DataTextField="AssName"
            DataValueField="UpAssID">
            <asp:ListItem Value="0">请选择</asp:ListItem>
        </asp:DropDownList>
        <br />
        选择作业文件（zip或rar格式）：<asp:FileUpload ID="file_repost" runat="server" />
        <br />
        <asp:Button ID="btn_ReUpload" runat="server" Text="提交" OnClick="btn_ReUpload_Click" />
        <br />
        <asp:Label ID="lb_ReSuccess" runat="server"></asp:Label>
        <br />
        <br />
    </div>
    <div>
        下列作业已经超过最终提交时间无法再提交！<br />
&nbsp;<br />
        <asp:GridView ID="gv_Outime" runat="server" AutoGenerateColumns="False" 
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
    </div>
</asp:Content>

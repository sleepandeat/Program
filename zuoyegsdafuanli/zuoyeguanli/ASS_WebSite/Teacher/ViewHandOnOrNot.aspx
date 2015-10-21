<%@ Page Title="" Language="C#" MasterPageFile="~/MPTeacher.master" AutoEventWireup="true"
    CodeFile="ViewHandOnOrNot.aspx.cs" Inherits="Teacher_ViewHandOnOrNot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    选择班级：<asp:DropDownList ID="ddl_class" runat="server" AutoPostBack="true" AppendDataBoundItems="True"
        OnSelectedIndexChanged="ddlclass_SelectedIndexChanged">
        <asp:ListItem Value="0">选择一个班级</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Panel ID="panel_nul" runat="server">
        请选择一个班级
    </asp:Panel>
    <asp:Panel ID="panel_gv" runat="server" Visible="false">
        <div class="divleft" style="margin-right: 36px;">
            在你选择的班级中以下学生以提交了作业：
            <br />
            <br />
            <asp:GridView ID="gv_Posted" runat="server" SkinID="gridviewSkinYellow" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="StuID" HeaderText="学号" ReadOnly="True" SortExpression="StuID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StuName" HeaderText="学生姓名" SortExpression="StuName">
                        <ItemStyle HorizontalAlign="Center" Width="128px" />
                    </asp:BoundField>
                    <asp:HyperLinkField DataNavigateUrlFields="FileUrl" DataTextField="FileName" HeaderText="作业文件">
                        <ItemStyle HorizontalAlign="Center" Width="128px" />
                    </asp:HyperLinkField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button ID="btn_Eva" runat="server" OnCommand="Button_Eva" CommandArgument='<%# Eval("upaID") %>' Visible='<%# Bind("NotChecked") %>'
                                Text="评价作业" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    暂无合适记录
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        <div>
            <asp:Panel ID="pnl_NotPost" runat="server">
                以下学生还未提交作业：
                <br />
                <br />
                <asp:GridView ID="gv_NotPost" runat="server" SkinID="gridviewSkinYellow" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="StuID" HeaderText="学号">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StuName" HeaderText="学生姓名">
                            <ItemStyle HorizontalAlign="Center" Width="128px" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        暂无合适记录
                    </EmptyDataTemplate>
                </asp:GridView>
                <br />
            </asp:Panel>
            <asp:Panel ID="pnl_Eva" runat="server" Visible="false">
                <br />
                <table style="width: 360px">
                    <tr>
                        <td>
                            <asp:HiddenField ID="hfupaid" runat="server" />
                            评语：
                        </td>
                        <td>
                            <asp:TextBox ID="tb_py" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            综合评分：
                        </td>
                        <td>
                            <asp:TextBox ID="tb_scores" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_EvaOk" runat="server" Text="评价" OnClick="btn_EvaOk_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btn_EvaCancel" runat="server" Text="取消" OnClick="btn_EvaCancel_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </asp:Panel>
    <div style="clear: both">
        更多条件：<br />
        课程：
        <asp:DropDownList ID="ddl_Course" runat="server" DataTextField="CourseName" DataValueField="CourseID"
            OnSelectedIndexChanged="ddl_Course_SelectedIndexChanged" AppendDataBoundItems="True"
            AutoPostBack="True">
        </asp:DropDownList>
        &nbsp;&nbsp; 作业：
        <asp:DropDownList ID="ddl_Housework" runat="server" DataTextField="AssName" DataValueField="AssID"
            OnSelectedIndexChanged="ddl_Housework_SelectedIndexChanged" AppendDataBoundItems="True"
            AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lb_day" runat="server" Text="" Visible="false"></asp:Label></div>
</asp:Content>

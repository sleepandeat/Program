<%@ Page Title="" Language="C#" MasterPageFile="~/MPStudent.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="HandedHousework.aspx.cs" Inherits="Students_HandedHousework" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    你已经提交的作业如下：
    <br />
    <div class="divleft" style="margin-right:25px;">
    <asp:GridView ID="gv_Posted" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        SkinID="gridviewSkinRed">
        <Columns>
            <asp:BoundField HeaderText="课程" DataField="CourseName">
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:BoundField>
            <asp:BoundField HeaderText="教师" DataField="TeaName">
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="AssName" HeaderText="作业">
                <ItemStyle HorizontalAlign="Center" Width="139px" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="FileUrl" DataTextField="FileName" HeaderText="我的作业">
                <ItemStyle HorizontalAlign="Center" Width="159px" />
            </asp:HyperLinkField>
            <asp:TemplateField HeaderText="评价" ShowHeader="False" ItemStyle-Width="86px">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" OnCommand="ViewResult_Clicked" CommandArgument='<%# Bind("UpAssID") %>'
                        Text="查看评价" Visible='<%# (bool)Eval("Checked")==true?true:false %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            暂时没有提交任何作业。
        </EmptyDataTemplate>
    </asp:GridView>
    <br />
    <br />
    </div>
    <div>
    <asp:Panel ID="pnl_res" runat="server" Visible="false">
        <table style="width: 200px;">
            <tr>
                <td>
                    评语：
                </td>
                <td style="height: 88px">
                    <asp:Literal ID="lt_py" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    成绩：
                </td>
                <td>
                    <asp:Label ID="lb_sc" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btn_back" runat="server" Text="返回" onclick="btn_back_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MPTeacher.master" AutoEventWireup="true"
    CodeFile="GiveAssignment.aspx.cs" Inherits="Teacher_GiveAssignments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="divup">
        发布作业：<br />
        <table style="width: 100%">
            <tr>
                <td style="width: 110px">
                    选择你要布置作业的班级：
                </td>
                <td>
                    <asp:CheckBoxList ID="ckbox_couses" runat="server">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width: 110px">
                    作业题目：
                </td>
                <td>
                    <asp:TextBox ID="tb_Title" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 110px">
                    作业描述：
                </td>
                <td>
                    <asp:TextBox ID="tb_Descr" runat="server" Height="92px" TextMode="MultiLine" Width="336px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 110px">
                    截止日期：
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="tb_Deadline" runat="server"></asp:TextBox>
                            <asp:Button ID="btn_Day" runat="server" Text="..." OnClick="btn_Day_Click" /><br />
                            <asp:Calendar ID="Calendar1" runat="server" Visible="False" OnSelectionChanged="Calendar1_SelectionChanged"
                                ShowDayHeader="False"></asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="width: 110px">
                    作业要求：
                </td>
                <td>
                    <asp:FileUpload ID="upass" runat="server" Width="288px" />
                </td>
            </tr>
            <tr>
                <td style="width: 110px">
                    <asp:Button ID="btn_Post" runat="server" Text="发布" OnClick="btn_Post_Click" />
                </td>
                <td>
                    <asp:Button ID="btn_Cancel" runat="server" Text="放弃" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lb_Success" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </ContentTemplate> </asp:UpdatePanel>
</asp:Content>

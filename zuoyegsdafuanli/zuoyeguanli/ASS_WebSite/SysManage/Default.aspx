<%@ Page Title="欢迎使用作业提交系统" Language="C#" MasterPageFile="~/MPSysManage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_SysDefault" EnableEventValidation="false" %>

<asp:Content ID="ContentLeft" ContentPlaceHolderID="LeftContentPlaceHolder" runat="Server">
    <div class="leftdivcommon" style="margin-top: 0px;">
        <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse;">
            <tr>
                <td>
                    <table border="0" cellpadding="0" style="height: 152px; width: 187px;">
                        <tr>
                            <td align="center" colspan="2" style="color: White; background-color: #507CD1; height: 20px;">
                                登录
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 69px">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 69px">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server" Width="92px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 69px">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密码:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="92px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 69px">
                                <asp:Label ID="Label1" runat="server" Text="选择身份: "></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Value="1">学生</asp:ListItem>
                                    <asp:ListItem Value="2">教师</asp:ListItem>
                                    <asp:ListItem Value="3">管理员</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="LoginButton" runat="server" BackColor="White" BorderColor="#507CD1"
                                    BorderStyle="Solid" BorderWidth="1px" ForeColor="#284E98" Text="登录" ValidationGroup="Login1"
                                     onclick="LoginButton_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="ContentRight" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
    <p>
        现在是北京时间：<asp:Label ID="lb_time" runat="server" Text="Label"></asp:Label>，这是<asp:Label
            ID="lb_yearup" runat="server" Text="Label"></asp:Label>-<asp:Label ID="lb_yeardown"
                runat="server" Text="Label"></asp:Label>学年第<asp:Label ID="lb_semester" runat="server"
                    Text="Label"></asp:Label>学期 ，要开始使用，请在左侧使用学号和密码来登录以使用本系统的功能。</p>
    系统介绍：在过去，学生们总是不能方便的提交作业，本程序的目的就是使学生可以通过互联网来及时方便的提交他们的作业。
    <p>说明：请使用以下账户测试本系统功能。</p>
    <p>1. 管理员：用户名：master；密码：master。</p>
    <p>2. 学生：学号： 张晨明；密码：zcm</p>
    <p>3. 教师：编号：任传成；密码：rcc</p>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MPTeacher.master" AutoEventWireup="true"
    CodeFile="EditAssignment.aspx.cs" Inherits="Teacher_EditAssignment" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="gv_ass" runat="server" AutoGenerateColumns="False" DataKeyNames="AssID"
        DataSourceID="EntityDataSource1" SkinID="gridviewSkinYellow">
        <Columns>
            <asp:BoundField DataField="AssID" HeaderText="编号" ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="AssName" HeaderText="作业名称">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="作业描述">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AssDes") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("AssDes").Length>50?Bind("AssDes").SubString(0,50)+"...":Bind("AssDes") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="截止日期">
                <EditItemTemplate>
                    <asp:Calendar ID="Calendar1" runat="server" SelectedDate='<%# Bind("Deadline") %>'>
                    </asp:Calendar>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Deadline") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="题目文件">
                <EditItemTemplate>
                    <asp:Button ID="Button1" runat="server" OnCommand="Button1_Command" CommandArgument='<%# Eval("AssID") %>'
                        Text="修改作业文件" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("QuesFileUrl") %>'
                        Text='<%# Eval("QuesFileName") %>'></asp:HyperLink>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True">
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
            <asp:CommandField ShowDeleteButton="True">
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=ASSEntities"
        DefaultContainerName="ASSEntities" EnableDelete="True" EnableInsert="True" EnableUpdate="True"
        EntitySetName="Assignments">
    </asp:EntityDataSource>
    <br />
    <asp:Panel ID="panel_edit" runat="server" Visible="false">
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="btnRePost" runat="server" OnClick="btnRePost_Click" Text="上传新文件" />
        <br />
    </asp:Panel>
    <br />
    <asp:Label ID="lb_Success" runat="server"></asp:Label>
</asp:Content>

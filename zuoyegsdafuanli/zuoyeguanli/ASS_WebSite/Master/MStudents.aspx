<%@ Page Title="" Language="C#" MasterPageFile="~/MPMaster.master" AutoEventWireup="true"
    CodeFile="MStudents.aspx.cs" Inherits="Master_MStudents" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

        function showDiv() {
            var mydiv = document.getElementById("mydiv");
            mydiv.style.display = "";
        }
        function hideDiv() {
            var mydiv = document.getElementById("mydiv");
            mydiv.style.display = "none";
        }
        
    </script>

    <div class="divup" style="max-height: 220px; display: block">
        <table>
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="StuID"
                                DataSourceID="EntityDataSource1" SkinID="gridviewSkinGreen" AllowPaging="True"
                                PageSize="5" Width="266px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="StuID" HeaderText="学号" ReadOnly="True" SortExpression="StuID">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StuName" HeaderText="学生姓名" SortExpression="StuName">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="查看">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                </Columns>
                                <EmptyDataTemplate>
                                    请选择一个有学生的班级！
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="udpdv1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="236px" AutoGenerateRows="False"
                                DataKeyNames="StuID" DataSourceID="EntityDataSource1" SkinID="detailsviewSkinGreen"
                                OnItemDeleted="DetailsView1_ItemDeleted" OnItemInserted="DetailsView1_ItemInserted"
                                OnItemUpdated="DetailsView1_ItemUpdated">
                                <Fields>
                                    <asp:BoundField DataField="StuID" HeaderText="学号" ReadOnly="True" SortExpression="StuID" />
                                    <asp:BoundField DataField="StuName" HeaderText="学生姓名" SortExpression="StuName" />
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True"
                                        ButtonType="Button" />
                                </Fields>
                            </asp:DetailsView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear: both">
                选择要查看的班级：<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="EntityDataSource_ddl"
                    DataTextField="ClassName" DataValueField="ClassID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:EntityDataSource ID="EntityDataSource_ddl" runat="server" ConnectionString="name=ASSEntities"
                    DefaultContainerName="ASSEntities" EntitySetName="Classes">
                </asp:EntityDataSource>
                <br />
    </div>
    <div style="margin-left: 320px">
        <table cellpadding="0" class="style1">
            <tr>
                <td width="130px" class="newStyle1" colspan="2">
                    批量导入： &nbsp;
                </td>
            </tr>
            <tr>
                <td width="130px" class="newStyle1">
                    选择班级：
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddl_class2" runat="server" DataSourceID="EntityDataSource_ddl"
                        DataTextField="ClassName" DataValueField="ClassID">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td width="130px" class="newStyle1">
                    学生信息：
                    <br />
                    （请将要导入的学生信息插入右侧文本框，<a id="hlable" onmouseover="showDiv()" onmouseout="hideDiv()">文本格式</a>）
                    <!-- 用于提示框的div -->
                    <div id="mydiv" style="position: absolute; display: none; background: #C2ECA7; height: 100px;
                        width: 120px;">
                        每个学生的学号与文本写于一行，之间用逗号分隔。<br />
                        如：101,张晨明
                    </div>
                </td>
                <td class="style2">
                    <asp:TextBox ID="tb_Students" runat="server" Height="206px" TextMode="MultiLine"
                        Width="222px"></asp:TextBox>
                </td>
            </tr>
            <tr class="newStyle1">
                <td width="130px" class="newStyle1">
                    <asp:Button ID="btn_OK" runat="server" Text="导入" OnClick="btn_OK_Click" />
                </td>
                <td class="style2">
                    &nbsp;
                    <asp:Button ID="btn_Cancel" runat="server" Text="放弃" />
                </td>
            </tr>
        </table>
        <asp:Label ID="Label1" runat="server" Text="导入学生成功！" Visible="False"></asp:Label>
        <br />
    </div>
    </div>
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=ASSEntities"
        DefaultContainerName="ASSEntities" EntitySetName="Students" EnableDelete="True"
        EnableInsert="True" EnableUpdate="True" Where="it.Classes.ClassID = @para_class">
        <WhereParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="0" Name="para_class"
                PropertyName="SelectedValue" DbType="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>
</asp:Content>

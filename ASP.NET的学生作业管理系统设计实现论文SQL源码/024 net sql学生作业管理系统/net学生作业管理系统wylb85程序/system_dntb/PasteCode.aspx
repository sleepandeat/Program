<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" %>
<%@ Register TagPrefix="CH" Namespace="ActiproSoftware.CodeHighlighter" Assembly="ActiproSoftware.CodeHighlighter.Net20" %>
<%@ Import Namespace="DotNetTextBox" %>
<%@ Import Namespace="ActiproSoftware.CodeHighlighter" %>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html;charset=gb2312">
<title><%=ResourceManager.GetString("codehighlighter")%></title>
<base target="_self" />
<link href="stylesheet.css" rel="stylesheet" type="text/css" />
 <script runat=server language="C#">
     protected void Page_Load(object sender, EventArgs e)
     {
         Response.Expires = -1;
         if (!IsPostBack)
         {
             CodeHighlighterConfiguration codeConfig = (CodeHighlighterConfiguration)System.Configuration.ConfigurationManager.GetSection("codeHighlighter");

             string[] keys = new string[codeConfig.LanguageConfigs.Keys.Count];
             codeConfig.LanguageConfigs.Keys.CopyTo(keys, 0);
             Array.Sort(keys);
             foreach (string key in keys)
             {
                 LanguageDropDownList.Items.Add(key);
                 if (key == "C#")
                 {
                     LanguageDropDownList.SelectedIndex = LanguageDropDownList.Items.Count - 1;
                 }
             }
             LineNumberMarginVisibleCheckBox.Text = ResourceManager.GetString("LineNumberMarginVisibleCheckBox");
             OutliningEnabledCheckBox.Text = ResourceManager.GetString("OutliningEnabledCheckBox");
             HighlightButton.Text = ResourceManager.GetString("HighlightButton");
         }

     }

     private void HighlightButton_Click(object sender, System.EventArgs e)
     {
         Codehighlighter1.LanguageKey = LanguageDropDownList.SelectedItem.Text;
         Codehighlighter1.OutliningEnabled = OutliningEnabledCheckBox.Checked;
         Codehighlighter1.LineNumberMarginVisible = LineNumberMarginVisibleCheckBox.Checked;
         Codehighlighter1.Text = CodeTextBox.Text.Replace("\\", "\\\\");
     }

     #region Web 窗体设计器生成的代码
     override protected void OnInit(EventArgs e)
     {
         //
         // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
         //
         InitializeComponent();
         base.OnInit(e);
     }

     /// <summary>
     /// 设计器支持所需的方法 - 不要使用代码编辑器修改
     /// 此方法的内容。
     /// </summary>
     private void InitializeComponent()
     {
         this.HighlightButton.Click += new System.EventHandler(this.HighlightButton_Click);
     }
     #endregion

     public void CodeHighlighter_PostRender(object sender, System.EventArgs e)
     {
         if (IsPostBack)
         {
             string code = Codehighlighter1.Output.Replace("\"", "\\\"");
             code = code.Replace("\r\n", "<br>\"+\r\n\"");
             string codstyle = @"<div style='BORDER-RIGHT: #cccccc 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #cccccc 1px solid; PADDING-LEFT: 4px; FONT-SIZE: 13px; PADDING-BOTTOM: 4px; BORDER-LEFT: #cccccc 1px solid; WIDTH: 98%; WORD-BREAK: break-all; PADDING-TOP: 4px; BORDER-BOTTOM: #cccccc 1px solid; BACKGROUND-COLOR: #eeeeee'>";
             if (HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].ToLower().IndexOf("msie") == -1)
             {
                 ClientScript.RegisterStartupScript(typeof(Page), "Key", @"window.opener.plugin_execommand(""" + codstyle + code + @"</div>"");window.parent.close();", true);
             }
             else
             {
                 ClientScript.RegisterStartupScript(typeof(Page), "Key", @"window.parent.returnValue =""" + codstyle + code + @"</div>"";window.parent.close();", true);
             }
         }
     }
 </script>
</head>
<body>
<form id="code" runat="server">
	<table border="0" cellpadding="0"cellspacing="0" width="100%">
	<tr>
		<td align="center">
			<div align="center">
				<table border=1 style="border-style:dashed ;"  bordercolor="#cccccc" >
					<tr>
						<td style="width: 86px; height: 32px" align="right">
                            <%=ResourceManager.GetString("codetype")%>：</td>
						<td style="width: 483px; height: 32px">
                            &nbsp;<asp:DropDownList Runat="server" ID="LanguageDropDownList" Width="69px" />&nbsp;
                            &nbsp;<asp:CheckBox Runat="server" ID="LineNumberMarginVisibleCheckBox" />&nbsp;<asp:CheckBox
                                ID="OutliningEnabledCheckBox" runat="server" />
                        </td>
					</tr>
					<tr>
						<td style="width: 86px; height: 353px;" align="right">
                            <%=ResourceManager.GetString("codecontent")%>：</td>
						<td style="width: 483px; height: 353px" align="center"><asp:TextBox Runat="server" ID="CodeTextBox" TextMode="MultiLine" Rows="10" Columns="80" Height="334px" Width="475px" BorderColor="Gray" BorderStyle="Dashed" BorderWidth="1px"/></td>
					</tr>
					<tr>
						<td style="height: 39px;" align="center" colspan="2"><asp:button id="HighlightButton" Runat="server"></asp:button>
                            <input type=Button ID="close" value="<%=ResourceManager.GetString("close2")%>"  OnClick="window.close()"/></td>
					</tr>
				</table>
			</div>
		</td>
		<td></td>
	</tr>
	<tr>
		<td class="FooterBar" colspan="2" align="center"></TD>
	</tr>	
	</table>
	<pre><ch:codehighlighter id="Codehighlighter1" runat="server" onpostrender="CodeHighlighter_PostRender"></ch:codehighlighter></pre>
</form>
</body>
<script language=javascript>
var userAgent = navigator.userAgent.toLowerCase();
var is_ie = (userAgent.indexOf('msie') != -1);
if(is_ie)
{
document.body.bgColor="ButtonFace";
}
else
{
document.body.bgColor="#E0E0E0";
}
</script>
</html>

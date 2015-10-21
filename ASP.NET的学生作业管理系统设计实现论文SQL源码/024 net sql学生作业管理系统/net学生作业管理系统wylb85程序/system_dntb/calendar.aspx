<%@ Page language="c#" AutoEventWireup="true" UICulture="auto" Culture="auto"%>
<%@ Import Namespace="DotNetTextBox" %>
<html>
<head>
<title>date</title>
<meta http-equiv="pragma" content="no-cache" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<base target="_self" />
<style type="text/css">
body,a,table,input,button{font-size:12px;font-family:宋体,Verdana,Arial}
</style>
<script runat="server" language="C#">
private void Page_Load(object sender, System.EventArgs e)
{
    if (Request.Cookies["languages"] != null)
    {
        ResourceManager.SiteLanguageKey = Request.Cookies["languages"].Value;
    }
    else
    {
        ResourceManager.SiteLanguageKey = HttpContext.Current.Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"].ToLower().Split(',')[0];
    }
}

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "Key", "insertDate('" + Calendar1.SelectedDate.ToString("yyyy-MM-dd") + "');", true);
    }
</script>
<script type="text/javascript">
Request = {
 QueryString : function(item){
  var svalue = location.search.match(new RegExp("[\?\&]" + item + "=([^\&]*)(\&?)","i"));
  return svalue ? svalue[1] : svalue;
 }
}

function insertDate(strCode)
{
　　parent.inserObject(parent.document.getElementById(Request.QueryString("name")).contentWindow,'nowdate',strCode);
　　parent.popMenu2.hide();
}
</script>
</head>
<body topmargin="2" bgcolor="#f9f8f7">
<form runat=server>
    <asp:Calendar ID="Calendar1" runat="server" BackColor="#F9F8F7" BorderColor="White"
        BorderWidth="1px" Font-Names="Verdana"
        Font-Size="9pt" ForeColor="Black" Height="200px" Width="220px" OnSelectionChanged="Calendar1_SelectionChanged" NextPrevFormat="FullMonth" ShowGridLines="True" BorderStyle="Dashed">
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TodayDayStyle BackColor="#CCCCCC" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <NextPrevStyle Font-Size="8pt" ForeColor="#333333" Font-Bold="True" VerticalAlign="Bottom" />
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <TitleStyle BackColor="White" Font-Bold="True"
            Font-Size="12pt" ForeColor="#333399" BorderColor="Black" BorderWidth="1px" BorderStyle="Dotted" />
    </asp:Calendar><input onclick="parent.popMenu2.hide();" type="button" value='<%=ResourceManager.GetString("close")%>' /></form>
</body></html>
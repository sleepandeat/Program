<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ggdetail.aspx.cs" Inherits="ggdetail" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>助学新版</title><LINK href="qtimages/style.css" type=text/css rel=stylesheet>
<style type="text/css">
<!--
.STYLE5 {	color: #FFFFFF;
	font-weight: bold;
}
.STYLE6 {font-size: 12pt}
-->
</style>
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <div>
         <table align="center" border="0" bordercolor="#a5dfc6" cellpadding="0" cellspacing="0"
                                class="newsline" style="border-collapse: collapse" width="98%">
                                <tr>
                                    <td align="center" height="33">
                                        <span style="color: #477641">
                                            <%=ntitle %>
                                            (点击率：<%=ndianjilv %>)</span></td>
                                </tr>
                                <tr>
                                    <td align="left" height="110">
                                        <%=ncontent %>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <input name="Submit5" onclick="javascript:history.back();" style="border-right: #000000 1px solid;
                                            border-top: #000000 1px solid; border-left: #000000 1px solid; color: #666666;
                                            border-bottom: #000000 1px solid; height: 19px" type="button" value="返回" /></td>
                                </tr>
                            </table>

    </div>
      
    </form>
</body>
</html>

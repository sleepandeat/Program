<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xueshengxinxi_detail.aspx.cs" Inherits="xueshengxinxi_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title><LINK href="images/StyleSheet.css" type=text/css rel=stylesheet>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" border="1" bordercolordark="#9cc7ef" bordercolorlight="#145aa0"
            cellpadding="4" cellspacing="0" width="70%">
            <tr bgcolor="#4296e7">
                <td colspan="4">
                    <div align="center">
                        <font color="#ffffff">学生信息详细</font></div>
                </td>
            </tr>
            <tr>
                <td width='11%' height=44>学号：</td><td width='39%'><%=nxuehao%></td><td  rowspan=10 align=center><a href="<%=nzhaopian%>" target=_blank><img src=<%=nzhaopian%> width=228 height=215 border=0></a></td></tr><tr><td width='11%' height=44>姓名：</td><td width='39%'><%=nxingming%></td></tr><tr><td width='11%' height=44>密码：</td><td width='39%'><%=nmima%></td></tr><tr><td width='11%' height=44>专业：</td><td width='39%'><%=nzhuanye%></td></tr><tr><td width='11%' height=44>班级：</td><td width='39%'><%=nbanji%></td></tr><tr><td width='11%' height=44>性别：</td><td width='39%'><%=nxingbie%></td></tr><tr><td width='11%' height=44>电话：</td><td width='39%'><%=ndianhua%></td></tr><tr><td width='11%' height=44>籍贯：</td><td width='39%'><%=njiguan%></td></tr><tr><td width='11%' height=44>身份证：</td><td width='39%'><%=nshenfenzheng%></td></tr><tr><td width='11%' height=44>入学时间：</td><td width='39%'><%=nruxueshijian%></td></tr><tr><td width='11%' height=100  >备注：</td><td width='39%' colspan=2 height=100 ><%=nbeizhu%></td></tr><tr><td colspan=3 align=center><input type=button name=Submit5 value=返回 style='border:solid 1px #000000; color:#666666' onClick="javascript:history.back()" />&nbsp;<input type=button name=Submit5 value=打印 style='border:solid 1px #000000; color:#666666' onClick="javascript:window.print()" /></td></tr>
            
            
            
            <tr bgcolor="#4296e7">
                <td colspan="4">&nbsp;
                    </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>


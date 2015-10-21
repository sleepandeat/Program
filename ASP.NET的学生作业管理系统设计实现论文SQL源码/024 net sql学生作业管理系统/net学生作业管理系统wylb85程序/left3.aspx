<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left3.aspx.cs" Inherits="left3" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title><link rel="stylesheet" href="css.css"><script src="images/prototype.js"></script>

<style type="text/css">
<!--
body,td,th {
	font-size: 12px;
}
body {
	background-color: #F7F7F7;
	background-image: url(images/left_02_01_02.gif);
}
.STYLE2 {color: #FFFFFF}
.STYLE3 {color: #17A25F}
-->
</style>
</head>
<BODY leftMargin=0 topMargin=0 marginwidth="0" marginheight="0">

    <form id="form1" runat="server">
    <div>
  <table id="__01" width="184" border="0" cellpadding="0" cellspacing="0">
	
	<tr>
		<td  background="images/left_02_01_02.gif"><table width="184"  border="0" cellpadding="0" cellspacing="0" background="images/left_02_01_02.gif" id="Table1">
          <tr>
            <td><table id="Table2" width="184" border="0" cellpadding="0" cellspacing="0">
              <tr onClick="new Element.toggle('submenu1')" style="cursor:hand;">
                <td width="184"  background="images/left_02_01_01.gif"><table width="100%" height="26" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                    <td width="90%"  height="26" align="center" valign="bottom"><span class="STYLE3"><strong>个人资料管理</strong></span></td>
                    <td width="10%">&nbsp;</td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td width="184"  style="display:none"  id="submenu1">
				<table width="91%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
     <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
      <td ><a href="xueshengxinxi_updt2.aspx" target="mainFrame">个人资料管理</a></td>
    </tr>
    
  </table>				</td>
              </tr>
              
            </table></td>
          </tr>
          <tr>
            <td><table id="Table3" width="184" border="0" cellpadding="0" cellspacing="0">
              <tr onClick="new Element.toggle('submenu2')" style="cursor:hand;">
                <td width="184" background="images/left_02_01_01.gif"><table width="100%" height="26" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="90%"  height="26" align="center" valign="bottom"><span class="STYLE3"><strong>公告信息查看</strong></span></td>
                      <td width="10%">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td width="184" background="images/left_02_01_02.gif"  style="display:none"  id="submenu2"><table width="91%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                      <td ><a href="news.aspx?lb=公告信息" target="mainFrame">公告信息查看</a></td>
                    </tr>
                   
                </table></td>
              </tr>
             
            </table></td>
          </tr>
          <tr>
            <td><table id="Table4" width="184" border="0" cellpadding="0" cellspacing="0">
              <tr onClick="new Element.toggle('submenu3')" style="cursor:hand;">
                <td width="184" background="images/left_02_01_01.gif"><table width="100%" height="26" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="90%" height="26" align="center" valign="bottom"><span class="STYLE3"><strong>在线选课</strong></span></td>
                      <td width="10%">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td width="184" background="images/left_02_01_02.gif"  style="display:none"  id="submenu3"><table width="91%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                      <td ><a href="jiaoshikaike_list3.aspx" target="mainFrame">在线选课</a></td>
                    </tr>
                    <tr>
                      <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                      <td ><a href="xuankejilu_list2.aspx" target="mainFrame">已选查询</a></td>
                    </tr>
                </table></td>
              </tr>
            
            </table></td>
          </tr>
          <tr>
            <td><table id="Table5" width="184" border="0" cellpadding="0" cellspacing="0">
              <tr onClick="new Element.toggle('submenu4')" style="cursor:hand;">
                <td width="184" background="images/left_02_01_01.gif"><table width="100%" height="26" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="90%"  height="26" align="center" valign="bottom"><span class="STYLE3"><strong>在线提问</strong></span></td>
                      <td width="10%">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td width="184" background="images/left_02_01_02.gif"  style="display:none"  id="submenu4"><table width="91%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                      <td ><a href="liuyanbanadd.aspx" target="mainFrame">在线提问</a></td>
                    </tr>
                    <tr>
                      <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                      <td ><a href="liuyanban.aspx" target="mainFrame">问题查看</a></td>
                    </tr>
                </table></td>
              </tr>
             
            </table></td>
          </tr>
          <tr>
            <td><table id="Table6" width="184" border="0" cellpadding="0" cellspacing="0">
              <tr onClick="new Element.toggle('submenu5')" style="cursor:hand;">
                <td width="184" background="images/left_02_01_01.gif"><table width="100%" height="26" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="90%"  height="26" align="center" valign="bottom"><span class="STYLE3"><strong>作业管理</strong></span></td>
                      <td width="10%">&nbsp;</td>
                    </tr>
                </table></td>
              </tr>
              <tr>
                <td width="184" background="images/left_02_01_02.gif"  style="display:none"  id="submenu5"><table width="91%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                      <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                      <td ><a href="zuoyefabu_list3.aspx" target="mainFrame">作业查看</a></td>
                    </tr>
                    <tr>
                      <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                      <td ><a href="zuoyeshangjiao_add.aspx" target="mainFrame">作业上交</a></td>
                    </tr>
                    <tr>
                      <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                      <td ><a href="zuoyeshangjiao_list2.aspx" target="mainFrame">已交查询</a></td>
                    </tr>
                </table></td>
              </tr>
             
            </table>
             </td>
          </tr>
            <tr>
              <td>
              <table id="Table7" width="184" border="0" cellpadding="0" cellspacing="0">
                <tr onClick="new Element.toggle('submenu6')" style="cursor:hand;">
                  <td width="184" background="images/left_02_01_01.gif"><table width="100%" height="26" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="90%"  height="26" align="center" valign="bottom"><span class="STYLE3"><strong>课件下载</strong></span></td>
                        <td width="10%">&nbsp;</td>
                      </tr>
                  </table></td>
                </tr>
                <tr>
                  <td width="184" background="images/left_02_01_02.gif"  style="display:none"  id="submenu6"><table width="91%" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                        <td ><a href="kejianxinxi_list3.aspx" target="mainFrame">课件下载</a></td>
                      </tr>
                     
                  </table></td>
                </tr>
               
              </table>
               </td>
          </tr>
           <%-- <tr>
              <td>
              <table id="Table8" width="184" border="0" cellpadding="0" cellspacing="0">
                <tr onClick="new Element.toggle('submenu7')" style="cursor:hand;">
                  <td width="184" background="images/left_02_01_01.gif"><table width="100%" height="26" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="90%"  height="26" align="center" valign="bottom"><span class="STYLE3"><strong>系统管理</strong></span></td>
                        <td width="10%">&nbsp;</td>
                      </tr>
                  </table></td>
                </tr>
                <tr>
                  <td width="184" background="images/left_02_01_02.gif"   id="submenu7"><table width="91%" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                        <td ><a href="youqinglianjie_add.aspx" target="mainFrame">友情连接添加</a></td>
                      </tr>
                      <tr>
                        <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                        <td ><a href="youqinglianjie_list.aspx" target="mainFrame">友情连接查询</a></td>
                      </tr>
					  <tr>
                        <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                        <td ><a href="lyb_gl.aspx" target="mainFrame">留言管理</a></td>
                      </tr>
                      <tr>
                        <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                        <td ><a href="dx.aspx?lb=系统简介" target="mainFrame">系统简介设置</a></td>
                      </tr>
					  <tr>
                        <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                        <td ><a href="dx.aspx?lb=系统公告" target="mainFrame">系统公告设置</a></td>
                      </tr>
                      <tr>
                        <td width="36" height="22" align="center"><img src="images/left_02_01.gif"></td>
                        <td ><a href="databack.aspx" target="mainFrame">数据备份</a></td>
                      </tr>
                  </table></td>
                </tr>
               
              </table>
               </td>
          </tr>--%>
            <tr>
              <td>
              <table id="Table9" width="184" border="0" cellpadding="0" cellspacing="0">
                <tr >
                  <td width="184" background="images/left_02_01_01.gif"><table width="100%" height="26" border="0" cellpadding="0" cellspacing="0">
                      <tr>
                        <td width="90%"  height="26" align="center" valign="bottom"><span class="STYLE3"><strong>系统版权</strong></span></td>
                        <td width="10%">&nbsp;</td>
                      </tr>
                  </table></td>
                </tr>
                <tr>
                  <td width="184" background="images/left_02_01_02.gif"   id="Td1"><table width="91%" border="0" align="center" cellpadding="0" cellspacing="0">
                      <tr>
                        <td colspan="2" align="center"><p><br>
                          系统作者：xxxxxx</p>
                        <p>指导老师：xxxxx</p>
                        <p>所在学校：xxxxx</p></td>
                      </tr>
                      
                  </table></td>
                </tr>
              
              </table></td>
          </tr>
        </table></td>
	</tr>
	
</table>

    </div>
    </form>
</body>
</html>

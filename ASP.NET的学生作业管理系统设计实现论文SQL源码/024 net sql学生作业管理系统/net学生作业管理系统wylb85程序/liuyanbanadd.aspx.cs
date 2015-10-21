using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class liuyanbanadd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql;
        string nbq = "";
        if (RadioButton1.Checked)
        {
            nbq = "1";
        }
        if (RadioButton2.Checked)
        {
            nbq = "2";
        }
        if (RadioButton3.Checked)
        {
            nbq = "3";
        }
        if (RadioButton4.Checked)
        {
            nbq = "4";
        }
        if (RadioButton5.Checked)
        {
            nbq = "5";
        }
        sql = "insert into liuyanban(cheng,biaoqing,biaoti,neirong,huifu) values('" + cheng.Text.ToString().Trim() + "','" + nbq + "','" + biaoti.Text.ToString().Trim() + "','" + neirong.Text.ToString().Trim() + "','" + huifu.Text.ToString().Trim() + "') ";
        int result;
        result = new Class1().hsgexucute(sql);
        if (result == 1)
        {
            Response.Write("<script>javascript:alert('操作成功');location.href='liuyanban.aspx';</script>");
        }
        else
        {
            Response.Write("<script>javascript:alert('系统错误，请检查数据库设置问题');</script>");
        }
    }



}


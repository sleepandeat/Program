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

public partial class jiaoshixinxi_updt2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
   
        if (!IsPostBack)
        {
			 xingbie.Items.Add("male"); 
			 xingbie.Items.Add("female");
		gonghao.ReadOnly = true;
            string sql;
            sql = "select * from jiaoshixinxi where gonghao='" + Session["username"].ToString().Trim() + "'";
            getdata(sql);
        }
    }



    private void getdata(string sql)
    {
        DataSet result = new DataSet();
        result = new Class1().hsggetdata(sql);
        if (result != null)
        {
            if (result.Tables[0].Rows.Count > 0)
            {
                gonghao.Text = result.Tables[0].Rows[0]["gonghao"].ToString().Trim();xingming.Text = result.Tables[0].Rows[0]["xingming"].ToString().Trim();mima.Text = result.Tables[0].Rows[0]["mima"].ToString().Trim();xingbie.Text = result.Tables[0].Rows[0]["xingbie"].ToString().Trim();dianhua.Text = result.Tables[0].Rows[0]["dianhua"].ToString().Trim();youxiang.Text = result.Tables[0].Rows[0]["youxiang"].ToString().Trim();shenfenzheng.Text = result.Tables[0].Rows[0]["shenfenzheng"].ToString().Trim();zhaopian.Text = result.Tables[0].Rows[0]["zhaopian"].ToString().Trim();zhicheng.Text = result.Tables[0].Rows[0]["zhicheng"].ToString().Trim();beizhu.Text = result.Tables[0].Rows[0]["beizhu"].ToString().Trim();
                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string sql;
        
        sql = "update jiaoshixinxi set gonghao='" + gonghao.Text.ToString().Trim() + "',xingming='" + xingming.Text.ToString().Trim() + "',mima='" + mima.Text.ToString().Trim() + "',xingbie='" + xingbie.Text.ToString().Trim() + "',dianhua='" + dianhua.Text.ToString().Trim() + "',youxiang='" + youxiang.Text.ToString().Trim() + "',shenfenzheng='" + shenfenzheng.Text.ToString().Trim() + "',zhaopian='" + zhaopian.Text.ToString().Trim() + "',zhicheng='" + zhicheng.Text.ToString().Trim() + "',beizhu='" + beizhu.Text.ToString().Trim() + "' where gonghao='" + Session["username"].ToString().Trim() + "'";
        int result;
        result = new Class1().hsgexucute(sql);
        if (result == 1)
        {
            Response.Write("<script>javascript:alert('修改成功');</script>");
        }
        else
        {
            Response.Write("<script>javascript:alert('系统错误');</script>");
        }
    }
}


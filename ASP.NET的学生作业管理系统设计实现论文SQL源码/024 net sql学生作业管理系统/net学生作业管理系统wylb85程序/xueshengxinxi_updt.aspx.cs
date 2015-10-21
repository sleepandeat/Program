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

public partial class xueshengxinxi_updt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
   
        if (!IsPostBack)
        {
			 xingbie.Items.Add("male"); 
			 xingbie.Items.Add("female");
            string sql;
            sql = "select * from xueshengxinxi where id=" + Request.QueryString["id"].ToString().Trim() ;
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
                xuehao.Text = result.Tables[0].Rows[0]["xuehao"].ToString().Trim();xingming.Text = result.Tables[0].Rows[0]["xingming"].ToString().Trim();mima.Text = result.Tables[0].Rows[0]["mima"].ToString().Trim();zhuanye.Text = result.Tables[0].Rows[0]["zhuanye"].ToString().Trim();banji.Text = result.Tables[0].Rows[0]["banji"].ToString().Trim();xingbie.Text = result.Tables[0].Rows[0]["xingbie"].ToString().Trim();dianhua.Text = result.Tables[0].Rows[0]["dianhua"].ToString().Trim();jiguan.Text = result.Tables[0].Rows[0]["jiguan"].ToString().Trim();shenfenzheng.Text = result.Tables[0].Rows[0]["shenfenzheng"].ToString().Trim();zhaopian.Text = result.Tables[0].Rows[0]["zhaopian"].ToString().Trim();ruxueshijian.Text = DateTime.Parse(result.Tables[0].Rows[0]["ruxueshijian"].ToString().Trim()).ToShortDateString();beizhu.Text = result.Tables[0].Rows[0]["beizhu"].ToString().Trim();
                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string sql;
        
        sql = "update xueshengxinxi set xuehao='" + xuehao.Text.ToString().Trim() + "',xingming='" + xingming.Text.ToString().Trim() + "',mima='" + mima.Text.ToString().Trim() + "',zhuanye='" + zhuanye.Text.ToString().Trim() + "',banji='" + banji.Text.ToString().Trim() + "',xingbie='" + xingbie.Text.ToString().Trim() + "',dianhua='" + dianhua.Text.ToString().Trim() + "',jiguan='" + jiguan.Text.ToString().Trim() + "',shenfenzheng='" + shenfenzheng.Text.ToString().Trim() + "',zhaopian='" + zhaopian.Text.ToString().Trim() + "',ruxueshijian='" + ruxueshijian.Text.ToString().Trim() + "',beizhu='" + beizhu.Text.ToString().Trim() + "' where id=" + Request.QueryString["id"].ToString().Trim();
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


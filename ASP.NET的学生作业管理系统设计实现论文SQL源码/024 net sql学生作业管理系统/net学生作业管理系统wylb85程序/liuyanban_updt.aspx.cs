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

public partial class liuyanban_updt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
   
        if (!IsPostBack)
        {
			// xingbie.Items.Add("male"); 
			// xingbie.Items.Add("female");
            string sql;
            sql = "select * from liuyanban where id=" + Request.QueryString["id"].ToString().Trim() ;
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
                cheng.Text = result.Tables[0].Rows[0]["cheng"].ToString().Trim();biaoqing.Text = result.Tables[0].Rows[0]["biaoqing"].ToString().Trim();biaoti.Text = result.Tables[0].Rows[0]["biaoti"].ToString().Trim();neirong.Text = result.Tables[0].Rows[0]["neirong"].ToString().Trim();huifu.Text = result.Tables[0].Rows[0]["huifu"].ToString().Trim();
                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string sql;
        
        sql = "update liuyanban set cheng='" + cheng.Text.ToString().Trim() + "',biaoqing='" + biaoqing.Text.ToString().Trim() + "',biaoti='" + biaoti.Text.ToString().Trim() + "',neirong='" + neirong.Text.ToString().Trim() + "',huifu='" + huifu.Text.ToString().Trim() + "' where id=" + Request.QueryString["id"].ToString().Trim();
        int result;
        result = new Class1().hsgexucute(sql);
        if (result == 1)
        {
            Response.Write("<script>javascript:alert('回复成功');</script>");
        }
        else
        {
            Response.Write("<script>javascript:alert('系统错误');</script>");
        }
    }
}


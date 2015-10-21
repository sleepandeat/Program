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

public partial class kechengxinxi_updt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
   
        if (!IsPostBack)
        {
            leixing.Items.Add("必修");
            leixing.Items.Add("选修");
            string sql;
            sql = "select * from kechengxinxi where id=" + Request.QueryString["id"].ToString().Trim() ;
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
                kechengbianhao.Text = result.Tables[0].Rows[0]["kechengbianhao"].ToString().Trim();kechengmingcheng.Text = result.Tables[0].Rows[0]["kechengmingcheng"].ToString().Trim();xueshi.Text = result.Tables[0].Rows[0]["xueshi"].ToString().Trim();xuefen.Text = result.Tables[0].Rows[0]["xuefen"].ToString().Trim();leixing.Text = result.Tables[0].Rows[0]["leixing"].ToString().Trim();beizhu.Text = result.Tables[0].Rows[0]["beizhu"].ToString().Trim();
                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string sql;
        
        sql = "update kechengxinxi set kechengbianhao='" + kechengbianhao.Text.ToString().Trim() + "',kechengmingcheng='" + kechengmingcheng.Text.ToString().Trim() + "',xueshi='" + xueshi.Text.ToString().Trim() + "',xuefen='" + xuefen.Text.ToString().Trim() + "',leixing='" + leixing.Text.ToString().Trim() + "',beizhu='" + beizhu.Text.ToString().Trim() + "' where id=" + Request.QueryString["id"].ToString().Trim();
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


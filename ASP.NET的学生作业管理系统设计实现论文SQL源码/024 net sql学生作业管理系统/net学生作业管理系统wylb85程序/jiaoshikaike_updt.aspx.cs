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

public partial class jiaoshikaike_updt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
   
        if (!IsPostBack)
        {
            addxiala("kechengxinxi", "kechengmingcheng", "kehubianhao");
            string sql;
            sql = "select * from jiaoshikaike where id=" + Request.QueryString["id"].ToString().Trim() ;
            getdata(sql);
        }
    }

    private void addxiala(string ntable, string nzd, string nxlk)
    {
        string sql;
        sql = "select " + nzd + " from " + ntable + " order by id desc";
        DataSet result = new DataSet();
        result = new Class1().hsggetdata(sql);
        if (result != null)
        {
            if (result.Tables[0].Rows.Count > 0)
            {
                int i = 0;
                for (i = 0; i < result.Tables[0].Rows.Count; i++)
                {
                    kecheng.Items.Add(result.Tables[0].Rows[i][0].ToString().Trim());
                }
            }
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
                kecheng.Text = result.Tables[0].Rows[0]["kecheng"].ToString().Trim();kaikejiaoshi.Text = result.Tables[0].Rows[0]["kaikejiaoshi"].ToString().Trim();beizhu.Text = result.Tables[0].Rows[0]["beizhu"].ToString().Trim();
                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string sql;
        
        sql = "update jiaoshikaike set kecheng='" + kecheng.Text.ToString().Trim() + "',kaikejiaoshi='" + kaikejiaoshi.Text.ToString().Trim() + "',beizhu='" + beizhu.Text.ToString().Trim() + "' where id=" + Request.QueryString["id"].ToString().Trim();
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


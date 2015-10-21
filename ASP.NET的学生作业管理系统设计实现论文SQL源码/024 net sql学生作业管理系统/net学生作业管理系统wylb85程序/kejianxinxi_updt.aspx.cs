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

public partial class kejianxinxi_updt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
   
        if (!IsPostBack)
        {
            leixing.Items.Add("zip");
            leixing.Items.Add("doc");
            leixing.Items.Add("pdf");
            leixing.Items.Add("rar");
            leixing.Items.Add("xls");
            leixing.Items.Add("swf");
            string sql;
            sql = "select * from kejianxinxi where id=" + Request.QueryString["id"].ToString().Trim() ;
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
                kejianbianhao.Text = result.Tables[0].Rows[0]["kejianbianhao"].ToString().Trim();kejianmingcheng.Text = result.Tables[0].Rows[0]["kejianmingcheng"].ToString().Trim();leixing.Text = result.Tables[0].Rows[0]["leixing"].ToString().Trim();wenjian.Text = result.Tables[0].Rows[0]["wenjian"].ToString().Trim();faburen.Text = result.Tables[0].Rows[0]["faburen"].ToString().Trim();
                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string sql;
        
        sql = "update kejianxinxi set kejianbianhao='" + kejianbianhao.Text.ToString().Trim() + "',kejianmingcheng='" + kejianmingcheng.Text.ToString().Trim() + "',leixing='" + leixing.Text.ToString().Trim() + "',wenjian='" + wenjian.Text.ToString().Trim() + "',faburen='" + faburen.Text.ToString().Trim() + "' where id=" + Request.QueryString["id"].ToString().Trim();
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


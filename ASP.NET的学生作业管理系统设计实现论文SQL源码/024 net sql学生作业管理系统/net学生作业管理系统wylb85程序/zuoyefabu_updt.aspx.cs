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

public partial class zuoyefabu_updt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
   
        if (!IsPostBack)
        {
			// xingbie.Items.Add("male"); 
			// xingbie.Items.Add("female");
            string sql;
            sql = "select * from zuoyefabu where id=" + Request.QueryString["id"].ToString().Trim() ;
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
                zuoyebianhao.Text = result.Tables[0].Rows[0]["zuoyebianhao"].ToString().Trim();zuoyemingcheng.Text = result.Tables[0].Rows[0]["zuoyemingcheng"].ToString().Trim();neirongyaoqiu.Text = result.Tables[0].Rows[0]["neirongyaoqiu"].ToString().Trim();fujian.Text = result.Tables[0].Rows[0]["fujian"].ToString().Trim();shangjiaoqixian.Text = DateTime.Parse(result.Tables[0].Rows[0]["shangjiaoqixian"].ToString().Trim()).ToShortDateString();faburen.Text = result.Tables[0].Rows[0]["faburen"].ToString().Trim();
                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string sql;
        
        sql = "update zuoyefabu set zuoyebianhao='" + zuoyebianhao.Text.ToString().Trim() + "',zuoyemingcheng='" + zuoyemingcheng.Text.ToString().Trim() + "',neirongyaoqiu='" + neirongyaoqiu.Text.ToString().Trim() + "',fujian='" + fujian.Text.ToString().Trim() + "',shangjiaoqixian='" + shangjiaoqixian.Text.ToString().Trim() + "',faburen='" + faburen.Text.ToString().Trim() + "' where id=" + Request.QueryString["id"].ToString().Trim();
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


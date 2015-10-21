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

public partial class zuoyeshangjiao_updtlb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
   
        if (!IsPostBack)
        {
			// xingbie.Items.Add("male"); 
			// xingbie.Items.Add("female");
            string sql;
            sql = "select * from zuoyeshangjiao where id=" + Request.QueryString["id"].ToString().Trim() ;
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
                zuoyebianhao.Text = result.Tables[0].Rows[0]["zuoyebianhao"].ToString().Trim();zuoyemingcheng.Text = result.Tables[0].Rows[0]["zuoyemingcheng"].ToString().Trim();zuoyeneirong.Text = result.Tables[0].Rows[0]["zuoyeneirong"].ToString().Trim();fujian.Text = result.Tables[0].Rows[0]["fujian"].ToString().Trim();shangjiaoren.Text = result.Tables[0].Rows[0]["shangjiaoren"].ToString().Trim();jiaoshipingyu.Text = result.Tables[0].Rows[0]["jiaoshipingyu"].ToString().Trim();zuoyechengji.Text = result.Tables[0].Rows[0]["zuoyechengji"].ToString().Trim();
                
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string sql;
        
        sql = "update zuoyeshangjiao set zuoyebianhao='" + zuoyebianhao.Text.ToString().Trim() + "',zuoyemingcheng='" + zuoyemingcheng.Text.ToString().Trim() + "',zuoyeneirong='" + zuoyeneirong.Text.ToString().Trim() + "',fujian='" + fujian.Text.ToString().Trim() + "',shangjiaoren='" + shangjiaoren.Text.ToString().Trim() + "',jiaoshipingyu='" + jiaoshipingyu.Text.ToString().Trim() + "',zuoyechengji='" + zuoyechengji.Text.ToString().Trim() + "' where id=" + Request.QueryString["id"].ToString().Trim();
        int result;
        result = new Class1().hsgexucute(sql);
        if (result == 1)
        {
            Response.Write("<script>javascript:alert('操作成功');</script>");
        }
        else
        {
            Response.Write("<script>javascript:alert('系统错误');</script>");
        }
    }
}


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

public partial class allgonggao_updt : System.Web.UI.Page
{
    public string lbtxt;
    protected void Page_Load(object sender, EventArgs e)
    {

       
   
        if (!IsPostBack)
        {
			// xingbie.Items.Add("male"); 
			// xingbie.Items.Add("female");
            string sql;
            sql = "select * from allgonggao where id=" + Request.QueryString["id"].ToString().Trim() ;
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
                title.Text = result.Tables[0].Rows[0]["title"].ToString().Trim();content.Text = result.Tables[0].Rows[0]["content"].ToString();leibie.Text = result.Tables[0].Rows[0]["leibie"].ToString().Trim();shouyetupian.Text = result.Tables[0].Rows[0]["shouyetupian"].ToString().Trim();dianjilv.Text = result.Tables[0].Rows[0]["dianjilv"].ToString().Trim();
                lbtxt = result.Tables[0].Rows[0]["leibie"].ToString().Trim();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string sql;
        
        sql = "update allgonggao set title='" + title.Text.ToString().Trim() + "',content='" + content.Text.ToString() + "',leibie='" + leibie.Text.ToString().Trim() + "',shouyetupian='" + shouyetupian.Text.ToString().Trim() + "',dianjilv='" + dianjilv.Text.ToString().Trim() + "' where id=" + Request.QueryString["id"].ToString().Trim();
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


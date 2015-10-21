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

public partial class ggdetail : System.Web.UI.Page
{
    public string ntitle, ncontent, ndianjilv;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)  //该页意思与 gg_updt.aspx.cs中的完全相似
        {
            string sql;
            sql = "update allgonggao set dianjilv=dianjilv+1 where id=" + Request.QueryString["id"].ToString().Trim();
            new Class1().hsgexucute(sql);
            sql = "select * from allgonggao where id=" + Request.QueryString["id"].ToString().Trim();
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
                ntitle = result.Tables[0].Rows[0]["title"].ToString().Trim();
                ncontent = result.Tables[0].Rows[0]["content"].ToString();
                ndianjilv = result.Tables[0].Rows[0]["dianjilv"].ToString().Trim();
            }
        }
    }
}

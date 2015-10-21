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

public partial class zuoyeshangjiao_detail : System.Web.UI.Page
{
	public string nzuoyebianhao,nzuoyemingcheng,nzuoyeneirong,nfujian,nshangjiaoren,njiaoshipingyu,nzuoyechengji;
    protected void Page_Load(object sender, EventArgs e)
    {
   
        if (!IsPostBack)
        {
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
                nzuoyebianhao = result.Tables[0].Rows[0]["zuoyebianhao"].ToString().Trim();nzuoyemingcheng = result.Tables[0].Rows[0]["zuoyemingcheng"].ToString().Trim();nzuoyeneirong = result.Tables[0].Rows[0]["zuoyeneirong"].ToString().Trim();nfujian = result.Tables[0].Rows[0]["fujian"].ToString().Trim();nshangjiaoren = result.Tables[0].Rows[0]["shangjiaoren"].ToString().Trim();njiaoshipingyu = result.Tables[0].Rows[0]["jiaoshipingyu"].ToString().Trim();nzuoyechengji = result.Tables[0].Rows[0]["zuoyechengji"].ToString().Trim();
                
            }
        }
    }
    
}


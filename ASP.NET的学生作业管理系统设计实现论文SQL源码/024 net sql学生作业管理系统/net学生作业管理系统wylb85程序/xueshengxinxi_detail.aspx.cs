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

public partial class xueshengxinxi_detail : System.Web.UI.Page
{
	public string nxuehao,nxingming,nmima,nzhuanye,nbanji,nxingbie,ndianhua,njiguan,nshenfenzheng,nzhaopian,nruxueshijian,nbeizhu;
    protected void Page_Load(object sender, EventArgs e)
    {
   
        if (!IsPostBack)
        {
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
                nxuehao = result.Tables[0].Rows[0]["xuehao"].ToString().Trim();nxingming = result.Tables[0].Rows[0]["xingming"].ToString().Trim();nmima = result.Tables[0].Rows[0]["mima"].ToString().Trim();nzhuanye = result.Tables[0].Rows[0]["zhuanye"].ToString().Trim();nbanji = result.Tables[0].Rows[0]["banji"].ToString().Trim();nxingbie = result.Tables[0].Rows[0]["xingbie"].ToString().Trim();ndianhua = result.Tables[0].Rows[0]["dianhua"].ToString().Trim();njiguan = result.Tables[0].Rows[0]["jiguan"].ToString().Trim();nshenfenzheng = result.Tables[0].Rows[0]["shenfenzheng"].ToString().Trim();nzhaopian = result.Tables[0].Rows[0]["zhaopian"].ToString().Trim();nruxueshijian = result.Tables[0].Rows[0]["ruxueshijian"].ToString().Trim();nbeizhu = result.Tables[0].Rows[0]["beizhu"].ToString().Trim();
                
            }
        }
    }
    
}


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

public partial class kejianxinxi_list2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            leixing.Items.Add("所有");
            leixing.Items.Add("zip");
            leixing.Items.Add("doc");
            leixing.Items.Add("pdf");
            leixing.Items.Add("rar");
            leixing.Items.Add("xls");
            leixing.Items.Add("swf");
            string sql;
            sql = "select * from kejianxinxi where faburen ='" + Session["username"].ToString().Trim() + "' order by id desc";
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
                DataGrid1.DataSource = result.Tables[0];
                DataGrid1.DataBind();
                Label1.Text = "以上数据中共" + result.Tables[0].Rows.Count+"条";
            }
            else
            {
                DataGrid1.DataSource = null;
                DataGrid1.DataBind();
                Label1.Text = "暂无任何数据";
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql;
        sql = "select * from kejianxinxi where faburen ='" + Session["username"].ToString().Trim() + "' ";
        if (kejianbianhao.Text.ToString().Trim()!="" ){ sql=sql+" and kejianbianhao like '%" + kejianbianhao.Text.ToString().Trim() + "%'";}if (kejianmingcheng.Text.ToString().Trim()!="" ){ sql=sql+" and kejianmingcheng like '%" + kejianmingcheng.Text.ToString().Trim() + "%'";}if (leixing.Text.ToString().Trim()!="所有" ){ sql=sql+" and leixing like '%" + leixing.Text.ToString().Trim() + "%'";}if (faburen.Text.ToString().Trim()!="" ){ sql=sql+" and faburen like '%" + faburen.Text.ToString().Trim() + "%'";}
        sql = sql + " order by id desc";

        getdata(sql);
    }

    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        string sql;
        sql = "select * from kejianxinxi where faburen ='" + Session["username"].ToString().Trim() + "' order by id desc";
        getdata(sql);
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
        DataGrid1.DataBind();
    }
	public string riqigeshi(object str)
    {
        string strTmp = str.ToString();
        DateTime dt = Convert.ToDateTime(strTmp);
        string ss = dt.ToShortDateString();
        return ss;
        
    } 
}


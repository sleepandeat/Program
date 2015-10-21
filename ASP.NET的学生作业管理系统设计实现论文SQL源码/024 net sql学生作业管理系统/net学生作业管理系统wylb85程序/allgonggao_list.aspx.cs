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

public partial class allgonggao_list : System.Web.UI.Page
{
    public string lb, lbtxt, sql; //定义全局变量
    protected void Page_Load(object sender, EventArgs e)
    {
      //  lb = Request.QueryString["lb"].ToString().Trim();  
        lbtxt = Request.QueryString["lb"].ToString().Trim();  //类别为提交来的参数
       
       
        if (!IsPostBack)
        {

            string sql;
            sql = "select * from allgonggao where leibie='"+lbtxt+"' order by id desc";
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
        sql = "select * from allgonggao where leibie='"+lbtxt+"'";
        if (title.Text.ToString().Trim()!="" ){ sql=sql+" and title like '%" + title.Text.ToString().Trim() + "%'";}
        sql = sql + " order by id desc";

        getdata(sql);
    }

    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        string sql;
        sql = "select * from allgonggao where leibie='" + lbtxt + "' order by id desc";
        getdata(sql);
        DataGrid1.CurrentPageIndex = e.NewPageIndex;
        DataGrid1.DataBind();
    }
}


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

public partial class liuyanban : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // xingbie.Items.Add("所有"); 
            // xingbie.Items.Add("male"); 
            // xingbie.Items.Add("female");
            string sql;
            sql = "select * from liuyanban where 1=1 order by id desc";
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
                DataList1.DataSource = result.Tables[0];
                DataList1.DataBind();
                // Label1.Text = "以上数据中共" + result.Tables[0].Rows.Count + "条";
            }
            else
            {
                DataList1.DataSource = null;
                DataList1.DataBind();
                //Label1.Text = "暂无任何数据";
            }
        }
    }



    public string riqigeshi(object str)
    {
        string strTmp = str.ToString();
        DateTime dt = Convert.ToDateTime(strTmp);
        string ss = dt.ToShortDateString();
        return ss;

    }
}


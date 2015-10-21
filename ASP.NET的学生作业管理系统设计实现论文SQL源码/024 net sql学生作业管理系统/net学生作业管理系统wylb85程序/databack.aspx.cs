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
using System.Data.SqlClient;

public partial class databack : System.Web.UI.Page
{
    SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["cn"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cx"].ToString().Trim() != "超级管理员")
        {
            Response.Write("<script>javascript:alert('对不起,您没有这个权限');history.back();</script>");
            Response.End();
        }
        SqlCommand mycmd = new SqlCommand();
        string myExecuteQuery = "backup database netxszyglwylb85 to disk='D:/netxszyglwylb85.dat'";
        SqlCommand myCommand = new SqlCommand(myExecuteQuery, myConnection);
        myCommand.Connection.Open();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
        Response.Write("<script>javascript:alert('数据成功备份于D:/netxszyglwylb85.dat');location.href='sy.aspx';</script>");
        Response.End();
    }
}

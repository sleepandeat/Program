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

public partial class allgonggao_add : System.Web.UI.Page
{
    public string lb, lbtxt, sql; //定义全局变量
    protected void Page_Load(object sender, EventArgs e)
    {
        lbtxt = Request.QueryString["lb"].ToString().Trim();  //类别为提交来的参数
        
        leibie.Text = lbtxt;
         Random rnd = new Random();
         int n = rnd.Next(1, 100);
         dianjilv.Text = n.ToString().Trim();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sql;
        sql="insert into allgonggao(title,content,leibie,shouyetupian,dianjilv) values('"+title.Text.ToString().Trim()+"','"+content.Text.ToString()+"','"+leibie.Text.ToString().Trim()+"','"+shouyetupian.Text.ToString().Trim()+"','"+dianjilv.Text.ToString().Trim()+"') ";
        int result;
        result = new Class1().hsgexucute(sql);
        if (result == 1)
        {
            Response.Write("<script>javascript:alert('添加成功');</script>");
        }
        else
        {
            Response.Write("<script>javascript:alert('系统错误，请检查数据库设置问题');</script>");
        }
    }
	//private void addxiala(string ntable, string nzd, string nxlk)
    //{
    //    string sql;
    //    sql = "select "+nzd+" from "+ntable+" order by id desc";
    //    DataSet result = new DataSet();
    //    result = new Class1().hsggetdata(sql);
    //    if (result != null)
    //    {
    //        if (result.Tables[0].Rows.Count > 0)
    //       {
    //            int i = 0;
    //            for (i = 0; i < result.Tables[0].Rows.Count; i++)
    //            {
    //                kehubianhao.Items.Add(result.Tables[0].Rows[i][0].ToString().Trim());
    //            }
    //        }
    //    }
    //}
}


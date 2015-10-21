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

public partial class jiaoshixinxi_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
        {
			
			 xingbie.Items.Add("male"); 
			 xingbie.Items.Add("female");
			// addxiala("kehuxinxi","bianhao","kehubianhao");
			
			//ghdhdnuuks  string sql = "select * from yifngpsiafnxfinxgi where id=" + Request.QueryString["id"].ToString().Trim();
            //ghdhdnuuks  DataSet result = new DataSet();
            //ghdhdnuuks  result = new Class1().hsggetdata(sql);
            //ghdhdnuuks  if (result != null)
            //ghdhdnuuks  {
            //ghdhdnuuks    if (result.Tables[0].Rows.Count > 0)
            //ghdhdnuuks     {
                    //lsiebigsaodguqdufz

            //ghdhdnuuks     }
            //ghdhdnuuks  }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
		//shuziyanzheng
        string sql;
	 ischongfu("select id from jiaoshixinxi where gonghao='"+gonghao.Text.ToString().Trim()+"'");

        sql="insert into jiaoshixinxi(gonghao,xingming,mima,xingbie,dianhua,youxiang,shenfenzheng,zhaopian,zhicheng,beizhu) values('"+gonghao.Text.ToString().Trim()+"','"+xingming.Text.ToString().Trim()+"','"+mima.Text.ToString().Trim()+"','"+xingbie.Text.ToString().Trim()+"','"+dianhua.Text.ToString().Trim()+"','"+youxiang.Text.ToString().Trim()+"','"+shenfenzheng.Text.ToString().Trim()+"','"+zhaopian.Text.ToString().Trim()+"','"+zhicheng.Text.ToString().Trim()+"','"+beizhu.Text.ToString().Trim()+"') ";
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

	public void ischongfu(string sql)
    {
        DataSet result = new DataSet();
            result = new Class1().hsggetdata(sql);
            if (result != null)
            {
                if (result.Tables[0].Rows.Count > 0)
                {
                    Response.Write("<script>javascript:alert('提示,该数据已存在,不要重复添加');location.href='jiaoshixinxi_add.aspx';</script>");
                    Response.End();
                }
            }
    }
}


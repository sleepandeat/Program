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

public partial class xueshengxinxi_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
        {
			
			 xingbie.Items.Add("male"); 
			 xingbie.Items.Add("female");
		
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
		
        string sql;
	 ischongfu("select id from xueshengxinxi where xuehao='"+xuehao.Text.ToString().Trim()+"'");

        sql="insert into xueshengxinxi(xuehao,xingming,mima,zhuanye,banji,xingbie,dianhua,jiguan,shenfenzheng,zhaopian,ruxueshijian,beizhu) values('"+xuehao.Text.ToString().Trim()+"','"+xingming.Text.ToString().Trim()+"','"+mima.Text.ToString().Trim()+"','"+zhuanye.Text.ToString().Trim()+"','"+banji.Text.ToString().Trim()+"','"+xingbie.Text.ToString().Trim()+"','"+dianhua.Text.ToString().Trim()+"','"+jiguan.Text.ToString().Trim()+"','"+shenfenzheng.Text.ToString().Trim()+"','"+zhaopian.Text.ToString().Trim()+"','"+ruxueshijian.Text.ToString().Trim()+"','"+beizhu.Text.ToString().Trim()+"') ";
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
	

	public void ischongfu(string sql)
    {
        DataSet result = new DataSet();
            result = new Class1().hsggetdata(sql);
            if (result != null)
            {
                if (result.Tables[0].Rows.Count > 0)
                {
                    Response.Write("<script>javascript:alert('提示,该数据已存在,不要重复添加');location.href='xueshengxinxi_add.aspx';</script>");
                    Response.End();
                }
            }
    }
}


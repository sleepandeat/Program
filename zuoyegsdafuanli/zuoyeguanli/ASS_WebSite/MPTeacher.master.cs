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

public partial class MPTeacher : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //验证身份..
        //测试时可先注释下列行..
        //if (Session["TeaID"] == null)
        //{
        //    Response.Redirect(@"../SysManage/Default.aspx");
        //}
    }
}

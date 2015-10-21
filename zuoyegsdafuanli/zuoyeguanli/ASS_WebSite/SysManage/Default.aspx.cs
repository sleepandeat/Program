using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using AssDAL;

public partial class _SysDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lb_time.Text = DateTime.Now.ToString();
        lb_yearup.Text = (string)Session["yearup"];
        lb_yeardown.Text = (string)Session["yeardown"];
        lb_semester.Text = (string)Session["Semester"];        
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string tname = UserName.Text;
        string tpswd = Password.Text;
        if (tname == "" || tpswd == "")
        {
            ThrowMyException("请填入完成的登录信息");
        }
        if (DropDownList1.SelectedValue == "1")
        {
            ValidateStu(tname, tpswd);
        }
        else if (DropDownList1.SelectedValue == "2")
        {
            ValidateTea(tname, tpswd);
        }
        else
        {
            ValidateMan(tname, tpswd);
        }
    }
        
    private void ValidateStu(string tname, string tpswd)
    {
        ASSEntities assen = new ASSEntities();
        
        var result = (from stu in assen.Students
                     where stu.StuName == tname && stu.Pswd == tpswd
                     select stu).First();
        if (result == null)
        {
            ThrowMyException("学号不存在或密码不正确");
        }
        Session["tName"] = tname;
        Session["StuID"] = result.StuID;
        Response.Redirect(@"~/Students/Index.aspx");
    }

    private void ValidateTea(string tname, string tpswd)
    {
        ASSEntities assen = new ASSEntities();
        
        var result = (from tea in assen.Teachers
                     where tea.TeaName ==tname && tea.Pswd == tpswd
                     select tea).First();
        if (result == null)
        {
            ThrowMyException("教师不存在或密码不正确");
        }
        Session["tName"] = tname;
        Session["TeaID"] = result.TeaID;
        Response.Redirect(@"~/Teacher/Index.aspx");
    }

    private void ValidateMan(string tname, string tpswd)
    {
        if (tname != "master" || tpswd != ConfigurationManager.AppSettings["master"])
        {
            ThrowMyException("管理员不存在或密码不正确");
        }

        Session["Master"] = "true";
        Response.Redirect(@"~/Master/Index.aspx");
    }

    private void ThrowMyException(string extxt)
    {
        Exception ex = new Exception();
        ex.Data["tbnull"] = extxt;
        throw ex;
    }
}

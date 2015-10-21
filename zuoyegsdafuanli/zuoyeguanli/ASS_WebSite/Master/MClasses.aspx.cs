using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AssDAL;

public partial class Master_MClasses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (gv1.SelectedRow != null)
        {
            dv1.PageIndex = gv1.SelectedRow.DataItemIndex;
            dv1.DataBind();
            
        }
    }
    protected void EntityDataSource1_Deleting(object sender, EntityDataSourceChangingEventArgs e)
    {
        Classes classtodel = (Classes)e.Entity;

        classtodel.SetCourses.Load();
        classtodel.Students.Load();

        int i = (from sc in classtodel.SetCourses select sc).Count();
        int j = (from s in classtodel.Students select s).Count();

        if (classtodel.SetCourses.Count() != 0 || classtodel.Students.Count() != 0)
        {
            e.Cancel = true;
            Response.Write(@"<script>alert("+"此班级还有学生，不能删除！');</script>");
        }        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "")
        {
            return;
        }
        string[] arrclass = TextBox2.Text.Split(',');
        ASSEntities assen = new ASSEntities();
        foreach (string classsh in arrclass)
        {
            string classname = TextBox1.Text + classsh;
            
            Classes c = new Classes();
            c.ClassName = classname;
            assen.AddToClasses(c);
        }
        assen.SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AssDAL;

public partial class Master_MCourses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void EntityDataSource1_Deleting(object sender, EntityDataSourceChangingEventArgs e)
    {
        Courses classtodel = (Courses)e.Entity;

        classtodel.SetCourses.Load();

        int i = (from sc in classtodel.SetCourses select sc).Count();

        if (classtodel.SetCourses.Count() != 0)
        {
            e.Cancel = true;
            Exception ex = new Exception();
            ex.Data["DeleteError"] = "此班级还有学生，不能删除";
            throw ex;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text == "")
        {
            return;
        }
        string[] arrcourse = TextBox2.Text.Split(',');

        ASSEntities assen = new ASSEntities();
        
        foreach(string course in arrcourse)
        {
            Courses c = new Courses();
            c.CourseName = course;
            assen.AddToCourses(c);
        }
        assen.SaveChanges();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GridView1.SelectedRow != null)
        {
            DetailsView1.PageIndex = GridView1.SelectedRow.DataItemIndex;
            DetailsView1.DataBind();
            udpdv1.Update();
        }
    }
    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        GridView1.DataBind();
        udpgv1.Update();
    }
    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        GridView1.DataBind();
        udpgv1.Update();
    }
    protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
    {
        GridView1.DataBind();
        udpgv1.Update();
    }
}

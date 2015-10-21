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
using System.Linq;
using AssDAL;

public partial class Teacher_MCourses : System.Web.UI.Page
{
    IQueryable<myBinding> result;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadGridview();
    }

    private void LoadGridview()
    {
        ASSEntities assen = new ASSEntities();
        result = from sc in assen.SetCourses
                     select new myBinding { SCID= sc.SCID,ClassName= sc.Classes.ClassName,CourseName= sc.Courses.CourseName,TeaName= sc.Teachers.TeaName };

        GridView1.DataSource = result;
        GridView1.DataBind();
    }
    
    class myBinding
    {
        public int SCID { get; set; }
        public string ClassName { get; set; }
        public string CourseName { get; set; }
        public string TeaName { get; set; }
    }

    protected void btn_givesc_Click(object sender, EventArgs e)
    {
        if (tb_class.Text == "" || tb_course.Text == "" || tb_teaer.Text == "")
        {
            Exception ex = new Exception();
            ex.Data["tbnull"] = "数据不完整。";
            throw ex;
        }

        ASSEntities assen = new ASSEntities();
        SetCourses sc = new SetCourses();


        int ncint = int.Parse(tb_class.Text);
        int ncoint = int.Parse(tb_course.Text);
        int ntint = int.Parse(tb_teaer.Text);
        var newclass = (from nc in assen.Classes
                        where nc.ClassID == ncint
                        select nc).First();
        var newcourse = (from nco in assen.Courses
                         where nco.CourseID == ncoint
                         select nco).First();
        var newteacher = (from nt in assen.Teachers
                          where nt.TeaID == ntint
                          select nt).First();

        sc.SCID = 1;
        sc.Classes = newclass;
        sc.Courses = newcourse;
        sc.Teachers = newteacher;
        if (tb_semester.Text != "")
        {
            sc.Semester = tb_semester.Text;
        }
        else
        {
            sc.Semester = Session["schoolsemester"].ToString();
        }

        assen.AddToSetCourses(sc);
        assen.SaveChanges();

    }
    protected void btn_class_Click(object sender, EventArgs e)
    {
        gvselect_class.Visible = true;
        gvselect_class.DataBind();
    }
    protected void btn_course_Click(object sender, EventArgs e)
    {
        gvselect_course.Visible = true;
        gvselect_course.DataBind();
    }
    protected void btn_teaer_Click(object sender, EventArgs e)
    {
        gvselect_teacher.Visible = true;
        gvselect_teacher.DataBind();
    }
    protected void gvselect_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = gvselect_class.SelectedRow;
        if (gvr != null)
        {
            tb_class.Text = gvr.Cells[0].Text;
            lb_class.Text = gvr.Cells[1].Text;
        }
        ((GridView)sender).Visible = false;
    }
    protected void gvselect_course_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = gvselect_course.SelectedRow;
        if (gvr != null)
        {
            tb_course.Text = gvr.Cells[0].Text;
            lb_course.Text = gvr.Cells[1].Text;
        }
        ((GridView)sender).Visible = false;
    }
    protected void gvselect_teacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gvr = gvselect_teacher.SelectedRow;
        if (gvr != null)
        {
            tb_teaer.Text = gvr.Cells[0].Text;
            lb_teaer.Text = gvr.Cells[1].Text;
        }
        ((GridView)sender).Visible = false;
    }
    protected void btn_change_Click(object sender, EventArgs e)
    {
        if (tb_change.Text == "")
        {
            return;
        }
        string[] inf = tb_change.Text.Split(',');
        string inf_1 = inf[1].Trim();
        int inf_2 = int.Parse(inf[0].Trim());
        ASSEntities assen = new ASSEntities();
        var teacher = (from t in assen.Teachers
                       where t.TeaName == inf_1
                       select t).First();

        var setcourse = (from sc in assen.SetCourses
                         where sc.SCID == inf_2
                         select sc).First();

        setcourse.Teachers = teacher;
        assen.SaveChanges();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = result ; 
        GridView1.DataBind();
    }
}

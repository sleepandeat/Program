using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AssDAL;

public partial class Teacher_VClasses : System.Web.UI.Page
{
    ASSEntities assen = new ASSEntities();
    string teaName,semester;

    protected void Page_Load(object sender, EventArgs e)
    {
        teaName = Session["TeaName"] != null ? Session["TeaName"].ToString() : "任传成";
        semester = Session["Semester"] != null ? Session["Semester"].ToString() : "200820092";
        //加载GridView
        Loadgv_ClasswithCourse();
        Loadgv_Housework();
    }

    private void Loadgv_ClasswithCourse()
    {
        var result = from sc in assen.SetCourses
                     where sc.Teachers.TeaName == teaName && sc.Semester == semester
                     select new { sc.Classes.ClassName, sc.Courses.CourseName };

        gv_ClasseswithCourse.DataSource = result;
        gv_ClasseswithCourse.DataBind();
    }

    private void Loadgv_Housework()
    {
        var result = from house in assen.Assignments
                     from sc in assen.SetCourses
                     where house.SetCourses.SCID == sc.SCID && sc.Semester == semester
                     select new { sc.Classes.ClassName, sc.Courses.CourseName, house.AssName, house.Deadline };

        gv_Housework.DataSource = result;
        gv_Housework.DataBind();
    }
}

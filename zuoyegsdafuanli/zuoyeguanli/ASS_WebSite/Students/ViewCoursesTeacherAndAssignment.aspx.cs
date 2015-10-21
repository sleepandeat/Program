using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AssDAL;

public partial class Students_ViewCoursesTeacherAndAssignment : System.Web.UI.Page
{
    int stuID;
    string stuName;
    string semester;
    int classID;
    
    ASSEntities assen = new ASSEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        //取得学号与姓名及学期号
        stuID = Session["StuNum"] != null ? int.Parse(Session["TeaName"].ToString()) : 1;
        semester = Session["Semester"] != null ? Session["Semester"].ToString() : "200820092";
        var stu = (from s in assen.Students
                   where s.StuID == stuID
                   select s).First();
        stuName = stu.StuName;
        stu.ClassesReference.Load();
        classID = stu.Classes.ClassID;

        LoadCourseTea();
        LoadHousework();
    }    

    private void LoadCourseTea()
    {
        var result = from res in assen.SetCourses
                      where res.Classes.ClassID == classID && res.Semester == semester
                      select new { res.Courses.CourseName, res.Teachers.TeaName };

        gvCourseTea.DataSource = result;
        gvCourseTea.DataBind();
    }

    IQueryable<interContainer> result;
    private void LoadHousework()
    {
        result = from cl in assen.Classes
                 from sc in cl.SetCourses
                 from ass in sc.Assignments
                 where ass.SetCourses.SCID == sc.SCID && sc.Semester == semester && cl.ClassID == classID
                 select new interContainer {
                     AssID = ass.AssID,
                     AssName = ass.AssName,
                     AssDes = ass.AssDes,
                     CourseName = sc.Courses.CourseName,
                     QuesFileName = ass.QuesFileName,
                     QuesFileUrl = ass.QuesFileUrl,
                     Deadline = ass.Deadline,
                     TeaName = sc.Teachers.TeaName
                 };

        gvHousework.DataSource = result;
        gvHousework.DataBind();
    }

    class interContainer
    {
        public int AssID { get; set; }
        public string AssName { get; set; }
        public string AssDes { get; set; }
        public string CourseName { get; set; }
        public string QuesFileName { get; set; }
        public string QuesFileUrl { get; set; }
        public DateTime Deadline { get; set; }
        public string TeaName { get; set; }
    }

    protected void View_hwDetails(object sender, CommandEventArgs e)
    {
        if (!pnlDetails.Visible)
        {
            pnlDetails.Visible = true;
        }

        int AssID = int.Parse((string)e.CommandArgument);
        IQueryable<interContainer> ic = result.Where(r => r.AssID == AssID).AsQueryable<interContainer>();
        DetailsView1.DataSource = ic;
        DetailsView1.DataBind();
    }
    protected void gvHousework_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHousework.PageIndex = e.NewPageIndex;
        gvHousework.DataSource = result;
        gvHousework.DataBind();
    }
}

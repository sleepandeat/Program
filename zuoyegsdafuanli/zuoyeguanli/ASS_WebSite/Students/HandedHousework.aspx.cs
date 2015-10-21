using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AssDAL;

public partial class Students_HandedHousework : System.Web.UI.Page
{
    int stuID;
    string stuName;
    string semester;
    int classID;

    ASSEntities assen = new ASSEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        //取得学号、姓名、班级号及学期号
        stuID = Session["StuNum"] != null ? int.Parse(Session["TeaName"].ToString()) : 1;
        semester = Session["Semester"] != null ? Session["Semester"].ToString() : "200820092";
        var stu = (from s in assen.Students
                   where s.StuID == stuID
                   select s).First();
        stuName = stu.StuName;
        stu.ClassesReference.Load();
        classID = stu.Classes.ClassID;

        //加载Gridview
        Load_gvPosted();
    }

    protected void Load_gvPosted()
    {
        var res = assen.GETHOUSEWORKDONE(stuID, classID, semester).ToList();

        List<interBinding> final = new List<interBinding>();
        foreach (UpAssignments a in res)
        {
            a.AssignmentsReference.Load();
            a.Assignments.SetCoursesReference.Load();
            a.Assignments.SetCourses.CoursesReference.Load();
            a.Assignments.SetCourses.TeachersReference.Load();
            final.Add(new interBinding
            {
                AssName = a.Assignments.AssName,
                CourseName = a.Assignments.SetCourses.Courses.CourseName,
                TeaName = a.Assignments.SetCourses.Teachers.TeaName,
                FileName = a.FileName,
                FileUrl = a.FileUrl,
                Checked = a.Marks.HasValue?true:false,
                UpAssID = a.UpAssID
            });
        }

        gv_Posted.DataSource = final;
        gv_Posted.DataBind();
    }

    class interBinding
    {
        public string AssName { get; set; }
        public string CourseName { get; set; }
        public string TeaName { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public bool Checked { get; set; }
        public int UpAssID { get; set; }
    }

    protected void ViewResult_Clicked(object sender, CommandEventArgs e)
    {
        int uasid = int.Parse(e.CommandArgument.ToString());
        pnl_res.Visible = true;

        UpAssignments a = assen.UpAssignments.Where(ua => ua.UpAssID == uasid).First();
        lt_py.Text = a.Result;
        lb_sc.Text = a.Marks.ToString();
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        pnl_res.Visible = false;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AssDAL;

public partial class Students_StudentIndex : System.Web.UI.Page
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
        gv_NearTime();
    }

    protected void gv_NearTime()
    {
        var res = assen.GETHOUSEWORKTODO(stuID, classID, semester).ToList();

        List<interBinding> final = new List<interBinding>();
        foreach (Assignments a in res)
        {
            a.SetCoursesReference.Load();
            a.SetCourses.CoursesReference.Load();
            a.SetCourses.TeachersReference.Load();
            final.Add(new interBinding
            {
                AssName = a.AssName,
                CourseName = a.SetCourses.Courses.CourseName,
                TeaName = a.SetCourses.Teachers.TeaName,
                Deadline = a.Deadline
            });
        }

        gv_NotPosted.DataSource = final;
        gv_NotPosted.DataBind();
    }

    class interBinding
    {
        public string AssName { get; set; }
        public string CourseName { get; set; }
        public string TeaName { get; set; }
        public DateTime Deadline { get; set; }
    }
}

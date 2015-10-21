using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AssDAL;

public partial class Teacher_ViewHandOnOrNot : System.Web.UI.Page
{
    //教师号
    string teaName;
    string semester;
    int teaID;
    ASSEntities assen = new ASSEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        //取得教师与学期号
        teaName = Session["TeaName"] != null ? Session["TeaName"].ToString() : "任传成";
        semester = Session["Semester"] != null ? Session["Semester"].ToString() : "200820092";
        teaID = assen.Teachers.Where(t => t.TeaName == teaName).First().TeaID;
        //加载ListBox
        if (!IsPostBack)
        {
            DdlClass_Load(teaID);
        }
    }

    class interDdlClass
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
    }

    class MyClassComparer : IEqualityComparer<interDdlClass>
    {
        public bool Equals(interDdlClass x, interDdlClass y)
        {
            return x.ClassID == y.ClassID;
        }

        public int GetHashCode(interDdlClass obj)
        {
            return obj.ClassID.GetHashCode();
        }
    }

    //加载上方班级列表
    private void DdlClass_Load(int myTeaID)
    {
        var myclasses = (from sc in assen.SetCourses
                        where sc.Teachers.TeaID == myTeaID && sc.Semester == semester
                        select new interDdlClass {
                            ClassID = sc.Classes.ClassID,
                            ClassName = sc.Classes.ClassName }).ToList().Distinct(new MyClassComparer());

        if (!IsPostBack)
        { 
            ddl_class.DataSource = myclasses;
            ddl_class.DataTextField = "ClassName";
            ddl_class.DataValueField = "ClassID";
            ddl_class.DataBind();
        }        
    }

    public class internalPosted
    {
        public int StuID { get; set; }
        public string StuName { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public int upaID { get; set; }
        public bool NotChecked { get; set; }
    }

    //加载已提交作业的GridView
    List<internalPosted> li = new List<internalPosted>();
    private void LoadPosted(int cID, int corID, int assID)
    {
        var res_posted = (from re in assen.GETSTUWHOUSEWORK(cID,semester)
                     select re).ToList();

        if (corID == 0 && assID == 0)
        { 
            foreach (UpAssignments a in res_posted)
            {
                a.StudentsReference.Load();
                li.Add(new internalPosted
                {
                    StuID = a.Students.StuID,
                    StuName = a.Students.StuName,
                    upaID = a.UpAssID,
                    FileName = a.FileName,
                    FileUrl = a.FileUrl,
                    NotChecked = a.Marks.HasValue ? false : true
                });
            }
        }
        else if (assID == 0)
        {
            foreach (UpAssignments a in res_posted)
            {
                a.StudentsReference.Load();
                a.Students.ClassesReference.Load();
                if(a.Students.Classes.ClassID == cID)
                {
                    li.Add(new internalPosted
                    {
                        StuID = a.Students.StuID,
                        StuName = a.Students.StuName, 
                        upaID = a.UpAssID,
                        FileName = a.FileName, 
                        FileUrl = a.FileUrl,
                        NotChecked = a.Marks.HasValue ? false : true
                    });
                }                
            }
        }
        else
        {
            foreach (UpAssignments f in res_posted)
            {
                f.StudentsReference.Load();
                f.Students.ClassesReference.Load();
                foreach (SetCourses sc in assen.SetCourses)
                {
                    sc.CoursesReference.Load();
                    sc.ClassesReference.Load();
                    if(f.Students.Classes.ClassID == cID
                        && sc.Courses.CourseID == corID
                        && sc.Classes.ClassID == cID)
                    {
                        li.Add(new internalPosted
                         {
                             StuID = f.Students.StuID,
                             StuName = f.Students.StuName,
                             upaID = f.UpAssID,
                             FileName = f.FileName,
                             FileUrl = f.FileUrl,
                             NotChecked = f.Marks.HasValue ? false : true
                         });
                    }
                }
            }
        }
        
        gv_Posted.DataSource = li;
        gv_Posted.DataBind();
    }

    //加载未提交作业的GridView
    private void LoadNotPost(int cID, int corID, int assID)
    {
        var res_notposted = (from re in assen.GETSTUWOHOUSEWORK(cID,semester)
                             select re).ToList();

        if (corID == 0 && assID == 0)
        {
            gv_NotPost.DataSource = res_notposted;
            gv_NotPost.DataBind();

            return;
        }
        if (corID != 0 && assID == 0)
        {
            res_notposted.Where(r => r.Classes.ClassID == cID);
        }
        else
        {
            List<Students> temp = new List<Students>();
            foreach (Students s in res_notposted)
            {
                s.ClassesReference.Load();
                foreach(SetCourses sc in assen.SetCourses)
                {
                    sc.CoursesReference.Load();
                    sc.CoursesReference.Load();
                    if(s.Classes.ClassID == cID && sc.Classes.ClassID == cID
                        && sc.Courses.CourseID == assID)
                    {
                        temp.Add(s);
                    }
                }
            }
        }
        gv_NotPost.DataSource = res_notposted;
        gv_NotPost.DataBind();
    }

    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        assen = new ASSEntities();
        if (ddl_class.SelectedValue == "0")
        {
            panel_gv.Visible = false;
            panel_nul.Visible = true;
            //重置两个列表
            DdlCourseLoad(0);
            DdlAssLoad(0, 0);
        }
        else
        {
            panel_gv.Visible = true;
            panel_nul.Visible = false;
            try
            {
                int classid = int.Parse(ddl_class.SelectedValue);
                LoadPosted(classid,0,0);
                LoadNotPost(classid,0,0);
                //加载进一步分类的DDL -- CourseID
                DdlCourseLoad(classid);
                //清空DDLAss
                DdlAssLoad(0, 0);
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }        
    }
    
    private void DdlCourseLoad(int cid)
    {
        ddl_Course.Items.Clear();
        ddl_Course.Items.Add(new ListItem("选择一个课程", "0"));

        if (cid == 0)
            return;

        var resultcourse = from rc in assen.SetCourses
                           where rc.Teachers.TeaID == teaID && rc.Classes.ClassID == cid
                           && rc.Semester == semester
                           select new { rc.Courses.CourseID, rc.Courses.CourseName};
        ddl_Course.DataSource = resultcourse;
        ddl_Course.DataBind();
    }
    protected void ddl_Course_SelectedIndexChanged(object sender, EventArgs e)
    {
        int classid = int.Parse(ddl_class.SelectedValue);
        int courseid = int.Parse(ddl_Course.SelectedValue);
        //如果courseid为0，清空DDLAss与Label
        if (courseid == 0)
        {
            //重置DdlAss
            DdlAssLoad(0, 0);
            //隐藏Label
            LabelLoad(0);
        }
        else
        { 
            //进一步加载作业列表
            DdlAssLoad(classid, courseid);
        }
        //加载Gridview(会自动判断courseid为0的情况)
        LoadPosted(classid, courseid, 0);
        LoadNotPost(classid, courseid, 0);
    }

    private void DdlAssLoad(int cid, int corid)
    {        
        ddl_Housework.Items.Clear();
        ddl_Housework.Items.Add(new ListItem("选择一个作业", "0"));

        if (corid == 0)
        { return; }

        int resultscid = assen.SetCourses.Where(sc => sc.Teachers.TeaID == teaID &&
            sc.Classes.ClassID == cid && sc.Courses.CourseID == corid &&
            sc.Semester == semester).First().SCID;
        var result = assen.Assignments.Where(a => a.SetCourses.SCID == resultscid).AsQueryable<Assignments>();

        ddl_Housework.DataSource = result;
        ddl_Housework.DataBind();
    }
    protected void ddl_Housework_SelectedIndexChanged(object sender, EventArgs e)
    {
        int classid = int.Parse(ddl_class.SelectedValue);
        int courseid = int.Parse(ddl_Course.SelectedValue);
        //在这里courseid不会为0 -- 当其为0时你不会看到这个列表
        int assid = int.Parse(ddl_Housework.SelectedValue);
        //加载Gridview(会自动判断assid)/会判断assid为0
        LoadPosted(classid, courseid, assid);
        LoadNotPost(classid, courseid, assid);
        //加载那个Label/同样会判断assid为0
        LabelLoad(assid);
    }
    private void LabelLoad(int assid)
    {
        if (assid == 0)
        {
            lb_day.Visible = false;
            return;
        }
        lb_day.Visible = true;
        DateTime dl = assen.Assignments.Where(a => a.AssID == assid).First().Deadline;
        TimeSpan ts = dl - DateTime.Now;
        string Notes = "据此作业的最终提交截止日期还有" + ts.Days.ToString() + "天";
        lb_day.Text = Notes;
    }

    protected void Button_Eva(object sender, CommandEventArgs e)
    {
        pnl_Eva.Visible = true;
        pnl_NotPost.Visible = false;

        hfupaid.Value = (string)e.CommandArgument;
    }
    protected void btn_EvaOk_Click(object sender, EventArgs e)
    {
        int uid = int.Parse(hfupaid.Value);
        ASSEntities upass = new ASSEntities();
        UpAssignments ua = upass.UpAssignments.Where(u => u.UpAssID == uid).First();
        ua.Marks = int.Parse(tb_scores.Text);
        ua.Result = tb_py.Text;
        upass.SaveChanges();
        pnl_Eva.Visible = false;
        pnl_NotPost.Visible = true;
    }
    protected void btn_EvaCancel_Click(object sender, EventArgs e)
    {
        tb_py.Text = "";
        tb_scores.Text = "";
        hfupaid.Value = "";

        pnl_NotPost.Visible = true;
        pnl_Eva.Visible = false;
    }
}

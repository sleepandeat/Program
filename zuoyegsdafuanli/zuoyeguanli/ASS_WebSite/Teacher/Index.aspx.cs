using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AssDAL;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Teacher_TeacherIndex : System.Web.UI.Page
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
        
        lb_tea.Text = teaName;

        ////加载Gridview列表
        ////获取所教班级
        //var result = from c in assen.Classes
        //             from sc in assen.SetCourses
        //             where c.ClassID == sc.Classes.ClassID && sc.Teachers.TeaID == teaID && 
        //             sc.Semester == semester 
        //             select c;
        ////保存班级号的列表
        //List<int> li = new List<int>();
        //foreach (Classes item in result)
        //{
        //    li.Add(item.ClassID);
        //}        
        ////取得每个班级中的未交作业的学生
        //IEnumerable<Students> ret = assen.Students;
        //ret.Except(assen.Students);
        //foreach(int i in li)
        //{
        //    var res = assen.GETSTUWOHOUSEWORKOT(i,semester).AsQueryable<Students>();
        //    //将各班级的信息合并起来
        //    ret.Union(res);
        //}
        //var final = from f in ret
        //            select new { f.StuID, f.StuName, f.Classes.ClassName };
        //if (final != null)
        //{ 
        //    GridView1.DataSource = final;
        //    GridView1.DataBind();
        //}
        
        
    }
}

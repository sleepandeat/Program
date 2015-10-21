using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using AssDAL;

public partial class Students_HandOnHousework : Page
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
        
        //加载DropDownList
        Loadddl();
        //加载GridView
        gv_OutTime();
    }

    //加载要提交的作业与要重新提交的作业
    private void Loadddl()
    {
        var haventpost = assen.GETHOUSEWORKTODO(stuID,classID,semester).AsQueryable<Assignments>();
        //绑定未交作业列表
        if (!IsPostBack)
        { 
            ddl_up.DataSource = haventpost;
            ddl_up.DataBind();
        }
        
        var havepost = assen.GETHOUSEWORKDONE(stuID,classID,semester).ToList();
        List<interDdl> li = new List<interDdl>();
        foreach (UpAssignments ua in havepost)
        {
            ua.AssignmentsReference.Load();
            li.Add(new interDdl
            {
                UpAssID = ua.UpAssID,
                AssName = ua.Assignments.AssName
            });
        }
        //绑定允许重新提交的列表
        if (!IsPostBack)
        { 
            ddl_reload.DataSource = li;
            ddl_reload.DataBind();
        }  
    }

    class interDdl
    {
        public int UpAssID { get; set; }
        public string AssName { get; set; }
    }

    protected void btn_Up_Click(object sender, EventArgs e)
    {
        ASSEntities assen_up = new ASSEntities();
        //assen_up.
        //处理上传
        string fileExt;
        string fileSavepath;
        if (file_firstpost.HasFile)
        {
            fileExt = Path.GetExtension(file_firstpost.FileName);
            if (fileExt == ".rar" || fileExt == ".zip")
            {
                try
                {
                    fileSavepath = Server.MapPath(@"..\Uploads\Students\") + stuID.ToString() + @"\";
                    if (!Directory.Exists(fileSavepath))
                    {
                        Directory.CreateDirectory(fileSavepath);
                    }
                    file_firstpost.SaveAs(fileSavepath + file_firstpost.FileName);
                    string FileNameWithExt = Path.GetFileName(file_firstpost.FileName);
                    string FileUrl = @"../Uploads/Students/" + stuID.ToString() + @"/" + file_firstpost.FileName;

                    //保存到数据库
                    int relatedAssID = int.Parse(ddl_up.SelectedValue);
                    var stu = assen.Students.Where(s => s.StuID == stuID).First();
                    var ass = assen.Assignments.Where(a => a.AssID == relatedAssID).First();
                    
                    UpAssignments ua = new UpAssignments();
                    ua.Students = stu;
                    ua.Assignments = ass;
                    ua.FileName = FileNameWithExt;
                    ua.FileUrl = FileUrl;
                    assen.AddToUpAssignments(ua);
                    assen.AcceptAllChanges();
                    assen.SaveChanges();

                    //结果
                    lb_Success.Text = "上传成功！";
                }
                catch (Exception ex)
                {
                    lb_Success.Text = "发生错误：" + ex.Message.ToString();
                }
            }
            else
            {
                lb_Success.Text = "只允许上传rar、zip文件！";
            }
        }
        else
        {
            lb_Success.Text = "没有选择要上传的文件！";
        }
    }

    protected void btn_ReUpload_Click(object sender, EventArgs e)
    {
        ASSEntities assen_repost = new ASSEntities();
        //处理已上传的文件
        int relatedupAssID = int.Parse(ddl_reload.SelectedValue);
        var result = (from s in assen.UpAssignments
                      where s.UpAssID == relatedupAssID
                      select s).First();
        string OldFilenameWithPath = Server.MapPath(@"../Uploads/Students/" + stuID.ToString() + @"/") + result.FileName;
        try
        {
            File.Delete(OldFilenameWithPath);
        }
        catch(Exception ex)
        { 
            throw new Exception(ex.ToString()+"原有提交的作业不存在");
        }
                
        //处理上传(重新上传)
        string fileExt;
        string FileNameWithExt;
        string FileUrl;
        if (file_repost.HasFile)
        {
            fileExt = Path.GetExtension(file_repost.FileName);
            if (fileExt == ".rar" || fileExt == ".zip")
            {
                try
                {
                    file_repost.SaveAs(Server.MapPath(@"..\Uploads\Students\") + stuID.ToString() + @"\" + file_repost.FileName);
                    FileNameWithExt = Path.GetFileName(file_repost.FileName);
                    FileUrl = @"../Uploads/Students/" + stuID.ToString() + @"/" + file_repost.FileName;
                    //重新上传完毕，将修改信息保存到数据库
                    var final = assen_repost.UpAssignments.Where(ua => ua.UpAssID == relatedupAssID).First();
                    final.FileName = FileNameWithExt;
                    final.FileUrl = FileUrl;
                    assen_repost.SaveChanges();

                    lb_ReSuccess.Text = "重新上传成功！";
                }
                catch (Exception ex)
                {
                    lb_ReSuccess.Text = "发生错误：" + ex.Message.ToString();
                }
            }
            else
            {
                lb_ReSuccess.Text = "只允许上传rar、zip文件！";
            }
        }
        else
        {
            lb_ReSuccess.Text = "没有选择要上传的文件！";
        }
    }

    protected void gv_OutTime()
    {
        var res = assen.GETHOUSEWORKTODOOT(stuID, classID, semester).ToList();

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

        gv_Outime.DataSource = final;
        gv_Outime.DataBind();
    }

    class interBinding
    { 
        public string AssName{ get; set; }
        public string CourseName { get; set; }
        public string TeaName { get; set; }
        public DateTime Deadline { get; set; }
    }
}

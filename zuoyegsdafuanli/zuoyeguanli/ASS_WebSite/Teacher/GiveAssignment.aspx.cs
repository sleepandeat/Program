using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AssDAL;
using System.IO;

public partial class Teacher_GiveAssignments : System.Web.UI.Page
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
        ListBoxLoad(teaName);
    }

    private void ListBoxLoad(string teaName)
    {
        var myclasses = from sc in assen.SetCourses
                        where sc.Teachers.TeaName == teaName
                        select new { sc.SCID, sc.Classes.ClassName };

        ckbox_couses.DataSource = myclasses;
        ckbox_couses.DataTextField = "ClassName";
        ckbox_couses.DataValueField = "SCID";
        if (!IsPostBack)
        {
            ckbox_couses.DataBind();
        }
    }
    protected void btn_Day_Click(object sender, EventArgs e)
    {
        Calendar1.Visible = true;
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        tb_Deadline.Text = Calendar1.SelectedDate.Date.ToString();
        Calendar1.Visible = false;
    }
    protected void btn_Post_Click(object sender, EventArgs e)
    {
        //判断是否具备发布条件
        if (!upass.HasFile || ckbox_couses.SelectedItem == null || tb_Title.Text == "" || tb_Descr.Text == "" || 
            tb_Deadline.Text == "")
        {
            throw new Exception("有未填项目。");
        }
        //获取选项
        string AssName = tb_Title.Text;
        string AssDes = tb_Descr.Text;
        DateTime dl = DateTime.Parse(tb_Deadline.Text);
        List<SetCourses> arr = new List<SetCourses>();
        foreach (ListItem li in ckbox_couses.Items)
        {
            if (li.Selected)
            {
                int i = int.Parse(li.Value);
                var result = (from s in assen.SetCourses
                              where s.Semester == semester && s.Teachers.TeaName == teaName && s.SCID == i
                              select s).First();
                arr.Add(result);
            }
        }
        //处理上传并获取文件名
        string fileExt;
        fileExt = Path.GetExtension(upass.FileName);
        if (fileExt == ".rar" || fileExt == ".zip")
        {
            try
            {
                //确定当前教师文件存储的位置
                string FilePath = Server.MapPath(@"..\Uploads\Teachers\" + teaID.ToString() + @"\");
                if (!Directory.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);
                upass.SaveAs(FilePath + @"\" + upass.FileName);
                //获取文件名
                string FileNameWithExt = Path.GetFileName(upass.FileName);
                //确定文件路径
                string FullFilePath = @"../Uploads/Teachers/" + teaID.ToString() + @"/" + FileNameWithExt;
                //将信息保存到数据库中
                foreach(SetCourses item in arr)
                {
                    Assignments ass = new Assignments();
                    ass.AssName = AssName;
                    ass.AssDes = AssDes;
                    ass.SetCourses = item;
                    ass.Deadline = dl;
                    ass.QuesFileName = FileNameWithExt;
                    ass.QuesFileUrl = FullFilePath;

                    assen.AddToAssignments(ass);
                    assen.SaveChanges();                                  
                }
                //成功
                lb_Success.Text = "发布成功！";   
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
}

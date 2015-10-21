using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using AssDAL;

public partial class Teacher_EditAssignment : System.Web.UI.Page
{
    static int HouseworkNum;
    string FilePath = "";
    ASSEntities assen= new ASSEntities();
    string teaName;
    string semester;
    int teaID;

    protected void Page_Load(object sender, EventArgs e)
    {
        //取得教师与学期号
        teaName = Session["TeaName"] != null ? Session["TeaName"].ToString() : "任传成";
        semester = Session["Semester"] != null ? Session["Semester"].ToString() : "200820092";
        teaID = assen.Teachers.Where(t => t.TeaName == teaName).First().TeaID;
    }

    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        panel_edit.Visible = true;
        HouseworkNum = int.Parse(e.CommandArgument.ToString());
        var result = (from ass in assen.Assignments
                  where ass.AssID == HouseworkNum
                  select ass).First();
        FilePath = result.QuesFileUrl;
    }
    protected void btnRePost_Click(object sender, EventArgs e)
    {
        if (FilePath != "")
        {
            try
            {
                File.Delete(FilePath);
            }
            catch
            {
                throw new Exception("原题目文件不存在！");
            }
        }
        //处理上传
        string fileExt;
        if (FileUpload1.HasFile)
        {
            fileExt = Path.GetExtension(FileUpload1.FileName);
            if (fileExt == ".rar" || fileExt == ".zip")
            {
                try
                {
                    FileUpload1.SaveAs(Server.MapPath(@"..\Uploads\Teachers") + @"\" + FileUpload1.FileName);
                    string FileNameWithExt = Path.GetFileName(FileUpload1.FileName);
                    string FileSavePath = @"../Uploads/Teachers/" + teaID.ToString() + @"/" + FileUpload1.FileName;

                    //信息插入数据库
                    var result = assen.Assignments.Where(a => a.AssID == HouseworkNum).First();
                    result.QuesFileName = FileNameWithExt;
                    result.QuesFileUrl = FileSavePath;
                    assen.SaveChanges();
                    //成功了
                    lb_Success.Text = "重新提交作业成功！";
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
        panel_edit.Visible = false;
    }
}

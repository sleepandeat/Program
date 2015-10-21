<%@ Page Language="C#" AutoEventWireup="true"%>
<%@ Import Namespace="DotNetTextBox" %>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>上传功能高级设置</title>
    <link href="stylesheet.css" rel="stylesheet" type="text/css" />
    <base target="_self" />
    <script runat=server language="C#">
        DotNetTextBox.doctextboxdb boxdb, _db;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                bind();
            }

        }
        protected void bind()
        {
            boxdb = new doctextboxdb();
            _db = new doctextboxdb();
            Response.Expires = -1;
            System.Collections.ArrayList mylist;
            if (Request.Cookies["uploadConfig"] != null)
            {
                //获取配置文件内容
                mylist = boxdb.get_the_xmlmessage(Request.Cookies["uploadConfig"].Value.ToLower());

            }
            else
            {
                mylist = boxdb.get_the_xmlmessage(HttpContext.Current.Request.PhysicalApplicationPath + "/system_dntb/uploadconfig/default.config");
            }

            //获取条件配置内容
            System.Collections.ArrayList _list = _db.get_the_xmlmessage(Server.MapPath("Advanced.config"));

            //判断上传文件夹的最大可用空间是否起用
            if (_list[1].ToString().Equals("0"))
            {
                this.maxAllUploadSize.Enabled = false;
                RangeValidator1.Enabled = false;
                this.Button3.Enabled = false;
            }
            //判断设置上传文件单个的最大尺寸是否起用
            if (_list[2].ToString().Equals("0"))
            {
                this.maxSingleUploadSize.Enabled = false;
                RangeValidator2.Enabled = false;
                this.Button1.Enabled = false;
            }
            //判断设置上传文件是否自动改名是否起用
            if (_list[3].ToString().Equals("0"))
            {
                this.autoname.Enabled = false;
                Button4.Enabled = false;
            }
            //判断设置是否允许上传是否起用
            if (_list[4].ToString().Equals("0"))
            {
                this.allowUpload.Enabled = false;
                this.Button5.Enabled = false;
            }
            //是否在上传界面启用水印选择是否起用
            if (_list[5].ToString().Equals("0"))
            {
                this.watermarkOption.Enabled = false;
                this.Button6.Enabled = false;
            }
            //判断是否启用上传图片的文字水印是否起用
            if (_list[6].ToString().Equals("0"))
            {
                this.watermark.Enabled = false;
                this.Button7.Enabled = false;
            }
            //开启文字水印后是否保留原件并新建副本是否起用
            if (_list[7].ToString().Equals("0"))
            {
                this.watermarkName.Enabled = false;
                this.Button8.Enabled = false;
            }
            //设置水印文字是否起用
            if (_list[8].ToString().Equals("0"))
            {
                this.watermarkText.Enabled = false;
                this.Button9.Enabled = false;
            }
            //是否启用上传图片的图片水印是否起用
            if (_list[9].ToString().Equals("0"))
            {
                this.watermarkImages.Enabled = false;
                this.Button10.Enabled = false;
            }
            //开启图片水印后是否保留原件并新建副本是否起用
            if (_list[10].ToString().Equals("0"))
            {
                this.watermarkImagesName.Enabled = false;
                this.Button11.Enabled = false;
            }
            if (_list[11].ToString().Equals("0"))
            {
                this.watermarkImages_path.Enabled = false;
                this.FileUpload1.Enabled = false;
                this.Button2.Enabled = false;
                this.Button12.Enabled = false;
            }
            //是否启用缩略图是否起用
            if (_list[12].ToString().Equals("0"))
            {
                this.smallImages.Enabled = false;
                this.Button13.Enabled = false;
            }
            //开启缩略图后是否保留原件并新建副本是否起用
            if (_list[13].ToString().Equals("0"))
            {
                this.smallImagesName.Enabled = false;
                this.Button14.Enabled = false;
            }
            //缩略图缩放类型是否起用
            if (_list[14].ToString().Equals("0"))
            {
                this.smallImagesType.Enabled = false;
                this.Button15.Enabled = false;
            }
            //缩略图宽度是否起用
            if (_list[15].ToString().Equals("0"))
            {
                this.smallImagesW.Enabled = false;
                RangeValidator3.Enabled = false;
                this.Button16.Enabled = false;
            }
            //缩略图高度是否起用
            if (_list[16].ToString().Equals("0"))
            {
                this.smallImagesH.Enabled = false;
                RangeValidator4.Enabled = false;
                this.Button17.Enabled = false;
            }
            //是否允许删除文件是否起用
            if (_list[17].ToString().Equals("0"))
            {
                this.delete.Enabled = false;
                this.Button18.Enabled = false;
            }
            //是否允许文件重命名是否起用
            if (_list[18].ToString().Equals("0"))
            {
                this.edit.Enabled = false;
                this.Button19.Enabled = false;
            }
            //是否显示文件列表是否起用
            if (_list[19].ToString().Equals("0"))
            {
                this.fileListBox.Enabled = false;
                this.Button20.Enabled = false;

            }
            //上传文件功能可上传的文件类型是否起用
            if (_list[20].ToString().Equals("0"))
            {
                this.fileFilters.Enabled = false;
                this.Button21.Enabled = false;

            }
            //上传图片功能可上传的文件类型是否起用
            if (_list[21].ToString().Equals("0"))
            {
                this.imagesFilters.Enabled = false;
                this.Button22.Enabled = false;
            }
            //上传自动播放文件功能可上传的文件类型是否起用
            if (_list[22].ToString().Equals("0"))
            {
                this.mediaFilters.Enabled = false;
                this.Button23.Enabled = false;
            }
            //上传模板功能可上传的文件类型是否起用
            if (_list[23].ToString().Equals("0"))
            {
                this.templateFilters.Enabled = false;
                this.Button24.Enabled = false;
            }


            //上传文件夹的最大可用空间
            this.maxAllUploadSize.Text = mylist[1].ToString();
            //上传文件单个的最大尺寸
            this.maxSingleUploadSize.Text = mylist[2].ToString();
            //上传文件是否自动改名
            for (int i = 0; i < this.autoname.Items.Count; i++)
            {
                if (this.autoname.Items[i].Value.Equals(mylist[3].ToString()))
                {
                    this.autoname.Items[i].Selected = true;
                }
            }
            //是否允许上传
            for (int i = 0; i < this.allowUpload.Items.Count; i++)
            {
                if (this.allowUpload.Items[i].Value.Equals(mylist[4].ToString()))
                {
                    this.allowUpload.Items[i].Selected = true;
                }
            }
            //在上传界面启用水印选择
            for (int i = 0; i < this.watermarkOption.Items.Count; i++)
            {
                if (this.watermarkOption.Items[i].Value.Equals(mylist[5].ToString()))
                {
                    this.watermarkOption.Items[i].Selected = true;
                }
            }
            //启用上传图片的文字水印
            for (int i = 0; i < watermark.Items.Count; i++)
            {
                if (this.watermark.Items[i].Value.Equals(mylist[6].ToString()))
                {
                    this.watermark.Items[i].Selected = true;
                }
            }
            //开启文字水印后是否保留原件并新建副本
            for (int i = 0; i < this.watermarkName.Items.Count; i++)
            {
                if (this.watermarkName.Items[i].Value.Equals(mylist[7].ToString()))
                {
                    this.watermarkName.Items[i].Selected = true;
                }
            }
            //水印文字
            this.watermarkText.Text = mylist[8].ToString();
            //是否启用上传图片的图片水印
            for (int i = 0; i < this.watermarkImages.Items.Count; i++)
            {
                if (this.watermarkImages.Items[i].Value.Equals(mylist[9].ToString()))
                {
                    this.watermarkImages.Items[i].Selected = true;
                }
            }
            //图片水印后是否保留原件并新建副本
            for (int i = 0; i < watermarkImagesName.Items.Count; i++)
            {
                if (this.watermarkImagesName.Items[i].Value.Equals(mylist[10].ToString()))
                {
                    this.watermarkImagesName.Items[i].Selected = true;
                }
            }
            //图片水印所在的位置
            this.watermarkImages_path.Text = mylist[11].ToString();
            //是否启用缩略图
            for (int i = 0; i < this.smallImages.Items.Count; i++)
            {
                if (this.smallImages.Items[i].Value.Equals(mylist[12].ToString()))
                {
                    this.smallImages.Items[i].Selected = true;
                }
            }
            //开启缩略图后是否保留原件并新建副本
            for (int i = 0; i < this.smallImagesName.Items.Count; i++)
            {
                if (this.smallImagesName.Items[i].Value.Equals(mylist[13].ToString()))
                {
                    this.smallImagesName.Items[i].Selected = true;
                }
            }
            //缩略图缩放类型,HW:指定高宽缩放(可能变形)。W:指定宽，高按比例。H:指定高，宽按比例。Cut:指定高宽裁减(不变形)
            for (int i = 0; i < this.smallImagesType.Items.Count; i++)
            {
                if (this.smallImagesType.Items[i].Text.Equals(mylist[14].ToString()))
                {
                    this.smallImagesType.Items[i].Selected = true;
                }
            }
            //缩略图宽度
            this.smallImagesW.Text = mylist[15].ToString();
            //缩略图高度
            this.smallImagesH.Text = mylist[16].ToString();
            //是否允许删除文件
            for (int i = 0; i < this.delete.Items.Count; i++)
            {
                if (this.delete.Items[i].Value.Equals(mylist[17].ToString()))
                {
                    this.delete.Items[i].Selected = true;
                }
            }
            //是否允许文件重命名
            for (int i = 0; i < this.edit.Items.Count; i++)
            {
                if (this.edit.Items[i].Value.Equals(mylist[18].ToString()))
                {
                    this.edit.Items[i].Selected = true;
                }
            }
            //是否显示文件列表
            for (int i = 0; i < this.fileListBox.Items.Count; i++)
            {
                if (this.fileListBox.Items[i].Value.Equals(mylist[19].ToString()))
                {
                    this.fileListBox.Items[i].Selected = true;
                }
            }
            //上传文件功能可上传的文件类型
            this.fileFilters.Text = mylist[20].ToString();
            //上传图片功能可上传的文件类型
            this.imagesFilters.Text = mylist[21].ToString();
            //上传自动播放文件功能可上传的文件类型
            this.mediaFilters.Text = mylist[22].ToString();
            //上传模板功能可上传的文件类型
            this.templateFilters.Text = mylist[23].ToString();
        }
        /// <summary>
        /// 上传图片到textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(Path.GetFullPath(Server.MapPath(Request.Cookies["uploadFolder"].Value.ToLower())));
            FileInfo[] fis = d.GetFiles();
            Double Size = 0;
            ArrayList showfile = new ArrayList();
            string[] Filters = this.imagesFilters.Text.Split(',');
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
                for (int i = 0; i <= Filters.Length - 1; i++)
                {
                    if (fi.Extension.ToLower() == "." + Filters[i].ToString().ToLower())
                    {
                        showfile.Add(fi);
                        break;
                    }
                }
            }

            Size = Convert.ToDouble((Double)Size / 1024);
            if (Size < Double.Parse(this.maxAllUploadSize.Text))
            {
                if (Request.Cookies["uploadFolder"] != null)
                {
                    if (this.FileUpload1.PostedFile.FileName != null && this.FileUpload1.PostedFile.FileName != "" && this.FileUpload1.PostedFile.ContentLength <= Double.Parse(this.maxSingleUploadSize.Text) * 1024)
                    {
                        this.FileUpload1.PostedFile.SaveAs(Server.MapPath(Request.Cookies["uploadFolder"].Value.ToLower() + "logo.gif"));
                        this.watermarkImages_path.Text = Request.Cookies["uploadFolder"].Value.ToLower() + "logo.gif";
                        ClientScript.RegisterStartupScript(typeof(Page), "Key", "alert('上传成功!')", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "Key", "alert('上传失败,文件超过限制大小或文件名为空!')", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "Key", "alert('上传失败,空间已满!')", true);
                }
            }
        }

        /// <summary>
        /// 设置上传文件夹的最大可用空间(单位KB)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            xml_update(Button3, "maxAllUploadSize", maxAllUploadSize.Text.Trim());
        }
        /// <summary>
        /// 设置上传文件单个的最大尺寸(单位KB)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            xml_update(Button1, "maxSingleUploadSize", maxSingleUploadSize.Text.Trim());
        }
        /// <summary>
        /// 设置上传文件是否自动改名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            xml_update(Button4, "autoname", autoname.SelectedValue);
        }
        /// <summary>
        /// 设置是否允许上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            xml_update(Button5, "allowUpload", allowUpload.SelectedValue);
        }
        /// <summary>
        /// 通用帮助函数
        /// </summary>
        /// <param name="button"></param>
        /// <param name="jiedianname"></param>
        /// <param name="the_value"></param>
        private void xml_update(Button button, string jiedianname, string the_value)
        {
            boxdb = new doctextboxdb();
            string path;
            if (Request.Cookies["uploadConfig"] != null)
            {
                //获取配置文件内容
                path = Request.Cookies["uploadConfig"].Value.ToLower();

            }
            else
            {
                path = HttpContext.Current.Request.PhysicalApplicationPath + "/system_dntb/uploadconfig/default.config";
            }
            bool check = boxdb.update_xml(path, "configuration", jiedianname, the_value);
            if (check) { button.Text = "更新成功"; } else { button.Text = "更新失败,点击重新更新"; }
            ClientScript.RegisterStartupScript(typeof(Page), "Key", "alert('更新成功!')", true);

        }
        /// <summary>
        /// 是否在上传界面启用水印选择的选项on为开启，off为关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button6_Click(object sender, EventArgs e)
        {
            xml_update(Button6, "watermarkOption", watermarkOption.SelectedValue);
            if (watermarkOption.SelectedItem.Text == "否")
            {
                watermark.Enabled = false;
                watermarkName.Enabled = false;
                watermarkText.Enabled = false;
                watermarkImages.Enabled = false;
                watermarkImagesName.Enabled = false;
                watermarkImages_path.Enabled = false;
                this.FileUpload1.Enabled = false;
                Button2.Enabled = false;
                imagesFilters.Enabled = false;
                this.Button7.Enabled = false;
                this.Button8.Enabled = false;
                this.Button9.Enabled = false;
                this.Button10.Enabled = false;
                this.Button11.Enabled = false;
                this.Button12.Enabled = false;
                this.Button22.Enabled = false;
            }
            else
            {
                watermark.Enabled = true;
                watermarkName.Enabled = true;
                watermarkText.Enabled = true;
                watermarkImages.Enabled = true;
                watermarkImagesName.Enabled = true;
                watermarkImages_path.Enabled = true;
                this.FileUpload1.Enabled = true;
                Button2.Enabled = true;
                imagesFilters.Enabled = true;
                this.Button7.Enabled = true;
                this.Button8.Enabled = true;
                this.Button9.Enabled = true;
                this.Button10.Enabled = true;
                this.Button11.Enabled = true;
                this.Button12.Enabled = true;
                this.Button22.Enabled = true;
            }
        }
        /// <summary>
        /// 是否启用上传图片的文字水印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button7_Click(object sender, EventArgs e)
        {
            xml_update(Button7, "watermark", watermark.SelectedValue);
            if (watermark.SelectedItem.Text == "否")
            {
                watermarkName.Enabled = false;
                watermarkText.Enabled = false;
            }
            else
            {
                watermarkName.Enabled = true;
                watermarkText.Enabled = true;
            }
        }
        /// <summary>
        /// 开启文字水印后是否保留原件并新建副本,false为不新建,false以外的字符则新建副本,副本名称以该字符加原文件名命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button8_Click(object sender, EventArgs e)
        {
            xml_update(Button8, "watermarkName", watermarkName.SelectedValue);
        }
        /// <summary>
        /// 设置水印文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button9_Click(object sender, EventArgs e)
        {
            xml_update(Button9, "watermarkText", watermarkText.Text.Trim());
        }
        /// <summary>
        /// 是否启用上传图片的图片水印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button10_Click(object sender, EventArgs e)
        {

            xml_update(Button10, "watermarkImages", watermarkImages.SelectedValue);
            if (watermarkImages.SelectedItem.Text == "否")
            {
                watermarkImagesName.Enabled = false;
                watermarkImages_path.Enabled = false;
                this.Button2.Enabled = false;
                this.FileUpload1.Enabled = false;
            }
            else
            {
                watermarkImagesName.Enabled = true;
                watermarkImages_path.Enabled = true;
                this.FileUpload1.Enabled = true;
                this.Button2.Enabled = true;
            }
        }
        /// <summary>
        /// 开启图片水印后是否保留原件并新建副本,false为不新建,false以外的字符则新建副本,副本名称以该字符加原文件名命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button11_Click(object sender, EventArgs e)
        {
            xml_update(Button11, "watermarkImagesName", watermarkImagesName.SelectedValue);
        }
        /// <summary>
        /// 设置图片水印所在的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button12_Click(object sender, EventArgs e)
        {
            xml_update(Button12, "watermarkImages_path", watermarkImages_path.Text.Trim());
        }
        /// <summary>
        /// 是否启用缩略图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button13_Click(object sender, EventArgs e)
        {
            xml_update(Button13, "smallImages", smallImages.SelectedValue);
            if (smallImages.SelectedItem.Text == "否")
            {
                smallImagesName.Enabled = false;
                smallImagesType.Enabled = false;
                smallImagesW.Enabled = false;
                smallImagesH.Enabled = false;
            }
            else
            {
                smallImagesName.Enabled = true;
                smallImagesType.Enabled = true;
                smallImagesW.Enabled = true;
                smallImagesH.Enabled = true;
            }
        }
        /// <summary>
        /// 开启缩略图后是否保留原件并新建副本,false为不新建,false以外的字符则新建副本,副本名称以该字符加原文件名命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button14_Click(object sender, EventArgs e)
        {
            xml_update(Button14, "smallImagesName", smallImagesName.SelectedValue);
        }
        /// <summary>
        /// 缩略图缩放类型,HW:指定高宽缩放(可能变形)。W:指定宽，高按比例。H:指定高，宽按比例。Cut:指定高宽裁减(不变形)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button15_Click(object sender, EventArgs e)
        {
            xml_update(Button15, "smallImagesType", smallImagesType.SelectedItem.Text);

        }
        /// <summary>
        /// 缩略图宽度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button16_Click(object sender, EventArgs e)
        {
            xml_update(Button16, "smallImagesW", smallImagesW.Text.Trim());
        }
        /// <summary>
        /// 缩略图高度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button17_Click(object sender, EventArgs e)
        {
            xml_update(Button17, "smallImagesH", smallImagesH.Text.Trim());
        }
        /// <summary>
        /// 是否允许删除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button18_Click(object sender, EventArgs e)
        {
            xml_update(Button18, "delete", delete.SelectedValue);
        }
        /// <summary>
        /// 是否允许文件重命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button19_Click(object sender, EventArgs e)
        {
            xml_update(Button19, "edit", edit.SelectedValue);
        }
        /// <summary>
        /// 是否显示文件列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button20_Click(object sender, EventArgs e)
        {
            xml_update(Button20, "fileListBox", fileListBox.SelectedValue);
        }
        /// <summary>
        /// 传文件功能可上传的文件类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button21_Click(object sender, EventArgs e)
        {
            xml_update(Button21, "fileFilters", fileFilters.Text.Trim());
        }
        /// <summary>
        /// 上传图片功能可上传的文件类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button22_Click(object sender, EventArgs e)
        {
            xml_update(Button22, "imagesFilters", imagesFilters.Text.Trim());
        }
        /// <summary>
        /// 上传自动播放文件功能可上传的文件类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button23_Click(object sender, EventArgs e)
        {
            xml_update(Button23, "mediaFilters", mediaFilters.Text.Trim());
        }

        /// <summary>
        /// 上传自动播放文件功能可上传的文件类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button24_Click(object sender, EventArgs e)
        {
            xml_update(Button24, "templateFilters", templateFilters.Text.Trim());
        }
        </script>
</head>
<body leftmargin=5 topmargin=5>
    <form id="form1" runat="server">
        <table border="1" cellpadding="0" cellspacing="0" width="95%">
    <tr>
        <td style="height: 20px;" colspan="2">
            设置上传文件夹最大的可用空间(单位KB)</td>
    </tr>
    <tr >
        <td style=" height: 20px; width: 90%;">
            <asp:TextBox ID="maxAllUploadSize" runat="server" Width="329px"></asp:TextBox>
      <asp:RangeValidator ID="RangeValidator1" runat="server" BackColor="White" BorderColor="Red"
                BorderWidth="1px" ControlToValidate="maxAllUploadSize" MaximumValue="99999999999999" ErrorMessage="必须是整数,而且最小0"
                MinimumValue="0" Type="Double"></asp:RangeValidator></td>
<td style="height: 20px; text-align: right;">
            <asp:Button ID="Button3" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0"  Height="24px" OnClick="Button3_Click"  /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            设置上传文件单个的最大尺寸(单位KB)</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:TextBox ID="maxSingleUploadSize" runat="server" Width="328px"></asp:TextBox>
      <asp:RangeValidator ID="RangeValidator2" runat="server" BackColor="White" BorderColor="Red"
                BorderWidth="1px" ControlToValidate="maxSingleUploadSize" MaximumValue="99999999999999" ErrorMessage="必须是整数,而且最小0"
                MinimumValue="0" Type="Double"></asp:RangeValidator></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button1" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button1_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            设置上传文件是否自动改名</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="autoname" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="false">否</asp:ListItem>
                <asp:ListItem Value="true">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button4" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button4_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            设置是否允许上传</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="allowUpload" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="false">否</asp:ListItem>
                <asp:ListItem Value="true">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button5" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button5_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            是否在上传界面启用水印选择</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="watermarkOption" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="off">否</asp:ListItem>
                <asp:ListItem Value="on">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button6" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button6_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            是否启用上传图片的文字水印</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="watermark" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="false">否</asp:ListItem>
                <asp:ListItem Value="true">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button7" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button7_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            开启文字水印后是否保留原件并新建副本</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="watermarkName" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="false">否</asp:ListItem>
                <asp:ListItem Value="true">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button8" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button8_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            设置水印文字</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:TextBox ID="watermarkText" runat="server" Width="325px"></asp:TextBox>&nbsp;
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="White"
                BorderColor="Red" BorderWidth="1px" ControlToValidate="watermarkText" ErrorMessage="不能为空"
                Width="107px"></asp:RequiredFieldValidator></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button9" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button9_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            是否启用上传图片的图片水印</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="watermarkImages" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="false">否</asp:ListItem>
                <asp:ListItem Value="true">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button10" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button10_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            开启图片水印后是否保留原件并新建副本</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="watermarkImagesName" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="false">否</asp:ListItem>
                <asp:ListItem Value="true">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button11" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button11_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            设置图片水印所在的位置(自动存为logo.gif)</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:TextBox ID="watermarkImages_path" runat="server" Width="326px"></asp:TextBox><br />
            <asp:FileUpload ID="FileUpload1" runat="server" Width="326px" />
      <asp:Button ID="Button2" runat="server" Height="19px" OnClick="Button2_Click" Text="上传"
                Width="71px" /></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button12" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button12_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            是否启用缩略图</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="smallImages" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="false">否</asp:ListItem>
                <asp:ListItem Value="true">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button13" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button13_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            开启缩略图后是否保留原件并新建副本</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="smallImagesName" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="false">否</asp:ListItem>
                <asp:ListItem Value="true">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button14" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button14_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            缩略图缩放类型,HW:指定高宽缩放(可能变形)。W:指定宽，高按比例。H:指定高，宽按比例。Cut:指定高宽裁减(不变形)</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="smallImagesType" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="324px">
                <asp:ListItem>HW</asp:ListItem>
                <asp:ListItem>W</asp:ListItem>
                <asp:ListItem>H</asp:ListItem>
                <asp:ListItem>CUT</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button15" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button15_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            缩略图宽度</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:TextBox ID="smallImagesW" runat="server" Width="323px"></asp:TextBox>
      <asp:RangeValidator ID="RangeValidator3" runat="server" BackColor="White" BorderColor="Red"
                BorderWidth="1px" ControlToValidate="smallImagesW" ErrorMessage="必须是整数,不能为负数"
                MinimumValue="0" MaximumValue="9999" Type="Double"></asp:RangeValidator></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button16" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button16_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            缩略图高度</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:TextBox ID="smallImagesH" runat="server" Width="322px"></asp:TextBox>
      <asp:RangeValidator ID="RangeValidator4" runat="server" BackColor="White" BorderColor="Red"
                BorderWidth="1px" ControlToValidate="smallImagesH" ErrorMessage="必须是整数,不能为负数"
                MinimumValue="0" MaximumValue="9999" Type="Double"></asp:RangeValidator></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button17" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button17_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            是否允许删除文件</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="delete" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="false">否</asp:ListItem>
                <asp:ListItem Value="true">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button18" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button18_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            是否允许文件重命名</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="edit" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="false">否</asp:ListItem>
                <asp:ListItem Value="true">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button19" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button19_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            是否显示文件列表</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:RadioButtonList ID="fileListBox" runat="server" BackColor="White" RepeatDirection="Horizontal"
                Width="328px">
                <asp:ListItem Value="false">否</asp:ListItem>
                <asp:ListItem Value="true">是</asp:ListItem>
      </asp:RadioButtonList></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button20" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button20_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            上传文件功能可上传的文件类型</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:TextBox ID="fileFilters" runat="server" Width="328px"></asp:TextBox></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button21" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button21_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            上传图片功能可上传的文件类型</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:TextBox ID="imagesFilters" runat="server" Width="328px"></asp:TextBox></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button22" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button22_Click" /></td>
    </tr>
    <tr >
        <td style="height: 25px" colspan="2">
            
            上传自动播放文件功能可上传的文件类型</td>
    </tr>
    <tr >
        <td style=" height: 25px; width: 90%;">
            <asp:TextBox ID="mediaFilters" runat="server" Width="328px"></asp:TextBox></td>
      <td style="height: 25px; text-align: right;"><asp:Button ID="Button23" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button23_Click" /></td>
    </tr>
            <tr >
                <td colspan="2" style="height: 25px; text-align: left">
                    上传模板功能可上传的文件类型</td>
            </tr>
            <tr >
                <td style=" height: 25px; width: 90%;">
                    <asp:TextBox ID="templateFilters" runat="server" Width="328px"></asp:TextBox></td>
                <td style="height: 25px; text-align: right">
                    <asp:Button ID="Button24" runat="server" Text="更新" Width="112px" BorderColor="#E0E0E0" Height="24px" OnClick="Button24_Click" /></td>
            </tr>
</table>

</form>
</body>
<script language=javascript>
var userAgent = navigator.userAgent.toLowerCase();
var is_ie = (userAgent.indexOf('msie') != -1);
if(is_ie)
{
document.body.bgColor="ButtonFace";
}
else
{
document.body.bgColor="#E0E0E0";
document.body.onunload=window.opener.location.reload();
}
</script>
</html>

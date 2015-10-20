using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace base64
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Base64StringToImage(string base53Str)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(base53Str);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                //bmp.Save(txtFileName + ".bmp", ImageFormat.Bmp);  
                //bmp.Save(txtFileName + ".gif", ImageFormat.Gif);  
                //bmp.Save(txtFileName + ".png", ImageFormat.Png);  
                ms.Close();
                //sr.Close();
                //ifs.Close();
                this.pictureBox1.Image = bmp;
                MessageBox.Show("转换成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Base64StringToImage 转换失败/nException：" + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

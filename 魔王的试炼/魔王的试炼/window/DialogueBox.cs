using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 对话框
    /// </summary>
    class DialogueBox : GameWindow
    {
        public DialogueBox()
            : base(GameIni.DialogueSize.Width, GameIni.DialogueSize.Height)
        {
            ExistStation = new Point(160, 330);
        }
        /// <summary>
        /// 对话队列
        /// </summary>
        private Queue<Dialogue> DialogueQueue = new Queue<Dialogue>(0);

        /// <summary>
        /// 每次刷新时不需要重新绘制
        /// </summary>
        public override void NextFrame() { }

        public override bool Enable
        {
            get
            {
                return base.Enable;
            }
            set
            {
                base.Enable = value;
                if (!value)
                {
                    DialogueQueue.Clear();
                }
            }
        }

        /// <summary>
        /// 打开下一个对话
        /// </summary>
        private void NextDialogue()
        {
            if (Enable)
            {
                if (DialogueQueue.Count == 0)
                {
                    this.Enable = false;
                    return;
                }

                SoundsList.PlaySound(SoundType.对话);
                ReDraw();
            }
        }

        /// <summary>
        /// 处理按键
        /// </summary>
        /// <param name="code">按键</param>
        /// <returns>返回一个布尔值，标示按键是否被处理</returns>
        public override bool HandleKeyDown(System.Windows.Forms.Keys code)
        {
            if (code == System.Windows.Forms.Keys.Enter || code == System.Windows.Forms.Keys.PageDown)
            {
                this.NextDialogue();
            }

            //捕获按键
            return true;
        }

        /// <summary>
        /// 从对话队列中取出一次对话，绘制此对话到画布
        /// 如果对话队列为空，则关闭对话框
        /// </summary>
        protected override void ReDraw()
        {
            //取出一次对话
            Dialogue oneDialogue = DialogueQueue.Dequeue();

            Bitmap canvas = new Bitmap(WindowFace);
            Graphics g = Graphics.FromImage(canvas);
            
            Font strFont = new Font(new FontFamily("微软雅黑"), 12, FontStyle.Regular);
            SolidBrush strBrush = new SolidBrush(Color.Black);

            //绘制人物栏
            g.DrawImage(MotaImage.BackWindow, new Rectangle(0, 0, 80, 30), new Rectangle(0, 0, MotaImage.BackWindow.Width, MotaImage.BackWindow.Height), GraphicsUnit.Pixel);
            //g.FillRectangle(new SolidBrush(Color.Aquamarine), new Rectangle(0, 0, 80, 30));
            g.DrawString(oneDialogue.Speaker, strFont, strBrush, new PointF(10, 5));

            //绘制会话栏
            g.DrawImage(MotaImage.BackWindow, new Rectangle(0, 35, GameIni.DialogueSize.Width - 5, GameIni.DialogueSize.Height - 40), new Rectangle(0, 0, MotaImage.BackWindow.Width, MotaImage.BackWindow.Height), GraphicsUnit.Pixel);
            //g.FillRectangle(new SolidBrush(Color.Aquamarine), new Rectangle(0, 35, GameIni.DialogueSize.Width - 5, GameIni.DialogueSize.Height - 40));
            g.DrawString(oneDialogue.Content, strFont, strBrush, new Rectangle(10, 45, 320, 100));

            canvas.SetOpacity(0.8F);
            WindowFace = canvas;
        }

        /// <summary>
        /// 打开对话框
        /// </summary>
        /// <param name="data">对话数据</param>
        public override void Open(object data)
        {
            Dialogue[] dialogues = data as Dialogue[];
            if (dialogues != null)
            {
                this.Enable = true;

                //在对话队列的尾端追加对话
                for (int i = 0; i < dialogues.Length; i++)
                {
                    DialogueQueue.Enqueue(dialogues[i]);
                }

            }

            NextDialogue();
        }
    }
}






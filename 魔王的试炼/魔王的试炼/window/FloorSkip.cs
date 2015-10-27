using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 楼层跳转界面
    /// </summary>
    class FloorSkip : Selector
    {
        public FloorSkip() : base(GameIni.SkipWindow.Width, GameIni.SkipWindow.Height)
        {
            ExistStation = new System.Drawing.Point(200, 100);
        }

        /// <summary>
        /// 楼层选项
        /// </summary>
        class FloorOption : Option
        {
            /// <summary>
            /// 创建楼层选项实例
            /// </summary>
            /// <param name="name">选项名称</param>
            /// <param name="valid">选项是否可以被选中</param>
            /// <param name="floor">选项代表的楼层</param>
            public FloorOption(string name, bool valid, int floor)
                : base(name, valid)
            {
                this.Floor = floor;
            }

            /// <summary>
            /// 获取或设置选项代表的楼层
            /// </summary>
            public int Floor { get; set; }

            /// <summary>
            /// 触发选项
            /// </summary>
            public override void onTrigger()
            {
                //跳转楼层
                MotaWorld.GetInstance().MapManager.CurFloorIndex = Floor;

                base.onTrigger();
            }

            public override void Draw(Graphics g, Point startPoint)
            {
                if (Selected)
                {
                    g.DrawRectangle(new Pen(Color.HotPink, 3), new Rectangle(startPoint.X - 10, startPoint.Y, 95, 30));
                }

                if (CanSelect)
                {
                    g.DrawString(Name, new Font(new FontFamily("微软雅黑"), 16, FontStyle.Regular), new SolidBrush(Color.Black), startPoint);
                }
                else
                {
                    g.DrawString(Name, new Font(new FontFamily("微软雅黑"), 16, FontStyle.Regular), new SolidBrush(Color.Gray), startPoint);
                }
            }
        }

        /// <summary>
        /// 绘制跳转界面到画布
        /// </summary>
        protected override void ReDraw()
        {
            Bitmap canvas = new Bitmap(WindowFace);
            Graphics.FromImage(canvas).DrawImage(MotaImage.BackWindow, new Rectangle(0, 0, this.WindowFace.Width, this.WindowFace.Height), new Rectangle(0, 0, MotaImage.BackWindow.Width, MotaImage.BackWindow.Height), GraphicsUnit.Pixel);
            
            //绘制文字
            Font descFont = new Font(new FontFamily("微软雅黑"), 13, FontStyle.Regular);
            SolidBrush descBrush = new SolidBrush(Color.Black);
            Graphics.FromImage(canvas).DrawString("请选择您要跳转的楼层", descFont, descBrush, new PointF(40, 10));

            //绘制楼层信息
            int index = 0;
            for (int i = 0; i < GameIni.SkipWindowCol; i++)
            {
                for (int j = 0; j < GameIni.SkipWindowRow; j++)
                {
                    if (Options.Count <= index)
                    {
                        break;
                    }

                    Options[index++].Draw(Graphics.FromImage(canvas), new Point(i * (GameIni.FloorUnit.Width + 20) + 25, 50 + j * (20 + GameIni.FloorUnit.Height)));  
                }
                if (Options.Count <= index)
                {
                    break;
                }
            }

            canvas.SetOpacity(0.8F);
            WindowFace = canvas;
        }

        /// <summary>
        /// 如果拥有楼层传送器,开启选项窗口并默认选中一项
        /// </summary>
        /// <param name="data">选项索引</param>
        public override void Open(object data)
        {
            //如果有其他窗口，禁止开启
            if (MotaWorld.GetInstance().ExistSolo)
            {
                return;
            }

            int index = MotaWorld.GetInstance().MapManager.CurFloorIndex;
            if (data != null)
            {
                //拆箱转换
                index = (int)data;
            }
            
            if (MotaWorld.GetInstance().MapManager.CurHero.Pack.ExistProperty(PropName.楼层传送器))
            {
                //添加选项
                this.RemoveAllOptions();
                int sumFloor = MotaWorld.GetInstance().MapManager.Tower.MaxFloor;
                for (int i = 0; i < sumFloor; i++)
                {
                    //如果楼层抵达过，则为有效选项，否则为无效选项
                    FloorOption o = new FloorOption(MotaWorld.GetInstance().MapManager.Tower[i].FloorName, MotaWorld.GetInstance().MapManager.FloorReached[i], i);
                    AddOption(o);
                }
            
                //默认选中当前楼层
                base.Open(index);
            }
        }

        /// <summary>
        /// 处理按键
        /// </summary>
        /// <param name="code">按键</param>
        /// <returns>返回一个布尔值，标示按键是否被处理</returns>
        public override bool HandleKeyDown(System.Windows.Forms.Keys code)
        {
            if (code == System.Windows.Forms.Keys.J)
            {
                if (MotaWorld.GetInstance().FloorSkipWindow.Enable == true)
                {
                    MotaWorld.GetInstance().FloorSkipWindow.Enable = false;
                }
                else
                {
                    MotaWorld.GetInstance().FloorSkipWindow.Open(null);
                }
                return true;
            }

            if (Enable)
            {
                //如果窗口有效，则捕获按键
                if (code == System.Windows.Forms.Keys.Up)
                {
                    PreItem();
                }
                else if (code == System.Windows.Forms.Keys.Down)
                {
                    NextItem();
                }
                else if (code == System.Windows.Forms.Keys.Left)
                {
                    //向左选
                    this.SelectedIndex -= GameIni.SkipWindowRow;
                }
                else if (code == System.Windows.Forms.Keys.Right)
                {
                    //向右选
                    this.SelectedIndex += GameIni.SkipWindowRow;
                }
                else if (code == System.Windows.Forms.Keys.Enter)
                {
                    this.Enter();
                    Enable = false;
                }
                return true;
            }

            return false;
        }

    }
}







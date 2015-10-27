using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 商店窗口,用于打开商店窗口进行金币或经验的交易
    /// 有商店开启事件打开此窗口，由退出选项关闭
    /// </summary>
    class Shop : Selector
    {
        /// <summary>
        /// 创建商店实例，提供交易者的引用
        /// </summary>
        /// <param name="dealer"></param>
        public Shop() : base(GameIni.ShopSize.Width, GameIni.ShopSize.Height)
        {
            ExistStation = new Point(180, 120);
        }

        /// <summary>
        /// 交易者
        /// </summary>
        private Idealer Dealer = null;

        /// <summary>
        /// 商店说明
        /// </summary>
        public string ShopMessage;

        /// <summary>
        /// 以交易者的身份开启商店，默认选中第一个选项
        /// </summary>
        /// <param name="data">交易者</param>
        public override void Open(object data)
        {
            if (data is Idealer)
            {
                Dealer = data as Idealer;
                base.Open(null);
                SoundsList.PlaySound(SoundType.进入商店);
            }
            else
            {
                throw new Exception("错误的交易者身份,不能开启商店");
            }
        }

        /// <summary>
        /// 空触发效果音
        /// </summary>
        protected override void EnterSound() { }

        /// <summary>
        /// 添加交易选项
        /// </summary>
        /// <param name="option">交易选项</param>
        public override void AddOption(Option option)
        {
            option.TriggerEvent += new EventHandler(Deal);
            base.AddOption(option);
        }

        /// <summary>
        /// 进行一次交易, 如果无法交易，则发出失败效果音，如果交易成功，发出成功效果音
        /// </summary>
        private void Deal(object sender, EventArgs e)
        {
            DealOption o = sender as DealOption;
            if (o == null || Dealer == null)
            {
                throw new Exception("错误的交易信息或交易对象为空");
            }

            //如果交易参数为空，则关闭商店
            if (o.OnePiece == null)
            {
                this.Enable = false;
                SoundsList.PlaySound(SoundType.关闭商店);
                return;
            }

            if (Dealer.Coin >= o.OnePiece.CoinDemand && Dealer.Exp >= o.OnePiece.ExpDemand)
            {
                //成功交易
                Dealer.Coin -= o.OnePiece.CoinDemand;
                Dealer.Exp -= o.OnePiece.ExpDemand;
                Dealer.Hp += o.OnePiece.HpUp;
                Dealer.Attack += o.OnePiece.Attack;
                Dealer.Defence += o.OnePiece.Defence;
                Dealer.Level += o.OnePiece.Level;
                Dealer.Magic += o.OnePiece.Magic;
                Dealer.Agility += o.OnePiece.Agility;

                SoundsList.PlaySound(SoundType.确认选择);
            }
            else
            {
                //失败交易
                SoundsList.PlaySound(SoundType.错误);
            }

        }

        /// <summary>
        /// 绘制商店和交易选项
        /// </summary>
        protected override void ReDraw()
        {
            Bitmap canvas = new Bitmap(WindowFace);
            Graphics g = Graphics.FromImage(canvas);
            g.Clear(Color.Transparent);

            g.DrawImage(MotaImage.BackWindow, new Rectangle(0, 0, GameIni.ShopSize.Width, 90 + 40 * Options.Count), new Rectangle(0, 0, MotaImage.BackWindow.Width, MotaImage.BackWindow.Height), GraphicsUnit.Pixel);
            
            //绘制文字
            Font descFont = new Font(new FontFamily("微软雅黑"), 13, FontStyle.Regular);
            SolidBrush descBrush = new SolidBrush(Color.Black);
            g.DrawString(ShopMessage, descFont, descBrush, new Rectangle(20, 10, 220, 50));
            g.DrawLine(new Pen(Color.Blue, 2), new Point(0, 65), new Point(GameIni.ShopSize.Width, 65));

            //绘制选项信息
            for (int i = 0; i < Options.Count; i++)
            {
                Options[i].Draw(g, new Point(50, 80 + i * 35));
            }

            canvas.SetOpacity(0.8F);
            WindowFace = canvas;
        }
    }
}





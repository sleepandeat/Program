using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 图片配置数据类,将地图数据加载到内存，为地图元素提供对应图像
    /// </summary>
    static class MotaImage
    {
        /// <summary>
        /// 图像容器,第二维表示图像随时间变化的帧数
        /// </summary>
        private static Bitmap[][] ImageVector = new Bitmap[300][];

        /// <summary>
        /// 存储图片文件名，用于检测图像是否已经加载到容器中
        /// </summary>
        private static string[] FileNames = new string[300];

        /// <summary>
        /// 根据索引获取图像
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>图像组</returns>
        public static Bitmap[] GetImage(int index)
        {
            if (index >= 0 && index < ImageVector.GetLength(0))
            {
                return ImageVector[index];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据图像索引获取文件名
        /// </summary>
        /// <param name="index">图像索引</param>
        /// <returns>文件名称</returns>
        public static string GetFileName(int index)
        {
            return FileNames[index];
        }

        /// <summary>
        /// 根据他图片文件名获取图像索引, 如果不存在，创建一个
        /// </summary>
        /// <param name="fileName">图片文件名</param>
        /// <param name="unitSize">分隔的单位尺寸</param>
        /// <returns>图像在容器里的索引</returns>
        public static int GetFaceIndex(string fileName, Size unitSize)
        {
            if (fileName == null || fileName.CompareTo(string.Empty) == 0)
            {
                return 0;
            }

            for (int i = 0; i < FileNames.Length; i++)
            {
                if (FileNames[i] != null && FileNames[i].CompareTo(fileName) == 0)
                {
                    return i;
                }
            }

            //在空的位置上追加新的图像，去除第一个默认的空图像
            for (int i = 1; i < FileNames.Length; i++)
            {
                if (FileNames[i] == null)
                {
                    FileNames[i] = fileName;
                    try
                    {
                        ImageVector[i] = GetFaceList(new Bitmap(fileName), unitSize);
                    }
                    catch
                    {
                        throw new Exception("图像文件" + fileName + "不存在！");
                    }
                    return i;
                }
            }

            throw new Exception("分配图像的数量超过限制");
        }

        /// <summary>
        /// 默认的背景图像
        /// </summary>
        public static Bitmap BackImage;

        /// <summary>
        /// 被选中怪物的图像的背景
        /// </summary>
        public static Bitmap SelectedBackImage;

        /// <summary>
        /// 窗口背景
        /// </summary>
        public static Bitmap BackWindow;

        /// <summary>
        /// 初始加载固有图像,但标准单位尺寸分隔
        /// </summary>
        static MotaImage()
        {
            BackImage = new Bitmap("images/map/Empty1.png");
            SelectedBackImage = GetImage(MotaElement.选中怪物背景);
            SelectedBackImage.SetOpacity(0.4F);

            BackWindow = new Bitmap("images/back.png");

            for (int i = 0; i < ImageVector.Length; i++)
            {
                MotaElement id = (MotaElement)i;
                ImageVector[i] = GetFaceList(GetImage(id), new Size(GameIni.ElementWidth, GameIni.ElementHeight));
            }
        }
        
        /// <summary>
        /// 按一定尺寸分隔元素图像为多帧
        /// </summary>
        /// <param name="srcPicture">原图像</param>
        /// <param name="unitSize">分隔后的单位尺寸</param>
        private static Bitmap[] GetFaceList(Bitmap srcPicture, Size unitSize)
        {
            //源图像为空，返回空引用
            if (srcPicture == null)
            {
                return null;
            }

            //源图像中末尾单位尺寸的单位坐标
            Coord mapCoord;

            //如果源图像的宽是单词宽度的整数倍，就按倍数分隔，否则修改单位尺寸满足宽度要求
            if (srcPicture.Width % unitSize.Width == 0)
            {
                mapCoord.Col = srcPicture.Width / unitSize.Width;
            }
            else
            {
                unitSize.Width = srcPicture.Width;
                mapCoord.Col = 1;
            }

            //如果源图像的高是单词高度的整数倍，就按倍数分隔，否则修改单位尺寸满足高度要求
            if (srcPicture.Height % unitSize.Height == 0)
            {
                mapCoord.Row = srcPicture.Height / unitSize.Height;
            }
            else
            {
                unitSize.Height = srcPicture.Height;
                mapCoord.Row = 1;
            }

            Bitmap[] resultFaceList = new Bitmap[mapCoord.Col * mapCoord.Row];

            //先从第一行分隔，再到下一行分隔，逐行分隔
            for (int i = 0; i < mapCoord.Row * mapCoord.Col; i++)
            {
                resultFaceList[i] = new Bitmap(unitSize.Width, unitSize.Height);
                
                Graphics.FromImage(resultFaceList[i]).DrawImageUnscaled(
                    srcPicture,
                    -(i % mapCoord.Col) * unitSize.Width,
                    -(i / mapCoord.Col) * unitSize.Height);
            }
            return resultFaceList;
        }

        private static Bitmap GetImage(MotaElement id)
        {
            Bitmap img = null;
            string imgFile = string.Empty;
            switch (id)
            {
                case MotaElement.选中怪物背景:
                    imgFile = "images/map/monsterback.png";
                    break;
                case MotaElement.指引指针:
                    imgFile = "images/map/指针.png";
                    break;
                case MotaElement.向下箭头:
                    imgFile = "images/map/allowDown.png";
                    break;
                case MotaElement.向左箭头:
                    imgFile = "images/map/allowLeft.png";
                    break;
                case MotaElement.向上箭头:
                    imgFile = "images/map/allowUp.png";
                    break;
                case MotaElement.向右箭头:
                    imgFile = "images/map/allowRight.png";
                    break;
                case MotaElement.墙1:
                    imgFile = "images/map/Block1.png";
                    break;
                case MotaElement.墙2:
                    imgFile = "images/map/Block2.png";
                    break;
                case MotaElement.墙3:
                    imgFile = "images/map/Block3.png";
                    break;
                case MotaElement.墙4:
                    imgFile = "images/map/Block4.png";
                    break;
                case MotaElement.墙5:
                    imgFile = "images/map/Block5.png";
                    break;
                case MotaElement.墙6:
                    imgFile = "images/map/Block6.png";
                    break;
                case MotaElement.墙7:
                    imgFile = "images/map/Block7.png";
                    break;
                case MotaElement.熔岩:
                    imgFile = "images/map/Block8.png";
                    break;
                case MotaElement.星星:
                    imgFile = "images/map/Block9.png";
                    break;
                case MotaElement.上楼:
                    imgFile = "images/map/梯上.png";
                    break;
                case MotaElement.下楼:
                    imgFile = "images/map/梯下.png";
                    break;
                case MotaElement.圣水瓶:
                    imgFile = "images/prop/圣水瓶.png";
                    break;
                case MotaElement.红血瓶:
                    imgFile = "images/prop/药剂小.png";
                    break;
                case MotaElement.蓝血瓶:
                    imgFile = "images/prop/药剂大.png";
                    break;
                case MotaElement.蓝宝石:
                    imgFile = "images/prop/蓝宝石.png";
                    break;
                case MotaElement.红宝石:
                    imgFile = "images/prop/红宝石.png";
                    break;
                case MotaElement.大金币:
                    imgFile = "images/prop/金块.png";
                    break;
                case MotaElement.小飞羽:
                    imgFile = "images/prop/飞羽.png";
                    break;
                case MotaElement.钥匙盒:
                    imgFile = "images/prop/钥匙盒.png";
                    break;
                case MotaElement.黄钥匙:
                    imgFile = "images/prop/黄钥匙.png";
                    break;
                case MotaElement.红钥匙:
                    imgFile = "images/prop/红钥匙.png";
                    break;
                case MotaElement.蓝钥匙:
                    imgFile = "images/prop/蓝钥匙.png";
                    break;
                case MotaElement.小黄钥匙:
                    imgFile = "images/prop/101-01.png";
                    break;
                case MotaElement.小蓝钥匙:
                    imgFile = "images/prop/101-02.png";
                    break;
                case MotaElement.小红钥匙:
                    imgFile = "images/prop/101-03.png";
                    break;
                case MotaElement.黄门:
                    imgFile = "images/map/500.png";
                    break;
                case MotaElement.蓝门:
                    imgFile = "images/map/501.png";
                    break;
                case MotaElement.红门:
                    imgFile = "images/map/502.png";
                    break;
                case MotaElement.花门:
                    imgFile = "images/map/503.png";
                    break;
                case MotaElement.铁门:
                    imgFile = "images/map/504.png";
                    break;
                case MotaElement.暗墙1:
                    imgFile = "images/map/506.png";
                    break;
                case MotaElement.暗墙2:
                    imgFile = "images/map/505.png";
                    break;
                case MotaElement.暗墙3:
                    imgFile = "images/map/507.png";
                    break;
                case MotaElement.怪物手册:
                    imgFile = "images/prop/101-13.png";
                    break;
                case MotaElement.楼层传送器:
                    imgFile = "images/prop/106-01Shoe.png";
                    break;
                case MotaElement.黄金盾:
                    imgFile = "images/prop/黄金盾.png";
                    break;
                case MotaElement.青峰剑:
                    imgFile = "images/prop/青锋剑.png";
                    break;
                case MotaElement.神圣盾:
                    imgFile = "images/prop/光芒神盾.png";
                    break;
                case MotaElement.神圣剑:
                    imgFile = "images/prop/星光神剑.png";
                    break;
                case MotaElement.铁盾:
                    imgFile = "images/prop/铁盾.png";
                    break;
                case MotaElement.铁剑:
                    imgFile = "images/prop/铁剑.png";
                    break;
                case MotaElement.破墙镐:
                    imgFile = "images/prop/十字镐.png";
                    break;
                case MotaElement.十字架:
                    imgFile = "images/prop/十字架.png";
                    break;
                case MotaElement.公主:
                    imgFile = "images/npc/公主.png";
                    break;
                case MotaElement.老人:
                    imgFile = "images/npc/NPC蓝.png";
                    break;
                case MotaElement.商店:
                    imgFile = "images/npc/商店中.png";
                    break;
                case MotaElement.商店右:
                    imgFile = "images/npc/商店右.png";
                    break;
                case MotaElement.商店左:
                    imgFile = "images/npc/商店左.png";
                    break;
                case MotaElement.商人:
                    imgFile = "images/npc/NPC红.png";
                    break;
                case MotaElement.仙子:
                    imgFile = "images/npc/仙女.png";
                    break;
                case MotaElement.目标:
                    imgFile = "images/map/target.png";
                    break;
                //case MotaElement.初级警卫:
                //    imgFile = "images/monster/0036-Monster06.png";
                //    break;
                //case MotaElement.青色史莱姆:
                //    imgFile = "images/monster/0031-Monster01.png";
                //    break;
                //case MotaElement.红色史莱姆:
                //    imgFile = "images/monster/1031-Monster01.png";
                //    break;
                //case MotaElement.黑色史莱姆:
                //    imgFile = "images/monster/2031-Monster01.png";
                //    break;
                //case MotaElement.大史莱姆:
                //    imgFile = "images/monster/3031-Monster01.png";
                //    break;
                //case MotaElement.小蝙蝠:
                //    imgFile = "images/monster/0032-Monster02.png";
                //    break;
                //case MotaElement.大蝙蝠:
                //    imgFile = "images/monster/1032-Monster02.png";
                //    break;
                //case MotaElement.红蝙蝠:
                //    imgFile = "images/monster/2032-Monster02.png";
                //    break;
                case MotaElement.箱子:
                    imgFile = "images/map/SandBox1.png";
                    break;
                case MotaElement.路障:
                    imgFile = "images/map/路障.png";
                    break;
                case MotaElement.道具包:
                    imgFile = "images/prop/102-14.png";
                    break;
                case MotaElement.上楼器:
                    imgFile = "images/prop/102-07.png";
                    break;
                case MotaElement.自然之靴:
                    imgFile = "images/prop/102-13Shoe.png";
                    break;
                case MotaElement.怪物探测器:
                    imgFile = "images/prop/怪物探测器.png";
                    break;



                default:
                    break;
            }
            if (imgFile != string.Empty)
            {
                FileNames[(int)id] = imgFile;
                img = new Bitmap(imgFile);
            }

            return img;
        }
    }
}




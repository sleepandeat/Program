using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 方向
    /// </summary>
    public enum Direction
    {
        Up = 3,
        Down = 0,
        Left = 1,
        Right = 2,
        No = 4,
    }

    /// <summary>
    /// 有通行性取向的游戏元素
    /// </summary>
    abstract class PassElement : DynamicElement
    {
        /// <summary>
        /// 创建通向性元素实例
        /// </summary>
        /// <param name="repeated">元素图像是否重复播放</param>
        /// <param name="interval">每帧的部分间隔</param>
        /// <param name="faceIndex">图像索引</param>
        public PassElement(bool repeated, int interval, MotaElement faceIndex)
            :base(repeated, interval, faceIndex)
        {}

        /// <summary>
        /// 创建通向性元素实例
        /// </summary>
        /// <param name="repeated">元素图像是否重复播放</param>
        /// <param name="interval">每帧的部分间隔</param>
        /// <param name="fileName">图像文件地址</param>
        /// <param name="unitSize">图像分隔的单位尺寸</param>
        public PassElement(bool repeated, int interval, string fileName, Size unitSize)
            :base(repeated, interval, fileName, unitSize)
        { }

        /// <summary>
        /// 内部的开关存储结构，初始是不可通行的
        /// </summary>
        private bool[] PassSwitch = new bool[4]{false, false, false, false};

        /// <summary>
        /// 获取或设置元素的向上通向性
        /// </summary>
        public bool PassUp
        {
            get {
                return PassSwitch[0];
            }
            set
            {
                PassSwitch[0] = value;
            }
        }

        /// <summary>
        /// 获取或设置元素的向下通向性
        /// </summary>
        public bool PassDown
        {
            get
            {
                return PassSwitch[1];
            }
            set
            {
                PassSwitch[1] = value;
            }
        }

        /// <summary>
        /// 获取或设置元素的向左通向性
        /// </summary>
        public bool PassLeft
        {
            get
            {
                return PassSwitch[2];
            }
            set
            {
                PassSwitch[2] = value;
            }
        }

        /// <summary>
        /// 获取或设置元素的向右通向性
        /// </summary>
        public bool PassRight
        {
            get
            {
                return PassSwitch[3];
            }
            set
            {
                PassSwitch[3] = value;
            }
        }

        /// <summary>
        /// 获取或设置元素的全通向性
        /// </summary>
        public bool CanPass
        {
            get
            {
                for (int i = 0; i < PassSwitch.Length; i++)
                {
                    if (!PassSwitch[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            set
            {
                for (int i = 0; i < PassSwitch.Length; i++)
                {
                    PassSwitch[i] = value;
                }
            }
        }

        /// <summary>
        /// 获取是否是障碍(四个方向都不可通行)
        /// </summary>
        public bool Obstacle 
        {
            get {
                //只要有一方可以通行，则为假
                for (int i = 0; i < PassSwitch.Length; i++)
                {
                    if (PassSwitch[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// 判断从某一方向是否可以通过元素
        /// </summary>
        /// <param name="way">方向</param>
        public bool Passable(Direction way)
        {
            switch (way)
            {
                case Direction.Up:
                    return PassUp;
                case Direction.Down:
                    return PassDown;
                case Direction.Left:
                    return PassLeft;
                case Direction.Right:
                    return PassRight;
                case Direction.No:
                    break;
                default:
                    break;
            }

            return false;
        }
    }
}








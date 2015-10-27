using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 全局配置数据，游戏系统参数,只读属性
    /// </summary>
    static class GameIni
    {
        #region 地图参数
        /// <summary>
        /// 获取游戏地图的宽度
        /// </summary>
        public static int MapWidth
        {
            get 
            { 
                return GameIni.MapGridX * GameIni.ElementWidth;
            }
        }

        /// <summary>
        /// 获取游戏地图的高度
        /// </summary>
        public static int MapHeight
        {
            get 
            {
                return GameIni.MapGridY * GameIni.ElementHeight; 
            }
        }

        /// <summary>
        /// 获取游戏界面窗口的宽度
        /// </summary>
        public static int WindowWidth
        {
            get {
                return GameIni.WindowGridX * GameIni.ElementWidth; 
            }
        }

        /// <summary>
        /// 获取游戏界面窗口的高度
        /// </summary>
        public static int WindowHeight
        {
            get { 
                return GameIni.WindowGridY * GameIni.ElementHeight; 
            }
        }

        /// <summary>
        /// 获取单位元素的宽度
        /// </summary>
        public static int ElementWidth { get { return 40;} }

        /// <summary>
        /// 获取单位元素的高度
        /// </summary>
        public static int ElementHeight { get { return 40; } }

        /// <summary>
        /// 获取标准单位尺寸
        /// </summary>
        public static Size UnitSize { get { return new Size(GameIni.ElementWidth, GameIni.ElementHeight); } }

        /// <summary>
        /// 获取游戏窗口的X轴格子数
        /// </summary>
        public static int WindowGridX { get { return 17; } }

        /// <summary>
        /// 获取游戏窗口的Y轴格子数
        /// </summary>
        public static int WindowGridY { get { return 13; } }

        /// <summary>
        /// 获取游戏地图的X轴格子数
        /// </summary>
        public static int MapGridX 
        {
            get {
                return MotaWorld.GetInstance().MapManager.CurFloorNode.FloorSize.Col;
            } 
        }

        /// <summary>
        /// 获取游戏地图的Y轴格子数
        /// </summary>
        public static int MapGridY 
        {
            get { 
                return MotaWorld.GetInstance().MapManager.CurFloorNode.FloorSize.Row;
            } 
        }

        
        #endregion

        #region 刷新参数
        /// <summary>
        /// 刷新间隔 ms
        /// </summary>
        public static int RefreshInterval { get { return 20; } }

        /// <summary>
        /// 默认元素的每一帧的播放间隔
        /// </summary>
        public static int DefaultInterval { get { return 250; } }

        #endregion

        #region 人物参数
        /// <summary>
        /// 获取人物初始的生命
        /// </summary>
        public static int IniHeroHp { get { return 1000; } }

        /// <summary>
        /// 获取人物的移动速度,标示元素每时钟间隔移动的单位数.
        /// </summary>
        public static int IniHeroSpeed { get { return 6; } }

        /// <summary>
        /// 获得勇士的初始攻击
        /// </summary>
        public static int IniHeroAttack { get { return 10; } }

        /// <summary>
        /// 获得勇士的初始防御
        /// </summary>
        public static int IniHeroDefence { get { return 10; } }

        /// <summary>
        /// 获得勇士的初始敏捷
        /// </summary>
        public static int IniHeroAgility { get { return 0; } }

        /// <summary>
        /// 获得勇士的初始魔法
        /// </summary>
        public static int IniHeroMagic { get { return 0; } }

        /// <summary>
        /// 获得勇士的初始金币
        /// </summary>
        public static int IniHeroCoins { get { return 0; } }

        /// <summary>
        /// 获得勇士的初始经验
        /// </summary>
        public static int IniHeroExp { get { return 0; } }

        /// <summary>
        /// 获得勇士的默认名称
        /// </summary>
        public static string IniHeroName { get { return "勇士"; } }

        /// <summary>
        /// 获得勇士的初始等级
        /// </summary>
        public static int IniHeroLevel { get { return 1; } }

        /// <summary>
        /// 获取人物在战斗中允许被撤退的次数
        /// </summary>
        public static int AllowQuitNumber { get { return 2; } }

        #endregion

        #region 系统参数
        /// <summary>
        /// 箱子移动一格需要的计数次数
        /// </summary>
        public static int BoxShiftCount { get { return 4; } }

        /// <summary>
        /// 推动箱子时的等候计数
        /// </summary>
        public static int PushWaitCount { get { return 4; } }

        /// <summary>
        /// 获取游戏人物距离窗口的边缘距离
        /// </summary>
        public static int EdgeDistance { get { return 150; } }

        #endregion

        #region 楼层跳转参数
        /// <summary>
        /// 楼层跳转窗口的行
        /// </summary>
        public static int SkipWindowRow { get { return 5; } }

        /// <summary>
        /// 楼层跳转窗口的列
        /// </summary>
        public static int SkipWindowCol
        {
            get
            {
                int col = Common.Ceil(6, SkipWindowRow);

                return col > 2 ? col : 2;
            }
        }

        /// <summary>
        /// 获取楼层单元的尺寸
        /// </summary>
        public static Size FloorUnit
        {
            get { return new Size(100, 40); }
        }

        /// <summary>
        /// 获取楼层跳转窗口的尺寸
        /// </summary>
        public static Size SkipWindow 
        {
            get { 
                return new Size(GameIni.SkipWindowCol * (GameIni.FloorUnit.Width + 30),
                    GameIni.SkipWindowRow * (GameIni.FloorUnit.Height + 20) + 50);
            } 
        }

        #endregion

        #region 对话框参数
        /// <summary>
        /// 获取对话框窗口的尺寸
        /// </summary>
        public static Size DialogueSize
        {
            get { return new Size(350, 140); }
        }

        #endregion

        #region 怪物手册
        /// <summary>
        /// 获取怪物手册窗口的尺寸
        /// </summary>
        public static Size BookSize
        {
            get { return new Size(580, 450); }
        }

        /// <summary>
        /// 获取怪物数据窗口的尺寸
        /// </summary>
        public static Size MiniBookSize
        {
            get { return new Size(240, 270); }
        }

        /// <summary>
        /// 获取怪物手册每页显示的怪物数量
        /// </summary>
        public static int PageVolume
        {
            get { return 6; }
        }
        #endregion

        #region 其他参数
        /// <summary>
        /// 获取道具在道具栏的图标大小
        /// </summary>
        public static Size PropIcon
        {
            get { return new Size(30, 30); }
        }

        /// <summary>
        /// 获取商店窗口的尺寸
        /// </summary>
        public static Size ShopSize
        {
            get { return new Size(250, 300); }
        }

        /// <summary>
        /// 箱子每次推动的总移动次数
        /// </summary>
        public static int BoxMoveTimes
        {
            get { return 8; }
        }

        /// <summary>
        /// 获取推箱子之前的等候时间，产生力气消耗的效果
        /// </summary>
        public static int BoxPushWait
        {
            get { return 5; }
        }

        /// <summary>
        /// 获取晃动一次的时间，一共要晃动四次
        /// </summary>
        public static int ShakeUnitTime
        {
            get { return 4; }
        }

        /// <summary>
        /// 获取晃动一步的距离
        /// </summary>
        public static int ShakeWidth
        {
            get { return 4; }
        }

        /// <summary>
        /// 获取背包的初始容量
        /// </summary>
        public static int PacketCapacity
        {
            get { return 30; }
        }
        #endregion

        #region 战斗参数
        /// <summary>
        /// 获取战斗窗口的尺寸
        /// </summary>
        public static Size BattleSize
        {
            get { return new Size(500, 218); }
        }
        #endregion

        #region 技能参数
        /// <summary>
        /// 获取单个技能特效图的尺寸
        /// </summary>
        public static Size SkillFrameSize
        {
            get { return new Size(120, 120); }
        }
        #endregion

        /// <summary>
        /// 获取主游戏记录文件
        /// </summary>
        public static string MainRecord 
        {
            get { return "records/mainRecord.xml"; }
        }

        /// <summary>
        /// 获取存档文件
        /// </summary>
        public static string RecordFile
        {
            get { return "records/record1.xml"; }
        }

    }
}








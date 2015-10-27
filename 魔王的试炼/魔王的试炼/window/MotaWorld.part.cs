using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 魔塔世界的窗口获取器
    /// </summary>
    partial class MotaWorld : GameWindow
    {
        /// <summary>
        /// 获取魔塔地图数据
        /// </summary>
        public MainGame MapManager
        {
            get
            {
                foreach (var item in Windows)
                {
                    if (item is MainGame)
                    {
                        return item as MainGame;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取道具消息显示窗口
        /// </summary>
        public GoodsMessage GoodsGetWindow
        {
            get
            {
                foreach (var item in Windows)
                {
                    if (item is GoodsMessage)
                    {
                        return item as GoodsMessage;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取场景转换窗口
        /// </summary>
        public FloorFlash SkipFlashWindow
        {
            get
            {
                foreach (var item in Windows)
                {
                    if (item is FloorFlash)
                    {
                        return item as FloorFlash;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取道具消息提示窗口
        /// </summary>
        public MessageShow MessageShowWindow
        {
            get
            {
                foreach (var item in Windows)
                {
                    if (item is MessageShow)
                    {
                        return item as MessageShow;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取楼层跳转窗口
        /// </summary>
        public FloorSkip FloorSkipWindow
        {
            get
            {
                foreach (var item in Windows)
                {
                    if (item is FloorSkip)
                    {
                        return item as FloorSkip;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取对话窗口
        /// </summary>
        public DialogueBox DialogueWindow
        {
            get
            {
                foreach (var item in Windows)
                {
                    if (item is DialogueBox)
                    {
                        return item as DialogueBox;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取商店窗口
        /// </summary>
        public Shop ShopWindow
        {
            get
            {
                foreach (var item in Windows)
                {
                    if (item is Shop)
                    {
                        return item as Shop;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取战斗窗口
        /// </summary>
        public BattleBox BattleWindow
        {
            get
            {
                foreach (var item in Windows)
                {
                    if (item is BattleBox)
                    {
                        return item as BattleBox;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取怪物手册窗口
        /// </summary>
        public MonsterBook BookWindow
        {
            get
            {
                foreach (var item in Windows)
                {
                    if (item is MonsterBook)
                    {
                        return item as MonsterBook;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 获取怪物数据窗口
        /// </summary>
        public MiniBook MiniBookWindow
        {
            get
            {
                foreach (var item in Windows)
                {
                    if (item is MiniBook)
                    {
                        return item as MiniBook;
                    }
                }
                return null;
            }
        }


    }
}

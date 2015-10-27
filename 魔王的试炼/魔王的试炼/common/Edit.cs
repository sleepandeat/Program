using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 游戏编辑类，单例模式
    /// </summary>
    class Edit
    {
        private Edit() { }

        private static Edit instance;

        public static Edit GetInstance()
        {
            if (instance == null)
            {
                instance = new Edit();
            }
            return instance;
        }

        /// <summary>
        /// 源本，用于复制
        /// </summary>
        private ElementNode SouVersion;

        /// <summary>
        /// 设置源本
        /// </summary>
        /// <param name="desPos">源本坐标</param>
        public void SetSource(Coord desPos)
        {
            SouVersion = MotaWorld.GetInstance().MapManager.GetNode(desPos);
        }

        /// <summary>
        /// 拷贝源本到新元素
        /// </summary>
        /// <param name="desPos">目标坐标</param>
        public void CopyTo(Coord desPos)
        {
            if (SouVersion != null)
            {
                MotaWorld.GetInstance().MapManager.CopyNode(SouVersion, desPos);
            }
        }

        /// <summary>
        /// 删除目标元素，事件设为空，地表设为默认
        /// </summary>
        /// <param name="souPos">目标元素的坐标</param>
        public void Delete(Coord souPos)
        {
            MotaWorld.GetInstance().MapManager.Delete(souPos);
        }

        /// <summary>
        /// 剪贴
        /// </summary>
        /// <param name="souPos">源目标坐标</param>
        public void Cut(Coord souPos)
        {
            SetSource(souPos);
            Delete(souPos);
        }
    }
}






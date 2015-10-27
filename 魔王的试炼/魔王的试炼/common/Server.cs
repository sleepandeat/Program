using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 服务类，响应界面操作
    /// </summary>
    static class Server
    {
        /// <summary>
        /// 获取魔塔世界实例
        /// </summary>
        private static MotaWorld MagicTower
        {
            get
            {
                return MotaWorld.GetInstance();
            }
        }

    }
}

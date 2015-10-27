using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 魔王的试炼
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MonsterData.LoadMonsterData("data/monster.xml");
            
            Application.Run(new FrmMain());
        }
    }
}

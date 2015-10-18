using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Weather
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ret = false;
            System.Threading.Mutex running = new System.Threading.Mutex(true, Application.ProductName, out ret);
            if (ret)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
                running.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("程序已经在运行，请不要同时运行多个本程序！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}

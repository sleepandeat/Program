using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace 魔王的试炼
{
    class MP3
    {
        public static uint SND_ASYNC = 0x0001; // play asynchronously 
        public static uint SND_FILENAME = 0x00020000; // name is file name
        [DllImport("winmm.dll")]
        public static extern int mciSendString(string m_strCmd, string m_strReceive, int m_v1, int m_v2);
        [DllImport("Kernel32", CharSet = CharSet.Auto)]
        static extern Int32 GetShortPathName(String path, StringBuilder shortPath, Int32 shortPathLength);

        static public void Load(string s)
        {
            string name = @"sounds\" + s;
            StringBuilder shortpath = new StringBuilder(80);
            int result = GetShortPathName(name, shortpath, shortpath.Capacity);
            name = shortpath.ToString();
            mciSendString(@"close all", null, 0, 0);
            mciSendString(@"open " + name + " alias song", null, 0, 0); //打开
            mciSendString("play song repeat", null, 0, 0); //播放
        }
    }
}

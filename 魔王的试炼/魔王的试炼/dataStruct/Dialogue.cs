using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    /// <summary>
    /// 对话的数据结构，用于存在一次对话的信息
    /// </summary>
    struct Dialogue
    {
        /// <summary>
        /// 创建一次会话数据
        /// </summary>
        /// <param name="name">说话人</param>
        /// <param name="content">对话内容</param>
        public Dialogue(string name, string content)
        {
            this.Speaker = name;
            this.Content = content;
        }

        /// <summary>
        /// 说话人
        /// </summary>
        public string Speaker;

        /// <summary>
        /// 对话内容
        /// </summary>
        public string Content; 
    }
}

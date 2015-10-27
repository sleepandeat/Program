using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 魔王的试炼
{
    //说明:
    //  这里选用hero类作为引用对象，因为只有它有能力触发事件
    //
    //

    /// <summary>
    /// 事件核心方法,由事件类选择性调用
    /// </summary>
    static class EventLogic
    {
        /// <summary>
        /// 上楼
        /// </summary>
        public static void UpFloor(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            MotaWorld.GetInstance().MapManager.CurFloorIndex = MotaWorld.GetInstance().MapManager.CurFloorNode.NextFloor;
            EventEffect(data);
        }

        /// <summary>
        /// 下楼
        /// </summary>
        public static void DownFloor(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            MotaWorld.GetInstance().MapManager.CurFloorIndex = MotaWorld.GetInstance().MapManager.CurFloorNode.PreFloor;
            EventEffect(data);
        }

        /// <summary>
        /// 增加血量 
        /// </summary>
        public static void AddHp(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            player.Hp += data.Value;
            EventEffect(data);
        }

        /// <summary>
        /// 倍增血量 
        /// </summary>
        public static void MulHp(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            player.Hp += (int)(player.Hp * data.Rate);
            EventEffect(data);
        }

        /// <summary>
        /// 增加攻击
        /// </summary>
        public static void AddAttack(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            player.Attack += data.Value;
            EventEffect(data);
        }

        /// <summary>
        /// 增加防御
        /// </summary>
        public static void AddDefence(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            player.Defence += data.Value;
            EventEffect(data);
        }

        /// <summary>
        /// 增加敏捷
        /// </summary>
        public static void AddAgility(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            player.Agility += data.Value;
            EventEffect(data);
        }

        /// <summary>
        /// 增加魔法
        /// </summary>
        public static void AddMagic(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            player.Magic += data.Value;
            EventEffect(data);
        }

        /// <summary>
        /// 增加金币
        /// </summary>
        public static void AddCoin(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            player.Coin += data.Value;
            EventEffect(data);
        }

        /// <summary>
        /// 增加经验
        /// </summary>
        public static void AddExp(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            player.Exp += data.Value;
            EventEffect(data);
        }

        /// <summary>
        /// 增加等级
        /// </summary>
        public static void AddLevel(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            player.Level += data.Value;
            EventEffect(data);
        }

        /// <summary>
        /// 增加道具
        /// </summary>
        public static void AddProperty(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            player.Pack.AddProperty(data.Prop, data.Value);
            EventEffect(data);
        }

        /// <summary>
        /// 打开对话窗口
        /// </summary>
        public static void OpenDialogue(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();

            Dialogue[] dialogues = data.Messages;
            MotaWorld.GetInstance().DialogueWindow.Open(dialogues);

            EventEffect(data);
        }

        /// <summary>
        /// 播放音效(用户定义的音效播放)
        /// </summary>
        public static void PlaySound(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            SoundsList.PlaySound(data.Sound);
            EventEffect(data);
        }

        /// <summary>
        /// 进入陷阱事件，损耗一定的生命值，并产生晃动效果
        /// 如果拥有路障道具的话，可以避免生命值的损耗
        /// </summary>
        public static void OnTrap(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();

            //检查是否拥有自然之靴
            if (!player.Pack.ExistProperty(PropName.自然之靴))
            {
                player.Hp -= data.Value;
                MotaWorld.GetInstance().MapManager.Shake();
            }

            EventEffect(data);
        }

        /// <summary>
        /// 开启事件
        /// </summary>
        public static void OpenEvent(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            //如果目标位置存在事件，开启它
            MapEvent me = MotaWorld.GetInstance().MapManager.Tower[data.DesPosation.Floor].EventMap[data.DesPosation.Seat.Row, data.DesPosation.Seat.Col];
            if (me != null)
            {
                me.Open();
            }  
            EventEffect(data);
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        public static void CloseEvent(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            //如果目标位置存在事件，关闭它
            MapEvent me = MotaWorld.GetInstance().MapManager.Tower[data.DesPosation.Floor].EventMap[data.DesPosation.Seat.Row, data.DesPosation.Seat.Col];
            if (me != null)
            {
                me.Close();
            }
            EventEffect(data);
        }

        /// <summary>
        /// 开启地表
        /// </summary>
        public static void OpenGround(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            //如果目标位置存在地表，开启它
            Background bg = MotaWorld.GetInstance().MapManager.Tower[data.DesPosation.Floor].BackMap[data.DesPosation.Seat.Row, data.DesPosation.Seat.Col];
            if (bg != null)
            {
                bg.Open();
            }
            EventEffect(data);
        }

        /// <summary>
        /// 关闭地表
        /// </summary>
        public static void CloseGround(Queue<MotaEventArgs> datas, Hero player)
        {
            MotaEventArgs data = datas.Dequeue();
            //如果目标位置存在地表，关闭它
            Background bg = MotaWorld.GetInstance().MapManager.Tower[data.DesPosation.Floor].BackMap[data.DesPosation.Seat.Row, data.DesPosation.Seat.Col];
            if (bg != null)
            {
                bg.Close();
            }
            EventEffect(data);
        }

        /// <summary>
        /// 设置事件效果
        /// </summary>
        /// <param name="method">事件参数</param>
        public static void EventEffect(MotaEventArgs data)
        {
            if (data.Method == EffectType.Blood || data.Method == EffectType.Goods || data.Method == EffectType.LevelUp)
            {
                MotaWorld.GetInstance().GoodsGetWindow.Open(new ShortMessage("获得" + data.Name, data.ExistStation));
            }

            //获取物品时显示消息
            if (data.Method == EffectType.Goods)
            {
                //播放音效
                SoundsList.PlaySound(SoundType.获得物品);
            }

            if (data.Method == EffectType.Blood)
            {
                SoundsList.PlaySound(SoundType.获取血瓶);
            }

            //获取道具时提升信息
            if (data.Method == EffectType.Prop)
            {
                MotaWorld.GetInstance().MessageShowWindow.Open(Property.GetDescribe(data.Prop));

                SoundsList.PlaySound(SoundType.获取道具);
            }

            if (data.Method == EffectType.LevelUp)
            {
                SoundsList.PlaySound(SoundType.升级);
            }
        }
        
    }
}















using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace 魔王的试炼
{
    /// <summary>
    /// 枚举游戏音效
    /// </summary>
    enum SoundType
    {
        获取血瓶 = 0,
        获取道具 = 1,
        开门 = 2,
        选择 = 3,
        确认选择 = 4,
        楼层跳转 = 5,
        对话 = 6,
        破墙 = 7,
        升级 = 8,
        错误 = 9,
        获得物品 = 10,
        进入商店 = 11,
        关闭商店 = 12,
        暗墙 = 13,
        普通攻击 = 14,
        剑击 = 15,
        战斗结束 = 16,
        推箱子 = 17,
        暴击 = 18,
        怪物暴击 = 19,
        防御屏障 = 20,
        恢复 = 21,
        愤怒一击 = 22,
        保存 = 23,
        NULL = 99,
    }

    /// <summary>
    /// 音效列表，加载音效到内存
    /// </summary>
    static class SoundsList
    {
        static SoundPlayer[] Sounds = new SoundPlayer[100];

        static SoundsList()
        {
            for (int i = 0; i < Sounds.Length; i++)
            {
                Sounds[i] = LoadSound((SoundType)i);
            }
        }

        /// <summary>
        /// 根据音效类型加载游戏音效到内存
        /// </summary>
        private static SoundPlayer LoadSound(SoundType type)
        {
            SoundPlayer sp = null;
            switch (type)
            {
                case SoundType.获取血瓶:
                    sp = new SoundPlayer(@"sounds/音效/血瓶.WAV");
                    break;
                case SoundType.获取道具:
                    sp = new SoundPlayer(@"sounds/音效/GetProp.wav");
                    break;
                case SoundType.开门:
                    sp = new SoundPlayer(@"sounds/音效/Key.wav");
                    break;
                case SoundType.选择:
                    sp = new SoundPlayer(@"sounds/音效/选择.WAV");
                    break;
                case SoundType.确认选择:
                    sp = new SoundPlayer(@"sounds/音效/确定.WAV");
                    break;
                case SoundType.楼层跳转:
                    sp = new SoundPlayer(@"sounds/音效/战斗结束.WAV");
                    break;
                case SoundType.对话:
                    sp = new SoundPlayer(@"sounds/音效/dialogue.wav");
                    break;
                case SoundType.破墙:
                    sp = new SoundPlayer(@"sounds/音效/destroy.wav");
                    break;
                case SoundType.升级:
                    sp = new SoundPlayer(@"sounds/音效/升级.WAV");
                    break;
                case SoundType.错误:
                    sp = new SoundPlayer(@"sounds/音效/错误.WAV");
                    break;
                case SoundType.获得物品:
                    sp = new SoundPlayer(@"sounds/音效/获得物品.WAV");
                    break;
                case SoundType.进入商店:
                    sp = new SoundPlayer(@"sounds/音效/金币商店.WAV");
                    break;
                case SoundType.关闭商店:
                    sp = new SoundPlayer(@"sounds/音效/取消.WAV");
                    break;
                case SoundType.暗墙:
                    sp = new SoundPlayer(@"sounds/音效/暗墙.WAV");
                    break;
                case SoundType.普通攻击:
                    sp = new SoundPlayer(@"sounds/音效/普通攻击.WAV");
                    break;
                case SoundType.剑击:
                    sp = new SoundPlayer(@"sounds/音效/剑击.WAV");
                    break;
                case SoundType.战斗结束:
                    sp = new SoundPlayer(@"sounds/音效/战斗结束.WAV");
                    break;
                case SoundType.推箱子:
                    sp = new SoundPlayer(@"sounds/音效/推箱子.WAV");
                    break;
                case SoundType.暴击:
                    sp = new SoundPlayer(@"sounds/音效/暴击.WAV");
                    break;
                case SoundType.怪物暴击:
                    sp = new SoundPlayer(@"sounds/音效/怪物暴击.WAV");
                    break;
                case SoundType.防御屏障:
                    sp = new SoundPlayer(@"sounds/音效/防御屏障.WAV");
                    break;
                case SoundType.恢复:
                    sp = new SoundPlayer(@"sounds/音效/恢复.WAV");
                    break;
                case SoundType.愤怒一击:
                    sp = new SoundPlayer(@"sounds/音效/愤怒一击.WAV");
                    break;
                case SoundType.保存:
                    sp = new SoundPlayer(@"sounds/音效/保存.WAV");
                    break;


                default:
                    break;
            }
            return sp;
        }

        /// <summary>
        /// 根据游戏音效类型播放音效
        /// </summary>
        /// <param name="type">音效类型</param>
        public static void PlaySound(SoundType type)
        {
            if (Sounds[(int)type] != null)
            {
                Sounds[(int)type].Play();
            }
            else
            {
                throw new Exception("不存在的音效类型");
            }
        }

    }
}











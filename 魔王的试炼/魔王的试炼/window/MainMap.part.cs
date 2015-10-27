using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace 魔王的试炼
{
    /// <summary>
    /// 魔塔主场景类的一些委托方法
    /// </summary>
    partial class MainGame
    {
        /// <summary>
        /// 判断当前楼层中的某个位置对于某个方向是否是可通行的
        /// </summary>
        /// <param name="pos">楼层中的位置</param>
        /// <param name="moveDirection">方向</param>
        /// <returns>如果不可通行，返回false</returns>
        public bool IsPassable(Coord pos, Direction moveDirection)
        {
            //委托楼层对象处理
            return CurFloorNode.IsPassable(pos, moveDirection);
        }

        /// <summary>
        /// 移动事件元素到新的位置，如果移动成功返回true
        /// </summary>
        /// <param name="souPos">源坐标</param>
        /// <param name="desPos">目标坐标</param>
        /// <param name="moveDirection">目标的移动方向，用于检测目标位置是否可通行</param>
        public bool ShiftEvent(Coord souPos, Coord desPos, Direction moveDirection)
        {
            //委托楼层对象处理
            return CurFloorNode.ShiftEvent(souPos, desPos, moveDirection);
        }

        /// <summary>
        /// 触发坐标处的事件
        /// </summary>
        /// <param name="pos">在地图上的坐标</param>
        /// <param name="triggerMethod">触发方式</param>
        /// <param name="player">触发者</param>
        public void TriggerEvent(Coord pos, TouchMethod triggerMethod, Hero player)
        {
            //委托楼层对象处理
            CurFloorNode.TriggerEvent(pos, triggerMethod, player);
        }

        /// <summary>
        /// 如果墙可以被破坏的话，破坏一堵墙
        /// </summary>
        /// <param name="pos">墙的位置</param>
        /// <returns>返回一个布尔值，标示是否破坏成功，如果墙不可以破坏，则返回false</returns>
        public bool Destroy(Coord pos)
        {
            //委托楼层对象处理
            return CurFloorNode.Destroy(pos);
        }

        /// <summary>
        /// 处理按键进行人物移动和道具使用
        /// </summary>
        /// <param name="code">按键</param>
        /// <returns>返回一个布尔值，标示按键是否被处理</returns>
        public override bool HandleKeyDown(System.Windows.Forms.Keys code)
        {
            //委托勇士对象处理按键
            return CurHero.HandleKeyDown(code);
        }

        /// <summary>
        /// 让窗口产生晃动
        /// </summary>
        public void Shake()
        {
            //委托窗口对象处理
            this.View.Shake();
        }

        /// <summary>
        /// 根据地图上的位置计算出在视图窗口上的相对位置
        /// </summary>
        /// <param name="mapPos">地图上的绝对位置</param>
        /// <returns>在视图窗口上的相当位置</returns>
        public Point GetWindowPosation(Point mapPos)
        {
            //委托窗口对象计算
            return View.GetWindowPosation(mapPos);
        }

        /// <summary>
        /// 根据视图窗口上的位置计算出在地图上的绝对位置
        /// </summary>
        /// <param name="windowPos">窗口上的相当位置</param>
        /// <returns>地图上的绝对位置</returns>
        public Point GetMapPosation(Point windowPos)
        { 
            //委托窗口对象计算
            return View.GetMapPosation(windowPos);
        }

        /// <summary>
        /// 刷新窗口位置，使之跟随目标的移动而移动
        /// </summary>
        /// <param name="MapPoint">目标的绝对位置</param>
        /// <param name="way">移动的方向</param>
        public void RefreshView(Point desPoint, Direction way)
        { 
            //委托窗口对象处理
            View.RefreshView(desPoint, way);
        }

        /// <summary>
        /// 根据窗口中的位置获取在地图上的坐标
        /// </summary>
        /// <param name="location">窗口中的位置</param>
        /// <returns>返回地图上的坐标</returns>
        public Coord GetPosation(Point location)
        { 
            return Common.GetStation(GetMapPosation(location));
        }

        /// <summary>
        /// 判断当前楼层中某个位置存放存在怪物
        /// </summary>
        /// <param name="pos">坐标</param>
        /// <returns>获取一个布尔值，标示是否存在怪物，如果存在，返回true</returns>
        public bool IsMonster(Point location)
        { 
            //委托楼层对象计算
            return CurFloorNode.IsMonster(GetPosation(location));
        }

        /// <summary>
        /// 删除目标元素，事件设为空，地表设为默认
        /// </summary>
        /// <param name="souPos">目标元素的坐标</param>
        public void Delete(Coord souPos)
        {
            this.CurFloorNode.Delete(souPos);
        }

        
        /// <summary>
        /// 拷贝源节点到新节点(覆盖)
        /// </summary>
        /// <param name="node">源节点元素</param>
        /// <param name="desNode">新节点元素坐标</param>
        public void CopyNode(ElementNode node, Coord desNode)
        {
            this.CurFloorNode.CopyNode(node, desNode);
        }

        /// <summary>
        /// 根据结点坐标获取结点元素
        /// </summary>
        /// <param name="desPos">结点坐标</param>
        /// <returns>结点元素</returns>
        public ElementNode GetNode(Coord desPos)
        {
            return this.CurFloorNode.GetNode(desPos);
        }

        /// <summary>
        /// 根据Xml元素重新加载结点
        /// </summary>
        /// <param name="desPos">结点坐标</param>
        /// <param name="xmlStr">xml字符串</param>
        public void LoadNode(Coord desPos, string xmlStr)
        {
            this.CurFloorNode.LoadNode(desPos, xmlStr);
        }

        /// <summary>
        /// 获取结点字符串描述（xml格式）
        /// </summary>
        /// <param name="desPos">目标坐标</param>
        /// <returns>xml字符串</returns>
        public string GetNodeString(Coord desPos)
        {
            return this.CurFloorNode.GetNodeString(desPos);
        }
    }
}




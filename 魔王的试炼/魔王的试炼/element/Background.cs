using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Linq;

namespace 魔王的试炼
{
    /// <summary>
    /// 地图背景层，包括墙壁和空地.
    /// 静态类，为每一种不同的地图元素提供同一个实例
    /// </summary>
    class Background : MapElement
    {
        /// <summary>
        /// 设置地图元素实例
        /// </summary>
        /// <param name="face">图像类型</param>
        /// <param name="pos">元素在地图上的坐标</param>
        /// <param name="canDestroy">元素是否可以被破墙镐破坏</param>
        public Background(MotaElement face, Coord pos, bool canDestroy = true) : base(face, pos) 
        {
            this.canDestroy = canDestroy;
        }

        private bool canDestroy;
        /// <summary>
        /// 获取元素是否可以被破墙镐破坏
        /// </summary>
        public bool CanDestroy
        {
            get
            {
                //只要是不可以通行的道路，才有可能被破坏
                if (Obstacle && canDestroy)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 根据地图参数创建相应的地图元素
        /// </summary>
        /// <param name="mapArgs">地图参数</param>
        /// <param name="existCoord">出现坐标</param>
        /// <returns>地图元素</returns>
        public static Background CreateInstance(XElement mapArgs, Coord existCoord)
        {
            int faceIndex;          //图像索引
            try
            {
                faceIndex = int.Parse(mapArgs.Element("faceIndex").Value);
            }
            catch (Exception)
            {
                throw new Exception("错误的地图类型 位置: " + existCoord.ToString());
            }

            bool canDestory = false;
            if (mapArgs.Element("canDestory") != null)
            {
                canDestory = true;
            }

            Background oneBack = new Background((MotaElement)faceIndex, existCoord, canDestory);

            bool upAllow = false;
            if (mapArgs.Element("upAllow") != null)
            {
                upAllow = true;
            } 
            bool downAllow = false;
            if (mapArgs.Element("downAllow") != null)
            {
                downAllow = true;
            }
            bool leftAllow = false;
            if (mapArgs.Element("leftAllow") != null)
            {
                leftAllow = true;
            } 
            bool rightAllow = false;
            if (mapArgs.Element("rightAllow") != null)
            {
                rightAllow = true;
            }

            oneBack.PassLeft = leftAllow;
            oneBack.PassDown = downAllow;
            oneBack.PassRight = rightAllow;
            oneBack.PassUp = upAllow;

            return oneBack;
        }

        /// <summary>
        /// 获取自身实例的Xml节点记录
        /// </summary>
        /// <returns>Xml描述的记录</returns>
        public XElement XmlRecord
        {
            get
            {
                if (!this.Exist)
                {
                    return EmptyXml;
                }

                XElement xmlRecord = new XElement("oneBack");
                xmlRecord.SetElementValue("faceIndex", this.FaceIndex);
                if (this.CanDestroy)
                {
                    xmlRecord.Add(new XElement("canDestory"));
                }
                if (this.PassUp)
                {
                    xmlRecord.Add(new XElement("upAllow"));
                }
                if (this.PassRight)
                {
                    xmlRecord.Add(new XElement("rightAllow"));
                }
                if (this.PassLeft)
                {
                    xmlRecord.Add(new XElement("leftAllow"));
                }
                if (this.PassDown)
                {
                    xmlRecord.Add(new XElement("downAllow"));
                }

                return xmlRecord;
            }
        }

        /// <summary>
        /// 获取缺省的地图xml数据
        /// </summary>
        public static XElement EmptyXml
        {
            get
            {
                XElement empty = new XElement("oneBack");
                empty.Add(new XElement("faceIndex", (int)MotaElement.Empty));
                empty.Add(new XElement("upAllow"));
                empty.Add(new XElement("downAllow"));
                empty.Add(new XElement("leftAllow"));
                empty.Add(new XElement("rightAllow"));
                return empty;
            }
        }

        /// <summary>
        /// 获取空地表的实例
        /// </summary>
        public static Background GetEmpty(Coord souPos)
        {
            return CreateInstance(EmptyXml, souPos);
        }
    }
}













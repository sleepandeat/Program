using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace 魔王的试炼
{
    /// <summary>
    /// 图像处理扩展方法类
    /// </summary>
    static class ImageProcess
    {
        /// <summary>
        /// 设置图像透明度(扩展方法)
        /// </summary>
        /// <param name="srcImage">源图像</param>
        /// <param name="opacity">透明度</param>
        public static void SetOpacity(this Bitmap srcImage, float opacity)
        {
            //变换矩阵
            float[][] nArray =
            {
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, opacity, 0},
                new float[] {0, 0, 0, 0, 1}
            };
            ColorMatrix matrix = new ColorMatrix(nArray);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            Bitmap preImage = new Bitmap(srcImage);
            Graphics.FromImage(srcImage).Clear(Color.Transparent);
            Graphics.FromImage(srcImage).DrawImage(preImage, new Rectangle(0, 0, srcImage.Width, srcImage.Height), 0, 0, srcImage.Width, srcImage.Height, GraphicsUnit.Pixel, attributes);
        }

        /// <summary>
        /// 对图像进行描边(扩展方法)
        /// </summary>
        /// <param name="srcPicture">源图像</param>
        /// <param name="borderColor">描边边界的颜色</param>
        public static void Stroke(this Bitmap srcPicture, Color borderColor)
        {
            for (int i = 0; i < srcPicture.Height; i++)
            {
                for (int j = 0; j < srcPicture.Width; j++)
                {
                    //当前的alpha分量
                    byte curAlpha = srcPicture.GetPixel(j, i).A;
                    if (curAlpha == 0 || curAlpha == borderColor.A)
                    {
                        continue;
                    }

                    //设置四个方向向量
                    Point[] vector = new Point[4]
                    {
                        new Point(0, 1),    //下
                        new Point(0, -1),   //上
                        new Point(1, 0),    //右
                        new Point(-1, 0),   //左
                    };

                    //遍历四个方向寻找描绘点
                    for (int k = 0; k < vector.Length; k++)
                    {
                        Point newPoint = new Point(j + vector[k].X, i + vector[k].Y);
                        if (newPoint.X >= 0 && newPoint.X < srcPicture.Width && newPoint.Y >= 0 && newPoint.Y < srcPicture.Height)
                        {
                            //如果是空白像素，描绘此点
                            if (srcPicture.GetPixel(newPoint.X, newPoint.Y).A == 0)
                            {
                                srcPicture.SetPixel(newPoint.X, newPoint.Y, borderColor);
                            }
                        }
                    }
                }
            }
        }
    }
}

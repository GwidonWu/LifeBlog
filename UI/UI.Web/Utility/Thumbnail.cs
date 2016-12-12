using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace UI.Web.Utility
{
    /// <summary>
    /// 生成缩略图
    /// </summary>
    public class Thumbnail
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">源地址</param>
        /// <param name="destination">保存地址</param>
        /// <param name="maxWidth">最大宽度</param>
        /// <param name="maxHeight">最大高度</param>
        public static void GenerateThumbnail(string source,string destination,int maxWidth,int maxHeight)
        {
            System.Drawing.Image orginalImage = System.Drawing.Image.FromFile(source);
            int originalWidth = orginalImage.Width;
            int originalHeight = orginalImage.Height;
            int thumbnailWidth, thumbnailHeight;
            Resize(originalWidth, originalHeight, maxWidth, maxHeight, out thumbnailWidth, out thumbnailHeight);
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(thumbnailWidth, thumbnailHeight);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawImage(orginalImage, 0, 0, thumbnailWidth, thumbnailHeight);
            bitmap.Save(destination);
        }
        private static void Resize(int origWidth,int origHeight,int maxWidth,int maxHeight,out int sizeWidth,out int sizeHeight)
        {
            if (origWidth < maxWidth && origHeight < maxHeight)
            {
                sizeWidth = origWidth;
                sizeHeight = origHeight;
                return;
            }
            sizeWidth = maxWidth;
            sizeHeight = (int)((double)origHeight / origWidth * sizeWidth + 0.5);
            if (sizeHeight > maxHeight)
            {
                sizeHeight = maxHeight;
                sizeWidth = (int)((double)origWidth / origHeight * sizeHeight + 0.5);
            }
        }
    }
}
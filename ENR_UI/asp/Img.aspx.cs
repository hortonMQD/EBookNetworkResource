using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ENR_UI.asp
{
    public partial class Img : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request["url"].ToString();
            string url1 = Server.MapPath(url);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            GetReducedImage(90, 100, url1).Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Response.ClearContent();
            Response.ContentType = "image/png";
            Response.BinaryWrite(ms.ToArray());
        }

        public System.Drawing.Image GetReducedImage(int Width, int Height, string url)
        {
            string src = url;
            System.Drawing.Image ResourceImage = System.Drawing.Image.FromFile(src);
            try
            {
                //用指定的大小和格式初始化Bitmap类的新实例
                Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                //从指定的Image对象创建新Graphics对象
                Graphics graphics = Graphics.FromImage(bitmap);
                //清除整个绘图面并以透明背景色填充
                graphics.Clear(Color.Transparent);
                //在指定位置并且按指定大小绘制原图片对象
                graphics.DrawImage(ResourceImage, new Rectangle(0, 0, Width, Height));
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                return bitmap;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
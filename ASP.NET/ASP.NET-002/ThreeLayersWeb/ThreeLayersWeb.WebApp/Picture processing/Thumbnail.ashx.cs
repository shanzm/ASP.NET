using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using ThreeLayersWeb.Common;

namespace ThreeLayersWeb.WebApp
{
    /// <summary>
    /// Thumbnail -实现缩略图 
    /// </summary>
    public class Thumbnail : IHttpHandler
    {
        public void   ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";


            //获取图片的缩略图——定义一个较小的画布，在画布上重画该张图片 
            string filePath = context.Request.MapPath("/ImageUpLoad/1.jpg");

            //创建一个图片
            using (Image img = Image.FromFile(filePath))
            {
                //设置画布大写，以图片为背景
                //我们不绘制其他的图案，直接把缩小的背景保存为图片，这就是原来图片的缩略图
                using (Bitmap map = new Bitmap(img, img.Width / 3, img.Height / 3))
                {
                    //定义图片的名称
                    string fileName = Guid.NewGuid().ToString();
                    //保存缩小的图片
                    map.Save(context.Request.MapPath("/ImageUpLoad/" + fileName + "_缩略图" + ".png"), System.Drawing.Imaging.ImageFormat.Jpeg);

                    context.Response.Write("<html><body><img src='" + "/ImageUpLoad/" + fileName + "_缩略图" + ".png '>" + "</body></html>");
                }
            }


            //调用ImageClass类中对图像处理的方法，给图片加水印
            //注意LetterWatermark返回的是图片加水印的新的图片的绝对路径,这个绝对路径在下面的src中，使用出错，尽量还是使用相对路径吧
            string Path = ImageClass.LetterWatermark(filePath,50, "--test--", Color.Blue, "B");
            
            context.Response.Write("<html><body><img src='"+"/ImageUpLoad/1.jpg"+ "'></body></html>");

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
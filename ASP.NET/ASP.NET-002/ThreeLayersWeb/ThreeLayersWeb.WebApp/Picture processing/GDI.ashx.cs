using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace ThreeLayersWeb.WebApp
{
    /// <summary>
    /// GDI+ 绘图demo
    /// </summary>
    public class GDI : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            //绘制一张图片并保存


            //新建一张300px*400px的画布
            using (Bitmap map = new Bitmap(400, 400))
            {
                //在画布map上新建一个画笔
                using (Graphics gra=Graphics.FromImage (map) )
                {
                    //将画布填充灰色
                    gra.Clear(Color.Gray);
                    //在画布中写字
                    //注意DrawString()四个参数的意义
                    gra.DrawString("https://github.com/shanzm", new Font("黑体", 14.0f, FontStyle.Bold), Brushes.Blue, new PointF(100, 350));
                    
                    //使用GUID定义一个文件名
                    string fileName = Guid.NewGuid().ToString();
                    //保存为一张图片，并且指定图片的格式
                    map.Save(context.Request.MapPath("/ImageUpLoad/" + fileName + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg );


                    context.Response.Write("<html><body><img src='"+"/ImageUpLoad/" + fileName + ".jpg"+"'</body></html>");
                     //注意这里引号配对，首先我们先写出来"<html。《、html"
                }
            }
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
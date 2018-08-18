using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace ThreeLayersWeb.WebApp
{
    /// <summary>
    /// FileUp -上传图片
    /// </summary>
    public class FileUp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string text = context.Request.Form["txtName"];
            HttpPostedFile file = context.Request.Files[0];//获取上传的文件
            //如果你是有多个图片提交按钮(也就是同时提交多个图片）
            //HttpFileCollection files = context.Request.Files;
            if (file.ContentLength > 0)//注意啊直接使用file != null判断是不可以的，因为你即使没有选择文件就提交，得到对象file长度为0，但并不意味着为空
            {
                //校验上传的文件类型
                //注意file.fileName 是获取文件file的完全路径
                //Path.GetFileName()获取是文件名和扩展名
                string fileName = Path.GetFileName(file.FileName);
                //获取文件的扩展名(注意获取的扩展名是包含一个点的)
                string fileExt = Path.GetExtension(fileName);
                //定义一个图片类型的数据用于后续判定上传的文件类型是不是属于这个数组
                string[] fileExts = { ".jpg", ".png", ".gif" };
                if (fileExts.Contains(fileExt))
                {
                    ////将文件保存在ImageUpLoad文件夹    
                    //file.SaveAs(context.Request.MapPath("/ImageUpLoad/" + fileName));                
                    ////展示上传的图片文件,☆☆☆☆☆☆☆☆☆☆☆注意路径中一定不要写多余的空格
                    //context.Response.Write("<html><body><img src='/ImageUpLoad/" + fileName + "'></body></html>");


                    //上面的写法不好，
                    //1.文件名使用的用户上传的文件名，如果上传了同名文件会覆盖,所以我们使用GUID命名文件
                    //2.我们把所有用户上传的文件都放在了一个ImageUpLoad文件夹中，当文件变多后不便于后期查看。所以我们根据日期分层新建文件夹

                    //新建GUID作为文件的名称
                    string newFileName = Guid.NewGuid().ToString();
                    //将不同的文件放在不同的文件夹中
                    //定义文件夹的物理路径
                    string dir = "/ImageUpLoad/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
                    //如果没有则新建文件夹
                    //注意context .Request.MapPath (dir)的值是 D:\Documents\Visual Studio 2010\Projects\ThreeLayersWeb\ThreeLayersWeb.WebApp\ImageUpLoad\2018\8\17\
                    if (!Directory.Exists(context.Request.MapPath(dir)))
                    {
                        Directory.CreateDirectory(context.Request.MapPath(dir));
                    }

                    //文件的全路径（就是包括文件名和文件扩展名）
                    string fullDir = dir + newFileName + fileExt;

                    file.SaveAs(context.Request.MapPath(fullDir));


                    //下面就是给图片加水印
                    //加水印之前呢我们要想一想，我们在服务器中是只保存加了水印的图片还是既保存加水印的图片还保存用户上传的原始图片
                    //如果你只要加水印的图片则
                    //这段文字上面的那句： file.SaveAs(context.Request.MapPath(fullDir));
                    //就不需要写了，你可以在加完水印之后再保存



                    //根据上传图片创建一个image实例
                    using (Image img = Image.FromFile(context.Request.MapPath(fullDir)))
                    //如果之前没有保存图片,则使用文件流，这么写
                    //using (Image img=Image .FromStream (file.InputStream ))
                    {
                        //根据图片的宽度和高度创建以图片为背景的画布
                        using (Bitmap map = new Bitmap(img, img.Width, img.Height))
                        {
                            using (Graphics gra = Graphics.FromImage(map))
                            {
                                gra.DrawString("https://github.com/shanzm", new Font("黑体", 19.0f, FontStyle.Bold), Brushes.Blue, new PointF(img.Width - 400, img.Height - 30));
                                //定义图片存储的路径
                                fullDir = dir + newFileName + "_水印" + fileExt;
                                map.Save(context.Request.MapPath(fullDir), System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                        }


                    }




                    context.Response.Write("<html><body><img src='" + fullDir + "'</body></html>");

                }
                else
                {
                    context.Response.Write("只能上传图片文件");
                }
            }
            else
            {
                context.Response.Write("请选择上传文件！");
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
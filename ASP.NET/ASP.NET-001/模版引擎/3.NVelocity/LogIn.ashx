<%@ WebHandler Language="C#" Class="LogIn" %>

using System;
using System.Web;
using NVelocity;
using NVelocity.Runtime;
using NVelocity.App;



///注意我们添加引用-NVelocity.dll
///在这里添加命名空间
///using NVelocity;
///using NVelocity.Runtime;
///using NVelocity.App;
///其实我没有文档，好像VS在这里也没有智能提示，所以我是使用VS自带的对象浏览器查看的下面代码中使用的函数的命名空间
///
///注意下面怎么初始化NVelocity等等代码其实没有必要记住，保存好随时可以拷贝就好。
///

///你发现好像和不使用这个模版引擎，直接使用字符串，再使用占位符之后再作替换也没有什么区别吗？其实这里我们只是举了一个简单的例子
///模版引擎的其他功能见4.NVelocity



public class LogIn : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string username = context.Request["username"];
        string password = context.Request["password"];



        if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
        {
            VelocityEngine vltEngine = new VelocityEngine();
            vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("~/模版引擎/3.NVelocity/templates"));//模板文件所在的文件夹
            vltEngine.Init();

            VelocityContext vltContext = new VelocityContext();
            vltContext.Put("username", "");//设置参数，在模板中可以通过$data来引用
            vltContext.Put("password", "");
            vltContext.Put("msg", "");
            Template vltTemplate = vltEngine.GetTemplate("LogIn.html");
            System.IO.StringWriter vltWriter = new System.IO.StringWriter();
            vltTemplate.Merge(vltContext, vltWriter);

            string html = vltWriter.GetStringBuilder().ToString();
            context.Response.Write(html);
        }
        else
        {
            if (username == "admin" && password == "123")
            {
                context.Response.Write("登录成功");
            }
            else
            {
                VelocityEngine vltEngine = new VelocityEngine();
                vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
                vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("~/模版引擎/3.NVelocity/templates"));//模板文件所在的文件夹
                vltEngine.Init();

                VelocityContext vltContext = new VelocityContext();
                vltContext.Put("username", username);//设置参数，在模板中可以通过$data来引用
                vltContext.Put("password", password);
                vltContext.Put("msg", "用户名或者密码错误");

                Template vltTemplate = vltEngine.GetTemplate("LogIn.html");
                System.IO.StringWriter vltWriter = new System.IO.StringWriter();
                vltTemplate.Merge(vltContext, vltWriter);

                string html = vltWriter.GetStringBuilder().ToString();
                context.Response.Write(html);
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
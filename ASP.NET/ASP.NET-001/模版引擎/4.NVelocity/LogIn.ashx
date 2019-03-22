<%@ WebHandler Language="C#" Class="LogIn" %>

using System;
using System.Web;
using NVelocity;
using NVelocity.Runtime;
using NVelocity.App;


public class LogIn : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //我们定义了一个Person类在这个项目的APP_Code文件夹中（这是VS默认的）
        Person p = new Person("shanzm", 24);

        //定义一个字典
     //Dictionary<string, string> dic = new Dictionary<string, string>();

        context.Response.ContentType = "text/html";
        VelocityEngine vltEngine = new VelocityEngine();
        vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
        vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("~/模版引擎/4.NVelocity/templates"));//模板文件所在的文件夹
        vltEngine.Init();

        VelocityContext vltContext = new VelocityContext();

        //在模板页其实我们需要的数据是Person.Name,但是我们只需要把Person替换，之后在模板页Person.Name 会自动识别
        //这其实是非常方便的，因为我们只要把一个对象给页面，页面想要这个对象的任何属性都是可以的。
        vltContext.Put("Person", p);
        vltContext.Put("Person", p);
        Template vltTemplate = vltEngine.GetTemplate("LogIn.html");
        System.IO.StringWriter vltWriter = new System.IO.StringWriter();
        vltTemplate.Merge(vltContext, vltWriter);

        string html = vltWriter.GetStringBuilder().ToString();
        context.Response.Write(html);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
<%@ WebHandler Language="C#" Class="LogIn" %>

using System;
using System.Web;
using NVelocity;
using NVelocity.Runtime;
using NVelocity.App;
using System.Collections.Generic;

///注意一些页面的头部模块，尾部模块或是其他的一些模块，我们一般是不用修改样式的，
///所以哦我们可以把他们的html代码单独写成一个html文件，我们在页面的主html页面使用
///#include（"html页面名")来调用
///但是若是模块的html文件中也有ashx页面中替换的变量，那么我们可以使用
///#parse（"html页面名")来调用

public class LogIn : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {

        Person p = new Person("shanzm", 24);




        context.Response.ContentType = "text/html";
        VelocityEngine vltEngine = new VelocityEngine();
        vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
        vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("~/模版引擎/5.NVelocity/templates"));//模板文件所在的文件夹
        vltEngine.Init();

        VelocityContext vltContext = new VelocityContext();


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
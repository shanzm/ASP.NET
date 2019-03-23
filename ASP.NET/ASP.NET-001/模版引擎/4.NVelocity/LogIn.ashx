<%@ WebHandler Language="C#" Class="LogIn" %>

using System;
using System.Web;
using NVelocity;
using NVelocity.Runtime;
using NVelocity.App;
using System.Collections.Generic;


public class LogIn : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //1.NVelocity之输出对象的属性
        //我们定义了一个Person类在这个项目的APP_Code文件夹中（这是VS默认的）
        Person p = new Person("shanzm", 24);

        //2.NVelocity之索引集合
        //定义一个字典
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic["a"] = "张三";
        dic["b"] = "李四";
        dic["c"] = "王五";
        ///dic["123"]="周六";这里有一个注意的地方：你在html页面$ Dictionary.123是得不到“周六”的，这里你把123定义为字符串，但是在html页面他是一个数字


        //3.NVelocity之遍历数组和集合
        //定义一个数组
        string[] strArray = new string[] { "小明", "小亮", "小红" };
        //定义一个泛型集合
        List<Person> personList = new List<Person>() { new Person("阿猫", 10), new Person("阿狗", 20) };

        //if逻辑判断



        context.Response.ContentType = "text/html";
        VelocityEngine vltEngine = new VelocityEngine();
        vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
        vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("~/模版引擎/4.NVelocity/templates"));//模板文件所在的文件夹
        vltEngine.Init();

        VelocityContext vltContext = new VelocityContext();

        //在模板页其实我们需要的数据是Person.Name,但是我们只需要把Person替换，之后在模板页Person.Name 会自动识别
        //这其实是非常方便的，因为我们只要把一个对象给页面，页面想要这个对象的任何属性都是可以的。
        vltContext.Put("Person", p);
  
        vltContext.Put("Dictionary", dic);
        vltContext.Put("Array", strArray);
        vltContext.Put("List", personList);


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
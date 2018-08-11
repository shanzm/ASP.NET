<%@ WebHandler Language="C#" Class="Show" %>

using System;
using System.Web;
using System.IO;
public class Show : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
       // context.Response.Write("Hello World");
        //获取要操作的模板物理路径
        //注意在asp.net中对文件和文件夹进行操作一定要获取物理路径
        string filePath = context.Request.MapPath("ShowInfo.html");
        //读取模板文件内容
        string filecontent= File.ReadAllText(filePath);
        //用具体的数据替换模板中的占位符
        filecontent = filecontent.Replace("$name", "张三").Replace("$password", "123456");
        //将替换后的内容输出给浏览器
        context.Response.Write(filecontent);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
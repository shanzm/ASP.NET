<%@ WebHandler Language="C#" Class="ShowAdd" %>

using System;
using System.Web;

public class ShowAdd : IHttpHandler {
          
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        string filePath = context.Request.MapPath("Add.html");//获取模板文件的路径
        string fileContent = System.IO.File.ReadAllText(filePath);//读取模板文件，
        context.Response.Write(fileContent);//把模板文件Add.html内容打印出来
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
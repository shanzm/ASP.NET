<%@ WebHandler Language="C#" Class="selfAddInfo" %>

using System;
using System.Web;

public class selfAddInfo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
         
        string filePath = context.Request.MapPath("selfAdd.htm");
        string fileContent = System.IO.File.ReadAllText(filePath);

        int num = Convert.ToInt32(context.Request.Form["record"]);
        num++;
        fileContent = fileContent.Replace("$num", num.ToString());
        context.Response.Write(fileContent);




    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
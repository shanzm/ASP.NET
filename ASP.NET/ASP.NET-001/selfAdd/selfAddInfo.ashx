<%@ WebHandler Language="C#" Class="selfAddInfo" %>

using System;
using System.Web;

public class selfAddInfo : IHttpHandler
{
    //http协议具有无状态性，第二次无法获取第一次请求的处理结果（后续请求无法获取之前请求的计算结果）
    // int num = 0;

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";

        string filePath = context.Request.MapPath("selfAdd.htm");
        string fileContent = System.IO.File.ReadAllText(filePath);
        //注意第一次运行的时候，txtName文本框中是没有值的，是NUll，使用convert.toint强转为0 ，
        //然后使用num++, 所以显示的是1；
        int num =Convert.ToInt32 (context .Request .Form ["txtNum"]);
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
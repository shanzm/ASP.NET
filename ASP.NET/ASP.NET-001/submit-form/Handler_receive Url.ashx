<%@ WebHandler Language="C#" Class="Handler_receive_Url" %>

using System;
using System.Web;

public class Handler_receive_Url : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string txtName = context.Request["txtName"];
        string txtPwd = context.Request["txtPwd"];
        context.Response.Write(txtName+txtPwd);

        ///运行这个页面在浏览器中：在URL后面直接输入:?txtName=shanzm&txtPwd=123

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
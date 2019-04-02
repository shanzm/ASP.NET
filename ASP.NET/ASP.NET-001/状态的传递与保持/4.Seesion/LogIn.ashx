<%@ WebHandler Language="C#" Class="LogIn" %>

using System;
using System.Web;
using System.Web.SessionState;

public class LogIn : IHttpHandler, IRequiresSessionState//ashx要操作Session必须实现IRequiresSessionState接口(命名空间using System.Web.SessionState;）
{
    ///Seesion本质：Seesion是基于Cookie的，其实就是自动生成一个唯一标识符ASP.NET_SessionId放在了Cookies，
    ///客户端根据ASP.NET_SessionId来在服务器的Seesion中读取相应的value
    ///
    ///也有人就要问了，ASP.NET_SessionId放在cookie中，用户可以修改他，在到服务器读取其他ASP.NET_SessionId的value，
    ///但是你要知道：ASP.NET_SessionId是随机生成的唯一值，是没有规律的，你修改是没有概率改为其他的合法的ASP.NET_SessionId

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string login = context.Request["login"];
        if (string.IsNullOrEmpty(login))
        {
            ///记住了调试的时候先清空一下浏览器的Cookies
            if (context.Session["UserName"] == null)
            {
                context.Response.Write(NVelocityHelper2.RenderHtml2("Login.html", new { UserName = "", Pwd = "" }));
            }
            else
            {
                string username = context.Session["UserName"].ToString();
                context.Response.Write(NVelocityHelper2.RenderHtml2("Login.html", new { UserName = username, Pwd = "" }));
            }


        }
        else
        {
            string username = context.Request["Username"];
            string pwd = context.Request["Pwd"];
            if (pwd == "admin" && username == "admin")
            {
                context.Session["UserName"] = username;

                context.Response.Write("登录成功！");
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
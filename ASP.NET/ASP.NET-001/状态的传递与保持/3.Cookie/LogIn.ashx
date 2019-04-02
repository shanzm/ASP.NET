<%@ WebHandler Language="C#" Class="LogIn" %>

using System;
using System.Web;

public class LogIn : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        //实现记住用户名
        if (!string.IsNullOrEmpty(context.Request["LogIn"]))
        {
            //点击了登录按钮，登录
            string username = context.Request["UserName"];
            string pwd = context.Request["Pwd"];
            HttpCookie CookieUserName = new HttpCookie("UserName", username);
            CookieUserName.Expires = DateTime.Now.AddDays(7);
            context.Response.SetCookie(CookieUserName);

            if (username=="admin"&&pwd=="admin")
            {
                context.Response.Write("登录成功！");
            }
            else
            {
                context.Response.Write("密码或用户名错误！");
            }
           
        }
        else
        {
            //显示页面
            HttpCookie username = context.Request.Cookies["UserName"];//注意若是Cookies中没有UserName,则接受到的uersname=null
            if (!(username==null) )//如果Cookie中有username则在显示页面的时候默认显示出来
            {
                context.Response.Write(NVelocityHelper.RenderHtml("LogIn.html", new { UserName = username.Value, Pwd = "" }));
            }
            else
            {
                context.Response.Write(NVelocityHelper.RenderHtml("LogIn.html", new { UserName = "", Pwd = "" }));
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
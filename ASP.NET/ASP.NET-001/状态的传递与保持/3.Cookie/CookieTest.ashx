<%@ WebHandler Language="C#" Class="CookieTest" %>

using System;
using System.Web;

public class CookieTest : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";

        if (!string.IsNullOrEmpty(context.Request["read"]))
        {
            HttpCookie cookie = context.Request.Cookies["Age"];
            string value = cookie.Value;
            var data = new { Value = value };
            context.Response.Write(NVelocityHelper.RenderHtml("CookieTest.html", data));
        }
        else if (!string.IsNullOrEmpty(context.Request["write"]))
        {
            HttpCookie cookieAge = new HttpCookie("Age", "25");//定义一个HttpCookie对象
            cookieAge.Expires = DateTime.Now.AddDays(1);//设置一个cookie的有效期，即一天之后清除cookie
            context.Response.SetCookie(cookieAge);
            string html = NVelocityHelper.RenderHtml("CookieTest.html", null);
            context.Response.Write(html);
        }
        else
        {
            context.Response.Write(NVelocityHelper.RenderHtml("CookieTest.html", null));
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
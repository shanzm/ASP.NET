<%@ WebHandler Language="C#" Class="LogIn" %>

using System;
using System.Web;

public class LogIn : IHttpHandler
{

    ///注意我们想把登录功能的ashx页面和html页面放在一起
    ///所以我们把表单html在ashx页面输出
    ///同时注意表单的action属性值又指向自己LogIn.ashx

    ///注意到了我们要是想要修改页面格式就要多次修改html字符串
    ///那么我们为何单独把html拿出来呢？---见2.Show-table



    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string html = @"<html>
                        <head></head>
                        <body>
                        <strong><font color='red'>登录</font></strong>
                        <form action='Login.ashx'>
                        <input type='text' name='username' value='{username}'/>
                        <input type='password' name='password' value='{password}' />
                        <input type='submit' value='登录'/>
                        </form>
                        <p>{msg}</p>
                        </body>
                        </html>";

        string username = context.Request["username"];
        string pwd = context.Request["password"];


        if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(pwd))
        {
            string code = html.Replace("{username}", "");
            code = code.Replace("{password}", "");
            code = code.Replace("{msg}", "");
            context.Response.Write(code);
        }
        else
        {
            if (username == "admin" && pwd == "admin")
            {
                context.Response.Write("你好，欢迎回来！");
            }
            else
            {
                string code = html.Replace("{username}", " ");
                code = code.Replace("{password}", "");
                code = code.Replace("{msg}", "密码或用户名错误,请重新输入！");
                context.Response.Write(code);
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
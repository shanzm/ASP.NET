<%@ WebHandler Language="C#" Class="AddInfo" %>

using System;
using System.Web;

public class AddInfo : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        ///这种方式只能接收get发送的数据
        //string userName = context.Request.QueryString["txtName"];
        //string userPwd = context.Request.QueryString["txtPwd"];


        ///这种方式只能接收post发送的数据
        string userName = context.Request.Form["txtName"];//或者：context.Request["txtName"]
        string userPwd = context.Request.Form["txtPwd"];//或者: context.Request["txtPwd"]

        string isVip = context.Request["isVip"];//注意checkbox的值在post请求的情况下只能这样接收，注意和其他的表单元素区分


        context.Response.Write("用户名：" + userName + ",密码：" + userPwd);

        if (isVip=="on")
        {
            context.Response.Write("你是VIP");
        }
        else
        {
            context.Response.Redirect ("http://www.baidu.com");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}
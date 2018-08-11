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
        string userName = context.Request.Form["txtName"];
        string userPwd = context.Request.Form["txtPwd"];
        
        
        
        context.Response.Write("用户名：" + userName + ",密码：" + userPwd);
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
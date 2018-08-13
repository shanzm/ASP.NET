<%@ WebHandler Language="C#" Class="AddUser" %>

using System;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class AddUser : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        //1.接受表单数据
        string userName = context.Request.Form["txtName"];
        string userPwd = context.Request.Form["txtPwd"];
        string userType = context.Request.Form["txtType"];

        //2.连接数据库，构建相应的sql语句，并执行sql语句
        string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "insert into ManagerInfo (MName,MPwd,MType) values (@MName,@MPwd,@MType)";
                SqlParameter[] param ={
                                      //注意这里我们也可以像以前的那样直接给sqlParameter赋值，但是我们先要给参数设置类型，所以就按照下面的写法
                                      //new SqlParameter（"@MName",userName）
                                       new SqlParameter ("@MName",SqlDbType .NVarChar ,32),
                                       new SqlParameter ("@MPwd",SqlDbType .NVarChar ,32),
                                       new SqlParameter ("@MType",SqlDbType .SmallInt )   
                                      };
                param[0].Value = userName;
                param[1].Value = userPwd;
                param[2].Value = Convert.ToInt16(userType);
                cmd.Parameters.AddRange(param);
                conn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    //如果插入成功则我们想要把插入的数据显示出来
                    //注意这是我们首次使用跳转
                    //这里的页面跳转的方式其实就是想UserInfoList页面发送了一个GET请求
                    context.Response.Redirect("UserInfoList.ashx");
                }
                else
                {
                    //context.Response.Redirect("Error.html");
                    context.Response.Write("ddd");
                }
	{
		 
	}
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
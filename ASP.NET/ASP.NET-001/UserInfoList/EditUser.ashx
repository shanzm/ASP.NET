<%@ WebHandler Language="C#" Class="EditUser" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class EditUser : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
 //获取表单中的修改值
        string MName = context.Request.Form["txtName"];
        string MPwd = context.Request.Form["txtPwd"];
        string MType = context.Request.Form["txtType"];
        int id = Convert.ToInt32(context.Request.Form["txtId"]);

        string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        using (SqlConnection conn=new SqlConnection (connStr ))
        {
            using (SqlCommand cmd=new SqlCommand ())
            {
                cmd.Connection = conn;
                //注意这里的id是在怎么来的，一开始在在ShowEdit.html页面中的表单中添加了一个隐藏域,在ShowEdit.ashx读取模板ShowEdit.html时把id替换的来的
                cmd.CommandText = "update ManagerInfo set MName=@MName,MPwd=@MPwd,MType=@MType where MId=@id";

                SqlParameter[] param ={
                                       new SqlParameter ("@MName",MName),
                                       new SqlParameter ("@MPwd",MPwd),
                                       new SqlParameter ("@MType",MType ),
                                       new SqlParameter ("@id",id)
                                      };
                cmd.Parameters.AddRange(param);
                conn.Open();
                if (cmd.ExecuteNonQuery ()>0)
                {
                    context.Response.Redirect("UserInfoList.ashx");
                }
                else
                {
                    context.Response.Write("error.html");
                }
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
<%@ WebHandler Language="C#" Class="DeleteUser" %>

using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public class DeleteUser : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        int id;
        if (int.TryParse (context.Request .QueryString ["id"],out id))
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection  conn=new SqlConnection (connStr ))
            {
                using (SqlCommand cmd=new SqlCommand ())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from ManagerInfo where MId=@id";
                    SqlParameter param = new SqlParameter("@id", id);
                    cmd.Parameters.Add(param);
                    conn.Open();
                    if (cmd.ExecuteNonQuery ()>0)
                    {
                        context.Response.Redirect("UserInfoList.ashx");
                        
                    }
                    else
                    {
                        context.Response.Write("删除失败");
                    }
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
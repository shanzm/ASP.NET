<%@ WebHandler Language="C#" Class="ShowDetail" %>

using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


public class ShowDetail : IHttpHandler
{

    public void ProcessRequest(HttpContext context) {
        context.Response.ContentType = "text/html";
        int id;
        //尝试将我们接收的id装换为数字，如果成功的话，返回一个true，并且把转换成功的后的值，赋值给第二个参数id
        if (int.TryParse (context.Request .QueryString ["id"],out id ))
        {
            //根据接收的id查询数据表中的相应的记录
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection  conn=new SqlConnection (connStr ))
            {
                string sql="select * from ManagerInfo where MId=@id";
                using (SqlDataAdapter adater=new SqlDataAdapter (sql,conn ))
                {
                    SqlParameter param = new SqlParameter("@id", id);
                    adater.SelectCommand.Parameters.Add(param);

                    DataTable da = new DataTable();
                    adater.Fill(da);

                    if (da.Rows.Count >0)
                    {
                        string filePath=context .Request .MapPath ("ShowUserDetail.html");
                        string fileContent=System.IO.File.ReadAllText (filePath );
                        fileContent =fileContent .Replace ("$MName",da.Rows[0]["MName"].ToString ()).Replace ("$MPwd",da.Rows[0]["MPwd"].ToString ());//注意使用了两个replace，这就是链式编程
                        context .Response .Write (fileContent );

                    }
                    else
                    {
                        context.Response.Write("查无此人");
                    }
                }
            }
        }
        else
        {
            context.Response.Write("参数错误");
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
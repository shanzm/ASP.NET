<%@ WebHandler Language="C#" Class="ShowEdit" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class ShowEdit : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";

        int id;//注意这个id就是要修改的那行数据的id，注意是通过get的方式获取的，所以使用context.Request.QueryString["id"]来获取id的值
        if (int.TryParse(context.Request.QueryString["id"], out id))
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr ))
            {
                string sql = "select * from ManagerInfo where Mid=@id";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    SqlParameter param = new SqlParameter("@id", id);
                    adapter.SelectCommand.Parameters.Add(param);
                    DataTable da = new DataTable();
                    adapter.Fill(da);
                    if (da.Rows.Count > 0)
                    {
                        string filePath = context.Request.MapPath("ShowEdit.html");
                        string fileContent = System.IO.File.ReadAllText(filePath);

                        fileContent =
                            fileContent.Replace("$MName", da.Rows[0]["MName"].ToString())
                            .Replace("$MPwd", da.Rows[0]["MPwd"].ToString())
                            .Replace("$MType", da.Rows[0]["MType"].ToString())
                            .Replace("$id", id.ToString ());//注意替换隐藏域的值

                        context.Response.Write(fileContent);
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
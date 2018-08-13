<%@ WebHandler Language="C#" Class="UserInfoList" %>

using System;
using System.Web;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

public class UserInfoList : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        { 
            string sql = "select * from ManagerInfo";
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
            {

                DataTable da = new DataTable();
                adapter.Fill(da);
                if (da.Rows.Count > 0)
                {

                    StringBuilder sb = new StringBuilder();
                    foreach (DataRow row in da.Rows)
                    {
                        sb.AppendFormat(@" <tr>
                                           <th>{0}</th>
                                           <th>{1}</th>
                                           <th>{2}</th>
                                           <th>{3}</th>
                                           <th><a href='ShowDetail.ashx?id={0}'>详细</a></th>
                                           <th><a href='DeleteUser.ashx?id={0}' class='detele'>删除</a></th>
                                           <th><a href ='ShowEdit.ashx?id={0}'>编辑</a></th>
                                           </tr>",
                            row["MId"].ToString(),
                            row["MName"].ToString(),
                            row["MPwd"].ToString(),
                            row["MType"].ToString()
                            );
                    }

                    string filePath = context.Request.MapPath("UserInfoList.html");
                    string fileContent = System.IO.File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("@tbody", sb.ToString());
                    context.Response.Write(fileContent);
                }
                else
                {
                    context.Response.Write("暂无数据");
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
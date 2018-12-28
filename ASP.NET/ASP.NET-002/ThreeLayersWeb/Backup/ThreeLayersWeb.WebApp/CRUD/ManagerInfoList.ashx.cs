using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeLayerWeb.BLL;
using ThreeLayersWeb.Model;
using System.Text;
using System.IO;

namespace ThreeLayersWeb.WebApp
{
    /// <summary>
    /// ManagerInfoList 的摘要说明
    /// </summary>
    public class ManagerInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            ManagerInfoBLL miBLL = new ManagerInfoBLL();
            List<ManagerInfo> list = miBLL.GetList();
            StringBuilder sb = new StringBuilder();
            foreach (ManagerInfo managerInfo in list)
            {
                sb.AppendFormat(@"<tr>
                                  <td>{0}</td>
                                  <td>{1}</td>
                                  <td>{2}</td>
                                  <td>{3}</td>
                                  <td><a href='DeleteManagerInfo.ashx?id={0}' class='delete'>删除</a></td>
                                  <td><a href='ShowDetail.ashx?id={0}'>详细</a></td>
                                  <td><a href='ShowEditManagerInfo.ashx?id={0}'>编辑</a></td>
                                  </tr>",
                                  managerInfo.MId,
                                  managerInfo.MName,
                                  managerInfo.MPwd,
                                  managerInfo.MType
                              );
            }

            string filePath = context.Request.MapPath("ManagerInfoList.html");
            string fileContent = File.ReadAllText(filePath);
            fileContent = fileContent.Replace("@tbody", sb.ToString());
            context.Response.Write(fileContent);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
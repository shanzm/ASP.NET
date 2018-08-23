using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeLayersWeb.Model;
using ThreeLayerWeb.BLL;
using System.IO;

namespace ThreeLayersWeb.WebApp
{
    /// <summary>
    /// EditManagerInfo 的摘要说明
    /// </summary>
    public class EditManagerInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                ManagerInfoBLL miBLL = new ManagerInfoBLL();
                ManagerInfo managerInfo = miBLL.GetManagerInfo(id);
                if (managerInfo != null)
                {
                    string filePath = context.Request.MapPath("ShowEditManagerInfo.html");
                    string fileContent = File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("$MName", managerInfo.MName)
                        .Replace("$MPwd", managerInfo.MPwd)
                        .Replace("$MType", managerInfo.MType.ToString())
                        .Replace("$id", managerInfo.MId.ToString ());

                    context.Response.Write(fileContent);
                }
                else
                {
                    context.Response.Write("查无此人");
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
}
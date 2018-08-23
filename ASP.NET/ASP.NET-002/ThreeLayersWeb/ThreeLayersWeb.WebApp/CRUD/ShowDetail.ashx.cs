using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeLayerWeb.BLL;
using ThreeLayersWeb.Model;
using System.IO;

namespace ThreeLayersWeb.WebApp
{
    /// <summary>
    /// ShowDetail 的摘要说明
    /// </summary>
    public class ShowDetail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                ManagerInfoBLL miBLl = new ManagerInfoBLL();
                ManagerInfo managerInfo = miBLl.GetManagerInfo(id);
                if (managerInfo !=null )
                {
                    string filePath = context.Request.MapPath("ShowDetail.html");
                    string fileContent = File.ReadAllText(filePath);
                    fileContent = fileContent.Replace("$MName", managerInfo.MName)
                        .Replace("$MId", managerInfo.MId.ToString ())
                        .Replace("$MPwd", managerInfo.MPwd)
                        .Replace("$MType", managerInfo.MType.ToString ());
                    context.Response.Write(fileContent);
                }
                else
                {
                    context.Response.Redirect("Error.html");
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
}
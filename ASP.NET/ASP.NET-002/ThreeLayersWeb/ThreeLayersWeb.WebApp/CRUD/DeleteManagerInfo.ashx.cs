using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeLayerWeb.BLL;

namespace ThreeLayersWeb.WebApp
{
    /// <summary>
    /// DeleteManagerInfo 的摘要说明
    /// </summary>
    public class DeleteManagerInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int id;
            if (int.TryParse(context.Request.QueryString["id"], out id))
            {
                ManagerInfoBLL miBLL = new ManagerInfoBLL();
                if (miBLL.DeleteManagerInfo(id))
                {
                    context.Response.Redirect("ManagerInfoList.ashx");
                }
                else
                {
                    context.Response.Redirect("Error.html");
                }
            }
            else
            {
                context.Response.Redirect("参数错误");
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
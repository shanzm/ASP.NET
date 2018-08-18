using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeLayersWeb.Model;
using ThreeLayerWeb.BLL;

namespace ThreeLayersWeb.WebApp
{
    /// <summary>
    /// AddUser 的摘要说明
    /// </summary>
    public class AddUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string txtName = context.Request.Form["txtName"];
            int txtType = Convert.ToInt32(context.Request.Form["txtType"]);
            string txtPwd = context.Request.Form["txtPwd"];

            ManagerInfo managerInfo = new ManagerInfo()
            {
                MName = txtName,
                MType = txtType,
                MPwd = txtPwd
            };

            ManagerInfoBLL miBLl = new ManagerInfoBLL();
            if (miBLl.AddManagerInfo(managerInfo))
            {
                //如果添加成功就返回到列表显示页面，显示一下新插入的数据
                context.Response.Redirect("ManagerInfoList.ashx");
            }
            else
            {
                context.Response.Write("Error.html");
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
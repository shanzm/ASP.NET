using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThreeLayersWeb.Model;
using ThreeLayerWeb.BLL;

namespace ThreeLayersWeb.WebApp
{
    /// <summary>
    /// EditManagerInfo1 的摘要说明
    /// </summary>
    public class EditManagerInfo1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //string txtName = context.Request.Form["txtName"];
            //string txtPwd = context.Request.Form["txtPwd"];
            //int txtType = Convert.ToInt32(context.Request.Form["txtType"]);

            ////注意接受隐藏域中的id
            //int id = Convert.ToInt32(context.Request.Form["txtid"]);


            //ManagerInfo managerInfo = new ManagerInfo()
            //{
            //    MName = txtName,
            //    MPwd = txtPwd,
            //    MType = txtType,
            //    MId = id
            //};

            ////接收表单数据直接实例化为对象
            //ManagerInfo managerInfo = new ManagerInfo()
            //{
            //    MName =context.Request.Form["txtName"],
            //    MPwd = context.Request.Form["txtPwd"],
            //    MType = Convert.ToInt32(context.Request.Form["txtType"]),
            //    MId = Convert.ToInt32(context.Request.Form["txtid"])
            //};
            ///注意上面这种方式也是有缺陷的
            ///如果你的表中有很多列，但这些列是没有展示在Form 中，
            ///所以你实例化这个对象时，有些列是没有赋值数据的
            ///但是在Dal层中，你使用sql语句更新是更新的所有列，
            ///所以这里我们先使用id查询出数据库表的数据对象（我们之前已经封装了这个函数）
            ///在使用表单中的数据进行修改，这样如果表单中没有那一列数据,或是没有修改则就是用依旧是原来的数据
            ///

            int id = Convert.ToInt32(context.Request.Form["txtid"]);
            ManagerInfoBLL miBLL = new ManagerInfoBLL();
            ManagerInfo managerInfo = miBLL.GetManagerInfo(id);

            managerInfo.MName = context.Request.Form["txtName"];
            managerInfo.MPwd = context.Request.Form["txtPwd"];
            managerInfo.MType = Convert.ToInt32(context.Request.Form["txtType"]);


            if (miBLL.EditManagerInfo(managerInfo))
            {
                context.Response.Redirect("ManagerInfoList.ashx");
            }
            else
            {
                context.Response.Redirect("Error.html");
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
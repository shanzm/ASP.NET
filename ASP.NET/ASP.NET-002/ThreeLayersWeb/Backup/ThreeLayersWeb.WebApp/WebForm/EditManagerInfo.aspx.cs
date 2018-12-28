using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeLayerWeb.BLL;
using ThreeLayersWeb.Model;

namespace ThreeLayersWeb.WebApp.WebForm
{
    public partial class EditManagerInfo : System.Web.UI.Page
    {
        //注意我们一般是怎么把aspx.cs 页面查询到的数据传输到aspx页面的
        //因为aspx.cs 是aspx的父类，所以我们只要在aspx.cs 定义一个属性，在aspx页面继承就可以了

        public ManagerInfo managerInfo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //注意进入EditManagerInfo.aspx页面有get请求的方式（主页面点击"编辑"）和post请求（EditManagerInfo.aspx页面的提交按钮）
            //所以根据不同的请求方式，做不同的操作
            if (!IsPostBack)//get请求
            {
                ShowEditManagerInfo();
            }
            else//post请求
            {
                UpdateManagerInfo();
            }

        }

        /// <summary>
        /// 更新修改的数据
        /// </summary>
        private void UpdateManagerInfo()
        {
            ManagerInfo managerInfo = new ManagerInfo()
            {
                MId = Convert.ToInt16(Request.Form["txtId"]),
                MName = Request.Form["txtName"],
                MPwd = Request.Form["txtPwd"],
                MType = Convert.ToInt32(Request.Form["txtType"])
            };

            ManagerInfoBLL miBLL = new ManagerInfoBLL();
            if (miBLL.AddManagerInfo(managerInfo))
            {
                Response.Redirect("ManagerInfoList3.aspx");
            }
            else
            {
                Response.Redirect("../CRUD/Error.html");
            }
        }

        /// <summary>
        /// 展示要修改的用户的信息
        /// </summary>
        private void ShowEditManagerInfo()
        {
            int id;
            if (int.TryParse(Request.QueryString["id"], out id))
            {
                ManagerInfoBLL miBLL = new ManagerInfoBLL();
                if (miBLL.GetManagerInfo(id) != null)//一定要做这个判断
                {
                    managerInfo = miBLL.GetManagerInfo(id);
                }
                else
                {
                    Response.Write("编辑对象id错误！");
                }
            }
            else
            {
                Response.Redirect("../CRUD/Error.html");
            }

        }
    }
}
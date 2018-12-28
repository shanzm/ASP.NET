using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeLayersWeb.Model;
using ThreeLayerWeb.BLL;

namespace ThreeLayersWeb.WebApp.WebForm
{
    public partial class AddManagerInfo3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //注意因为进入AddManagerInfo3.aspx页面有可能是get请求，也有可能是post请求(见AddManagerInfo3.aspx中说明)
            //所以这里要做判断，我们在表单中添加一个隐藏域来做判断
            //隐藏域的值随便写一点就可以，我们通过是否为空来进行判断
            //隐藏域不为空，也就是用户点击了submit按钮，发出了post请求
            /// if (!string.IsNullOrEmpty(Request.Form["isPost"]))
            //注意这里和一般处理程序中的写法不一样，我们省略了context.
            //因为这里继承于Page类，对context进行了进一步的封装

            // 注意啊Page类中有一个IsPostBack属性来判断是否为post请求，是post请求则值为true
            //但是使用这个属性的前提是AddManagerInfo3.aspx.cs中的表单属性中的runat="server"没有被你删除
            //因为IsPostBack属性就是根据由runat="server"自动生成的_ _VIEWSTATE隐藏域进行判断的
            //所以我们一开始自己在表单中写的隐藏域isPost就没有必要了，就可以不写了
            if (IsPostBack)
            {
                InsertManagerInfo();
            }
        }

        private void InsertManagerInfo()
        {
            ManagerInfo managerInfo = new ManagerInfo()
            {
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
    }
}
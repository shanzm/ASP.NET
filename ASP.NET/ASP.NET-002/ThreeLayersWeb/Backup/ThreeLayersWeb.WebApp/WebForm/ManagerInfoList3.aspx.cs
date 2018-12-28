using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeLayerWeb.BLL;
using ThreeLayersWeb.Model;

//与ManagerInfoList2.aspx不一样的就是
//当我们在aspx.cs 文件中读取到数据库的数据之后，我们直接定义一个List属性
//之后我们在aspx文件中继承这个List属性，然后在aspx文件中进行遍历输出为一个table样式



namespace ThreeLayersWeb.WebApp.WebForm
{
    public partial class ManagerInfoList3 : System.Web.UI.Page
    {
        public List<ManagerInfo> managerInfoList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ManagerInfoBLL miBLL = new ManagerInfoBLL();
            managerInfoList = miBLL.GetList();

        }
    }
}
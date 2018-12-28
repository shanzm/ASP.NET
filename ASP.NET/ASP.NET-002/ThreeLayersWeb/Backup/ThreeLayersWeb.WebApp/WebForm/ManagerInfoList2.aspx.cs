using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeLayerWeb.BLL;
using ThreeLayersWeb.Model;
using System.Text;

//注意之前我们一直是使用html页面配合 ashx页面来创建网页
//使用html页面做模板，使用占位符代替一些需要从数据库读取的数据
//使用ashx页面来读取模板，替换掉占位符，在返回给浏览器，渲染成网页

//但是有许多时候，我们的的html页面很复杂，有许多数据要展示，那没就会使用很多占位符
//这样编写就十分的麻烦了

//所以我们开始使用Web窗体，我们右键添加新项-Web窗体
//一个Web窗体有三个文件，aspx文件是写html代码，也可以写c#代码，但是要写在<% %> 之中
//aspx文件是继承于aspx.cs 文件的，我们主要是在aspx.cs 文件中查询数据


/*整个运行的原理
 *首先用户在浏览器地址栏中输入aspx文件，发送一个报文到服务器，服务器把请求转交给IIS
 *IIS判断是一个aspx文件，也就是一个动态页面，它执行不了，
 *所以由asp.net_isapi.dll 转交给.net Framework ,.net Framework执行服务端的这些代码
 *.net Framework首先执行aspx文件的父类aspx.cs 文件，之后再执行aspx文件中的服务端代码（也就是<% %>中的C#代码）
 *C#代码都执行完之后，就生成了完整的html代码，再把html代码返回到服务器，由服务器返回给浏览器
 *浏览器渲染html代码称为显示的网页
 */


namespace ThreeLayersWeb.WebApp
{
    public partial class ManagerInfoList2 : System.Web.UI.Page
    {
        public string strTable { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
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
                                  </tr>",
                                  managerInfo.MId,
                                  managerInfo.MName,
                                  managerInfo.MPwd,
                                  managerInfo.MType
                                  );
            }
            strTable = sb.ToString();
        }
    }
}
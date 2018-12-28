using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeLayerWeb.BLL;
using ThreeLayersWeb.Model;
using System.Text;

namespace ThreeLayersWeb.WebApp.WebDemos
{
    public partial class NewsList : System.Web.UI.Page
    {
        public string strHtml { get; set; }
        public int PageIndex { get; set; }
        public int PageCount{ get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = 5;//每页显示10条数据
            int pageIndex;
            ///注意这里其实我们一打开这个页面，的地址是http://localhost:46009/WebDemos/NewsList.aspx
            ///也就是没有使用get请求传递一个pageIndex，所以是接收不到pageIndex的
            ///但是这个页面的最下面有“下页”“上页”这两个超链接，所以这两个的超链接的地址就要加上一个参数pageIndex+1
            if (!int.TryParse(Request.QueryString["pageIndex"], out pageIndex))
            {
                ///当浏览器的地址栏是http://localhost:46009/WebDemos/NewsList.aspx
                ///我们就设置pageIndex默认是1
                pageIndex = 1;
            }
            ManagerInfoBLL miBLL = new ManagerInfoBLL();

            //获取总页数
            int pageCount=miBLL .GetPageCount (pageSize);
            //对页数进行判断，防止越界
            pageIndex =pageIndex <1?1:pageIndex ;
            pageIndex =pageIndex >pageCount ?pageCount :pageIndex ;
            PageIndex = pageIndex;
            PageCount = pageCount;
            List<ManagerInfo> list = miBLL.GetPageList(pageIndex, pageSize);
            StringBuilder sb = new StringBuilder();
            foreach (ManagerInfo managerInfo in list)
            {
                sb.AppendFormat("<li><span>{0}</span><a href='#' target='_top'>{1}</a></li>", managerInfo.MPwd, managerInfo.MName);
            }
            strHtml = sb.ToString();
        }
    }
}
#region
// ===============================================================================
// Project Name        :    ThreeLayersWeb.Common
// Project Description : 
// ===============================================================================
// Class Name          :    PageBarHelper
// Class Version       :    v1.0.0.0
// Class Description   : 
// CLR                 :    4.0.30319.18408  
// Author              :    单志铭(shanzm)
// Create Time         :    2018-8-26 00:08:49
// Update Time         :    2018-8-26 00:08:49
// ===============================================================================
// Copyright © SHANZM-PC  2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeLayersWeb.Common
{
    public class PageBarHelper
    {
        //返回网页下面的页码列表，让当前页面的页码没有超链接，其他页面的页面超链接到该页面
        public static string GetPageBar(int pageIndex, int pageCount)
        {
            if (pageCount == 1)
            {
                return string.Empty;
            }
            int start = pageIndex - 5;//计算页码表的起始位置，要求显示10个数字的页码，当前页面的页码在中间
            if (start < 1)
            {
                start = 1;
            }
            int end = start + 9;
            if (end>pageCount)
            {
                end = pageCount;
                //重新计算一下start(如果不重新计算start，有可能最后显示的页码不到10个)
                start = end - 9 < 1 ? 1 : end - 9;
            }
            StringBuilder sb = new StringBuilder();
            if (pageIndex > 1)//如果没有首页的号码，则在页码表最前面显示"上一页"按钮
            {
                sb.AppendFormat ("<a href='NewsList.aspx?pageIndex={0}'>上一页</a>",pageIndex -1);
            }
            for (int i = start ; i <= end; i++)
            {
                //if (i==pageIndex )//当前页面的页码不需要加超链接，直接就一个数字就可以
                //{
                //    sb.Append(i);
                //}
                //else
                //{
                    sb.AppendFormat("<a href='NewsList.aspx?pageIndex={0}'>{0}</a>",i );
                //}
            }

            if (pageIndex <pageCount )//如果没有尾页的号码，则在页码表最后显示"下一页"按钮
            {
                sb.AppendFormat("<a href='NewsList.aspx?pageIndex={0}'>下一页</a>", pageIndex + 1);
            }
            return sb.ToString();
        }
    }
}

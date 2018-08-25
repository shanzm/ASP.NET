#region
// ===============================================================================
// Project Name        :    ThreeLayerWeb.Bll
// Project Description : 
// ===============================================================================
// Class Name          :    ManagerInfoBLL
// Class Version       :    v1.0.0.0
// Class Description   : 
// CLR                 :    4.0.30319.18408  
// Author              :    单志铭(shanzm)
// Create Time         :    2018-8-15 00:42:45
// Update Time         :    2018-8-15 00:42:45
// ===============================================================================
// Copyright © SHANZM-PC  2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreeLayersWeb.Model;
using ThreeLayersWeb.DAL;

namespace ThreeLayerWeb.BLL
{
    public class ManagerInfoBLL
    {
        ManagerInfoDAL miDal = new ManagerInfoDAL();
        //返回用户信息列表
        public List<ManagerInfo> GetList()
        {
            return miDal.GetList();
        }


        //注意这个范围应该是有业务逻辑层进行计算，也就是在这里进行计算
        //也就是由页数计算取值范围
        /// <summary>
        /// 返回指定范围的数据
        /// </summary>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">每页显示的行数</param>
        /// <returns></returns>
        public List<ManagerInfo> GetPageList(int PageIndex, int PageSize)
        {
            int start = (PageIndex - 1) * PageSize + 1;
            int end = PageIndex * PageSize;//start + PageSize - 1;

            return miDal.GetPageList(start, end);
        }

        //显示层要显示总页数，所以就要计算一下总页数
        //在这个业务逻辑层由数据库的总记录数计算总页数
        /// <summary>
        /// 返回总页数
        /// </summary>
        /// <param name="pageSize">每页显示的行数</param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = miDal.GetRecordCount();
            //Math.Ceiling()往上取整，返回值是双精度浮点数，所以哦我们在转化为int
            //同时注意，Math.Ceiling()的参数是double或decimal，所以哦我们要强转double
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount/pageSize));
            return pageCount;

        }


        //添加数据，返回添加的行数
        public bool AddManagerInfo(ManagerInfo managerInfo)
        {
            return miDal.AddManagerInfo(managerInfo) > 0;
        }


        //删除数据
        public bool DeleteManagerInfo(int id)
        {
            return miDal.DeleteManagerInfo(id) > 0;
        }

        //查询一个ManagerInfo对象
        public ManagerInfo GetManagerInfo(int id)
        {
            return miDal.GetManagerInfo(id);
        }

        //修改用户数据
        public bool EditManagerInfo(ManagerInfo managerInfo)
        {
            return miDal.EditManagerInfo(managerInfo) > 0;
        }
    }
}

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
            return miDal.EditManagerInfo(managerInfo)>0;
        }
    }
}

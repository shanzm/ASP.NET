#region
// ===============================================================================
// Project Name        :    ThreeLayersWeb.DAL
// Project Description : 
// ===============================================================================
// Class Name          :    ManagerInfoDAL
// Class Version       :    v1.0.0.0
// Class Description   : 
// CLR                 :    4.0.30319.18408  
// Author              :    单志铭(shanzm)
// Create Time         :    2018-8-15 00:06:06
// Update Time         :    2018-8-15 00:06:06
// ===============================================================================
// Copyright © SHANZM-PC  2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreeLayersWeb.Model;
using System.Data;
using System.Data.SqlClient;


namespace ThreeLayersWeb.DAL
{
    public class ManagerInfoDAL
    {
        /// <summary>
        /// 查询用户信息列表
        /// </summary>
        /// <returns>整个数据库表中的数据</returns>
        public List<ManagerInfo> GetList()
        {
            string sql = "select * from ManagerInfo";
            DataTable da = SqlHelper.GetDataTable(sql, CommandType.Text);

            List<ManagerInfo> list = null;
            if (da.Rows.Count > 0)
            {
                list = new List<ManagerInfo>();
                ManagerInfo managerInfo = null;
                foreach (DataRow row in da.Rows)
                {
                    managerInfo = new ManagerInfo();
                    LoadEntity(managerInfo, row);//注意这里我们把循环中的对象实例化，给封装了一个方法LoadEntity()
                    list.Add(managerInfo);
                }
            }
            return list;

        }


        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="managerInfo"></param>
        /// <returns>添加的数量</returns>
        public int AddManagerInfo(ManagerInfo managerInfo)
        {
            string sql = "insert into ManagerInfo (MName,MPwd,MType) values(@MName,@MPwd,@MType)";
            SqlParameter[] param ={
                                       new SqlParameter ("@MName",managerInfo.MName ),
                                       new SqlParameter ("@MPwd",managerInfo.MPwd ),
                                       new  SqlParameter ("@MType",managerInfo.MType )
                                  };
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, param);

        }



        //实例化ManagerInfo 对象
        private void LoadEntity(ManagerInfo managerInfo, DataRow row)
        {
            managerInfo.MId = Convert.ToInt32(row["MId"]);
            //注意啊数据库中的一些列是允许为空的，所以我们严谨的写法，为了抛异常，要对是否为空进行判断
            managerInfo.MName = row["MName"] != DBNull.Value ? row["MName"].ToString() : string.Empty;
            managerInfo.MPwd = row["MPwd"] != DBNull.Value ? row["MPwd"].ToString() : string.Empty;
            managerInfo.MType = Convert.ToInt32(row["MType"]);
        }


        /// <summary>
        /// 根据id删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>删除的数量</returns>
        public int DeleteManagerInfo(int id)
        {
            string sql = "delete from ManagerInfo where MId=@id ";
            SqlParameter param = new SqlParameter("@id", id);
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, param);

        }


        /// <summary>
        /// 根据数据id查询一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ManagerInfo对象</returns>
        public ManagerInfo GetManagerInfo(int id)
        {
            string sql = "select * from ManagerInfo where MId=@id";
            SqlParameter param = new SqlParameter("@id", id);
            DataTable da = SqlHelper.GetDataTable(sql, CommandType.Text, param);

            ManagerInfo managerInfo = null;
            if (da.Rows.Count > 0)
            {
                managerInfo = new ManagerInfo();
                LoadEntity(managerInfo, da.Rows[0]);
            }
            return managerInfo;
        }


        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="managerInfo"></param>
        /// <returns></returns>
        public int EditManagerInfo(ManagerInfo managerInfo)
        {
            string sql = "update ManagerInfo set MName=@MName,MPwd=@MPwd,MType=@MType where MId=@MId";
            SqlParameter[] param ={

                                     new SqlParameter ("@MName",managerInfo .MName ),
                                     new SqlParameter ("@MPwd",managerInfo .MPwd ),
                                     new SqlParameter ("@MType",managerInfo .MType ),
                                     new SqlParameter ("@MId",managerInfo .MId )
                                  };
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, param);

        }
    }
}

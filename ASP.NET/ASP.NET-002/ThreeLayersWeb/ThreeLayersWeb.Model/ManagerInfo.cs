#region
// ===============================================================================
// Project Name        :    ThreeLayersWeb.Model
// Project Description : 
// ===============================================================================
// Class Name          :    ManagerInfo
// Class Version       :    v1.0.0.0
// Class Description   : 
// CLR                 :    4.0.30319.18408  
// Author              :    单志铭(shanzm)
// Create Time         :    2018-8-14 18:18:29
// Update Time         :    2018-8-14 18:18:29
// ===============================================================================
// Copyright © SHANZM-PC  2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeLayersWeb.Model
{
    public partial class ManagerInfo
    {
        public int MId { get; set; }
        public string MName { get; set; }
        public int MType { get; set; }
        public string MPwd { get; set; }
    }
}

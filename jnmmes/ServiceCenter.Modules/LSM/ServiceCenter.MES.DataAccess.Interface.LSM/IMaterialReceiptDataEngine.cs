﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.Model.LSM;
using ServiceCenter.DataAccess;

namespace ServiceCenter.MES.DataAccess.Interface.LSM
{
    /// <summary>
    /// 定义领料数据访问接口。
    /// </summary>
    public interface IMaterialReceiptDataEngine
        : IDatabaseDataEngine<MaterialReceipt, string>
    {
    }
}

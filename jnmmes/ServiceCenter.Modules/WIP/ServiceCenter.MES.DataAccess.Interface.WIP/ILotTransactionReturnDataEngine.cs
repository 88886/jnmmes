﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.Model.WIP;
using ServiceCenter.DataAccess;
using ServiceCenter.Model;

namespace ServiceCenter.MES.DataAccess.Interface.WIP
{
    /// <summary>
    /// 批次退料数据访问接口。
    /// </summary>
    public interface ILotTransactionReturnDataEngine
        : IDatabaseDataEngine<LotTransactionReturn, LotTransactionReturnKey>
    {
    }
}
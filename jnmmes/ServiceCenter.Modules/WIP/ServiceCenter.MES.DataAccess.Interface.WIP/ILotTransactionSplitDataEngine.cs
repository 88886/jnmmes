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
    /// 批次拆分数据访问接口。
    /// </summary>
    public interface ILotTransactionSplitDataEngine
        : IDatabaseDataEngine<LotTransactionSplit, LotTransactionSplitKey>
    {
    }
}

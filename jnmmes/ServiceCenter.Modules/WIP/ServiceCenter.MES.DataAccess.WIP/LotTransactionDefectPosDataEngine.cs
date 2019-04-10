﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.Model.WIP;

using ServiceCenter.Model;
using ServiceCenter.MES.DataAccess.Interface.WIP;
using NHibernate;
using ServiceCenter.Common.DataAccess.NHibernate;

namespace ServiceCenter.MES.DataAccess.WIP
{
    /// <summary>
    /// 批次不良数据访问类。
    /// </summary>
    public class LotTransactionDefectPosDataEngine
        : DatabaseDataEngine<LotTransactionDefectPos, LotTransactionDefectPosKey>, ILotTransactionDefectPosDataEngine
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="sf"></param>
        public LotTransactionDefectPosDataEngine(ISessionFactory sf):base(sf)
        {
        }
    }
}

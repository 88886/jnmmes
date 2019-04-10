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
    /// 批次报废数据访问类。
    /// </summary>
    public class LotTransactionScrapDataEngine
        : DatabaseDataEngine<LotTransactionScrap, LotTransactionScrapKey>, ILotTransactionScrapDataEngine
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="sf"></param>
        public LotTransactionScrapDataEngine(ISessionFactory sf):base(sf)
        {
            this.SessionFactory = sf;
        }
    }
}

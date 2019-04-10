﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.Model.ZPVM;

using ServiceCenter.Model;
using ServiceCenter.MES.DataAccess.Interface.ZPVM;
using NHibernate;
using ServiceCenter.Common.DataAccess.NHibernate;

namespace ServiceCenter.MES.DataAccess.ZPVM
{
    /// <summary>
    /// 包装数据访问类。
    /// </summary>
    public class ChestDataEngine
        : DatabaseDataEngine<Chest, string>, IChestDataEngine
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="sf"></param>
        public ChestDataEngine(ISessionFactory sf):base(sf)
        {
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.DataAccess.Interface.FMM;
using ServiceCenter.MES.Model.FMM;
using NHibernate;
using ServiceCenter.Common.DataAccess.NHibernate;


namespace ServiceCenter.MES.DataAccess.FMM
{
    /// <summary>
    /// 表示班别数据访问类。
    /// </summary>
    public class BinDataEngine
            : DatabaseDataEngine<Bin, string>
            ,IBinDataEngine
    {
        public BinDataEngine(ISessionFactory sf) : base(sf) { }
    }
}

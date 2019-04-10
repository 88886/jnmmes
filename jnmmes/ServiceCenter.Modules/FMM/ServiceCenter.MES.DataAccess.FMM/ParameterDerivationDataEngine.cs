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
    /// 表示推导参数运算数据访问类。
    /// </summary>
    public class ParameterDerivationDataEngine
        : DatabaseDataEngine<ParameterDerivation, ParameterDerivationKey>
        , IParameterDerivationDataEngine
    {
        public ParameterDerivationDataEngine(ISessionFactory sf):base(sf){}
    }
}

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
    /// 表示工艺流程组数据访问类。
    /// </summary>
    public class RouteEnterpriseDataEngine
        : DatabaseDataEngine<RouteEnterprise, string>
        , IRouteEnterpriseDataEngine
    {
        public RouteEnterpriseDataEngine(ISessionFactory sf):base(sf)
        {
        }
    }
}
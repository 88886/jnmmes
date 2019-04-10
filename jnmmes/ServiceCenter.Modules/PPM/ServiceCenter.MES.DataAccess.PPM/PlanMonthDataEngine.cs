﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.DataAccess.Interface.PPM;
using ServiceCenter.MES.Model.PPM;
using NHibernate;
using ServiceCenter.Common.DataAccess.NHibernate;

namespace ServiceCenter.MES.DataAccess.PPM
{
    //生产计划管理
    public class PlanMonthDataEngine
        : DatabaseDataEngine<PlanMonth, PlanMonthKey>
        , IPlanMonthDataEngine
    {
        public PlanMonthDataEngine(ISessionFactory sf) : base(sf) { }
    }
}

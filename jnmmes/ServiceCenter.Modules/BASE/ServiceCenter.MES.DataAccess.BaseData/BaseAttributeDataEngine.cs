﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.DataAccess.Interface.BaseData;
using ServiceCenter.MES.Model.BaseData;
using NHibernate;
using ServiceCenter.DataAccess;
using ServiceCenter.Common.DataAccess.NHibernate;

namespace ServiceCenter.MES.DataAccess.BaseData
{
    /// <summary>
    /// 表示基础属性数据访问类。
    /// </summary>
    public class BaseAttributeDataEngine
        : DatabaseDataEngine<BaseAttribute, BaseAttributeKey>
        ,IBaseAttributeDataEngine
    {
        public BaseAttributeDataEngine(ISessionFactory sf):base(sf)
        {
        }

    }
}

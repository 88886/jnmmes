﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.Model.ZPVM;
using ServiceCenter.DataAccess;
using ServiceCenter.Model;

namespace ServiceCenter.MES.DataAccess.Interface.ZPVM
{
    /// <summary>
    /// 定义规则数据访问接口。
    /// </summary>
    public interface IRuleDataEngine : IDatabaseDataEngine<Rule, string>
    {
    }
}

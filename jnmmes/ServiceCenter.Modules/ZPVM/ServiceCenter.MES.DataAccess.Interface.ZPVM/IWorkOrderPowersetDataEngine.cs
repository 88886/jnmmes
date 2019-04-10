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
    /// 定义工单分档设置数据访问接口。
    /// </summary>
    public interface IWorkOrderPowersetDataEngine 
        : IDatabaseDataEngine<WorkOrderPowerset, WorkOrderPowersetKey>
    {
    }
}
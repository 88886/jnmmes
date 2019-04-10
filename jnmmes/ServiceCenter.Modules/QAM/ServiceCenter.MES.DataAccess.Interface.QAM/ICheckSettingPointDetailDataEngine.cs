﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.Model.QAM;
using ServiceCenter.DataAccess;

namespace ServiceCenter.MES.DataAccess.Interface.QAM
{
    /// <summary>
    /// 表示检验设置点明细数据的数据访问接口。
    /// </summary>
    public interface ICheckSettingPointDetailDataEngine
        : IDatabaseDataEngine<CheckSettingPointDetail, CheckSettingPointDetailKey>
    {
    }
}

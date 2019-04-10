﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.Model.FMM;
using ServiceCenter.DataAccess;

namespace ServiceCenter.MES.DataAccess.Interface.FMM
{
    /// <summary>
    /// 表示打印标签数据访问接口。
    /// </summary>
    public interface IPrintLabelDataEngine : IDatabaseDataEngine<PrintLabel, string>
    {
    }
}

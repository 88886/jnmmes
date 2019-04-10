﻿using ServiceCenter.MES.Model.FMM;
using ServiceCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.MES.Service.Contract.FMM
{
    /// <summary>
    /// 定义排班计划服务契约。
    /// </summary>
     [ServiceContract]
    public interface IScheduleContract
    {
         /// <summary>
         /// 添加排班计划。
         /// </summary>
         /// <param name="obj">排班计划。</param>
         /// <returns><see cref="MethodReturnResult"/></returns>
         [OperationContract]
         MethodReturnResult Add(Schedule obj);
         /// <summary>
         /// 修改排班计划。
         /// </summary>
         /// <param name="obj">排班计划。</param>
         /// <returns><see cref="MethodReturnResult" /></returns>
         [OperationContract]
         MethodReturnResult Modify(Schedule obj);
         /// <summary>
         /// 删除排班计划。
         /// </summary>
         /// <param name="key">排班计划标识符.</param>
         /// <returns>MethodReturnResult.</returns>
         [OperationContract]
         MethodReturnResult Delete(string key);
         /// <summary>
         /// 获取排班计划数据。
         /// </summary>
         /// <param name="key">排班计划标识符.</param>
         /// <returns>MethodReturnResult&lt;Schedule&gt;，排班计划数据.</returns>
         [OperationContract]
         MethodReturnResult<Schedule> Get(string key);
         /// <summary>
         /// 获取排班计划数据集合。
         /// </summary>
         /// <param name="cfg">查询参数。</param>
         /// <returns>MethodReturnResult&lt;IList&lt;Schedule&gt;&gt;，排班计划数据集合。</returns>
         [OperationContract(Name="GetList")]
         MethodReturnResult<IList<Schedule>> Get(ref PagingConfig cfg);
    }
}

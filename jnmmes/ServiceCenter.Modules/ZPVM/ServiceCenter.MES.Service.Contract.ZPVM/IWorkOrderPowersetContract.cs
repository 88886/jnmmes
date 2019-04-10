﻿using ServiceCenter.MES.Model.ZPVM;
using ServiceCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.MES.Service.Contract.ZPVM
{
    /// <summary>
    /// 定义工单分档设置数据服务契约。
    /// </summary>
     [ServiceContract]
    public interface IWorkOrderPowersetContract
    {
         /// <summary>
         /// 添加工单分档设置数据。
         /// </summary>
         /// <param name="obj">工单分档设置数据。</param>
         /// <returns><see cref="MethodReturnResult"/></returns>
         [OperationContract]
         MethodReturnResult Add(WorkOrderPowerset obj);
         /// <summary>
         /// 修改工单分档设置数据。
         /// </summary>
         /// <param name="obj">工单分档设置数据。</param>
         /// <returns><see cref="MethodReturnResult" /></returns>
         [OperationContract]
         MethodReturnResult Modify(WorkOrderPowerset obj);
         /// <summary>
         /// 删除工单分档设置数据。
         /// </summary>
         /// <param name="key">工单分档设置数据标识符.</param>
         /// <returns>MethodReturnResult.</returns>
         [OperationContract]
         MethodReturnResult Delete(WorkOrderPowersetKey key);
         /// <summary>
         /// 获取工单分档设置数据。
         /// </summary>
         /// <param name="key">工单分档设置数据标识符.</param>
         /// <returns>MethodReturnResult&lt;WorkOrderPowerset&gt;，工单分档设置数据.</returns>
         [OperationContract]
         MethodReturnResult<WorkOrderPowerset> Get(WorkOrderPowersetKey key);
         /// <summary>
         /// 获取工单分档设置数据集合。
         /// </summary>
         /// <param name="cfg">查询工单分档设置数据。</param>
         /// <returns>MethodReturnResult&lt;IList&lt;WorkOrderPowerset&gt;&gt;，工单分档设置数据集合。</returns>
         [OperationContract(Name="GetList")]
         MethodReturnResult<IList<WorkOrderPowerset>> Get(ref PagingConfig cfg);
    }
}

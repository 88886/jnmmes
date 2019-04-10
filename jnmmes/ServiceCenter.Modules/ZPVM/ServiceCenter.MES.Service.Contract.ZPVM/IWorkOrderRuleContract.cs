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
    /// 定义工单规则设置数据服务契约。
    /// </summary>
     [ServiceContract]
    public interface IWorkOrderRuleContract
    {
         /// <summary>
         /// 添加工单规则设置数据。
         /// </summary>
         /// <param name="obj">工单规则设置数据。</param>
         /// <returns><see cref="MethodReturnResult"/></returns>
         [OperationContract]
         MethodReturnResult Add(WorkOrderRule obj);
         /// <summary>
         /// 修改工单规则设置数据。
         /// </summary>
         /// <param name="obj">工单规则设置数据。</param>
         /// <returns><see cref="MethodReturnResult" /></returns>
         [OperationContract]
         MethodReturnResult Modify(WorkOrderRule obj);
         /// <summary>
         /// 删除工单规则设置数据。
         /// </summary>
         /// <param name="key">工单规则设置数据标识符.</param>
         /// <returns>MethodReturnResult.</returns>
         [OperationContract]
         MethodReturnResult Delete(WorkOrderRuleKey key);
         /// <summary>
         /// 获取工单规则设置数据。
         /// </summary>
         /// <param name="key">工单规则设置数据标识符.</param>
         /// <returns>MethodReturnResult&lt;WorkOrderRule&gt;，工单规则设置数据.</returns>
         [OperationContract]
         MethodReturnResult<WorkOrderRule> Get(WorkOrderRuleKey key);
         /// <summary>
         /// 获取工单规则设置数据集合。
         /// </summary>
         /// <param name="cfg">查询工单规则设置数据。</param>
         /// <returns>MethodReturnResult&lt;IList&lt;WorkOrderRule&gt;&gt;，工单规则设置数据集合。</returns>
         [OperationContract(Name="GetList")]
         MethodReturnResult<IList<WorkOrderRule>> Get(ref PagingConfig cfg);
    }
}

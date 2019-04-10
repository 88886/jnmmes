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
    /// 定义代码数据服务契约。
    /// </summary>
     [ServiceContract]
    public interface IEquipmentReasonCodeContract
    {
         /// <summary>
         /// 添加代码数据。
         /// </summary>
         /// <param name="obj">代码数据。</param>
         /// <returns><see cref="MethodReturnResult"/></returns>
         [OperationContract]
         MethodReturnResult Add(EquipmentReasonCode obj);
         /// <summary>
         /// 修改代码数据。
         /// </summary>
         /// <param name="obj">代码数据。</param>
         /// <returns><see cref="MethodReturnResult" /></returns>
         [OperationContract]
         MethodReturnResult Modify(EquipmentReasonCode obj);
         /// <summary>
         /// 删除代码数据。
         /// </summary>
         /// <param name="key">代码数据标识符.</param>
         /// <returns>MethodReturnResult.</returns>
         [OperationContract]
         MethodReturnResult Delete(string key);
         /// <summary>
         /// 获取代码数据。
         /// </summary>
         /// <param name="key">代码数据标识符.</param>
         /// <returns>MethodReturnResult&lt;ReasonCode&gt;，代码数据.</returns>
         [OperationContract]
         MethodReturnResult<EquipmentReasonCode> Get(string key);
         /// <summary>
         /// 获取代码数据集合。
         /// </summary>
         /// <param name="cfg">查询参数。</param>
         /// <returns>MethodReturnResult&lt;IList&lt;ReasonCode&gt;&gt;，代码数据集合。</returns>
         [OperationContract(Name="GetList")]
         MethodReturnResult<IList<EquipmentReasonCode>> Get(ref PagingConfig cfg);
    }
}

﻿using ServiceCenter.MES.Model.EDC;
using ServiceCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.MES.Service.Contract.EDC
{
    /// <summary>
    /// 定义采集项目数据服务契约。
    /// </summary>
     [ServiceContract]
    public interface IDataAcquisitionItemContract
    {
         /// <summary>
         /// 添加采集项目数据。
         /// </summary>
         /// <param name="obj">采集项目数据。</param>
         /// <returns><see cref="MethodReturnResult"/></returns>
         [OperationContract]
         MethodReturnResult Add(DataAcquisitionItem obj);
         /// <summary>
         /// 修改采集项目数据。
         /// </summary>
         /// <param name="obj">采集项目数据。</param>
         /// <returns><see cref="MethodReturnResult" /></returns>
         [OperationContract]
         MethodReturnResult Modify(DataAcquisitionItem obj);
         /// <summary>
         /// 删除采集项目数据。
         /// </summary>
         /// <param name="key">采集项目数据标识符.</param>
         /// <returns>MethodReturnResult.</returns>
         [OperationContract]
         MethodReturnResult Delete(string key);
         /// <summary>
         /// 获取采集项目数据。
         /// </summary>
         /// <param name="key">采集项目数据标识符.</param>
         /// <returns>MethodReturnResult&lt;DataAcquisitionItem&gt;，采集项目数据.</returns>
         [OperationContract]
         MethodReturnResult<DataAcquisitionItem> Get(string key);
         /// <summary>
         /// 获取采集项目数据集合。
         /// </summary>
         /// <param name="cfg">查询采集项目。</param>
         /// <returns>MethodReturnResult&lt;IList&lt;DataAcquisitionItem&gt;&gt;，采集项目数据集合。</returns>
         [OperationContract(Name="GetList")]
         MethodReturnResult<IList<DataAcquisitionItem>> Get(ref PagingConfig cfg);
    }
}

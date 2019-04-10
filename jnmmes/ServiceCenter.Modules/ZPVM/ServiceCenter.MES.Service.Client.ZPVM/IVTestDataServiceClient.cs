﻿// ***********************************************************************
// Assembly         : ServiceCenter.MES.Service.Client.ZPVM
// Author           : peter
// Created          : 07-30-2014
//
// Last Modified By : peter
// Last Modified On : 08-08-2014
// ***********************************************************************
// <copyright file="IVTestDataServiceClient.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.Service.Contract.ZPVM;
using ServiceCenter.MES.Model.ZPVM;
using ServiceCenter.Model;
using System.Data;

/// <summary>
/// The ZPVM namespace.
/// </summary>
namespace ServiceCenter.MES.Service.Client.ZPVM
{
    /// <summary>
    /// 定义IV测试数据管理契约调用方式。
    /// </summary>
    public class IVTestDataServiceClient : ClientBase<IIVTestDataContract>, IIVTestDataContract, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IVTestDataServiceClient" /> class.
        /// </summary>
        public IVTestDataServiceClient() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IVTestDataServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public IVTestDataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IVTestDataServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public IVTestDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IVTestDataServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public IVTestDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IVTestDataServiceClient" /> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public IVTestDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        /// <summary>
        /// 添加IV测试数据。
        /// </summary>
        /// <param name="obj">IV测试数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Add(IVTestData obj)
        {
            return base.Channel.Add(obj);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> AddAsync(IVTestData obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Add(obj);
            });
        }
        /// <summary>
        /// 修改IV测试数据。
        /// </summary>
        /// <param name="obj">IV测试数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public ServiceCenter.Model.MethodReturnResult Modify(IVTestData obj)
        {
            return base.Channel.Modify(obj);
        }
        /// <summary>
        /// modify as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> ModifyAsync(IVTestData obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Modify(obj);
            });
        }
        /// <summary>
        /// 删除IV测试数据。
        /// </summary>
        /// <param name="key">IV测试数据标识符。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Delete(IVTestDataKey key)
        {
            return base.Channel.Delete(key);
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="key">IV测试数据标识符.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> DeleteAsync(IVTestDataKey key)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Delete(key);
            });
        }

        /// <summary>
        /// 获取IV测试数据。
        /// </summary>
        /// <param name="key">IV测试数据标识符.</param>
        /// <returns><see cref="MethodReturnResult&lt;IVTestData&gt;" />,IV测试数据.</returns>
        public MethodReturnResult<IVTestData> Get(IVTestDataKey key)
        {
            return base.Channel.Get(key);
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;MethodReturnResult&lt;IVTestData&gt;&gt;.</returns>
        public async Task<MethodReturnResult<IVTestData>> GetAsync(IVTestDataKey key)
        {
            return await Task.Run<MethodReturnResult<IVTestData>>(() =>
            {
                return base.Channel.Get(key);
            });
        }

        /// <summary>
        /// 获取IV测试数据集合。
        /// </summary>
        /// <param name="cfg">查询IV测试数据.</param>
        /// <returns>MethodReturnResult&lt;IList&lt;IVTestData&gt;&gt;，IV测试数据集合.</returns>
        public MethodReturnResult<IList<IVTestData>> Get(ref ServiceCenter.Model.PagingConfig cfg)
        {
            return base.Channel.Get(ref cfg);
        }
        public MethodReturnResult<DataSet> GetIVdata(ref LotIVdataParameter p)
        {
            return base.Channel.GetIVdata(ref p);
        }

        public MinPaiData GetMinPaiData(string LotNumber, string lineCode)
        {
            return base.Channel.GetMinPaiData(LotNumber,lineCode);
        }

        public string CallBack(string lotNumber, string ErrorMessage, string lineCode)
        {
            return base.Channel.CallBack(lotNumber, ErrorMessage,lineCode);
        }
    }
}

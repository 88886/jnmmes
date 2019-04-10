﻿// ***********************************************************************
// Assembly         : ServiceCenter.MES.Service.Client.ZPVM
// Author           : peter
// Created          : 07-30-2014
//
// Last Modified By : peter
// Last Modified On : 08-08-2014
// ***********************************************************************
// <copyright file="IVTestDataPrintLogServiceClient.cs" company="">
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

/// <summary>
/// The ZPVM namespace.
/// </summary>
namespace ServiceCenter.MES.Service.Client.ZPVM
{
    /// <summary>
    /// 定义IV测试数据打印日志管理契约调用方式。
    /// </summary>
    public class IVTestDataPrintLogServiceClient : ClientBase<IIVTestDataPrintLogContract>, IIVTestDataPrintLogContract, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IVTestDataPrintLogServiceClient" /> class.
        /// </summary>
        public IVTestDataPrintLogServiceClient() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IVTestDataPrintLogServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public IVTestDataPrintLogServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IVTestDataPrintLogServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public IVTestDataPrintLogServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IVTestDataPrintLogServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public IVTestDataPrintLogServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IVTestDataPrintLogServiceClient" /> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public IVTestDataPrintLogServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        /// <summary>
        /// 添加IV测试数据打印日志。
        /// </summary>
        /// <param name="obj">IV测试数据打印日志数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Add(IVTestDataPrintLog obj)
        {
            return base.Channel.Add(obj);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> AddAsync(IVTestDataPrintLog obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Add(obj);
            });
        }
        /// <summary>
        /// 修改IV测试数据打印日志。
        /// </summary>
        /// <param name="obj">IV测试数据打印日志数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public ServiceCenter.Model.MethodReturnResult Modify(IVTestDataPrintLog obj)
        {
            return base.Channel.Modify(obj);
        }
        /// <summary>
        /// modify as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> ModifyAsync(IVTestDataPrintLog obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Modify(obj);
            });
        }
        /// <summary>
        /// 删除IV测试数据打印日志。
        /// </summary>
        /// <param name="key">IV测试数据打印日志标识符。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Delete(IVTestDataPrintLogKey key)
        {
            return base.Channel.Delete(key);
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="key">IV测试数据打印日志标识符.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> DeleteAsync(IVTestDataPrintLogKey key)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Delete(key);
            });
        }

        /// <summary>
        /// 获取IV测试数据打印日志数据。
        /// </summary>
        /// <param name="key">IV测试数据打印日志标识符.</param>
        /// <returns><see cref="MethodReturnResult&lt;IVTestDataPrintLog&gt;" />,IV测试数据打印日志数据.</returns>
        public MethodReturnResult<IVTestDataPrintLog> Get(IVTestDataPrintLogKey key)
        {
            return base.Channel.Get(key);
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;MethodReturnResult&lt;IVTestDataPrintLog&gt;&gt;.</returns>
        public async Task<MethodReturnResult<IVTestDataPrintLog>> GetAsync(IVTestDataPrintLogKey key)
        {
            return await Task.Run<MethodReturnResult<IVTestDataPrintLog>>(() =>
            {
                return base.Channel.Get(key);
            });
        }

        /// <summary>
        /// 获取IV测试数据打印日志数据集合。
        /// </summary>
        /// <param name="cfg">查询IV测试数据打印日志.</param>
        /// <returns>MethodReturnResult&lt;IList&lt;IVTestDataPrintLog&gt;&gt;，IV测试数据打印日志数据集合.</returns>
        public MethodReturnResult<IList<IVTestDataPrintLog>> Get(ref ServiceCenter.Model.PagingConfig cfg)
        {
            return base.Channel.Get(ref cfg);
        }
    }
}

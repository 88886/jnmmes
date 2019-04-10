﻿// ***********************************************************************
// Assembly         : ServiceCenter.MES.Service.Client.EDC
// Author           : peter
// Created          : 07-30-2014
//
// Last Modified By : peter
// Last Modified On : 08-08-2014
// ***********************************************************************
// <copyright file="CategoryDetailServiceClient.cs" company="">
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
using ServiceCenter.MES.Service.Contract.EDC;
using ServiceCenter.MES.Model.EDC;
using ServiceCenter.Model;

/// <summary>
/// The EDC namespace.
/// </summary>
namespace ServiceCenter.MES.Service.Client.EDC
{
    /// <summary>
    /// 定义采集参数管理契约调用方式。
    /// </summary>
    public class CategoryDetailServiceClient : ClientBase<ICategoryDetailContract>, ICategoryDetailContract, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDetailServiceClient" /> class.
        /// </summary>
        public CategoryDetailServiceClient() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDetailServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public CategoryDetailServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDetailServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public CategoryDetailServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDetailServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public CategoryDetailServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDetailServiceClient" /> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public CategoryDetailServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        /// <summary>
        /// 添加采集参数。
        /// </summary>
        /// <param name="obj">采集参数数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Add(CategoryDetail obj)
        {
            return base.Channel.Add(obj);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> AddAsync(CategoryDetail obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Add(obj);
            });
        }
        /// <summary>
        /// 修改采集参数。
        /// </summary>
        /// <param name="obj">采集参数数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public ServiceCenter.Model.MethodReturnResult Modify(CategoryDetail obj)
        {
            return base.Channel.Modify(obj);
        }
        /// <summary>
        /// modify as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> ModifyAsync(CategoryDetail obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Modify(obj);
            });
        }
        /// <summary>
        /// 删除采集参数。
        /// </summary>
        /// <param name="key">采集参数标识符。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Delete(CategoryDetailKey key)
        {
            return base.Channel.Delete(key);
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="key">采集参数标识符.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> DeleteAsync(CategoryDetailKey key)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Delete(key);
            });
        }

        /// <summary>
        /// 获取采集参数数据。
        /// </summary>
        /// <param name="key">采集参数标识符.</param>
        /// <returns><see cref="MethodReturnResult&lt;CategoryDetail&gt;" />,采集参数数据.</returns>
        public MethodReturnResult<CategoryDetail> Get(CategoryDetailKey key)
        {
            return base.Channel.Get(key);
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;MethodReturnResult&lt;CategoryDetail&gt;&gt;.</returns>
        public async Task<MethodReturnResult<CategoryDetail>> GetAsync(CategoryDetailKey key)
        {
            return await Task.Run<MethodReturnResult<CategoryDetail>>(() =>
            {
                return base.Channel.Get(key);
            });
        }

        /// <summary>
        /// 获取采集参数数据集合。
        /// </summary>
        /// <param name="cfg">查询采集参数.</param>
        /// <returns>MethodReturnResult&lt;IList&lt;CategoryDetail&gt;&gt;，采集参数数据集合.</returns>
        public MethodReturnResult<IList<CategoryDetail>> Get(ref ServiceCenter.Model.PagingConfig cfg)
        {
            return base.Channel.Get(ref cfg);
        }
    }
}
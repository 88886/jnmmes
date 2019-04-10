﻿// ***********************************************************************
// Assembly         : ServiceCenter.MES.Service.Client.EDC
// Author           : peter
// Created          : 07-30-2014
//
// Last Modified By : peter
// Last Modified On : 08-08-2014
// ***********************************************************************
// <copyright file="CategoryServiceClient.cs" company="">
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
    /// 定义采集参数组管理契约调用方式。
    /// </summary>
    public class CategoryServiceClient : ClientBase<ICategoryContract>, ICategoryContract, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryServiceClient" /> class.
        /// </summary>
        public CategoryServiceClient() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public CategoryServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public CategoryServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public CategoryServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryServiceClient" /> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public CategoryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        /// <summary>
        /// 添加采集参数组。
        /// </summary>
        /// <param name="obj">采集参数组数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Add(Category obj)
        {
            return base.Channel.Add(obj);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> AddAsync(Category obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Add(obj);
            });
        }
        /// <summary>
        /// 修改采集参数组。
        /// </summary>
        /// <param name="obj">采集参数组数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public ServiceCenter.Model.MethodReturnResult Modify(Category obj)
        {
            return base.Channel.Modify(obj);
        }
        /// <summary>
        /// modify as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> ModifyAsync(Category obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Modify(obj);
            });
        }
        /// <summary>
        /// 删除采集参数组。
        /// </summary>
        /// <param name="key">采集参数组标识符。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Delete(string key)
        {
            return base.Channel.Delete(key);
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="key">采集参数组标识符.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> DeleteAsync(string key)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Delete(key);
            });
        }

        /// <summary>
        /// 获取采集参数组数据。
        /// </summary>
        /// <param name="key">采集参数组标识符.</param>
        /// <returns><see cref="MethodReturnResult&lt;Category&gt;" />,采集参数组数据.</returns>
        public MethodReturnResult<Category> Get(string key)
        {
            return base.Channel.Get(key);
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;MethodReturnResult&lt;Category&gt;&gt;.</returns>
        public async Task<MethodReturnResult<Category>> GetAsync(string key)
        {
            return await Task.Run<MethodReturnResult<Category>>(() =>
            {
                return base.Channel.Get(key);
            });
        }

        /// <summary>
        /// 获取采集参数组数据集合。
        /// </summary>
        /// <param name="cfg">查询采集参数组.</param>
        /// <returns>MethodReturnResult&lt;IList&lt;Category&gt;&gt;，采集参数组数据集合.</returns>
        public MethodReturnResult<IList<Category>> Get(ref ServiceCenter.Model.PagingConfig cfg)
        {
            return base.Channel.Get(ref cfg);
        }
    }
}

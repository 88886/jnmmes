﻿// ***********************************************************************
// Assembly         : ServiceCenter.MES.Service.Client.ZPVM
// Author           : peter
// Created          : 07-30-2014
//
// Last Modified By : peter
// Last Modified On : 08-08-2014
// ***********************************************************************
// <copyright file="ProductControlObjectServiceClient.cs" company="">
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
    /// 定义产品控制参数对象设置数据管理契约调用方式。
    /// </summary>
    public class ProductControlObjectServiceClient : ClientBase<IProductControlObjectContract>, IProductControlObjectContract, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductControlObjectServiceClient" /> class.
        /// </summary>
        public ProductControlObjectServiceClient() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductControlObjectServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public ProductControlObjectServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductControlObjectServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public ProductControlObjectServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductControlObjectServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public ProductControlObjectServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductControlObjectServiceClient" /> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public ProductControlObjectServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        /// <summary>
        /// 添加产品控制参数对象设置数据。
        /// </summary>
        /// <param name="obj">产品控制参数对象设置数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Add(ProductControlObject obj)
        {
            return base.Channel.Add(obj);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> AddAsync(ProductControlObject obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Add(obj);
            });
        }
        /// <summary>
        /// 修改产品控制参数对象设置数据。
        /// </summary>
        /// <param name="obj">产品控制参数对象设置数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public ServiceCenter.Model.MethodReturnResult Modify(ProductControlObject obj)
        {
            return base.Channel.Modify(obj);
        }
        /// <summary>
        /// modify as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> ModifyAsync(ProductControlObject obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Modify(obj);
            });
        }
        /// <summary>
        /// 删除产品控制参数对象设置数据。
        /// </summary>
        /// <param name="key">产品控制参数对象设置数据标识符。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Delete(ProductControlObjectKey key)
        {
            return base.Channel.Delete(key);
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="key">产品控制参数对象设置数据标识符.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> DeleteAsync(ProductControlObjectKey key)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Delete(key);
            });
        }

        /// <summary>
        /// 获取产品控制参数对象设置数据。
        /// </summary>
        /// <param name="key">产品控制参数对象设置数据标识符.</param>
        /// <returns><see cref="MethodReturnResult&lt;ProductControlObject&gt;" />,产品控制参数对象设置数据.</returns>
        public MethodReturnResult<ProductControlObject> Get(ProductControlObjectKey key)
        {
            return base.Channel.Get(key);
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;MethodReturnResult&lt;ProductControlObject&gt;&gt;.</returns>
        public async Task<MethodReturnResult<ProductControlObject>> GetAsync(ProductControlObjectKey key)
        {
            return await Task.Run<MethodReturnResult<ProductControlObject>>(() =>
            {
                return base.Channel.Get(key);
            });
        }

        /// <summary>
        /// 获取产品控制参数对象设置数据集合。
        /// </summary>
        /// <param name="cfg">查询产品控制参数对象设置数据.</param>
        /// <returns>MethodReturnResult&lt;IList&lt;ProductControlObject&gt;&gt;，产品控制参数对象设置数据集合.</returns>
        public MethodReturnResult<IList<ProductControlObject>> Get(ref ServiceCenter.Model.PagingConfig cfg)
        {
            return base.Channel.Get(ref cfg);
        }
    }
}
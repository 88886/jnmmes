﻿// ***********************************************************************
// Assembly         : ServiceCenter.MES.Service.Client.FMM
// Author           : peter
// Created          : 07-30-2014
//
// Last Modified By : peter
// Last Modified On : 08-08-2014
// ***********************************************************************
// <copyright file="RouteOperationEquipmentServiceClient.cs" company="">
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
using ServiceCenter.MES.Service.Contract.FMM;
using ServiceCenter.MES.Model.FMM;
using ServiceCenter.Model;

/// <summary>
/// The FMM namespace.
/// </summary>
namespace ServiceCenter.MES.Service.Client.FMM
{
    /// <summary>
    /// 定义工序设备管理契约调用方式。
    /// </summary>
    public class RouteOperationEquipmentServiceClient : ClientBase<IRouteOperationEquipmentContract>, IRouteOperationEquipmentContract, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteOperationEquipmentServiceClient" /> class.
        /// </summary>
        public RouteOperationEquipmentServiceClient() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteOperationEquipmentServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public RouteOperationEquipmentServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteOperationEquipmentServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public RouteOperationEquipmentServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteOperationEquipmentServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public RouteOperationEquipmentServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteOperationEquipmentServiceClient" /> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public RouteOperationEquipmentServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }



        /// <summary>
        /// 添加工序设备。
        /// </summary>
        /// <param name="obj">工序设备数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Add(RouteOperationEquipment obj)
        {
            return base.Channel.Add(obj);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> AddAsync(RouteOperationEquipment obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Add(obj);
            });
        }
        /// <summary>
        /// 修改工序设备。
        /// </summary>
        /// <param name="obj">工序设备数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public ServiceCenter.Model.MethodReturnResult Modify(RouteOperationEquipment obj)
        {
            return base.Channel.Modify(obj);
        }
        /// <summary>
        /// modify as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> ModifyAsync(RouteOperationEquipment obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Modify(obj);
            });
        }
        /// <summary>
        /// 删除工序设备。
        /// </summary>
        /// <param name="key">工序设备标识符。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Delete(RouteOperationEquipmentKey key)
        {
            return base.Channel.Delete(key);
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="key">工序设备标识符.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> DeleteAsync(RouteOperationEquipmentKey key)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Delete(key);
            });
        }
        /// <summary>
        /// 获取工序设备数据。
        /// </summary>
        /// <param name="key">工序设备标识符.</param>
        /// <returns><see cref="MethodReturnResult&lt;RouteOperationEquipment&gt;" />,工序设备数据.</returns>
        public MethodReturnResult<RouteOperationEquipment> Get(RouteOperationEquipmentKey key)
        {
            return base.Channel.Get(key);
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;MethodReturnResult&lt;RouteOperationEquipment&gt;&gt;.</returns>
        public async Task<MethodReturnResult<RouteOperationEquipment>> GetAsync(RouteOperationEquipmentKey key)
        {
            return await Task.Run<MethodReturnResult<RouteOperationEquipment>>(() =>
            {
                return base.Channel.Get(key);
            });
        }

        /// <summary>
        /// 获取工序设备数据集合。
        /// </summary>
        /// <param name="cfg">查询参数.</param>
        /// <returns>MethodReturnResult&lt;IList&lt;RouteOperationEquipment&gt;&gt;，工序设备数据集合.</returns>
        public MethodReturnResult<IList<RouteOperationEquipment>> Get(ref ServiceCenter.Model.PagingConfig cfg)
        {
            return base.Channel.Get(ref cfg);
        }
    }
}

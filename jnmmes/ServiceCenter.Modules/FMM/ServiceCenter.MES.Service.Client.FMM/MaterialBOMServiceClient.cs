﻿// ***********************************************************************
// Assembly         : ServiceCenter.MES.Service.Client.FMM
// Author           : peter
// Created          : 07-30-2014
//
// Last Modified By : peter
// Last Modified On : 08-08-2014
// ***********************************************************************
// <copyright file="MaterialBOMServiceClient.cs" company="">
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
    /// 定义物料BOM管理契约调用方式。
    /// </summary>
    public class MaterialBOMServiceClient : ClientBase<IMaterialBOMContract>, IMaterialBOMContract, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialBOMServiceClient" /> class.
        /// </summary>
        public MaterialBOMServiceClient() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialBOMServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public MaterialBOMServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialBOMServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public MaterialBOMServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialBOMServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public MaterialBOMServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaterialBOMServiceClient" /> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public MaterialBOMServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        /// <summary>
        /// 添加物料BOM。
        /// </summary>
        /// <param name="obj">物料BOM数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Add(MaterialBOM obj)
        {
            return base.Channel.Add(obj);
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> AddAsync(MaterialBOM obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Add(obj);
            });
        }
        /// <summary>
        /// 修改物料BOM。
        /// </summary>
        /// <param name="obj">物料BOM数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public ServiceCenter.Model.MethodReturnResult Modify(MaterialBOM obj)
        {
            return base.Channel.Modify(obj);
        }
        /// <summary>
        /// modify as an asynchronous operation.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> ModifyAsync(MaterialBOM obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Modify(obj);
            });
        }
        /// <summary>
        /// 删除物料BOM。
        /// </summary>
        /// <param name="key">物料BOM标识符。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Delete(MaterialBOMKey key)
        {
            return base.Channel.Delete(key);
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="key">物料BOM标识符.</param>
        /// <returns>Task&lt;MethodReturnResult&gt;.</returns>
        public async Task<MethodReturnResult> DeleteAsync(MaterialBOMKey key)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Delete(key);
            });
        }

        /// <summary>
        /// 获取物料BOM数据。
        /// </summary>
        /// <param name="key">物料BOM标识符.</param>
        /// <returns><see cref="MethodReturnResult&lt;MaterialBOM&gt;" />,物料BOM数据.</returns>
        public MethodReturnResult<MaterialBOM> Get(MaterialBOMKey key)
        {
            return base.Channel.Get(key);
        }

        /// <summary>
        /// get as an asynchronous operation.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Task&lt;MethodReturnResult&lt;MaterialBOM&gt;&gt;.</returns>
        public async Task<MethodReturnResult<MaterialBOM>> GetAsync(MaterialBOMKey key)
        {
            return await Task.Run<MethodReturnResult<MaterialBOM>>(() =>
            {
                return base.Channel.Get(key);
            });
        }

        /// <summary>
        /// 获取物料BOM数据集合。
        /// </summary>
        /// <param name="cfg">查询物料BOM.</param>
        /// <returns>MethodReturnResult&lt;IList&lt;MaterialBOM&gt;&gt;，物料BOM数据集合.</returns>
        public MethodReturnResult<IList<MaterialBOM>> Get(ref ServiceCenter.Model.PagingConfig cfg)
        {
            return base.Channel.Get(ref cfg);
        }
    }
}

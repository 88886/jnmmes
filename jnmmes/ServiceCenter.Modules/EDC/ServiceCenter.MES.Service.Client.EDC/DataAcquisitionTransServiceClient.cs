﻿using ServiceCenter.MES.Model.EDC;
using ServiceCenter.MES.Service.Contract.EDC;
using ServiceCenter.Model;
// ***********************************************************************
// Assembly         : ServiceCenter.MES.Service.Client.EDC
// Author           : fangjun
// Created          : 06-04-2017
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="DataAcquisitionDataServiceClient.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServiceCenter.MES.Service.Client.EDC
{
    /// <summary>
    /// 定义采集数据管理契约调用方式。
    /// </summary>
    public class DataAcquisitionDataServiceClient : ClientBase<IDataAcquisitionDataContract>, IDataAcquisitionDataContract, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAcquisitionDataServiceClient" /> class.
        /// </summary>
        public DataAcquisitionDataServiceClient() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAcquisitionDataServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public DataAcquisitionDataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAcquisitionDataServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public DataAcquisitionDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAcquisitionDataServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public DataAcquisitionDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAcquisitionDataServiceClient" /> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public DataAcquisitionDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        /// <summary>
        /// 添加采集数据。
        /// </summary>
        /// <param name="obj">采集数据数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Add(DataAcquisitionData obj)
        {
            return base.Channel.Add(obj);
        }

        public async Task<MethodReturnResult> AddAsync(DataAcquisitionData obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Add(obj);
            });
        }

        /// <summary>
        /// 新增一组采集数
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public MethodReturnResult Add(IList<DataAcquisitionData> lst)
        {
            return base.Channel.Add(lst);
        }

        public async Task<MethodReturnResult> AddAsync(IList<DataAcquisitionData> lst)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Add(lst);
            });
        }

        /// <summary>
        /// 修改采集数据。
        /// </summary>
        /// <param name="obj">采集数据数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Modify(DataAcquisitionData obj)
        {
            return base.Channel.Modify(obj);
        }

        public async Task<MethodReturnResult> ModifyAsync(DataAcquisitionData obj)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Modify(obj);
            });
        }

        public MethodReturnResult Modify(IList<DataAcquisitionData> lst)
        {
            return base.Channel.Modify(lst);
        }

        public async Task<MethodReturnResult> ModifyAsync(IList<DataAcquisitionData> lst)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Modify(lst);
            });
        }

        /// <summary>
        /// 删除采集数据。
        /// </summary>
        /// <param name="key">采集数据标识符。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Delete(DataAcquisitionDataKey key)
        {
            return base.Channel.Delete(key);
        }
        
        public async Task<MethodReturnResult> DeleteAsync(DataAcquisitionDataKey key)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Delete(key);
            });
        }

        public MethodReturnResult Delete(DateTime eDCTime, string itemCode, string lineCode, string equipmentCode, string locationName)
        {
            return base.Channel.Delete(eDCTime, itemCode, lineCode, equipmentCode, locationName);
        }

        public async Task<MethodReturnResult> DeleteAsync(DateTime eDCTime, string itemCode, string lineCode, string equipmentCode, string locationName)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Delete(eDCTime, itemCode, lineCode, equipmentCode, locationName);
            });
        }

        /// <summary>
        /// 获取采集数据数据。
        /// </summary>
        /// <param name="key">采集数据标识符。</param>
        /// <returns><see cref="MethodReturnResult&lt;DataAcquisitionData&gt;" />,采集数据数据.</returns>
        public MethodReturnResult<DataAcquisitionData> Get(DataAcquisitionDataKey key)
        {
            return base.Channel.Get(key);
        }

        public async Task<MethodReturnResult<DataAcquisitionData>> GetAsync(DataAcquisitionDataKey key)
        {
            return await Task.Run<MethodReturnResult<DataAcquisitionData>>(() =>
            {
                return base.Channel.Get(key);
            });
        }

        /// <summary>
        /// 获取采集数据数据集合。
        /// </summary>
        /// <param name="cfg">查询参数.</param>
        /// <returns>MethodReturnResult&lt;IList&lt;DataAcquisitionData&gt;&gt;，采集数据数据集合.</returns>
        public ServiceCenter.Model.MethodReturnResult<IList<DataAcquisitionData>> Get(ref ServiceCenter.Model.PagingConfig cfg)
        {
            return base.Channel.Get(ref cfg);
        }

        public MethodReturnResult<DataSet> GetData(ref DataAcquisitionDataGetParameter p)
        {
            return base.Channel.GetData(ref p);
        }

        public async Task<MethodReturnResult<DataSet>> GetDataAsync(DataAcquisitionDataGetParameter p)
        {
            return await Task.Run<MethodReturnResult<DataSet>>(() =>
            {
                return base.Channel.GetData(ref p);
            });
        }
    }
}

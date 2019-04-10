﻿// ***********************************************************************
// Assembly         : ServiceCenter.MES.Service.Client.WIP
// Author           : peter
// Created          : 07-30-2014
//
// Last Modified By : peter
// Last Modified On : 08-08-2014
// ***********************************************************************
// <copyright file="LotTerminalServiceClient.cs" company="">
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
using ServiceCenter.MES.Service.Contract.WIP;
using ServiceCenter.MES.Model.WIP;
using ServiceCenter.Model;

/// <summary>
/// The WIP namespace.
/// </summary>
namespace ServiceCenter.MES.Service.Client.WIP
{
    /// <summary>
    /// 定义批次终止契约调用方式。
    /// </summary>
    public class LotTerminalServiceClient : ClientBase<ILotTerminalContract>, ILotTerminalContract, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LotTerminalServiceClient" /> class.
        /// </summary>
        public LotTerminalServiceClient() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LotTerminalServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        public LotTerminalServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LotTerminalServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public LotTerminalServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LotTerminalServiceClient" /> class.
        /// </summary>
        /// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public LotTerminalServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LotTerminalServiceClient" /> class.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="remoteAddress">The remote address.</param>
        public LotTerminalServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        public MethodReturnResult Terminal(TerminalParameter p)
        {
            return base.Channel.Terminal(p);
        }

        public async Task<MethodReturnResult> TerminalAsync(TerminalParameter p)
        {
            return await Task.Run<MethodReturnResult>(() =>
            {
                return base.Channel.Terminal(p);
            });
        }
    }
}

﻿// ***********************************************************************
// Assembly         : ServiceCenter.MES.Service.Contract.RBAC
// Author           : peter
// Created          : 07-30-2014
//
// Last Modified By : peter
// Last Modified On : 07-30-2014
// ***********************************************************************
// <copyright file="IUserOwnResourceContract.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using ServiceCenter.MES.Model.RBAC;
using ServiceCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The RBAC namespace.
/// </summary>
namespace ServiceCenter.MES.Service.Contract.RBAC
{
    /// <summary>
    /// 定义用户资源管理契约接口。
    /// </summary>
    [ServiceContract]
    public interface IUserOwnResourceContract
    {
        /// <summary>
        /// 添加用户资源。
        /// </summary>
        /// <param name="obj">用户资源数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        [OperationContract]
        MethodReturnResult Add(UserOwnResource obj);
        /// <summary>
        /// 修改用户资源。
        /// </summary>
        /// <param name="obj">用户资源数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        [OperationContract]
        MethodReturnResult Modify(UserOwnResource obj);
        /// <summary>
        /// 删除用户资源。
        /// </summary>
        /// <param name="key">用户资源标识符。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        [OperationContract]
        MethodReturnResult Delete(UserOwnResourceKey key);
        /// <summary>
        /// 获取用户资源数据。
        /// </summary>
        /// <param name="key">用户资源标识符.</param>
        /// <returns><see cref="MethodReturnResult&lt;UserOwnResource&gt;" />,用户资源数据.</returns>
        [OperationContract]
        MethodReturnResult<UserOwnResource> Get(UserOwnResourceKey key);
        /// <summary>
        /// 获取用户资源数据集合。
        /// </summary>
        /// <param name="cfg">查询参数.</param>
        /// <returns>MethodReturnResult&lt;IList&lt;UserOwnResource&gt;&gt;，用户资源数据集合.</returns>
        [OperationContract(Name = "GetList")]
        MethodReturnResult<IList<UserOwnResource>> Get(ref PagingConfig cfg);
    }
}

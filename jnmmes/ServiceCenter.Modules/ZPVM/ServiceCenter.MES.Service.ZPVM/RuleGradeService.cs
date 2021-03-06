﻿using ServiceCenter.MES.DataAccess.Interface.ZPVM;
using ServiceCenter.MES.Model.ZPVM;
using ServiceCenter.MES.Service.Contract.ZPVM;
using ServiceCenter.MES.Service.ZPVM.Resources;
using ServiceCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCenter.MES.Service.ZPVM
{
    /// <summary>
    /// 实现规则-等级设置数据管理服务契约。
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class RuleGradeService : IRuleGradeContract
    {
        /// <summary>
        /// 规则-等级设置数据数据访问读写。
        /// </summary>
        public IRuleGradeDataEngine RuleGradeDataEngine { get; set; }


        /// <summary>
        /// 添加规则-等级设置数据。
        /// </summary>
        /// <param name="obj">规则-等级设置数据数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Add(RuleGrade obj)
        {
            MethodReturnResult result = new MethodReturnResult();
            if (this.RuleGradeDataEngine.IsExists(obj.Key))
            {
                result.Code = 1001;
                result.Message = String.Format(StringResource.RuleGradeService_IsExists, obj.Key);
                return result;
            }
            try
            {
                this.RuleGradeDataEngine.Insert(obj);
            }
            catch (Exception ex)
            {
                result.Code = 1000;
                result.Message = String.Format(StringResource.Error,ex.Message);
                result.Detail = ex.ToString();
            }
            return result;
        }


        /// <summary>
        /// 修改规则-等级设置数据。
        /// </summary>
        /// <param name="obj">规则-等级设置数据数据。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Modify(RuleGrade obj)
        {
            MethodReturnResult result = new MethodReturnResult();
            if (!this.RuleGradeDataEngine.IsExists(obj.Key))
            {
                result.Code = 1002;
                result.Message = String.Format(StringResource.RuleGradeService_IsNotExists, obj.Key);
                return result;
            }
            try
            {
                this.RuleGradeDataEngine.Update(obj);
            }
            catch (Exception ex)
            {
                result.Code = 1000;
                result.Message = String.Format(StringResource.Error, ex.Message);
                result.Detail = ex.ToString();
            }
            return result;
        }
        /// <summary>
        /// 删除规则-等级设置数据。
        /// </summary>
        /// <param name="key">规则-等级设置数据标识符。</param>
        /// <returns><see cref="MethodReturnResult" />.</returns>
        public MethodReturnResult Delete(RuleGradeKey key)
        {
            MethodReturnResult result = new MethodReturnResult();
            if (!this.RuleGradeDataEngine.IsExists(key))
            {
                result.Code = 1002;
                result.Message = String.Format(StringResource.RuleGradeService_IsNotExists, key);
                return result;
            }
            try
            {
                this.RuleGradeDataEngine.Delete(key);
            }
            catch (Exception ex)
            {
                result.Code = 1000;
                result.Message = String.Format(StringResource.Error, ex.Message);
                result.Detail = ex.ToString();
            }
            return result;
        }

        /// <summary>
        /// 获取规则-等级设置数据数据。
        /// </summary>
        /// <param name="key">规则-等级设置数据标识符.</param>
        /// <returns><see cref="MethodReturnResult&lt;RuleGrade&gt;" />,规则-等级设置数据数据.</returns>
        public MethodReturnResult<RuleGrade> Get(RuleGradeKey key)
        {
            MethodReturnResult<RuleGrade> result = new MethodReturnResult<RuleGrade>();
            if (!this.RuleGradeDataEngine.IsExists(key))
            {
                result.Code = 1002;
                result.Message = String.Format(StringResource.RuleGradeService_IsNotExists, key);
                return result;
            }
            try
            {
                result.Data = this.RuleGradeDataEngine.Get(key);
            }
            catch (Exception ex)
            {
                result.Code = 1000;
                result.Message = String.Format(StringResource.Error, ex.Message);
                result.Detail = ex.ToString();
            }
            return result;
        }

        /// <summary>
        /// 获取规则-等级设置数据数据集合。
        /// </summary>
        /// <param name="cfg">查询参数。</param>
        /// <returns><see cref="MethodReturnResult&lt;RuleGrade&gt;" />,规则-等级设置数据数据集合。</returns>
        public MethodReturnResult<IList<RuleGrade>> Get(ref PagingConfig cfg)
        {
            MethodReturnResult<IList<RuleGrade>> result = new MethodReturnResult<IList<RuleGrade>>();
            try
            {
                result.Data = this.RuleGradeDataEngine.Get(cfg);
            }
            catch (Exception ex)
            {
                result.Code = 1000;
                result.Message = String.Format(StringResource.Error, ex.Message);
                result.Detail = ex.ToString();
            }
            return result;
        }
    }
}

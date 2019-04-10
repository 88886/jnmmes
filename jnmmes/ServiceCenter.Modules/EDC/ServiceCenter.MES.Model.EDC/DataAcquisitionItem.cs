﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.Model;

namespace ServiceCenter.MES.Model.EDC
{
    /// <summary>
    /// 描述采集项目的模型类。
    /// </summary>
    [DataContract]
    public class DataAcquisitionItem : BaseModel<string>
    {
        /// <summary>
        /// 主键（采集项目代码）。
        /// </summary>
        [DataMember]
        public override string Key
        {
            get;
            set;
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        [DataMember]
        public virtual string ItemName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public virtual string Description { get; set; }

        /// <summary>
        /// 工序
        /// </summary>
        [DataMember]
        public virtual string RouteStepName { get; set; }

        /// <summary>
        /// 创建人。
        /// </summary>
        [DataMember]
        public virtual string Creator { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        [DataMember]
        public virtual DateTime? CreateTime { get; set; }

        /// <summary>
        /// 编辑人。
        /// </summary>
        [DataMember]
        public virtual string Editor { get; set; }

        /// <summary>
        /// 编辑时间。
        /// </summary>
        [DataMember]
        public virtual DateTime? EditTime { get; set; }
    }
}

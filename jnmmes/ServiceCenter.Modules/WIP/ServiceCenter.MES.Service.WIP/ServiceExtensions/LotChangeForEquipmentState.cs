﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCenter.MES.DataAccess.Interface.FMM;
using ServiceCenter.MES.DataAccess.Interface.WIP;
using ServiceCenter.MES.Model.FMM;
using ServiceCenter.MES.Model.WIP;
using ServiceCenter.MES.Service.Contract.WIP;
using ServiceCenter.MES.Service.WIP.Resources;
using ServiceCenter.Model;
using ServiceCenter.MES.DataAccess.Interface.EMS;
using ServiceCenter.MES.Model.EMS;
using NHibernate;

namespace ServiceCenter.MES.Service.WIP.ServiceExtensions
{
    /// <summary>
    /// 扩展批次转工单，进行设备状态切换操作。
    /// </summary>
    class LotChangeForEquipmentState : ILotChange
    {
        public LotChangeForEquipmentState(ISessionFactory sf)
        {
            this.SessionFactory = sf;
        }
        public ISessionFactory SessionFactory
        {
            get;
            set;
        }
        /// <summary>
        /// 设备数据访问类。
        /// </summary>
        public IEquipmentDataEngine EquipmentDataEngine
        {
            get;
            set;
        }

        /// <summary>
        /// 设备状态数据访问类。
        /// </summary>
        public IEquipmentStateDataEngine EquipmentStateDataEngine
        {
            get;
            set;
        }

        /// <summary>
        /// 设备状态切换数据访问类。
        /// </summary>
        public IEquipmentChangeStateDataEngine EquipmentChangeStateDataEngine
        {
            get;
            set;
        }
        /// <summary>
        /// 设备状态事件数据访问类。
        /// </summary>
        public IEquipmentStateEventDataEngine EquipmentStateEventDataEngine
        {
            get;
            set;
        }
        /// <summary>
        /// 批次数据访问类。
        /// </summary>
        public ILotDataEngine LotDataEngine
        {
            get;
            set;
        }
        /// <summary>
        /// 批次加工设备数据访问对象。
        /// </summary>
        public ILotTransactionEquipmentDataEngine LotTransactionEquipmentDataEngine
        {
            get;
            set;
        }

        /// <summary>
        /// 在批次转工单时，更新对应的设备数据。
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public MethodReturnResult Execute(ChangeParameter p)
        {
            List<Equipment> lstEquipmentDataEngineForEPUpdate = new List<Equipment>();
            List<Equipment> lstEquipmentDataEngineForEUpdate = new List<Equipment>();
            List<EquipmentStateEvent> lstEquipmentStateEventForEPInsert = new List<EquipmentStateEvent>();
            List<EquipmentStateEvent> lstEquipmentStateEventForEInsert = new List<EquipmentStateEvent>();




            MethodReturnResult result = new MethodReturnResult()
            {
                Code = 0
            };
            DateTime now = DateTime.Now;

            foreach (string lotNumber in p.LotNumbers)
            {
                Lot lot = this.LotDataEngine.Get(lotNumber);
                string equipmentCode = lot.EquipmentCode;
                //如果转工单没有选择设备，直接返回。
                if (string.IsNullOrEmpty(equipmentCode))
                {
                    return result;
                }
                //获取设备数据
                Equipment e = this.EquipmentDataEngine.Get(equipmentCode ?? string.Empty);
                if (e == null)
                {
                    return result;
                }
                //获取设备当前状态。
                EquipmentState es = this.EquipmentStateDataEngine.Get(e.StateName ?? string.Empty);
                if (es == null)
                {
                    return result;
                }

                //获取设备LOST的主键
                EquipmentState lostState = this.EquipmentStateDataEngine.Get("LOST");
                //获取设备当前状态->LOST的状态切换数据。
                EquipmentChangeState ecsToLost = this.EquipmentChangeStateDataEngine.Get(es.Key, lostState.Key);

                if (ecsToLost != null)
                {
                    //根据设备编码获取当前加工批次数据。
                    PagingConfig cfg = new PagingConfig()
                    {
                        //PageSize = 1,
                        //PageNo = 0,
                        IsPaging=false,
                        Where = string.Format("EquipmentCode='{0}' AND STATE='{1}'"
                                                , equipmentCode
                                                , Convert.ToInt32(EnumLotTransactionEquipmentState.Start))
                    };
                    IList<LotTransactionEquipment> lst = this.LotTransactionEquipmentDataEngine.Get(cfg);
                    if (lst.Count > 0)//设备当前加工批次>0，则直接返回。
                    {
                        return result;
                    }
                    //更新父设备状态。
                    if (!string.IsNullOrEmpty(e.ParentEquipmentCode))
                    {
                        Equipment ep = this.EquipmentDataEngine.Get(e.ParentEquipmentCode);
                        if (ep != null)
                        {
                            Equipment epUpdate = ep.Clone() as Equipment;
                            //更新设备状态。
                            epUpdate.StateName = lostState.Key;
                            epUpdate.ChangeStateName = ecsToLost.Key;
                            //this.EquipmentDataEngine.Update(epUpdate);
                            lstEquipmentDataEngineForEPUpdate.Add(epUpdate);
                            //新增设备状态事件数据
                            EquipmentStateEvent newStateEvent = new EquipmentStateEvent()
                            {
                                Key = Guid.NewGuid().ToString(),
                                CreateTime = now,
                                Creator = p.Creator,
                                Description = p.Remark,
                                Editor = p.Creator,
                                EditTime = now,
                                EquipmentChangeStateName = ecsToLost.Key,
                                EquipmentCode = e.ParentEquipmentCode,
                                EquipmentFromStateName = es.Key,
                                EquipmentToStateName = lostState.Key,
                                IsCurrent = true
                            };
                            //this.EquipmentStateEventDataEngine.Insert(newStateEvent);
                            lstEquipmentStateEventForEPInsert.Add(newStateEvent);
                        }
                    }
                    //更新设备状态。
                    Equipment eUpdate = e.Clone() as Equipment;
                    eUpdate.StateName = lostState.Key;
                    eUpdate.ChangeStateName = ecsToLost.Key;
                    //this.EquipmentDataEngine.Update(eUpdate);
                    lstEquipmentDataEngineForEUpdate.Add(eUpdate);
                    //新增设备状态事件数据
                    EquipmentStateEvent stateEvent = new EquipmentStateEvent()
                    {
                        Key = Guid.NewGuid().ToString(),
                        CreateTime = now,
                        Creator = p.Creator,
                        Description = p.Remark,
                        Editor = p.Creator,
                        EditTime = now,
                        EquipmentChangeStateName = ecsToLost.Key,
                        EquipmentCode = e.Key,
                        EquipmentFromStateName = es.Key,
                        EquipmentToStateName = lostState.Key,
                        IsCurrent = true
                    };
                    // this.EquipmentStateEventDataEngine.Insert(stateEvent);
                    lstEquipmentStateEventForEInsert.Add(stateEvent);
                }
            }


            #region 开始事务
            ITransaction transaction = null;
            ISession db = this.SessionFactory.OpenSession();
            transaction = db.BeginTransaction();
            try
            {
                foreach (Equipment obj in lstEquipmentDataEngineForEPUpdate)
                {
                    this.EquipmentDataEngine.Update(obj, db);
                }
                foreach (Equipment obj in lstEquipmentDataEngineForEUpdate)
                {
                    this.EquipmentDataEngine.Update(obj, db);
                }
                foreach (EquipmentStateEvent obj in lstEquipmentStateEventForEPInsert)
                {
                    this.EquipmentStateEventDataEngine.Insert(obj, db);
                }
                foreach (EquipmentStateEvent obj in lstEquipmentStateEventForEInsert)
                {
                    this.EquipmentStateEventDataEngine.Insert(obj, db);
                }

                transaction.Commit();
                db.Close();
            }
            catch (Exception err)
            {
                transaction.Rollback();
                db.Close();
                result.Code = 1000;
                result.Message += string.Format(StringResource.Error, err.Message);
                result.Detail = err.ToString();
                return result;
            }
            #endregion
            return result;
        }

    }
}

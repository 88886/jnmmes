﻿using ServiceCenter.Client.Mvc.Areas.ZPVM.Models;
using ZPVMResources = ServiceCenter.Client.Mvc.Resources.ZPVM;
using ServiceCenter.MES.Model.ZPVM;
using ServiceCenter.MES.Service.Client.ZPVM;
using ServiceCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ServiceCenter.Client.Mvc.RDLC;
using ServiceCenter.MES.Model.WIP;
using ServiceCenter.MES.Model.FMM;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.IO;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using Microsoft.Reporting.WebForms;
using ServiceCenter.MES.Service.Client.WIP;
using ServiceCenter.MES.Service.Client.FMM;
using ServiceCenter.MES.Model.PPM;
using ServiceCenter.MES.Service.Client.PPM;
using System.Data;
using ServiceCenter.MES.Service.Contract.WIP;

namespace ServiceCenter.Client.Mvc.Areas.ZPVM.Controllers
{
    public class WorkOrderPrintSetController : Controller
    {
        //
        // GET: /ZPVM/WorkOrderPrintSet/
        public async Task<ActionResult> Index(string OrderNumber, string MaterialCode)
        {
            if (string.IsNullOrEmpty(OrderNumber) || string.IsNullOrEmpty(MaterialCode))
            {
                return RedirectToAction("Index", "WorkOrderRule");
            }

            using (WorkOrderRuleServiceClient client = new WorkOrderRuleServiceClient())
            {
                MethodReturnResult<WorkOrderRule> result = await client.GetAsync(new WorkOrderRuleKey()
                {
                   OrderNumber=OrderNumber,
                   MaterialCode=MaterialCode
                });

                if (result.Code > 0 || result.Data == null)
                {
                    return RedirectToAction("Index", "WorkOrderRule");
                }
                ViewBag.Rule = result.Data;
            }

            using (WorkOrderPrintSetServiceClient client = new WorkOrderPrintSetServiceClient())
            {
                await Task.Run(() =>
                {
                    PagingConfig cfg = new PagingConfig()
                    {
                        Where = string.Format(" Key.OrderNumber = '{0}' AND Key.MaterialCode='{1}'"
                                              , OrderNumber
                                              , MaterialCode),
                        OrderBy = "Key"
                    };
                    MethodReturnResult<IList<WorkOrderPrintSet>> result = client.Get(ref cfg);

                    if (result.Code == 0)
                    {
                        ViewBag.PagingConfig = cfg;
                        ViewBag.List = result.Data;
                    }
                });
            }
            return View(new WorkOrderPrintSetQueryViewModel() { OrderNumber = OrderNumber, MaterialCode = MaterialCode });
        }

        //
        //POST: /ZPVM/WorkOrderPrintSet/Query
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Query(WorkOrderPrintSetQueryViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (WorkOrderPrintSetServiceClient client = new WorkOrderPrintSetServiceClient())
                {
                    await Task.Run(() =>
                    {
                        StringBuilder where = new StringBuilder();
                        if (model != null)
                        {
                            where.AppendFormat(" Key.OrderNumber = '{0}' AND Key.MaterialCode='{1}'"
                                              , model.OrderNumber
                                              , model.MaterialCode);

                        }
                        PagingConfig cfg = new PagingConfig()
                        {
                            OrderBy = "Key",
                            Where = where.ToString()
                        };
                        MethodReturnResult<IList<WorkOrderPrintSet>> result = client.Get(ref cfg);

                        if (result.Code == 0)
                        {
                            ViewBag.PagingConfig = cfg;
                            ViewBag.List = result.Data;
                        }
                    });
                }
            }
            return PartialView("_ListPartial");
        }
        //
        //POST: /ZPVM/WorkOrderPrintSet/PagingQuery
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PagingQuery(string where, string orderBy, int? currentPageNo, int? currentPageSize)
        {
            if (ModelState.IsValid)
            {
                int pageNo = currentPageNo ?? 0;
                int pageSize = currentPageSize ?? 20;
                if (Request["PageNo"] != null)
                {
                    pageNo = Convert.ToInt32(Request["PageNo"]);
                }
                if (Request["PageSize"] != null)
                {
                    pageSize = Convert.ToInt32(Request["PageSize"]);
                }

                using (WorkOrderPrintSetServiceClient client = new WorkOrderPrintSetServiceClient())
                {
                    await Task.Run(() =>
                    {
                        PagingConfig cfg = new PagingConfig()
                        {
                            PageNo = pageNo,
                            PageSize = pageSize,
                            Where = where ?? string.Empty,
                            OrderBy = orderBy ?? string.Empty
                        };
                        MethodReturnResult<IList<WorkOrderPrintSet>> result = client.Get(ref cfg);
                        if (result.Code == 0)
                        {
                            ViewBag.PagingConfig = cfg;
                            ViewBag.List = result.Data;
                        }
                    });
                }
            }
            return PartialView("_ListPartial");
        }
        //
        // POST: /ZPVM/WorkOrderPrintSet/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(WorkOrderPrintSetViewModel model)
        {
            using (WorkOrderPrintSetServiceClient client = new WorkOrderPrintSetServiceClient())
            {
                WorkOrderPrintSet obj = new WorkOrderPrintSet()
                {
                    Key = new WorkOrderPrintSetKey(){
                        MaterialCode=model.MaterialCode,
                        OrderNumber=model.OrderNumber,
                        LabelCode=model.LabelCode
                    },
                    ItemNo = model.ItemNo ?? 0,
                    Qty = model.Qty ?? 1,
                    IsUsed = model.IsUsed,
                    Editor = User.Identity.Name,
                    EditTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    Creator = User.Identity.Name
                };
                MethodReturnResult rst = await client.AddAsync(obj);
                if (rst.Code == 0)
                {
                    rst.Message = string.Format(ZPVMResources.StringResource.WorkOrderPrintSet_Save_Success
                                                , obj.Key);
                }
                return Json(rst);
            }
        }
        //
        // GET: /ZPVM/WorkOrderPrintSet/Modify
        public async Task<ActionResult> Modify(string OrderNumber, string MaterialCode, string labelCode)
        {
            WorkOrderPrintSetViewModel viewModel = new WorkOrderPrintSetViewModel();
            using (WorkOrderPrintSetServiceClient client = new WorkOrderPrintSetServiceClient())
            {
                MethodReturnResult<WorkOrderPrintSet> result = await client.GetAsync(new WorkOrderPrintSetKey()
                {
                    MaterialCode = MaterialCode,
                    OrderNumber = OrderNumber,
                    LabelCode = labelCode
                });
                if (result.Code == 0)
                {
                    viewModel = new WorkOrderPrintSetViewModel()
                    {
                        MaterialCode = result.Data.Key.MaterialCode,
                        OrderNumber = result.Data.Key.OrderNumber,
                        LabelCode=result.Data.Key.LabelCode,
                        Qty = result.Data.Qty,
                        ItemNo = result.Data.ItemNo,
                        IsUsed = result.Data.IsUsed,
                        CreateTime = result.Data.CreateTime,
                        Creator = result.Data.Creator,
                        Editor = result.Data.Editor,
                        EditTime = result.Data.EditTime
                    };
                    return PartialView("_ModifyPartial", viewModel);
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return PartialView("_ModifyPartial", new WorkOrderPrintSetViewModel());
        }

        //
        // POST: /ZPVM/WorkOrderPrintSet/SaveModify
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveModify(WorkOrderPrintSetViewModel model)
        {
            using (WorkOrderPrintSetServiceClient client = new WorkOrderPrintSetServiceClient())
            {
                WorkOrderPrintSetKey key = new WorkOrderPrintSetKey()
                {
                    MaterialCode = model.MaterialCode,
                    OrderNumber = model.OrderNumber,
                    LabelCode = model.LabelCode
                };
                MethodReturnResult<WorkOrderPrintSet> result = await client.GetAsync(key);

                if (result.Code == 0)
                {
                    result.Data.ItemNo = model.ItemNo ?? 0;
                    result.Data.Qty = model.Qty??0;
                    result.Data.IsUsed = model.IsUsed;
                    result.Data.Editor = User.Identity.Name;
                    result.Data.EditTime = DateTime.Now;
                    MethodReturnResult rst = await client.ModifyAsync(result.Data);
                    if (rst.Code == 0)
                    {
                        rst.Message = string.Format(ZPVMResources.StringResource.WorkOrderPrintSet_SaveModify_Success
                                                    , key);
                    }
                    return Json(rst);
                }
                return Json(result);
            }
        }
        //
        // GET: /ZPVM/WorkOrderPrintSet/Detail
        public async Task<ActionResult> Detail(string OrderNumber, string MaterialCode, string labelCode)
        {
            using (WorkOrderPrintSetServiceClient client = new WorkOrderPrintSetServiceClient())
            {
                WorkOrderPrintSetKey key = new WorkOrderPrintSetKey()
                {
                    MaterialCode = MaterialCode,
                    OrderNumber = OrderNumber,
                    LabelCode = labelCode
                };
                MethodReturnResult<WorkOrderPrintSet> result = await client.GetAsync(key);
                if (result.Code == 0)
                {
                    WorkOrderPrintSetViewModel viewModel = new WorkOrderPrintSetViewModel()
                    {
                        MaterialCode = result.Data.Key.MaterialCode,
                        OrderNumber = result.Data.Key.OrderNumber,
                        LabelCode = result.Data.Key.LabelCode,
                        Qty = result.Data.Qty,
                        ItemNo = result.Data.ItemNo,
                        IsUsed = result.Data.IsUsed,
                        CreateTime = result.Data.CreateTime,
                        Creator = result.Data.Creator,
                        Editor = result.Data.Editor,
                        EditTime = result.Data.EditTime
                    };
                    return PartialView("_InfoPartial", viewModel);
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return PartialView("_InfoPartial");
        }
        //
        // POST: /ZPVM/WorkOrderPrintSet/Delete
        [HttpPost]
        public async Task<ActionResult> Delete(string OrderNumber, string MaterialCode, string labelCode)
        {
            MethodReturnResult result = new MethodReturnResult();
            WorkOrderPrintSetKey key = new WorkOrderPrintSetKey()
            {
                MaterialCode = MaterialCode,
                OrderNumber = OrderNumber,
                LabelCode = labelCode
            };
            using (WorkOrderPrintSetServiceClient client = new WorkOrderPrintSetServiceClient())
            {
                result = await client.DeleteAsync(key);
                if (result.Code == 0)
                {
                    result.Message = string.Format(ZPVMResources.StringResource.WorkOrderPrintSet_Delete_Success
                                                    , key);
                }
                return Json(result);
            }
        }

        #region 标签预览
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShowPackageListReport(string orderNumber, string labelCode, string materialCode)
        {
            return ShowReport(orderNumber, labelCode, materialCode);
            //return ShowPrintView(orderNumber, labelCode, materialCode);
        }

        [AllowAnonymous]
        public ActionResult ShowReport(string orderNumber, string labelCode, string materialCode)
        {
            MethodReturnResult result = new MethodReturnResult();
            PackingListPrintQueryViewModel model = new PackingListPrintQueryViewModel();
            model.IsAutoPackageNo = false;
            model.PackageNo = "";

            #region 获取工单内首次创建且不为零托号
            using (PackageQueryServiceClient packageQueryServiceClient = new PackageQueryServiceClient())
            {
                PagingConfig cfg = new PagingConfig()
                {
                    PageSize = 1,
                    OrderBy = "CreateTime ",
                    Where = string.Format(@" OrderNumber = '{0}'",orderNumber)
                };
                MethodReturnResult<IList<Package>> lstPackage = packageQueryServiceClient.Get(ref cfg);
                if (lstPackage.Data != null && lstPackage.Data.Count > 0)
                {
                    model.PackageNo = lstPackage.Data[0].Key;
                }
            }
            #endregion

            #region 包装号不为空
            if (model.PackageNo != "")
            {              
                PackageListDataSet ds = new PackageListDataSet();
                IList<PackageDetail> lstPackageDetail = new List<PackageDetail>();
                IList<IVTestData> lstIVTestData = new List<IVTestData>();
                IList<Lot> lstLot = new List<Lot>();

                #region
                try
                {
                    string color = null;
                    string pscode = null;
                    string psitemno = null;
                    string pssubcode = null;
                    double qty = 0;
                    string grade = null;                    

                    //获取打印包装清单相关的数据
                    using (PackageQueryServiceClient client = new PackageQueryServiceClient())
                    {
                        RPTpackagelistParameter param = new RPTpackagelistParameter();  //参数
                        if (model.PackageNo != null || model.PackageNo != "")
                        {
                            param.PackageNo = model.PackageNo; //包装号
                        }
                        PagingConfig cfg = new PagingConfig()
                        {
                            OrderBy = "Key.PackageNo,ItemNo ASC",
                        };
                        MethodReturnResult<DataSet> dt = client.GetRPTpackagelist(param);
                        ViewBag.HistoryList = dt;
                        MethodReturnResult<DataSet> dtOfOEM = client.GetOEMpackagelist(param);
                        if (dtOfOEM.Data != null && dtOfOEM.Data.Tables.Count > 0 && dtOfOEM.Data.Tables[0].Rows.Count > 0)
                        {
                            DataTable oemDataTable = new DataTable();
                            oemDataTable = dtOfOEM.Data.Tables[0];
                            oemDataTable.TableName = "OemDataTable";
                            dt.Data.Tables.Add(oemDataTable.Copy());
                        }

                        //判断批次是否存在
                        if (dt.Code > 0 || dt.Data == null)
                        {
                            return Content(string.Format("未找到批次号{0}的信息。", model.LotNumber1));
                        }
                        else
                        {
                            if (dt.Data.Tables[0] != null && dt.Data.Tables[0].Rows.Count > 0)
                            {
                                orderNumber = dt.Data.Tables[0].Rows[0]["ORDER_NUMBER"].ToString();  //工单号(第一行数据的工单号)
                                materialCode = dt.Data.Tables[0].Rows[0]["MATERIAL_CODE"].ToString();//物料编码
                                color = dt.Data.Tables[0].Rows[0]["COLOR"].ToString();
                                pscode = dt.Data.Tables[0].Rows[0]["PS_CODE"].ToString();
                                psitemno = dt.Data.Tables[0].Rows[0]["PS_ITEM_NO"].ToString();
                                pssubcode = dt.Data.Tables[0].Rows[0]["PS_SUBCODE"].ToString();
                                grade = dt.Data.Tables[0].Rows[0]["GRADE"].ToString();
                            }
                            else if (dtOfOEM.Data != null && dtOfOEM.Data.Tables.Count > 0 && dtOfOEM.Data.Tables[0].Rows.Count > 0)
                            {
                                orderNumber = dt.Data.Tables[1].Rows[0]["ORDER_NUMBER"].ToString();  //工单号(第一行数据的工单号)
                                materialCode = dt.Data.Tables[1].Rows[0]["MATERIAL_CODE"].ToString();//物料编码
                                color = dt.Data.Tables[1].Rows[0]["COLOR"].ToString();
                                pscode = dt.Data.Tables[1].Rows[0]["PS_CODE"].ToString();
                                psitemno = dt.Data.Tables[1].Rows[0]["PS_ITEM_NO"].ToString();
                                pssubcode = dt.Data.Tables[1].Rows[0]["PS_SUBCODE"].ToString();
                                grade = dt.Data.Tables[1].Rows[0]["GRADE"].ToString();
                            }
                            else
                            {
                                return Content(string.Format("请进行IV修正或检查批次{0}所在工单分档代码与批次IV数据中分档代码是否一致。",
                                    model.LotNumber1));
                            }
                        }


                        //判断物料编码或是工单是否为空
                        if (orderNumber == null || materialCode == null)
                        {
                            return Content(string.Format("未找到批次号{0}的工单信息。", model.LotNumber1));
                        }

                        WorkOrder workOrder = null;
                        //获取工单信息
                        using (WorkOrderServiceClient clientWorkOrder = new WorkOrderServiceClient())
                        {
                            workOrder = clientWorkOrder.Get(orderNumber).Data;
                        }

                        //根据工单规则获取满包数量
                        using (WorkOrderRuleServiceClient clientWorkOrderProduct = new WorkOrderRuleServiceClient())
                        {
                            WorkOrderRuleKey WorkOrderRuleKey = new WorkOrderRuleKey()
                            {
                                OrderNumber = orderNumber,
                                MaterialCode = materialCode
                            };
                            MethodReturnResult<WorkOrderRule> resultWorkOrderRule = clientWorkOrderProduct.Get(WorkOrderRuleKey);
                            qty = resultWorkOrderRule.Data.FullPackageQty;
                        }

                        if (qty == 0)
                        {
                            return Content(string.Format("未找到批次号{0}的满包数量。", model.LotNumber1));
                        }

                        //获取包装数据清单
                        string strPackagePrintLabel = this.GetPackagePrintLabel(dt, orderNumber, materialCode);
                        bool blIsEnglish = false;

                        if (strPackagePrintLabel != "" && strPackagePrintLabel.Length > 0)
                        {
                            if (strPackagePrintLabel.IndexOf("EN") > 0)
                            {
                                blIsEnglish = true;
                            }
                        }

                        //获取工单分档规则
                        WorkOrderPowerset wop = null;
                        if (dt.Data != null && pscode != null)
                        {
                            using (WorkOrderPowersetServiceClient client1 = new WorkOrderPowersetServiceClient())
                            {
                                MethodReturnResult<WorkOrderPowerset> result1 = client1.Get(new WorkOrderPowersetKey()
                                {
                                    Code = pscode,
                                    ItemNo = Convert.ToInt16(psitemno),
                                    OrderNumber = orderNumber,
                                    MaterialCode = materialCode
                                });
                                wop = result1.Data;
                            }
                        }
                        else
                        {
                            return Content(string.Format("批次{0}所在工单未设置分档", model.LotNumber1));
                        }

                        //根据物料编码获取物料数据，进一步获取产品类型。
                        Material material = null;
                        using (MaterialServiceClient client2 = new MaterialServiceClient())
                        {
                            MethodReturnResult<Material> result2 = client2.Get(materialCode);
                            if (result2.Code > 0)
                            {
                                return Content(result2.Message);
                            }
                            material = result2.Data;
                        }

                        //根据工单获取工单电池片类型属性数据
                        WorkOrderAttribute workOrderAttribute = null;
                        using (WorkOrderAttributeServiceClient clientOfOrderMattr = new WorkOrderAttributeServiceClient())
                        {
                            WorkOrderAttributeKey workOrderAttributeKey = new WorkOrderAttributeKey()
                            {
                                OrderNumber = orderNumber,
                                AttributeName = "CellType"
                            };

                            MethodReturnResult<WorkOrderAttribute> result2 = clientOfOrderMattr.Get(workOrderAttributeKey);
                            workOrderAttribute = result2.Data;
                        }

                        //根据包装号获取柜号信息
                        Package packageToChest = null;
                        string chestOfPackage = "";
                        using (PackageQueryServiceClient clientOfPackage = new PackageQueryServiceClient())
                        {
                            MethodReturnResult<Package> result2 = clientOfPackage.Get(model.PackageNo);
                            packageToChest = result2.Data;
                            if (packageToChest != null
                                && packageToChest.ContainerNo != null
                                && packageToChest.ContainerNo != "")
                            {
                                chestOfPackage = packageToChest.ContainerNo.Trim();
                            }
                        }

                        //组件包装数据。
                        PackageListDataSet.PackageRow row = ds.Package.NewPackageRow();
                        if (strPackagePrintLabel == "PackageList_SunEN.rdlc")
                        {
                            row.ProductType = string.Format("SE-{1}{0}NPB-A4"
                                                        , wop == null ? string.Empty : Convert.ToString(wop.StandardPower)
                                                        , material.Key.StartsWith("1201") ? "M" : "P");
                        }
                        else if (strPackagePrintLabel == "PackageList_PERC.rdlc")
                        {
                            int indexOfType = material.Name.IndexOf('-');
                            row.ProductType = string.Format("{0}-{1}"
                                                        , material.Name.Substring(0, indexOfType)
                                                        , wop.PowerName.Substring(0, 3));

                        }
                        //协鑫72包装清单 《产品规格》
                        else if (strPackagePrintLabel == "XXPackageList.rdlc")
                        {
                            if (wop.PowerName == "325W")
                            {
                                row.ProductType = "GCL-P6/72325";
                            }
                            else if (wop.PowerName == "320W")
                            {
                                row.ProductType = "ZKX-320P-24";
                            }
                            else
                            {
                                row.ProductType = "Test123:" + wop.PowerName;
                            }
                        }
                        //晋能档位转换清单
                        else if (strPackagePrintLabel == "晋能.rdlc")
                        {
                            if (wop.PowerName == "特定功率")
                            {
                                wop.PowerName = "特定功率";
                                row.ProductType = string.Format("{0}{1}-{2}"
                                                        , material.Name.Substring(0, 4)
                                                        , material.MainRawQtyPerLot
                                                        , wop.PowerName.Substring(0, 3));
                            }
                            else
                            {
                                row.ProductType = string.Format("{0}{1}-{2}"
                                                        , material.Name.Substring(0, 4)
                                                        , material.MainRawQtyPerLot
                                                        , wop.PowerName.Substring(0, 3));
                            }
                        }
                        //SE单晶60包装清单
                        else if (strPackagePrintLabel == "SEPackageList-EN.rdlc")
                        {
                            MaterialAttribute materialAttributes = null;
                            using (MaterialAttributeServiceClient clientOfMaterialAttribute = new MaterialAttributeServiceClient())
                            {
                                MaterialAttributeKey materialAttributeKey = new MaterialAttributeKey()
                                {
                                    MaterialCode = materialCode,
                                    AttributeName = "ProductType"
                                };
                                MethodReturnResult<MaterialAttribute> resultOfMaterialAttribute = clientOfMaterialAttribute.Get(materialAttributeKey);
                                if (resultOfMaterialAttribute.Code > 0)
                                {
                                    return Content(resultOfMaterialAttribute.Message);
                                }
                                materialAttributes = resultOfMaterialAttribute.Data;
                            }
                            //获取包装第一块明细数据。
                            using (PackageQueryServiceClient packageClientOfSE = new PackageQueryServiceClient())
                            {
                                PagingConfig cfgSE = new PagingConfig()
                                {
                                    IsPaging = false,
                                    Where = string.Format("ItemNo='1' AND Key.PackageNo='{0}'", model.PackageNo),
                                    OrderBy = "ItemNo"
                                };
                                MethodReturnResult<IList<PackageDetail>> packageDetailresultOfSE = packageClientOfSE.GetDetail(ref cfgSE);
                                if (packageDetailresultOfSE.Code > 0 || packageDetailresultOfSE.Data == null || packageDetailresultOfSE.Data.Count == 0)
                                {
                                    return Content(string.Format("未获取到包装号{0}的第一块组件包装明细信息", model.PackageNo));
                                }
                                else
                                {
                                    PackageDetail obj = packageDetailresultOfSE.Data.FirstOrDefault();
                                    if (obj != null)
                                    {
                                        using (LotQueryServiceClient lotClientOfSE = new LotQueryServiceClient())
                                        {
                                            MethodReturnResult<Lot> lotResultOfSE = lotClientOfSE.Get(obj.Key.ObjectNumber);

                                            if (lotResultOfSE.Code == 0 && lotResultOfSE.Data != null)
                                            {
                                                string valueOf = materialAttributes.Value.Trim();
                                                int indexOfType1 = valueOf.IndexOf('*');
                                                if (lotResultOfSE.Data.Attr3 != null && lotResultOfSE.Data.Attr3 != "")
                                                {
                                                    row.ProductType = string.Format("S{0}{1}-{2}{3}-1WA"
                                                                        , valueOf.Substring(0, indexOfType1)
                                                                        , wop.PowerName.Substring(0, 3)
                                                                        , material.MainRawQtyPerLot
                                                                        , valueOf.Substring(valueOf.Length - 3)
                                                                    );
                                                }
                                                else
                                                {
                                                    row.ProductType = string.Format("{0}{1}-{2}{3}-1WA"
                                                                        , valueOf.Substring(0, indexOfType1)
                                                                        , wop.PowerName.Substring(0, 3)
                                                                        , material.MainRawQtyPerLot
                                                                        , valueOf.Substring(valueOf.Length - 3)
                                                                    );
                                                }
                                            }
                                            else
                                            {
                                                return Content(string.Format("未获取到包装号{0}的第一块组件{1}批次信息", model.PackageNo, obj.Key.ObjectNumber));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        return Content(string.Format("未获取到包装号{0}的第一块组件包装明细信息", model.PackageNo));
                                    }
                                }
                            }
                        }

                        else if (material.Key == "1202020119" || material.Key == "1202020121")
                        {
                            row.ProductType = string.Format("YL-{0}P-29b"
                                                        , wop.PowerName.Substring(0, 3));
                        }
                        //晋能常规清单
                        else
                        {
                            int indexOfType = material.Name.IndexOf('-');
                            if (indexOfType > 0)
                            {
                                row.ProductType = string.Format("{0}-{1}"
                                                        , material.Name.Substring(0, indexOfType)
                                                        , wop.PowerName.Substring(0, 3));
                            }
                            else
                            {
                                row.ProductType = string.Format("{0}-{1}"
                                                        , material.Name.Substring(0, 6)
                                                        , wop.PowerName.Substring(0, 3));
                            }
                        }

                        row.MaterialClass = material.Class;                                      //物料类型
                        row.ProductSpec = material.Spec;                                         //产品规格
                        row.Description = material.Description;                                  //描述
                        row.OrderNumber = orderNumber;                                           //工单
                        row.PackageNo = model.PackageNo;                                         //包装号

                        if (dt.Data.Tables.Count > 1 && dt.Data.Tables[1] != null && dt.Data.Tables[1].Rows.Count > 0)       //总数
                        {
                            row.Count = (dt.Data.Tables[0].Rows.Count + dt.Data.Tables[1].Rows.Count).ToString();
                        }
                        else
                        {
                            row.Count = dt.Data.Tables[0].Rows.Count.ToString();
                        }

                        row.PowerName = wop == null ? string.Empty : wop.PowerName;
                        row.PowerTolerance = wop == null ? string.Empty : wop.PowerDifference;

                        row.Color = color;

                        if (blIsEnglish)
                        {
                            row.OrderNumber = orderNumber.Substring(4, 8);
                            if (strPackagePrintLabel == "SEPackageList-EN.rdlc")
                            {
                                if (row.Color == "深蓝")
                                {
                                    row.Color = "Dark Blue";
                                }
                                if (row.Color == "浅蓝")
                                {
                                    row.Color = "Light Blue";
                                }
                                if (row.Color == "正蓝")
                                {
                                    row.Color = "Blue";
                                }
                            }
                            else
                            {
                                //Light blue，Blue，Dark blue（3选1）
                                if (row.Color == "深蓝")
                                {
                                    row.Color = "Navy Blue";
                                }
                                if (row.Color == "浅蓝")
                                {
                                    row.Color = "baby Blue";
                                }
                                if (row.Color == "正蓝")
                                {
                                    row.Color = "Blue";
                                }
                                row.PowerName = wop == null ? string.Empty : wop.PowerName.Substring(0, 3);
                            }
                        }
                        else
                        {
                            if (strPackagePrintLabel == "YL-JN-PackageList-2.rdlc")
                            {
                                if (row.Color == "深蓝")
                                {
                                    row.Color = "C3";
                                }
                                if (row.Color == "浅蓝")
                                {
                                    row.Color = "C2";
                                }
                            }
                            else
                            {
                                if (row.Color == "深蓝")
                                {
                                    row.Color = "Dark Blue/深蓝";
                                }
                                if (row.Color == "浅蓝")
                                {
                                    row.Color = "Light Blue/浅蓝";
                                }
                                if (row.Color == "正蓝")
                                {
                                    row.Color = "Blue/正蓝";
                                }
                            }
                        }

                        #region 协鑫永能/晋能/张家港电池片类型加颜色
                        if (workOrderAttribute != null)
                        {
                            string attrOfOrderCell = workOrderAttribute.AttributeValue.Trim();
                            if (row.Color == "Dark Blue/深蓝")
                            {
                                row.CellType = attrOfOrderCell + "D";
                            }
                            else if (row.Color == "Light Blue/浅蓝")
                            {
                                row.CellType = attrOfOrderCell + "L";
                            }
                            else
                            {
                                row.CellType = attrOfOrderCell;
                            }
                        }
                        #endregion

                        #region 协鑫永能/晋能/张家港柜号流水号
                        row.ChestNo = chestOfPackage;
                        #endregion

                        #region 协鑫张家港或晋能ORDER NO: 103A车间：D001 / 102A车间：D002 / 102B车间：D003
                        if (row.PackageNo.Substring(0, 3) == "27M" || row.PackageNo.Substring(0, 3) == "27P"
                            || row.PackageNo.Substring(0, 3) == "64M" || row.PackageNo.Substring(0, 3) == "64P")
                        {
                            if (workOrder.LocationName == "103A")
                            {
                                row.OrderNumber = "D001";
                            }
                            if (workOrder.LocationName == "102A")
                            {
                                row.OrderNumber = "D002";
                            }
                            if (workOrder.LocationName == "102B")
                            {
                                row.OrderNumber = "D003";
                            }
                        }
                        #endregion

                        row.PowerSubCode = pssubcode;
                        row.MaterialCode = materialCode;
                        IList<string> lstColor = new List<string>();    //托内颜色数组
                        string sColor = "";
                        string sFullColor = "";
                        bool isfind = false;
                        string packageLots = "";
                        string sss = "";

                        #region 德国
                        if (strPackagePrintLabel == "GERMAN.rdlc")
                        {
                            if (dt.Data != null && dt.Data.Tables.Count > 1)
                            {
                                if (dt.Data.Tables[0].Rows.Count > 0)
                                {
                                    for (int j = 0; j < dt.Data.Tables[0].Rows.Count; j++)
                                    {
                                        packageLots += dt.Data.Tables[0].Rows[j]["OBJECT_NUMBER"].ToString() + ";";
                                    }
                                }
                                if (dt.Data.Tables[1].Rows.Count > 0)
                                {
                                    for (int j = 0; j < dt.Data.Tables[1].Rows.Count; j++)
                                    {
                                        packageLots += dt.Data.Tables[1].Rows[j]["OBJECT_NUMBER"].ToString() + ";";
                                    }
                                }
                            }
                            else
                            {
                                for (int j = 0; j < dt.Data.Tables[0].Rows.Count; j++)
                                {
                                    packageLots += dt.Data.Tables[0].Rows[j]["OBJECT_NUMBER"].ToString() + ";";
                                }
                            }
                            Image img = QRCodeSave(packageLots);
                            byte[] packageLotNosOfByte = ImageToBytes(img);
                            sss = ConvertImageToBase64(img, ImageFormat.Png);
                            row.PackageLotNos = packageLotNosOfByte;
                            //row.PackageLotNos = sss;
                        }
                        #endregion

                        for (int j = 0; j < dt.Data.Tables[0].Rows.Count; j++)
                        {
                            //添加包装明细
                            PackageListDataSet.PackageDetailRow detailRow = ds.PackageDetail.NewPackageDetailRow();
                            detailRow.PackageNo = dt.Data.Tables[0].Rows[j]["PACKAGE_NO"].ToString();
                            detailRow.ItemNo = Convert.ToInt16(dt.Data.Tables[0].Rows[j]["ITEM_NO"].ToString());
                            detailRow.LotNo = dt.Data.Tables[0].Rows[j]["OBJECT_NUMBER"].ToString();
                            detailRow.IMP = dt.Data.Tables[0].Rows[j]["COEF_IMAX"].ToString();
                            detailRow.ISC = dt.Data.Tables[0].Rows[j]["COEF_ISC"].ToString();
                            detailRow.PM = dt.Data.Tables[0].Rows[j]["COEF_PMAX"].ToString();
                            detailRow.VMP = dt.Data.Tables[0].Rows[j]["COEF_VMAX"].ToString();
                            detailRow.VOC = dt.Data.Tables[0].Rows[j]["COEF_VOC"].ToString();
                            detailRow.FF = dt.Data.Tables[0].Rows[j]["COEF_FF"].ToString();
                            detailRow.PowerSubCode = dt.Data.Tables[0].Rows[j]["PS_SUBCODE"].ToString();
                            ds.PackageDetail.AddPackageDetailRow(detailRow);

                            //将不同的颜色加入颜色数组
                            #region
                            sColor = dt.Data.Tables[0].Rows[j]["COLOR"].ToString();

                            if (blIsEnglish)
                            {
                                if (strPackagePrintLabel == "SEPackageList-EN.rdlc")
                                {
                                    if (sColor == "深蓝")
                                    {
                                        sColor = "Dark Blue";
                                    }
                                    if (sColor == "浅蓝")
                                    {
                                        sColor = "Light Blue";
                                    }
                                    if (sColor == "正蓝")
                                    {
                                        sColor = "Blue";
                                    }
                                }
                                else
                                {
                                    //Light blue，Blue，Dark blue（3选1）
                                    if (sColor == "深蓝")
                                    {
                                        sColor = "Navy Blue";
                                    }
                                    if (sColor == "浅蓝")
                                    {
                                        sColor = "baby Blue";
                                    }
                                    if (sColor == "正蓝")
                                    {
                                        sColor = "Blue";
                                    }
                                }
                            }
                            else
                            {
                                if (sColor == "深蓝")
                                {
                                    sColor = "Dark Blue/深蓝";
                                }
                                if (sColor == "浅蓝")
                                {
                                    sColor = "Light Blue/浅蓝";
                                }
                                if (sColor == "正蓝")
                                {
                                    sColor = "Blue/正蓝";
                                }
                            }

                            isfind = false;

                            //判断颜色是否存在
                            foreach (string s in lstColor)
                            {
                                if (s == sColor)
                                {
                                    isfind = true;

                                    break;
                                }
                            }

                            if (!isfind)
                            {
                                lstColor.Add(sColor);

                                if (sFullColor == "")
                                {
                                    sFullColor = sColor;
                                }
                                else
                                {
                                    sFullColor += "\\" + sColor;
                                }

                            }
                            #endregion
                        }

                        if (dt.Data.Tables.Count > 1)
                        {
                            for (int j = 0; j < dt.Data.Tables[1].Rows.Count; j++)
                            {
                                //添加包装明细
                                PackageListDataSet.PackageDetailRow detailRow = ds.PackageDetail.NewPackageDetailRow();
                                detailRow.PackageNo = dt.Data.Tables[1].Rows[j]["PACKAGE_NO"].ToString();
                                detailRow.ItemNo = Convert.ToInt16(dt.Data.Tables[1].Rows[j]["ITEM_NO"].ToString());
                                detailRow.LotNo = dt.Data.Tables[1].Rows[j]["OBJECT_NUMBER"].ToString();
                                detailRow.IMP = dt.Data.Tables[1].Rows[j]["COEF_IMAX"].ToString();
                                detailRow.ISC = dt.Data.Tables[1].Rows[j]["COEF_ISC"].ToString();
                                detailRow.PM = dt.Data.Tables[1].Rows[j]["COEF_PMAX"].ToString();
                                detailRow.VMP = dt.Data.Tables[1].Rows[j]["COEF_VMAX"].ToString();
                                detailRow.VOC = dt.Data.Tables[1].Rows[j]["COEF_VOC"].ToString();
                                detailRow.FF = dt.Data.Tables[1].Rows[j]["COEF_FF"].ToString();
                                detailRow.PowerSubCode = dt.Data.Tables[1].Rows[j]["PS_SUBCODE"].ToString();
                                ds.PackageDetail.AddPackageDetailRow(detailRow);

                                //将不同的颜色加入颜色数组
                                #region
                                sColor = dt.Data.Tables[1].Rows[j]["COLOR"].ToString();

                                if (blIsEnglish)
                                {
                                    if (strPackagePrintLabel == "SEPackageList-EN.rdlc")
                                    {
                                        if (sColor == "深蓝")
                                        {
                                            sColor = "Dark Blue";
                                        }
                                        if (sColor == "浅蓝")
                                        {
                                            sColor = "Light Blue";
                                        }
                                        if (sColor == "正蓝")
                                        {
                                            sColor = "Blue";
                                        }
                                    }
                                    else
                                    {
                                        //Light blue，Blue，Dark blue（3选1）
                                        if (sColor == "深蓝")
                                        {
                                            sColor = "Navy Blue";
                                        }
                                        if (sColor == "浅蓝")
                                        {
                                            sColor = "baby Blue";
                                        }
                                        if (sColor == "正蓝")
                                        {
                                            sColor = "Blue";
                                        }
                                    }
                                }
                                else
                                {
                                    if (sColor == "深蓝")
                                    {
                                        sColor = "Dark Blue/深蓝";
                                    }
                                    if (sColor == "浅蓝")
                                    {
                                        sColor = "Light Blue/浅蓝";
                                    }
                                    if (sColor == "正蓝")
                                    {
                                        sColor = "Blue/正蓝";
                                    }
                                }

                                isfind = false;

                                //判断颜色是否存在
                                foreach (string s in lstColor)
                                {
                                    if (s == sColor)
                                    {
                                        isfind = true;

                                        break;
                                    }
                                }

                                if (!isfind)
                                {
                                    lstColor.Add(sColor);

                                    if (sFullColor == "")
                                    {
                                        sFullColor = sColor;
                                    }
                                    else
                                    {
                                        sFullColor += "\\" + sColor;
                                    }

                                }

                                #endregion
                            }
                        }

                        if (strPackagePrintLabel == "PackageList_DongFangEN.rdlc")
                        {
                            row.Color = sFullColor;
                        }

                        ds.Package.AddPackageRow(row);

                        if (dt.Data.Tables.Count >= 1)
                        {
                            for (int i = ds.PackageDetail.Rows.Count; i < 29; i++)
                            {
                                PackageListDataSet.PackageDetailRow detailRow = ds.PackageDetail.NewPackageDetailRow();
                                detailRow.PackageNo = row.PackageNo;
                                detailRow.ItemNo = i + 1;
                                detailRow.LotNo = null;
                                ds.PackageDetail.AddPackageDetailRow(detailRow);
                            }
                        }

                        using (LocalReport localReport = new LocalReport())
                        {
                            if (model.PackageListType == EnumPackageListType.Normal)
                            {
                                if (grade != "A")
                                {
                                    localReport.ReportPath = Server.MapPath(string.Format("~/RDLC/{0}", "PackageList_BD.rdlc"));
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(strPackagePrintLabel) == false && strPackagePrintLabel.Length > 0)
                                    {
                                        localReport.ReportPath = Server.MapPath(string.Format("~/RDLC/{0}", strPackagePrintLabel));
                                    }
                                    else
                                    {
                                        localReport.ReportPath = Server.MapPath("~/RDLC/PackageList_New.rdlc");
                                    }
                                }
                            }
                            else
                            {
                                //localReport.ReportPath = Server.MapPath("~/RDLC/PackageList_P.rdlc");
                                localReport.ReportPath = Server.MapPath("~/RDLC/PackageList_PackageNo.rdlc");
                            }
                            ReportDataSource reportDataSourcePackage = new ReportDataSource("Package", ds.Tables[ds.Package.TableName]);
                            localReport.DataSources.Add(reportDataSourcePackage);
                            ReportDataSource reportDataSourcePackageDetail = new ReportDataSource("PackageDetail", ds.Tables[ds.PackageDetail.TableName]);
                            localReport.DataSources.Add(reportDataSourcePackageDetail);
                            string reportType = "PDF";
                            string mimeType;
                            string encoding;
                            string fileNameExtension;
                            //The DeviceInfo settings should be changed based on the reportType
                            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
                            string deviceInfo =
                                            "<DeviceInfo>" +
                                            "  <OutputFormat>PDF</OutputFormat>" +
                                            "</DeviceInfo>";
                            Warning[] warnings;
                            string[] streams;
                            byte[] renderedBytes;
                            //Render the report
                            renderedBytes = localReport.Render(
                                reportType,
                                deviceInfo,
                                out mimeType,
                                out encoding,
                                out fileNameExtension,
                                out streams,
                                out warnings);
                            //Response.AddHeader("content-disposition", "attachment; filename=NorthWindCustomers." + fileNameExtension);
                            return File(renderedBytes, mimeType);
                        }
                    }
                }
                #endregion

                catch (Exception err)
                {
                    result.Code = 1005;
                    result.Message = err.Message;
                }
            }
            #endregion

            #region 包装号为空
            else
            {
                WorkOrderPrintSetViewModel workOrderPrintSetViewModel = new WorkOrderPrintSetViewModel();
                //获取标签信息
                PrintLabel label = workOrderPrintSetViewModel.GetLabel(labelCode);
                if (label.Type == EnumPrintLabelType.Box)
                {
                    PackageListDataSet ds = new PackageListDataSet();
                    IList<PackageDetail> lstPackageDetail = new List<PackageDetail>();
                    IList<IVTestData> lstIVTestData = new List<IVTestData>();
                    IList<Lot> lstLot = new List<Lot>();

                    #region
                    try
                    {
                        string pssubcode = "X";
                        int qty = 0;

                        //获取包装数据清单
                        string strPackagePrintLabel = label.Content;
                        bool blIsEnglish = false;

                        if (strPackagePrintLabel != "" && strPackagePrintLabel.Length > 0)
                        {
                            if (strPackagePrintLabel.IndexOf("EN") > 0)
                            {
                                blIsEnglish = true;
                            }
                        }

                        //根据工单规则获取满包数量
                        using (WorkOrderRuleServiceClient clientWorkOrderProduct = new WorkOrderRuleServiceClient())
                        {
                            WorkOrderRuleKey WorkOrderRuleKey = new WorkOrderRuleKey()
                            {
                                OrderNumber = orderNumber,
                                MaterialCode = materialCode
                            };
                            MethodReturnResult<WorkOrderRule> resultWorkOrderRule = clientWorkOrderProduct.Get(WorkOrderRuleKey);
                            qty = Convert.ToInt32(resultWorkOrderRule.Data.FullPackageQty);
                        }

                        if (qty == 0)
                        {
                            return Content(string.Format("未找到工单号{0}的满包数量。", orderNumber));
                        }

                        //组件包装数据。
                        PackageListDataSet.PackageRow row = ds.Package.NewPackageRow();
                        row.ProductType = "X";
                        row.MaterialClass = "X";                                     //物料类型
                        row.ProductSpec = "X";                                       //产品规格
                        row.Description = "X";                                       //描述
                        row.OrderNumber = orderNumber;                               //工单
                        row.PackageNo = "X";                                         //包装号
                        row.Count = qty.ToString();                                  //总数
                        row.PowerName = "X";
                        row.PowerTolerance = "X";
                        if (blIsEnglish)
                        {
                            row.Color = "Blue";
                        }
                        else
                        {
                            row.Color = "Blue/正蓝";
                        }

                        #region 协鑫永能/晋能/张家港电池片类型加颜色
                        row.CellType = "L";
                        #endregion

                        #region 协鑫永能/晋能/张家港柜号流水号
                        row.ChestNo = "";
                        #endregion
                        row.PowerSubCode = pssubcode;
                        row.MaterialCode = materialCode;
                        IList<string> lstColor = new List<string>();    //托内颜色数组
                        string packageLots = "X";
                        string sss = "";

                        #region 德国
                        if (strPackagePrintLabel == "GERMAN.rdlc")
                        {
                            packageLots = "XXX";
                            Image img = QRCodeSave(packageLots);
                            byte[] packageLotNosOfByte = ImageToBytes(img);
                            sss = ConvertImageToBase64(img, ImageFormat.Png);
                            row.PackageLotNos = packageLotNosOfByte;
                        }
                        #endregion

                        for (int j = 0; j < qty; j++)
                        {
                            //添加包装明细
                            PackageListDataSet.PackageDetailRow detailRow = ds.PackageDetail.NewPackageDetailRow();
                            detailRow.PackageNo = "X";
                            detailRow.ItemNo = j + 1;
                            detailRow.LotNo = "X";
                            detailRow.IMP = "X";
                            detailRow.ISC = "X";
                            detailRow.PM = "X";
                            detailRow.VMP = "X";
                            detailRow.VOC = "X";
                            detailRow.FF = "X";
                            detailRow.PowerSubCode = "X";
                            ds.PackageDetail.AddPackageDetailRow(detailRow);
                        }

                        for (int i = ds.PackageDetail.Rows.Count; i < 29; i++)
                        {
                            PackageListDataSet.PackageDetailRow detailRow = ds.PackageDetail.NewPackageDetailRow();
                            detailRow.PackageNo = row.PackageNo;
                            detailRow.ItemNo = i + 1;
                            detailRow.LotNo = null;
                            ds.PackageDetail.AddPackageDetailRow(detailRow);
                        }

                        ds.Package.AddPackageRow(row);

                        using (LocalReport localReport = new LocalReport())
                        {
                            localReport.ReportPath = Server.MapPath(string.Format("~/RDLC/{0}", strPackagePrintLabel));
                            ReportDataSource reportDataSourcePackage = new ReportDataSource("Package", ds.Tables[ds.Package.TableName]);
                            localReport.DataSources.Add(reportDataSourcePackage);
                            ReportDataSource reportDataSourcePackageDetail = new ReportDataSource("PackageDetail", ds.Tables[ds.PackageDetail.TableName]);
                            localReport.DataSources.Add(reportDataSourcePackageDetail);
                            localReport.Refresh();
                            string reportType = "PDF";
                            string mimeType;
                            string encoding;
                            string fileNameExtension;
                            string deviceInfo =
                                            "<DeviceInfo>" +
                                            "  <OutputFormat>PDF</OutputFormat>" +
                                            "</DeviceInfo>";
                            Warning[] warnings;
                            string[] streams;
                            byte[] renderedBytes;
                            renderedBytes = localReport.Render(
                                reportType,
                                deviceInfo,
                                out mimeType,
                                out encoding,
                                out fileNameExtension,
                                out streams,
                                out warnings);
                            return File(renderedBytes, mimeType);
                        }
                    }
                    #endregion

                    catch (Exception err)
                    {
                        result.Code = 1005;
                        result.Message = err.Message;
                    }
                }  
            }
            #endregion
          
            return Json(result);
        }
        #endregion

        //标签预览
        [AllowAnonymous]
        public ActionResult ShowPrintView(string orderNumber, string labelCode, string materialCode)
        {
            MethodReturnResult result = new MethodReturnResult();
            WorkOrderPrintSetViewModel model = new WorkOrderPrintSetViewModel();
            //获取标签信息
            PrintLabel label = model.GetLabel(labelCode);
            if (label.Type == EnumPrintLabelType.Box)
            {
                PackageListDataSet ds = new PackageListDataSet();
                IList<PackageDetail> lstPackageDetail = new List<PackageDetail>();
                IList<IVTestData> lstIVTestData = new List<IVTestData>();
                IList<Lot> lstLot = new List<Lot>();

                #region
                try
                {
                    string pssubcode = "X";
                    int qty = 0;

                    //获取包装数据清单
                    string strPackagePrintLabel = label.Content;
                    bool blIsEnglish = false;

                    if (strPackagePrintLabel != "" && strPackagePrintLabel.Length > 0)
                    {
                        if (strPackagePrintLabel.IndexOf("EN") > 0)
                        {
                            blIsEnglish = true;
                        }
                    }

                    //根据工单规则获取满包数量
                    using (WorkOrderRuleServiceClient clientWorkOrderProduct = new WorkOrderRuleServiceClient())
                    {
                        WorkOrderRuleKey WorkOrderRuleKey = new WorkOrderRuleKey()
                        {
                            OrderNumber = orderNumber,
                            MaterialCode = materialCode
                        };
                        MethodReturnResult<WorkOrderRule> resultWorkOrderRule = clientWorkOrderProduct.Get(WorkOrderRuleKey);
                        qty = Convert.ToInt32(resultWorkOrderRule.Data.FullPackageQty);
                    }

                    if (qty == 0)
                    {
                        return Content(string.Format("未找到工单号{0}的满包数量。", orderNumber));
                    }

                    //组件包装数据。
                    PackageListDataSet.PackageRow row = ds.Package.NewPackageRow();
                    row.ProductType = "X";
                    row.MaterialClass = "X";                                     //物料类型
                    row.ProductSpec = "X";                                       //产品规格
                    row.Description = "X";                                       //描述
                    row.OrderNumber = orderNumber;                               //工单
                    row.PackageNo = "X";                                         //包装号
                    row.Count = qty.ToString();                                  //总数
                    row.PowerName = "X";
                    row.PowerTolerance = "X";
                    if (blIsEnglish)
                    {
                        row.Color = "Blue";
                    }
                    else
                    {
                        row.Color = "Blue/正蓝";
                    }

                    #region 协鑫永能/晋能/张家港电池片类型加颜色
                    row.CellType = "L";
                    #endregion

                    #region 协鑫永能/晋能/张家港柜号流水号
                    row.ChestNo = "";
                    #endregion
                    row.PowerSubCode = pssubcode;
                    row.MaterialCode = materialCode;
                    IList<string> lstColor = new List<string>();    //托内颜色数组
                    string packageLots = "X";
                    string sss = "";

                    #region 德国
                    if (strPackagePrintLabel == "GERMAN.rdlc")
                    {
                        packageLots = "XXX";
                        Image img = QRCodeSave(packageLots);
                        byte[] packageLotNosOfByte = ImageToBytes(img);
                        sss = ConvertImageToBase64(img, ImageFormat.Png);
                        row.PackageLotNos = packageLotNosOfByte;
                    }
                    #endregion

                    for (int j = 0; j < qty; j++)
                    {
                        //添加包装明细
                        PackageListDataSet.PackageDetailRow detailRow = ds.PackageDetail.NewPackageDetailRow();
                        detailRow.PackageNo = "X";
                        detailRow.ItemNo = j + 1;
                        detailRow.LotNo = "X";
                        detailRow.IMP = "X";
                        detailRow.ISC = "X";
                        detailRow.PM = "X";
                        detailRow.VMP = "X";
                        detailRow.VOC = "X";
                        detailRow.FF = "X";
                        detailRow.PowerSubCode = "X";
                        ds.PackageDetail.AddPackageDetailRow(detailRow);
                    }

                    ds.Package.AddPackageRow(row);                    

                    using (LocalReport localReport = new LocalReport())
                    {
                        localReport.ReportPath = Server.MapPath(string.Format("~/RDLC/{0}", strPackagePrintLabel));
                        ReportDataSource reportDataSourcePackage = new ReportDataSource("Package", ds.Tables[ds.Package.TableName]);
                        localReport.DataSources.Add(reportDataSourcePackage);
                        ReportDataSource reportDataSourcePackageDetail = new ReportDataSource("PackageDetail", ds.Tables[ds.PackageDetail.TableName]);
                        localReport.DataSources.Add(reportDataSourcePackageDetail);
                        localReport.Refresh();
                        string reportType = "PDF";
                        string mimeType;
                        string encoding;
                        string fileNameExtension;
                        string deviceInfo =
                                        "<DeviceInfo>" +
                                        "  <OutputFormat>PDF</OutputFormat>" +
                                        "</DeviceInfo>";
                        Warning[] warnings;
                        string[] streams;
                        byte[] renderedBytes;
                        renderedBytes = localReport.Render(
                            reportType,
                            deviceInfo,
                            out mimeType,
                            out encoding,
                            out fileNameExtension,
                            out streams,
                            out warnings);
                        return File(renderedBytes, mimeType);
                    }
                }
                #endregion

                catch (Exception err)
                {
                    result.Code = 1005;
                    result.Message = err.Message;
                }
            }         
            return Json(result);
        }

        public Bitmap QRCodeBitmapForStringAnother(string nr)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode = qrEncoder.Encode(nr);
            //保存成png文件
            //string filename = @"E:\HelloWorld.png";
            //ModuleSize 设置图片大小  
            //QuietZoneModules 设置周边padding
            /*
                * 5----150*150    padding:5
                * 10----300*300   padding:10
                */
            GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(4, QuietZoneModules.Four), Brushes.Black, Brushes.White);

            Point padding = new Point(4, 4);
            DrawingSize dSize = render.SizeCalculator.GetSize(qrCode.Matrix.Width);
            Bitmap map = new Bitmap(dSize.CodeWidth + padding.X, dSize.CodeWidth + padding.Y);
            Graphics g = Graphics.FromImage(map);
            render.Draw(g, qrCode.Matrix, padding);
            return map;
        }

        /// <summary>
        /// 封装方法返回Bitmap
        /// </summary>
        /// <param name="nr"></param>
        /// <returns></returns>
        public Bitmap QRCodeBimapForString(string nr)
        {
            string enCodeString = nr;

            //QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            //QrCode qrCode = qrEncoder.Encode(enCodeString);
            //GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(4, QuietZoneModules.Four), Brushes.Black, Brushes.White);

            //Point padding = new Point(4, 4);
            //DrawingSize dSize = render.SizeCalculator.GetSize(qrCode.Matrix.Width);
            //Bitmap map = new Bitmap(dSize.CodeWidth + padding.X, dSize.CodeWidth + padding.Y);
            //Graphics g = Graphics.FromImage(map);
            //render.Draw(g, qrCode.Matrix, padding);

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            //编码方式(注意：BYTE能支持中文，ALPHA_NUMERIC扫描出来的都是数字)
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;//大小(值越大生成的二维码图片像素越高)
            //版本(注意：设置为0主要是防止编码的字符串太长时发生错误)
            qrCodeEncoder.QRCodeVersion = 0;
            //错误效验、错误更正(有4个等级)
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            return qrCodeEncoder.Encode(enCodeString, Encoding.GetEncoding("GB2312"));
        }

        /// <summary>
        /// 保存到本地
        /// </summary>
        /// <param name="nr"></param>
        /// <returns></returns>
        public Image QRCodeSave(string nr)
        {
            //Bitmap bt = QRCodeBimapForString(nr);
            Bitmap bt = QRCodeBitmapForStringAnother(nr);
            Image img = bt;
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Image\\";
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string path = Path.Combine(filePath, fileName);
            bt.Save(path);
            //如果要显示图片就要有返回值
            return img;
        }

        /// <summary>
        /// image对象转byte数组
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image img)
        {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }

        /// <summary>
        /// 转换base64
        /// </summary>
        /// <param name="image"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        private static string ConvertImageToBase64(Image image, ImageFormat format)
        {
            byte[] imageArray;

            using (System.IO.MemoryStream imageStream = new System.IO.MemoryStream())
            {
                image.Save(imageStream, format);
                imageArray = new byte[imageStream.Length];
                imageStream.Seek(0, System.IO.SeekOrigin.Begin);
                imageStream.Read(imageArray, 0, Convert.ToInt32(imageStream.Length));
            }

            return Convert.ToBase64String(imageArray);
        }

        public string GetPackagePrintLabel(MethodReturnResult<DataSet> dt, string strWorkOrder, string strMaterialCode)
        {
            string strPackagePrintLabel = "";
            string strPrintLabelCode = "";
            using (WorkOrderPrintSetServiceClient client = new WorkOrderPrintSetServiceClient())
            {
                PagingConfig cfg = new PagingConfig
                {
                    IsPaging = false,
                    Where = string.Format(@" Key.OrderNumber='{0}' and Key.MaterialCode='{1}' and Key.LabelCode like 'JNW%'", strWorkOrder, strMaterialCode),
                    OrderBy = " Key.LabelCode desc "
                };
                MethodReturnResult<IList<WorkOrderPrintSet>> result = client.Get(ref cfg);
                if (result != null && result.Data != null && result.Data.Count > 0)
                {
                    //如果特定工单挂了两个包装清单
                    if (result.Data.Count > 1 && strWorkOrder == "特定工单")
                    {
                        //如果包装号档位信息为275W
                        if (dt.Data.Tables[0].Rows[0]["PM_NAME"].ToString().Trim() == "特定功率" || dt.Data.Tables[1].Rows[0]["PM_NAME"].ToString().Trim() == "特定功率")
                        {
                            strPrintLabelCode = result.Data[0].Key.LabelCode;
                        }
                        else
                        {
                            strPrintLabelCode = result.Data[1].Key.LabelCode;
                        }
                    }
                    else
                    {
                        strPrintLabelCode = result.Data[0].Key.LabelCode;
                    }
                }
            }

            if (string.IsNullOrEmpty(strPrintLabelCode) == false && strPrintLabelCode.Length > 0)
            {
                using (PrintLabelServiceClient client = new PrintLabelServiceClient())
                {
                    MethodReturnResult<PrintLabel> resultOfPrintLabel = client.Get(strPrintLabelCode);
                    if (resultOfPrintLabel != null && resultOfPrintLabel.Code == 0)
                    {
                        PrintLabel printLabel = resultOfPrintLabel.Data;
                        if (printLabel != null)
                        {
                            strPackagePrintLabel = printLabel.Content;
                        }
                    }
                }
            }
            return strPackagePrintLabel;
        }

        public ActionResult GetPowersetCode(string q)
        {
            IList<Powerset> lstDetail = new List<Powerset>();
            using (PowersetServiceClient client = new PowersetServiceClient())
            {
                PagingConfig cfg = new PagingConfig()
                {
                    IsPaging = false,
                    Where = string.Format(@"CONCAT(Key.Code ,cast(Key.ItemNo as string))  LIKE '{0}%'
                                            AND IsUsed=1"
                                           , q),

                    OrderBy = "Key"
                };

                MethodReturnResult<IList<Powerset>> result = client.Get(ref cfg);
                if (result.Code <= 0 && result.Data != null)
                {
                    lstDetail = result.Data;
                }
            }

            var lnq = from item in lstDetail
                      select item.Key;

            return Json(from item in lstDetail
                        select new
                        {
                            @label = item.Key + "-" + item.Name + "-" + item.PowerName,
                            @value = item.Key.Code + item.Key.ItemNo.ToString(),
                            @Data = item,
                            @SubWay = item.SubWay.ToString()
                        }, JsonRequestBehavior.AllowGet);
        }

    }
}
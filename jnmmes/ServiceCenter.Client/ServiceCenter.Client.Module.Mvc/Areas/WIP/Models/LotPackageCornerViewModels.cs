﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceCenter.MES.Service.Client;
using ServiceCenter.Model;
using ServiceCenter.MES.Model.WIP;
using WIPResources = ServiceCenter.Client.Mvc.Resources.WIP;
using ServiceCenter.Client.Mvc.Resources;
using ServiceCenter.MES.Service.Client.WIP;
using System.Web.Mvc;
using ServiceCenter.Common;
using ServiceCenter.MES.Service.Client.BaseData;
using ServiceCenter.MES.Model.BaseData;
using ServiceCenter.MES.Service.Client.FMM;
using ServiceCenter.MES.Model.FMM;
using ServiceCenter.MES.Service.Client.PPM;
using ServiceCenter.MES.Model.PPM;
using ServiceCenter.MES.Service.Client.RBAC;
using ServiceCenter.MES.Model.RBAC;
using ServiceCenter.MES.Model.LSM;
using ServiceCenter.MES.Service.Client.LSM;

namespace ServiceCenter.Client.Mvc.Areas.WIP.Models
{
    public class LotPackageCornerViewModels
    {

        [Required]
        [Display(Name = "LotNumber", ResourceType = typeof(WIPResources.StringResource))]
        public string LotNumber { get; set; }


        [Display(Name = "LotViewModel_LineCode", ResourceType = typeof(WIPResources.StringResource))]
        public string LineCode { get; set; }

        [Display(Name = "UndoPackageCorner", ResourceType = typeof(WIPResources.StringResource))]
        public bool UndoPackageCorner { get; set; }



        public IEnumerable<SelectListItem> GetProductionLineList()
        {
            //获取用户拥有权限的生产线。
            IList<Resource> lstResource = new List<Resource>();
            using (UserAuthenticateServiceClient client = new UserAuthenticateServiceClient())
            {
                MethodReturnResult<IList<Resource>> result = client.GetResourceList(HttpContext.Current.User.Identity.Name, ResourceType.ProductionLine);
                if (result.Code <= 0 && result.Data != null)
                {
                    lstResource = result.Data;
                }
            }
            IList<ProductionLine> lst = new List<ProductionLine>();
            PagingConfig cfg = new PagingConfig()
            {
                IsPaging = false
            };
            using (ProductionLineServiceClient client = new ProductionLineServiceClient())
            {
                MethodReturnResult<IList<ProductionLine>> result = client.Get(ref cfg);
                if (result.Code <= 0 && result.Data != null)
                {
                    lst = result.Data;
                }
            }

            return from item in lst
                   where lstResource.Any(m => m.Data.ToUpper() == item.Key.ToUpper())
                   select new SelectListItem()
                   {
                       Text = string.Format("{0}[{1}]", item.Name, item.Key),
                       Value = item.Key
                   };
        }
    }
      
   
}
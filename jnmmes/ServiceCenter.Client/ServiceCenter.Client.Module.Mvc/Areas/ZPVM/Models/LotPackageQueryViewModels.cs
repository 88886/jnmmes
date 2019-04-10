﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceCenter.MES.Service.Client;
using ServiceCenter.Model;
using ServiceCenter.MES.Model.WIP;
using ServiceCenter.Client.Mvc.Resources;
using ServiceCenter.MES.Service.Client.WIP;
using System.Web.Mvc;
using ServiceCenter.Common;
using ServiceCenter.Client.Mvc.Areas.WIP.Models;
using ServiceCenter.MES.Model.ZPVM;
using ServiceCenter.MES.Service.Client.ZPVM;
using ZPVMResources = ServiceCenter.Client.Mvc.Resources.ZPVM;

namespace ServiceCenter.Client.Mvc.Areas.ZPVM.Models
{

    public class LotPackageQueryViewModel 
    {
        public LotPackageQueryViewModel()
        {
            this.StartCreateTime = DateTime.Now.ToString("yyyy/MM/dd");
            this.EndCreateTime = DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
        }

        [Display(Name = "PackageNo", ResourceType = typeof(ZPVMResources.StringResource))]
        public string PackageNo { get; set; }

        [Display(Name = "PackageNo", ResourceType = typeof(ZPVMResources.StringResource))]
        public string PackageNo1 { get; set; }

        [Display(Name = "LotPackageQueryViewModel_OrderNumber", ResourceType = typeof(ZPVMResources.StringResource))]
        public string OrderNumber { get; set; }

        [Display(Name = "LotPackageQueryViewModel_StartCreateTime", ResourceType = typeof(ZPVMResources.StringResource))]
        public string StartCreateTime { get; set; }

        [Display(Name = "LotPackageQueryViewModel_EndCreateTime", ResourceType = typeof(ZPVMResources.StringResource))]
        public string EndCreateTime { get; set; }
    }


}
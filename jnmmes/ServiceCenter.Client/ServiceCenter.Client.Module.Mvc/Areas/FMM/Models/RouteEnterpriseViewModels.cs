﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceCenter.MES.Service.Client;
using ServiceCenter.Model;
using ServiceCenter.MES.Model.FMM;
using FMMResources = ServiceCenter.Client.Mvc.Resources.FMM;
using ServiceCenter.Client.Mvc.Resources;
using ServiceCenter.MES.Service.Client.FMM;
using System.Web.Mvc;
using ServiceCenter.Common;

namespace ServiceCenter.Client.Mvc.Areas.FMM.Models
{
    public class RouteEnterpriseQueryViewModel
    {
        public RouteEnterpriseQueryViewModel()
        {
            Status = EnumObjectStatus.Available.GetHashCode().ToString();
        }

        [Display(Name = "RouteEnterpriseQueryViewModel_Name", ResourceType = typeof(FMMResources.StringResource))]
        public string Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "Status", ResourceType = typeof(StringResource))]
        public string Status { get; set; }

        /// <summary>
        /// 取得状态类型列表，包含空类型用于表示不选择
        /// </summary>
        /// <returns></returns>
        public IList<SelectListItem> GetObjectStatusList()
        {
            IEnumerable<SelectListItem> Enumlst = new List<SelectListItem>();
            IList<SelectListItem> lst = new List<SelectListItem>();

            IDictionary<EnumObjectStatus, string> dic = EnumExtensions.GetDisplayNameDictionary<EnumObjectStatus>();

            Enumlst = from item in dic
                      select new SelectListItem()
                      {
                          Text = item.Value,
                          Value = Convert.ToString(item.Key.GetHashCode())
                      };

            SelectListItem NewItem = new SelectListItem()
            {
                Text = "",
                Value = ""
            };

            lst.Add(NewItem);

            foreach (SelectListItem item in Enumlst)
            {
                NewItem = new SelectListItem()
                {
                    Text = item.Text,
                    Value = item.Value
                };

                lst.Add(NewItem);
            }

            return lst;
        }
    }

    public class RouteEnterpriseViewModel
    {
        public RouteEnterpriseViewModel()
        {
            this.CreateTime = DateTime.Now;
            this.EditTime = DateTime.Now;
            this.Status = EnumObjectStatus.Available;
        }

        [Required]
        [Display(Name = "RouteEnterpriseViewModel_Name", ResourceType = typeof(FMMResources.StringResource))]
        [StringLength(50, MinimumLength = 2
                        , ErrorMessageResourceName = "ValidateStringLength"
                        , ErrorMessageResourceType = typeof(StringResource))]
        public string Name { get; set; }

        [Display(Name = "Status", ResourceType = typeof(StringResource))]
        public EnumObjectStatus Status { get; set; }

        [Display(Name = "Description", ResourceType = typeof(StringResource))]
        [StringLength(255, MinimumLength = 0, ErrorMessage = null
                     , ErrorMessageResourceName = "ValidateMaxStringLength"
                     , ErrorMessageResourceType = typeof(StringResource))]
        public string Description { get; set; }

        [Display(Name = "Editor", ResourceType = typeof(StringResource))]
        public string Editor { get; set; }


        [Display(Name = "EditTime", ResourceType = typeof(StringResource))]
        public DateTime? EditTime { get; set; }


        [Display(Name = "Creator", ResourceType = typeof(StringResource))]
        public string Creator { get; set; }


        [Display(Name = "CreateTime", ResourceType = typeof(StringResource))]
        public DateTime? CreateTime { get; set; }

        public IEnumerable<SelectListItem> GetObjectStatusList()
        {
            IDictionary<EnumObjectStatus, string> dic = EnumExtensions.GetDisplayNameDictionary<EnumObjectStatus>();

            return from item in dic
                   select new SelectListItem()
                   {
                       Text = item.Value,
                       Value = Convert.ToString(item.Key)
                   }; ;
        }

    }
}
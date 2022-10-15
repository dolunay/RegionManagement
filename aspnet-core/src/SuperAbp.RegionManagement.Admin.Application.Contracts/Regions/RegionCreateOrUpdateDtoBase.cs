﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.ObjectExtending;

namespace SuperAbp.RegionManagement.Admin.Regions
{
    public class RegionCreateOrUpdateDtoBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 区号
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// 精度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Snow.RegionManagement.Admin.Regions
{    
    public class RegionListDto : EntityDto<int>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public int? ParentId { get; set; }

        /// <summary>
        /// 父名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }
    }
}
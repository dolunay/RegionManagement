using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Snow.RegionManagement.Regions
{
    public class RegionListDto : EntityDto<int>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 父名称
        /// </summary>
        public string ParentName { get; set; }
    }
}
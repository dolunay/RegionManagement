using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Regions
{
    public class RegionNodeDto : EntityDto<Guid>
    {
        public RegionNodeDto()
        {
            Children = new List<RegionNodeDto>();
        }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否叶子
        /// </summary>
        public bool IsLeaf { get; set; }

        public List<RegionNodeDto> Children { get; set; }
    }
}
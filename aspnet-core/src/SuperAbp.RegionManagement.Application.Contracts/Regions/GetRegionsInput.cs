using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Regions
{
    public class GetRegionsInput// : PagedAndSortedResultRequestDto
    {
        public int? ParentId { get; set; }
    }
}
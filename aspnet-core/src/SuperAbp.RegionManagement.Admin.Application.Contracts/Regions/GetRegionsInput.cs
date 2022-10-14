using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Snow.RegionManagement.Admin.Regions
{
    public class GetRegionsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
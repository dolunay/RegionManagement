using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAbp.RegionManagement.Admin.Regions
{
    public class RegionCreateDto : RegionCreateOrUpdateDtoBase
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
    }
}
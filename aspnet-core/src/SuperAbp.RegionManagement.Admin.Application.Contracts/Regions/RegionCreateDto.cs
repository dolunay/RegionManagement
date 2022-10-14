using System;
using System.Collections.Generic;
using System.Text;

namespace Snow.RegionManagement.Admin.Regions
{
    public class RegionCreateDto : RegionCreateOrUpdateDtoBase
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
    }
}
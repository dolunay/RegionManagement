using System;

namespace SuperAbp.RegionManagement.Admin.Streets
{
    public class StreetCreateOrUpdateDtoBase
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Alias { get; set; }
        public Guid DistrictId { get; set; }
    }
}
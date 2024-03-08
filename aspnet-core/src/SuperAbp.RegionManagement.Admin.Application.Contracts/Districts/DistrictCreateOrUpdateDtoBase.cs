using System;

namespace SuperAbp.RegionManagement.Admin.Districts
{
    public class DistrictCreateOrUpdateDtoBase
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Alias { get; set; }
        public Guid CityId { get; set; } = default!;
    }
}
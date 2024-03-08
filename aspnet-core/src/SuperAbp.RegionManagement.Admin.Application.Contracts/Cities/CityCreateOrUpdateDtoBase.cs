using System;

namespace SuperAbp.RegionManagement.Admin.Cities
{
    public class CityCreateOrUpdateDtoBase
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Alias { get; set; }
    }
}
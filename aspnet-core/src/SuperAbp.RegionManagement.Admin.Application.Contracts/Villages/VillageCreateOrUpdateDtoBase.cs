using System;

namespace SuperAbp.RegionManagement.Admin.Villages
{
    public class VillageCreateOrUpdateDtoBase
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Alias { get; set; }
        public Guid StreetId { get; set; }
    }
}
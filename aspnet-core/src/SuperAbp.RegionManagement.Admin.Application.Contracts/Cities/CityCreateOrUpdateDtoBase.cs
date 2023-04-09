using System;

namespace SuperAbp.RegionManagement.Admin.Cities
{
    public class CityCreateOrUpdateDtoBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public Guid ProvinceId { get; set; }
    }
}
using System;

namespace SuperAbp.RegionManagement.Admin.Districts
{
    public class DistrictCreateOrUpdateDtoBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid CityId { get; set; }
    }
}
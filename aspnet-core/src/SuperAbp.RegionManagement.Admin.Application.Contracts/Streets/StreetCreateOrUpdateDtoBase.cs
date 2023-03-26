namespace SuperAbp.RegionManagement.Admin.Streets
{
    public class StreetCreateOrUpdateDtoBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public System.Guid ProvinceId { get; set; }
        public System.Guid CityId { get; set; }
        public System.Guid DistrictId { get; set; }
    }
}
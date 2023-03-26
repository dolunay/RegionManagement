namespace SuperAbp.RegionManagement.Admin.Districts
{
    public class DistrictCreateOrUpdateDtoBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public System.Guid ProvinceId { get; set; }
        public System.Guid CityId { get; set; }
    }
}
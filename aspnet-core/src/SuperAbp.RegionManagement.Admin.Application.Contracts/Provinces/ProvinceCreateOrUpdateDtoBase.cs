namespace SuperAbp.RegionManagement.Admin.Provinces
{
    public class ProvinceCreateOrUpdateDtoBase
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Alias { get; set; }

        public string? Abbreviation { get; set; }
    }
}
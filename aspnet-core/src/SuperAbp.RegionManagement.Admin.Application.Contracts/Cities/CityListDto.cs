using Volo.Abp.Application.Dtos;

namespace Snow.RegionManagement.Admin.Cities;

public class CityListDto : EntityDto<int>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 简称
    /// </summary>
    public string Alias { get; set; }

    public int ProvinceId { get; set; }
}
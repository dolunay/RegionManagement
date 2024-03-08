using System;

namespace SuperAbp.RegionManagement.Admin.Cities
{
    /// <summary>
    /// 创建
    /// </summary>
    public class CityCreateDto : CityCreateOrUpdateDtoBase
    {
        public Guid ProvinceId { get; set; } = default!;
    }
}
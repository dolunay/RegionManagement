using System;

namespace SuperAbp.RegionManagement.Admin.Cities
{
    /// <summary>
    /// 更新
    /// </summary>
    public class CityUpdateDto : CityCreateOrUpdateDtoBase
    {
        public Guid? ProvinceId { get; set; } = default!;
    }
}
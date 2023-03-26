using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Cities
{
    /// <summary>
    /// 列表
    /// </summary>
    public class CityListDto: EntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}
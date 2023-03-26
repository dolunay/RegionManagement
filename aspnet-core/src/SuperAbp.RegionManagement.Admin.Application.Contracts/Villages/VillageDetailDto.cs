using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Villages
{
    /// <summary>
    /// 列表
    /// </summary>
    public class VillageDetailDto: EntityDto<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
    }
}
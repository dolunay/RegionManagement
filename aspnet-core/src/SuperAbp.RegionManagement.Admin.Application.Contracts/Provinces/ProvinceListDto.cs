using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Provinces
{
    /// <summary>
    /// 列表
    /// </summary>
    public class ProvinceListDto : EntityDto<Guid>
    {
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Alias { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string? Abbreviation { get; set; }
    }
}
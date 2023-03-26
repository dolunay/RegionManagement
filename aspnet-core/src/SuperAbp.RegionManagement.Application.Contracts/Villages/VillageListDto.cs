using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Villages;

public class VillageListDto : EntityDto<Guid>
{
    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }
}
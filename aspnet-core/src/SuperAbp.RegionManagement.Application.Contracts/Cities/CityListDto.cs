using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Cities;

public class CityListDto : EntityDto<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 简称
    /// </summary>
    public string Alias { get; set; }
}
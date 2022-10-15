using System;
using SuperAbp.RegionManagement.Provinces;
using Volo.Abp.Domain.Entities;

namespace SuperAbp.RegionManagement.Cities;

/// <summary>
/// 市
/// </summary>
public class City : Entity<Guid>
{
    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 简称
    /// </summary>
    public string Alias { get; set; }

    /// <summary>
    /// 省Id
    /// </summary>
    public Guid ProvinceId { get; set; }
}
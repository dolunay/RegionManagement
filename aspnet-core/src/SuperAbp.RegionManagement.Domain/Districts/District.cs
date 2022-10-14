using System;
using Volo.Abp.Domain.Entities;

namespace Snow.RegionManagement.Districts;

/// <summary>
/// 区
/// </summary>
public class District : Entity<Guid>
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

    /// <summary>
    /// 市Id
    /// </summary>
    public Guid CityId { get; set; }
}
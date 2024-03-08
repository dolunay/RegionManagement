using System;
using SuperAbp.RegionManagement.Provinces;
using Volo.Abp.Domain.Entities;

namespace SuperAbp.RegionManagement.Cities;

/// <summary>
/// 市
/// </summary>
public class City : Entity<Guid>
{
    protected City()
    {
    }

    public City(Guid id, Guid provinceId, string name, string code) : base(id)
    {
        ProvinceId = provinceId;
        Name = name;
        Code = code;
    }

    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; internal set; } = default!;

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; internal set; } = default!;

    /// <summary>
    /// 简称
    /// </summary>
    public string? Alias { get; set; }

    /// <summary>
    /// 省Id
    /// </summary>
    public Guid ProvinceId { get; internal set; } = default!;
}
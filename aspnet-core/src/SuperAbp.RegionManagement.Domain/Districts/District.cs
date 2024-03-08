using System;
using Volo.Abp.Domain.Entities;

namespace SuperAbp.RegionManagement.Districts;

/// <summary>
/// 区
/// </summary>
public class District : Entity<Guid>
{
    private District()
    {
    }

    public District(Guid id, Guid provinceId, Guid cityId, string name, string code) : base(id)
    {
        ProvinceId = provinceId;
        CityId = cityId;
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
    public Guid ProvinceId { get; internal set; }

    /// <summary>
    /// 市Id
    /// </summary>
    public Guid CityId { get; internal set; }
}
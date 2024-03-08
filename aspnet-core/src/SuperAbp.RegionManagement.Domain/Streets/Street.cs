using System;
using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Provinces;
using Volo.Abp.Domain.Entities;

namespace SuperAbp.RegionManagement.Streets;

/// <summary>
/// 乡镇
/// </summary>
public class Street : Entity<Guid>
{
    protected Street()
    {
    }

    public Street(Guid id, Guid provinceId, Guid cityId, Guid districtId, string name, string code) : base(id)
    {
        ProvinceId = provinceId;
        CityId = cityId;
        DistrictId = districtId;
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

    /// <summary>
    /// 市Id
    /// </summary>
    public Guid CityId { get; internal set; } = default!;

    /// <summary>
    /// 区Id
    /// </summary>
    public Guid DistrictId { get; internal set; } = default!;
}
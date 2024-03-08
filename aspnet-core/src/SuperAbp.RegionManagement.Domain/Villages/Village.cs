using System;
using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Provinces;
using SuperAbp.RegionManagement.Streets;
using Volo.Abp.Domain.Entities;

namespace SuperAbp.RegionManagement.Villages;

/// <summary>
/// 村庄
/// </summary>
public class Village : Entity<Guid>
{
    protected Village()
    {
    }

    public Village(Guid id, Guid provinceId, Guid cityId, Guid districtId, Guid streetId, string name, string code) : base(id)
    {
        ProvinceId = provinceId;
        CityId = cityId;
        DistrictId = districtId;
        StreetId = streetId;
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

    /// <summary>
    /// 区Id
    /// </summary>
    public Guid DistrictId { get; internal set; }

    /// <summary>
    /// 乡镇Id
    /// </summary>
    public Guid StreetId { get; internal set; }
}
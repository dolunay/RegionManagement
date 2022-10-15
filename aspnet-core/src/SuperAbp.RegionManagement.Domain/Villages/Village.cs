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

    /// <summary>
    /// 区Id
    /// </summary>
    public Guid DistrictId { get; set; }

    /// <summary>
    /// 乡镇Id
    /// </summary>
    public Guid StreetId { get; set; }
}
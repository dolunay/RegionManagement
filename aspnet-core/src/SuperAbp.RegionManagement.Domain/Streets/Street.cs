using System;
using Snow.RegionManagement.Cities;
using Snow.RegionManagement.Provinces;
using Volo.Abp.Domain.Entities;

namespace Snow.RegionManagement.Streets;

/// <summary>
/// 乡镇
/// </summary>
public class Street : Entity<Guid>
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
}
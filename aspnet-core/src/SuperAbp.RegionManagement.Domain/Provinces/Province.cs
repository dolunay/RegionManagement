using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace SuperAbp.RegionManagement.Provinces;

/// <summary>
/// 省
/// </summary>
public class Province : Entity<Guid>
{
    protected Province()
    { }

    public Province(Guid id, string name, string code) : base(id)
    {
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
    /// 别名
    /// </summary>
    public string? Alias { get; set; }

    /// <summary>
    /// 简称
    /// </summary>
    public string? Abbreviation { get; set; }
}
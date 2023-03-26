using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Streets;

public interface IStreetRepository : IRepository<Street, Guid>
{
    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="districtId">地区</param>
    /// <returns></returns>
    Task<IEnumerable<Street>> GetListByDistrictIdAsync(Guid districtId);
}
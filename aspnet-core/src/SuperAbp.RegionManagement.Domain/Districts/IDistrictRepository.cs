using SuperAbp.RegionManagement.Cities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Districts;

public interface IDistrictRepository : IRepository<District, Guid>
{
    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="cityId">城市Id</param>
    /// <returns></returns>
    Task<IEnumerable<District>> GetListByCityIdAsync(Guid cityId);
}
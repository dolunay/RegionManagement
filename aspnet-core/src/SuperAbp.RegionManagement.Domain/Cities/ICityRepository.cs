using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Cities;

public interface ICityRepository : IRepository<City, Guid>
{
    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="provinceId">省份Id</param>
    /// <returns></returns>
    Task<IEnumerable<City>> GetListByProvinceIdAsync(Guid provinceId);
}
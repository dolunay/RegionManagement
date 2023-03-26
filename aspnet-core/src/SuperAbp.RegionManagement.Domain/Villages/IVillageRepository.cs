using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Villages;

public interface IVillageRepository : IRepository<Village, Guid>
{
    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="streetId">乡镇Id</param>
    /// <returns></returns>
    Task<IEnumerable<Village>> GetListByStreetIdAsync(Guid streetId);
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Provinces;

public interface IProvinceRepository : IRepository<Province, Guid>
{
    /// <summary>
    /// 查找
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="includeDetails"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Province> FindByNameAsync(string name,
        bool includeDetails = true,
        CancellationToken cancellationToken = default);
}
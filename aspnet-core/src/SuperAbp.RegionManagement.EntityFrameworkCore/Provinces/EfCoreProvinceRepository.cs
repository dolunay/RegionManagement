using System;
using System.Threading;
using System.Threading.Tasks;
using SuperAbp.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.Provinces;

public class EfCoreProvinceRepository : EfCoreRepository<IRegionManagementDbContext, Province, Guid>,
    IProvinceRepository
{
    public EfCoreProvinceRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(
        dbContextProvider)
    {
    }

    public async Task<Province> FindByNameAsync(string name, bool includeDetails = true,
        CancellationToken cancellationToken = default)
    {
        return await FindAsync(p => p.Name == name || p.Alias == name, includeDetails, cancellationToken);
    }
}
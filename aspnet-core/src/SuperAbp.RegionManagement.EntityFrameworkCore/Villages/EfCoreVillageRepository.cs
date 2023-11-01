using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperAbp.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.Villages;

public class EfCoreVillageRepository : EfCoreRepository<IRegionManagementDbContext, Village, Guid>, IVillageRepository
{
    public EfCoreVillageRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public virtual async Task<IEnumerable<Village>> GetListByStreetIdAsync(Guid streetId)
    {
        return await (await GetQueryableAsync())
            .Where(v => v.StreetId == streetId)
            .ToListAsync();
    }
}
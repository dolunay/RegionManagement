using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperAbp.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.Streets;

public class EfCoreStreetRepository : EfCoreRepository<IRegionManagementDbContext, Street, Guid>, IStreetRepository
{
    public EfCoreStreetRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public virtual async Task<IEnumerable<Street>> GetListByDistrictIdAsync(Guid districtId)
    {
        return await (await GetQueryableAsync())
            .Where(s => s.DistrictId == districtId)
            .ToListAsync();
    }
}
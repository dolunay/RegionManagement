using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperAbp.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.Districts;

public class EfCoreDistrictRepository : EfCoreRepository<IRegionManagementDbContext, District, Guid>, IDistrictRepository
{
    public EfCoreDistrictRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public virtual async Task<IEnumerable<District>> GetListByCityIdAsync(Guid cityId)
    {
        return await (await GetQueryableAsync())
            .Where(d => d.CityId == cityId)
            .ToListAsync();
    }
}
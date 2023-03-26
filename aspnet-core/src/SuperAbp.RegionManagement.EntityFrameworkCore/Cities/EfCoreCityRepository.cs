using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperAbp.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.Cities;

public class EfCoreCityRepository : EfCoreRepository<IRegionManagementDbContext, City, Guid>, ICityRepository
{
    public EfCoreCityRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<IEnumerable<City>> GetListByProvinceIdAsync(Guid provinceId)
    {
       return await (await GetQueryableAsync()).Where(c => c.ProvinceId == provinceId)
            .ToListAsync();
    }
}
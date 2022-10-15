using System;
using SuperAbp.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.Cities;

public class EfCoreCityRepository : EfCoreRepository<IRegionManagementDbContext, City, Guid>, ICityRepository
{
    public EfCoreCityRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
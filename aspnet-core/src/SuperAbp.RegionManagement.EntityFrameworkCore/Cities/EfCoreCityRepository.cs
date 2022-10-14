using System;
using Snow.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Snow.RegionManagement.Cities;

public class EfCoreCityRepository : EfCoreRepository<IRegionManagementDbContext, City, Guid>, ICityRepository
{
    public EfCoreCityRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
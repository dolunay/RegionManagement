using System;
using Snow.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Snow.RegionManagement.Streets;

public class EfCoreStreetRepository : EfCoreRepository<IRegionManagementDbContext, Street, Guid>, IStreetRepository
{
    public EfCoreStreetRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
using System;
using SuperAbp.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.Districts;

public class EfCoreDistrictRepository : EfCoreRepository<IRegionManagementDbContext, District, Guid>, IDistrictRepository
{
    public EfCoreDistrictRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
using System;
using SuperAbp.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.Villages;

public class EfCoreVillageRepository : EfCoreRepository<IRegionManagementDbContext, Village, Guid>, IVillageRepository
{
    public EfCoreVillageRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
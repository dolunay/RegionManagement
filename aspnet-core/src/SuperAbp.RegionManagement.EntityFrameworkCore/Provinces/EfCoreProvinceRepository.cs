using System;
using SuperAbp.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.Provinces;

public class EfCoreProvinceRepository : EfCoreRepository<IRegionManagementDbContext, Province, Guid>, IProvinceRepository
{
    public EfCoreProvinceRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
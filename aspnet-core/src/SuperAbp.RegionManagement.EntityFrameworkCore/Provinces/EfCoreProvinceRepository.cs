using System;
using Snow.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Snow.RegionManagement.Provinces;

public class EfCoreProvinceRepository : EfCoreRepository<IRegionManagementDbContext, Province, Guid>, IProvinceRepository
{
    public EfCoreProvinceRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}
using SuperAbp.RegionManagement.EntityFrameworkCore;
using SuperAbp.RegionManagement.Locations;
using SuperAbp.RegionManagement.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.EntityFrameworkCore.Locations
{
    public class EfCoreLocationRepository : EfCoreRepository<IRegionManagementDbContext, RegionLocation, Guid>,
    ILocationRepository
    {
        public EfCoreLocationRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
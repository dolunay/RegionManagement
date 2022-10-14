using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Snow.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Snow.RegionManagement.Regions
{
    public class EfCoreRegionRepository : EfCoreRepository<IRegionManagementDbContext, Region, int>, IRegionRepository
    {
        public EfCoreRegionRepository(IDbContextProvider<IRegionManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Region>> FindByParentIdAsync(int? parentId)
        {
            return await (await GetQueryableAsync()).Where(r => r.ParentId == parentId).ToListAsync();
        }
    }
}
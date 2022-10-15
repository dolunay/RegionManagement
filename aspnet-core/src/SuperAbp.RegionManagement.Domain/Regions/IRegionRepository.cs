using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Regions
{
    public interface IRegionRepository : IRepository<Region, int>
    {
        Task<List<Region>> FindByParentIdAsync(int? parentId);
    }
}
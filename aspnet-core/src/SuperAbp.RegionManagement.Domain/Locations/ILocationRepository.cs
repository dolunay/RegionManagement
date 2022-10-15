using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Locations
{
    public interface ILocationRepository:IRepository<RegionLocation, Guid>
    {
    }
}

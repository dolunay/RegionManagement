using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace Snow.RegionManagement.Locations
{
    public interface ILocationRepository:IRepository<RegionLocation, Guid>
    {
    }
}

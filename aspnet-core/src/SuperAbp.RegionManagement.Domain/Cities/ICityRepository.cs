using System;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Cities;

public interface ICityRepository : IRepository<City, Guid>
{
}
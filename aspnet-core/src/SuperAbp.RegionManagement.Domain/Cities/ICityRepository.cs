using System;
using Volo.Abp.Domain.Repositories;

namespace Snow.RegionManagement.Cities;

public interface ICityRepository : IRepository<City, Guid>
{
}
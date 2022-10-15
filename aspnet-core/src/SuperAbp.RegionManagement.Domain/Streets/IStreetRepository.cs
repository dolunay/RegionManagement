using System;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Streets;

public interface IStreetRepository : IRepository<Street, Guid>
{
}
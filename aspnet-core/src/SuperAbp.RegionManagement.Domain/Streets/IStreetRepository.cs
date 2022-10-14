using System;
using Volo.Abp.Domain.Repositories;

namespace Snow.RegionManagement.Streets;

public interface IStreetRepository : IRepository<Street, Guid>
{
}
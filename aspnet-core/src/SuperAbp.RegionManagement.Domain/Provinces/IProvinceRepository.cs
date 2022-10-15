using System;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Provinces;

public interface IProvinceRepository : IRepository<Province, Guid>
{
}
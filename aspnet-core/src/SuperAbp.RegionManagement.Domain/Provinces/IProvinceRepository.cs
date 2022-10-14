using System;
using Volo.Abp.Domain.Repositories;

namespace Snow.RegionManagement.Provinces;

public interface IProvinceRepository : IRepository<Province, Guid>
{
}
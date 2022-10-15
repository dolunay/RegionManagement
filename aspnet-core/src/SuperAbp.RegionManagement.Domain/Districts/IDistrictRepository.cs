using System;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Districts;

public interface IDistrictRepository : IRepository<District, Guid>
{
}
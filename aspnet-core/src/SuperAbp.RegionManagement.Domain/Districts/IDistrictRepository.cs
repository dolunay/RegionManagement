using System;
using Volo.Abp.Domain.Repositories;

namespace Snow.RegionManagement.Districts;

public interface IDistrictRepository : IRepository<District, Guid>
{
}
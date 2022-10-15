using System;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Villages;

public interface IVillageRepository : IRepository<Village, Guid>
{
}
using System;
using Volo.Abp.Domain.Repositories;

namespace Snow.RegionManagement.Villages;

public interface IVillageRepository : IRepository<Village, Guid>
{
}
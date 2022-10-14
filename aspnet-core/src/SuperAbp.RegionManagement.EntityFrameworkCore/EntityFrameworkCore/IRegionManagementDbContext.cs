using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.EntityFrameworkCore;

[ConnectionStringName(RegionManagementDbProperties.ConnectionStringName)]
public interface IRegionManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}

using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.EntityFrameworkCore;

[ConnectionStringName(RegionManagementDbProperties.ConnectionStringName)]
public class RegionManagementDbContext : AbpDbContext<RegionManagementDbContext>, IRegionManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public RegionManagementDbContext(DbContextOptions<RegionManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureRegionManagement();
    }
}

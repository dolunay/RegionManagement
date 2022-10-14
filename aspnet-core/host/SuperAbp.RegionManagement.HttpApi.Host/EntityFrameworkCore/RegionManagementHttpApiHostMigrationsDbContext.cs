using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.EntityFrameworkCore;

public class RegionManagementHttpApiHostMigrationsDbContext : AbpDbContext<RegionManagementHttpApiHostMigrationsDbContext>
{
    public RegionManagementHttpApiHostMigrationsDbContext(DbContextOptions<RegionManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureRegionManagement();
    }
}

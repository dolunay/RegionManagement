using Microsoft.EntityFrameworkCore;
using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Districts;
using SuperAbp.RegionManagement.Locations;
using SuperAbp.RegionManagement.Provinces;
using SuperAbp.RegionManagement.Streets;
using SuperAbp.RegionManagement.Villages;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SuperAbp.RegionManagement.EntityFrameworkCore;

[ConnectionStringName(RegionManagementDbProperties.ConnectionStringName)]
public class RegionManagementDbContext : AbpDbContext<RegionManagementDbContext>, IRegionManagementDbContext
{
    public DbSet<Province> Provinces { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Village> Villages { get; set; }
    public DbSet<RegionLocation> RegionLocations { get; set; }

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
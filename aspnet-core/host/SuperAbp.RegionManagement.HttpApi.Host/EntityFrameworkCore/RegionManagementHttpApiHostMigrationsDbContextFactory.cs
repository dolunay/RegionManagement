using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SuperAbp.RegionManagement.EntityFrameworkCore;

public class RegionManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<RegionManagementHttpApiHostMigrationsDbContext>
{
    public RegionManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<RegionManagementHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("SuperAbpRegionManagement"));

        return new RegionManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}

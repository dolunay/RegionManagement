using Microsoft.EntityFrameworkCore;
using SuperAbp.RegionManagement.Admin.Regions;
using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Districts;
using SuperAbp.RegionManagement.Locations;
using SuperAbp.RegionManagement.Provinces;
using SuperAbp.RegionManagement.Regions;
using SuperAbp.RegionManagement.Streets;
using SuperAbp.RegionManagement.Villages;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SuperAbp.RegionManagement.EntityFrameworkCore;

public static class RegionManagementDbContextModelCreatingExtensions
{
    public static void ConfigureRegionManagement(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Region>(b =>
        {
            b.ToTable(RegionManagementDbProperties.DbTablePrefix + "Regions", RegionManagementDbProperties.DbSchema);
            b.Property(p => p.Id).ValueGeneratedNever();
            b.Property(p => p.Name).IsRequired().HasMaxLength(RegionConsts.MaxNameLength);
            b.Property(p => p.Alias).HasMaxLength(RegionConsts.MaxAliasLength);
            b.Property(p => p.EnglishName).HasMaxLength(RegionConsts.MaxEnglishNameLength);
            b.Property(p => p.AreaCode).HasMaxLength(RegionConsts.MaxAreaCodeLength);
            b.Property(p => p.PostCode).HasMaxLength(RegionConsts.MaxPostCodeLength);
        });
        builder.Entity<Province>(b =>
        {
            b.ToTable(RegionManagementDbProperties.DbTablePrefix + "Provinces", RegionManagementDbProperties.DbSchema);
            b.Property(p => p.Code).IsRequired().HasMaxLength(ProvinceConsts.MaxCodeLength);
            b.Property(p => p.Name).IsRequired().HasMaxLength(ProvinceConsts.MaxNameLength);
            b.Property(p => p.Alias).HasMaxLength(ProvinceConsts.MaxAliasLength);
            b.ConfigureByConvention();
        });

        builder.Entity<City>(b =>
        {
            b.ToTable(RegionManagementDbProperties.DbTablePrefix + "Cities", RegionManagementDbProperties.DbSchema);
            b.Property(p => p.Code).IsRequired().HasMaxLength(ProvinceConsts.MaxCodeLength);
            b.Property(p => p.Name).IsRequired().HasMaxLength(CityConsts.MaxNameLength);
            b.Property(p => p.Alias).HasMaxLength(CityConsts.MaxAliasLength);
            b.ConfigureByConvention();
        });

        builder.Entity<District>(b =>
        {
            b.ToTable(RegionManagementDbProperties.DbTablePrefix + "Districts", RegionManagementDbProperties.DbSchema);
            b.Property(p => p.Code).IsRequired().HasMaxLength(ProvinceConsts.MaxCodeLength);
            b.Property(p => p.Name).IsRequired().HasMaxLength(DistrictConsts.MaxNameLength);
            b.Property(p => p.Alias).HasMaxLength(DistrictConsts.MaxAliasLength);
            b.ConfigureByConvention();
        });
        builder.Entity<Street>(b =>
        {
            b.ToTable(RegionManagementDbProperties.DbTablePrefix + "Streets", RegionManagementDbProperties.DbSchema);
            b.Property(p => p.Code).IsRequired().HasMaxLength(ProvinceConsts.MaxCodeLength);
            b.Property(p => p.Name).IsRequired().HasMaxLength(StreetConsts.MaxNameLength);
            b.Property(p => p.Alias).HasMaxLength(StreetConsts.MaxAliasLength);
            b.ConfigureByConvention();
        });
        builder.Entity<Village>(b =>
        {
            b.ToTable(RegionManagementDbProperties.DbTablePrefix + "Villages", RegionManagementDbProperties.DbSchema);
            b.Property(p => p.Code).IsRequired().HasMaxLength(ProvinceConsts.MaxCodeLength);
            b.Property(p => p.Name).IsRequired().HasMaxLength(VillageConsts.MaxNameLength);
            b.Property(p => p.Alias).HasMaxLength(VillageConsts.MaxAliasLength);
            b.ConfigureByConvention();
        });

        builder.Entity<RegionLocation>(b =>
        {
            b.ToTable(RegionManagementDbProperties.DbTablePrefix + "RegionLocations", RegionManagementDbProperties.DbSchema);
            b.ConfigureByConvention();
        });
    }
}

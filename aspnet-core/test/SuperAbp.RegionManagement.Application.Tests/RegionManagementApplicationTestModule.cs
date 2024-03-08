using SuperAbp.RegionManagement.Admin;
using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement;

[DependsOn(
    typeof(SuperAbpRegionManagementAdminApplicationModule),
    typeof(SuperAbpRegionManagementApplicationModule),
    typeof(RegionManagementDomainTestModule)
)]
public class RegionManagementApplicationTestModule : AbpModule
{
}
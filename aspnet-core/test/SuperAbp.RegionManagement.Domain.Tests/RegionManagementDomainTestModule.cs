using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement;

[DependsOn(
    typeof(SuperAbpRegionManagementDomainModule),
    typeof(RegionManagementTestBaseModule)
)]
public class RegionManagementDomainTestModule : AbpModule
{
}
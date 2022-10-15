using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement;

[DependsOn(
    typeof(SuperAbpRegionManagementApplicationModule),
    typeof(RegionManagementDomainTestModule)
    )]
public class RegionManagementApplicationTestModule : AbpModule
{

}

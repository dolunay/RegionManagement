using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement;

[DependsOn(
    typeof(RegionManagementApplicationModule),
    typeof(RegionManagementDomainTestModule)
    )]
public class RegionManagementApplicationTestModule : AbpModule
{

}

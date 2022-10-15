using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SuperAbpRegionManagementDomainSharedModule)
)]
public class SuperAbpRegionManagementDomainModule : AbpModule
{

}

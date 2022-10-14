using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(RegionManagementDomainSharedModule)
)]
public class RegionManagementDomainModule : AbpModule
{

}

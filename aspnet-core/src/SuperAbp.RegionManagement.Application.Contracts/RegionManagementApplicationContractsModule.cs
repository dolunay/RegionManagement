using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace SuperAbp.RegionManagement;

[DependsOn(
    typeof(RegionManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class RegionManagementApplicationContractsModule : AbpModule
{

}

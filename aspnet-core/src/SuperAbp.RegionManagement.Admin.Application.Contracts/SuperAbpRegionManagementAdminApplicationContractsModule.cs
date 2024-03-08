using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.FluentValidation;
using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement.Admin;

[DependsOn(
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpFluentValidationModule)
    )]
public class SuperAbpRegionManagementAdminApplicationContractsModule : AbpModule
{
}
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using SuperAbp.RegionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement.Admin;

[DependsOn(
    typeof(SuperAbpRegionManagementAdminApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SuperAbpRegionManagementAdminHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SuperAbpRegionManagementAdminHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<RegionManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
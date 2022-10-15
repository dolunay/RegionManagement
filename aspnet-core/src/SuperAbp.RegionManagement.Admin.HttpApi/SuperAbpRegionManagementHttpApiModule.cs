using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using SuperAbp.RegionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement.Admin;

[DependsOn(
    typeof(SuperAbpRegionManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class SuperAbpRegionManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SuperAbpRegionManagementHttpApiModule).Assembly);
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

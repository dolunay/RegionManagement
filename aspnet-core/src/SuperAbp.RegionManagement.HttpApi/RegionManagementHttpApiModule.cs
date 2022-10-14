using Localization.Resources.AbpUi;
using SuperAbp.RegionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace SuperAbp.RegionManagement;

[DependsOn(
    typeof(RegionManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class RegionManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(RegionManagementHttpApiModule).Assembly);
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

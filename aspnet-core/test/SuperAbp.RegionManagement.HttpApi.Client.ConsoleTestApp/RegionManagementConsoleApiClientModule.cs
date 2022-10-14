using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(RegionManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class RegionManagementConsoleApiClientModule : AbpModule
{

}

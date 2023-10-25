using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SuperAbp.RegionManagement.Admin
{
    [DependsOn(
        typeof(SuperAbpRegionManagementAdminApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class SuperAbpRegionManagementAdminHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(SuperAbpRegionManagementAdminApplicationContractsModule).Assembly,
                RegionManagementAdminRemoteServiceConsts.RemoteServiceName
            );

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SuperAbpRegionManagementAdminHttpApiClientModule>();
            });
        }
    }
}
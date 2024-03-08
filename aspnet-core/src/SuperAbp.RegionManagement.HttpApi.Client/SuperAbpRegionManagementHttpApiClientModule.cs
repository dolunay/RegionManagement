using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace SuperAbp.RegionManagement
{
    [DependsOn(
        typeof(SuperAbpRegionManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class SuperAbpRegionManagementHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(SuperAbpRegionManagementApplicationContractsModule).Assembly,
                RegionManagementRemoteServiceConsts.RemoteServiceName
            );

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SuperAbpRegionManagementHttpApiClientModule>();
            });
        }
    }
}
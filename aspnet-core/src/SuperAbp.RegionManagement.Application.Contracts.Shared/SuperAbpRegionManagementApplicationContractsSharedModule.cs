using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement
{
    [DependsOn(typeof(SuperAbpRegionManagementDomainSharedModule))]
    public class SuperAbpRegionManagementApplicationContractsSharedModule : AbpModule
    {
    }
}
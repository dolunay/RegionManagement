using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement;

/* Inherit from this class for your domain layer tests. */
public abstract class RegionManagementDomainTestBase<TStartupModule> : RegionManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

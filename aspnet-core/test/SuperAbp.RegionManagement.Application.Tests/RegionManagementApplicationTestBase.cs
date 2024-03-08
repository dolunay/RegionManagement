using System;
using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement;

public abstract class RegionManagementApplicationTestBase<TStartupModule> : RegionManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
}
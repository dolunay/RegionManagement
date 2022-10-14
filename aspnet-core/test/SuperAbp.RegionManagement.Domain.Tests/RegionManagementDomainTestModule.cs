using SuperAbp.RegionManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(RegionManagementEntityFrameworkCoreTestModule)
    )]
public class RegionManagementDomainTestModule : AbpModule
{

}

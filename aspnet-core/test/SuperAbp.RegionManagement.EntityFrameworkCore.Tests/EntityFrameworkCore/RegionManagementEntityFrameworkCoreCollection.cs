using Xunit;

namespace SuperAbp.RegionManagement.EntityFrameworkCore;

[CollectionDefinition(RegionManagementTestConsts.CollectionDefinitionName)]
public class RegionManagementEntityFrameworkCoreCollection : ICollectionFixture<RegionManagementEntityFrameworkCoreFixture>
{

}

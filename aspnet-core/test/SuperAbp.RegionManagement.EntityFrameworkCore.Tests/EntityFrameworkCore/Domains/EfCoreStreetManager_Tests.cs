using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Provinces;
using SuperAbp.RegionManagement.Streets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SuperAbp.RegionManagement.EntityFrameworkCore.Domains;

[Collection(RegionManagementTestConsts.CollectionDefinitionName)]
public class EfCoreStreetManager_Tests : StreetManager_Tests<RegionManagementEntityFrameworkCoreTestModule>
{
}
using SuperAbp.RegionManagement.Districts;
using SuperAbp.RegionManagement.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SuperAbp.RegionManagement.EntityFrameworkCore.Domains;

[Collection(RegionManagementTestConsts.CollectionDefinitionName)]
public class EfCoreDistrictManager_Tests : DistrictManager_Tests<RegionManagementEntityFrameworkCoreTestModule>
{
}
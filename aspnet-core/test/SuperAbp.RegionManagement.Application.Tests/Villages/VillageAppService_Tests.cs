using Shouldly;
using SuperAbp.RegionManagement.Admin.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp;
using Xunit;
using Volo.Abp.Modularity;
using SuperAbp.RegionManagement.Admin.Villages;
using SuperAbp.RegionManagement.Villages;

namespace SuperAbp.RegionManagement.Provinces;

public abstract class VillageAppService_Tests<TStartupModule> : RegionManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly IVillageAppService _villageAppService;

    protected VillageAppService_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _villageAppService = GetRequiredService<IVillageAppService>();
    }

    [Fact]
    public async Task Should_Get_List()
    {
        var result = await _villageAppService.GetListAsync(_testData.Street1Id);
        result.Items.Count.ShouldBeGreaterThan(0);
    }
}
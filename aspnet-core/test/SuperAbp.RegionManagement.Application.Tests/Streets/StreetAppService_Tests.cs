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
using SuperAbp.RegionManagement.Admin.Streets;
using SuperAbp.RegionManagement.Streets;

namespace SuperAbp.RegionManagement.Provinces;

public abstract class StreetAppService_Tests<TStartupModule> : RegionManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly IStreetAppService _streetAppService;

    protected StreetAppService_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _streetAppService = GetRequiredService<IStreetAppService>();
    }

    [Fact]
    public async Task Should_Get_List()
    {
        var result = await _streetAppService.GetListAsync(_testData.District1Id);
        result.Items.Count.ShouldBeGreaterThan(0);
    }
}
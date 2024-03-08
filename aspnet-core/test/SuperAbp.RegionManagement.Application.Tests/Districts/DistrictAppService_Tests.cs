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
using SuperAbp.RegionManagement.Admin.Districts;
using SuperAbp.RegionManagement.Districts;

namespace SuperAbp.RegionManagement.Provinces;

public abstract class DistrictAppService_Tests<TStartupModule> : RegionManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly IDistrictAppService _districtAppService;

    protected DistrictAppService_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _districtAppService = GetRequiredService<IDistrictAppService>();
    }

    [Fact]
    public async Task Should_Get_List()
    {
        var result = await _districtAppService.GetListAsync(_testData.City1Id);
        result.Items.Count.ShouldBeGreaterThan(0);
    }
}
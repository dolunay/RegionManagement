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
using SuperAbp.RegionManagement.Admin.Cities;

namespace SuperAbp.RegionManagement.Cities;

public abstract class CityAppService_Tests<TStartupModule> : RegionManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly ICityAppService _cityAppService;

    protected CityAppService_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _cityAppService = GetRequiredService<ICityAppService>();
    }

    [Fact]
    public async Task Should_Get_List()
    {
        var result = await _cityAppService.GetListAsync(_testData.Province1Id);
        result.Items.Count.ShouldBeGreaterThan(0);
    }
}
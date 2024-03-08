using Shouldly;
using SuperAbp.RegionManagement.Admin.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace SuperAbp.RegionManagement.Provinces;

public abstract class ProvinceAppService_Tests<TStartupModule> : RegionManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly IProvinceAppService _provinceAppService;

    public ProvinceAppService_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _provinceAppService = GetRequiredService<IProvinceAppService>();
    }

    [Fact]
    public async Task Should_Get_List()
    {
        var result = await _provinceAppService.GetListAsync();
        result.Items.Count.ShouldBeGreaterThan(0);
    }
}
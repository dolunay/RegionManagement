using Shouldly;
using SuperAbp.RegionManagement.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace SuperAbp.RegionManagement.Cities;

public abstract class CityManager_Tests<TStartupModule> : RegionManagementDomainTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly ICityRepository _cityRepository;
    private readonly CityManager _cityManager;

    protected CityManager_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _cityManager = GetRequiredService<CityManager>();
        _cityRepository = GetRequiredService<ICityRepository>();
    }

    [Fact]
    public async Task Should_Create()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var city = await _cityManager.CreateAsync(_testData.Province1Id, "name", "code");
            city.ShouldNotBeNull();
        });
    }

    [Fact]
    public async Task Should_Set_Province()
    {
        City? city;
        await WithUnitOfWorkAsync(async () =>
        {
            city = await _cityRepository.GetAsync(_testData.City1Id);
            await _cityManager.SetProvinceAsync(city, _testData.Province2Id);
        });
        city = await _cityRepository.GetAsync(_testData.City1Id);
        city.ProvinceId.ShouldBe(_testData.Province2Id);
    }

    [Fact]
    public async Task Should_Set_Name()
    {
        var newName = "new Name";
        City? city;
        await WithUnitOfWorkAsync(async () =>
        {
            city = await _cityRepository.GetAsync(_testData.City1Id);
            await _cityManager.SetNameAsync(city, newName);
        });
        city = await _cityRepository.GetAsync(_testData.City1Id);
        city.Name.ShouldBe(newName);
    }

    [Fact]
    public async Task Should_Set_Code()
    {
        var newCode = "new Code";
        City? city;
        await WithUnitOfWorkAsync(async () =>
        {
            city = await _cityRepository.GetAsync(_testData.City1Id);
            await _cityManager.SetCodeAsync(city, newCode);
        });
        city = await _cityRepository.GetAsync(_testData.City1Id);
        city.Code.ShouldBe(newCode);
    }
}
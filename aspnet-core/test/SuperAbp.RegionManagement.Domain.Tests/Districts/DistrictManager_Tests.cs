using Shouldly;
using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace SuperAbp.RegionManagement.Districts;

public abstract class DistrictManager_Tests<TStartupModule> : RegionManagementDomainTestBase<TStartupModule>
where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly IDistrictRepository _districtRepository;
    private readonly ICityRepository _cityRepository;
    private readonly DistrictManager _districtManager;

    protected DistrictManager_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _districtManager = GetRequiredService<DistrictManager>();
        _cityRepository = GetRequiredService<ICityRepository>();
        _districtRepository = GetRequiredService<IDistrictRepository>();
    }

    [Fact]
    public async Task Should_Create()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var city = await _districtManager.CreateAsync(_testData.City1Id, "name", "code");
            city.ShouldNotBeNull();
        });
    }

    [Fact]
    public async Task Should_Set_City()
    {
        District? district;
        await WithUnitOfWorkAsync(async () =>
        {
            district = await _districtRepository.GetAsync(_testData.District1Id);
            await _districtManager.SetCityAsync(district, _testData.City2Id);
        });
        district = await _districtRepository.GetAsync(_testData.District1Id);
        district.CityId.ShouldBe(_testData.City2Id);
    }

    [Fact]
    public async Task Should_Set_Name()
    {
        var newName = "new Name";
        District? district;
        await WithUnitOfWorkAsync(async () =>
        {
            district = await _districtRepository.GetAsync(_testData.District1Id);
            await _districtManager.SetNameAsync(district, newName);
        });
        district = await _districtRepository.GetAsync(_testData.District1Id);
        district.Name.ShouldBe(newName);
    }

    [Fact]
    public async Task Should_Set_Code()
    {
        var newCode = "new Code";
        District? district;
        await WithUnitOfWorkAsync(async () =>
        {
            district = await _districtRepository.GetAsync(_testData.District1Id);
            await _districtManager.SetCodeAsync(district, newCode);
        });
        district = await _districtRepository.GetAsync(_testData.District1Id);
        district.Code.ShouldBe(newCode);
    }
}
using Shouldly;
using SuperAbp.RegionManagement.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace SuperAbp.RegionManagement.Streets;

public abstract class StreetManager_Tests<TStartupModule> : RegionManagementDomainTestBase<TStartupModule>
where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly StreetManager _streetManager;
    private readonly IStreetRepository _streetRepository;

    public StreetManager_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _streetManager = GetRequiredService<StreetManager>();
        _streetRepository = GetRequiredService<IStreetRepository>();
    }

    [Fact]
    public async Task Should_Create()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var city = await _streetManager.CreateAsync(_testData.District1Id, "name", "code");
            city.ShouldNotBeNull();
        });
    }

    [Fact]
    public async Task Should_Set_District()
    {
        Street? street;
        await WithUnitOfWorkAsync(async () =>
        {
            street = await _streetRepository.GetAsync(_testData.Street1Id);
            await _streetManager.SetDistrictAsync(street, _testData.District2Id);
        });
        street = await _streetRepository.GetAsync(_testData.Street1Id);
        street.DistrictId.ShouldBe(_testData.District2Id);
    }

    [Fact]
    public async Task Should_Set_Name()
    {
        var newName = "new Name";
        Street? street;
        await WithUnitOfWorkAsync(async () =>
        {
            street = await _streetRepository.GetAsync(_testData.Street1Id);
            await _streetManager.SetNameAsync(street, newName);
        });
        street = await _streetRepository.GetAsync(_testData.Street1Id);
        street.Name.ShouldBe(newName);
    }

    [Fact]
    public async Task Should_Set_Code()
    {
        var newCode = "new Code";
        Street? street;
        await WithUnitOfWorkAsync(async () =>
        {
            street = await _streetRepository.GetAsync(_testData.Street1Id);
            await _streetManager.SetCodeAsync(street, newCode);
        });
        street = await _streetRepository.GetAsync(_testData.Street1Id);
        street.Code.ShouldBe(newCode);
    }
}
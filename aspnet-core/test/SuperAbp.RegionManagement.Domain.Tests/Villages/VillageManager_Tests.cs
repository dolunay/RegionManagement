using Shouldly;
using SuperAbp.RegionManagement.Streets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace SuperAbp.RegionManagement.Villages;

public abstract class VillageManager_Tests<TStartupModule> : RegionManagementDomainTestBase<TStartupModule>
where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly VillageManager _villageManager;
    private readonly IVillageRepository _villageRepository;

    public VillageManager_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _villageManager = GetRequiredService<VillageManager>();
        _villageRepository = GetRequiredService<IVillageRepository>();
    }

    [Fact]
    public async Task Should_Create()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var city = await _villageManager.CreateAsync(_testData.Street1Id, "name", "code");
            city.ShouldNotBeNull();
        });
    }

    [Fact]
    public async Task Should_Set_Street()
    {
        Village? village;
        await WithUnitOfWorkAsync(async () =>
        {
            village = await _villageRepository.GetAsync(_testData.Village1Id);
            await _villageManager.SetStreetAsync(village, _testData.Street2Id);
        });
        village = await _villageRepository.GetAsync(_testData.Village1Id);
        village.StreetId.ShouldBe(_testData.Street2Id);
    }

    [Fact]
    public async Task Should_Set_Name()
    {
        var newName = "new Name";
        Village? village;
        await WithUnitOfWorkAsync(async () =>
        {
            village = await _villageRepository.GetAsync(_testData.Village1Id);
            await _villageManager.SetNameAsync(village, newName);
        });
        village = await _villageRepository.GetAsync(_testData.Village1Id);
        village.Name.ShouldBe(newName);
    }

    [Fact]
    public async Task Should_Set_Code()
    {
        var newCode = "new Code";
        Village? village;
        await WithUnitOfWorkAsync(async () =>
        {
            village = await _villageRepository.GetAsync(_testData.Village1Id);
            await _villageManager.SetCodeAsync(village, newCode);
        });
        village = await _villageRepository.GetAsync(_testData.Village1Id);
        village.Code.ShouldBe(newCode);
    }
}
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

namespace SuperAbp.RegionManagement.Provinces;

public abstract class VillageAdminAppService_Tests<TStartupModule> : RegionManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly IVillageAdminAppService _villageAdminAppService;

    protected VillageAdminAppService_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _villageAdminAppService = GetRequiredService<IVillageAdminAppService>();
    }

    [Fact]
    public async Task Should_Get_List()
    {
        var result = await _villageAdminAppService.GetListAsync(new GetVillagesInput() { StreetId = _testData.Street1Id });
        result.Items.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_Get_For_Editor()
    {
        var result = await _villageAdminAppService.GetEditorAsync(_testData.Village1Id);
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task Should_Create()
    {
        var dto = new VillageCreateDto()
        {
            StreetId = _testData.Street1Id,
            Name = "Name",
            Code = "Code",
            Alias = "Alias"
        };
        var villageDto = await _villageAdminAppService.CreateAsync(dto);
        var village = await _villageAdminAppService.GetEditorAsync(villageDto.Id);
        village.ShouldNotBeNull();
        village.Name.ShouldBe(dto.Name);
        village.Code.ShouldBe(dto.Code);
        village.Alias.ShouldBe(dto.Alias);
    }

    [Fact]
    public async Task Should_Create_Exists_Name()
    {
        var dto = new VillageCreateDto()
        {
            StreetId = _testData.Street1Id,
            Name = _testData.Village1Name,
            Code = "Code",
            Alias = "Alias"
        };
        await Should.ThrowAsync<BusinessException>(
           async () =>
               await _villageAdminAppService.CreateAsync(dto));
    }

    [Fact]
    public async Task Should_Create_Exists_Code()
    {
        var dto = new VillageCreateDto()
        {
            StreetId = _testData.Street1Id,
            Name = "Name",
            Code = _testData.Village1Code,
            Alias = "Alias"
        };
        await Should.ThrowAsync<BusinessException>(
           async () =>
               await _villageAdminAppService.CreateAsync(dto));
    }

    [Fact]
    public async Task Should_Update()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var dto = new VillageUpdateDto()
            {
                StreetId = _testData.Street1Id,
                Name = "new Name",
                Code = "new Code",
                Alias = "new Alias"
            };
            await _villageAdminAppService.UpdateAsync(_testData.Village1Id, dto);
            var village = await _villageAdminAppService.GetEditorAsync(_testData.Village1Id);
            village.ShouldNotBeNull();
            village.Name.ShouldBe(dto.Name);
            village.Code.ShouldBe(dto.Code);
            village.Alias.ShouldBe(dto.Alias);
        });
    }

    [Fact]
    public async Task Should_Delete()
    {
        await _villageAdminAppService.DeleteAsync(_testData.Village1Id);
        await Should.ThrowAsync<EntityNotFoundException>(
           async () =>
               await _villageAdminAppService.GetEditorAsync(_testData.Village1Id));
    }
}
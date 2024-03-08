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

namespace SuperAbp.RegionManagement.Provinces;

public abstract class StreetAdminAppService_Tests<TStartupModule> : RegionManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly IStreetAdminAppService _streetAdminAppService;

    protected StreetAdminAppService_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _streetAdminAppService = GetRequiredService<IStreetAdminAppService>();
    }

    [Fact]
    public async Task Should_Get_List()
    {
        var result = await _streetAdminAppService.GetListAsync(new GetStreetsInput() { DistrictId = _testData.District1Id });
        result.Items.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_Get_For_Editor()
    {
        var result = await _streetAdminAppService.GetEditorAsync(_testData.Street1Id);
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task Should_Create()
    {
        var dto = new StreetCreateDto()
        {
            DistrictId = _testData.District1Id,
            Name = "Name",
            Code = "Code",
            Alias = "Alias"
        };
        var streetDto = await _streetAdminAppService.CreateAsync(dto);
        var street = await _streetAdminAppService.GetEditorAsync(streetDto.Id);
        street.ShouldNotBeNull();
        street.Name.ShouldBe(dto.Name);
        street.Code.ShouldBe(dto.Code);
        street.Alias.ShouldBe(dto.Alias);
    }

    [Fact]
    public async Task Should_Create_Exists_Name()
    {
        var dto = new StreetCreateDto()
        {
            DistrictId = _testData.District1Id,
            Name = _testData.Street1Name,
            Code = "Code",
            Alias = "Alias"
        };
        await Should.ThrowAsync<BusinessException>(
           async () =>
               await _streetAdminAppService.CreateAsync(dto));
    }

    [Fact]
    public async Task Should_Create_Exists_Code()
    {
        var dto = new StreetCreateDto()
        {
            DistrictId = _testData.District1Id,
            Name = "Name",
            Code = _testData.Street1Code,
            Alias = "Alias"
        };
        await Should.ThrowAsync<BusinessException>(
           async () =>
               await _streetAdminAppService.CreateAsync(dto));
    }

    [Fact]
    public async Task Should_Update()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var dto = new StreetUpdateDto()
            {
                DistrictId = _testData.District1Id,
                Name = "new Name",
                Code = "new Code",
                Alias = "new Alias"
            };
            await _streetAdminAppService.UpdateAsync(_testData.Street1Id, dto);
            var street = await _streetAdminAppService.GetEditorAsync(_testData.Street1Id);
            street.ShouldNotBeNull();
            street.Name.ShouldBe(dto.Name);
            street.Code.ShouldBe(dto.Code);
            street.Alias.ShouldBe(dto.Alias);
        });
    }

    [Fact]
    public async Task Should_Delete()
    {
        await _streetAdminAppService.DeleteAsync(_testData.Street1Id);
        await Should.ThrowAsync<EntityNotFoundException>(
           async () =>
               await _streetAdminAppService.GetEditorAsync(_testData.Street1Id));
    }
}
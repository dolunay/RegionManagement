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

namespace SuperAbp.RegionManagement.Provinces;

public abstract class DistrictAdminAppService_Tests<TStartupModule> : RegionManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly IDistrictAdminAppService _districtAdminAppService;

    protected DistrictAdminAppService_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _districtAdminAppService = GetRequiredService<IDistrictAdminAppService>();
    }

    [Fact]
    public async Task Should_Get_List()
    {
        var result = await _districtAdminAppService.GetListAsync(new GetDistrictsInput() { CityId = _testData.City1Id });
        result.Items.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_Get_For_Editor()
    {
        var result = await _districtAdminAppService.GetEditorAsync(_testData.District1Id);
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task Should_Create()
    {
        var dto = new DistrictCreateDto()
        {
            CityId = _testData.City1Id,
            Name = "Name",
            Code = "Code",
            Alias = "Alias"
        };
        var districtDto = await _districtAdminAppService.CreateAsync(dto);
        var district = await _districtAdminAppService.GetEditorAsync(districtDto.Id);
        district.ShouldNotBeNull();
        district.Name.ShouldBe(dto.Name);
        district.Code.ShouldBe(dto.Code);
        district.Alias.ShouldBe(dto.Alias);
    }

    [Fact]
    public async Task Should_Create_Exists_Name()
    {
        var dto = new DistrictCreateDto()
        {
            CityId = _testData.City1Id,
            Name = _testData.District1Name,
            Code = "Code",
            Alias = "Alias"
        };
        await Should.ThrowAsync<BusinessException>(
           async () =>
               await _districtAdminAppService.CreateAsync(dto));
    }

    [Fact]
    public async Task Should_Create_Exists_Code()
    {
        var dto = new DistrictCreateDto()
        {
            CityId = _testData.City1Id,
            Name = "Name",
            Code = _testData.District1Code,
            Alias = "Alias"
        };
        await Should.ThrowAsync<BusinessException>(
           async () =>
               await _districtAdminAppService.CreateAsync(dto));
    }

    [Fact]
    public async Task Should_Update()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var dto = new DistrictUpdateDto()
            {
                CityId = _testData.City1Id,
                Name = "new Name",
                Code = "new Code",
                Alias = "new Alias"
            };
            await _districtAdminAppService.UpdateAsync(_testData.District1Id, dto);
            var district = await _districtAdminAppService.GetEditorAsync(_testData.District1Id);
            district.ShouldNotBeNull();
            district.Name.ShouldBe(dto.Name);
            district.Code.ShouldBe(dto.Code);
            district.Alias.ShouldBe(dto.Alias);
        });
    }

    [Fact]
    public async Task Should_Delete()
    {
        await _districtAdminAppService.DeleteAsync(_testData.District1Id);
        await Should.ThrowAsync<EntityNotFoundException>(
           async () =>
               await _districtAdminAppService.GetEditorAsync(_testData.District1Id));
    }
}
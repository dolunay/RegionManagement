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

namespace SuperAbp.RegionManagement.Provinces;

public abstract class CityAdminAppService_Tests<TStartupModule> : RegionManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly ICityAdminAppService _cityAdminAppService;

    protected CityAdminAppService_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _cityAdminAppService = GetRequiredService<ICityAdminAppService>();
    }

    [Fact]
    public async Task Should_Get_List()
    {
        var result = await _cityAdminAppService.GetListAsync(new GetCitiesInput() { ProvinceId = _testData.Province1Id });
        result.Items.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_Get_For_Editor()
    {
        var result = await _cityAdminAppService.GetEditorAsync(_testData.City1Id);
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task Should_Create()
    {
        var dto = new CityCreateDto()
        {
            ProvinceId = _testData.Province1Id,
            Name = "Name",
            Code = "Code",
            Alias = "Alias"
        };
        var cityDto = await _cityAdminAppService.CreateAsync(dto);
        var city = await _cityAdminAppService.GetEditorAsync(cityDto.Id);
        city.ShouldNotBeNull();
        city.Name.ShouldBe(dto.Name);
        city.Code.ShouldBe(dto.Code);
        city.Alias.ShouldBe(dto.Alias);
    }

    [Fact]
    public async Task Should_Create_Exists_Name()
    {
        var dto = new CityCreateDto()
        {
            ProvinceId = _testData.Province1Id,
            Name = _testData.City1Name,
            Code = "Code",
            Alias = "Alias"
        };
        await Should.ThrowAsync<BusinessException>(
           async () =>
               await _cityAdminAppService.CreateAsync(dto));
    }

    [Fact]
    public async Task Should_Create_Exists_Code()
    {
        var dto = new CityCreateDto()
        {
            ProvinceId = _testData.Province1Id,
            Name = "Name",
            Code = _testData.City1Code,
            Alias = "Alias"
        };
        await Should.ThrowAsync<BusinessException>(
           async () =>
               await _cityAdminAppService.CreateAsync(dto));
    }

    [Fact]
    public async Task Should_Update()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var dto = new CityUpdateDto()
            {
                Name = "new Name",
                Code = "new Code",
                Alias = "new Alias"
            };
            await _cityAdminAppService.UpdateAsync(_testData.City1Id, dto);
            var city = await _cityAdminAppService.GetEditorAsync(_testData.City1Id);
            city.ShouldNotBeNull();
            city.Name.ShouldBe(dto.Name);
            city.Code.ShouldBe(dto.Code);
            city.Alias.ShouldBe(dto.Alias);
        });
    }

    [Fact]
    public async Task Should_Delete()
    {
        await _cityAdminAppService.DeleteAsync(_testData.City1Id);
        await Should.ThrowAsync<EntityNotFoundException>(
           async () =>
               await _cityAdminAppService.GetEditorAsync(_testData.City1Id));
    }
}
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

namespace SuperAbp.RegionManagement.Provinces;

public abstract class ProvinceAdminAppService_Tests<TStartupModule> : RegionManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly IProvinceAdminAppService _provinceAdminAppService;

    protected ProvinceAdminAppService_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _provinceAdminAppService = GetRequiredService<IProvinceAdminAppService>();
    }

    [Fact]
    public async Task Should_Get_List()
    {
        var result = await _provinceAdminAppService.GetListAsync(new GetProvincesInput());
        result.Items.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_Get_For_Editor()
    {
        var result = await _provinceAdminAppService.GetEditorAsync(_testData.Province1Id);
        result.ShouldNotBeNull();
    }

    [Fact]
    public async Task Should_Create()
    {
        var dto = new ProvinceCreateDto()
        {
            Name = "Name",
            Code = "Code",
            Alias = "Alias",
            Abbreviation = "Abbreviation"
        };
        var provinceDto = await _provinceAdminAppService.CreateAsync(dto);
        var province = await _provinceAdminAppService.GetEditorAsync(provinceDto.Id);
        province.ShouldNotBeNull();
        province.Name.ShouldBe(dto.Name);
        province.Code.ShouldBe(dto.Code);
        province.Alias.ShouldBe(dto.Alias);
        province.Abbreviation.ShouldBe(dto.Abbreviation);
    }

    [Fact]
    public async Task Should_Update()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var dto = new ProvinceUpdateDto()
            {
                Name = "new Name",
                Code = "new Code",
                Alias = "new Alias"
            };
            await _provinceAdminAppService.UpdateAsync(_testData.Province1Id, dto);
            var province = await _provinceAdminAppService.GetEditorAsync(_testData.Province1Id);
            province.ShouldNotBeNull();
            province.Name.ShouldBe(dto.Name);
            province.Code.ShouldBe(dto.Code);
            province.Alias.ShouldBe(dto.Alias);
        });
    }

    [Fact]
    public async Task Should_Delete()
    {
        await _provinceAdminAppService.DeleteAsync(_testData.Province1Id);
        await Should.ThrowAsync<EntityNotFoundException>(
           async () =>
               await _provinceAdminAppService.GetEditorAsync(_testData.Province1Id));
    }
}
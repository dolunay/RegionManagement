using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Modularity;
using Xunit;

namespace SuperAbp.RegionManagement.Provinces;

public abstract class ProvinceManager_Tests<TStartupModule> : RegionManagementDomainTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly RegionManagementTestData _testData;
    private readonly IProvinceRepository _provinceRepository;
    private readonly ProvinceManager _provinceManager;

    protected ProvinceManager_Tests()
    {
        _testData = GetRequiredService<RegionManagementTestData>();
        _provinceManager = GetRequiredService<ProvinceManager>();
        _provinceRepository = GetRequiredService<IProvinceRepository>();
    }

    [Fact]
    public async Task Should_Create()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var province = await _provinceManager.CreateAsync("name", "code");
            province.ShouldNotBeNull();
        });
    }

    [Fact]
    public async Task Should_Create_Exists_Name()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            await Should.ThrowAsync<BusinessException>(
                async () => await _provinceManager.CreateAsync(_testData.Province1Name, "code"));
        });
    }

    [Fact]
    public async Task Should_Create_Exists_Code()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            await Should.ThrowAsync<BusinessException>(
                async () => await _provinceManager.CreateAsync("name", _testData.Province1Code));
        });
    }

    [Fact]
    public async Task Should_Set_Name()
    {
        var newName = "new Name";
        Province? province;
        await WithUnitOfWorkAsync(async () =>
        {
            province = await _provinceRepository.GetAsync(_testData.Province1Id);
            await _provinceManager.SetNameAsync(province, newName);
        });
        province = await _provinceRepository.GetAsync(_testData.Province1Id);
        province.Name.ShouldBe(newName);
    }

    [Fact]
    public async Task Should_Set_Name_Exists()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            await Should.ThrowAsync<BusinessException>(
                async () =>
                {
                    var province = await _provinceRepository.GetAsync(_testData.Province1Id);
                    await _provinceManager.SetNameAsync(province, _testData.Province2Name);
                });
        });
    }

    [Fact]
    public async Task Should_Set_Code()
    {
        var newCode = "new Code";
        Province? province;
        await WithUnitOfWorkAsync(async () =>
        {
            province = await _provinceRepository.GetAsync(_testData.Province1Id);
            await _provinceManager.SetCodeAsync(province, newCode);
        });
        province = await _provinceRepository.GetAsync(_testData.Province1Id);
        province.Code.ShouldBe(newCode);
    }

    [Fact]
    public async Task Should_Set_Code_Exists()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            await Should.ThrowAsync<BusinessException>(
                async () =>
                {
                    var province = await _provinceRepository.GetAsync(_testData.Province1Id);
                    await _provinceManager.SetCodeAsync(province, _testData.Province2Code);
                });
        });
    }
}
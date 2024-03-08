using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Districts;
using SuperAbp.RegionManagement.Provinces;
using SuperAbp.RegionManagement.Streets;
using SuperAbp.RegionManagement.Villages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;

namespace SuperAbp.RegionManagement;

public class RegionManagementTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IProvinceRepository _provinceRepository;
    private readonly ICityRepository _cityRepository;
    private readonly IDistrictRepository _districtRepository;
    private readonly IStreetRepository _streetRepository;
    private readonly IVillageRepository _villageRepository;
    private readonly RegionManagementTestData _testData;

    public RegionManagementTestDataSeedContributor(
       IProvinceRepository provinceRepository, ICityRepository cityRepository, IVillageRepository villageRepository, RegionManagementTestData testData, IDistrictRepository districtRepository, IStreetRepository streetRepository)
    {
        _provinceRepository = provinceRepository;
        _cityRepository = cityRepository;
        _villageRepository = villageRepository;
        _testData = testData;
        _districtRepository = districtRepository;
        _streetRepository = streetRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _provinceRepository.InsertManyAsync(new List<Province>()
        {
            new Province(_testData.Province1Id, _testData.Province1Name, _testData.Province1Code)
                {
                    Alias = "河北"
                },
            new Province(_testData.Province2Id, _testData.Province2Name, _testData.Province2Code)
                {
                    Alias = "山东"
                }
        });
        await _cityRepository.InsertManyAsync(new List<City>()
        {
            new City(_testData.City1Id, _testData.Province1Id, _testData.City1Name, _testData.City1Code)
            {
                Alias = "邢台"
            },
            new City(_testData.City2Id, _testData.Province1Id, _testData.City2Name, _testData.City2Code)
            {
                Alias = "烟台"
            }
        });
        await _districtRepository.InsertManyAsync(new List<District>
        {
            new District(_testData.District1Id, _testData.Province1Id, _testData.City1Id,
                _testData.District1Name, _testData.District1Code)
            {
                Alias = "临西"
            },
            new District(_testData.District2Id, _testData.Province1Id, _testData.City1Id,
                _testData.District2Name, _testData.District2Code)
            {
                Alias = "广宗"
            },
        });
        await _streetRepository.InsertManyAsync(new List<Street>
        {
            new Street(_testData.Street1Id, _testData.Province1Id, _testData.City1Id, _testData.District1Id, _testData.Street1Name, _testData.Street1Code),
            new Street(_testData.Street2Id, _testData.Province1Id, _testData.City1Id, _testData.District1Id, _testData.Street2Name, _testData.Street2Code)
        });
        await _villageRepository.InsertManyAsync(new List<Village>
        {
            new Village(_testData.Village1Id, _testData.Province1Id, _testData.City1Id,
            _testData.District1Id, _testData.Street1Id, _testData.Village1Name, _testData.Village1Code),
            new Village(_testData.Village2Id, _testData.Province1Id, _testData.City1Id,
            _testData.District1Id, _testData.Street1Id, _testData.Village2Name, _testData.Village2Code)
        });
    }
}
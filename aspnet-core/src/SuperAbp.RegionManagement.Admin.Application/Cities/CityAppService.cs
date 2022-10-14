using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snow.RegionManagement.Cities;

namespace Snow.RegionManagement.Admin.Cities;

public class CityAppService : RegionManagementAppService, ICityAppService
{
    private readonly ICityRepository _cityRepository;

    public CityAppService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<List<CityListDto>> GetChildrenAsync(int provinceId)
    {
        var provinceQueryable = await _cityRepository.GetQueryableAsync();
        var provinces = await AsyncExecuter.ToListAsync(provinceQueryable
            .Where(p => p.ProvinceId == provinceId));
        return ObjectMapper.Map<List<City>, List<CityListDto>>(provinces);
    }
}
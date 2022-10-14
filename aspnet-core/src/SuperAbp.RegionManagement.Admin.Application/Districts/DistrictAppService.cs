using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snow.RegionManagement.Districts;

namespace Snow.RegionManagement.Admin.Districts;

public class AreaAppService : RegionManagementAppService, IDistrictAppService
{
    private readonly IDistrictRepository _areaRepository;

    public AreaAppService(IDistrictRepository areaRepository)
    {
        _areaRepository = areaRepository;
    }

    public async Task<List<DistrictListDto>> GetChildrenAsync(int provinceId, int cityId)
    {
        var provinceQueryable = await _areaRepository.GetQueryableAsync();
        var provinces = await AsyncExecuter.ToListAsync(provinceQueryable
            .Where(p => p.ProvinceId == provinceId));
        return ObjectMapper.Map<List<District>, List<DistrictListDto>>(provinces);
    }
}
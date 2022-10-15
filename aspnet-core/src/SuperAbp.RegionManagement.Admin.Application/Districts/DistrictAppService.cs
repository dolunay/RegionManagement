using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperAbp.RegionManagement.Districts;

namespace SuperAbp.RegionManagement.Admin.Districts;

public class AreaAppService : RegionManagementAppService, IDistrictAppService
{
    private readonly IDistrictRepository _areaRepository;

    public AreaAppService(IDistrictRepository areaRepository)
    {
        _areaRepository = areaRepository;
    }

    public async Task<List<DistrictListDto>> GetChildrenAsync(Guid provinceId, Guid cityId)
    {
        var provinceQueryable = await _areaRepository.GetQueryableAsync();
        var provinces = await AsyncExecuter.ToListAsync(provinceQueryable
            .Where(p => p.ProvinceId == provinceId));
        return ObjectMapper.Map<List<District>, List<DistrictListDto>>(provinces);
    }
}
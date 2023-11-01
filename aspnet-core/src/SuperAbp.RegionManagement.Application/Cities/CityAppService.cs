using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperAbp.RegionManagement.Provinces;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Cities;

public class CityAppService : RegionManagementAppService, ICityAppService
{
    protected ICityRepository CityRepository { get; }

    public CityAppService(ICityRepository cityRepository)
    {
        CityRepository = cityRepository;
    }

    public virtual async Task<ListResultDto<CityListDto>> GetListAsync(Guid provinceId)
    {
        var provinces = await CityRepository.GetListByProvinceIdAsync(provinceId);
        return new ListResultDto<CityListDto>(ObjectMapper.Map<List<City>, List<CityListDto>>(provinces.ToList()));
    }
}
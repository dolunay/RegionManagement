using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Districts;

public class DistrictAppService : RegionManagementAppService, IDistrictAppService
{
    private readonly IDistrictRepository _districtRepository;

    public DistrictAppService(IDistrictRepository areaRepository)
    {
        _districtRepository = areaRepository;
    }

    public async Task<ListResultDto<DistrictListDto>> GetListAsync(Guid cityId)
    {
        var districts = await _districtRepository.GetListByCityIdAsync(cityId);
        return new ListResultDto<DistrictListDto>(ObjectMapper.Map<List<District>, List<DistrictListDto>>(districts.ToList()));
    }
}
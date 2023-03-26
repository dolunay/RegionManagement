using SuperAbp.RegionManagement.Cities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Streets;

public class StreetAppService : RegionManagementAppService, IStreetAppService
{
    private readonly IStreetRepository _streetRepository;

    public StreetAppService(IStreetRepository streetRepository)
    {
        _streetRepository = streetRepository;
    }

    public async Task<ListResultDto<StreetListDto>> GetListAsync(Guid districtId)
    {
        var streets = await _streetRepository.GetListByDistrictIdAsync(districtId);
        return new ListResultDto<StreetListDto>(ObjectMapper.Map<List<Street>, List<StreetListDto>>(streets.ToList()));
    }
}
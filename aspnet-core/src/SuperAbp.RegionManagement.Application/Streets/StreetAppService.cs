using SuperAbp.RegionManagement.Cities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Streets;

public class StreetAppService : RegionManagementAppService, IStreetAppService
{
    protected IStreetRepository StreetRepository { get; }

    public StreetAppService(IStreetRepository streetRepository)
    {
        StreetRepository = streetRepository;
    }

    public virtual async Task<ListResultDto<StreetListDto>> GetListAsync(Guid districtId)
    {
        var streets = await StreetRepository.GetListByDistrictIdAsync(districtId);
        return new ListResultDto<StreetListDto>(ObjectMapper.Map<List<Street>, List<StreetListDto>>(streets.ToList()));
    }
}
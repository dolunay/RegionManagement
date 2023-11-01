using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Districts;

public class DistrictAppService : RegionManagementAppService, IDistrictAppService
{
    protected IDistrictRepository DistrictRepository { get; }

    public DistrictAppService(IDistrictRepository areaRepository)
    {
        DistrictRepository = areaRepository;
    }

    public virtual async Task<ListResultDto<DistrictListDto>> GetListAsync(Guid cityId)
    {
        var districts = await DistrictRepository.GetListByCityIdAsync(cityId);
        return new ListResultDto<DistrictListDto>(ObjectMapper.Map<List<District>, List<DistrictListDto>>(districts.ToList()));
    }
}
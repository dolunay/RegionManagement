using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Snow.RegionManagement.Locations;

public class LocationAppService:RegionManagementAppService, ILocationAppService
{
    private  readonly ILocationRepository _locationRepository;

    public LocationAppService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public virtual async Task<LocationListDto> GetAsync(Guid regionId)
    {
        var location = await _locationRepository.GetAsync(l => l.RegionId == regionId);
        return ObjectMapper.Map<RegionLocation, LocationListDto>(location);
    }

    public virtual async Task<ListResultDto<LocationListDto>> GetListAsync(Guid[] regionIds)
    {
        var locationQueryable = await _locationRepository.GetQueryableAsync();
        var locations =
            await AsyncExecuter.ToListAsync(locationQueryable.Where(l => regionIds.Contains(l.RegionId)));
        return new ListResultDto<LocationListDto>(ObjectMapper.Map<List<RegionLocation>, List<LocationListDto>>(locations));
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Locations;

public class LocationAppService : RegionManagementAppService, ILocationAppService
{
    protected ILocationRepository LocationRepository { get; }

    public LocationAppService(ILocationRepository locationRepository)
    {
        LocationRepository = locationRepository;
    }

    public virtual async Task<LocationListDto> GetAsync(Guid regionId)
    {
        var location = await LocationRepository.GetAsync(l => l.RegionId == regionId);
        return ObjectMapper.Map<RegionLocation, LocationListDto>(location);
    }

    public virtual async Task<ListResultDto<LocationListDto>> GetListAsync(Guid[] regionIds)
    {
        var locationQueryable = await LocationRepository.GetQueryableAsync();
        var locations =
            await AsyncExecuter.ToListAsync(locationQueryable.Where(l => regionIds.Contains(l.RegionId)));
        return new ListResultDto<LocationListDto>(ObjectMapper.Map<List<RegionLocation>, List<LocationListDto>>(locations));
    }
}
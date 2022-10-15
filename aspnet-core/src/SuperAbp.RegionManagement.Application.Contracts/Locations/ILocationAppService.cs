using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SuperAbp.RegionManagement.Locations;

public interface ILocationAppService:IApplicationService
{
    Task<LocationListDto> GetAsync(Guid regionId);

    Task<ListResultDto<LocationListDto>> GetListAsync(Guid[] regionIds);
}
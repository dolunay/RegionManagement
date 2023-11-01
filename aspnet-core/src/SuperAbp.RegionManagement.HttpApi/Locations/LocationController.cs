using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Locations
{
    /// <summary>
    /// 经纬度管理
    /// </summary>
    [RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
    [Area(RegionManagementRemoteServiceConsts.ModuleName)]
    [ControllerName("Location")]
    [Route("api/region/location")]
    public class LocationController : ILocationAppService
    {
        protected ILocationAppService LocationAppService { get; }

        public LocationController(ILocationAppService locationAppService)
        {
            LocationAppService = locationAppService;
        }

        [HttpGet("{regionId}")]
        public virtual async Task<LocationListDto> GetAsync(Guid regionId)
        {
            return await LocationAppService.GetAsync(regionId);
        }

        [HttpGet]
        public virtual async Task<ListResultDto<LocationListDto>> GetListAsync(Guid[] regionIds)
        {
            return await LocationAppService.GetListAsync(regionIds);
        }
    }
}
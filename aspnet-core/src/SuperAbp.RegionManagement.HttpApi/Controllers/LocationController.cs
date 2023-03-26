using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperAbp.RegionManagement.Locations;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Controllers
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
        private readonly ILocationAppService _locationAppService;

        public LocationController(ILocationAppService locationAppService)
        {
            _locationAppService = locationAppService;
        }

        [HttpGet("{regionId}")]
        public virtual async Task<LocationListDto> GetAsync(Guid regionId)
        {
            return await _locationAppService.GetAsync(regionId);
        }

        [HttpGet]
        public virtual async Task<ListResultDto<LocationListDto>> GetListAsync(Guid[] regionIds)
        {
            return await _locationAppService.GetListAsync(regionIds);
        }
    }
}

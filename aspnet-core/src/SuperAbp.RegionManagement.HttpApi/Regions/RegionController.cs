using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Snow.RegionManagement.Regions
{
    /// <summary>
    /// 区域管理
    /// </summary>
    [RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
    [Area(RegionManagementRemoteServiceConsts.ModuleName)]
    [ControllerName("Region")]
    [Route("api/regions")]
    public class RegionController : AbpController, IRegionAppService
    {
        protected readonly IRegionAppService _regionAppService;

        public RegionController(IRegionAppService regionAppService)
        {
            _regionAppService = regionAppService;
        }

        /// <summary>
        /// 根节点
        /// </summary>
        /// <returns></returns>
        [HttpGet("root")]
        public async Task<ListResultDto<RegionNodeDto>> GetRootAsync()
        {
            return await _regionAppService.GetRootAsync();
        }

        /// <summary>
        /// 下级
        /// </summary>
        /// <param name="id">父Id</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        [HttpGet("{id}/children/{level}")]
        public virtual async Task<ListResultDto<RegionNodeDto>> GetChildrenAsync(Guid id, RegionLevel level)
        {
            return await _regionAppService.GetChildrenAsync(id, level);
        }
    }
}
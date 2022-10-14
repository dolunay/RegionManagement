using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Snow.RegionManagement.Admin.Regions
{
    /// <summary>
    /// 区域管理
    /// </summary>
    [RemoteService(Name = RegionManagementAdminRemoteServiceConsts.RemoteServiceName)]
    [Area(RegionManagementAdminRemoteServiceConsts.ModuleName)]
    [ControllerName("Region")]
    [Route("api/regions")]
    public class RegionController : RegionManagementController, IRegionAppService
    {
        private readonly IRegionAppService _regionAppService;

        public RegionController(IRegionAppService regionAppService)
        {
            _regionAppService = regionAppService;
        }

        /*
        /// <summary>
        /// 所有
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public virtual async Task<ListResultDto<RegionListDto>> GetAllListAsync()
        {
            return await _regionAppService.GetAllListAsync();
        }

        /// <summary>
        /// 树
        /// </summary>
        /// <returns></returns>
        [HttpGet("tree")]
        public async Task<ListResultDto<RegionNodeDto>> GetTreeListAsync()
        {
            return await _regionAppService.GetTreeListAsync();
        }*/

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

        /*
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<PagedResultDto<RegionListDto>> GetListAsync(GetRegionsInput input)
        {
            return await _regionAppService.GetListAsync(input);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/editor")]
        public virtual async Task<GetRegionForEditOutput> GetEditorAsync(int id)
        {
            return await _regionAppService.GetEditorAsync(id);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<RegionListDto> CreateAsync(RegionCreateDto input)
        {
            return await _regionAppService.CreateAsync(input);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public virtual async Task<RegionListDto> UpdateAsync(int id, RegionUpdateDto input)
        {
            return await _regionAppService.UpdateAsync(id, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public virtual async Task DeleteAsync(int id)
        {
            await _regionAppService.DeleteAsync(id);
        }
        */
    }
}
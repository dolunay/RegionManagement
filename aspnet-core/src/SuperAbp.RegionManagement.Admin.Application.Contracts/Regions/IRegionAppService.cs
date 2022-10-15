using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace SuperAbp.RegionManagement.Admin.Regions
{
    /// <summary>
    /// 区域管理
    /// </summary>
    public interface IRegionAppService : IApplicationService
    {
        /// <summary>
        /// 获取根
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<RegionNodeDto>> GetRootAsync();

        /// <summary>
        /// 下级
        /// </summary>
        /// <param name="id">父Id</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        Task<ListResultDto<RegionNodeDto>> GetChildrenAsync(Guid id, RegionLevel level);

        /*
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<RegionListDto>> GetAllListAsync();

        Task<ListResultDto<RegionNodeDto>> GetTreeListAsync();

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<RegionListDto>> GetListAsync(GetRegionsInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetRegionForEditOutput> GetEditorAsync(int id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<RegionListDto> CreateAsync(RegionCreateDto input);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<RegionListDto> UpdateAsync(int id, RegionUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
        */
    }
}
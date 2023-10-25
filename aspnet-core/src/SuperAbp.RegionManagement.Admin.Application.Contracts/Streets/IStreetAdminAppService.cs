using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SuperAbp.RegionManagement.Admin.Streets
{
    /// <summary>
    /// 镇管理
    /// </summary>
    public interface IStreetAdminAppService : IApplicationService
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="districtId">区Id</param>
        /// <returns></returns>
        Task<ListResultDto<StreetListDto>> GetChildrenAsync(Guid districtId);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<StreetListDto>> GetListAsync(GetStreetsInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetStreetForEditorOutput> GetEditorAsync(Guid id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<StreetListDto> CreateAsync(StreetCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<StreetListDto> UpdateAsync(Guid id, StreetUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
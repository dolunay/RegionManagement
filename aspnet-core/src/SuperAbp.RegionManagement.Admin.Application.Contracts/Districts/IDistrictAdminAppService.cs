using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SuperAbp.RegionManagement.Admin.Districts
{
    /// <summary>
    /// 地区管理
    /// </summary>
    public interface IDistrictAdminAppService : IApplicationService
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="cityId">市Id</param>
        /// <returns></returns>
        Task<ListResultDto<DistrictListDto>> GetChildrenAsync(Guid cityId);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<DistrictListDto>> GetListAsync(GetDistrictsInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetDistrictForEditorOutput> GetEditorAsync(Guid id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DistrictListDto> CreateAsync(DistrictCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DistrictListDto> UpdateAsync(Guid id, DistrictUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
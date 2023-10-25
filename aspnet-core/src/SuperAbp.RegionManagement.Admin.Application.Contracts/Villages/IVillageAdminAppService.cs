using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SuperAbp.RegionManagement.Admin.Villages
{
    /// <summary>
    /// 乡管理
    /// </summary>
    public interface IVillageAdminAppService : IApplicationService
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="streetId">乡镇Id</param>
        /// <returns></returns>
        Task<ListResultDto<VillageListDto>> GetChildrenAsync(Guid streetId);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<VillageListDto>> GetListAsync(GetVillagesInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetVillageForEditorOutput> GetEditorAsync(Guid id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<VillageListDto> CreateAsync(VillageCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<VillageListDto> UpdateAsync(Guid id, VillageUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
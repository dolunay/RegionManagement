using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SuperAbp.RegionManagement.Admin.Cities
{
    /// <summary>
    /// 市管理
    /// </summary>
    public interface ICityAppService : IApplicationService
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="provinceId">省Id</param>
        /// <returns></returns>
        Task<ListResultDto<CityListDto>> GetChildrenAsync(Guid provinceId);

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        Task<PagedResultDto<CityListDto>> GetListAsync(GetCitiesInput input);

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<GetCityForEditorOutput> GetEditorAsync(Guid id);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CityListDto> CreateAsync(CityCreateDto input);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CityListDto> UpdateAsync(Guid id, CityUpdateDto input);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
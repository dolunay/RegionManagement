using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using SuperAbp.RegionManagement.Permissions;
using SuperAbp.RegionManagement.Provinces;

namespace SuperAbp.RegionManagement.Admin.Provinces
{
    /// <summary>
    /// 省管理
    /// </summary>
    [Authorize(RegionManagementPermissions.Provinces.Default)]
    public class ProvinceAdminAppService : RegionManagementAdminAppService, IProvinceAdminAppService
    {
        private readonly IProvinceRepository _provinceRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="provinceRepository"></param>
        public ProvinceAdminAppService(
            IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public virtual async Task<ListResultDto<ProvinceListDto>> GetAllListAsync()
        {
            var provinces = await _provinceRepository.GetListAsync();
            return new ListResultDto<ProvinceListDto>(
                ObjectMapper.Map<List<Province>, List<ProvinceListDto>>(provinces));
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<ProvinceListDto>> GetListAsync(GetProvincesInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _provinceRepository.GetQueryableAsync();

            long totalCount = await AsyncExecuter.CountAsync(queryable);

            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? ProvinceConsts.DefaultSorting)
                .PageBy(input));

            var dtos = ObjectMapper.Map<List<Province>, List<ProvinceListDto>>(entities);

            return new PagedResultDto<ProvinceListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<GetProvinceForEditorOutput> GetEditorAsync(Guid id)
        {
            Province entity = await _provinceRepository.GetAsync(id);

            return ObjectMapper.Map<Province, GetProvinceForEditorOutput>(entity);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Provinces.Create)]
        public virtual async Task<ProvinceListDto> CreateAsync(ProvinceCreateDto input)
        {
            var entity = ObjectMapper.Map<ProvinceCreateDto, Province>(input);
            entity = await _provinceRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<Province, ProvinceListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Provinces.Update)]
        public virtual async Task<ProvinceListDto> UpdateAsync(Guid id, ProvinceUpdateDto input)
        {
            Province entity = await _provinceRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await _provinceRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Province, ProvinceListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Provinces.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _provinceRepository.DeleteAsync(s => s.Id == id);
        }

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(ProvinceSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
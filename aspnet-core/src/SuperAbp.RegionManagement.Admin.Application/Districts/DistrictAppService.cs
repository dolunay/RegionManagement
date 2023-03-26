using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SuperAbp.RegionManagement.Districts;
using Volo.Abp;
using Volo.Abp.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using SuperAbp.RegionManagement.Permissions;

namespace SuperAbp.RegionManagement.Admin.Districts
{
    /// <summary>
    /// 地区管理
    /// </summary>
    [Authorize(RegionManagementPermissions.Districts.Default)]
    public class DistrictAppService : RegionManagementAppService, IDistrictAppService
    {
        private readonly IDistrictRepository _districtRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="districtRepository"></param>
        public DistrictAppService(
            IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public virtual async Task<ListResultDto<DistrictListDto>> GetChildrenAsync(Guid cityId)
        {
            var districts = await _districtRepository.GetListByCityIdAsync(cityId);
            return new ListResultDto<DistrictListDto>(ObjectMapper.Map<List<District>, List<DistrictListDto>>(districts.ToList()));
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<DistrictListDto>> GetListAsync(GetDistrictsInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _districtRepository.GetQueryableAsync();

            queryable = queryable
                .Where(d => d.CityId == input.CityId);

            long totalCount = await AsyncExecuter.CountAsync(queryable);

            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? DistrictConsts.DefaultSorting)
                .PageBy(input));

            var dtos = ObjectMapper.Map<List<District>, List<DistrictListDto>>(entities);

            return new PagedResultDto<DistrictListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<GetDistrictForEditorOutput> GetEditorAsync(Guid id)
        {
            District entity = await _districtRepository.GetAsync(id);

            return ObjectMapper.Map<District, GetDistrictForEditorOutput>(entity);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Districts.Create)]
        public virtual async Task<DistrictListDto> CreateAsync(DistrictCreateDto input)
        {
            var entity = ObjectMapper.Map<DistrictCreateDto, District>(input);
            entity = await _districtRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<District, DistrictListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Districts.Update)]
        public virtual async Task<DistrictListDto> UpdateAsync(Guid id, DistrictUpdateDto input)
        {
            District entity = await _districtRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await _districtRepository.UpdateAsync(entity);
            return ObjectMapper.Map<District, DistrictListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Districts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _districtRepository.DeleteAsync(s => s.Id == id);
        }

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(DistrictSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
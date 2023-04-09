using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SuperAbp.RegionManagement.Cities;
using Volo.Abp;
using Volo.Abp.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using SuperAbp.RegionManagement.Permissions;
using SuperAbp.RegionManagement.Provinces;

namespace SuperAbp.RegionManagement.Admin.Cities
{
    /// <summary>
    /// 市管理
    /// </summary>
    [Authorize(RegionManagementPermissions.Cities.Default)]
    public class CityAppService : RegionManagementAppService, ICityAppService
    {
        private readonly ICityRepository _cityRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="cityRepository"></param>
        public CityAppService(
            ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public virtual async Task<ListResultDto<CityListDto>> GetChildrenAsync(Guid provinceId)
        {
            var provinces = await _cityRepository.GetListByProvinceIdAsync(provinceId);
            return new ListResultDto<CityListDto>(ObjectMapper.Map<List<City>, List<CityListDto>>(provinces.ToList()));
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<CityListDto>> GetListAsync(GetCitiesInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _cityRepository.GetQueryableAsync();

            queryable = queryable
                .Where(c => c.ProvinceId == input.ProvinceId);

            long totalCount = await AsyncExecuter.CountAsync(queryable);

            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? CityConsts.DefaultSorting)
                .PageBy(input));

            var dtos = ObjectMapper.Map<List<City>, List<CityListDto>>(entities);

            return new PagedResultDto<CityListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<GetCityForEditorOutput> GetEditorAsync(Guid id)
        {
            City entity = await _cityRepository.GetAsync(id);
            var dto = ObjectMapper.Map<City, GetCityForEditorOutput>(entity);
            return dto;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Cities.Create)]
        public virtual async Task<CityListDto> CreateAsync(CityCreateDto input)
        {
            var entity = ObjectMapper.Map<CityCreateDto, City>(input);
            entity = await _cityRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<City, CityListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Cities.Update)]
        public virtual async Task<CityListDto> UpdateAsync(Guid id, CityUpdateDto input)
        {
            City entity = await _cityRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await _cityRepository.UpdateAsync(entity);
            return ObjectMapper.Map<City, CityListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Cities.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _cityRepository.DeleteAsync(s => s.Id == id);
        }

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(CitySettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
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
    [Authorize(RegionManagementPermissions.Cities.Default)]
    public class CityAdminAppService : RegionManagementAdminAppService, ICityAdminAppService
    {
        protected ICityRepository CityRepository { get; }

        public CityAdminAppService(
            ICityRepository cityRepository)
        {
            CityRepository = cityRepository;
        }

        public virtual async Task<ListResultDto<CityListDto>> GetChildrenAsync(Guid provinceId)
        {
            var provinces = await CityRepository.GetListByProvinceIdAsync(provinceId);
            return new ListResultDto<CityListDto>(ObjectMapper.Map<List<City>, List<CityListDto>>(provinces.ToList()));
        }

        public virtual async Task<PagedResultDto<CityListDto>> GetListAsync(GetCitiesInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await CityRepository.GetQueryableAsync();

            queryable = queryable
                .Where(c => c.ProvinceId == input.ProvinceId);

            long totalCount = await AsyncExecuter.CountAsync(queryable);

            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? CityConsts.DefaultSorting)
                .PageBy(input));

            var dtos = ObjectMapper.Map<List<City>, List<CityListDto>>(entities);

            return new PagedResultDto<CityListDto>(totalCount, dtos);
        }

        public virtual async Task<GetCityForEditorOutput> GetEditorAsync(Guid id)
        {
            City entity = await CityRepository.GetAsync(id);
            var dto = ObjectMapper.Map<City, GetCityForEditorOutput>(entity);
            return dto;
        }

        [Authorize(RegionManagementPermissions.Cities.Create)]
        public virtual async Task<CityListDto> CreateAsync(CityCreateDto input)
        {
            var entity = ObjectMapper.Map<CityCreateDto, City>(input);
            entity = await CityRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<City, CityListDto>(entity);
        }

        [Authorize(RegionManagementPermissions.Cities.Update)]
        public virtual async Task<CityListDto> UpdateAsync(Guid id, CityUpdateDto input)
        {
            City entity = await CityRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await CityRepository.UpdateAsync(entity);
            return ObjectMapper.Map<City, CityListDto>(entity);
        }

        [Authorize(RegionManagementPermissions.Cities.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await CityRepository.DeleteAsync(s => s.Id == id);
        }

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        protected virtual async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(CitySettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
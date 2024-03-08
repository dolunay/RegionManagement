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
        protected CityManager CityManager { get; }

        public CityAdminAppService(
            ICityRepository cityRepository, CityManager cityManager)
        {
            CityRepository = cityRepository;
            CityManager = cityManager;
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
            var city = await CityManager.CreateAsync(input.ProvinceId, input.Name, input.Code);
            city.Alias = input.Alias;
            city = await CityRepository.InsertAsync(city);
            return ObjectMapper.Map<City, CityListDto>(city);
        }

        [Authorize(RegionManagementPermissions.Cities.Update)]
        public virtual async Task<CityListDto> UpdateAsync(Guid id, CityUpdateDto input)
        {
            City city = await CityRepository.GetAsync(id);
            await CityManager.SetNameAsync(city, input.Name);
            await CityManager.SetCodeAsync(city, input.Code);
            if (input.ProvinceId.HasValue)
            {
                await CityManager.SetProvinceAsync(city, input.ProvinceId.Value);
            }
            city.Alias = input.Alias;

            city = await CityRepository.UpdateAsync(city);
            return ObjectMapper.Map<City, CityListDto>(city);
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
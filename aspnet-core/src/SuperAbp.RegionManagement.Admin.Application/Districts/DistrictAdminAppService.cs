using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Districts;
using Volo.Abp;
using Volo.Abp.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using SuperAbp.RegionManagement.Permissions;
using SuperAbp.RegionManagement.Provinces;

namespace SuperAbp.RegionManagement.Admin.Districts
{
    [Authorize(RegionManagementPermissions.Districts.Default)]
    public class DistrictAdminAppService : RegionManagementAdminAppService, IDistrictAdminAppService
    {
        protected IDistrictRepository DistrictRepository { get; }
        protected DistrictManager DistrictManager { get; }

        public DistrictAdminAppService(
            IDistrictRepository districtRepository, DistrictManager districtManager)
        {
            DistrictRepository = districtRepository;
            DistrictManager = districtManager;
        }

        public virtual async Task<ListResultDto<DistrictListDto>> GetChildrenAsync(Guid cityId)
        {
            var districts = await DistrictRepository.GetListByCityIdAsync(cityId);
            return new ListResultDto<DistrictListDto>(ObjectMapper.Map<List<District>, List<DistrictListDto>>(districts.ToList()));
        }

        public virtual async Task<PagedResultDto<DistrictListDto>> GetListAsync(GetDistrictsInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await DistrictRepository.GetQueryableAsync();

            queryable = queryable
                .Where(d => d.CityId == input.CityId);

            long totalCount = await AsyncExecuter.CountAsync(queryable);

            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? DistrictConsts.DefaultSorting)
                .PageBy(input));

            var dtos = ObjectMapper.Map<List<District>, List<DistrictListDto>>(entities);

            return new PagedResultDto<DistrictListDto>(totalCount, dtos);
        }

        public virtual async Task<GetDistrictForEditorOutput> GetEditorAsync(Guid id)
        {
            District entity = await DistrictRepository.GetAsync(id);

            return ObjectMapper.Map<District, GetDistrictForEditorOutput>(entity);
        }

        [Authorize(RegionManagementPermissions.Districts.Create)]
        public virtual async Task<DistrictListDto> CreateAsync(DistrictCreateDto input)
        {
            var district = await DistrictManager.CreateAsync(input.CityId, input.Name, input.Code);
            district.Alias = input.Alias;
            district = await DistrictRepository.InsertAsync(district);
            return ObjectMapper.Map<District, DistrictListDto>(district);
        }

        [Authorize(RegionManagementPermissions.Districts.Update)]
        public virtual async Task<DistrictListDto> UpdateAsync(Guid id, DistrictUpdateDto input)
        {
            District district = await DistrictRepository.GetAsync(id);
            await DistrictManager.SetCityAsync(district, input.CityId);
            await DistrictManager.SetNameAsync(district, input.Name);
            await DistrictManager.SetCodeAsync(district, input.Code);
            district.Alias = input.Alias;

            district = await DistrictRepository.UpdateAsync(district);
            return ObjectMapper.Map<District, DistrictListDto>(district);
        }

        [Authorize(RegionManagementPermissions.Districts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await DistrictRepository.DeleteAsync(s => s.Id == id);
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
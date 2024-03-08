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
using SuperAbp.RegionManagement.Streets;

namespace SuperAbp.RegionManagement.Admin.Streets
{
    [Authorize(RegionManagementPermissions.Streets.Default)]
    public class StreetAdminAppService : RegionManagementAdminAppService, IStreetAdminAppService
    {
        protected IStreetRepository StreetRepository { get; }
        protected StreetManager StreetManager { get; }

        public StreetAdminAppService(
            IStreetRepository streetRepository, StreetManager streetManager)
        {
            StreetRepository = streetRepository;
            StreetManager = streetManager;
        }

        public virtual async Task<ListResultDto<StreetListDto>> GetChildrenAsync(Guid districtId)
        {
            var streets = await StreetRepository.GetListByDistrictIdAsync(districtId);
            return new ListResultDto<StreetListDto>(ObjectMapper.Map<List<Street>, List<StreetListDto>>(streets.ToList()));
        }

        public virtual async Task<PagedResultDto<StreetListDto>> GetListAsync(GetStreetsInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await StreetRepository.GetQueryableAsync();

            queryable = queryable
                .Where(s => s.DistrictId == input.DistrictId);

            long totalCount = await AsyncExecuter.CountAsync(queryable);

            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? StreetConsts.DefaultSorting)
                .PageBy(input));

            var dtos = ObjectMapper.Map<List<Street>, List<StreetListDto>>(entities);

            return new PagedResultDto<StreetListDto>(totalCount, dtos);
        }

        public virtual async Task<GetStreetForEditorOutput> GetEditorAsync(Guid id)
        {
            Street entity = await StreetRepository.GetAsync(id);

            return ObjectMapper.Map<Street, GetStreetForEditorOutput>(entity);
        }

        [Authorize(RegionManagementPermissions.Streets.Create)]
        public virtual async Task<StreetListDto> CreateAsync(StreetCreateDto input)
        {
            var street = await StreetManager.CreateAsync(input.DistrictId, input.Name, input.Code);
            street.Alias = input.Alias;
            street = await StreetRepository.InsertAsync(street);
            return ObjectMapper.Map<Street, StreetListDto>(street);
        }

        [Authorize(RegionManagementPermissions.Streets.Update)]
        public virtual async Task<StreetListDto> UpdateAsync(Guid id, StreetUpdateDto input)
        {
            Street street = await StreetRepository.GetAsync(id);
            await StreetManager.SetNameAsync(street, input.Name);
            await StreetManager.SetCodeAsync(street, input.Code);
            await StreetManager.SetDistrictAsync(street, input.DistrictId);
            street.Alias = input.Alias;

            street = await StreetRepository.UpdateAsync(street);
            return ObjectMapper.Map<Street, StreetListDto>(street);
        }

        [Authorize(RegionManagementPermissions.Streets.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await StreetRepository.DeleteAsync(s => s.Id == id);
        }

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(StreetSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
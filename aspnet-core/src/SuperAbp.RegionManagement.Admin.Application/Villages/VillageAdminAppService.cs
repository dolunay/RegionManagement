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
using SuperAbp.RegionManagement.Villages;

namespace SuperAbp.RegionManagement.Admin.Villages
{
    [Authorize(RegionManagementPermissions.Villages.Default)]
    public class VillageAdminAppService : RegionManagementAdminAppService, IVillageAdminAppService
    {
        protected IVillageRepository VillageRepository { get; }
        protected VillageManager VillageManager { get; }

        public VillageAdminAppService(
            IVillageRepository villageRepository, VillageManager villageManager)
        {
            VillageRepository = villageRepository;
            VillageManager = villageManager;
        }

        public virtual async Task<ListResultDto<VillageListDto>> GetChildrenAsync(Guid streetId)
        {
            var provinces = await VillageRepository.GetListByStreetIdAsync(streetId);
            return new ListResultDto<VillageListDto>(ObjectMapper.Map<List<Village>, List<VillageListDto>>(provinces.ToList()));
        }

        public virtual async Task<PagedResultDto<VillageListDto>> GetListAsync(GetVillagesInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await VillageRepository.GetQueryableAsync();

            queryable = queryable
                .Where(v => v.StreetId == input.StreetId);

            long totalCount = await AsyncExecuter.CountAsync(queryable);

            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? VillageConsts.DefaultSorting)
                .PageBy(input));

            var dtos = ObjectMapper.Map<List<Village>, List<VillageListDto>>(entities);

            return new PagedResultDto<VillageListDto>(totalCount, dtos);
        }

        public virtual async Task<GetVillageForEditorOutput> GetEditorAsync(Guid id)
        {
            Village entity = await VillageRepository.GetAsync(id);

            return ObjectMapper.Map<Village, GetVillageForEditorOutput>(entity);
        }

        [Authorize(RegionManagementPermissions.Villages.Create)]
        public virtual async Task<VillageListDto> CreateAsync(VillageCreateDto input)
        {
            var village = await VillageManager.CreateAsync(input.StreetId, input.Name, input.Code);
            village.Alias = input.Alias;
            village = await VillageRepository.InsertAsync(village);
            return ObjectMapper.Map<Village, VillageListDto>(village);
        }

        [Authorize(RegionManagementPermissions.Villages.Update)]
        public virtual async Task<VillageListDto> UpdateAsync(Guid id, VillageUpdateDto input)
        {
            Village village = await VillageRepository.GetAsync(id);
            await VillageManager.SetStreetAsync(village, input.StreetId);
            await VillageManager.SetNameAsync(village, input.Name);
            await VillageManager.SetCodeAsync(village, input.Code);
            village.Alias = input.Alias;
            village = await VillageRepository.UpdateAsync(village);
            return ObjectMapper.Map<Village, VillageListDto>(village);
        }

        [Authorize(RegionManagementPermissions.Villages.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await VillageRepository.DeleteAsync(s => s.Id == id);
        }

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(VillageSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
    }
}
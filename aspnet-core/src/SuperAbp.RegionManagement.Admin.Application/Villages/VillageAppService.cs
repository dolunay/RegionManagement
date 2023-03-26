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
    /// <summary>
    /// 乡管理
    /// </summary>
    [Authorize(RegionManagementPermissions.Villages.Default)]
    public class VillageAppService : RegionManagementAppService, IVillageAppService
    {
        private readonly IVillageRepository _villageRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="villageRepository"></param>
        public VillageAppService(
            IVillageRepository villageRepository)
        {
            _villageRepository = villageRepository;
        }

        public virtual async Task<ListResultDto<VillageListDto>> GetChildrenAsync(Guid streetId)
        {
            var provinces = await _villageRepository.GetListByStreetIdAsync(streetId);
            return new ListResultDto<VillageListDto>(ObjectMapper.Map<List<Village>, List<VillageListDto>>(provinces.ToList()));
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<VillageListDto>> GetListAsync(GetVillagesInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _villageRepository.GetQueryableAsync();

            queryable = queryable
                .Where(v => v.StreetId == input.StreetId);

            long totalCount = await AsyncExecuter.CountAsync(queryable);

            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? VillageConsts.DefaultSorting)
                .PageBy(input));

            var dtos = ObjectMapper.Map<List<Village>, List<VillageListDto>>(entities);

            return new PagedResultDto<VillageListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<GetVillageForEditorOutput> GetEditorAsync(Guid id)
        {
            Village entity = await _villageRepository.GetAsync(id);

            return ObjectMapper.Map<Village, GetVillageForEditorOutput>(entity);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Villages.Create)]
        public virtual async Task<VillageListDto> CreateAsync(VillageCreateDto input)
        {
            var entity = ObjectMapper.Map<VillageCreateDto, Village>(input);
            entity = await _villageRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<Village, VillageListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Villages.Update)]
        public virtual async Task<VillageListDto> UpdateAsync(Guid id, VillageUpdateDto input)
        {
            Village entity = await _villageRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await _villageRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Village, VillageListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Villages.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _villageRepository.DeleteAsync(s => s.Id == id);
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
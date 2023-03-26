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
    /// <summary>
    /// 镇管理
    /// </summary>
    [Authorize(RegionManagementPermissions.Streets.Default)]
    public class StreetAppService : RegionManagementAppService, IStreetAppService
    {
        private readonly IStreetRepository _streetRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="streetRepository"></param>
        public StreetAppService(
            IStreetRepository streetRepository)
        {
            _streetRepository = streetRepository;
        }

        public virtual async Task<ListResultDto<StreetListDto>> GetChildrenAsync(Guid districtId)
        {
            var streets = await _streetRepository.GetListByDistrictIdAsync(districtId);
            return new ListResultDto<StreetListDto>(ObjectMapper.Map<List<Street>, List<StreetListDto>>(streets.ToList()));
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns>结果</returns>
        public virtual async Task<PagedResultDto<StreetListDto>> GetListAsync(GetStreetsInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await _streetRepository.GetQueryableAsync();

            queryable = queryable
                .Where(s => s.DistrictId == input.DistrictId);

            long totalCount = await AsyncExecuter.CountAsync(queryable);

            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? StreetConsts.DefaultSorting)
                .PageBy(input));

            var dtos = ObjectMapper.Map<List<Street>, List<StreetListDto>>(entities);

            return new PagedResultDto<StreetListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual async Task<GetStreetForEditorOutput> GetEditorAsync(Guid id)
        {
            Street entity = await _streetRepository.GetAsync(id);

            return ObjectMapper.Map<Street, GetStreetForEditorOutput>(entity);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Streets.Create)]
        public virtual async Task<StreetListDto> CreateAsync(StreetCreateDto input)
        {
            var entity = ObjectMapper.Map<StreetCreateDto, Street>(input);
            entity = await _streetRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<Street, StreetListDto>(entity);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Streets.Update)]
        public virtual async Task<StreetListDto> UpdateAsync(Guid id, StreetUpdateDto input)
        {
            Street entity = await _streetRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await _streetRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Street, StreetListDto>(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Streets.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _streetRepository.DeleteAsync(s => s.Id == id);
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
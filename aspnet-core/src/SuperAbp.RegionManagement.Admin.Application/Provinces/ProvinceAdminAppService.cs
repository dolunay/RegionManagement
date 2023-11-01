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
    [Authorize(RegionManagementPermissions.Provinces.Default)]
    public class ProvinceAdminAppService : RegionManagementAdminAppService, IProvinceAdminAppService
    {
        protected IProvinceRepository ProvinceRepository { get; }

        public ProvinceAdminAppService(
            IProvinceRepository provinceRepository)
        {
            ProvinceRepository = provinceRepository;
        }

        public virtual async Task<ListResultDto<ProvinceListDto>> GetAllListAsync()
        {
            var provinces = await ProvinceRepository.GetListAsync();
            return new ListResultDto<ProvinceListDto>(
                ObjectMapper.Map<List<Province>, List<ProvinceListDto>>(provinces));
        }

        public virtual async Task<PagedResultDto<ProvinceListDto>> GetListAsync(GetProvincesInput input)
        {
            await NormalizeMaxResultCountAsync(input);

            var queryable = await ProvinceRepository.GetQueryableAsync();

            long totalCount = await AsyncExecuter.CountAsync(queryable);

            var entities = await AsyncExecuter.ToListAsync(queryable
                .OrderBy(input.Sorting ?? ProvinceConsts.DefaultSorting)
                .PageBy(input));

            var dtos = ObjectMapper.Map<List<Province>, List<ProvinceListDto>>(entities);

            return new PagedResultDto<ProvinceListDto>(totalCount, dtos);
        }

        public virtual async Task<GetProvinceForEditorOutput> GetEditorAsync(Guid id)
        {
            Province entity = await ProvinceRepository.GetAsync(id);

            return ObjectMapper.Map<Province, GetProvinceForEditorOutput>(entity);
        }

        [Authorize(RegionManagementPermissions.Provinces.Create)]
        public virtual async Task<ProvinceListDto> CreateAsync(ProvinceCreateDto input)
        {
            var entity = ObjectMapper.Map<ProvinceCreateDto, Province>(input);
            entity = await ProvinceRepository.InsertAsync(entity, true);
            return ObjectMapper.Map<Province, ProvinceListDto>(entity);
        }

        [Authorize(RegionManagementPermissions.Provinces.Update)]
        public virtual async Task<ProvinceListDto> UpdateAsync(Guid id, ProvinceUpdateDto input)
        {
            Province entity = await ProvinceRepository.GetAsync(id);
            entity = ObjectMapper.Map(input, entity);
            entity = await ProvinceRepository.UpdateAsync(entity);
            return ObjectMapper.Map<Province, ProvinceListDto>(entity);
        }

        [Authorize(RegionManagementPermissions.Provinces.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await ProvinceRepository.DeleteAsync(s => s.Id == id);
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
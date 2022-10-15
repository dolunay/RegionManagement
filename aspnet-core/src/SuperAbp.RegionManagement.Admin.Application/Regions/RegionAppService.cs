using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Districts;
using SuperAbp.RegionManagement.Permissions;
using SuperAbp.RegionManagement.Provinces;
using SuperAbp.RegionManagement.Regions;
using SuperAbp.RegionManagement.Streets;
using SuperAbp.RegionManagement.Villages;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Admin.Regions
{
    /// <summary>
    /// 区域管理
    /// </summary>
    [Authorize(RegionManagementPermissions.Regions.Default)]
    public class RegionAppService : RegionManagementAppService, IRegionAppService
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IStreetRepository _streetRepository;
        private readonly IVillageRepository _villageRepository;

        public RegionAppService(IProvinceRepository provinceRepository,
            ICityRepository cityRepository,
            IDistrictRepository districtRepository,
            IStreetRepository streetRepository,
            IVillageRepository villageRepository)
        {
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _streetRepository = streetRepository;
            _villageRepository = villageRepository;
        }

        public virtual async Task<ListResultDto<RegionNodeDto>> GetRootAsync()
        {
            var provinceQueryable = await _provinceRepository.GetQueryableAsync();

            var provinces = await AsyncExecuter.ToListAsync(provinceQueryable.OrderBy(p => p.Code));
            return new ListResultDto<RegionNodeDto>(
                ObjectMapper.Map<List<Province>, List<RegionNodeDto>>(provinces));
        }

        public virtual async Task<ListResultDto<RegionNodeDto>> GetChildrenAsync(Guid id, RegionLevel level)
        {
            // TODO:获取子级问题
            List<RegionNodeDto> regions = new List<RegionNodeDto>();
            switch (level)
            {
                case RegionLevel.City:
                    await GetChildrenAsync(regions,
                        await _cityRepository.GetQueryableAsync(),
                        c => c.ProvinceId == id,
                        a => _districtRepository.AnyAsync(v => v.CityId == a.Id));
                    break;

                case RegionLevel.District:
                    await GetChildrenAsync(regions,
                        await _districtRepository.GetQueryableAsync(),
                        c => c.CityId == id,
                        a => _streetRepository.AnyAsync(v => v.DistrictId == a.Id));
                    break;

                case RegionLevel.Street:
                    await GetChildrenAsync(regions,
                        await _streetRepository.GetQueryableAsync(),
                        c => c.DistrictId == id,
                        a => _villageRepository.AnyAsync(v => v.StreetId == a.Id));
                    break;

                case RegionLevel.Village:
                    await GetChildrenAsync(regions,
                        await _villageRepository.GetQueryableAsync(),
                        c => c.StreetId == id,
                        a => Task.FromResult(true));
                    break;
            }
            return new ListResultDto<RegionNodeDto>(regions);
        }

        private async Task GetChildrenAsync<T>(List<RegionNodeDto> regions, IQueryable<T> queryable,
            Expression<Func<T, bool>> where, Func<T, Task<bool>> anyChild)
        {
            var cities = await AsyncExecuter.ToListAsync(queryable.Where(where).OrderBy("Code ASC"));
            await ToDto(regions, cities, anyChild);
        }

        /// <summary>
        /// 转Dto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="regions"></param>
        /// <param name="items"></param>
        /// <param name="anyChild">是否有子元素</param>
        /// <returns></returns>
        private async Task ToDto<T>(List<RegionNodeDto> regions, List<T> items, Func<T, Task<bool>> anyChild)
        {
            foreach (T item in items)
            {
                var dto = ObjectMapper.Map<T, RegionNodeDto>(item);
                dto.IsLeaf = !await anyChild(item);
                regions.Add(dto);
            }
        }

        /*

        private readonly IRegionRepository _regionRepository;

        public RegionAppService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<RegionListDto>> GetAllListAsync()
        {
            var regions = await _regionRepository.GetListAsync();

            var dtos = ObjectMapper.Map<List<Region>, List<RegionListDto>>(regions);
            return new ListResultDto<RegionListDto>(dtos);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ListResultDto<RegionNodeDto>> GetTreeListAsync()
        {
            var regions = await _regionRepository.GetListAsync();

            List<RegionNodeDto> dtos = new List<RegionNodeDto>();
            foreach (Region region in regions.Where(c => !c.ParentId.HasValue))
            {
                RegionNodeDto currentDto = ObjectMapper.Map<Region, RegionNodeDto>(region);
                currentDto.Children.AddRange(GetChildren(region.Id, regions));
                currentDto.IsLeaf = !currentDto.Children.Any();
                dtos.Add(currentDto);
            }
            return new ListResultDto<RegionNodeDto>(dtos);
        }

        protected virtual IEnumerable<RegionNodeDto> GetChildren(int parentId, IEnumerable<Region> regions)
        {
            List<RegionNodeDto> results = new List<RegionNodeDto>();
            var children = regions.Where(c => c.ParentId == parentId).ToList();
            if (children.Count <= 0)
            {
                yield break;
            }
            foreach (var child in children)
            {
                RegionNodeDto currentDto = ObjectMapper.Map<Region, RegionNodeDto>(child);
                currentDto.Children.AddRange(GetChildren(child.Id, regions));
                currentDto.IsLeaf = !currentDto.Children.Any();
                yield return currentDto;
            }
        }

        /// <summary>
        /// 根节点
        /// </summary>
        /// <returns></returns>
        public virtual async Task<ListResultDto<RegionNodeDto>> GetRootAsync()
        {
            var regions = await _regionRepository.FindByParentIdAsync(null);
            var dtos = ObjectMapper.Map<List<Region>, List<RegionNodeDto>>(regions);
            return new ListResultDto<RegionNodeDto>(dtos);
        }

        /// <summary>
        /// 下级
        /// </summary>
        /// <param name="id">父Id</param>
        /// <returns></returns>
        public virtual async Task<ListResultDto<RegionNodeDto>> GetChildrenAsync(int id)
        {
            var regions = await _regionRepository.FindByParentIdAsync(id);
            List<RegionNodeDto> treeNodes = new List<RegionNodeDto>();
            foreach (Region region in regions)
            {
                RegionNodeDto treeNode = ObjectMapper.Map<Region, RegionNodeDto>(region);
                treeNode.IsLeaf = !(await AsyncExecuter.AnyAsync(await _regionRepository.GetQueryableAsync(), r => r.ParentId == region.Id));
                treeNodes.Add(treeNode);
            }
            return new ListResultDto<RegionNodeDto>(treeNodes);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<PagedResultDto<RegionListDto>> GetListAsync(GetRegionsInput input)
        {
            await NormalizeMaxResultCountAsync(input);
            var queryable = await _regionRepository.WithDetailsAsync(r => r.Parent);
            var tempQuery = queryable
               .WhereIf(!String.IsNullOrEmpty(input.Filter), e => e.Name.Contains(input.Filter) || e.Alias.Contains(input.Filter))
               .WhereIf(!String.IsNullOrEmpty(input.Name), e => e.Name.Contains(input.Name))
               .WhereIf(input.ParentId.HasValue, e => e.ParentId == input.ParentId.Value);

            long totalCount = await AsyncExecuter.CountAsync(tempQuery);

            var entities = await AsyncExecuter.ToListAsync(tempQuery
                .OrderBy(input.Sorting ?? "Id ASC")
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            var dtos = ObjectMapper.Map<List<Region>, List<RegionListDto>>(entities);

            return new PagedResultDto<RegionListDto>(totalCount, dtos);
        }

        /// <summary>
        /// 获取修改
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Regions.Update)]
        public virtual async Task<GetRegionForEditOutput> GetEditorAsync(int id)
        {
            Region region = await _regionRepository.GetAsync(id);
            return ObjectMapper.Map<Region, GetRegionForEditOutput>(region);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Regions.Create)]
        public virtual async Task<RegionListDto> CreateAsync(RegionCreateDto input)
        {
            Region region = ObjectMapper.Map<RegionCreateDto, Region>(input);
            if (input.ParentId.HasValue)
            {
                Region parent = await _regionRepository.FindAsync(input.ParentId.Value)
                    ?? throw new UserFriendlyException("父类不存在");
                region.Level = parent.Level + 1;
            }
            else
            {
                region.Level = 0;
            }
            await _regionRepository.InsertAsync(region, true);
            return ObjectMapper.Map<Region, RegionListDto>(region);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Regions.Update)]
        public virtual async Task<RegionListDto> UpdateAsync(int id, RegionUpdateDto input)
        {
            Region region = await _regionRepository.GetAsync(id);

            ObjectMapper.Map<RegionUpdateDto, Region>(input, region);
            //region.ParentId = input.ParentId;

            //if (region.ParentId.HasValue && input.ParentId != region.ParentId)
            //{
            //    if (region.ParentId.HasValue && input.ParentId.Value != region.ParentId.Value)
            //    {
            //        Region parent = await _regionRepository.FindAsync(input.ParentId.Value)
            //            ?? throw new UserFriendlyException("父类不存在");
            //        region.Level = parent.Level + 1;
            //    }
            //}
            await _regionRepository.UpdateAsync(region);
            return ObjectMapper.Map<Region, RegionListDto>(region);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [Authorize(RegionManagementPermissions.Regions.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            if (await _regionRepository.AnyAsync(r => r.ParentId == id))
            {
                throw new UserFriendlyException("存在子区域,无法删除");
            }

            await _regionRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 规范最大记录数
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        private async Task NormalizeMaxResultCountAsync(PagedAndSortedResultRequestDto input)
        {
            var maxPageSize = (await SettingProvider.GetOrNullAsync(RegionSettings.MaxPageSize))?.To<int>();
            if (maxPageSize.HasValue && input.MaxResultCount > maxPageSize.Value)
            {
                input.MaxResultCount = maxPageSize.Value;
            }
        }
        */
    }
}
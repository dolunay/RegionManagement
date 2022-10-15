using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Districts;
using SuperAbp.RegionManagement.Provinces;
using SuperAbp.RegionManagement.Streets;
using SuperAbp.RegionManagement.Villages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace SuperAbp.RegionManagement.Regions
{
    /// <summary>
    /// 区域管理
    /// </summary>
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
    }
}
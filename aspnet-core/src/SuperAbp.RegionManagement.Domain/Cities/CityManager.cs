using SuperAbp.RegionManagement.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using System.Xml.Linq;
using SuperAbp.RegionManagement.Districts;

namespace SuperAbp.RegionManagement.Cities
{
    public class CityManager : DomainService
    {
        protected IProvinceRepository ProvinceRepository { get; }

        protected ICityRepository CityRepository { get; }

        public CityManager(IProvinceRepository provinceRepository, ICityRepository cityRepository)
        {
            ProvinceRepository = provinceRepository;
            CityRepository = cityRepository;
        }

        public virtual async Task<City> CreateAsync(Guid provinceId, string name, string code)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(code, nameof(code));
            // TODO:replace provinceId to province?
            var province = await ProvinceRepository.GetAsync(provinceId);
            if (await CityRepository.AnyAsync(p => p.Name == name))
            {
                throw new BusinessException(RegionManagementErrorCodes.CityNameExists);
            }
            if (await CityRepository.AnyAsync(p => p.Code == code))
            {
                throw new BusinessException(RegionManagementErrorCodes.CityCodeExists);
            }
            return new City(GuidGenerator.Create(), province.Id, name, code);
        }

        public virtual async Task SetProvinceAsync(City city, Guid provinceId)
        {
            if (city.ProvinceId == provinceId)
            { return; }
            var province = await ProvinceRepository.GetAsync(provinceId);
            city.ProvinceId = province.Id;
        }

        public virtual async Task SetNameAsync(City city, string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            if (city.Name == name)
            {
                return;
            }
            if (await CityRepository.AnyAsync(p => p.Id != city.Id && p.Name == name))
            {
                throw new BusinessException(RegionManagementErrorCodes.CityNameExists);
            }
            city.Name = name;
        }

        public virtual async Task SetCodeAsync(City city, string code)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            if (city.Code == code)
            {
                return;
            }
            if (await CityRepository.AnyAsync(p => p.Id != city.Id && p.Code == code))
            {
                throw new BusinessException(RegionManagementErrorCodes.CityCodeExists);
            }
            city.Code = code;
        }
    }
}
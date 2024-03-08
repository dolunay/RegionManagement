using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Provinces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SuperAbp.RegionManagement.Districts
{
    public class DistrictManager : DomainService
    {
        protected ICityRepository CityRepository { get; }
        protected IDistrictRepository DistrictRepository { get; }

        public DistrictManager(ICityRepository cityRepository, IDistrictRepository districtRepository)
        {
            CityRepository = cityRepository;
            DistrictRepository = districtRepository;
        }

        public virtual async Task<District> CreateAsync(Guid cityId, string name, string code)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(code, nameof(code));
            var city = await CityRepository.FindAsync(cityId)
                ?? throw new BusinessException(RegionManagementErrorCodes.CityNotExists);
            if (await DistrictRepository.AnyAsync(d => d.Name == name))
            {
                throw new BusinessException(RegionManagementErrorCodes.DistrictNameExists);
            }
            if (await DistrictRepository.AnyAsync(d => d.Code == code))
            {
                throw new BusinessException(RegionManagementErrorCodes.DistrictCodeExists);
            }
            return new District(GuidGenerator.Create(), city.ProvinceId, cityId, name, code);
        }

        public virtual async Task SetCityAsync(District district, Guid cityId)
        {
            if (district.CityId == cityId)
            {
                return;
            }
            var city = await CityRepository.GetAsync(cityId);
            district.CityId = cityId;
            district.ProvinceId = city.ProvinceId;
        }

        public virtual async Task SetNameAsync(District district, string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            if (district.Name == name)
            {
                return;
            }
            if (await DistrictRepository.AnyAsync(d => d.Id != district.Id && d.Name == name))
            {
                throw new BusinessException(RegionManagementErrorCodes.DistrictNameExists);
            }
            district.Name = name;
        }

        public virtual async Task SetCodeAsync(District district, string code)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            if (district.Code == code)
            {
                return;
            }
            if (await DistrictRepository.AnyAsync(d => d.Id != district.Id && d.Code == code))
            {
                throw new BusinessException(RegionManagementErrorCodes.DistrictCodeExists);
            }
            district.Code = code;
        }
    }
}
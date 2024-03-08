using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SuperAbp.RegionManagement.Provinces
{
    public class ProvinceManager : DomainService
    {
        protected IProvinceRepository ProvinceRepository { get; }

        public ProvinceManager(IProvinceRepository provinceRepository)
        {
            ProvinceRepository = provinceRepository;
        }

        public virtual async Task<Province> CreateAsync(string name, string code)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(code, nameof(code));
            if (await ProvinceRepository.AnyAsync(p => p.Name == name))
            {
                throw new BusinessException(RegionManagementErrorCodes.ProvinceNameExists);
            }
            if (await ProvinceRepository.AnyAsync(p => p.Code == code))
            {
                throw new BusinessException(RegionManagementErrorCodes.ProvinceCodeExists);
            }
            return new Province(GuidGenerator.Create(), name, code);
        }

        public virtual async Task SetNameAsync(Province province, string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            if (province.Name == name)
            {
                return;
            }
            if (await ProvinceRepository.AnyAsync(p => p.Id != province.Id && p.Name == name))
            {
                throw new BusinessException(RegionManagementErrorCodes.ProvinceNameExists);
            }
            province.Name = name;
        }

        public virtual async Task SetCodeAsync(Province province, string code)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            if (province.Code == code)
            {
                return;
            }
            if (await ProvinceRepository.AnyAsync(p => p.Id != province.Id && p.Code == code))
            {
                throw new BusinessException(RegionManagementErrorCodes.ProvinceCodeExists);
            }
            province.Code = code;
        }
    }
}
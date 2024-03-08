using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Districts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SuperAbp.RegionManagement.Streets;

public class StreetManager : DomainService
{
    protected IDistrictRepository DistrictRepository { get; }
    protected IStreetRepository StreetRepository { get; }

    public StreetManager(IDistrictRepository districtRepository, IStreetRepository streetRepository)
    {
        DistrictRepository = districtRepository;
        StreetRepository = streetRepository;
    }

    public virtual async Task<Street> CreateAsync(Guid districtId, string name, string code)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Check.NotNullOrWhiteSpace(code, nameof(code));
        var district = await DistrictRepository.FindAsync(districtId)
            ?? throw new BusinessException(RegionManagementErrorCodes.DistrictNotExists);
        if (await StreetRepository.AnyAsync(s => s.Name == name))
        {
            throw new BusinessException(RegionManagementErrorCodes.StreetNameExists);
        }
        if (await StreetRepository.AnyAsync(s => s.Code == code))
        {
            throw new BusinessException(RegionManagementErrorCodes.StreetCodeExists);
        }
        return new Street(GuidGenerator.Create(), district.ProvinceId, district.CityId, district.Id, name, code);
    }

    public virtual async Task SetNameAsync(Street street, string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        if (street.Name == name)
        {
            return;
        }
        if (await StreetRepository.AnyAsync(s => s.Id != street.Id && s.Name == name))
        {
            throw new BusinessException(RegionManagementErrorCodes.StreetNameExists);
        }
        street.Name = name;
    }

    public virtual async Task SetCodeAsync(Street street, string code)
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));
        if (street.Code == code)
        { return; }
        if (await StreetRepository.AnyAsync(s => s.Id != street.Id && s.Code == code))
        {
            throw new BusinessException(RegionManagementErrorCodes.StreetCodeExists);
        }
        street.Code = code;
    }

    public virtual async Task SetDistrictAsync(Street street, Guid districtId)
    {
        if (street.DistrictId == districtId)
        { return; }
        var district = await DistrictRepository.FindAsync(districtId)
            ?? throw new BusinessException(RegionManagementErrorCodes.DistrictNotExists);

        street.CityId = district.CityId;
        street.ProvinceId = district.ProvinceId;
        street.DistrictId = district.Id;
    }
}
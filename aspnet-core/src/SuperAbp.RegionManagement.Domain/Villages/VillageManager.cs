using SuperAbp.RegionManagement.Districts;
using SuperAbp.RegionManagement.Streets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace SuperAbp.RegionManagement.Villages;

public class VillageManager : DomainService
{
    protected IStreetRepository StreetRepository { get; }
    protected IVillageRepository VillageRepository { get; }

    public VillageManager(IStreetRepository streetRepository, IVillageRepository villageRepository)
    {
        StreetRepository = streetRepository;
        VillageRepository = villageRepository;
    }

    public virtual async Task<Village> CreateAsync(Guid streetId, string name, string code)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        Check.NotNullOrWhiteSpace(code, nameof(code));

        var street = await StreetRepository.FindAsync(streetId)
            ?? throw new BusinessException(RegionManagementErrorCodes.StreetNotExists);
        if (await VillageRepository.AnyAsync(v => v.Name == name))
        {
            throw new BusinessException(RegionManagementErrorCodes.VillageNameExists);
        }
        if (await VillageRepository.AnyAsync(v => v.Code == code))
        {
            throw new BusinessException(RegionManagementErrorCodes.VillageCodeExists);
        }
        return new Village(GuidGenerator.Create(), street.ProvinceId, street.CityId, street.DistrictId, street.Id, name, code);
    }

    public virtual async Task SetNameAsync(Village village, string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));
        if (village.Name == name)
        {
            return;
        }
        if (await VillageRepository.AnyAsync(s => s.Id != village.Id && s.Name == name))
        {
            throw new BusinessException(RegionManagementErrorCodes.VillageNameExists);
        }
        village.Name = name;
    }

    public virtual async Task SetCodeAsync(Village village, string code)
    {
        Check.NotNullOrWhiteSpace(code, nameof(code));
        if (village.Code == code)
        {
            return;
        }
        if (await VillageRepository.AnyAsync(s => s.Id != village.Id && s.Code == code))
        {
            throw new BusinessException(RegionManagementErrorCodes.VillageCodeExists);
        }
        village.Code = code;
    }

    public virtual async Task SetStreetAsync(Village village, Guid streetId)
    {
        if (village.StreetId == streetId)
        {
            return;
        }
        var street = await StreetRepository.FindAsync(streetId)
            ?? throw new BusinessException(RegionManagementErrorCodes.StreetNotExists);

        village.CityId = street.CityId;
        village.ProvinceId = street.ProvinceId;
        village.DistrictId = street.DistrictId;
        village.StreetId = street.Id;
    }
}
using SuperAbp.RegionManagement.Cities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Villages;

public class VillageAppService : RegionManagementAppService, IVillageAppService
{
    private readonly IVillageRepository _villageRepository;

    public VillageAppService(IVillageRepository villageRepository)
    {
        _villageRepository = villageRepository;
    }

    public async Task<ListResultDto<VillageListDto>> GetListAsync(Guid streetId)
    {
        var provinces = await _villageRepository.GetListByStreetIdAsync(streetId);
        return new ListResultDto<VillageListDto>(ObjectMapper.Map<List<Village>, List<VillageListDto>>(provinces.ToList()));
    }
}
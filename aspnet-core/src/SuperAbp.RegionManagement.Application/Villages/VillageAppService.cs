using SuperAbp.RegionManagement.Cities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Villages;

public class VillageAppService : RegionManagementAppService, IVillageAppService
{
    protected IVillageRepository VillageRepository { get; }

    public VillageAppService(IVillageRepository villageRepository)
    {
        VillageRepository = villageRepository;
    }

    public virtual async Task<ListResultDto<VillageListDto>> GetListAsync(Guid streetId)
    {
        var provinces = await VillageRepository.GetListByStreetIdAsync(streetId);
        return new ListResultDto<VillageListDto>(ObjectMapper.Map<List<Village>, List<VillageListDto>>(provinces.ToList()));
    }
}
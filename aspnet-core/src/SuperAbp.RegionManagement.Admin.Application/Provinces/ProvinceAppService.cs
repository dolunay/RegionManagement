using System.Collections.Generic;
using System.Threading.Tasks;
using SuperAbp.RegionManagement.Provinces;

namespace SuperAbp.RegionManagement.Admin.Provinces;

public class ProvinceAppService : RegionManagementAppService, IProvinceAppService
{
    private readonly IProvinceRepository _provinceRepository;

    public ProvinceAppService(IProvinceRepository provinceRepository)
    {
        _provinceRepository = provinceRepository;
    }

    public async Task<List<ProvinceListDto>> GetAllListAsync()
    {
        var provinces = await _provinceRepository.GetListAsync();
        return ObjectMapper.Map<List<Province>, List<ProvinceListDto>>(provinces);
    }
}
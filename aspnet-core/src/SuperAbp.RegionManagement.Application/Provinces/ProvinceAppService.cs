using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Provinces
{
    public class ProvinceAppService : RegionManagementAppService, IProvinceAppService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceAppService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task<ListResultDto<ProvinceListDto>> GetListAsync()
        {
            var provinces = await _provinceRepository.GetListAsync();
            return new ListResultDto<ProvinceListDto>(ObjectMapper.Map<List<Province>, List<ProvinceListDto>>(provinces));
        }
    }
}
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
        protected IProvinceRepository ProvinceRepository { get; }

        public ProvinceAppService(IProvinceRepository provinceRepository)
        {
            ProvinceRepository = provinceRepository;
        }

        public virtual async Task<ListResultDto<ProvinceListDto>> GetListAsync()
        {
            var provinces = await ProvinceRepository.GetListAsync();
            return new ListResultDto<ProvinceListDto>(ObjectMapper.Map<List<Province>, List<ProvinceListDto>>(provinces));
        }
    }
}
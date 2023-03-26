using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SuperAbp.RegionManagement.Provinces
{
    /// <summary>
    /// 省份
    /// </summary>
    public interface IProvinceAppService : IApplicationService
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<ProvinceListDto>> GetListAsync();
    }
}
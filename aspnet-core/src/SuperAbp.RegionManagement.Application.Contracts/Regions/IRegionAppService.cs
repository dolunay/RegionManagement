using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Snow.RegionManagement.Regions
{
    /// <summary>
    /// 区域管理
    /// </summary>
    public interface IRegionAppService : IApplicationService
    {
        /// <summary>
        /// 获取根
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<RegionNodeDto>> GetRootAsync();

        /// <summary>
        /// 下级
        /// </summary>
        /// <param name="id">父Id</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        Task<ListResultDto<RegionNodeDto>> GetChildrenAsync(Guid id, RegionLevel level);
    }
}
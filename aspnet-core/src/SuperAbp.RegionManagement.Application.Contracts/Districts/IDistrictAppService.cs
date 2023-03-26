using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Districts;

/// <summary>
/// 地区
/// </summary>
public interface IDistrictAppService : IApplicationService
{
    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="cityId">城市</param>
    /// <returns></returns>
    Task<ListResultDto<DistrictListDto>> GetListAsync(Guid cityId);
}
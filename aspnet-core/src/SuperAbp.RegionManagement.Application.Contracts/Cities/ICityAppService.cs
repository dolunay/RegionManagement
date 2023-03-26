using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SuperAbp.RegionManagement.Cities;

/// <summary>
/// 城市
/// </summary>
public interface ICityAppService : IApplicationService
{
    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="provinceId">省份Id</param>
    /// <returns></returns>
    Task<ListResultDto<CityListDto>> GetListAsync(Guid provinceId);
}
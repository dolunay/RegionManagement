using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Streets;

/// <summary>
/// 乡镇
/// </summary>
public interface IStreetAppService : IApplicationService
{
    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="districtId">区域Id</param>
    /// <returns></returns>
    Task<ListResultDto<StreetListDto>> GetListAsync(Guid districtId);
}
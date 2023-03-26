using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Villages;

/// <summary>
/// 村庄
/// </summary>
public interface IVillageAppService : IApplicationService
{
    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="streetId">乡镇Id</param>
    /// <returns></returns>
    Task<ListResultDto<VillageListDto>> GetListAsync(Guid streetId);
}
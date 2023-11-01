using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Districts;

/// <summary>
/// 地区
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/region/districts")]
public class DistrictController : RegionManagementController, IDistrictAppService
{
    protected IDistrictAppService DistrictAppService { get; }

    public DistrictController(IDistrictAppService districtAppService)
    {
        DistrictAppService = districtAppService;
    }

    /// <summary>
    /// 列
    /// </summary>
    /// <param name="cityId">城市Id</param>
    /// <returns></returns>
    [HttpGet("{cityId}")]
    public virtual async Task<ListResultDto<DistrictListDto>> GetListAsync(Guid cityId)
    {
        return await DistrictAppService.GetListAsync(cityId);
    }
}
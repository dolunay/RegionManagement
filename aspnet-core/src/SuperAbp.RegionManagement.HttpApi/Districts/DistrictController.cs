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
    private readonly IDistrictAppService _districtAppService;

    public DistrictController(IDistrictAppService districtAppService)
    {
        _districtAppService = districtAppService;
    }

    /// <summary>
    /// 列
    /// </summary>
    /// <param name="cityId">城市Id</param>
    /// <returns></returns>
    [HttpGet("{cityId}")]
    public async Task<ListResultDto<DistrictListDto>> GetListAsync(Guid cityId)
    {
        return await _districtAppService.GetListAsync(cityId);
    }
}
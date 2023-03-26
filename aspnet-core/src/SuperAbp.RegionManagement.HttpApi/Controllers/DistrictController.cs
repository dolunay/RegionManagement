using Microsoft.AspNetCore.Mvc;
using SuperAbp.RegionManagement.Districts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Controllers;

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
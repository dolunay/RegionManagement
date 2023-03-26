using Microsoft.AspNetCore.Mvc;
using SuperAbp.RegionManagement.Streets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Controllers;

/// <summary>
/// 乡镇
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/region/streets")]
public class StreetController : RegionManagementController, IStreetAppService
{
    private readonly IStreetAppService _streetAppService;

    public StreetController(IStreetAppService streetAppService)
    {
        _streetAppService = streetAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="districtId">区域Id</param>
    /// <returns></returns>
    [HttpGet("{districtId}")]
    public async Task<ListResultDto<StreetListDto>> GetListAsync(Guid districtId)
    {
        return await _streetAppService.GetListAsync(districtId);
    }
}
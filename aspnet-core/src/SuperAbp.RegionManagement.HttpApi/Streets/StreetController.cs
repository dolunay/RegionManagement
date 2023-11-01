using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Streets;

/// <summary>
/// 乡镇
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/region/streets")]
public class StreetController : RegionManagementController, IStreetAppService
{
    protected IStreetAppService StreetAppService { get; }

    public StreetController(IStreetAppService streetAppService)
    {
        StreetAppService = streetAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="districtId">区域Id</param>
    /// <returns></returns>
    [HttpGet("{districtId}")]
    public virtual async Task<ListResultDto<StreetListDto>> GetListAsync(Guid districtId)
    {
        return await StreetAppService.GetListAsync(districtId);
    }
}
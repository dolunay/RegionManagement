using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Villages;

/// <summary>
/// 村庄
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/region/villages")]
public class VillageController : RegionManagementController, IVillageAppService
{
    protected IVillageAppService VillageAppService { get; }

    public VillageController(IVillageAppService villageAppService)
    {
        VillageAppService = villageAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="streetId">乡镇Id</param>
    /// <returns></returns>
    [HttpGet("{streetId}")]
    public virtual async Task<ListResultDto<VillageListDto>> GetListAsync(Guid streetId)
    {
        return await VillageAppService.GetListAsync(streetId);
    }
}
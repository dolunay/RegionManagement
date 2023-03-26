using Microsoft.AspNetCore.Mvc;
using SuperAbp.RegionManagement.Provinces;
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
/// 省份
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/region/provinces")]
public class ProvinceController : RegionManagementController, IProvinceAppService
{
    private readonly IProvinceAppService _provinceAppService;

    public ProvinceController(IProvinceAppService provinceAppService)
    {
        _provinceAppService = provinceAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ListResultDto<ProvinceListDto>> GetListAsync()
    {
        return await _provinceAppService.GetListAsync();
    }
}
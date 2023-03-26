using Microsoft.AspNetCore.Mvc;
using SuperAbp.RegionManagement.Cities;
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
/// 城市
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/region/cities")]
public class CityController : RegionManagementController, ICityAppService
{
    private readonly ICityAppService _cityAppService;

    public CityController(ICityAppService cityAppService)
    {
        _cityAppService = cityAppService;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="provinceId">省份Id</param>
    /// <returns></returns>
    [HttpGet("{provinceId}")]
    public async Task<ListResultDto<CityListDto>> GetListAsync(Guid provinceId)
    {
        return await _cityAppService.GetListAsync(provinceId);
    }
}
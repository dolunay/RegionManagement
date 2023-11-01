using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Cities;

/// <summary>
/// 城市
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/region/cities")]
public class CityController : RegionManagementController, ICityAppService
{
    protected ICityAppService CityAppService { get; }

    public CityController(ICityAppService cityAppService)
    {
        CityAppService = cityAppService;
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="provinceId">省份Id</param>
    /// <returns></returns>
    [HttpGet("{provinceId}")]
    public virtual async Task<ListResultDto<CityListDto>> GetListAsync(Guid provinceId)
    {
        return await CityAppService.GetListAsync(provinceId);
    }
}
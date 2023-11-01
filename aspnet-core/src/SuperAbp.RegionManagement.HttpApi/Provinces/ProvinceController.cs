using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Provinces;

/// <summary>
/// 省份
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/region/provinces")]
public class ProvinceController : RegionManagementController, IProvinceAppService
{
    protected IProvinceAppService ProvinceAppService { get; }

    public ProvinceController(IProvinceAppService provinceAppService)
    {
        ProvinceAppService = provinceAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public virtual async Task<ListResultDto<ProvinceListDto>> GetListAsync()
    {
        return await ProvinceAppService.GetListAsync();
    }
}
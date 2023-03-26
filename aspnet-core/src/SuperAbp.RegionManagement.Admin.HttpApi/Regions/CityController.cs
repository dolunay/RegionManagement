using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using SuperAbp.RegionManagement.Admin.Cities;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Regions;

/// <summary>
/// 城市
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/admin/region/cities")]
public class CityController : RegionManagementController, ICityAppService
{
    private readonly ICityAppService _cityAppService;

    public CityController(ICityAppService cityAppService)
    {
        _cityAppService = cityAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="provinceId">省Id</param>
    /// <returns></returns>
    [HttpGet("{provinceId}/children")]
    public async Task<ListResultDto<CityListDto>> GetChildrenAsync(Guid provinceId)
    {
        return await _cityAppService.GetChildrenAsync(provinceId);
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>结果</returns>
    [HttpGet]
    public async Task<PagedResultDto<CityListDto>> GetListAsync(GetCitiesInput input)
    {
        return await _cityAppService.GetListAsync(input);
    }

    /// <summary>
    /// 获取修改
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<GetCityForEditorOutput> GetEditorAsync(Guid id)
    {
        return await _cityAppService.GetEditorAsync(id);
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<CityListDto> CreateAsync(CityCreateDto input)
    {
        return await _cityAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">主键</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<CityListDto> UpdateAsync(Guid id, CityUpdateDto input)
    {
        return await _cityAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        await _cityAppService.DeleteAsync(id);
    }
}
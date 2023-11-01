using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Cities;

/// <summary>
/// 城市
/// </summary>
[RemoteService(Name = RegionManagementAdminRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementAdminRemoteServiceConsts.ModuleName)]
[Route("api/admin/region/cities")]
public class CityAdminController : RegionManagementAdminController, ICityAdminAppService
{
    protected ICityAdminAppService CityAppService { get; }

    public CityAdminController(ICityAdminAppService cityAppService)
    {
        CityAppService = cityAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="provinceId">省Id</param>
    /// <returns></returns>
    [HttpGet("{provinceId}/children")]
    public virtual async Task<ListResultDto<CityListDto>> GetChildrenAsync(Guid provinceId)
    {
        return await CityAppService.GetChildrenAsync(provinceId);
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>结果</returns>
    [HttpGet]
    public virtual async Task<PagedResultDto<CityListDto>> GetListAsync(GetCitiesInput input)
    {
        return await CityAppService.GetListAsync(input);
    }

    /// <summary>
    /// 获取修改
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public virtual async Task<GetCityForEditorOutput> GetEditorAsync(Guid id)
    {
        return await CityAppService.GetEditorAsync(id);
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task<CityListDto> CreateAsync(CityCreateDto input)
    {
        return await CityAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">主键</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public virtual async Task<CityListDto> UpdateAsync(Guid id, CityUpdateDto input)
    {
        return await CityAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public virtual async Task DeleteAsync(Guid id)
    {
        await CityAppService.DeleteAsync(id);
    }
}
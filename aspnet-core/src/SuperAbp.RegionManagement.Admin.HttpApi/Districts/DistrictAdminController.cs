using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Districts;

/// <summary>
/// 地区管理
/// </summary>
[RemoteService(Name = RegionManagementAdminRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementAdminRemoteServiceConsts.ModuleName)]
[Route("api/admin/region/districts")]
public class DistrictAdminController : RegionManagementAdminController, IDistrictAdminAppService
{
    protected IDistrictAdminAppService DistrictAppService { get; }

    public DistrictAdminController(IDistrictAdminAppService districtAppService)
    {
        DistrictAppService = districtAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="cityId">市Id</param>
    /// <returns></returns>
    [HttpGet("{cityId}/children")]
    public virtual async Task<ListResultDto<DistrictListDto>> GetChildrenAsync(Guid cityId)
    {
        return await DistrictAppService.GetChildrenAsync(cityId);
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>结果</returns>
    [HttpGet]
    public virtual async Task<PagedResultDto<DistrictListDto>> GetListAsync(GetDistrictsInput input)
    {
        return await DistrictAppService.GetListAsync(input);
    }

    /// <summary>
    /// 获取修改
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public virtual async Task<GetDistrictForEditorOutput> GetEditorAsync(Guid id)
    {
        return await DistrictAppService.GetEditorAsync(id);
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task<DistrictListDto> CreateAsync(DistrictCreateDto input)
    {
        return await DistrictAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">主键</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public virtual async Task<DistrictListDto> UpdateAsync(Guid id, DistrictUpdateDto input)
    {
        return await DistrictAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public virtual async Task DeleteAsync(Guid id)
    {
        await DistrictAppService.DeleteAsync(id);
    }
}
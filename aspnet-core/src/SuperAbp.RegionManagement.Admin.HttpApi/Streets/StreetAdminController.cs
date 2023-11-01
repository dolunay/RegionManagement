using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Streets;

/// <summary>
/// 镇管理
/// </summary>
[RemoteService(Name = RegionManagementAdminRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementAdminRemoteServiceConsts.ModuleName)]
[Route("api/admin/region/streets")]
public class StreetAdminController : RegionManagementAdminController, IStreetAdminAppService
{
    protected IStreetAdminAppService StreetAppService { get; }

    public StreetAdminController(IStreetAdminAppService streetAppService)
    {
        StreetAppService = streetAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="districtId">区Id</param>
    /// <returns></returns>
    [HttpGet("{districtId}/children")]
    public virtual async Task<ListResultDto<StreetListDto>> GetChildrenAsync(Guid districtId)
    {
        return await StreetAppService.GetChildrenAsync(districtId);
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>结果</returns>
    [HttpGet]
    public virtual async Task<PagedResultDto<StreetListDto>> GetListAsync(GetStreetsInput input)
    {
        return await StreetAppService.GetListAsync(input);
    }

    /// <summary>
    /// 获取修改
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public virtual async Task<GetStreetForEditorOutput> GetEditorAsync(Guid id)
    {
        return await StreetAppService.GetEditorAsync(id);
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task<StreetListDto> CreateAsync(StreetCreateDto input)
    {
        return await StreetAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">主键</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public virtual async Task<StreetListDto> UpdateAsync(Guid id, StreetUpdateDto input)
    {
        return await StreetAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public virtual async Task DeleteAsync(Guid id)
    {
        await StreetAppService.DeleteAsync(id);
    }
}
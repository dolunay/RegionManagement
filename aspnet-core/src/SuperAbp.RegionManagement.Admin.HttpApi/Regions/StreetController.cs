using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using SuperAbp.RegionManagement.Admin.Streets;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Regions;

/// <summary>
/// 镇管理
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/admin/region/streets")]
public class StreetController : RegionManagementController, IStreetAppService
{
    private readonly IStreetAppService _streetAppService;

    public StreetController(IStreetAppService streetAppService)
    {
        _streetAppService = streetAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="districtId">区Id</param>
    /// <returns></returns>
    [HttpGet("{districtId}/children")]
    public async Task<ListResultDto<StreetListDto>> GetChildrenAsync(Guid districtId)
    {
        return await _streetAppService.GetChildrenAsync(districtId);
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>结果</returns>
    [HttpGet]
    public async Task<PagedResultDto<StreetListDto>> GetListAsync(GetStreetsInput input)
    {
        return await _streetAppService.GetListAsync(input);
    }

    /// <summary>
    /// 获取修改
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<GetStreetForEditorOutput> GetEditorAsync(Guid id)
    {
        return await _streetAppService.GetEditorAsync(id);
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<StreetListDto> CreateAsync(StreetCreateDto input)
    {
        return await _streetAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">主键</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<StreetListDto> UpdateAsync(Guid id, StreetUpdateDto input)
    {
        return await _streetAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        await _streetAppService.DeleteAsync(id);
    }
}
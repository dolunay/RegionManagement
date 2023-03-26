using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using SuperAbp.RegionManagement.Admin.Districts;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Regions;

/// <summary>
/// 地区管理
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/admin/region/districts")]
public class DistrictController : RegionManagementController, IDistrictAppService
{
    private readonly IDistrictAppService _districtAppService;

    public DistrictController(IDistrictAppService districtAppService)
    {
        _districtAppService = districtAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="cityId">市Id</param>
    /// <returns></returns>
    [HttpGet("{cityId}/children")]
    public async Task<ListResultDto<DistrictListDto>> GetChildrenAsync(Guid cityId)
    {
        return await _districtAppService.GetChildrenAsync(cityId);
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>结果</returns>
    [HttpGet]
    public async Task<PagedResultDto<DistrictListDto>> GetListAsync(GetDistrictsInput input)
    {
        return await _districtAppService.GetListAsync(input);
    }

    /// <summary>
    /// 获取修改
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<GetDistrictForEditorOutput> GetEditorAsync(Guid id)
    {
        return await _districtAppService.GetEditorAsync(id);
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<DistrictListDto> CreateAsync(DistrictCreateDto input)
    {
        return await _districtAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">主键</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<DistrictListDto> UpdateAsync(Guid id, DistrictUpdateDto input)
    {
        return await _districtAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        await _districtAppService.DeleteAsync(id);
    }
}
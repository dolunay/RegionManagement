using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Villages;

/// <summary>
/// 乡管理
/// </summary>
[RemoteService(Name = RegionManagementAdminRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementAdminRemoteServiceConsts.ModuleName)]
[Route("api/admin/region/villages")]
public class VillageAdminController : RegionManagementAdminController, IVillageAdminAppService
{
    private readonly IVillageAdminAppService _villageAppService;

    public VillageAdminController(IVillageAdminAppService villageAppService)
    {
        _villageAppService = villageAppService;
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="streetId">乡镇Id</param>
    /// <returns></returns>
    [HttpGet("{streetId}/children")]
    public async Task<ListResultDto<VillageListDto>> GetChildrenAsync(Guid streetId)
    {
        return await _villageAppService.GetChildrenAsync(streetId);
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>结果</returns>
    [HttpGet]
    public async Task<PagedResultDto<VillageListDto>> GetListAsync(GetVillagesInput input)
    {
        return await _villageAppService.GetListAsync(input);
    }

    /// <summary>
    /// 获取修改
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<GetVillageForEditorOutput> GetEditorAsync(Guid id)
    {
        return await _villageAppService.GetEditorAsync(id);
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<VillageListDto> CreateAsync(VillageCreateDto input)
    {
        return await _villageAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">主键</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<VillageListDto> UpdateAsync(Guid id, VillageUpdateDto input)
    {
        return await _villageAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        await _villageAppService.DeleteAsync(id);
    }
}
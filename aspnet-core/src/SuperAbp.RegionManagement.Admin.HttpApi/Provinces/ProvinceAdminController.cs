using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Provinces;

/// <summary>
/// 省管理
/// </summary>
[RemoteService(Name = RegionManagementAdminRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementAdminRemoteServiceConsts.ModuleName)]
[Route("api/admin/region/provinces")]
public class ProvinceAdminController : RegionManagementAdminController, IProvinceAdminAppService
{
    protected IProvinceAdminAppService ProvinceAppService { get; }

    public ProvinceAdminController(IProvinceAdminAppService provinceAppService)
    {
        ProvinceAppService = provinceAppService;
    }

    /// <summary>
    /// 所有
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    public virtual async Task<ListResultDto<ProvinceListDto>> GetAllListAsync()
    {
        return await ProvinceAppService.GetAllListAsync();
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>结果</returns>
    [HttpGet]
    public virtual async Task<PagedResultDto<ProvinceListDto>> GetListAsync(GetProvincesInput input)
    {
        return await ProvinceAppService.GetListAsync(input);
    }

    /// <summary>
    /// 获取修改
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public virtual async Task<GetProvinceForEditorOutput> GetEditorAsync(Guid id)
    {
        return await ProvinceAppService.GetEditorAsync(id);
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public virtual async Task<ProvinceListDto> CreateAsync(ProvinceCreateDto input)
    {
        return await ProvinceAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">主键</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public virtual async Task<ProvinceListDto> UpdateAsync(Guid id, ProvinceUpdateDto input)
    {
        return await ProvinceAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public virtual async Task DeleteAsync(Guid id)
    {
        await ProvinceAppService.DeleteAsync(id);
    }
}
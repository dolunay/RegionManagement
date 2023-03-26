using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using SuperAbp.RegionManagement.Admin.Provinces;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Regions;

/// <summary>
/// 省管理
/// </summary>
[RemoteService(Name = RegionManagementRemoteServiceConsts.RemoteServiceName)]
[Area(RegionManagementRemoteServiceConsts.ModuleName)]
[Route("api/admin/region/provinces")]
public class ProvinceController : RegionManagementController, IProvinceAppService
{
    private readonly IProvinceAppService _provinceAppService;

    public ProvinceController(IProvinceAppService provinceAppService)
    {
        _provinceAppService = provinceAppService;
    }

    /// <summary>
    /// 所有
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    public async Task<ListResultDto<ProvinceListDto>> GetAllListAsync()
    {
        return await _provinceAppService.GetAllListAsync();
    }

    /// <summary>
    /// 列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>结果</returns>
    [HttpGet]
    public async Task<PagedResultDto<ProvinceListDto>> GetListAsync(GetProvincesInput input)
    {
        return await _provinceAppService.GetListAsync(input);
    }

    /// <summary>
    /// 获取修改
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<GetProvinceForEditorOutput> GetEditorAsync(Guid id)
    {
        return await _provinceAppService.GetEditorAsync(id);
    }

    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ProvinceListDto> CreateAsync(ProvinceCreateDto input)
    {
        return await _provinceAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id">主键</param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ProvinceListDto> UpdateAsync(Guid id, ProvinceUpdateDto input)
    {
        return await _provinceAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id">主键</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(Guid id)
    {
        await _provinceAppService.DeleteAsync(id);
    }
}
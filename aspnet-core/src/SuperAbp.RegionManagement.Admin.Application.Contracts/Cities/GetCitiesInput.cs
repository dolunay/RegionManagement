using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Cities
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class GetCitiesInput : PagedAndSortedResultRequestDto
    {
        public Guid ProvinceId { get; set; }
    }
}
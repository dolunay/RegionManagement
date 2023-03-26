using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Districts
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class GetDistrictsInput : PagedAndSortedResultRequestDto
    {
        public Guid CityId { get; set; }
    }
}
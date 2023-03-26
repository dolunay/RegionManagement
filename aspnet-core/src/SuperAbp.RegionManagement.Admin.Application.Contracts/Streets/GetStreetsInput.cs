using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Streets
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class GetStreetsInput : PagedAndSortedResultRequestDto
    {
        public Guid DistrictId { get; set; }
    }
}
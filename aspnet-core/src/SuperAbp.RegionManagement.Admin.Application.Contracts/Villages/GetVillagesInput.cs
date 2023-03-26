using System;
using Volo.Abp.Application.Dtos;

namespace SuperAbp.RegionManagement.Admin.Villages
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class GetVillagesInput : PagedAndSortedResultRequestDto
    {
        public Guid StreetId { get; set; }
    }
}
using System;
using Volo.Abp.Domain.Entities;

namespace SuperAbp.RegionManagement.Locations
{
    public class RegionLocation : Entity<Guid>
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Longitude { get; set; }

        public Guid RegionId { get; set; }

        public RegionLevel Level { get; set; }
    }
}

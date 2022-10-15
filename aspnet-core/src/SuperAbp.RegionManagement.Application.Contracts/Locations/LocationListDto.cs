using System;

namespace SuperAbp.RegionManagement.Locations;

public class LocationListDto
{
    /// <summary>
    /// 纬度
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// 经度
    /// </summary>
    public double Longitude { get; set; }

    public Guid? RegionId { get; set; }
}
namespace SuperAbp.RegionManagement;

public static class RegionManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "SuperAbp";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "RegionManagement";
}

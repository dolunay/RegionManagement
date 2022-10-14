namespace SuperAbp.RegionManagement;

public static class RegionManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "RegionManagement";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "RegionManagement";
}

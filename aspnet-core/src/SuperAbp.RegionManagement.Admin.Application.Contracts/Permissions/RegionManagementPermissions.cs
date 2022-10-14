using Volo.Abp.Reflection;

namespace SuperAbp.RegionManagement.Permissions;

public class RegionManagementPermissions
{
    public const string GroupName = "RegionManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(RegionManagementPermissions));
    }
}

using Volo.Abp.Reflection;

namespace SuperAbp.RegionManagement.Permissions
{
    public class RegionManagementPermissions
    {
        public const string GroupName = "SuperAbpRegionManagement";

        public static class Regions
        {
            public const string Default = GroupName + ".Region";
            public const string Management = Default + ".Management";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(RegionManagementPermissions));
        }
    }
}
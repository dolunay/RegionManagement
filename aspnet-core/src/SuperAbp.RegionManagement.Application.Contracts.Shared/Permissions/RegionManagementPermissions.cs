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

        public static class Provinces
        {
            public const string Default = GroupName + ".Province";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class Cities
        {
            public const string Default = GroupName + ".City";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class Districts
        {
            public const string Default = GroupName + ".District";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class Streets
        {
            public const string Default = GroupName + ".Street";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static class Villages
        {
            public const string Default = GroupName + ".Village";
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
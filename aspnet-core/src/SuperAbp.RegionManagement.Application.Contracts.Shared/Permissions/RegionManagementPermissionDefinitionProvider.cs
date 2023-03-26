using SuperAbp.RegionManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SuperAbp.RegionManagement.Permissions
{
    public class RegionManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(RegionManagementPermissions.GroupName, L("Permission:RegionManagement"));

            var regions = myGroup.AddPermission(RegionManagementPermissions.Regions.Default, L("Permission:Region"));
            regions.AddChild(RegionManagementPermissions.Regions.Management, L("Permission:Management"));
            regions.AddChild(RegionManagementPermissions.Regions.Create, L("Permission:Create"));
            regions.AddChild(RegionManagementPermissions.Regions.Update, L("Permission:Edit"));
            regions.AddChild(RegionManagementPermissions.Regions.Delete, L("Permission:Delete"));

            var provinces = myGroup.AddPermission(RegionManagementPermissions.Provinces.Default, L("Permission:Province"));
            provinces.AddChild(RegionManagementPermissions.Provinces.Create, L("Permission:Create"));
            provinces.AddChild(RegionManagementPermissions.Provinces.Update, L("Permission:Edit"));
            provinces.AddChild(RegionManagementPermissions.Provinces.Delete, L("Permission:Delete"));

            var cities = myGroup.AddPermission(RegionManagementPermissions.Cities.Default, L("Permission:City"));
            cities.AddChild(RegionManagementPermissions.Cities.Create, L("Permission:Create"));
            cities.AddChild(RegionManagementPermissions.Cities.Update, L("Permission:Edit"));
            cities.AddChild(RegionManagementPermissions.Cities.Delete, L("Permission:Delete"));

            var districts = myGroup.AddPermission(RegionManagementPermissions.Districts.Default, L("Permission:District"));
            districts.AddChild(RegionManagementPermissions.Districts.Create, L("Permission:Create"));
            districts.AddChild(RegionManagementPermissions.Districts.Update, L("Permission:Edit"));
            districts.AddChild(RegionManagementPermissions.Districts.Delete, L("Permission:Delete"));

            var streets = myGroup.AddPermission(RegionManagementPermissions.Streets.Default, L("Permission:Street"));
            streets.AddChild(RegionManagementPermissions.Streets.Create, L("Permission:Create"));
            streets.AddChild(RegionManagementPermissions.Streets.Update, L("Permission:Edit"));
            streets.AddChild(RegionManagementPermissions.Streets.Delete, L("Permission:Delete"));

            var villages = myGroup.AddPermission(RegionManagementPermissions.Villages.Default, L("Permission:Village"));
            villages.AddChild(RegionManagementPermissions.Villages.Create, L("Permission:Create"));
            villages.AddChild(RegionManagementPermissions.Villages.Update, L("Permission:Edit"));
            villages.AddChild(RegionManagementPermissions.Villages.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<RegionManagementResource>(name);
        }
    }
}
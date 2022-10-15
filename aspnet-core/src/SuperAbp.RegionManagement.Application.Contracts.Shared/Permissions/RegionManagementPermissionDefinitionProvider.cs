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

            var regions = myGroup.AddPermission(RegionManagementPermissions.Regions.Default, L("Permission:Regions"));
            regions.AddChild(RegionManagementPermissions.Regions.Management, L("Permission:Management"));
            regions.AddChild(RegionManagementPermissions.Regions.Create, L("Permission:Create"));
            regions.AddChild(RegionManagementPermissions.Regions.Update, L("Permission:Edit"));
            regions.AddChild(RegionManagementPermissions.Regions.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<RegionManagementResource>(name);
        }
    }
}
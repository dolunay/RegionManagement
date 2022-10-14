using SuperAbp.RegionManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SuperAbp.RegionManagement.Permissions;

public class RegionManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(RegionManagementPermissions.GroupName, L("Permission:RegionManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RegionManagementResource>(name);
    }
}

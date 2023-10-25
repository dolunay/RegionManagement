using SuperAbp.RegionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SuperAbp.RegionManagement.Admin;

public abstract class RegionManagementAdminController : AbpControllerBase
{
    protected RegionManagementAdminController()
    {
        LocalizationResource = typeof(RegionManagementResource);
    }
}
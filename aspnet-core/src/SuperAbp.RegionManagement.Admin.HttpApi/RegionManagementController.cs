using SuperAbp.RegionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SuperAbp.RegionManagement.Admin;

public abstract class RegionManagementController : AbpControllerBase
{
    protected RegionManagementController()
    {
        LocalizationResource = typeof(RegionManagementResource);
    }
}

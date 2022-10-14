using SuperAbp.RegionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SuperAbp.RegionManagement.Pages;

public abstract class RegionManagementPageModel : AbpPageModel
{
    protected RegionManagementPageModel()
    {
        LocalizationResourceType = typeof(RegionManagementResource);
    }
}

using SuperAbp.RegionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SuperAbp.RegionManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class RegionManagementPageModel : AbpPageModel
{
    protected RegionManagementPageModel()
    {
        LocalizationResourceType = typeof(RegionManagementResource);
        ObjectMapperContext = typeof(SuperAbpRegionManagementWebModule);
    }
}

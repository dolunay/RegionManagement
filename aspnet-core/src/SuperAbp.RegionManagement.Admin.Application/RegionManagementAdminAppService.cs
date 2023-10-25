using SuperAbp.RegionManagement.Localization;
using Volo.Abp.Application.Services;

namespace SuperAbp.RegionManagement.Admin;

public abstract class RegionManagementAdminAppService : ApplicationService
{
    protected RegionManagementAdminAppService()
    {
        LocalizationResource = typeof(RegionManagementResource);
        ObjectMapperContext = typeof(SuperAbpRegionManagementAdminApplicationModule);
    }
}
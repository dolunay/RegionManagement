using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SuperAbp.RegionManagement;

[Dependency(ReplaceServices = true)]
public class RegionManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "RegionManagement";
}

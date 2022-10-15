using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SuperAbp.RegionManagement.EntityFrameworkCore;

[DependsOn(
    typeof(SuperAbpRegionManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class SuperAbpRegionManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<RegionManagementDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}

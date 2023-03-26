using Volo.Abp.Settings;

namespace SuperAbp.RegionManagement.Admin.Districts
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class DistrictSettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    DistrictSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}

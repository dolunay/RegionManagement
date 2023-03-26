using Volo.Abp.Settings;

namespace SuperAbp.RegionManagement.Admin.Cities
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class CitySettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    CitySettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}

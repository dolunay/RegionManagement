using Volo.Abp.Settings;

namespace SuperAbp.RegionManagement.Admin.Villages
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class VillageSettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    VillageSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}

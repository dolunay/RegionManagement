using Volo.Abp.Settings;

namespace SuperAbp.RegionManagement.Admin.Streets
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class StreetSettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    StreetSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}

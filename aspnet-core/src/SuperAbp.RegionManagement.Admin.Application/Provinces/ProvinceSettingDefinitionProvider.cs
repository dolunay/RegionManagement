using Volo.Abp.Settings;

namespace SuperAbp.RegionManagement.Admin.Provinces
{
    /// <summary>
    /// SettingDefinitionProvider
    /// </summary>
    public class ProvinceSettingDefinitionProvider : SettingDefinitionProvider
    {
    /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    ProvinceSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}

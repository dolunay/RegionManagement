using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Settings;

namespace SuperAbp.RegionManagement.Regions
{
    /// <summary>
    /// RegionSettingDefinitionProvider
    /// </summary>
    public class RegionSettingDefinitionProvider : SettingDefinitionProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition(
                    RegionSettings.MaxPageSize,
                    "100",
                    isVisibleToClients: true
                )
            );
        }
    }
}
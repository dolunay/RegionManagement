using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace SuperAbp.RegionManagement.Web.Menus;

public class RegionManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(RegionManagementMenus.Prefix, displayName: "RegionManagement", "~/RegionManagement", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}

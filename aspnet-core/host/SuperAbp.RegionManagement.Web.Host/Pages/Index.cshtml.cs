using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace SuperAbp.RegionManagement.Pages;

public class IndexModel : RegionManagementPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}

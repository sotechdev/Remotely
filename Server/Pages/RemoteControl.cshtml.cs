using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SODesk.Server.Auth;
using SODesk.Server.Services;
using SODesk.Shared.Models;

namespace SODesk.Server.Pages
{
    [ServiceFilter(typeof(RemoteControlFilterAttribute))]
    public class RemoteControlModel : PageModel
    {
        private readonly IDataService _dataService;
        public RemoteControlModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public SODeskUser SODeskUser { get; private set; }
        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                SODeskUser = _dataService.GetUserByNameWithOrg(base.User.Identity.Name);
            }
        }
    }
}

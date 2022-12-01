using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using SODesk.Server.Services;
using SODesk.Shared.Models;
using System.Threading.Tasks;

namespace SODesk.Server.Components
{
    public class AuthComponentBase : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            IsAuthenticated = await AuthService.IsAuthenticated();
            User = await AuthService.GetUser();
            Username = User?.UserName;
            await base.OnInitializedAsync();
        }

        public bool IsAuthenticated { get; private set; }

        public SODeskUser User { get; private set; }

        public string Username { get; private set; }

        [Inject]
        protected IAuthService AuthService { get; set; }
    }
}

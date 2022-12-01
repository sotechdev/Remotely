using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SODesk.Server.Services;
using SODesk.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SODesk.Server.Auth
{
    public class TwoFactorRequiredHandler : AuthorizationHandler<TwoFactorRequiredRequirement>
    {
        private readonly UserManager<SODeskUser> _userManager;
        private readonly IApplicationConfig _appConfig;

        public TwoFactorRequiredHandler(UserManager<SODeskUser> userManager, IApplicationConfig appConfig)
        {
            _userManager = userManager;
            _appConfig = appConfig;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, TwoFactorRequiredRequirement requirement)
        {
            if (context.User.Identity.IsAuthenticated && _appConfig.Require2FA)
            {
                var user = await _userManager.GetUserAsync(context.User);
                if (!user.TwoFactorEnabled)
                {
                    context.Fail();
                    return;
                }
            }
            context.Succeed(requirement);
        }
    }
}

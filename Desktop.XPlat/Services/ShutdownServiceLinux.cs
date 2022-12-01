using Microsoft.Extensions.DependencyInjection;
using SODesk.Desktop.Core;
using SODesk.Desktop.Core.Interfaces;
using SODesk.Desktop.Core.Services;
using SODesk.Shared.Utilities;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SODesk.Desktop.XPlat.Services
{
    public class ShutdownServiceLinux : IShutdownService
    {
        public async Task Shutdown()
        {
            Logger.Debug($"Exiting process ID {Environment.ProcessId}.");
            var casterSocket = ServiceContainer.Instance.GetRequiredService<ICasterSocket>();
            await casterSocket.DisconnectAllViewers();
            Environment.Exit(0);
        }
    }
}

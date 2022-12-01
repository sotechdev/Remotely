using Remotely.Shared.Models;

namespace Remotely.Desktop.Core.Interfaces;

public interface IConfigService
{
    DesktopAppConfig GetConfig();
    void Save(DesktopAppConfig config);
}

using System.Threading.Tasks;

namespace Remotely.Desktop.Core.Interfaces;

public interface IRemoteControlAccessService
{
    Task<bool> PromptForAccess(string requesterName, string organizationName);
}

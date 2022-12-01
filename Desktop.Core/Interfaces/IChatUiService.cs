using Remotely.Shared.Models;

using System;
using System.IO;

namespace Remotely.Desktop.Core.Interfaces;

public interface IChatUiService
{
    event EventHandler ChatWindowClosed;

    void ShowChatWindow(string organizationName, StreamWriter writer);
    void ReceiveChat(ChatMessage chatMessage);
}

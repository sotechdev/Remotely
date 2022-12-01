using Avalonia.Controls;
using Avalonia.Threading;
using SODesk.Desktop.Core.Interfaces;
using SODesk.Desktop.XPlat.Views;

namespace SODesk.Desktop.XPlat.Services
{
    public class SessionIndicatorLinux : ISessionIndicator
    {
        public void Show()
        {
            Dispatcher.UIThread.Post(() =>
            {
                var indicatorWindow = new SessionIndicatorWindow();
                indicatorWindow.Show();
            });
        }
    }
}

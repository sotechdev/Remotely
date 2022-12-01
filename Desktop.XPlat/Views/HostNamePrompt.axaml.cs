using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SODesk.Desktop.XPlat.ViewModels;
using SODesk.Desktop.XPlat.Views;

namespace SODesk.Desktop.XPlat.Views
{
    public class HostNamePrompt : Window
    {
        public HostNamePrompt()
        {
            Owner = MainWindow.Current;
            InitializeComponent();
        }

        public HostNamePromptViewModel ViewModel => DataContext as HostNamePromptViewModel;

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}

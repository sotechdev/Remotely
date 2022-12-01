﻿using Avalonia.Controls;
using ReactiveUI;
using SODesk.Desktop.XPlat.Services;
using System.Windows.Input;

namespace SODesk.Desktop.XPlat.ViewModels
{
    public class HostNamePromptViewModel : BrandedViewModelBase
    {
        public string _host = "https://";

        public string Host
        {
            get => _host;
            set => this.RaiseAndSetIfChanged(ref _host, value);
        }

        public ICommand OKCommand => new Executor((param) =>
        {
            (param as Window).Close();
        });
    }
}

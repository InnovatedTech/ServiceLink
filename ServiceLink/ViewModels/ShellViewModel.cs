using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.IconPacks;
using ServiceLink.Models;
using ServiceLink.Views.Pages;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;
using System.Windows.Threading;

namespace ServiceLink.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        public ObservableCollection<MenuItem> Menu { get; } = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> OptionsMenu { get; } = new ObservableCollection<MenuItem>();

        public ShellViewModel()
        {
            // Initialize menus
            InitializeMenus();
        }

        private void InitializeMenus()
        {
            this.Menu.Add(new MenuItem()
            {
                Icon = new PackIconForkAwesome() { Kind = PackIconForkAwesomeKind.BarChart},
                Label = "OVERVIEW",
                NavigationType = typeof(MainPage),
                NavigationDestination = new Uri("Views/Pages/MainPage.xaml", UriKind.RelativeOrAbsolute)
            });
            this.OptionsMenu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.GearSolid },
                Label = "PROJECT SETTINGS",
                NavigationType = typeof(ProjectSettingsPage),
                NavigationDestination = new Uri("Views/Pages/ProjectSettingsPage.xaml", UriKind.RelativeOrAbsolute)
            });
            this.OptionsMenu.Add(new MenuItem()
            {
                Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.InfoSolid },
                Label = "SUPPORT",
                NavigationType = typeof(SupportPage),
                NavigationDestination = new Uri("Views/Pages/SupportPage.xaml", UriKind.RelativeOrAbsolute)
            });
        }
    }
}

using ControlzEx.Theming;
using ServiceLink.Models;
using ServiceLink.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceLink
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Current.Dispatcher.InvokeAsync(async () =>
            {
                await Task.Delay(1000); // Small delay to ensure the window is loaded
                Update update = new Update();
                await update.RunUpdate();
            });
            var settings = SettingsViewModel.Instance;

            ThemeManager.Current.ChangeTheme(Application.Current, settings.Theme);

        }
        protected override void OnExit(ExitEventArgs e)
        {
            //SettingsViewModel.Instance.SaveSettings();
            //base.OnExit(e);
        }
    }
}
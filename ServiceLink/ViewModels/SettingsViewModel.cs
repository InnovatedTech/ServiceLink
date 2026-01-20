using CommunityToolkit.Mvvm.Input;
using ControlzEx.Theming;
using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace ServiceLink.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private static readonly object _lock = new object();
        private static SettingsViewModel _instance;

        public static SettingsViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SettingsViewModel();
                        }
                    }
                }
                return _instance;
            }
        }

        private SettingsViewModel()
        {
            LightThemeCommand = new RelayCommand(() => IsLightTheme = true);
            DarkThemeCommand = new RelayCommand(() => IsLightTheme = false);
        }


        // 🔹 Store Theme as a String in Settings
        public string Theme
        {
            get => Properties.Settings.Default.Theme;
            set
            {
                if (Properties.Settings.Default.Theme != value)
                {
                    Properties.Settings.Default.Theme = value;
                    SaveSettings();
                    ThemeManager.Current.ChangeTheme(Application.Current, value);
                    OnPropertyChanged(nameof(Theme));
                    OnPropertyChanged(nameof(IsDarkTheme));
                    OnPropertyChanged(nameof(IsLightTheme));
                }
            }
        }

        public bool IsDarkTheme
        {
            get => Theme.Contains("Dark");
            set
            {
                Theme = value ? "Dark.Cobalt" : "Light.Cobalt";
            }
        }

        public bool IsLightTheme
        {
            get => !IsDarkTheme;
            set
            {
                IsDarkTheme = !value;
            }
        }

        public ICommand LightThemeCommand { get; }
        public ICommand DarkThemeCommand { get; }

        public void SaveSettings()
        {
            try
            {
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings: " + ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


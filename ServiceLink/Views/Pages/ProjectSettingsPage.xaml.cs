using System.Windows.Controls;
using ServiceLink.ViewModels;

namespace ServiceLink.Views.Pages
{
    /// <summary>
    /// Interaction logic for ProjectSettingsPage.xaml
    /// </summary>
    public partial class ProjectSettingsPage : Page
    {
        readonly ProjectSettingsPageViewModel viewModel = new ProjectSettingsPageViewModel();
        public ProjectSettingsPage()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}

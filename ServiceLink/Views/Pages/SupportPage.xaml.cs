using System.Windows.Controls;
using ServiceLink.ViewModels;

namespace ServiceLink.Views.Pages
{
    /// <summary>
    /// Interaction logic for SupportPage.xaml
    /// </summary>
    public partial class SupportPage : Page
    {
        readonly SupportPageViewModel viewModel = new SupportPageViewModel();
        public SupportPage()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}

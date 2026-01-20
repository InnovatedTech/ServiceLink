using System.Windows.Controls;
using ServiceLink.ViewModels;

namespace ServiceLink.Views.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        readonly MainPageViewModel viewModel = new MainPageViewModel();
        public MainPage()
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}

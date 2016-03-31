using HearthstoneDeck.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace HearthstoneDeck.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        public MainPageViewModel ViewModel => this.DataContext as MainPageViewModel;
    }
}

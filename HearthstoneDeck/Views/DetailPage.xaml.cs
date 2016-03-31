using HearthstoneDeck.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;

namespace HearthstoneDeck.Views
{
    public sealed partial class DetailPage : Page
    {
        public DetailPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        public DetailPageViewModel ViewModel => this.DataContext as DetailPageViewModel;
    }
}


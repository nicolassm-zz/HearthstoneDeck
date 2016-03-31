using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using HearthstoneDeck.Models;
using HearthstoneDeck.Services.CardApi;
using HearthstoneDeck.Services.ImageLoader;
using Template10.Mvvm;
using Template10.Utils;

namespace HearthstoneDeck.ViewModels
{
    public class CardsPageViewModel : ViewModelBase
    {
        private readonly ICardApi _cardApi;
        private readonly IImageLoader _imageLoader;

        private ObservableCollection<Card> _cards;

        public ObservableCollection<Card> Cards
        {
            get { return _cards; }
            set { Set(ref _cards, value); }
        }

        private ObservableCollection<Card> _deckCards = new ObservableCollection<Card>();

        public ObservableCollection<Card> DeckCards
        {
            get { return _deckCards; }
            set { Set(ref _deckCards, value); }
        }

        public CardsPageViewModel(ICardApi cardApi, IImageLoader imageLoader)
        {
            _cardApi = cardApi;
            _imageLoader = imageLoader;
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            Cards = new ObservableCollection<Card>();
            var response = await _cardApi.GetAll();
            foreach (var basic in response.Basic)
            {
                //var card = await _cardApi.GetOne(basic.name);
                if (!String.IsNullOrEmpty(basic.img))
                {
                    basic.Image = await _imageLoader.GetFromUrl(basic.img);
                    Cards.Add(basic);
                }
            }
        }

    }
}

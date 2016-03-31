using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using HearthstoneDeck.Services.CardApi;
using HearthstoneDeck.Services.ImageLoader;
using Microsoft.Practices.ServiceLocation;

namespace HearthstoneDeck.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<ICardApi, CardApi>();
            SimpleIoc.Default.Register<IImageLoader, ImageLoader>();

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<SettingsPageViewModel>();
            SimpleIoc.Default.Register<DetailPageViewModel>();
            SimpleIoc.Default.Register<CardsPageViewModel>();
        }

        public MainPageViewModel MainPage => ServiceLocator.Current.GetInstance<MainPageViewModel>();
        public SettingsPageViewModel SettingsPage => ServiceLocator.Current.GetInstance<SettingsPageViewModel>();
        public DetailPageViewModel DetailPage => ServiceLocator.Current.GetInstance<DetailPageViewModel>();
        public CardsPageViewModel CardsPage => ServiceLocator.Current.GetInstance<CardsPageViewModel>();
    }
}

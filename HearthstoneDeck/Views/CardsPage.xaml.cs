using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HearthstoneDeck.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HearthstoneDeck.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CardsPage : Page
    {
        public CardsPage()
        {
            this.InitializeComponent();
        }

        private void Cards_OnDragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var items = String.Join(",", e.Items.Cast<Card>().Select(c => c.cardId));
            e.Data.Properties.Add("sourceList", sender as ListView);
            e.Data.SetText(items);
            e.Data.RequestedOperation = DataPackageOperation.Move;
        }

        private void Deck_OnDragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                e.AcceptedOperation = DataPackageOperation.Move;
            }
        }

        private async void Deck_OnDrop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var ids = await e.DataView.GetTextAsync();
                
                var destinationListView = sender as ListView;
                var destinationCollection = destinationListView?.ItemsSource as ObservableCollection<Card>;
                object sourceListView;
                if (!e.Data.Properties.TryGetValue("sourceList", out sourceListView))
                    return;
                
                var sourceCollection = ((ListView)sourceListView).ItemsSource as ObservableCollection<Card>;

                if (sourceCollection != null && destinationCollection != null && destinationCollection.Count()<30 )
                {
                    var count = 0;
                    foreach (var cardId in ids.Split(','))
                    {
                        foreach(var card in destinationCollection)
                        {
                            if (card.cardId == cardId)
                                count++;
                        }

                        if (count < 2)
                        {
                            var itemToMove = sourceCollection.First(c => c.cardId == cardId);

                            destinationCollection.Add(itemToMove);
                        }
                        //sourceCollection.Remove(itemToMove);
                    }
                }
            }
        }

        private void Deck_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var sourceListView = sender as ListView;
            var sourceCollection = sourceListView?.ItemsSource as ObservableCollection<Card>;

            var selectedCard = sourceListView.SelectedItem as Card;
            var id = selectedCard.cardId;

            var itemToRemove = sourceCollection.First(c => c.cardId == id);
            sourceCollection.Remove(itemToRemove);

        }
    }
}

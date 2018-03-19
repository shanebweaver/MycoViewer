using System;
using System.Linq;
using MycoViewer.ViewModels.Search;

using Windows.UI.Xaml.Controls;

namespace MycoViewer.Views.Search
{
    public sealed partial class MasterSearchPage : Page
    {
        private MasterSearchViewModel ViewModel => DataContext as MasterSearchViewModel;

        public MasterSearchPage()
        {
            InitializeComponent();
        }

        private void MasterSearchNavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItem is string)
            {
                NavigationViewItem item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                switch (item?.Tag)
                {
                    case "basic": 
                    case "advanced":
                    case "specimens": 
                    case "thesaurus": 
                    case "bibliography":
                        ContentFrame.Navigate(typeof(SearchPage), item?.Tag); break;
                }
            }
        }

        private void MasterSearchNavView_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SimpleSearchPage));
        }
    }
}
